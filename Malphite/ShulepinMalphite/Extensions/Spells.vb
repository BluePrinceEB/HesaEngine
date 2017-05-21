Imports HesaEngine.SDK
Imports HesaEngine.SDK.Enums

Module Spells

    Public Q, W, E, R As Spell

    Public Sub Initialize()
        Q = New Spell(SpellSlot.Q, 625)
        W = New Spell(SpellSlot.W, 250)
        E = New Spell(SpellSlot.E, 400)
        R = New Spell(SpellSlot.R, 1000)

        R.SetSkillshot(250, 270, 700, False, SkillshotType.SkillshotCircle)
    End Sub

End Module