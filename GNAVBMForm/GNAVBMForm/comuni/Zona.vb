Public Class Zona

    Private _codice As String
    Private _nome As String

    Public Sub New()

    End Sub

    Public Property Codice As String
        Get
            Return _codice
        End Get
        Set(value As String)
            _codice = value
        End Set
    End Property

    Public Property Nome As String
        Get
            Return _nome
        End Get
        Set(value As String)
            _nome = value
        End Set
    End Property
End Class
