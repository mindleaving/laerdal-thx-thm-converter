using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

[XmlType(Namespace = "")]
public class Trend
{
    [XmlAttribute]
    public string CurveType { get; set; }
    [XmlAttribute]
    public int Duration_Seconds { get; set; }
}