using LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;
using LaerdalSimDesignerThemeToSimPadConverter.Models.SimPad;

namespace LaerdalSimDesignerThemeToSimPadConverter.Converters;

public class LaryngospasmParameterConverter : ParameterConverter
{
    public LaryngospasmParameterConverter(
        string parameterName)
        : base(parameterName)
    {
    }

    public override bool CanConvert(
        SingleValueResponse response)
    {
        return int.TryParse(response.NewValue, out _);
    }

    public override Parameter Convert(
        SingleValueResponse response)
    {
        var laryngospasmSeverity = int.Parse(response.NewValue);
        return new(SimPadParameterName, laryngospasmSeverity >= 75 ? "2" : laryngospasmSeverity >= 50 ? "1" : "0");
    }
}