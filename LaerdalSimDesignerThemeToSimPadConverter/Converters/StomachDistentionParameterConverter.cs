using LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;
using LaerdalSimDesignerThemeToSimPadConverter.Models.SimPad;

namespace LaerdalSimDesignerThemeToSimPadConverter.Converters;

public class StomachDistentionParameterConverter : ParameterConverter
{
    public StomachDistentionParameterConverter(
        string parameterName)
        : base(parameterName)
    {
    }

    public override bool CanConvert(
        SingleValueResponse response)
    {
        return response.Id is "Laerdal.Response.Airway.StomachDistention.Enabled" 
            or "Laerdal.Response.Airway.StomachDistention.Inflate"
            or "Laerdal.Response.Airway.StomachDistention.ReleaseAir";
    }

    public override Parameter Convert(
        SingleValueResponse response)
    {
        if (response.Id == "Laerdal.Response.Airway.StomachDistention.Inflate")
            return new(SimPadParameterName, "2");
        if (response.Id == "Laerdal.Response.Airway.StomachDistention.ReleaseAir")
            return new(SimPadParameterName, "0");
        return new(SimPadParameterName, "1");
    }
}