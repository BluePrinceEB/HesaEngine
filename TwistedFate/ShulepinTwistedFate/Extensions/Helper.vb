Imports HesaEngine.SDK
Imports HesaEngine.SDK.Enums
Imports HesaEngine.SDK.GameObjects

Module Helper

    Public MyHero As AIHeroClient = ObjectManager.Me
    Public Orbwalker As Orbwalker.OrbwalkerInstance = Core.Orbwalker

    Public Function IsStunned(unit As AIHeroClient) As Boolean
        For Each enemy In ObjectManager.Heroes.Enemies.Where(Function(e) e.HasBuffOfType(BuffType.Stun))
            Return True
        Next
        Return False
    End Function

    Public Sub CardSelector()
        If MyHero.IsRecalling() Or MyHero.InShop() Then
            Return
        End If

        Dim Y = Config.CardSelect.Get(Of MenuKeybind)("Yellow").Active
        Dim R = Config.CardSelect.Get(Of MenuKeybind)("Red").Active
        Dim B = Config.CardSelect.Get(Of MenuKeybind)("Blue").Active

        If Y Then
            ShulepinTwistedFate.CardSelector.StartSelecting(Cards.Yellow)
        End If

        If R Then
            ShulepinTwistedFate.CardSelector.StartSelecting(Cards.Red)
        End If

        If B Then
            ShulepinTwistedFate.CardSelector.StartSelecting(Cards.Blue)
        End If
    End Sub

End Module