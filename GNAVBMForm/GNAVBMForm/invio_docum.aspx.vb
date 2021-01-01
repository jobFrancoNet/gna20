Imports System.IO
Imports System.Net.Mail
Imports System.Web.Configuration
Imports MySql.Data.MySqlClient

Public Class invio_docum
    Inherits System.Web.UI.Page
    Public strFile As String = "public/documentazione/"

    Public strconn As String = String.Empty
    Protected Function SwitchDB() As String

        If (ConfigurationManager.AppSettings("DB").Equals("TEST")) Then
            strconn = WebConfigurationManager.ConnectionStrings("GNATEST_ConnectionString").ConnectionString
        End If
        If (ConfigurationManager.AppSettings("DB").Equals("PRODUZIONE")) Then
            strconn = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
        End If

        Return strconn
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Request.Cookies("SITOGNA") Is Nothing) Then
            Response.Redirect("login.aspx")
        End If

        strconn = SwitchDB()
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (FileUpload1.PostedFile.ContentType = "application/pdf") Then
            Dim matr As String = Request("matr")
            Dim documento As String = matr & "_" & Replace(DropDownList1.SelectedValue, " ", "") & ".pdf"

            'salvo così com'è
            'FileUpload1.SaveAs("x:\inetpub\vhosts\guardianazionaleambientale.eu\httpdocs\Public\documentazione\" + myFoto)
            'nota inserire errore per bloccare eventualmente nuovo sumbit degli stessseri dati...+ inserire possibilità caricamento ricevuta quota
            FileUpload1.SaveAs(Server.MapPath("public/documentazione/" + documento))
            'Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionS itring").ConnectionString
            Dim conn As New MySqlConnection(strconn)
            Dim strSQL As String = "INSERT INTO tbl_documentazione (matricola, url_docum, tipo_docum) VALUES ('" & matr & "', '" & documento & "', '" & DropDownList1.SelectedValue & "')"
            Dim comm As New MySqlCommand(strSQL, conn)
            conn.Open()
            comm.ExecuteNonQuery()
            conn.Close()
            Dim smtpclient As SmtpClient = New SmtpClient()
            Dim msgemail As MailMessage = New MailMessage()

            Dim mittente As MailAddress = New MailAddress("noreply@guardianazionaleambientale.eu", "NOREPLY - Comunicazioni GNA")
            'Dim destinatario As MailAddress = New MailAddress("a.facchini@hotmail.it", "aldo.81@live.it")

            Dim nomefile As String = Nothing

            ' Preparo il messaggio
            msgemail.From = mittente
            'msgemail.To.Add("presidenza@guardianazionaleambientale.eu")
            'msgemail.To.Add("segreteria@guardianazionaleambientale.eu")
            msgemail.To.Add("test@guardianazionaleambientale.eu")
            Dim strBody As String
            msgemail.Subject = "GNA - Invio Documentazione"
            strBody = "Ti informo che in data " & Now() & " " & Request.Cookies("SITOGNA")("nome") & " " & Request.Cookies("SITOGNA")("cogn") & " ha inviato un documento per il socio con la matricola " & matr & ".<br /><br />"
            strBody = strBody & "Tipo documento: " & DropDownList1.SelectedValue & ".<br /><br />"
            strBody = strBody & "In allegato il documento.<br /><br />"
            strBody = strBody & "Clicca qui per visionare la modifica: <a href='http://www.guardianazionaleambientale.eu/corr_doc.aspx?matr=" & Request.QueryString("matr") & "' target='_blank'>VISIONA</a><br>"
            msgemail.Body = strBody
            msgemail.IsBodyHtml = True
            Dim allegato As Attachment = New Attachment(MapPath("public/documentazione/" & documento))
            msgemail.Attachments.Add(allegato)
            'Imposto il server
            smtpclient.Host = "smtp.guardianazionaleambientale.eu"
            smtpclient.Credentials = New System.Net.NetworkCredential("noreply@guardianazionaleambientale.eu", "tGNOrvLpGxL")

            Try
                'Invio dell'email
                smtpclient.Send(msgemail)
                Response.Write("Documento inviato all'ufficio preposto per l'accettazione<br><br>")

            Catch ex As Exception

                Response.Write("Si è verificato un errore durante l'invio<br><br>" & ex.ToString())
                smtpclient.Dispose()
                msgemail.Dispose()

            Finally

                If (nomefile <> Nothing And File.Exists(MapPath(nomefile))) Then
                    File.Delete(MapPath(nomefile))
                End If

            End Try
        Else
            Response.Write("IL FILE NON E' UN DOCUMENTO PDF")
        End If
    End Sub
End Class