using LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;
using LaerdalSimDesignerThemeToSimPadConverter.Models.SimPad;

namespace LaerdalSimDesignerThemeToSimPadConverter.Converters;

public class BooleanParameterConverter : ParameterConverter
{
    public BooleanParameterConverter(
        string parameterName)
        : base(parameterName)
    {
    }

    public override bool CanConvert(
        SingleValueResponse response)
    {
        return response.NewValue.ToLower() is "true" or "false";
    }

    public override Parameter Convert(
        SingleValueResponse response)
    {
        return new(SimPadParameterName, response.NewValue.ToLower());
    }
}