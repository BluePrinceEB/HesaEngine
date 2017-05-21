Imports HesaEngine.SDK

Module Harass

    Public Sub Execute()
        Dim UseQ = HarassMenu.Get(Of MenuCheckbox)("HarassQ").Checked
        Dim UseW = HarassMenu.Get(Of MenuCheckbox)("HarassW").Checked
        Dim UseE = HarassMenu.Get(Of MenuCheckbox)("HarassE").Checked
        Dim Mana = HarassMenu.Get(Of MenuSlider)("HarassMana").CurrentValue

        Dim Target = TargetSelector.GetTarget(Q.Range, TargetSelector.DamageType.Magical)

        If Target Is Nothing Or MyHero.ManaPercent <= Mana Then
            Return
        End If

        If UseQ And Q.IsReady() And Target.IsValidTarget(Q.Range) Then
            Q.Cast(Target)
        ElseIf UseW And W.IsReady() And Target.IsValidTarget(W.Range) Then
            W.Cast()
        ElseIf UseE And E.IsReady() And Target.IsValidTarget(E.Range) Then
            E.Cast()
        End If
    End Sub

End Module
