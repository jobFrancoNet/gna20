Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class GestionePagamentoCorso20

    Private _IdUtente As Integer
    Private _IdCorso As Integer
    Private _DataPagamento As Date
    Private _IdModalità As Integer
    Private _IdTransazione As String
    Private _totalePagato As Double

    Public Property IdUtente As Integer
        Get
            Return _IdUtente
        End Get
        Set(value As Integer)
            _IdUtente = value
        End Set
    End Property

    Public Property IdCorso As Integer
        Get
            Return _IdCorso
        End Get
        Set(value As Integer)
            _IdCorso = value
        End Set
    End Property
    Public Property DataPagamento As Date
        Get
            Return _DataPagamento
        End Get
        Set(value As Date)
            _DataPagamento = value
        End Set
    End Property

    Public Property IdModalità As Integer
        Get
            Return _IdTransazione
        End Get
        Set(value As Integer)
            _IdTransazione = value
        End Set
    End Property

    Public Property totalepagato As Double
        Get
            Return _totalePagato
        End Get
        Set(value As Double)
            _totalePagato = value
        End Set
    End Property

    Public Function SalvataggioInfoPagamento(mysqlconn As MySqlConnection, mysqlcomm As MySqlCommand) As Integer

        mysqlcomm.CommandText = "Insert into Pagamenti_Corsi(IdUtente,IdCorso,IdModalità,TotalePagato) values("
        mysqlcomm.CommandText = mysqlcomm.CommandText & Me.IdUtente & ","
        mysqlcomm.CommandText = mysqlcomm.CommandText & Me.IdCorso & ","
        mysqlcomm.CommandText = mysqlcomm.CommandText & Me.IdModalità & ","
        mysqlcomm.CommandText = mysqlcomm.CommandText & Me.totalepagato & ")"

        Dim resultquery As Integer = mysqlcomm.ExecuteNonQuery()

        mysqlconn.Close()
        mysqlcomm.Dispose()
        Return resultquery
    End Function

    Public Function OttieniIdModalitàPagamento(freg As registrazioneDroni, mysqlconn As MySqlConnection, mysqlcomm As MySqlCommand) As Integer
        Dim modalità_assegni As Boolean = freg.Modalità1.Checked
        Dim modalità_bonifico As Boolean = freg.Modalità2.Checked
        Dim modalità_ccpost As Boolean = freg.Modalità3.Checked

        mysqlcomm = New MySqlCommand()
        mysqlcomm.Connection = mysqlconn
        mysqlcomm.CommandText = "Select IdModalità from Anagrafica_modpagamenti where Descrizione='"

        If (modalità_assegni) Then
            mysqlcomm.CommandText = mysqlcomm.CommandText & freg.Modalità1.Text & "'"
        End If

        If (modalità_bonifico) Then
            mysqlcomm.CommandText = mysqlcomm.CommandText & freg.Modalità2.Text & "'"
        End If

        If (modalità_ccpost) Then
            mysqlcomm.CommandText = mysqlcomm.CommandText & freg.Modalità3.Text & "'"

        End If

        Dim id_modalità As Integer = 0



        Dim result_query As MySqlDataReader
        result_query = mysqlcomm.ExecuteReader()
        If (result_query.HasRows) Then
            While (result_query.Read)
                id_modalità = result_query("IdModalità")

            End While
            result_query.Close()
            mysqlcomm.Dispose()
        End If
        mysqlconn.Close()
        OttieniIdModalitàPagamento = id_modalità
    End Function

    Public Function OttieniPagamento30percento(IdCorso As Integer, mysqlconn As MySqlConnection, mysqlcomm As MySqlCommand) As DueDate
        Dim prezzo_corso As Double
        mysqlcomm = New MySqlCommand("Select * from Anagrafica_corsi where IdCorso=" & IdCorso & " and Attivo=1")
        mysqlcomm.Connection = mysqlconn

        Dim result_infopag As MySqlDataReader = mysqlcomm.ExecuteReader()

        If (result_infopag.HasRows) Then
            While (result_infopag.Read)
                prezzo_corso = result_infopag("Prezzo") * (30 / 100)

            End While
            result_infopag.Close()
            mysqlcomm.Dispose()
        End If
        Return prezzo_corso
    End Function
End Class
