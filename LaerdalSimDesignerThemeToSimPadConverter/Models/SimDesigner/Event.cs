using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

[XmlInclude(typeof(IntEvent))]
[XmlInclude(typeof(BoolEvent))]
[XmlInclude(typeof(DrugEvent))]
public class Event
{
    [XmlAttribute(Namespace = "http://www.laerdal.com/Scenario")]
    public string Id { get; set; }
    [XmlElement("Keyword", Namespace = "")]
    public List<string> Keywords { get; set; }
    [XmlElement(Namespace = "")]
    public InstructorProperties InstructorProperties { get; set; }
}