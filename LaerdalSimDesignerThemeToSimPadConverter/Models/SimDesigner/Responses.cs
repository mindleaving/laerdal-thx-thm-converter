using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

[XmlType(Namespace = "")]
public class Responses
{
    [XmlAttribute]
    public bool SetAllOtherParamsToDefault { get; set; }
    public List<SingleValueResponse>? SingleValueResponses { get; set; }
    public TrendResponse? TrendResponse { get; set; }
    public List<VocalSoundResponse>? VocalSoundResponses { get; set; }
}