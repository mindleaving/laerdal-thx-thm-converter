using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

[XmlType(Namespace = "")]
public class ViewItem
{
    [XmlAttribute]
    public bool IncludeInView { get; set; }
    [XmlAttribute]
    public bool PreselectInView { get; set; }
    [XmlElement(nameof(Event), typeof(Event)), 
    XmlElement(nameof(IntEvent), typeof(IntEvent)),
    XmlElement(nameof(BoolEvent), typeof(BoolEvent)),
    XmlElement(nameof(DrugEvent), typeof(DrugEvent))]
    public List<Event>? Events { get; set; }
}