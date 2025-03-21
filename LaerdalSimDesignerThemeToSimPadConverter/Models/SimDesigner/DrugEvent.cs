using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

public class DrugEvent : Event
{
    [XmlAttribute]
    public bool ShowAsSimple { get; set; }
    [XmlElement("DrugAdmin")]
    public List<DrugAdmin> DrugAdmin { get; set; }
}