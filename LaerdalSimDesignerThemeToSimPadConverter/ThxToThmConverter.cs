using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using LaerdalSimDesignerThemeToSimPadConverter.Converters;
using LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;
using LaerdalSimDesignerThemeToSimPadConverter.Models.SimPad;
using Event = LaerdalSimDesignerThemeToSimPadConverter.Models.SimPad.Event;

namespace LaerdalSimDesignerThemeToSimPadConverter;

public class ThxToThmConverter
{
    private readonly ThxFileReader thxFileReader;
    private readonly ThmFileWriter thmFileWriter;
    private readonly AirwayBlockageParameterConverter airwayBlockageParameterConverter;
    private readonly VocalSoundParameterConverter vocalSoundParameterConverter;

    public ThxToThmConverter(
        ThxFileReader thxFileReader,
        ThmFileWriter thmFileWriter)
    {
        this.thxFileReader = thxFileReader;
        this.thmFileWriter = thmFileWriter;
        airwayBlockageParameterConverter = new AirwayBlockageParameterConverter();
        vocalSoundParameterConverter = new VocalSoundParameterConverter();
    }

    public void ConvertAndWrite(
        string thxFilePath,
        string thmFilePath)
    {
        var theme = Convert(thxFilePath);
        thmFileWriter.Write(thmFilePath, theme);
    }

    public Theme Convert(
        string thxFilePath)
    {
        var thxFile = thxFileReader.Read(thxFilePath);
        return Convert(thxFile);
    }

    public Stream ConvertAndWrite(
        Stream inputStream,
        string name)
    {
        var theme = Convert(inputStream, name);
        return thmFileWriter.Write(theme);
    }

    public Theme Convert(
        Stream inputStream,
        string name)
    {
        var thxFile = thxFileReader.Read(inputStream, name);
        return Convert(thxFile);
    }

    public Theme Convert(
        ThxFile thxFile)
    {
        var (events, states) = ConvertPhases(thxFile.Scenario.EventViews);
        return new Theme
        {
            Name = thxFile.Name,
            Events = events,
            WaitingStates = states,
            Favorites = new() { Name = "Favorite name" },
            SimulatorType = (int)thxFile.ScenarioInfo.TargetedManikin,
            Sounds = new Sounds()
        };
    }

    private (List<EventGroup> eventGroups, List<State> states) ConvertPhases(
        EventViews eventViews)
    {
        var eventGroups = new List<EventGroup>();
        var states = new List<State>();
        foreach (var phase in eventViews.Views)
        {
            eventGroups.AddRange(ExtractEventGroups(phase.Categories));
            states.AddRange(ExtractStates(phase.Frames));
        }

        return (eventGroups, states);
    }

    private List<State> ExtractStates(
        List<ExecutionElement> frames)
    {
        var states = new List<State>();
        foreach (var frame in frames)
        {
            if(frame.EntryResponse == null)
                continue;
            var parameters = new List<Parameter>();
            if (frame.EntryResponse.Trend != null)
            {
                parameters.Add(new Parameter("TransitionTime", frame.EntryResponse.Trend.Duration_Seconds.ToString()));
            }

            if (frame.EntryResponse.Responses.SetAllOtherParamsToDefault)
            {
                parameters.Add(new Parameter("ALL_NORMAL", "true"));
            }
            if (frame.EntryResponse.Responses.SingleValueResponses != null)
            {
                foreach (var response in frame.EntryResponse.Responses.SingleValueResponses)
                {
                    if (!ParameterConverterCollection.Converters.TryGetValue(response.Id, out var parameterConverter))
                        continue;
                    if(parameterConverter == null)
                        continue;
                    if(!parameterConverter.CanConvert(response))
                        continue;
                    Parameter parameter;
                    if(response.SetType != "SET_ABSOLUTE")
                    {
                        if (!TryApplyRelativeParameterChange(response, parameterConverter, states, out parameter)) 
                            continue;
                    }
                    else
                    {
                        parameter = parameterConverter.Convert(response);
                    }
                    parameters.Add(parameter);
                    if (parameterConverter is PulseParameterConverter && parameters.Exists(x => x.Name == "OverridePulse"))
                        parameters.Add(new("OverridePulse", "true"));

                }
                if(airwayBlockageParameterConverter.TryConvert(frame.EntryResponse.Responses.SingleValueResponses, out var airwayBlockageParameter))
                    parameters.Add(airwayBlockageParameter);
            }

            if (frame.EntryResponse.Responses.VocalSoundResponses != null)
            {
                foreach (var vocalSoundResponse in frame.EntryResponse.Responses.VocalSoundResponses)
                {
                    if (!vocalSoundParameterConverter.TryConvert(vocalSoundResponse, out var vocalSoundParameter)) 
                        continue;
                    parameters.Add(vocalSoundParameter);
                    if(vocalSoundResponse.Repeat == -1) // Loop
                        parameters.Add(vocalSoundParameterConverter.LoopParameter(true));
                    break; // SimPad seems to only supports one sound per theme state
                }
            }
            var state = new State(frame.DisplayName)
            {
                Parameters = parameters.DistinctBy(x => x.Name).ToList()
            };
            states.Add(state);
        }

        return states;
    }

