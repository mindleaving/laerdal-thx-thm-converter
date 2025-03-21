using System.IO.Compression;
using System.Text;
using System.Xml.Serialization;
using LaerdalSimDesignerThemeToSimPadConverter.Models.SimPad;

namespace LaerdalSimDesignerThemeToSimPadConverter;

public class ThmFileWriter
{
    private readonly XmlSerializer xmlSerializer;

    public ThmFileWriter()
    {
        xmlSerializer = new XmlSerializer(typeof(Theme));
    }

    public void Write(
        string outputFilePath,
        Theme theme)
    {
        var xmlNamespaces = new XmlSerializerNamespaces();
        xmlNamespaces.Add("", "");

        if(File.Exists(outputFilePath))
            File.Delete(outputFilePath);
        using var fileStream = File.OpenWrite(outputFilePath);
        using var zipArchive = new ZipArchive(fileStream, ZipArchiveMode.Create);
        var themeEntry = zipArchive.CreateEntry("theme.xml");
        using var themeEntryStream = themeEntry.Open();
        using var streamWriter = new StreamWriter(themeEntryStream, new UTF8Encoding(true));
        xmlSerializer.Serialize(streamWriter, theme, xmlNamespaces);
    }
}