Imports HesaEngine.SDK

Module KillSteal

    Public Sub Execute()
        Dim UseQ = ComboMenu.Get(Of MenuCheckbox)("ComboQ").Checked
        Dim UseE = ComboMenu.Get(Of MenuCheckbox)("ComboE").Checked

        For Each Enemy In ObjectManager.Heroes.Enemies.Where(Function(e) e.IsValidTarget(Q.Range))
            If UseQ And Q.IsReady() And Enemy.Health < Q.GetDamage(Enemy) Then
                Q.Cast(Enemy)
            ElseIf UseE And E.IsReady() And Enemy.Health < E.GetDamage(Enemy) Then
                E.Cast()
            End If
        Next
    End Sub

End Module
