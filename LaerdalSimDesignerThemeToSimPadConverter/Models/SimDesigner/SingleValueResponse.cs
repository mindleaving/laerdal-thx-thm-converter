using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

[XmlType(Namespace = "")]
public class SingleValueResponse
{
    [XmlAttribute]
    public int Delay_Seconds { get; set; }
    [XmlAttribute(Namespace = "http://www.laerdal.com/Scenario")]
    public string Id { get; set; }
    [XmlAttribute]
    public string NewValue { get; set; }
    [XmlAttribute]
    public string SetType { get; set; }
    [XmlAttribute]
    public int SetDuration_Seconds { get; set; }
    [XmlAttribute]
    public string SetDurationCurveType { get; set; }
    [XmlAttribute]
    public int SetBackAfter_Seconds { get; set; }
    [XmlAttribute]
    public int SetBackDuration_Seconds { get; set; }
    [XmlAttribute]
    public string SetBackDurationCurveType { get; set; }

    public override string ToString()
    {
        return $"{Id}: {NewValue} ({SetType})";
    }
}