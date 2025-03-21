using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

[XmlType(Namespace = "")]
public class SingleValueResponses
{
    [XmlElement("SingleValueResponse")]
    public List<SingleValueResponse> Values { get; set; }
}