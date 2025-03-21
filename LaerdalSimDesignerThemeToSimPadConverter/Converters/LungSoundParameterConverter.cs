namespace LaerdalSimDesignerThemeToSimPadConverter.Converters;

public class LungSoundParameterConverter : EnumParameterConverter
{
    public LungSoundParameterConverter(
        string parameterName)
        : base(parameterName, new()
        {
            { "NORMAL", "Normal" },
            { "COARSE_CRACKLES", "Coarse crackles" },
            { "FINE_CRACKLES", "Fine crackles" },
            { "PNEUMONIA", "Pneumonia" },
            { "RHONCHI", "Rhonchi" },
            { "STRIDOR", "Stridor" },
            { "WHEEZES", "Wheezes" },
            { "PLEURAL_RUB", "Pleural Rub" },
            //{ "NO_SOUND", ""},
        })
    {
    }
}