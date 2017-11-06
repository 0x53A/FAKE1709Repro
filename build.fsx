#r "./packages/FAKE/tools/FakeLib.dll"

open Fake
open System

Target "Test" (fun _ ->
    let root = @"C:\Users\chrst\Desktop\Test\"
    MSBuildHelper.build (fun p -> { p with MaxCpuCount = Some (Some Environment.ProcessorCount)
                                           Properties =
                                              [
                                                "VCInstallDir", root @@  @"packages\build\VisualCppTools.Community.D14Layout\lib\native\"
                                                "Include", @"packages\build\Precast.WindowsSdk\tools\windows-kits\8.1\Include\um"

                                              ]}) @"C:\Users\chrst\Desktop\1709\Solution1\Solution1.sln")

RunTargetOrDefault "Test"
