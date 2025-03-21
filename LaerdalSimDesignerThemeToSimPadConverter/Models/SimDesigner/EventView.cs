using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

[XmlType(Namespace = "")]
public class EventView
{
    public string DisplayName { get; set; }
    public List<ExecutionElement> Frames { get; set; }
    public List<Category> Categories { get; set; }
}