    private bool TryApplyRelativeParameterChange(
        SingleValueResponse response,
        IParameterConverter parameterConverter,
        List<State> states,
        [NotNullWhen(true)] out Parameter? parameter)
    {
        parameter = null;
        var previousStateParameterValue = states.SelectMany(state => state.Parameters)
            .LastOrDefault(x => x.Name == parameterConverter.SimPadParameterName)
            ?.Value;
        if(previousStateParameterValue == null)
            return false;
        if(!double.TryParse(previousStateParameterValue, CultureInfo.InvariantCulture, out var previousNumericValue))
            return false;
        if(!double.TryParse(response.NewValue, CultureInfo.InvariantCulture, out var numericValue))
            return false;
        double absoluteValue;
        switch (response.SetType)
        {
            case "SET_ADD":
                absoluteValue = previousNumericValue + numericValue;
                break;
            case "SET_SUB":
                absoluteValue = previousNumericValue - numericValue;
                break;
            case "SET_MUL":
                absoluteValue = previousNumericValue * numericValue;
                break;
            case "SET_DIV":
                absoluteValue = numericValue != 0 ? previousNumericValue / numericValue : previousNumericValue;
                break;
            default:
                Console.WriteLine($"Unsupported set type '{response.SetType}'");
                return false;
        }

        parameter = parameterConverter.Convert(
            new()
            {
                Id = response.Id,
                NewValue = absoluteValue.ToString("F2"),
                SetType = "SET_ABSOLUTE",
                Delay_Seconds = response.Delay_Seconds,
                SetBackAfter_Seconds = response.SetBackAfter_Seconds,
                SetBackDurationCurveType = response.SetBackDurationCurveType,
                SetBackDuration_Seconds = response.SetBackDuration_Seconds,
                SetDurationCurveType = response.SetDurationCurveType,
                SetDuration_Seconds = response.SetDuration_Seconds
            });
        return true;
    }

    private IEnumerable<EventGroup> ExtractEventGroups(
        List<Category> categories)
    {
        foreach (var category in categories)
        {
            var eventGroup = new EventGroup(category.DisplayName, Icon.None)
            {
                Events = category.ViewItemGroups?
                    .Where(viewItemGroup => viewItemGroup.ViewItems != null)
                    .SelectMany(viewItemGroup => viewItemGroup.ViewItems!)
                    .Where(viewItems => viewItems.Events != null)
                    .SelectMany(viewItems => viewItems.Events!)
                    .Select(ConvertEvent)
                    .ToList() ?? []
            };
            if (eventGroup.Events.Count == 0) 
                continue;
            yield return eventGroup;
        }
    }

    private Event ConvertEvent(
        Models.SimDesigner.Event simDesignerEvent)
    {
        var name = simDesignerEvent.Id;
        if (name.StartsWith("Laerdal.Event."))
            name = name.Substring("Laerdal.Event.".Length);
        else if (name.StartsWith("Custom.Event."))
            name = name.Substring("Custom.Event.".Length);
        var simPadEvent = new Event(name);
        return simPadEvent;
    }
}