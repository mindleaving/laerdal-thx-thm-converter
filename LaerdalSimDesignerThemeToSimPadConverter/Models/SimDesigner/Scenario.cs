using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

[XmlRoot("ScenarioFile", Namespace = "http://www.laerdal.com/Scenario")]
public class Scenario
{
    [XmlAttribute]
    public string Version { get; set; }
    [XmlAttribute]
    public string MonitorLayout { get; set; }
    [XmlAttribute]
    public bool AutoPerfusionHandling { get; set; }
    [XmlAttribute]
    public bool UsingStrictLegacyConversion { get; set; }
    [XmlAttribute]
    public bool AutoAirwayHandling { get; set; }
    [XmlAttribute]
    public bool UseNewPulseLogic { get; set; }
    [XmlElement(Namespace = "")]
    public int StartExecutionElementStorageId { get; set; }
    [XmlElement(Namespace = "")]
    public EventViews EventViews { get; set; }
    [XmlElement(Namespace = "")]
    public List<UserDefinedVariable> UserDefinedVariables { get; set; }
    [XmlElement(Namespace = "")]
    public DesignerLayout DesignerLayout { get; set; }
}