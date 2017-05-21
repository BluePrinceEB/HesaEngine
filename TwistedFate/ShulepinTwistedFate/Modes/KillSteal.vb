Imports HesaEngine.SDK
Imports ShulepinTwistedFate.Spells

Module KillSteal

    Public Sub Execute()
        Dim UseQ = Config.KS.Get(Of MenuCheckbox)("Q").Checked

        For Each Enemy In ObjectManager.Heroes.Enemies.Where(Function(e) e.IsValidTarget(Q.Range))
            If UseQ And Q.IsReady() And Enemy.Health < Q.GetDamage(Enemy) Then
                Dim Prediction = Q.GetPrediction(Enemy)
                If Prediction.Hitchance >= HitChance.High Then
                    Q.Cast(Prediction.CastPosition)
                End If
            End If
        Next
    End Sub

End Module