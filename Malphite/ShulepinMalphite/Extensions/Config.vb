Imports HesaEngine.SDK

Module Config

    Public MainMenu, ComboMenu, HarassMenu, KSMenu, DrawMenu As Menu

    Public Sub Initialize()
        MainMenu = Menu.AddMenu("[Shulepin] " + MyHero.ChampionName)

        MainMenu.AddSeparator("GENERAL FEATURES")

        ComboMenu = MainMenu.AddSubMenu("Combo")
        ComboMenu.Add(New MenuCheckbox("ComboQ", "Use Q", True))
        ComboMenu.Add(New MenuCheckbox("ComboW", "Use W", True))
        ComboMenu.Add(New MenuCheckbox("ComboE", "Use E", True))
        ComboMenu.Add(New MenuCheckbox("ComboR", "Use R", True))
        ComboMenu.Add(New MenuSlider("MinR", "Min. Hit Enemies Use R", 1, 5, 3))

        HarassMenu = MainMenu.AddSubMenu("Harass")
        HarassMenu.Add(New MenuCheckbox("HarassQ", "Use Q", True))
        HarassMenu.Add(New MenuCheckbox("HarassW", "Use W", True))
        HarassMenu.Add(New MenuCheckbox("HarassE", "Use E", True))
        HarassMenu.Add(New MenuSlider("HarassMana", "Min. Mana(%) For Harass", 0, 100, 50))

        KSMenu = MainMenu.AddSubMenu("Kill Steal")
        KSMenu.Add(New MenuCheckbox("KSQ", "Use Q", True))
        KSMenu.Add(New MenuCheckbox("KSE", "Use E", True))

        DrawMenu = MainMenu.AddSubMenu("Drawings")
        DrawMenu.Add(New MenuCheckbox("Draw", "Disable All Drawings"))
        DrawMenu.Add(New MenuCheckbox("DrawQ", "Draw Q", True))
        DrawMenu.Add(New MenuCheckbox("DrawE", "Draw E", True))
        DrawMenu.Add(New MenuCheckbox("DrawR", "Draw R", True))
    End Sub

End Module