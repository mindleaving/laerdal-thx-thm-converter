using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

[XmlType(Namespace = "")]
public class EventViews
{
    [XmlElement("EventView", Namespace = "")]
    public List<EventView> Views { get; set; }
}