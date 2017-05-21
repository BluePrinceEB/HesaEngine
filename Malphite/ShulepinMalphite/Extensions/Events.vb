Imports HesaEngine
Imports HesaEngine.SDK

Module Events

    Public Sub Initialize()
        AddHandler Game.OnUpdate, AddressOf OnUpdate
        AddHandler Drawing.OnDraw, AddressOf OnDraw
    End Sub

    Private Sub OnUpdate()
        Select Case Orbwalker.ActiveMode
            Case SDK.Orbwalker.OrbwalkingMode.Combo
                Combo.Execute()
                Exit Select
            Case SDK.Orbwalker.OrbwalkingMode.Harass
                Harass.Execute()
                Exit Select
        End Select

        KillSteal.Execute()
    End Sub

    Private Sub OnDraw()
        Drawings.Initialize()
    End Sub

End Module
