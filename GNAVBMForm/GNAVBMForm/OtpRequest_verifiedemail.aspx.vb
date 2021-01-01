Imports System.Data
Imports System.Web.Configuration
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Net.Mail
Public Class OtpRequest_verifiedemail
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

                            'controlla se nella tabella OTP_REQUEST CI SIA UN IDACCESSO PARI A QUELLO NEL COOKIE E CHE LA DATA DI SCADENZA OTP NON SIA TRASCORSA...
                            Dim scad_otp As Boolean = False

                            MySqlConnection.ClearAllPools()
                            'Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
                            Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNATEST_ConnectionString").ConnectionString
                            Dim conn As New MySqlConnection(strconn)

                            Dim idaccesso As Integer = Request.Cookies("SITOGNA")("idaccesso")

                            Dim DATA_CORRENTE As Date = Date.Today

                            Dim DATA_ATTUALE = Year(DATA_CORRENTE).ToString & "-" & Month(DATA_CORRENTE).ToString & "-" & Day(DATA_CORRENTE).ToString

                            Dim strsql = "Select * from tbl_otprequest where IdAccesso=" & idaccesso & " AND DATASCADOTP>=" & "'" & DATA_ATTUALE & "' Order By DataRichOTP DESC "

                            Dim comm As New MySqlCommand(strsql, conn)

                            conn.Open()

                            Dim rs As DataSet

                            Dim dataAdapter As MySqlDataAdapter

                            rs = New DataSet()

                            dataAdapter = New MySqlDataAdapter()
                            dataAdapter.SelectCommand = comm

                            dataAdapter.Fill(rs, "otp")



                            If (rs.Tables(0).Rows.Count > 0) Then

                            Else
                                scad_otp = True
                                Me.lbl_Messaggio.Text = "OTP SCADUTO"
                                Me.lbl_Messaggio.Visible = True

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
        Dim otp_valido As Boolean = False
        Dim scad_otp As Boolean = False
        MySqlConnection.ClearAllPools()
        'Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNATEST_ConnectionString").ConnectionString
        Dim conn As New MySqlConnection(strconn)

        Dim idaccesso As Integer = Request.Cookies("SITOGNA")("idaccesso")

        Dim DATA_CORRENTE As Date = Date.Today

        Dim DATA_ATTUALE = Year(DATA_CORRENTE).ToString & "-" & Month(DATA_CORRENTE).ToString & "-" & Day(DATA_CORRENTE).ToString


        Dim strsql_OTP = "Select * from tbl_otprequest where IdAccesso=" & idaccesso & " AND NumberOTP=" & Me.OTP_NUMBER.Text

        conn.Open()
        Dim comm_otp As New MySqlCommand(strsql_OTP, conn)

        Dim rsotp As DataSet
        rsotp = New DataSet

        Dim adapt As MySqlDataAdapter

        adapt = New MySqlDataAdapter()
        adapt.SelectCommand = comm_otp
        adapt.Fill(rsotp, "otp")
        otp_valido = False
        If (rsotp.Tables(0).Rows.Count > 0) Then
            otp_valido = True
            Dim strsql = "Select * from tbl_otprequest where IdAccesso=" & idaccesso & " AND DATASCADOTP>=" & "'" & DATA_ATTUALE & "' and NumberOTP=" & Me.OTP_NUMBER.Text & " Order By DataRichOTP DESC "

            Dim comm As New MySqlCommand(strsql, conn)


            Dim rs As DataSet

            Dim dataAdapter As MySqlDataAdapter

            rs = New DataSet()

            dataAdapter = New MySqlDataAdapter()
            dataAdapter.SelectCommand = comm

            dataAdapter.Fill(rs, "otp")
            scad_otp = True
            If (rs.Tables(0).Rows.Count > 0) Then

                If (rs.Tables(0).Rows(0).Field(Of UInt64)("verificato") = 0) Then
                    scad_otp = False
                    'logiche da implementare
                    'settare il campo verificato della tabella tbl_otprequest a 1
                    'settare il campo email_verificata della tabella tbl_accesso a 1
                    'inviare una mail all'indirizzo dichiarato/verificato di buon esito dell'operazione di verifica 
                    strsql = "Update tbl_otprequest set verificato=1 where IdAccesso=" & idaccesso & " AND DATASCADOTP>=" & "'" & DATA_ATTUALE & "' and NumberOTP=" & Me.OTP_NUMBER.Text
                    comm = New MySqlCommand(strsql, conn)
                    Dim result_agg_verificato As Integer = comm.ExecuteNonQuery()
                    'settare il campo email_verificata nella tabella tbl_accesso
                    strsql = "Update tbl_accesso set email_verificata=1 where Id=" & idaccesso
                    comm = New MySqlCommand(strsql, conn)
                    Dim result_agg_email_verificata As Integer = comm.ExecuteNonQuery()

                    otp_valido = True
                    Dim result_agg_indirizzoemail As Integer
                    If (otp_valido And result_agg_verificato = 1 And result_agg_email_verificata = 1) Then
                        'invio mail

                        'UPDATE INDIRIZZO ENAIL IN CASO il valore di cookie aggiornamentoemail è a true

                        If (Request.Cookies("SITOGNA")("aggiornamentoemail").Equals("True")) Then
                            'aggiornamento email nei sistemi
                            strsql = "Update tbl_accesso set e_mail='" & Request.Cookies("SITOGNA")("email_verificata") & "' where Id=" & idaccesso
                            comm = New MySqlCommand(strsql, conn)
                            result_agg_indirizzoemail = comm.ExecuteNonQuery()
                        End If


                        Dim mittente As MailAddress = New MailAddress("noreply@guardianazionaleambientale.eu", "Segreteria - Servizio verifica indirizzo email")
                        Dim msginvio_mail As MailMessage
                        msginvio_mail = New MailMessage()

                        msginvio_mail.From = mittente
                        msginvio_mail.To.Add(Request.Cookies("SITOGNA")("email"))

                        msginvio_mail.To.Add("test@guardianazionaleambientale.eu")


                        msginvio_mail.IsBodyHtml = True

                        If (Request.Cookies("SITOGNA")("aggiornamentoemail").Equals("True")) Then
                            msginvio_mail.Body = "L'indirizzo email da lei dichiarato:" & Request.Cookies("SITOGNA")("email_verificata") & "  è stato correttamente verificato ed essendo diverso da quello precedentemente dichiarato è stato aggiornato nei nostri sistemi" & "<br /><br />"
                            msginvio_mail.Body = msginvio_mail.Body & "<p style='text-align:center'><img src='http://www.guardianazionaleambientale.eu/img/image004.jpg' /></p>"
                            msginvio_mail.Body = msginvio_mail.Body & "<div style='text-align:center'>"
                            msginvio_mail.Body = msginvio_mail.Body & "<span style='color:#0000FF;font-size:24px;font-family:Arial,sans-serif'>Guardia Nazionale Ambientale</span><br />"
                            msginvio_mail.Body = msginvio_mail.Body & "<span style='color:#0000FF;font-size:13.33px;font-family:Arial,sans-serif'>Sede Nazionale: Via Scarpanto n. 64 - 00139 Roma</span><br />"
                            msginvio_mail.Body = msginvio_mail.Body & "<span style='color:#0000FF;font-size:13.33px;font-family:Arial,sans-serif'>Ufficio di Presidenza: Via Tre Venezie n. 162 - 05100 Terni</span><br />"
                            msginvio_mail.Body = msginvio_mail.Body & "<span style='color:#0000FF;font-size:13.33px;font-family:Arial,sans-serif'>Servizio automatico di certificazione contatti</span></div>"
                        Else
                            msginvio_mail.Body = "L'indirizzo email da lei dichiarato:" & Request.Cookies("SITOGNA")("email") & "  è stato correttamente verificato" & "<br /><br />"
                            msginvio_mail.Body = msginvio_mail.Body & "<p style='text-align:center'><img src='http://www.guardianazionaleambientale.eu/img/image004.jpg' /></p>"
                            msginvio_mail.Body = msginvio_mail.Body & "<div style='text-align:center'>"
                            msginvio_mail.Body = msginvio_mail.Body & "<span style='color:#0000FF;font-size:24px;font-family:Arial,sans-serif'>Guardia Nazionale Ambientale</span><br />"
                            msginvio_mail.Body = msginvio_mail.Body & "<span style='color:#0000FF;font-size:13.33px;font-family:Arial,sans-serif'>Sede Nazionale: Via Scarpanto n. 64 - 00139 Roma</span><br />"
                            msginvio_mail.Body = msginvio_mail.Body & "<span style='color:#0000FF;font-size:13.33px;font-family:Arial,sans-serif'>Ufficio di Presidenza: Via Tre Venezie n. 162 - 05100 Terni</span><br />"
                            msginvio_mail.Body = msginvio_mail.Body & "<span style='color:#0000FF;font-size:13.33px;font-family:Arial,sans-serif'>Servizio automatico di certificazione contatti</span></div>"

                        End If


                        msginvio_mail.Subject = "Servizio verifica email"


                        'impostazione configurazione host

                        Dim smtp_client As SmtpClient = New SmtpClient()

                        smtp_client.Host = "smtp.guardianazionaleambientale.eu"
                        smtp_client.Credentials = New System.Net.NetworkCredential("test@guardianazionaleambientale.eu", "Alberto2020@")

                        Try
                            'Invio dell'email
                            smtp_client.Send(msginvio_mail)
                            lbl_Messaggio.Text = "<b>OTP verificata correttamente è stata inviata una mail di conferma; nel caso non dovesse essere visibile in posta in arrivo, controllare prima tra i messaggi spam o posta indesiderata. Nel caso non fosse stata recapitata alcuna mail è pregato di contattarci al più presto a segreteria@guardianazionaleambientale.eu al fine di provvedere alla risoluzione del problema</b>"
                            lbl_Messaggio.Visible = True
                            ImageButton2.Visible = True
                            ImageButton1.Visible = False
                        Catch es As Exception
                            lbl_Messaggio.Text = es.Message.ToString()
                            lbl_Messaggio.Visible = True
                        End Try



                    End If
                Else
                    Response.Redirect("login.aspx")
                End If






            End If

        End If
        If (otp_valido = False) Then
            Me.lbl_Messaggio.Text = "<b>OTP Errato - Controllare la mail ed inserire un otp valido</b>"
            Me.lbl_Messaggio.Visible = True
        End If
        If (scad_otp = True) Then
            Me.lbl_Messaggio.Text = "<b>OTP SCADUTO - Eseguire una nuova richiesta di verifica email</b>"
            Me.lbl_Messaggio.Visible = True
        End If
    End Sub

    Protected Sub ImageButton2_Click(sender As Object, e As ImageClickEventArgs)
        Response.Redirect("login.aspx")
    End Sub
End Class