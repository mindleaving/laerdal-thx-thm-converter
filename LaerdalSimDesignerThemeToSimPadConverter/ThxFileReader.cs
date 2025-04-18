using System.IO.Compression;
using System.Xml.Serialization;
using LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

namespace LaerdalSimDesignerThemeToSimPadConverter;

public class ThxFileReader
{
    private const string CtgPresetsFileName = "CtgPresets.xml";
    private const string ScenarioFileName = "Scenario.xml";
    private const string ScenarioInfoFileName = "ScenarioInfo.xml";
    private const string ScenarioPatientFileName = "ScenarioPatient.xml";
    private const string SoundPresetsFileName = "SoundPresets.xml";

    public ThxFile Read(
        string thxFilePath)
    {
        using var fileStream = File.OpenRead(thxFilePath);
        var name = Path.GetFileNameWithoutExtension(thxFilePath);
        return Read(fileStream, name);
    }

    public ThxFile Read(
        Stream inputStream,
        string name = "SimPadTheme")
    {
        using var zipArchive = new ZipArchive(inputStream, ZipArchiveMode.Read);
        using var scenarioFile = zipArchive.GetEntry(ScenarioFileName)!.Open();
        var scenario = Read<Scenario>(scenarioFile);
        using var scenarioInfoFile = zipArchive.GetEntry(ScenarioInfoFileName)!.Open();
        var scenarioInfo = Read<ScenarioInfo>(scenarioInfoFile);
        // TODO: Gather other information from patient and sound preset file
        return new(name, scenario, scenarioInfo);
    }

    private T Read<T>(
        Stream stream)
    {
        var xmlSerializer = new XmlSerializer(typeof(T));
        return (T?)xmlSerializer.Deserialize(stream)!;
    }
}