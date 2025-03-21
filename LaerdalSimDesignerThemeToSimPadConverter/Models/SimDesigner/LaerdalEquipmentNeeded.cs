using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

[XmlType(Namespace = "http://www.laerdal.com/Scenario")]
public class LaerdalEquipmentNeeded
{
    [XmlElement("LaerdalEquipmentNeeded")]
    public List<LaerdalEquipment> LaerdalEquipments { get; set; }
}