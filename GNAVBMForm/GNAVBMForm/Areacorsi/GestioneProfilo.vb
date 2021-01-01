Imports MySql.Data
Imports MySql.Data.MySqlClient
Namespace AreaCorsi
    Public Class GestioneProfilo
        Private _indirizzo As String
        Private _città_residenza As String
        Private _cap_residenza As String
        Private _prov_residenza As String
        Private _tipoutente As String
        Private _luogo_nascita As String
        Private _Prov_nascita As String
        Private _datanascita As Date
        Private _civico As String
        Private _codicefiscale As String
        Private _IdRecapito As Integer
        Private _TitoloStudio As String
        Private _IdProfessione As Integer
        Private _IdUtente As Integer

        Public Property Indirizzo As String
            Get
                Return _indirizzo
            End Get
            Set(value As String)
                _indirizzo = value
            End Set
        End Property

        Public Property Città_residenza As String
            Get
                Return _città_residenza
            End Get
            Set(value As String)
                _città_residenza = value
            End Set
        End Property

        Public Property Cap_residenza As String
            Get
                Return _cap_residenza
            End Get
            Set(value As String)
                _cap_residenza = value
            End Set
        End Property

        Public Property Prov_residenza As String
            Get
                Return _prov_residenza
            End Get
            Set(value As String)
                _prov_residenza = value
            End Set
        End Property

        Public Property TipoUtente As String
            Get
                Return _tipoutente
            End Get
            Set(value As String)
                _tipoutente = value
            End Set
        End Property

        Public Property IdRecapito As Integer
            Get
                Return _IdRecapito
            End Get
            Set(value As Integer)
                _IdRecapito = value
            End Set
        End Property

        Public Property TitoloStudio As String
            Get
                Return _TitoloStudio
            End Get
            Set(value As String)
                _TitoloStudio = value
            End Set
        End Property

        Public Property IdProfessione As Integer
            Get
                Return _IdProfessione
            End Get
            Set(value As Integer)
                _IdProfessione = value
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

        Public Property civico As String
            Get
                Return _civico
            End Get
            Set(value As String)
                _civico = value
            End Set
        End Property

        Public Property luogonascita As String
            Get
                Return _luogo_nascita
            End Get
            Set(value As String)
                _luogo_nascita = value
            End Set
        End Property

        Public Property provnascita As String
            Get
                Return _Prov_nascita
            End Get
            Set(value As String)
                _Prov_nascita = value
            End Set
        End Property

        Public Property datanascita As Date
            Get
                Return _datanascita
            End Get
            Set(value As Date)
                _datanascita = value
            End Set
        End Property

        Public Property codicefiscale As String
            Get
                Return _codicefiscale
            End Get
            Set(value As String)
                _codicefiscale = value
            End Set
        End Property

        Public Sub SalvaProfiloUtente(mysqlconn As MySqlConnection, mysqlcomm As MySqlCommand, gestutente As GestioneUtente, stringaconn_gna As String, stringaconn_corsi As String, freg As registrazionecorso)
            'salvataggio profilo utente con campi
            'indirizzo
            'cap
            'città
            'prov
            'tipoutente
            'titolostudio
            'idprofessione

            'ottieni ID Professione di appartenenza
            mysqlconn.ConnectionString = stringaconn_corsi
            mysqlcomm.CommandText = "Select * from Anagrafica_Professioni where Descrizione='"

            'ottieni Id Professione
            If (freg.gna.Checked = True) Then
                Me.IdProfessione = Me.OttieniIdProfessione(freg.gna.Text, mysqlconn, mysqlcomm)
                mysqlconn.Close()
            End If
            If (freg.mininterno_poliziastato.Checked) Then
                mysqlcomm.CommandText = "Select * from Anagrafica_Professioni where Descrizione='"
                Me.IdProfessione = Me.OttieniIdProfessione(freg.mininterno_poliziastato.Text, mysqlconn, mysqlcomm)
                mysqlconn.Close()
            End If
            If (freg.mindifesa_carabinieri.Checked) Then
                mysqlcomm.CommandText = "Select * from Anagrafica_Professioni where Descrizione='"
                Me.IdProfessione = Me.OttieniIdProfessione(freg.mindifesa_carabinieri.Text, mysqlconn, mysqlcomm)
                mysqlconn.Close()
            End If
            If (freg.minfinanze_guardiafinanza.Checked) Then
                mysqlcomm.CommandText = "Select * from Anagrafica_Professioni where Descrizione='"
                Me.IdProfessione = Me.OttieniIdProfessione(freg.minfinanze_guardiafinanza.Text, mysqlconn, mysqlcomm)
                mysqlconn.Close()
            End If
            If (freg.PCDM_protezionecivile.Checked) Then
                mysqlcomm.CommandText = "Select * from Anagrafica_Professioni where Descrizione='"
                Me.IdProfessione = Me.OttieniIdProfessione(freg.PCDM_protezionecivile.Text, mysqlconn, mysqlcomm)
                mysqlconn.Close()
            End If
            If (freg.vigilifuoco.Checked) Then
                mysqlcomm.CommandText = "Select * from Anagrafica_Professioni where Descrizione='"
                Me.IdProfessione = Me.OttieniIdProfessione(freg.vigilifuoco.Text, mysqlconn, mysqlcomm)
                mysqlconn.Close()
            End If
            If (freg.poliziamunicipale.Checked) Then
                mysqlcomm.CommandText = "Select * from Anagrafica_Professioni where Descrizione='"
                Me.IdProfessione = Me.OttieniIdProfessione(freg.poliziamunicipale.Text, mysqlconn, mysqlcomm)
                mysqlconn.Close()
            End If
            If (freg.associazionepolstato.Checked) Then
                mysqlcomm.CommandText = "Select * from Anagrafica_Professioni where Descrizione='"
                Me.IdProfessione = Me.OttieniIdProfessione(freg.associazionepolstato.Text, mysqlconn, mysqlcomm)
                mysqlconn.Close()
            End If
            If (freg.associazioneNazCarabinieri.Checked) Then
                mysqlcomm.CommandText = "Select * from Anagrafica_Professioni where Descrizione='"
                Me.IdProfessione = Me.OttieniIdProfessione(freg.associazioneNazCarabinieri.Text, mysqlconn, mysqlcomm)
                mysqlconn.Close()
            End If
            If (freg.associazionenazfinanzieri.Checked) Then
                mysqlcomm.CommandText = "Select * from Anagrafica_Professioni where Descrizione='"
                Me.IdProfessione = Me.OttieniIdProfessione(freg.associazionenazfinanzieri.Text, mysqlconn, mysqlcomm)
                mysqlconn.Close()
            End If
            If (freg.mingiustizia_poliziaPenitenziaria.Checked) Then
                mysqlcomm.CommandText = "Select * from Anagrafica_Professioni where Descrizione='"
                Me.IdProfessione = Me.OttieniIdProfessione(freg.mingiustizia_poliziaPenitenziaria.Text, mysqlconn, mysqlcomm)
                mysqlconn.Close()
            End If

            'salvataggio dati credenziali in anagrafica_utenti


            If (Me.TipoUtente = "Corsista esterno") Then
                gestutente.SalvaInfo_corsista_nonGna(mysqlcomm, mysqlconn, stringaconn_corsi)
            End If

            Me.IdUtente = gestutente.IdUtente

            'finalizza salvataggio profilo

            'Me.SalvaProfiloUtente(mysqlconn, mysqlcomm, gestutente, stringaconn_gna, stringaconn_corsi, freg)

            mysqlconn = New MySqlConnection(stringaconn_corsi)
            mysqlcomm = New MySqlCommand()
            mysqlcomm.Connection = mysqlconn
            mysqlcomm.CommandText = "Insert into anagrafica_profili(DataNascita,LuogoNascita,ProvNascita,Indirizzo,Civico,Città_residenza,Cap_residenza,prov_residenza,TipoUtente,IdRecapito,TitoloStudio,CodiceFiscale,IdProfessione) values("

            'formatta datanascita nel formato Anno-mese-giorno

            Dim data_nascita As String

            data_nascita = Me.datanascita.Year.ToString() & "-" & Me.datanascita.Month.ToString() & "-" & Me.datanascita.Day.ToString()

            Me.luogonascita = Me.luogonascita.Replace("'", "''")

            Me.Città_residenza = Me.Città_residenza.Replace("'", "''")



            mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & data_nascita & "',"
            mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & Me.luogonascita & "',"
            mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & Me.provnascita & "',"
            mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & Me.Indirizzo & "',"
            mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & Me.civico & "',"
            mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & Me.Città_residenza & "',"
            mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & Me.Cap_residenza & "',"
            mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & Me.Prov_residenza & "',"
            mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & Me.TipoUtente & "',"
            mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & Me.IdRecapito & "',"
            mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & Me.TitoloStudio & "',"
            mysqlcomm.CommandText = mysqlcomm.CommandText & "'" & Me.codicefiscale & "',"
            mysqlcomm.CommandText = mysqlcomm.CommandText & Me.IdProfessione & ")"

            mysqlconn.Open()

            Dim resultquery As Integer = mysqlcomm.ExecuteNonQuery()

            If (resultquery = 1) Then
                mysqlcomm.Dispose()
                mysqlcomm = New MySqlCommand()
                mysqlcomm.Connection = mysqlconn
                mysqlcomm.CommandText = "Select IdProfilo from anagrafica_profili where "
                mysqlcomm.CommandText = mysqlcomm.CommandText & "DataNascita='" & data_nascita & "' And "
                mysqlcomm.CommandText = mysqlcomm.CommandText & " LuogoNascita='" & Me.luogonascita & "' And "
                mysqlcomm.CommandText = mysqlcomm.CommandText & " ProvNascita='" & Me.provnascita & "' And "
                mysqlcomm.CommandText = mysqlcomm.CommandText & " Indirizzo='" & Me.Indirizzo & "' And"
                mysqlcomm.CommandText = mysqlcomm.CommandText & " Civico='" & Me.civico & "' And"
                mysqlcomm.CommandText = mysqlcomm.CommandText & " Città_residenza='" & Me.Città_residenza & "' And"
                mysqlcomm.CommandText = mysqlcomm.CommandText & " Cap_residenza='" & Me.Cap_residenza & "' And"
                mysqlcomm.CommandText = mysqlcomm.CommandText & " prov_residenza='" & Me.Prov_residenza & "' And"
                mysqlcomm.CommandText = mysqlcomm.CommandText & " TipoUtente='" & Me.TipoUtente & "' And"
                mysqlcomm.CommandText = mysqlcomm.CommandText & " IdRecapito=" & Me.IdRecapito & " And"
                mysqlcomm.CommandText = mysqlcomm.CommandText & " TitoloStudio='" & Me.TitoloStudio & "' And"
                mysqlcomm.CommandText = mysqlcomm.CommandText & " CodiceFiscale='" & Me.codicefiscale & "' And"
                mysqlcomm.CommandText = mysqlcomm.CommandText & " IdProfessione=" & Me.IdProfessione

                Dim result_query As MySqlDataReader = mysqlcomm.ExecuteReader()
                If (result_query.HasRows) Then
                    While (result_query.Read)
                        gestutente.IdProfilo = result_query("IdProfilo")



                    End While
                    result_query.Close()
                    Dim result_aggiornamento As Integer = gestutente.UpdateIdProfiloByIdUtente(gestutente.IdProfilo, gestutente.IdUtente, mysqlconn, mysqlcomm)
                    mysqlcomm.Dispose()
                    mysqlconn.Close()
                End If
            End If
        End Sub

        Public Function OttieniIdProfessione(descrizione As String, mysqlconn As MySqlConnection, mysqlcomm As MySqlCommand)


            Dim descrizionenew As String = descrizione.Replace("'", "''")
            mysqlcomm.CommandText = mysqlcomm.CommandText & descrizionenew & "'"

            mysqlconn.Open()

            Dim result_descrprofessione As MySqlDataReader

            result_descrprofessione = mysqlcomm.ExecuteReader()

            If (result_descrprofessione.HasRows) Then
                While (result_descrprofessione.Read)
                    Me.IdProfessione = result_descrprofessione("IdProfessione")
                End While
            End If
            result_descrprofessione.Close()

            Return Me.IdProfessione
        End Function
    End Class
End Namespace