namespace LaerdalSimDesignerThemeToSimPadConverter.Converters;

public class PulseParameterConverter : EnumParameterConverter
{
    public PulseParameterConverter(
        string parameterName)
        : base(parameterName, new()
        {
            { "ABSENT", "0" }, // Absent
            { "WEAK", "1" }, // Weak
            { "NORMAL", "2" }, // Noraml
        })
    {
    }
}