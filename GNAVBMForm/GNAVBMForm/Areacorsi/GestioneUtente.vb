Imports MySql.Data.MySqlClient
Imports MySql.Data
Namespace AreaCorsi
    Public Class GestioneUtente
        Private _UserId As String
        Private _password As String
        Private _nome As String
        Private _cognome As String
        Private _idprofilo As Integer
        Private _matricola As Integer
        Private _IdUtente As Integer
        Private _CodiceFiscale As String


        Public Property UserId As String
            Get
                Return _UserId
            End Get
            Set(value As String)
                _UserId = value
            End Set
        End Property

        Public Property password As String
            Get
                Return _password
            End Get
            Set(value As String)
                _password = value
            End Set
        End Property

        Public Property nome As String
            Get
                Return _nome
            End Get
            Set(value As String)
                _nome = value
            End Set
        End Property

        Public Property IdProfilo As Integer
            Get
                Return _idprofilo
            End Get
            Set(value As Integer)
                _idprofilo = value
            End Set
        End Property

        Public Property Cognome As String
            Get
                Return _cognome
            End Get
            Set(value As String)
                _cognome = value
            End Set
        End Property

        Public Property Matricola As Integer
            Get
                Return _matricola
            End Get
            Set(value As Integer)
                _matricola = value
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

        Public Property CodiceFiscale As String
            Get
                Return _CodiceFiscale
            End Get
            Set(value As String)
                _CodiceFiscale = value
            End Set
        End Property

        Public Sub OttieniUserIdPasswordbyMatricola(matricola As Integer, mysqlcomm As MySqlCommand, mysqlconn As MySqlConnection, stringaconngna As String, stringaconnessione_corsi As String, mysqlcomm_gna As MySqlCommand)
            mysqlconn = New MySqlConnection()
            mysqlconn.ConnectionString = stringaconngna
            mysqlconn.Open()
            Dim recordset_gnaAccesso As MySqlDataReader
            mysqlcomm = New MySqlCommand()
            mysqlcomm.Connection = mysqlconn
            mysqlcomm.CommandText = "Select * from tbl_accesso where Matricola=" & matricola
            recordset_gnaAccesso = mysqlcomm.ExecuteReader()
            If (recordset_gnaAccesso.HasRows) Then
                While (recordset_gnaAccesso.Read)
                    Me.UserId = recordset_gnaAccesso("user")
                    Me.password = recordset_gnaAccesso("pwd")

                End While
            End If
            recordset_gnaAccesso.Close()
            mysqlconn = New MySqlConnection()
            mysqlconn.ConnectionString = stringaconnessione_corsi
            mysqlconn.Open()
            mysqlcomm.Connection = mysqlconn

            SalvaInfo_corsista_gna(mysqlcomm, mysqlconn, stringaconnessione_corsi)





        End Sub

        Public Sub SalvaInfo_corsista_nonGna(mysqlcomm As MySqlCommand, mysqlconn As MySqlConnection, stringaconnessione_corsi As String)
            mysqlconn.ConnectionString = stringaconnessione_corsi
            mysqlconn.Open()
            mysqlcomm.CommandText = "Insert into anagrafica_utenti(UserId,Password,Nome,Cognome,IdProfilo,Matricola,CodiceFiscale) values("
            mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & Me.UserId & "',"
            mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & Me.password & "',"
            mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & Me.nome & "',"
            mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & Me.Cognome & "',"
            mysqlcomm.CommandText = mysqlcomm.CommandText & 0 & ","
            mysqlcomm.CommandText = mysqlcomm.CommandText & 0 & ","
            mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & Me.CodiceFiscale & "')"

            mysqlcomm.Connection = mysqlconn



            Dim risultato_queryInsert As Integer = mysqlcomm.ExecuteNonQuery()

            If (risultato_queryInsert = 1) Then
                'ottieni IdUtente
                Dim istruzionesql As String
                istruzionesql = "Select IdUtente from Anagrafica_utenti where UserId='"
                istruzionesql = istruzionesql & Me.UserId & "' And Password='"
                istruzionesql = istruzionesql & Me.password & "' And Cognome='"
                istruzionesql = istruzionesql & Me.Cognome & "' and Nome='"
                istruzionesql = istruzionesql & Me.nome & "' and CodiceFiscale='"
                istruzionesql = istruzionesql & Me.CodiceFiscale & "'"
                mysqlcomm = New MySqlCommand(istruzionesql)
                mysqlcomm.Connection = mysqlconn

                Dim resultInfoIdUtente As MySqlDataReader = mysqlcomm.ExecuteReader()

                If (resultInfoIdUtente.HasRows) Then
                    While (resultInfoIdUtente.Read)
                        Me.IdUtente = resultInfoIdUtente("IdUtente")
                    End While
                End If
                resultInfoIdUtente.Close()
                mysqlconn.Close()
            End If

        End Sub

        Public Sub SalvaInfo_corsista_gna(mysqlcomm As MySqlCommand, mysqlconn As MySqlConnection, stringaconnessione_corsi As String)
            mysqlcomm.CommandText = "Insert into anagrafica_utenti(UserId,Password,Nome,Cognome,IdProfilo,Matricola,CodiceFiscale) values("
            mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & Me.UserId & "',"
            mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & Me.password & "',"
            mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & Me.nome & "',"
            mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & Me.Cognome & "',"
            mysqlcomm.CommandText = mysqlcomm.CommandText & 0 & ","
            mysqlcomm.CommandText = mysqlcomm.CommandText & Me.Matricola & ","
            mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & Me.CodiceFiscale & "')"

            mysqlcomm.Connection = mysqlconn

            Dim risultato_queryInsert As Integer = mysqlcomm.ExecuteNonQuery()

            If (risultato_queryInsert = 1) Then
                'ottieni IdUtente
                Dim istruzionesql As String
                istruzionesql = "Select IdUtente from Anagrafica_utenti where UserId='"
                istruzionesql = istruzionesql & Me.UserId & "' And Password='"
                istruzionesql = istruzionesql & Me.password & "' And Cognome='"
                istruzionesql = istruzionesql & Me.Cognome & "' and Nome='"
                istruzionesql = istruzionesql & Me.nome & "' and CodiceFiscale='"
                istruzionesql = istruzionesql & Me.CodiceFiscale & "'"
                mysqlcomm = New MySqlCommand(istruzionesql)
                mysqlcomm.Connection = mysqlconn

                Dim resultInfoIdUtente As MySqlDataReader = mysqlcomm.ExecuteReader()

                If (resultInfoIdUtente.HasRows) Then
                    While (resultInfoIdUtente.Read)
                        Me.IdUtente = resultInfoIdUtente("IdUtente")
                    End While
                End If
                resultInfoIdUtente.Close()
                mysqlconn.Close()
            End If

        End Sub

        Public Function UpdateIdProfiloByIdUtente(idprofilo As Integer, idutente As Integer, mysqlconn As MySqlConnection, mysqlcomm As MySqlCommand) As Integer
            'Update IdProfilo per idutente registrato in anagrafica_utenti

            mysqlcomm = New MySqlCommand()
            mysqlcomm.Connection = mysqlconn
            mysqlcomm.CommandText = "Update Anagrafica_utenti Set IdProfilo=" & idprofilo & " Where IdUtente=" & idutente

            Dim result_query_aggiornamento = mysqlcomm.ExecuteNonQuery()

            UpdateIdProfiloByIdUtente = result_query_aggiornamento
        End Function
    End Class
End Namespace