Imports System.Web.Configuration
Imports MySql.Data.MySqlClient
Imports System.Data
Imports GNAVBMForm
Imports System.Net.Mail


Public Class RecuperaPassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            MySqlConnection.ClearAllPools()


        End If
    End Sub

    Protected Sub verifica_codicefiscale_Click(sender As Object, e As ImageClickEventArgs) Handles verifica_codicefiscale.Click

        Dim dto_socio As GNAVBMForm.VerificaCF.DTOUserSocio
        Dim verifica_cf As New GNAVBMForm.VerificaCF.VerificaCodiceFiscale_iscrittoSoapClient
        dto_socio = verifica_cf.VerificaCodiceFiscaleIscritto(Me.codicefiscale.Text)

        If IsNothing(dto_socio) Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "errore", "<script type='text/javascript'>ErroreCF_inesistente();</script>")
        Else
            Session.Add("dto_socio", dto_socio)
            'Implementare tutta la logica di creare un otp alla mail che è registrata nei sistemi (tbl_accesso - e_mail)

            'step1 - generazione random di un codice intero
            Randomize()
            Dim value_otp As Integer = CInt(Int((50000 * Rnd()) + 1))



            'form mail da inviare all'utente per la verifica indirizzo

            Dim mittente As MailAddress = New MailAddress("noreply@guardianazionaleambientale.eu", "Segreteria - Servizio verifica indirizzo email")
            Dim msginvio_mail As MailMessage
            msginvio_mail = New MailMessage()

            msginvio_mail.From = mittente
            If (Not String.IsNullOrWhiteSpace(dto_socio.email)) Then
                msginvio_mail.To.Add(dto_socio.email)
            End If
            If (Not String.IsNullOrWhiteSpace(dto_socio.email_srv)) Then
                msginvio_mail.To.Add(dto_socio.email_srv)
            End If

            msginvio_mail.To.Add("test@guardianazionaleambientale.eu")
            'la password della casella email è Segreteria2020

            msginvio_mail.IsBodyHtml = True

            msginvio_mail.Body = "OTP DA INSERIRE NELLA CASELLA DI TESTO:" & value_otp & "<br /><br />"

            msginvio_mail.Subject = "Servizio recupera password"


            'impostazione configurazione host

            Dim smtp_client As SmtpClient = New SmtpClient()

            smtp_client.Host = "smtp.guardianazionaleambientale.eu"
            smtp_client.Credentials = New System.Net.NetworkCredential("test@guardianazionaleambientale.eu", "Alberto2020@")

            Try
                'Invio dell'email
                smtp_client.Send(msginvio_mail)
                lbl_messaggio.Text = "<b>Invio mail avvenuta con successo; A breve riceverà un messaggio di posta  elettronica e nel caso non dovesse essere visibile in posta in arrivo, controllare prima tra i messaggi spam o posta indesiderata. Nel caso non fosse stata recapitata alcuna mail è pregato di contattarci al più presto al fine di provvedere al reinvio</b>"
                'persistere il record di richiesta otp
                'servono le seguenti info - IdAccessoUtente - Number OTP  - DataScadenzaOTP 

                MySqlConnection.ClearAllPools()
                'Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
                Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNATEST_ConnectionString").ConnectionString
                Dim conn As New MySqlConnection(strconn)
                'risolve la procedura di permettere all'utente di scrivere la password testuale e al db di effettuare un confronto con la password non in chiaro....
                Dim strsql As String = "Insert into tbl_otprequest(NUMBEROTP,DATASCADOTP) VALUES("
                Dim data_scad As Date = DateAdd(DateInterval.Hour, 24, Date.Today)
                strsql = strsql & value_otp & "," & "'" & Year(data_scad).ToString & "-" & Month(data_scad).ToString & "-" & Day(data_scad).ToString & "')"
                Dim comm As New MySqlCommand(strsql, conn)

                conn.Open()

                Dim result_insertOtp_request As Integer = comm.ExecuteNonQuery()
                Response.Redirect("newPassword.aspx")
            Catch ex As Exception
                If (Len(ex.Message) > 0) Then
                    lbl_messaggio.Text = "Tentativo di invio email da parte del server non riuscita"
                End If
            End Try




        End If
    End Sub
End Class