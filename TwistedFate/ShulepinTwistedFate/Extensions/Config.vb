Imports HesaEngine.SDK

Friend Class Config

    Public Shared Main, Combo, Harass, KS, Draw, CardSelect, Misc As Menu

    Public Shared Sub Initialize()
        Main = Menu.AddMenu("[Shulepin] " + MyHero.ChampionName)

        Main.AddSeparator("GENERAL FEATURES")

        Combo = Main.AddSubMenu("Combo")
        Combo.Add(New MenuCheckbox("Q", "Use Q", True))
        Combo.Add(New MenuCheckbox("Qstun", "Use Q Only If Stunned", True))
        Combo.Add(New MenuCheckbox("W", "Use W", True))
        Combo.Add(New MenuCombo("CardMode", "Card Select Mode", {"Blue", "Red", "Yellow"}, 2))

        Harass = Main.AddSubMenu("Harass")
        Harass.Add(New MenuCheckbox("Q", "Use Q", True))
        Harass.Add(New MenuCheckbox("Qstun", "Use Q Only If Stunned"))
        Harass.Add(New MenuCheckbox("W", "Use W", True))
        Harass.Add(New MenuCombo("CardMode", "Card Select Mode", {"Blue", "Red", "Yellow"}, 2))
        Harass.Add(New MenuSlider("Mana", "Min. Mana(%) For Harass", 0, 100, 50))

        KS = Main.AddSubMenu("Kill Steal")
        KS.Add(New MenuCheckbox("Q", "Use Q", True))

        Draw = Main.AddSubMenu("Drawings")
        Draw.Add(New MenuCheckbox("Draw", "Disable All Drawings"))
        Draw.Add(New MenuCheckbox("Q", "Draw Q", True))

        Main.AddSubMenu(" ")

        Main.AddSeparator("ADVANCED FEATURES")
        CardSelect = Main.AddSubMenu("Card Selector")
        CardSelect.Add(New MenuKeybind("Yellow", "Pick Yellow Card", SharpDX.DirectInput.Key.W))
        CardSelect.Add(New MenuKeybind("Blue", "Pick Blue Card", SharpDX.DirectInput.Key.E))
        CardSelect.Add(New MenuKeybind("Red", "Pick Red Card", SharpDX.DirectInput.Key.C))

        Misc = Main.AddSubMenu("Misc")
        Misc.Add(New MenuCheckbox("AA", "Disable AA During Loop Cycle", True))
        Misc.Add(New MenuCheckbox("WR", "Auto Select Yellow Card When R", True))
    End Sub

End Class
