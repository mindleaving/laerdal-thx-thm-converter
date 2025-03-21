using LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;
using LaerdalSimDesignerThemeToSimPadConverter.Models.SimPad;

namespace LaerdalSimDesignerThemeToSimPadConverter.Converters;

public interface IParameterConverter
{
    string SimPadParameterName { get; }

    bool CanConvert(
        SingleValueResponse response);
    Parameter Convert(
        SingleValueResponse response);
}