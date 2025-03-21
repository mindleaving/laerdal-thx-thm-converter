using System.Diagnostics.CodeAnalysis;
using LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;
using LaerdalSimDesignerThemeToSimPadConverter.Models.SimPad;

namespace LaerdalSimDesignerThemeToSimPadConverter.Converters;

public class AirwayBlockageParameterConverter
{
    public string ParameterName => "AirwayBlockage";

    // SimPad enums:
    // 0: No blockage
    // 1: Left side blockage
    // 2: Right side blockage
    // 3: Both side blockage
    // 4: Right partial
    // 5: Left blocked, right partial
    // 6: Tongue fallback
    // 8: Left partial
    // 10: Left partial, right blocked
    // 12: Both partial
    public bool TryConvert(
        List<SingleValueResponse> singleValueResponses,
        [NotNullWhen(true)] out Parameter? airwayBlockageParameter)
    {
        var tongueFallbackResponse = singleValueResponses.Find(x => x.Id == "Laerdal.Response.Airway.TongueFallback");
        if (tongueFallbackResponse != null && tongueFallbackResponse.NewValue.ToLower() == "true")
        {
            airwayBlockageParameter = new(ParameterName, "6");
            return true;
        }

        var airflowBlockedResponse = singleValueResponses.Find(x => x.Id == "Laerdal.Response.Airway.AirFlowBlocked");
        if(airflowBlockedResponse != null && airflowBlockedResponse.NewValue.ToLower() == "true")
        {
            airwayBlockageParameter = new(ParameterName, "3"); // Both side blockage
            return true;
        }

        var leftAirwayResistance = singleValueResponses.Find(x => x.Id == "Laerdal.Response.Airway.LungResistanceLeft_Percent");
        var leftAirwayResistanceValue = leftAirwayResistance != null ? int.Parse(leftAirwayResistance.NewValue) : 0;
        var rightAirwayResistance = singleValueResponses.Find(x => x.Id == "Laerdal.Response.Airway.LungResistanceRight_Percent");
        var rightAirwayResistanceValue = rightAirwayResistance != null ? int.Parse(rightAirwayResistance.NewValue) : 0;

        var leftBlockageState = GetAirwayBlockageState(leftAirwayResistanceValue);
        var rightBlockageState = GetAirwayBlockageState(rightAirwayResistanceValue);
        int overallState;
        switch (leftBlockageState)
        {
            case AirwayBlockageState.Open:
                switch (rightBlockageState)
                {
                    case AirwayBlockageState.Open:
                        overallState = 0;
                        break;
                    case AirwayBlockageState.Partial:
                        overallState = 4;
                        break;
                    case AirwayBlockageState.Blocked:
                        overallState = 2;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                break;
            case AirwayBlockageState.Partial:
                switch (rightBlockageState)
                {
                    case AirwayBlockageState.Open:
                        overallState = 8;
                        break;
                    case AirwayBlockageState.Partial:
                        overallState = 12;
                        break;
                    case AirwayBlockageState.Blocked:
                        overallState = 10;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                break;
            case AirwayBlockageState.Blocked:
                switch (rightBlockageState)
                {
                    case AirwayBlockageState.Open:
                        overallState = 1;
                        break;
                    case AirwayBlockageState.Partial:
                        overallState = 5;
                        break;
                    case AirwayBlockageState.Blocked:
                        overallState = 3;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        airwayBlockageParameter = new(ParameterName, overallState.ToString());
        return true;
    }

    private static AirwayBlockageState GetAirwayBlockageState(
        int leftAirwayResistanceValue)
    {
        return leftAirwayResistanceValue == 0 ? AirwayBlockageState.Open
            : leftAirwayResistanceValue > 75 ? AirwayBlockageState.Blocked
            : AirwayBlockageState.Partial;
    }

    private enum AirwayBlockageState
    {
        Open,
        Partial,
        Blocked
    }
}