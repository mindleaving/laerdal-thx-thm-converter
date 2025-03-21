using LaerdalSimDesignerThemeToSimPadConverter.Models.SimDesigner;
using LaerdalSimDesignerThemeToSimPadConverter.Models.SimPad;

namespace LaerdalSimDesignerThemeToSimPadConverter.Test;

public class ThxFileReaderTest
{
    [Test]
    public void DeserializedThxFileContainsAllInformation()
    {
        var sut = new ThxFileReader();
        var testFilePath = Path.Combine("Data", "test-theme.thx");
        var thxFile = sut.Read(testFilePath);

        Assert.That(thxFile, Is.Not.Null);

        // Scenario
        Assert.That(thxFile.Scenario, Is.Not.Null);
        Assert.That(thxFile.Scenario.MonitorLayout, Is.EqualTo("Ward Monitor"));
        Assert.That(thxFile.Scenario.EventViews, Is.Not.Null);
        Assert.That(thxFile.Scenario.EventViews.Views.Count, Is.EqualTo(1));
        var phase1 = thxFile.Scenario.EventViews.Views[0]; 
        Assert.That(phase1.Categories.Count, Is.EqualTo(3));
        Assert.That(phase1.Categories[0].DisplayName, Is.EqualTo("Team dynamics"));
        Assert.That(phase1.Categories[0].ViewItemGroups!.Count, Is.EqualTo(2));
        Assert.That(phase1.Categories[0].ViewItemGroups![0].DisplayName, Is.EqualTo("Correct treatment"));
        Assert.That(phase1.Categories[0].ViewItemGroups![0].ViewItems!.Count, Is.EqualTo(1));
        Assert.That(phase1.Categories[0].ViewItemGroups![0].ViewItems![0].Events!.Count, Is.EqualTo(1));
        Assert.That(phase1.Categories[0].ViewItemGroups![1].DisplayName, Is.EqualTo("Related events"));
        Assert.That(phase1.Categories[0].ViewItemGroups![1].ViewItems!.Count, Is.EqualTo(3));
        Assert.That(phase1.Categories[0].ViewItemGroups![1].ViewItems![0].Events!.Count, Is.EqualTo(1));
        Assert.That(phase1.Categories[0].ViewItemGroups![1].ViewItems![1].Events!.Count, Is.EqualTo(1));
        Assert.That(phase1.Categories[0].ViewItemGroups![1].ViewItems![2].Events!.Count, Is.EqualTo(1));
        Assert.That(phase1.Categories[1].DisplayName, Is.EqualTo("Airway"));
        Assert.That(phase1.Categories[1].ViewItemGroups!.Count, Is.EqualTo(1));
        Assert.That(phase1.Categories[1].ViewItemGroups![0].ViewItems!.Count, Is.EqualTo(3));
        Assert.That(phase1.Categories[1].ViewItemGroups![0].ViewItems![0].Events!.Count, Is.EqualTo(1));
        Assert.That(phase1.Categories[1].ViewItemGroups![0].ViewItems![1].Events!.Count, Is.EqualTo(1));
        Assert.That(phase1.Categories[1].ViewItemGroups![0].ViewItems![2].Events!.Count, Is.EqualTo(1));
        Assert.That(phase1.Categories[2].DisplayName, Is.EqualTo("Circulation"));
        Assert.That(phase1.Categories[2].ViewItemGroups!.Count, Is.EqualTo(1));
        Assert.That(phase1.Categories[2].ViewItemGroups![0].ViewItems!.Count, Is.EqualTo(2));
        Assert.That(phase1.Categories[2].ViewItemGroups![0].ViewItems![0].Events!.Count, Is.EqualTo(1));
        Assert.That(phase1.Categories[2].ViewItemGroups![0].ViewItems![0].Events![0], Is.TypeOf<DrugEvent>());
        Assert.That(((DrugEvent)phase1.Categories[2].ViewItemGroups![0].ViewItems![0].Events![0]).DrugAdmin.Count, Is.EqualTo(7));
        Assert.That(phase1.Categories[2].ViewItemGroups![0].ViewItems![1].Events!.Count, Is.EqualTo(1));
        Assert.That(phase1.Categories[2].ViewItemGroups![0].ViewItems![1].Events![0], Is.TypeOf<BoolEvent>());
        Assert.That(phase1.Frames.Count, Is.EqualTo(4));
        Assert.That(phase1.Frames[0].EntryResponse!.Responses.SingleValueResponses!.Count, Is.EqualTo(18));
        Assert.That(phase1.Frames[1].EntryResponse!.Responses.SingleValueResponses!.Count, Is.EqualTo(41));
        Assert.That(phase1.Frames[1].EntryResponse!.Responses.VocalSoundResponses!.Count, Is.EqualTo(3));
        Assert.That(phase1.Frames[1].EntryResponse!.Responses.TrendResponse, Is.Not.Null);
        Assert.That(phase1.Frames[1].EntryResponse!.Responses.TrendResponse!.StopAllOther, Is.True);
        Assert.That(phase1.Frames[2].EntryResponse!.Trend, Is.Not.Null);
        Assert.That(phase1.Frames[2].EntryResponse!.Trend!.Duration_Seconds, Is.EqualTo(7));
        Assert.That(phase1.Frames[2].EntryResponse!.Responses.SingleValueResponses!.Count, Is.EqualTo(18));
        Assert.That(phase1.Frames[3].EntryResponse!.Trend, Is.Not.Null);
        Assert.That(phase1.Frames[3].EntryResponse!.Trend!.CurveType, Is.EqualTo("LINEAR"));
        Assert.That(phase1.Frames[3].EntryResponse!.Trend!.Duration_Seconds, Is.EqualTo(60));
        Assert.That(phase1.Frames[3].EntryResponse!.Responses.SingleValueResponses!.Count, Is.EqualTo(4));
        Assert.That(phase1.Frames[3].EntryResponse!.Responses.TrendResponse, Is.Not.Null);
        Assert.That(phase1.Frames[3].EntryResponse!.Responses.TrendResponse!.StopAllOther, Is.True);
        Assert.That(thxFile.Scenario.DesignerLayout, Is.Not.Null);
        Assert.That(thxFile.Scenario.DesignerLayout.ElementLayouts.Count, Is.EqualTo(4));

        // Scenario info
        Assert.That(thxFile.ScenarioInfo, Is.Not.Null);
        Assert.That(thxFile.ScenarioInfo.TargetedManikin, Is.EqualTo(SimulatorType.SimBaby2));
        Assert.That(thxFile.ScenarioInfo.AllowedManikins.Manikins, Is.EquivalentTo(new[] { SimulatorType.SimJunior, SimulatorType.SimNewB2 }));
        Assert.That(thxFile.ScenarioInfo.SupportedDevices.Devices, Is.EquivalentTo(new[] { SimulatorControlDeviceType.PC, SimulatorControlDeviceType.SimPad }));
        Assert.That(thxFile.ScenarioInfo.LaerdalEquipment.LaerdalEquipments, Is.EquivalentTo(new[] { LaerdalEquipment.PatientMonitor }));
    }
}