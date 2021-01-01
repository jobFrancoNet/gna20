Imports MySql.Data
Imports MySql.Data.MySqlClient
Namespace AreaCorsi
    Public Class gest_pagamento

        Private _idCorso As Integer
        Private _IdUtente As Integer
        Private _DataPagamento As Date
        Private _IdModalità As Integer
        Private _IdTransazione As String
        Private _TotaledaPagare As Double


        Public Property IdCorso As Integer
            Get
                Return _idCorso
            End Get
            Set(value As Integer)
                _idCorso = value
            End Set
        End Property

        Public Property IdUtente As Integer
            Get
                Return _IdUtente
            End Get
            Set(value As Integer)
                _IdUtente = value
            End Set
        End Property

        Public Property IdModalità As Integer
            Get
                Return _IdModalità
            End Get
            Set(value As Integer)
                _IdModalità = value
            End Set
        End Property

        Public Property IdTransazione As String
            Get
                Return _IdTransazione
            End Get
            Set(value As String)
                _IdTransazione = value
            End Set
        End Property

        Public Property TotaleDaPagare As Double
            Get
                Return _TotaledaPagare
            End Get
            Set(value As Double)
                _TotaledaPagare = value
            End Set
        End Property

        Public Sub SalvaPagamento()

        End Sub
    End Class
End Namespace