using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

public class BoolEvent : Event
{
    [XmlAttribute]
    public bool AllowReportWithoutValue { get; set; }
    [XmlAttribute]
    public bool AutoSetTo { get; set; }
    public UnsetEvent UnsetEvent { get; set; }
}