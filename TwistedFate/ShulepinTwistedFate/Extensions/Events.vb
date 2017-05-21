Imports SharpDX
Imports HesaEngine
Imports HesaEngine.SDK
Imports HesaEngine.SDK.Args
Imports HesaEngine.SDK.GameObjects
Imports ShulepinTwistedFate.Spells

Friend Class Events

    Public Shared Sub Initialize()
        AddHandler Game.OnUpdate, AddressOf OnUpdate
        AddHandler Drawing.OnDraw, AddressOf OnDraw
        AddHandler SDK.Orbwalker.BeforeAttack, AddressOf BeforeAttack
        AddHandler Obj_AI_Base.OnProcessSpellCast, AddressOf OnProcessSpellCast
    End Sub

    Private Shared Sub OnUpdate()

        Select Case Orbwalker.ActiveMode
            Case SDK.Orbwalker.OrbwalkingMode.Combo
                Combo.Execute()
                Exit Select
            Case SDK.Orbwalker.OrbwalkingMode.Harass
                Harass.Execute()
                Exit Select
        End Select

        KillSteal.Execute()
        Helper.CardSelector()

    End Sub

    Private Shared Sub BeforeAttack(args As Args.BeforeAttackEventArgs)
        If CardSelector.Status = SelectStatus.Selecting And Config.Misc.Get(Of MenuCheckbox)("AA").Checked Then
            args.Process = False
            Return
        End If
        args.Process = True
    End Sub

    Private Shared Sub OnProcessSpellCast(sender As Obj_AI_Base, args As GameObjectProcessSpellCastEventArgs)
        If Not sender.IsMe Then
            Return
        End If

        If args.SData.Name.ToLower() = "gate" And Config.Misc.Get(Of MenuCheckbox)("WR").Checked Then
            CardSelector.StartSelecting(Cards.Yellow)
        End If
    End Sub

    Private Shared Sub OnDraw()
        Dim UseQ = Config.Draw.Get(Of MenuCheckbox)("Q").Checked
        Dim Draw = Config.Draw.Get(Of MenuCheckbox)("Draw").Checked

        If Draw Or MyHero.IsDead Then
            Return
        End If

        If UseQ And Q.IsReady() Then
            Drawing.DrawCircle(MyHero.Position, Q.Range, Color.Red)
        End If
    End Sub

End Class
