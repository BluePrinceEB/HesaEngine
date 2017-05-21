Imports HesaEngine.SDK
Imports HesaEngine.SDK.Enums

Friend Class Spells

    Public Shared Q, W, E, R As Spell

    Public Shared Sub Initialize()
        Q = New Spell(SpellSlot.Q, 1450)
        W = New Spell(SpellSlot.W)
        E = New Spell(SpellSlot.E)
        R = New Spell(SpellSlot.R, 5500)

        Q.SetSkillshot(0, 40, 1000, False, SkillshotType.SkillshotLine)
    End Sub

End Class
