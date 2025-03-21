namespace LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;

public class ThxFile
{
    public ThxFile(
        string name,
        Scenario scenario,
        ScenarioInfo scenarioInfo)
    {
        Name = name;
        Scenario = scenario;
        ScenarioInfo = scenarioInfo;
    }

    public string Name { get; }
    public Scenario Scenario { get; }
    public ScenarioInfo ScenarioInfo { get; }
}