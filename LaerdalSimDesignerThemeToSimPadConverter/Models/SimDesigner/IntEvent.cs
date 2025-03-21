using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

public class IntEvent : Event
{
    [XmlAttribute]
    public bool AllowReportWithoutValue { get; set; }
    [XmlAttribute]
    public int MaxValue { get; set; }
    [XmlAttribute]
    public int MinValue { get; set; }
    [XmlAttribute]
    public int StepSize { get; set; }
}