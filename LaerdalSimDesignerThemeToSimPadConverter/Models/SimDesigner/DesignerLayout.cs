using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

[XmlType(Namespace = "")]
public class DesignerLayout
{
    [XmlAttribute]
    public string Version { get; set; }
    [XmlElement("ElementLayout")]
    public List<ElementLayout> ElementLayouts { get; set; }
}