using LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;
using LaerdalSimDesignerThemeToSimPadConverter.Models.SimPad;

namespace LaerdalSimDesignerThemeToSimPadConverter.Converters;

public class EnumParameterConverter : ParameterConverter
{
    private readonly Dictionary<string, string> enumMap;

    public EnumParameterConverter(
        string parameterName,
        Dictionary<string, string> enumMap)
        : base(parameterName)
    {
        this.enumMap = enumMap;
    }

    public override bool CanConvert(
        SingleValueResponse response)
    {
        return enumMap.ContainsKey(response.Id);
    }

    public override Parameter Convert(
        SingleValueResponse response)
    {
        return new Parameter(SimPadParameterName, enumMap[response.Id]);
    }
}