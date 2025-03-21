using System.Globalization;
using LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;
using LaerdalSimDesignerThemeToSimPadConverter.Models.SimPad;

namespace LaerdalSimDesignerThemeToSimPadConverter.Converters;

public class NumericParameterConverter : ParameterConverter
{
    private readonly double scaling;

    public NumericParameterConverter(
        string parameterName,
        double scaling = 1.0)
        : base(parameterName)
    {
        this.scaling = scaling;
    }


    public override bool CanConvert(
        SingleValueResponse response)
    {
        return double.TryParse(response.NewValue, CultureInfo.InvariantCulture, out _);
    }

    public override Parameter Convert(
        SingleValueResponse response)
    {
        var value = double.Parse(response.NewValue, CultureInfo.InvariantCulture) * scaling;
        return new(SimPadParameterName, value.ToString("F0"));
    }
}