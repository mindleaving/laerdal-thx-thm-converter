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
        if(File.Exists(outputFilePath))
            File.Delete(outputFilePath);
        using var fileStream = File.OpenWrite(outputFilePath);
        using var memoryStream = Write(theme);
        memoryStream.CopyTo(fileStream);
    }

    public MemoryStream Write(
        Theme theme)
    {
        var xmlNamespaces = new XmlSerializerNamespaces();
        xmlNamespaces.Add("", "");

        var memoryStream = new MemoryStream();
        using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, leaveOpen: true))
        {
            var themeEntry = zipArchive.CreateEntry("theme.xml");
            using(var themeEntryStream = themeEntry.Open())
            using(var streamWriter = new StreamWriter(themeEntryStream, new UTF8Encoding(true)))
            {
                xmlSerializer.Serialize(streamWriter, theme, xmlNamespaces);
            }
        }
        memoryStream.Seek(0, SeekOrigin.Begin);
        return memoryStream;
    }
}