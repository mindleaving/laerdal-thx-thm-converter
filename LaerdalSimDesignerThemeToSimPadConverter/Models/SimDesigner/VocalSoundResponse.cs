using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

[XmlType(Namespace = "")]
public class VocalSoundResponse
{
    [XmlAttribute]
    public int Delay_Seconds { get; set; }
    [XmlAttribute]
    public string FileName { get; set; }
    [XmlAttribute]
    public int Repeat { get; set; }
    [XmlAttribute]
    public int Interval_Seconds { get; set; }
    [XmlAttribute]
    public int Volume_Percent { get; set; }
    [XmlAttribute]
    public bool Queue { get; set; }
}