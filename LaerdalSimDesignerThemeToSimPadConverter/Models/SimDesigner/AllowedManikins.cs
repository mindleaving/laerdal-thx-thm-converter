using System.Xml.Serialization;
using LaerdalSimDesignerThemeToSimPadConverter.Models.SimPad;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

[XmlType(Namespace = "http://www.laerdal.com/Scenario")]
public class AllowedManikins
{
    [XmlElement("Name")]
    public List<SimulatorType> Manikins { get; set; }
}