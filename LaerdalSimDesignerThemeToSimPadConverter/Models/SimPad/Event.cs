using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimPad;

public class Event
{
    public Event() { }
    public Event(
        string name)
    {
        Name = name;
    }

    [XmlElement("name")]
    public string Name { get; set; }
}