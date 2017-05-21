Imports HesaEngine.SDK
Imports HesaEngine.SDK.Enums

Public Class Program
    Implements IScript

    Public ReadOnly Property Name As String Implements IScript.Name
        Get
            Return "Malphite"
        End Get
    End Property

    Public ReadOnly Property Version As String Implements IScript.Version
        Get
            Return "1.0.0.1"
        End Get
    End Property

    Public ReadOnly Property Author As String Implements IScript.Author
        Get
            Return "Shulepin"
        End Get
    End Property

    Public Sub OnInitialize() Implements IScript.OnInitialize
        AddHandler Game.OnGameLoaded, AddressOf OnGameLoaded
    End Sub

    Private Sub OnGameLoaded()
        If MyHero.Hero <> Champion.Malphite Then
            Return
        End If

        Malphite.Initialize()
    End Sub
End Class
