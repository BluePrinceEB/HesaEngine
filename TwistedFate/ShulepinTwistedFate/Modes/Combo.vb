Imports HesaEngine.SDK
Imports ShulepinTwistedFate.Spells

Module Combo

    Public Sub Execute()
        Dim Target = TargetSelector.GetTarget(Q.Range)

        If Target Is Nothing Then
            Return
        End If

        Dim UseQ = Config.Combo.Get(Of MenuCheckbox)("Q").Checked
        Dim UseQStun = Config.Combo.Get(Of MenuCheckbox)("Qstun").Checked
        Dim UseW = Config.Combo.Get(Of MenuCheckbox)("W").Checked
        Dim CardMode = Config.Combo.Get(Of MenuCombo)("CardMode").CurrentValueText

        If UseW And W.IsReady() And Target.IsValidTarget(MyHero.GetRealAutoAttackRange + 150) Then
            Select Case CardMode
                Case "Blue"
                    CardSelector.StartSelecting(Cards.Blue)
                    Exit Select
                Case "Red"
                    CardSelector.StartSelecting(Cards.Red)
                    Exit Select
                Case "Yellow"
                    CardSelector.StartSelecting(Cards.Yellow)
                    Exit Select
            End Select
        End If


        If Q.IsReady() And Target.IsValidTarget(Q.Range) Then
            If UseQ And UseQStun Then
                If IsStunned(Target) Then
                    Q.Cast(Target.Position)
                End If
            ElseIf UseQ Then
                Dim Prediction = Q.GetPrediction(Target, True)
                If Prediction.Hitchance >= HitChance.High Then
                    Q.Cast(Prediction.CastPosition)
                End If
            End If
        End If
    End Sub

End Module
