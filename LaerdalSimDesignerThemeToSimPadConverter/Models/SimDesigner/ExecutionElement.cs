using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

[XmlType(Namespace = "")]
public class ExecutionElement
{
    [XmlAttribute(Namespace = "http://www.laerdal.com/Scenario")]
    public int StorageId { get; set; }
    [XmlAttribute]
    public bool VisibleInOnTheFly { get; set; }
    [XmlAttribute]
    public bool RemovePendingDelays { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public EntryResponse? EntryResponse { get; set; }
}