Imports HesaEngine.SDK
Imports HesaEngine.SDK.Enums

Friend Class TwistedFate

    Public Shared Sub Initialize()
        If MyHero.Hero <> Champion.TwistedFate Then
            Return
        End If

        Try
            Spells.Initialize()
            Config.Initialize()
            Events.Initialize()
            Chat.Print("Shulepin Twisted Fate Loaded!")
        Catch ex As Exception
            Logger.Log("Error: " + ex.ToString(), ConsoleColor.Red)
        End Try
    End Sub

End Class
