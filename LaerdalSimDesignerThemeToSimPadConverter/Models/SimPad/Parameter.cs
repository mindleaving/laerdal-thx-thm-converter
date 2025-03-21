using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimPad;

public class Parameter
{
    public Parameter() { }
    public Parameter(
        string name,
        string value)
    {
        Name = name;
        Value = value;
    }

    [XmlElement("name")]
    public string Name { get; set; }
    [XmlElement("value")]
    public string Value { get; set; }
}