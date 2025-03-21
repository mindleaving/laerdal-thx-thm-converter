using System.Xml.Serialization;
using LaerdalSimDesignerThemeToSimPadConverter.Models.SimPad;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

[XmlRoot(Namespace = "http://www.laerdal.com/Scenario")]
public class ScenarioInfo
{
    [XmlAttribute]
    public string Version { get; set; }
    [XmlAttribute]
    public string EditorVersion { get; set; }
    [XmlAttribute]
    public string MinimumExecuterVersion { get; set; }
    [XmlAttribute]
    public bool HasPatientDescription { get; set; }

    public ScenarioType ScenarioType { get; set; }
    public string ShortDescription { get; set; }
    public LaerdalEquipmentNeeded LaerdalEquipment { get; set; }
    public string DefaultLanguage { get; set; }
    public SimulatorType TargetedManikin { get; set; }
    public AllowedManikins AllowedManikins { get; set; }
    public SupportedDevices SupportedDevices { get; set; }
    public List<SingleValueResponse> VitalSigns { get; set; }
}