using LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;
using LaerdalSimDesignerThemeToSimPadConverter.Models.SimPad;

namespace LaerdalSimDesignerThemeToSimPadConverter.Converters;

public class TongueEdemaParameterConverter : ParameterConverter
{
    public TongueEdemaParameterConverter(
        string parameterName)
        : base(parameterName)
    {
    }

    public override bool CanConvert(
        SingleValueResponse response)
    {
        return int.TryParse(response.NewValue, out _);
    }

    // SimPad enums:
    // 0: No edema
    // 1: Medium edema
    // 2: Max edema
    public override Parameter Convert(
        SingleValueResponse response)
    {
        var edemaSeverity = int.Parse(response.NewValue);
        return new Parameter(SimPadParameterName, edemaSeverity > 75 ? "2" : edemaSeverity > 0 ? "1" : "0");
    }
}