
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Harmony;
using UnityEngine;

// TODO: Copy Harmony liscence info into GameData.
namespace ScienceOverhaulMod
{
    // Note: Had to use NuGet to reference Microsoft.NETCore.Portable.Compatibility to handle
    // error message "The type 'Object' is defined in an assembly that is not referenced. You
    // must add a reference to assembly 'mscorelib, Version=2.0.0, Culture=neutral, etc..."
    // Solution found at: https://stackoverflow.com/questions/37468552/you-must-add-a-reference-to-assembly-mscorlib-version-4-0-0
    [KSPAddon(KSPAddon.Startup.Instantly, false)]
    public class ScienceOverhaulMod : MonoBehaviour
    {
        public static void Log(String s)
        {
            print("[ScienceOverhaulMod] " + s);
        }

        public static void LogWarning(String s)
        {
            Log("Warning: " + s);
        }

        public static void LogError(String s)
        {
            Log("ERROR: " + s);
        }

        /// <summary>
        /// Called when KSP loads this assembly.
        /// </summary>
        private void Awake()
        {
            Log("Awake() started");
            UnityEngine.Debug.Log("[ScienceOverhaulMod] This is what Unity logs look like");

            Log(getMonoVersion());
            
            // We need to stay active, because KSP will be calling into our methods.
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(transform.gameObject);

            test1();
            test2();

            // Apply our patches before the game gets a chance to execute anything important.
            HarmonyInstance patcher = HarmonyInstance.Create("com.github.science.overhaul");
            patcher.PatchAll(Assembly.GetExecutingAssembly());

            test1();
            test2();
        }

        private void test1()
        {
            Log("test1");
        }
        private void test2()
        {
            Log("test2");
        }

        /// <summary>
        /// Run at some point...?
        /// </summary>
        private void Start()
        {
            Log("Start() started");
        }

        /// <summary>
        /// Called when KSP is closing.
        /// </summary>
        private void OnDestroy()
        {
            Log("OnDestroy() started");
        }

        private String getMonoVersion()
        {
            return Environment.Version.ToString();
        }
    }

    namespace RnDPatchedMethods
    {
        [HarmonyPatch(typeof(ResearchAndDevelopment))]
        [HarmonyPatch("SubmitScienceData")]
        class SubmitScienceDataPatch
        {
            static bool Prefix(float dataAmount, ScienceSubject subject, ref float __result)
            {
                UnityEngine.Debug.Log(String.Format("[ScienceOverhaulMod] SubmitScienceData({0}, {1}) intercepted.", dataAmount, subject));
                __result = 100;

                // Don't execute the original method.
                return false;
            }
        }
    }
}