namespace IsCityCanProduceUnitsTrue_BepInEx

open Mono.Cecil
open Mono.Cecil.Cil
open System
open System.Collections.Generic
open System.IO
open System.Linq

module Patcher =

    let targetDLLs: IEnumerable<string> = [ "Assembly-CSharp.dll" ]

    let Initialize () = ()

    let Finish () = ()

    let Patch (assembly: AssemblyDefinition) =
        let mainModule = assembly.MainModule

        let CityBehProduceUnit = mainModule.Types |> Seq.find (fun t -> t.Name = "CityBehProduceUnit")
        let isCityCanProduceUnits = CityBehProduceUnit.Methods |> Seq.find (fun m -> m.Name = "isCityCanProduceUnits")
        let isCityCanProduceUnitsIL = isCityCanProduceUnits.Body.GetILProcessor()

        for _ in 1..6 do
            isCityCanProduceUnitsIL.Remove(isCityCanProduceUnits.Body.Instructions.[0])

