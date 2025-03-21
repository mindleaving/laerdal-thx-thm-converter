using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

[XmlType(Namespace = "")]
public class SizeLocation
{
    [XmlAttribute]
    public int SizeX { get; set; }
    [XmlAttribute]
    public int SizeY { get; set; }
    [XmlAttribute]
    public int TopLeftX { get; set; }
    [XmlAttribute]
    public int TopLeftY { get; set; }
}