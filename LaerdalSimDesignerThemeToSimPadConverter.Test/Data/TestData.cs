using LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;
using LaerdalSimDesignerThemeToSimPadConverter.Models.SimPad;

namespace LaerdalSimDesignerThemeToSimPadConverter.Test.Data;

internal static class TestData
{
    public static Theme TestTheme = new()
    {
        Name = "ABCDE",
        SimulatorType = (int)SimulatorType.SimBaby,
        WaitingStates = [
            new State("ZYXWVU")
            {
                Parameters = [
                    new("HR", "127"),
                    new("ALL_NORMAL","true"),
                    new("StartState","true")
                ]
            },
            new State("State2")
            {
                Parameters = [
                    new("BPDiastolic","34"),
                    new("BPSystolic","75"),
                    new("HR","115"),
                    new("RR","44"),
                    new("SpO2","31"),
                    new("Temp","366"),
                    new("TempPeri","363"),
                    new("EtCO2","33"),
                    new("EtCO2InspirationSlope","50"),
                    new("EtCO2ExpirationSlope","50"),
                    new("TransitionTime","37"),
                    new("ChestRise","3"),
                    new("ACArtifacts","false"),
                    new("MuscularArtifacts","false"),
                    new("ExtraSystoleType","2"),
                    new("ExtraSystoleProbability","0"),
                    new("Rhythm","Hyperkalemic"),
                    new("PEA","false"),
                    new("CapillaryRefillTimePeri","4"),
                    new("CapillaryRefillTime","3")
                ]
            }
        ],
        Events = [
            new("Simulation", Icon.None)
            {
                Events = [
                    new("Thrombolic event")
                ]
            },
            new("Airway", Icon.None)
            {
                Events = [
                    new("Intubation"),
                    new("Cheek sweep")
                ]
            }
        ],
        Favorites = new() { Name = "Favorite name" },
        Sounds = new()
    };

    public static Scenario TestScenario = new()
    {
        Version = "7",
        AutoPerfusionHandling = true,
        UsingStrictLegacyConversion = false,
        AutoAirwayHandling = true,
        UseNewPulseLogic = true,
        StartExecutionElementStorageId = 1,
        EventViews = new()
        {
            Views = [
                new()
                {
                    DisplayName = "Events",
                    Frames =
                    [
                        new()
                        {
                            StorageId = 1,
                            VisibleInOnTheFly = false,
                            RemovePendingDelays = false,
                            DisplayName = "ZYXWV",
                            Description = string.Empty,
                            EntryResponse = new()
                            {
                                Responses = new()
                                {
                                    SingleValueResponses = [
                                        new()
                                        {
                                            Delay_Seconds = 0,
                                            Id = "Laerdal.Response.Ecg.BasicRhythm",
                                            NewValue = "SINUS",
                                            SetType = "SET_ABSOLUTE",
                                            SetDuration_Seconds = 0,
                                            SetDurationCurveType = "LINEAR",
                                            SetBackAfter_Seconds = 0,
                                            SetBackDuration_Seconds = 0,
                                            SetBackDurationCurveType = "LINEAR"
                                        }
                                    ]
                                }
                            }
                        },
                        new()
                        {
                            StorageId = 2,
                            VisibleInOnTheFly = false,
                            RemovePendingDelays = false,
                            DisplayName = "State2",
                            Description = "Put a short clinical description here",
                            EntryResponse = new()
                            {
                                Responses = new()
                                {
                                    SingleValueResponses = [
                                        new()
                                        {
                                            Delay_Seconds = 0,
                                            Id = "Laerdal.Response.Ecg.HeartRate_bpm",
                                            NewValue = "127",
                                            SetType = "SET_ABSOLUTE",
                                            SetDuration_Seconds = 0,
                                            SetDurationCurveType = "LINEAR",
                                            SetBackAfter_Seconds = 0,
                                            SetBackDuration_Seconds = 0,
                                            SetBackDurationCurveType = "LINEAR"
                                        }
                                    ]
                                }
                            }
                        }
                    ]
                }
            ]
        },
        UserDefinedVariables = [],
        DesignerLayout = new()
        {
            Version = "0",
            ElementLayouts =
            [
                new()
                {
                    StorageId = 1,
                    Tag = "Frame",
                    IndexRelativeStorageId = -1,
                    SizeLocation = new()
                    {
                        SizeX = 0,
                        SizeY = 0,
                        TopLeftX = 852,
                        TopLeftY = 50
                    }
                },
                new()
                {
                    StorageId = 2,
                    Tag = "Frame",
                    IndexRelativeStorageId = -1,
                    SizeLocation = new()
                    {
                        SizeX = 0,
                        SizeY = 0,
                        TopLeftX = 852,
                        TopLeftY = 244
                    }
                }
            ]
        }
    };
}