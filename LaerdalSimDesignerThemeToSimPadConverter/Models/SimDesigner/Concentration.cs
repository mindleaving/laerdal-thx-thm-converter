using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

public class Concentration
{
    [XmlAttribute]
    public double ConcentrationValue { get; set; }
    [XmlAttribute]
    public string DividendUnit { get; set; }
    [XmlAttribute]
    public string DivisorUnit { get; set; }
}