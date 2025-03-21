using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

[XmlType(Namespace = "")]
public class TrendResponse
{
    [XmlAttribute]
    public bool StopAllOther { get; set; }
}