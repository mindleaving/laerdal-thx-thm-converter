using LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;
using LaerdalSimDesignerThemeToSimPadConverter.Models.SimPad;

namespace LaerdalSimDesignerThemeToSimPadConverter.Converters;

public abstract class ParameterConverter : IParameterConverter
{
    protected ParameterConverter(
        string parameterName)
    {
        SimPadParameterName = parameterName;
    }

    public string SimPadParameterName { get; }

    public abstract bool CanConvert(
        SingleValueResponse response);

    public abstract Parameter Convert(
        SingleValueResponse response);
}