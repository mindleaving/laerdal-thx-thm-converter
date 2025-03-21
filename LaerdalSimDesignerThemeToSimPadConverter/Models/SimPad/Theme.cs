using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimPad;

public class Theme
{
    [XmlAttribute("name")]
    public string Name { get; set; }
    [XmlAttribute("simulator")]
    public int SimulatorType { get; set; }
    public List<State> WaitingStates { get; set; }
    public List<EventGroup> Events { get; set; }
    public FavoriteEvents Favorites { get; set; }
    public Sounds Sounds { get; set; }
}