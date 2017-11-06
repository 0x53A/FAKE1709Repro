#r "./packages/FAKE/tools/FakeLib.dll"

open Fake
open System

Target "Test" (fun _ ->
    MSBuildHelper.build (fun p -> { p with MaxCpuCount = Some (Some Environment.ProcessorCount)
                                           Targets = [ "Print" ]
                                           Properties =
                                              [
                                                "Prop1",  @"ValueWithBackslash\"
                                                "Prop2", @"AnotherValueWithBackslash\"

                                              ]}) @"build.proj")

RunTargetOrDefault "Test"
