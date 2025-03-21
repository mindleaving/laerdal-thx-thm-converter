using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimPad;

[XmlType("Group")]
public class EventGroup
{
    public EventGroup() { }
    public EventGroup(
        string name,
        Icon icon)
    {
        Name = name;
        Icon = (int)icon;
    }

    [XmlAttribute("name")]
    public string Name { get; set; }
    [XmlAttribute("icon")]
    public int Icon { get; set; }
    [XmlElement("Event")]
    public List<Event> Events { get; set; }
}