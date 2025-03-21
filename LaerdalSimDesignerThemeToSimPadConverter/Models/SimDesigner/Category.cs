using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

[XmlType(Namespace = "")]
public class Category
{
    [XmlAttribute]
    public string IconId { get; set; }
    public string DisplayName { get; set; }
    [XmlElement("ViewItems", Namespace = "")]
    public List<ViewItemGroup>? ViewItemGroups { get; set; }
}