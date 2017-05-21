Imports HesaEngine.SDK
Imports ShulepinTwistedFate.Spells

Module Harass

    Public Sub Execute()
        Dim Target = TargetSelector.GetTarget(Q.Range)

        Dim Mana = Config.Harass.Get(Of MenuSlider)("Mana").CurrentValue

        If Target Is Nothing Or MyHero.ManaPercent <= Mana Then
            Return
        End If

        Dim UseQ = Config.Harass.Get(Of MenuCheckbox)("Q").Checked
        Dim UseQStun = Config.Harass.Get(Of MenuCheckbox)("Qstun").Checked
        Dim UseW = Config.Harass.Get(Of MenuCheckbox)("W").Checked
        Dim CardMode = Config.Harass.Get(Of MenuCombo)("CardMode").CurrentValueText

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
