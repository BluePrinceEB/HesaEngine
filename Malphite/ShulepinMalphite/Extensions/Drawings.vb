Imports SharpDX
Imports HesaEngine.SDK

Module Drawings

    Public Sub Initialize()
        Dim UseQ = DrawMenu.Get(Of MenuCheckbox)("DrawQ").Checked
        Dim UseE = DrawMenu.Get(Of MenuCheckbox)("DrawE").Checked
        Dim UseR = DrawMenu.Get(Of MenuCheckbox)("DrawR").Checked
        Dim Draw = DrawMenu.Get(Of MenuCheckbox)("Draw").Checked

        If Draw Or MyHero.IsDead Then
            Return
        End If

        If UseQ And Q.IsReady() Then
            Drawing.DrawCircle(MyHero.Position, Q.Range, Color.Red)
        End If

        If UseE And E.IsReady() Then
            Drawing.DrawCircle(MyHero.Position, E.Range, Color.Blue)
        End If

        If UseR And R.IsReady() Then
            Drawing.DrawCircle(MyHero.Position, R.Range, Color.White)
        End If
    End Sub

End Module
