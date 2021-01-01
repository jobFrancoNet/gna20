Public Class Comuni
    Private _codice As String
    Private _Nome As String
    Private _zona As Zona
    Private _regione As Regione
    Private _cap As List(Of String)
    Private _sigla As String
    Private _codicecatastale As String
    Private _popolazione As String
    Private _prov As Province

    Public Sub New()

    End Sub

    Public Property codice As String
        Get
            Return _codice
        End Get
        Set(value As String)
            _codice = value
        End Set
    End Property

    Public Property Nome As String
        Get
            Return _Nome
        End Get
        Set(value As String)
            _Nome = value
        End Set
    End Property

    Public Property Zona As Zona
        Get
            Return _zona
        End Get
        Set(value As Zona)
            _zona = value
        End Set
    End Property

    Public Property Regione As Regione
        Get
            Return _regione
        End Get
        Set(value As Regione)
            _regione = value
        End Set
    End Property

    Public Property Cap As List(Of String)
        Get
            Return _cap
        End Get
        Set(value As List(Of String))
            _cap = value
        End Set
    End Property
    Public Property Sigla As String
        Get
            Return _sigla
        End Get
        Set(value As String)
            _sigla = value
        End Set
    End Property

    Public Property CodiceCatastale As String
        Get
            Return _codicecatastale
        End Get
        Set(value As String)
            _codicecatastale = value
        End Set
    End Property

    Public Property Popolazione As String
        Get
            Return _popolazione
        End Get
        Set(value As String)
            _popolazione = value
        End Set
    End Property

    Public Property Provincia As Province
        Get
            Return _prov
        End Get
        Set(value As Province)
            _prov = value
        End Set
    End Property
End Class
