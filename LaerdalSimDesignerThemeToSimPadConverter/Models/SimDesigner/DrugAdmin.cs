using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

public class DrugAdmin
{
    [XmlAttribute]
    public string RouteEnumId { get; set; }
    [XmlAttribute]
    public bool StopAdmin { get; set; }
    [XmlAttribute]
    public bool IncludeInView { get; set; }
    [XmlAttribute]
    public bool PreselectInView { get; set; }
    [XmlAttribute]
    public bool ShowPatientWeight { get; set; }
    [XmlAttribute]
    public string VSIITmpDisplayName { get; set; }

    public Concentration Concentration { get; set; }
    public DoseOrRate DoseOrRate { get; set; }
}