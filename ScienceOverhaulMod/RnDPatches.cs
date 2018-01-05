using System;
using System.Collections.Generic;
using Harmony;

namespace ScienceOverhaulMod.Patches.RnDPatches
{
    /// <summary>
    /// This method is part of the Part Test contract template. When a contract has the
    /// user test a part, this is called. It marks a part as testable, which adds the right-click
    /// option "test" to the part. <see cref="RemoveExperimentalPart"/> is called when the contract is completed.
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// Note: Multiple contracts may add the experimental part. So, each call to <c>AddExperimentalPart</c>
    /// must increment a counter, and each call to <see cref="RemoveExperimentalPart"/> should decrement that counter.
    /// In the stock code, <c>ResearchAndDevelopment.experimentalPartsStock</c> handles incrementing/decrementing.
    /// 
    /// Called by:
    ///     <c>Contracts.Templates.PartTest.OnAccepted()</c>
    /// 
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("AddExperimentalPart")]
    class AddExperimentalPartPatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="AddExperimentalPartPatch"/> info about the patched method.
        /// <param name="ap">The part to add.</param>
        /// </summary>
        static bool Prefix(AvailablePart ap)
        {
            return true;
        }
    }

    /// <summary>
    /// This method returns true if the user can afford to research the given tech tree node. This method should always
    /// return true if science is disabled for this game mode.
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// In the stock code, this method returns true if <c>round(ResearchAndDevelopment.Science) >= round(amount)</c> or
    /// if <c>ResearchAndDevelopment.Instance</c> is null.
    /// 
    /// Called by:
    ///     <c>Strategies.Strategy.CanBeActivated(string)</c>
    /// 
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("CanAfford")]
    class CanAffordPatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="CanAffordPatch"/> info about the patched method.
        /// </summary>
        static bool Prefix(ref bool __result, float amount)
        {
            return true;
        }
    }

    /// <summary>
    /// This method looks through every part, and checks if there are any that aren't assigned to a tech node. It returns
    /// the list of found parts as a (space separated?) string. If there are no parts, it returns a default string.
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// This method is for debugging purposes.
    /// 
    /// Called by:
    ///     <c>RnDDebugUtil.DrawSciencePage()</c>
    /// 
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("CheckForMissingParts")]
    class CheckForMissingPartsPatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="CheckForMissingPartsPatch"/> info about the patched method.
        /// </summary>
        static bool Prefix(ref string __result)
        {
            return true;
        }
    }

    /// <summary>
    /// This method returns the total amount of science available in the whole game.
    /// </summary>
    /// <remarks>
    /// 
    /// This method is for debugging purposes.
    /// 
    /// The stock method iterates over every <c>ExperimentSituation</c>, <c>CelestialBody</c>, and Biome, looks up the science, and
    /// returns the sum of all the science values.
    /// 
    /// Called by:
    ///     <c>RnDDebugUtil.DrawSciencePage()</c>
    /// 
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("CountUniversalScience")]
    class CountUniversalSciencePatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="CountUniversalSciencePatch"/> info about the patched method.
        /// </summary>
        static bool Prefix(ref string __result)
        {
            return true;
        }
    }

    /// <summary>
    /// This method returns the names of the biomes for a given CelestialBody, with spaces removed, in the order they appear in
    /// <c>CelestialBody.BiomeMap.Attributes[]</c>, followed by the same thing for minibiomes if <c>includeMiniBiomes</c> is
    /// <c>true</c>.
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// This method is used to populate the Archives tab of the RnD building.
    /// 
    /// The stock method calls <c>ResearchAndDevelopment.GetMiniBiomeTags</c> for minibiome info.
    /// 
    /// Called by:
    ///     <c>KSP.UI.Screens.RDEnvironmentAdapter.GetBiomeTags(CelestialBody, bool)</c>
    /// 
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("GetBiomeTags")]
    class GetBiomeTagsPatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="GetBiomeTagsPatch"/> info about the patched method.
        /// </summary>
        static bool Prefix(ref List<string> __result, CelestialBody cb, bool includeMiniBiomes)
        {
            return true;
        }
    }

    /// <summary>
    /// Identical to <see cref="GetBiomeTagsPatch"/>, but uses localized (<c>displayname</c>) strings.
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// Called by:
    ///     <c>KSP.UI.Screens.RDEnvironmentAdapter.GetBiomeTagsLocalized(CelestialBody, bool)</c>
    /// 
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("GetBiomeTagsLocalized")]
    class GetBiomeTagsLocalizedPatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="GetBiomeTagsLocalizedPatch"/> info about the patched method.
        /// </summary>
        static bool Prefix(ref List<string> __result, CelestialBody cb, bool includeMiniBiomes)
        {
            return true;
        }
    }

    /// <summary>
    /// This method returns the <c>ScienceExperiment</c> object that corresponds to a given <c>experimentID</c> string.
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// This is one of the main methods of the <c>ResearchAndDevelopment</c> class. Returned experiments <i>may</i> be modified,
    /// stored, etc.
    /// 
    /// Called by:
    ///     <c>ExperimentResultDialogPage.ExperimentResultDialogPage(...)</c>
    ///     <c>FinePrint.Contracts.Parameters.SurveyWaypointParameter.CalculateAltitudes(double)</c>
    ///     <c>FinePrint.Contracts.Parameters.SurveyWaypointParameter.GetTitle()</c>
    ///     <c>FinePrint.Contracts.SurveyContract.PossibleDefinitions()</c>
    ///     <c>FinePrint.Utilities.ProgressUtilities.ExperimentPossibleAt(string, CelestialBody, double, double, double, double)</c>
    ///     <c>KSP.UI.Screens.RDEnvironmentAdapter.GetExperiment(string)</c>
    ///     <c>ModuleAsteroid.OnStart(StartState)</c>
    ///     <c>ModuleScienceExperiment.OnStart(StartState)</c>
    ///     <c>ResearchAndDevelopment.GetResults(string)</c> (stock version)
    ///     <c>ScienceData.Load(ConfigNode)</c>
    ///     <c>ScienceUtil.GenerateLocalizedTitle(string)</c>
    ///     <c>ScienceUtil.generateRecoveryLocalizedTitle(string)</c>
    ///     <c>ScienceUtil.GetExperimentFieldsFromScienceID(string, string, string, string)</c>
    ///     <c>Upgradeables.KSCFacilityLevelText.GetValue(string, float)</c>
    /// 
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("GetExperiment")]
    class GetExperimentPatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="GetExperimentPatch"/> info about the patched method.
        /// </summary>
        static bool Prefix(ref ScienceExperiment __result, string experimentID)
        {
            return true;
        }
    }

    /// <summary>
    /// This method returns a list of all possible experiment IDs, that can be used in <see cref="GetExperimentPatch"/>.
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// The stock method just returns <c>ResearchAndDevelopment.experiments.Keys</c> converted into a <c>List&lt;string&gt;</c>.
    /// 
    /// Called by:
    ///     <c>KSP.UI.Screens.RDEnvironmentAdapter.GetExperimentIDs()</c>
    /// 
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("GetExperimentIDs")]
    class GetExperimentIDsPatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="GetExperimentIDsPatch"/> info about the patched method.
        /// </summary>
        static bool Prefix(ref List<string> __result)
        {
            return true;
        }
    }

    /// <summary>
    /// This method is a builder for <c>ScienceSubject</c> instances.
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// The stock method constructs a ScienceSubject from the parameters, then runs it through <see cref="RnDOverhaul.getScienceSubject"/>.
    /// 
    /// Called by:
    ///     <c>ModuleScienceExperiment.gatherData(bool)</c>
    /// 
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("GetExperimentSubject")]
    [HarmonyPatch(new Type[] {typeof(ScienceExperiment), typeof(ExperimentSituations), typeof(CelestialBody), typeof(string), typeof(string)})]
    class GetExperimentSubjectPatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="GetExperimentSubjectPatch"/> info about the patched method.
        /// </summary>
        static bool Prefix(ref ScienceSubject __result, ScienceExperiment experiment, ExperimentSituations situation, CelestialBody body, string biome, string displaybiome)
        {
            return true;
        }
    }

    /// <summary>
    /// This method is a builder for <c>ScienceSubject</c> instances.
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// The stock method constructs a ScienceSubject from the parameters, then runs it through <see cref="RnDOverhaul.getScienceSubject"/>.
    /// 
    /// Called by:
    ///     <c>ModuleAsteroid.performSampleExperiment(ModuleScienceContainer)</c>
    /// 
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("GetExperimentSubject")]
    [HarmonyPatch(new Type[] {typeof(ScienceExperiment), typeof(ExperimentSituations), typeof(string), typeof(string), typeof(CelestialBody), typeof(string), typeof(string)})]
    class GetExperimentSubjectWithSourcePatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="GetExperimentSubjectWithSourcePatch"/> info about the patched method.
        /// </summary>
        static bool Prefix(ref ScienceSubject __result, ScienceExperiment experiment, ExperimentSituations situation, string sourceUId, string sourceTitle, CelestialBody body, string biome, string displaybiome)
        {
            return true;
        }
    }

    /// <summary>
    /// This method returns the name of the minibiome given a scienceID.
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// If <c>formatted</c> is <c>true</c>, use <c>MiniBiome.GetDisplayName</c>, otherwise use <c>MiniBiome.LocalizedTag</c>.
    /// 
    /// Called by:
    ///     <c>OrbitRenderer.objectNode_OnUpdateCaption(MapNode, CaptionData)</c>
    ///     <c>ProtoVessel.GetSituationString(ProtoVessel, List&lt;CelestialBody&gt;)</c>
    ///     <c>ScienceUtil.GetBiomedisplayName(CelestialBody, string)</c>
    ///     <c>Vessel.GetSituationString(Vessel)</c>
    ///     <c>VesselRecovery.OnVesselRecovered(ProtoVessel, bool)</c>
    /// 
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("GetMiniBiomedisplayNameByScienceID")]
    class GetMiniBiomedisplayNameByScienceIDPatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="GetMiniBiomedisplayNameByScienceIDPatch"/> info about the patched method.
        /// </summary>
        static bool Prefix(ref string __result, string TagID, bool formatted)
        {
            return true;
        }
    }

    /// <summary>
    /// This method returns the name of the minibiome given a unity tag?
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// If <c>formatted</c> is <c>true</c>, use <c>MiniBiome.GetDisplayName</c>, otherwise use <c>MiniBiome.LocalizedTag</c>.
    /// 
    /// Called by:
    ///     <c>FlightDriver.Start()</c>
    ///     <c>ModuleDeployableSolarPanel.CalculateTrackingLOS(Vector3, string)</c>
    ///     <c>Vessel.SetLandedAt(string, GameObject, string)</c>
    /// 
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("GetMiniBiomedisplayNameByUnityTag")]
    class GetMiniBiomedisplayNameByUnityTagPatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="GetMiniBiomedisplayNameByUnityTagPatch"/> info about the patched method.
        /// </summary>
        static bool Prefix(ref string __result, string TagID, bool formatted)
        {
            return true;
        }
    }

    /// <summary>
    /// Returns a list of all minibiomes for a given <c>CelestialBody</c>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// Called by:
    ///     <c>ResearchAndDevelopment.GetBiomeTags(CelestialBody, bool)</c> (stock version)
    /// 
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("GetMiniBiomeTags")]
    class GetMiniBiomeTagsPatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="GetMiniBiomeTagsPatch"/> info about the patched method.
        /// </summary>
        static bool Prefix(ref List<string> __result, CelestialBody cb)
        {
            return true;
        }
    }

    /// <summary>
    /// Same as <see cref="GetMiniBiomeTagsPatch"/>, but with localized strings.
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// Called by:
    ///     <c>ResearchAndDevelopment.GetBiomeTagsLocalized(CelestialBody, bool)</c> (stock version)
    /// 
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("GetMiniBiomeTagsLocalized")]
    class GetMiniBiomeTagsLocalizedPatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="GetMiniBiomeTagsLocalizedPatch"/> info about the patched method.
        /// </summary>
        static bool Prefix(ref List<string> __result, CelestialBody cb)
        {
            return true;
        }
    }

    /// <summary>
    /// This method is used to show the user how much "available" science there is using a given experiment.
    /// It's the value of the experiment AFTER the current experiment is processed fully.
    /// It's the grey-green part of the bar in the experiment dialog.
    /// </summary>
    /// <remarks>
    /// 
    /// This is part of the diminishing-returns system in KSP for science measured from the same place
    /// multiple times.
    /// 
    /// Called by:
    ///     <c>ExperimentResultDialogPage.ExperimentResultDialogPage(...)</c>
    /// 
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("GetNextScienceValue")]
    class GetNextScienceValuePatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="GetNextScienceValuePatch"/> info about the patched method.
        /// </summary>
        static bool Prefix(ref float __result, float dataAmount, ScienceSubject subject, float xmitScalar)
        {
            return true;
        }
    }

    /// <summary>
    /// This method returns the <i>reference multiplier</i>, which is based on how much valuable the <b>situation</b>
    /// of the experiment is for the <c>CelestialBody</c> it came from.
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// Called by:
    ///     <c>ExperimentResultDialogPage.ExperimentResultDialogPage(...)</c>
    ///     <c>ResearchAndDevelopment.GetNextScienceValue(float, ScienceSubject, float)</c> (stock version)
    ///     <c>ResearchAndDevelopment.GetScienceValue(float, ScienceSubject, float)</c> (stock version)
    /// 
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("GetReferenceDataValue")]
    class GetRefereneceDataValuePatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="GetRefereneceDataValuePatch"/> info about the patched method.
        /// <param name="dataAmount"/>The amount of data recieved via normal processing or transmission. It's measured in mits, not science points!</param>
        /// </summary>
        static bool Prefix(ref float __result, float dataAmount, ScienceSubject subject)
        {
            return true;
        }
    }

    /// <summary>
    /// This method returns the results string. It locates the experiment string based on the full experiment ID. If there are multiple copies, it chooses
    /// randomly; if there is no entry for this particular situation, it uses the default string.
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// Any localization needs to happen before returning the string.
    /// 
    /// Called by:
    ///     <c>ExperimentResultDialogPage.ExperimentResultDialogPage(...)</c>
    ///     <c>KSP.UI.Screens.RDEnvironmentAdapter.GetResults(string)</c>
    /// 
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("GetResults")]
    class GetResultsPatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="GetResultsPatch"/> info about the patched method.
        /// </summary>
        static bool Prefix(ref float __result, string subjectID)
        {
            return true;
        }
    }

    /// <summary>
    /// This method converts the amount of mits recieved into actual science points, based on the experiment
    /// and its situation.
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// Called by:
    ///     <c>ExperimentResultDialogPage.ExperimentResultDialogPage(...)</c>
    ///     <c>ResearchAndDevelopment.GetNextScienceValue(float, ScienceSubject, float)</c> (stock version)
    ///     <c>ResearchAndDevelopment.SubmitScienceData(float, ScienceSubject, float, ProtoVessel, bool)</c> (stock version)
    /// 
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("GetScienceValue")]
    class GetScienceValuePatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="GetScienceValuePatch"/> info about the patched method.
        /// </summary>
        static bool Prefix(ref float __result, float dataAmount, ScienceSubject subject, float xmitScalar)
        {
            return true;
        }
    }

    /// <summary>
    /// This method returns the list of experiment situations, as strings. Nothing important actually uses this method; everything
    /// in the stock KSP code directly uses the ExperimentSituations enum. This method should become the preferred method of finding
    /// situations for experiments, so that new situations can be added.
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// Called by:
    ///     <c>KSP.UI.Screens.RDEnvironmentAdapter.GetSituationTags()</c>
    /// 
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("GetSituationTags")]
    class GetSituationTagsPatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="GetSituationTagsPatch"/> info about the patched method.
        /// </summary>
        static bool Prefix(ref List<string> __result)
        {
            return true;
        }
    }

    /// <summary>
    /// This method returns descriptions for each situation, used in the Archives tab of the RnD building. It must be the same order as
    /// returned by <see cref="GetSituationTagsDescriptionsPatch"/>.
    /// </summary>
    /// <remarks>
    /// 
    /// Called by:
    ///     <c>KSP.UI.Screens.RDEnvironmentAdapter.GetSituationTagsDescriptions()</c>
    /// 
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("GetSituationTagsDescriptions")]
    class GetSituationTagsDescriptionsPatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="GetSituationTagsDescriptionsPatch"/> info about the patched method.
        /// </summary>
        static bool Prefix(ref List<string> __result)
        {
            return true;
        }
    }

    /// <summary>
    /// This method returns the ScienceSubject object for a given experiment ID string.
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// Called by:
    ///     <c>ExperimentResultDialogPage.ExperimentResultDialogPage(...)</c>
    ///     <c>ModuleDataTransmitter.transmitQueuedData(float, float, Callback, bool)</c>
    /// 
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("GetSubjectByID")]
    class GetSubjectByIDPatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="GetSubjectByIDPatch"/> info about the patched method.
        /// </summary>
        static bool Prefix(ref ScienceSubject __result, string subjectID)
        {
            return true;
        }
    }

    /// <summary>
    /// This method returns the list of all ScienceSubjects.
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// Called by: 
    ///     <c>KSP.UI.Screens.RDEnvironmentAdapter.GetSubjects()</c>
    ///     
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("GetSubjects")]
    class GetSubjectsPatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="GetSubjectsPatch"/> info about the patched method.
        /// </summary>
        static bool Prefix(ref List<ScienceSubject> __result)
        {
            return true;
        }
    }

    /// <summary>
    /// 
    /// This method returns the <i>subject</i> multiplier for the given subject. This represents
    /// how difficult it is to measure science in this particular situation.
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// Called by:
    ///     <c>ResearchAndDevelopment.GetNextScienceValue(float, ScienceSubject, float)</c> (stock version)
    ///     <c>ResearchAndDevelopment.SubmitScienceData(float, ScienceSubject, float, ProtoVessel, bool)</c> (stock version)
    /// 
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("GetSubjectValue")]
    class GetSubjectValuePatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="GetSubjectValuePatch"/> info about the patched method.
        /// </summary>
        static bool Prefix(ref float __result, float subjectScience, ScienceSubject subject)
        {
            return true;
        }
    }


    /// <summary>
    /// This method returns the state object for the given tech tree node.
    /// </summary>
    /// <remarks>
    /// 
    /// This method offers very powerful control over how the science tree is stored, displayed, changed, and unlocked.
    /// 
    /// Called by:
    ///     <c>Contracts.Templates.PartTest.Generate()</c>
    ///     <c>Contracts.Templates.RecoverAsset.ChooseVesselType(Random)</c>
    ///     <c>KSP.UI.Screens.RDTechTree.GetCheapestUnavailableNodes(int)</c>
    ///     <c>KSP.UI.Screens.RDTechTree.recurseForNextTechs(ProtoRDNode, List&lt;ProtoTechNode&gt;)</c>
    ///     <c>ModuleToggleCrossfeed.CrossfeedHasTech()</c>
    ///     <c>Part.AllowAutoStruts()</c>
    ///     <c>PartUpgradeHandler.IsAvailableToUnlock(string)</c>
    ///     <c>PartUpgradeHandler.IsUnlocked(string)</c>
    /// 
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("GetTechnologyState")]
    class GetTechnologyStatePatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="GetTechnologyStatePatch"/> info about the patched method.
        /// </summary>
        static bool Prefix(ref RDTech.State __result, string techID)
        {
            return true;
        }
    }

    /// <summary>
    /// This method returns the localized name of a given tech tree node.
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// This method is mostly used to display warning messages when unavailable tech is required for an action.
    /// 
    /// Called by:
    ///     <c>KSP.UI.Screens.Editor.PartListTooltipController.onPurchaseProceed()</c>
    ///     <c>PreFlightTests.ExperimentalPartsAvailable.ExperimentalPartsAvailable(ShipConstruct)</c>
    ///     <c>PreFlightTests.ExperimentalPartsAvailable.ExperimentalPartsAvailable(VesselCrewManifest)</c>
    ///     <c>ProtoRDNode.ProtoRDNode(ConfigNode)</c>
    ///     <c>RDTech.Start()</c>
    /// 
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("GetTechnologyTitle")]
    class GetTechnologyTitlePatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="GetTechnologyTitlePatch"/> info about the patched method.
        /// </summary>
        static bool Prefix(ref string __result, string techID)
        {
            return true;
        }
    }

    /// <summary>
    /// This method is part of the Part Test contract template. When a contract has the
    /// user test a part, <see cref="AddExperimentalPart"/> is called. It marks a part as testable, which adds the
    /// right-click option "test" to the part. This method returns <c>true</c> if the part is marked as testable.
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// Note: Multiple contracts may add the experimental part. So, each call to <see cref="AddExperimentalPart"/>
    /// must increment a counter, and each call to <see cref="RemoveExperimentalPart"/> should decrement that counter. In
    /// the stock code, <c>ResearchAndDevelopment.experimentalPartsStock</c> handles incrementing/decrementing.
    /// 
    /// 
    /// Called by:
    ///     <c>Contracts.Templates.PartTest.OnAccepted()</c>
    ///     <c>KSP.UI.Screens.Editor.PartListTooltip._GetPartStats(Part, bool)</c>
    ///     <c>KSP.UI.Screens.EditorPartIcon.CheckExperimental()</c>
    ///     <c>PreFlightTests.ExperimentalPartsAvailable.GetWarningDescription()</c>
    ///     <c>PreFlightTests.ExperimentalPartsAvailable.Test()</c>
    ///     <c>ShipTemplate.LoadShip(ConfigNode)</c>
    ///     
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("IsExperimentalPart")]
    class IsExperimentalPartPatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="IsExperimentalPartPatch"/> info about the patched method.
        /// </summary>
        static bool Prefix(ref bool __result, AvailablePart ap)
        {
            return true;
        }
    }

    /// <summary>
    /// I *think* this method returns the list of parts that don't have a tech node.
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// This method is for debugging.
    /// 
    /// Called by:
    ///     <c>RnDDebugUtil.DrawSciencePage()</c>
    /// 
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("PartAssignmentSummary")]
    class PartAssignmentSummaryPatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="PartAssignmentSummaryPatch"/> info about the patched method.
        /// </summary>
        static bool Prefix(ref string __result)
        {
            return true;
        }
    }

    /// <summary>
    /// This method returns true if the given part has been purchased, and true if this isn't career mode.
    /// </summary>
    /// <remarks>
    /// 
    /// Called by: 
    ///     <c>Contracts.Templates.PartTest.OnAccepted()</c>
    ///     <c>KSP.UI.Screens.Editor.PartListTooltip.Setup(AvailablePart, Callback&lt;PartListTooltip&gt;, RenderTexture)</c>
    ///     <c>ModuleTestSubject.delayedStart(int)</c>
    ///     
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("PartModelPurchased")]
    class PartModelPurchasedPatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="PartModelPurchasedPatch"/> info about the patched method.
        /// </summary>
        static bool Prefix(ref bool __result, AvailablePart ap)
        {
            return true;
        }
    }

    /// <summary>
    /// This method returns true if a given part's tech node has been unlocked.
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// This is a powerful way to control part unlocking. It may be possible to have parts listed under multiple tech tree nodes.
    /// 
    /// Called by:
    ///     <c>FinePrint.Contracts.SatelliteContract.ProbeCoresUnlocked()</c>
    ///     <c>FinePrint.Utilities.ProgressUtilities.HaveModuleTech(string, string)</c>
    ///     <c>FinePrint.Utilities.ProgressUtilities.HavePartTech(string, bool)</c>
    ///     <c>KSP.UI.Screens.Editor.PartListTooltip.Setup(AvailablePart, Callback&lt;PartListTooltip&gt;, RenderTexture)</c>
    ///     <c>ResearchAndDevelopment.ResearchedValidContractObjectives(List&lt;string&gt;, bool)</c>
    ///     <c>ShipConstruct.LoadShip(ConfigNode)</c>
    ///     <c>ShipTemplate.LoadShip(ConfigNode)</c>
    ///     <c>TutorialScience.OnTutorialSetup()</c>
    /// 
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("PartTechAvailable")]
    class PartTechAvailablePatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="PartTechAvailablePatch"/> info about the patched method.
        /// </summary>
        static bool Prefix(ref bool __result, AvailablePart ap)
        {
            return true;
        }
    }

    /// <summary>
    /// Finds all instances of RDTechTree in the ENTIRE PROGRAM (using <c>Object.FindObjectsOfType()</c>!) and calls their <c>SpawnTechTreeNodes()</c> method.
    /// </summary>
    /// <remarks>
    /// 
    /// Why does it scan the whole program for ALL instances of RDTechTree? Aren't they in an array somewhere?
    /// 
    /// Why is this in the ResearchAndDevelopment class? It's UI; shouldn't it be in the <c>KSP.UI.Screens</c> namespace, at least?
    /// 
    /// Called by:
    ///     <c>ProgressNode.AwardProgressRandomTech(string, int)</c>
    ///     <c>ResearchAndDevelopment.CheatTechnology()</c> (stock version)
    /// 
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("RefreshTechTreeUI")]
    class RefreshTechTreeUIPatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="RefreshTechTreeUIPatch"/> info about the patched method.
        /// </summary>
        static bool Prefix()
        {
            return true;
        }
    }

    /// <summary>
    /// This method is part of the Part Test contract template. When a contract has the
    /// user test a part, <see cref="AddExperimentalPart"/> is called. It marks a part as testable, which adds the
    /// right-click option "test" to the part. This is called when the contract is completed.
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// Note: Multiple contracts may add the experimental part. So, each call to <see cref="AddExperimentalPart"/>
    /// must increment a counter, and each call to <c>RemoveExperimentalPart</c> should decrement that counter. In
    /// the stock code, <c>ResearchAndDevelopment.experimentalPartsStock</c> handles incrementing/decrementing.
    /// 
    /// 
    /// Called by:
    ///     <c>Contracts.Templates.PartTest.OnFinished()</c>
    ///     <c>Contracts.Templates.PartTest.OnPartResearched(AvailablePart)</c>
    ///     
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("RemoveExperimentalPart")]
    class RemoveExperimentalPartPatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="RemoveExperimentalPartPatch"/> info about the patched method.
        /// </summary>
        /// <param name="ap">The part to remove.</param>
        /// <returns><c>false</c></returns>
        static bool Prefix(AvailablePart ap)
        {
            return true;
        }
    }

    /// <summary>
    /// This method is the parametric version of <see cref="ResearchedValidContractObjectivesPatch"/>.
    /// </summary>
    /// <remarks>
    /// 
    /// Note: When it calls the normal version, it sets <c>copy</c> to <c>false</c>.
    /// 
    /// This method probably doesn't need to be changed; change the normal version instead.
    /// 
    /// Called by:
    ///     <c>Contracts.Templates.RecoverAsset.Initialize()</c>
    ///     <c>FinePrint.Contracts.ARMContract.Generate()</c>
    ///     <c>FinePrint.Contracts.BaseContract.AreFacilitiesUnlocked()</c>
    ///     <c>FinePrint.Contracts.BaseContract.Generate()</c>
    ///     <c>FinePrint.Contracts.ExplorationContract.GetMissionMilestones()</c>
    ///     <c>FinePrint.Contracts.SatelliteContract.AreSatellitesUnlocked()</c>
    ///     <c>FinePrint.Contracts.StationContract.AreAsteroidsUnlocked()</c>
    ///     <c>FinePrint.Contracts.StationContract.AreFacilitiesUnlocked()</c>
    /// 
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("ResearchedValidContractObjectives")]
    [HarmonyPatch(new Type[] { typeof(string[])})]
    class ResearchedValidContractObjectivesParametricPatch
    {
        /// <summary>
        /// Stub to call <see cref="ResearchedValidContractObjectivesPatch"/>.
        /// See <see cref="ResearchedValidContractObjectivesParametricPatch"/> info about the patched method.
        /// </summary>
        static bool Prefix(ref bool __result, string[] objectiveTypes)
        {
            return true;
        }
    }

    /// <summary>
    /// This method checks if the parts / part types specified by this contract are researched (and unlocked?). Returns true if they are all
    /// available, false otherwise.
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// If <c>copy</c> is <c>true</c>, it makes a copy of the input array. It needs to operate on a copy because it removes objectives
    /// from the array as it looks for parts.
    /// 
    /// The stock method iterates over all the given objectives, and then iterates over every loaded part, calling <c>IsValidContractObjective(string)</c>
    /// on them. The algorithm could definitely be improved by making just one pass over loaded parts, causing fewer cache misses.
    /// 
    /// Called by:
    ///     <c>ResearchAndDevelopment.ResearchedContractObjectives(param string[])</c> (stock version)
    ///     
    /// See <see cref="ResearchedValidContractObjectivesParametricPatch"/> for more callers.
    /// 
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("ResearchedValidContractObjectives")]
    [HarmonyPatch(new Type[] {typeof(List<string>), typeof(bool)})]
    class ResearchedValidContractObjectivesPatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="ResearchedValidContractObjectivesPatch"/> info about the patched method.
        /// </summary>
        static bool Prefix(ref bool __result, List<string> objectiveTypes, bool copy)
        {
            return true;
        }
    }

    /// <summary>
    /// This method returns the localized string printed on the screen when a vessel has finished sending science.
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// Called by:
    ///     <c>ModuleOrbitalSurveyor.CompleteSurvey(ScienceData, Vessel, bool)</c>
    ///     <c>ModuleScienceLab.OnTransmissionComplete(ScienceData, Vessel, bool)</c>
    ///     <c>ResearchAndDevelopment.SubmitScienceData(float, ScienceSubject, float, ProtoVessel, bool)</c> (stock version)
    /// 
    /// </remarks>
    [HarmonyPatch(typeof(ResearchAndDevelopment))]
    [HarmonyPatch("ScienceTransmissionRewardString")]
    class ScienceTransmissionRewardStringPatch
    {
        /// <summary>
        /// Stub to call into <see cref="RnDOverhaul.PerstistantInstance"/>.
        /// See <see cref="ScienceTransmissionRewardStringPatch"/> info about the patched method.
        /// </summary>
        static bool Prefix(ref string __result, float amount, TransactionReasons reason)
        {
            return true;
        }
    }
}

