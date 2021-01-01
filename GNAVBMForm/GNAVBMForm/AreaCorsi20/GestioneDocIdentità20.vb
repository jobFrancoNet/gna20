Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class GestioneDocIdentità20
    Private _tipodoc As String
    Private _NumeroDocumento As String
    Private _DataRilascio As Date
    Private _enterilascio As String
    Private _datascadenza As Date
    Private _idutente As Integer

    Public Property Tipodoc As String
        Get
            Return _tipodoc
        End Get
        Set(value As String)
            _tipodoc = value
        End Set
    End Property

    Public Property DataRilascio As Date
        Get
            Return _DataRilascio
        End Get
        Set(value As Date)
            _DataRilascio = value
        End Set
    End Property

    Public Property enterilascio As String
        Get
            Return _enterilascio
        End Get
        Set(value As String)
            _enterilascio = value
        End Set
    End Property

    Public Property Datascadenza As Date
        Get
            Return _datascadenza
        End Get
        Set(value As Date)
            _datascadenza = value
        End Set
    End Property
    Public Property IdUtente As Integer
        Get
            Return _idutente
        End Get
        Set(value As Integer)
            _idutente = value
        End Set
    End Property

    Public Property NumeroDocumento As String
        Get
            Return _NumeroDocumento
        End Get
        Set(value As String)
            _NumeroDocumento = value
        End Set
    End Property

    Public Sub SalvaDocumentoIdentità(idutente As Integer, mysqlconn As MySqlConnection, mysqlcomm As MySqlCommand)

        mysqlcomm = New MySqlCommand()
        mysqlcomm.Connection = mysqlconn

        mysqlcomm.CommandText = "Insert into Anagrafica_doc_ric(TipoDoc,NumeroDocumento,DataRilascio,EnteRilascio,DataScadenza,IdUtente) Values("

        Me.enterilascio = Me.enterilascio.Replace("'", "''")
        Me.Tipodoc = Me.Tipodoc.Replace("'", "''")

        mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & Me.Tipodoc & "',"
        mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & Me.NumeroDocumento & "',"

        Dim data_rilascio As String = Me.DataRilascio.Year.ToString() & "-" & Me.DataRilascio.Month.ToString() & "-" & Me.DataRilascio.Day.ToString()

        mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & data_rilascio & "',"

        mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & Me.enterilascio & "',"

        Dim data_scadenza As String = Me.Datascadenza.Year.ToString() & "-" & Me.Datascadenza.Month.ToString() & "-" & Me.Datascadenza.Day.ToString()

        mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & data_scadenza & "',"

        mysqlcomm.CommandText = mysqlcomm.CommandText & idutente & ")"

        mysqlconn.Open()

        Dim result_query As Integer = mysqlcomm.ExecuteNonQuery()


    End Sub


End Class
