using LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;
using LaerdalSimDesignerThemeToSimPadConverter.Models.SimPad;

namespace LaerdalSimDesignerThemeToSimPadConverter.Converters;

public class ExtrasystoleFrequencyParameterConverter : ParameterConverter
{
    public ExtrasystoleFrequencyParameterConverter(
        string parameterName)
        : base(parameterName)
    {
    }

    public override bool CanConvert(
        SingleValueResponse response)
    {
        return int.TryParse(response.NewValue, out _);
    }

    public override Parameter Convert(
        SingleValueResponse response)
    {
        var extrasystoleFrequency = int.Parse(response.NewValue);
        if (extrasystoleFrequency == 100)
            return new(SimPadParameterName, "4"); // Bigeminy
        if(extrasystoleFrequency > 50)
            return new(SimPadParameterName, "3"); // Frequent
        if (extrasystoleFrequency > 15)
            return new(SimPadParameterName, "2"); // Medium
        if (extrasystoleFrequency > 0)
            return new(SimPadParameterName, "1"); // Low
        return new(SimPadParameterName, "0"); // Manual
    }
}