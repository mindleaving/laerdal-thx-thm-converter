using System.Xml.Serialization;

namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

[XmlType(Namespace = "")]
public class InstructorProperties
{
    public bool ShowOnceInView { get; set; }
}