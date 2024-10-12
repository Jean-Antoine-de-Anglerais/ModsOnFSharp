namespace FSharpTraitsMod

open UnityEngine

type public WorldBoxMod() =
    inherit MonoBehaviour()

    static let mutable initialized = false

    member this.Update() =
        if not Config.gameLoaded then
            ()
        elif not initialized then
            this.init()
            initialized <- true

    member this.init() =
        let giantTrait = AssetManager.traits.get "giant"
        giantTrait.base_stats[S.scale] <- 0.50f

        let human = AssetManager.actor_library.get "unit_human"
        human.traits.Add "giant"
        human.traits.Add "slow"

        let elf = AssetManager.actor_library.get "unit_elf"
        elf.traits.Add "giant"
        elf.traits.Add "slow"

        let orc = AssetManager.actor_library.get "unit_orc"
        orc.traits.Add "giant"
        orc.traits.Add "slow"

        let dwarf = AssetManager.actor_library.get "unit_dwarf"
        dwarf.traits.Add "giant"
        dwarf.traits.Add "slow"

