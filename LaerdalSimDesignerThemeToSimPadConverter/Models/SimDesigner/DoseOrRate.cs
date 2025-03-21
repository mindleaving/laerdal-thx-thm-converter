using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

public class DoseOrRate
{
    [XmlAttribute]
    public double DefaultValue { get; set; }
    [XmlAttribute]
    public double MinValue { get; set; }
    [XmlAttribute]
    public double MaxValue { get; set; }
    [XmlAttribute]
    public double ConversionFactorToISO { get; set; }
    [XmlAttribute]
    public bool IsRelativePatientWeight { get; set; }
    [XmlAttribute]
    public int DisplayDecimals { get; set; }
    [XmlElement("AllowAdjusting")]
    public List<string> AllowAdjusting { get; set; }
}