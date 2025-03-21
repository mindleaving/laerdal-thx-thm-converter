using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

public class UnsetEvent
{
    [XmlAttribute(Namespace = "http://www.laerdal.com/Scenario")]
    public string Id { get; set; }
    [XmlAttribute]
    public bool ShowMainEvent { get; set; }
    [XmlAttribute]
    public bool Toggle { get; set; }
}