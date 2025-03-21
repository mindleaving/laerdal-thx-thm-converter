namespace LaerdalSimDesignerThemeToSimPadConverter.Converters;

public static class ParameterConverterCollection
{
    public static readonly Dictionary<string, IParameterConverter?> Converters = new()
    {
        { "Laerdal.Response.BloodPressure.Systolic_mmHg", new NumericParameterConverter("BPDiastolic") },
        { "Laerdal.Response.BloodPressure.Diastolic_mmHg", new NumericParameterConverter("BPSystolic") },
        { "Laerdal.Response.Ecg.BasicRhythm", new EnumParameterConverter("Rhythm", new()
        {
            { "SINUS", "Sinus" },
            { "SINUS_WPW", "WPW" },
            { "HYPER_KALEMIA", "Hyperkalemic" },
            { "SINUS_ISCHAEMIA", "Ischemia" },
            { "SINUS_PROLONGED_QT", "Hypokalemic" },
            { "SINUS_AMI_INFERIOR", "InfAMI" },
            { "SINUS_LBBB", "LBBB" },
            { "SINUS_RBBB", "RBBB" },
            { "WANDERING_PACEMAKER", "AtrialTach" },
            { "SVT", "SVT" },
            { "JUNCTIONAL_RHYTHM", "JuncRhythm" },
            { "A_FIB", "AtrialFib" },
            { "A_FLUTTER", "AtrialFlutter" },
            { "AV_BLOCK1", "AV1" },
            { "AV_BLOCK2I", "AV2Type1" },
            { "AV_BLOCK2II", "AV2Type2" },
            { "AV_BLOCK3", "AV3" },
            { "ASYSTOLE_IDIOVENTRICULAR", "Idioventricular" },
            { "VT", "VT" },
            { "VT2", "VT2" },
            { "TORSADE_DE_POINT", "TDePointes" },
            { "VF", "VF" },
            { "ASYSTOLE", "Asystole" },
            { "PACER_VVI", "Pacemaker" },
            { "PACER_DDD", "PacemakerAV" },
            { "PACER_VVI_MALE_FUNCTION", "PacemakerLOC" },
            // New rhythms in SimDesigner
            { "SINUS_60_YEARS", "Sinus" },
            { "SINUS_POST_ISCHAEMIA", "Ischemia" },
            { "SINUS_AMI_ANTERIOR", "InfAMI" },
            { "SINUS_AMI_ANTERIOR_LATE", "InfAMI" },
            { "SINUS_HYPERTROPHIA", "Sinus" },
            { "SINUS_RIGHT_HYPERTROPHIA", "Sinus" },
            { "SINUS_RIGHT_HYPERTROPHIA_STRESSED", "Sinus" },
            { "VENTRICULAR_STANDSTILL", "Asystole" },
        }) },
        { "Laerdal.Response.Ecg.HeartRate_bpm", new NumericParameterConverter("HR") },
        { "Laerdal.Response.Ecg.MuscularArtefacts", new BooleanParameterConverter("MuscularArtifacts") },
        { "Laerdal.Response.Ecg.ElectricalArtefacts", new BooleanParameterConverter("ACArtifacts") },
        { "Laerdal.Response.Ecg.Severity", null },
        { "Laerdal.Response.Ecg.Extrasystole", new EnumParameterConverter("ExtraSystoleType", new()
        {
            { "NONE", "1" }, // None
            { "PAC_PJC", "2" }, // PJC
            { "UNIFOCAL_PVC", "3" }, // Unifocal PVC
            { "PVC_R_ON_T", "6" }, // PVC R/T
            { "COUPLED_PVC", "4" }, // Coupled PVC
        }) },
        { "Laerdal.Response.Ecg.ExtrasystoleFrequency", new ExtrasystoleFrequencyParameterConverter("ExtraSystoleProbability") },
        { "Laerdal.Response.Ecg.PEA", new BooleanParameterConverter("PEA") },
        { "Laerdal.Response.Respiration.RR_BreathsPerMinute", new NumericParameterConverter("RR") },
        { "Laerdal.Response.SpO2.Value_Percent", new NumericParameterConverter("SpO2") },
        { "Laerdal.Response.Temp.TBlood_Celcius", new NumericParameterConverter("Temp", scaling: 10) },
        { "Laerdal.Response.Temp.TPeri_Celcius", new NumericParameterConverter("TempPeri", scaling: 10) },
        { "Laerdal.Response.CapillaryRefillTime.LeftHand_Seconds", new NumericParameterConverter("CapillaryRefillTimePeri") },
        { "Laerdal.Response.CapillaryRefillTime.Sternum_Seconds", new NumericParameterConverter("CapillaryRefillTime") },
        { "Laerdal.Response.etCO2.Value_mmHg", new NumericParameterConverter("EtCO2") },
        { "Laerdal.Response.etCO2.ExpirationSlope_Percent", new NumericParameterConverter("EtCO2ExpirationSlope") },
        { "Laerdal.Response.etCO2.InspirationSlope_Percent", new NumericParameterConverter("EtCO2InspirationSlope") },
        { "Laerdal.Response.SpO2.CyanosisThreshold_Percent", null },
        { "Laerdal.Response.PAP.Wedge_mmHg", null },
        { "Laerdal.Response.PAP.Systolic_mmHg", null },
        { "Laerdal.Response.PAP.Diastolic_mmHg", null },
        { "Laerdal.Response.CVP.Value_mmHg", null },
        { "Laerdal.Response.ICP_mmHg", null },
        { "Laerdal.Response.pH", null },
        { "Laerdal.Response.CardiacOutput.Value_LiterPerMinute", null },
        { "Laerdal.Response.N2O.inN2O_Percent", null },
        { "Laerdal.Response.N2O.etN2O_Percent", null },
        { "Laerdal.Response.O2.inO2_Percent", null },
        { "Laerdal.Response.O2.etO2_Percent", null },
        { "Laerdal.Response.AGT.inAGT_Percent", null },
        { "Laerdal.Response.AGT.etAGT_Percent", null },
        { "Laerdal.Response.TOF.Count", null },
        { "Laerdal.Response.TOF.Percent", null },
        { "Laerdal.Response.PTC", null },
        { "Laerdal.Response.MuscleTone.Type", new EnumParameterConverter("MovementState", new()
        {
            { "TONE", "1" }, // Tone
            { "LIMP", "2" }, // Limp
            { "MOTION", "3" }, // Motion
            { "SEIZURE", "4" }, // Seizure
            { "SEIZURE_LEFT_ARM", "5" }, // Seizure left arm
            { "SEIZURE_RIGHT_ARM", "6" }, // Seizure right arm
        }) },
        { "Laerdal.Response.Auscultation.Heart.Whole", new EnumParameterConverter("HeartSound", new()
        {
            { "NORMAL", "Normal" },
            { "AORTIC_STENOSIS", "Aortic stenosis" },
            { "EARLY_SYSTOLIC_MURMUR", "Early systolic murmur" },
            { "HOLOSYSTOLIC_MURMUR", "Holosystolic murmur" },
            { "DIASTOLIC_MURMUR", "Diastolic murmur" },
            { "CONTINOUS_MURMUR", "Continuous murmur" },
            { "GALLOP", "Gallop" },
            { "VENTRICULAR_SEPTAL_DEFECT", "Ventricular Septal Defect" },
            { "ATRIAL_SEPTAL_DEFECT", "Atrial Septal Defect" },
            { "PULMONARY_STENOSIS", "Pulmonary Stenosis" },
            //{ "NO_SOUND", "No sound" }
        }) },
        { "Laerdal.Response.Auscultation.Heart.WholeVolume_Percent", new NumericParameterConverter("HeartSoundVolume", scaling: 0.1) },
        { "Laerdal.Response.Respiration.ChestRise", new EnumParameterConverter("ChestRise", new()
        {
            { "NONE", "0" }, // Off
            { "NORMAL", "1" }, // Normal
            { "SHALLOW", "2" }, // Shallow
            { "DEEP", "3" }, // Deep
            { "IRREGULAR", "4" }, // Irregular
        }) },
        { "Laerdal.Response.Airway.LungCompliance_Percent", new NumericParameterConverter("LungCompliancePercent") },
        { "Laerdal.Response.Airway.AirFlowBlocked", null }, // AirwayBlockage
        { "Laerdal.Response.Airway.LungResistanceLeft_Percent", null }, // AirwayBlockage
        { "Laerdal.Response.Airway.LungResistanceRight_Percent", null }, // AirwayBlockage
        { "Laerdal.Response.Respiration.BreathingPattern", new EnumParameterConverter("BreathingPattern", new()
        {
            { "NORMAL", "0" }, // Noraml
            { "RETRACTION", "1" }, // Retraction
            { "SEESAW", "2" }, // Saw
        }) },
        //{ "Laerdal.Response.Airway.TongueFallback", new BooleanParameterConverter("TongueFallback") }, // AirwayBlockage
        { "Laerdal.Response.Airway.TongueEdema_Percent", new TongueEdemaParameterConverter("TongueEdema") },

        { "Laerdal.Response.Auscultation.LungRight.Whole", new LungSoundParameterConverter("LungSoundRight") },
        { "Laerdal.Response.Auscultation.LungRight.Anterior", new LungSoundParameterConverter("LungSoundRightAnterior") },
        { "Laerdal.Response.Auscultation.LungRight.Posterior", new LungSoundParameterConverter("LungSoundRightPosterior") },
        { "Laerdal.Response.Auscultation.LungRight.AnteriorUpper", new LungSoundParameterConverter("LungSoundRightAnteriorUpper") },
        { "Laerdal.Response.Auscultation.LungRight.PosteriorUpper", new LungSoundParameterConverter("LungSoundRightPosteriorUpper") },
        { "Laerdal.Response.Auscultation.LungRight.AnteriorLower", new LungSoundParameterConverter("LungSoundRightAnteriorLower") },
        { "Laerdal.Response.Auscultation.LungRight.PosteriorLower", new LungSoundParameterConverter("LungSoundRightPosteriorLower") },
        { "Laerdal.Response.Auscultation.LungRight.WholeVolume_Percent", new NumericParameterConverter("LungSoundVolumeRight", scaling: 0.1) },
        { "Laerdal.Response.Auscultation.LungRight.AnteriorVolume_Percent", new NumericParameterConverter("LungSoundVolumeRightAnterior", scaling: 0.1) },
        { "Laerdal.Response.Auscultation.LungRight.PosteriorVolume_Percent", new NumericParameterConverter("LungSoundVolumeRightPosterior", scaling: 0.1) },
        { "Laerdal.Response.Auscultation.LungRight.AnteriorUpperVolume_Percent", new NumericParameterConverter("LungSoundVolumeRightAnteriorUpper", scaling: 0.1) },
        { "Laerdal.Response.Auscultation.LungRight.PosteriorUpperVolume_Percent", new NumericParameterConverter("LungSoundVolumeRightPosteriorUpper", scaling: 0.1) },
        { "Laerdal.Response.Auscultation.LungRight.AnteriorLowerVolume_Percent", new NumericParameterConverter("LungSoundVolumeRightAnteriorLower", scaling: 0.1) },
        { "Laerdal.Response.Auscultation.LungRight.PosteriorLowerVolume_Percent", new NumericParameterConverter("LungSoundVolumeRightPosteriorLower", scaling: 0.1) },

        { "Laerdal.Response.Auscultation.LungLeft.Whole", new LungSoundParameterConverter("LungSoundLeft") },
        { "Laerdal.Response.Auscultation.LungLeft.Anterior", new LungSoundParameterConverter("LungSoundLeftAnterior") },
        { "Laerdal.Response.Auscultation.LungLeft.Posterior", new LungSoundParameterConverter("LungSoundLeftPosterior") },
        { "Laerdal.Response.Auscultation.LungLeft.AnteriorUpper", new LungSoundParameterConverter("LungSoundLeftAnteriorUpper") },
        { "Laerdal.Response.Auscultation.LungLeft.PosteriorUpper", new LungSoundParameterConverter("LungSoundLeftPosteriorUpper") },
        { "Laerdal.Response.Auscultation.LungLeft.AnteriorLower", new LungSoundParameterConverter("LungSoundLeftAnteriorLower") },
        { "Laerdal.Response.Auscultation.LungLeft.PosteriorLower", new LungSoundParameterConverter("LungSoundLeftPosteriorLower") },
        { "Laerdal.Response.Auscultation.LungLeft.WholeVolume_Percent", new NumericParameterConverter("LungSoundVolumeLeft", scaling: 0.1) },
        { "Laerdal.Response.Auscultation.LungLeft.AnteriorVolume_Percent", new NumericParameterConverter("LungSoundVolumeLeftAnterior", scaling: 0.1) },
        { "Laerdal.Response.Auscultation.LungLeft.PosteriorVolume_Percent", new NumericParameterConverter("LungSoundVolumeLeftPosterior", scaling: 0.1) },
        { "Laerdal.Response.Auscultation.LungLeft.AnteriorUpperVolume_Percent", new NumericParameterConverter("LungSoundVolumeLeftAnteriorUpper", scaling: 0.1) },
        { "Laerdal.Response.Auscultation.LungLeft.PosteriorUpperVolume_Percent", new NumericParameterConverter("LungSoundVolumeLeftPosteriorUpper", scaling: 0.1) },
        { "Laerdal.Response.Auscultation.LungLeft.AnteriorLowerVolume_Percent", new NumericParameterConverter("LungSoundVolumeLeftAnteriorLower", scaling: 0.1) },
        { "Laerdal.Response.Auscultation.LungLeft.PosteriorLowerVolume_Percent", new NumericParameterConverter("LungSoundVolumeLeftPosteriorLower", scaling: 0.1) },

        { "Laerdal.Response.Airway.PneumothoraxLeftVer2", new EnumParameterConverter("PneumothoraxLeft", new()
        {
            { "TENSION", "true" },
        }) },
        //{ null, "PneumothoraxRight" }, // Not supported
        { "Laerdal.Response.HeadSeizure", new BooleanParameterConverter("HeadSeizure") },
        //{ null, "EyeSeizure" }, // Not supported. Use Laerdal.Response.Eyes.BlinkRate
        { "Laerdal.Response.Convulsions.Type", null },
        { "Laerdal.Response.HeadLimp", new HeadLimpParameterConverter("HeadLimp") },
        { "Laerdal.Response.Eyes.BlinkRate", new NumericParameterConverter("EyesBlinkRate") },
        { "Laerdal.Response.Fontanelle.IsFull", new FontanelleParameterConverter("Fontanelle") },
        { "Laerdal.Response.Pulses.EnablePulseRules", null },
        { "Laerdal.Response.Pacing.Threshold_mA", new NumericParameterConverter("PacingThreshold") },
        { "Laerdal.Response.Pulses.Central", new PulseParameterConverter("PulseCentral") },
        { "Laerdal.Response.Pulses.LeftArm", new PulseParameterConverter("PulsePeripheral") },
        { "Laerdal.Response.Pulses.RightArm", new PulseParameterConverter("PulsePeripheral") },
        { "Laerdal.Response.Pulses.Femoral", new PulseParameterConverter("PulseCentral") },
        { "Laerdal.Response.Pulses.Neck", new PulseParameterConverter("PulseCentral") },
        { "Laerdal.Response.Auscultation.LungLeft.PresetName", new LungSoundParameterConverter("LungSoundLeftPreset") },
        { "Laerdal.Response.Auscultation.LungRight.PresetName", new LungSoundParameterConverter("LungSoundRightPreset") },
        { "Laerdal.Response.Airway.Laryngospasm_Percent", new LaryngospasmParameterConverter("Laryngospasm") },
        { "Laerdal.Response.Airway.PharyngealObstruction", new BooleanParameterConverter("PharyngealObstruction") },
        { "Laerdal.Response.Airway.FBAO", null }, // Foreign body
        //{ null, "ALL_NORMAL" }, // Responses.SetAllOtherParamsToDefault
        //{ null, "StartState" }, // Not supported
        { "Laerdal.Response.Airway.StomachDistention.Enabled", new StomachDistentionParameterConverter("StomachDistension") },
        { "Laerdal.Response.Airway.StomachDistention.Inflate", new StomachDistentionParameterConverter("StomachDistension") },
        { "Laerdal.Response.Auscultation.Bowel.Whole", new EnumParameterConverter("BowelSound", new()
        {
            { "NORMAL", "Normal" },
            { "BORBORYGMUS", "Borborygmus" },
            { "HYPERACTIVE", "Hyperactive" },
            { "HYPOACTIVE", "Hypoactive" },
            { "NO_SOUND", "No sound" },
        }) },
        { "Laerdal.Response.Auscultation.Bowel.WholeVolume_Percent", new NumericParameterConverter("BowelSoundVolume", scaling: 0.1) },
        //{ null, "CompressorOn" }, // Not supported
        //{ null, "CompressorSetting" }, // Not supported
        { "Laerdal.Response.BloodPressure.KorotkoffVolume", new NumericParameterConverter("KorotkoffVolume", scaling: 0.1) },
        { "Laerdal.Response.BloodPressure.AuscultationGap", new BooleanParameterConverter("KorotkoffGap") },
        //{ null, "VocalSound" }, // Not supported
        //{ null, "VocalSoundVolume" }, // Not supported
        
    };
}