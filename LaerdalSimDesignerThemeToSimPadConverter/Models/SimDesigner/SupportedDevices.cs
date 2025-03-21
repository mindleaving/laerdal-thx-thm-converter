using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

[XmlType(Namespace = "http://www.laerdal.com/Scenario")]
public class SupportedDevices
{
    [XmlElement("Name")]
    public List<SimulatorControlDeviceType> Devices { get; set; }
}