using System.Diagnostics.CodeAnalysis;
using LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;
using LaerdalSimDesignerThemeToSimPadConverter.Models.SimPad;

namespace LaerdalSimDesignerThemeToSimPadConverter.Converters;

public class VocalSoundParameterConverter
{
    private readonly Dictionary<string, string> vocalSoundMap = new()
    {
        { "Cough.wav", "Cough" },
        { "Weakcry.wav", "Weakcry" },
        { "Strongcry.wav", "Strongcry" },
        { "Strongcry (type 2).wav", "Strongcry" },
        { "Grunt.wav", "Grunt" },
        { "Screaming.wav", "Screaming" },
        { "Hiccup.wav", "Hiccup" },
        { "Content.wav", "Content" },
    };

    public Parameter LoopParameter(bool loop) => new("VocalSoundRepeat", loop ? "true" : "false");

    public bool TryConvert(
        VocalSoundResponse response,
        [NotNullWhen(true)] out Parameter? parameter)
    {
        if (!vocalSoundMap.TryGetValue(response.FileName, out var simPadValue))
        {
            parameter = null;
            return false;
        }
        parameter = new("VocalSound", simPadValue);
        return true;
    }
}