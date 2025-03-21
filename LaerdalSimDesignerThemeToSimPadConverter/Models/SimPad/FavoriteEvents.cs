using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimPad;

public class FavoriteEvents
{
    [XmlAttribute("name")]
    public string Name { get; set; }
}