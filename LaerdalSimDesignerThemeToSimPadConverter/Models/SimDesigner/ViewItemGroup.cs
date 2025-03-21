using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

[XmlType("ViewItems", Namespace = "")]
public class ViewItemGroup
{
    public string DisplayName { get; set; }
    [XmlElement("ViewItem", Namespace = "")]
    public List<ViewItem>? ViewItems { get; set; }
}