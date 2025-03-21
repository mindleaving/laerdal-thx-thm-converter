using LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;
using LaerdalSimDesignerThemeToSimPadConverter.Models.SimPad;

namespace LaerdalSimDesignerThemeToSimPadConverter.Converters;

public class HeadLimpParameterConverter : ParameterConverter
{
    public HeadLimpParameterConverter(
        string parameterName)
        : base(parameterName)
    {
    }

    public override bool CanConvert(
        SingleValueResponse response)
    {
        return response.NewValue.ToLower() is "true";
    }

    public override Parameter Convert(
        SingleValueResponse response)
    {
        return new(SimPadParameterName, "1");
    }
}