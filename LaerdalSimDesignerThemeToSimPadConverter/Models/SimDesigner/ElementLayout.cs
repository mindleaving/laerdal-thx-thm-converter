using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

[XmlType(Namespace = "")]
public class ElementLayout
{
    [XmlAttribute(Namespace = "http://www.laerdal.com/Scenario")]
    public int StorageId { get; set; }
    [XmlAttribute]
    public string Tag { get; set; }
    [XmlAttribute]
    public int IndexRelativeStorageId { get; set; }
    public SizeLocation SizeLocation { get; set; }
}