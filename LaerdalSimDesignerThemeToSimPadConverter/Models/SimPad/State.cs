using System.Collections;
using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimPad;

public class State
{
    public State() { }
    public State(
        string name)
    {
        Name = name;
    }

    [XmlAttribute("name")]
    public string Name { get; set; }
    [XmlElement("Parameter")]
    public List<Parameter> Parameters { get; set; }
}