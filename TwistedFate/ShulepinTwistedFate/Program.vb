Imports HesaEngine.SDK

Public Class Program
    Implements IScript

    Public ReadOnly Property Name As String Implements IScript.Name
        Get
            Return "Twisted Fate"
        End Get
    End Property

    Public ReadOnly Property Version As String Implements IScript.Version
        Get
            Return "1.0.0.0"
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
        TwistedFate.Initialize()
    End Sub
End Class