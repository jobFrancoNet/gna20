Imports System.Web.Configuration
Imports MySql.Data.MySqlClient
Imports System.Net.Mail

Public Class emailverified
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            MySqlConnection.ClearAllPools()

            If (Request.Cookies("SITOGNA") Is Nothing) Then
                Response.Redirect("login.aspx")
            Else

                If (Request.Cookies("SITOGNA") IsNot Nothing) Then
                    If Request.Cookies("SITOGNA")("cogn") IsNot Nothing Or Request.Cookies("SITOGNA")("cogn") <> "" Then
                        If Request.Cookies("SITOGNA")("EMAIL_VERIFIED").Equals("0") Then
                            Me.emaildich.Text = Request.Cookies("SITOGNA")("email")
                            Me.emaildich.Enabled = False

                            'controlla se nella tabella OTP_REQUEST CI SIA UN IDACCESSO PARI A QUELLO NEL COOKIE E CHE LA DATA DI SCADENZA OTP NON SIA TRASCORSA...
                            Dim scad_otp As Boolean = False

                            MySqlConnection.ClearAllPools()
                            'Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
                            Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNATEST_ConnectionString").ConnectionString
                            Dim conn As New MySqlConnection(strconn)

                            Dim idaccesso As Integer = Request.Cookies("SITOGNA")("idaccesso")

                            Dim DATA_CORRENTE As Date = Date.Today

                            Dim DATA_ATTUALE = Year(DATA_CORRENTE).ToString & "-" & Month(DATA_CORRENTE).ToString & "-" & Day(DATA_CORRENTE).ToString

                            Dim strsql = "Select * from tbl_otprequest where IdAccesso=" & idaccesso & " AND DATASCADOTP>=" & "'" & DATA_ATTUALE & "'" & " And verificato = 0  Order By DataRichOTP DESC "

                            Dim comm As New MySqlCommand(strsql, conn)

                            conn.Open()

                            Dim rs As DataSet

                            Dim dataAdapter As MySqlDataAdapter

                            rs = New DataSet()

                            dataAdapter = New MySqlDataAdapter()
                            dataAdapter.SelectCommand = comm

                            dataAdapter.Fill(rs, "otp")



                            If (rs.Tables(0).Rows.Count > 0) Then
                                Response.Redirect("OtpRequest_verifiedemail.aspx")
                            Else

                            End If



                        Else



                            Response.Redirect("riservata.aspx")
                        End If

                    End If
                End If
            End If
        End If
    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click

        Page.Validate()
        If Page.IsValid Then
            'LOGICA DI GESTIONE TASK SUL DB 
            ' step 1 - bisognerà inviare un codice random alla mail dichiarata.... generando nel corpo della mail un link che dovrà far arrivare l'utente su una pagina che lo informa 
            'dell'avvenuta verifica corretta della mail facendo cambiare lo stato di email_verificata da 0 a 1
            'step 1a - Bisognerà registrare la richiesta di OTP in una apposita tabella del database
            'step 2 - Prima dell'invio della mail bisogna effettuare un confronto tra la mail dichiarata e la mail confermata se non dovessero essere uguali si provvederà da subito ad
            'aggiornare la mail nell'anagrafica.

            'step0 - verifica email con quella da verificare
            Dim aggiornamento_email As Boolean = False
            If (Me.emaildich.Text <> Me.emailver.Text) Then
                aggiornamento_email = True
                Request.Cookies("SITOGNA")("aggiornamentoemail") = aggiornamento_email
                Request.Cookies("SITOGNA")("email_verificata") = Me.emailver.Text
            End If
            'step1 - generazione random di un codice intero
            Randomize()
            Dim value_otp As Integer = CInt(Int((50000 * Rnd()) + 1))

            Dim mycookie As HttpCookie = Request.Cookies("SITOGNA")

            Response.Cookies.Add(mycookie)

            'form mail da inviare all'utente per la verifica indirizzo

            Dim mittente As MailAddress = New MailAddress("noreply@guardianazionaleambientale.eu", "Segreteria - Servizio verifica indirizzo email")
            Dim msginvio_mail As MailMessage
            msginvio_mail = New MailMessage()

            msginvio_mail.From = mittente
            msginvio_mail.To.Add(Me.emailver.Text)

            msginvio_mail.To.Add("test@guardianazionaleambientale.eu")
            'la password della casella email è Segreteria2020

            msginvio_mail.IsBodyHtml = True

            msginvio_mail.Body = "OTP DA INSERIRE NELLA CASELLA DI TESTO ACCEDENDO ALL'URL SEGUENTE:" & value_otp & "<br /><br />"
            msginvio_mail.Body = msginvio_mail.Body & "http://localhost:56145/OtpRequest_verifiedemail.aspx"

            msginvio_mail.Subject = "Servizio verifica email"


            'impostazione configurazione host

            Dim smtp_client As SmtpClient = New SmtpClient()

            smtp_client.Host = "smtp.guardianazionaleambientale.eu"
            smtp_client.Credentials = New System.Net.NetworkCredential("test@guardianazionaleambientale.eu", "Alberto2020@")

            Try
                'Invio dell'email
                smtp_client.Send(msginvio_mail)
                lbl_status_inviomail.Text = "<b>Invio mail avvenuta con successo; A breve riceverà un messaggio di posta  elettronica e nel caso non dovesse essere visibile in posta in arrivo, controllare prima tra i messaggi spam o posta indesiderata. Nel caso non fosse stata recapitata alcuna mail è pregato di contattarci al più presto al fine di provvedere al reinvio</b>"

                'persistere il record di richiesta otp
                'servono le seguenti info - IdAccessoUtente - Number OTP  - DataScadenzaOTP 

                MySqlConnection.ClearAllPools()
                'Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
                Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNATEST_ConnectionString").ConnectionString
                Dim conn As New MySqlConnection(strconn)
                'risolve la procedura di permettere all'utente di scrivere la password testuale e al db di effettuare un confronto con la password non in chiaro....
                Dim strsql As String = "Insert into tbl_otprequest(IdAccesso,NUMBEROTP,DATASCADOTP) VALUES("
                Dim data_scad As Date = DateAdd(DateInterval.Hour, 24, Date.Today)
                strsql = strsql & Request.Cookies("SITOGNA")("idaccesso") & "," & value_otp & "," & "'" & Year(data_scad).ToString & "-" & Month(data_scad).ToString & "-" & Day(data_scad).ToString & "')"
                Dim comm As New MySqlCommand(strsql, conn)

                conn.Open()

                Dim result_insertOtp_request As Integer = comm.ExecuteNonQuery()

                lbl_status_inviomail.Visible = True

                Response.Redirect("OtpRequest_verifiedemail.aspx")

            Catch ex As Exception

                lbl_status_inviomail.Text = "Si è verificato un errore durante l'invio della mail oppure nel salvataggio della richiesta OTP " & " " & ex.Message.ToString()
                lbl_status_inviomail.Visible = True
                smtp_client.Dispose()
                msginvio_mail.Dispose()
            End Try

        End If
    End Sub
End Class