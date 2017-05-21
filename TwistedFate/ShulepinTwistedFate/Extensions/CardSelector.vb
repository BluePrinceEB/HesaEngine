Imports HesaEngine.SDK
Imports HesaEngine.SDK.Args
Imports HesaEngine.SDK.Enums
Imports HesaEngine.SDK.GameObjects
Imports ShulepinTwistedFate.Spells

Public Enum Cards
    Red
    Yellow
    Blue
    None
End Enum

Public Enum SelectStatus
    Ready
    Selecting
    Selected
    Cooldown
End Enum

Friend Class CardSelector   'Credits: KarmaPanda

    Public Shared SelectedCard As Cards
    Public Shared Status As SelectStatus
    Public Shared LastW As Single

    Shared Sub New()
        AddHandler Game.OnUpdate, AddressOf OnUpdate
        AddHandler Obj_AI_Base.OnProcessSpellCast, AddressOf OnProcessSpellCast
    End Sub

    Public Shared Sub StartSelecting(card As Cards)
        If MyHero.Spellbook.GetSpell(SpellSlot.W).SpellData.Name = "PickACard" And Status = SelectStatus.Ready Then
            SelectedCard = card
            If Environment.TickCount - LastW > 170 + Game.Ping / 2 Then
                W.Cast()
                LastW = Environment.TickCount
            End If
        End If
    End Sub

    Private Shared Sub OnUpdate()
        Dim Name = MyHero.Spellbook.GetSpell(SpellSlot.W).SpellData.Name
        Dim State = MyHero.Spellbook.GetSpellState(SpellSlot.W)

        If (State = SpellState.Ready AndAlso Name = "PickACard" AndAlso (Status <> SelectStatus.Selecting OrElse Environment.TickCount - LastW > 500)) OrElse ObjectManager.Player.IsDead Then
            Status = SelectStatus.Ready
        ElseIf State = SpellState.Cooldown AndAlso Name = "PickACard" Then
            SelectedCard = Cards.None
            Status = SelectStatus.Cooldown
        ElseIf State = SpellState.Surpressed AndAlso Not MyHero.IsDead Then
            Status = SelectStatus.Selected
        End If

        If SelectedCard = Cards.Blue AndAlso Name.ToLower() = "bluecardlock" AndAlso Environment.TickCount > LastW Then
            MyHero.Spellbook.CastSpell(SpellSlot.W)
        ElseIf SelectedCard = Cards.Yellow AndAlso Name.ToLower() = "goldcardlock" AndAlso Environment.TickCount > LastW Then
            MyHero.Spellbook.CastSpell(SpellSlot.W)
        ElseIf SelectedCard = Cards.Red AndAlso Name.ToLower() = "redcardlock" AndAlso Environment.TickCount > LastW Then
            MyHero.Spellbook.CastSpell(SpellSlot.W)
        End If
    End Sub

    Private Shared Sub OnProcessSpellCast(sender As Obj_AI_Base, args As GameObjectProcessSpellCastEventArgs)
        If Not sender.IsMe Then
            Return
        End If

        If args.SData.Name = "PickACard" Then
            Status = SelectStatus.Selecting
        End If

        If args.SData.Name.ToLower() = "goldcardlock" OrElse args.SData.Name.ToLower() = "bluecardlock" OrElse args.SData.Name.ToLower() = "redcardlock" Then
            Status = SelectStatus.Selected
            SelectedCard = Cards.None
        End If
    End Sub

End Class
