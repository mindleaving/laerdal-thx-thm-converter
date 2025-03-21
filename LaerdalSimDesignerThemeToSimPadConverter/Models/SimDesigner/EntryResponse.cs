using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

[XmlType(Namespace = "")]
public class EntryResponse
{
    public Trend? Trend { get; set; }
    public Responses Responses { get; set; }
}