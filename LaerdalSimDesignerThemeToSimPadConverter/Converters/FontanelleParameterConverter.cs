using LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;
using LaerdalSimDesignerThemeToSimPadConverter.Models.SimPad;

namespace LaerdalSimDesignerThemeToSimPadConverter.Converters;

public class FontanelleParameterConverter : ParameterConverter
{
    public FontanelleParameterConverter(
        string parameterName)
        : base(parameterName)
    {
    }

    public override bool CanConvert(
        SingleValueResponse response)
    {
        return response.NewValue.ToLower() == "true";
    }

    public override Parameter Convert(
        SingleValueResponse response)
    {
        return new(SimPadParameterName, "1");
    }
}