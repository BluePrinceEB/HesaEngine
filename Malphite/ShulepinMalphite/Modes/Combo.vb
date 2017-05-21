Imports HesaEngine.SDK

Module Combo

    Public Sub Execute()
        Dim UseQ = ComboMenu.Get(Of MenuCheckbox)("ComboQ").Checked
        Dim UseW = ComboMenu.Get(Of MenuCheckbox)("ComboW").Checked
        Dim UseE = ComboMenu.Get(Of MenuCheckbox)("ComboE").Checked
        Dim UseR = ComboMenu.Get(Of MenuCheckbox)("ComboR").Checked
        Dim MinR = ComboMenu.Get(Of MenuSlider)("MinR").CurrentValue

        Dim Target = TargetSelector.GetTarget(R.Range, TargetSelector.DamageType.Magical)

        If Target Is Nothing Then
            Return
        End If

        If UseQ And Q.IsReady() And Target.IsValidTarget(Q.Range) Then
            Q.Cast(Target)
        ElseIf UseW And W.IsReady() And Target.IsValidTarget(W.Range) Then
            W.Cast()
        ElseIf UseE And E.IsReady() And Target.IsValidTarget(E.Range) Then
            E.Cast()
        End If

        If UseR And R.IsReady() And Target.IsValidTarget(R.Range) Then
            Dim Prediction = R.GetPrediction(Target, True)
            If (Prediction.CastPosition.CountEnemiesInRange(250) >= MinR And Prediction.Hitchance >= HitChance.High) Then
                R.Cast(Prediction.CastPosition)
            End If
        End If
    End Sub

End Module
