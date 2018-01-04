using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// Initial mod created following this tutorial: https://wiki.kerbalspaceprogram.com/wiki/Tutorial:Creating_your_first_module
namespace ScienceOverhaulMod
{
    // Note: Had to use NuGet to reference Microsoft.NETCore.Portable.Compatibility to handle
    // error message "The type 'Object' is defined in an assembly that is not referenced. You
    // must add a reference to assembly 'mscorelib, Version=2.0.0, Culture=neutral, etc..."
    // Solution found at: https://stackoverflow.com/questions/37468552/you-must-add-a-reference-to-assembly-mscorlib-version-4-0-0
    public class ScienceOverhaulMod : PartModule
    {
        public override void OnStart(StartState state)
        {
            print("[ScienceOverhaulMod] Hello, world!");
        }
    }
}
