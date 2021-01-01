Imports MySql.Data.MySqlClient
Imports System.Web.Configuration
Imports System.Data
Imports GNAVBMForm.VerificaCF

Public Class newPassword
    Inherits System.Web.UI.Page
    Public dto_soc As GNAVBMForm.VerificaCF.DTOUserSocio
    Public strConn As String = WebConfigurationManager.ConnectionStrings("GNATEST_ConnectionString").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        dto_soc = Session("dto_socio")
    End Sub

    Protected Sub modificapassword_Click(sender As Object, e As ImageClickEventArgs) Handles modificapassword.Click
        Page.Validate()
        If Page.IsValid Then

            Dim pwd_da_salvare = Me.newpass.Text
            'VERIFICA PRIMA DI AGGIORNARE La PASSWORD SE IL CODICE OTP INSERITO SIA VALIDO E NON SIA SCADUTO...
            Try
                Dim mysqlconn As MySqlConnection = New MySqlConnection(strConn)
                mysqlconn.Open()
                Dim DATA_CORRENTE As Date = Date.Today

                Dim DATA_ATTUALE = Year(DATA_CORRENTE).ToString & "-" & Month(DATA_CORRENTE).ToString & "-" & Day(DATA_CORRENTE).ToString

                Dim strsql = "Select * from tbl_otprequest where NumberOtp=" & codiceotp.Text & " AND DATASCADOTP>=" & "'" & DATA_ATTUALE & "' Order By DataRichOTP DESC "

                Dim comm As New MySqlCommand(strsql, mysqlconn)


                Dim rs As DataSet

                Dim dataAdapter As MySqlDataAdapter

                rs = New DataSet()

                dataAdapter = New MySqlDataAdapter()
                dataAdapter.SelectCommand = comm

                dataAdapter.Fill(rs, "otp")



                If (rs.Tables(0).Rows.Count > 0) Then
                    Dim comando As String = "Update tbl_accesso set pwd=md5('" & pwd_da_salvare & "') where Matricola= " & dto_soc.Matricola
                    Dim mysqlcomm As New MySqlCommand(comando, mysqlconn)
                    Dim result_aggiornamento = mysqlcomm.ExecuteNonQuery()
                    Dim comando1 As String = "Update tbl_otpRequest set verificato=1 where NumberOtp=" & Me.codiceotp.Text
                    Dim mysqlcomm1 = New MySqlCommand(comando1, mysqlconn)
                    mysqlcomm1.ExecuteNonQuery()
                    If (result_aggiornamento = 1) Then
                        Me.lbl_status_cambiopassword.Visible = True

                        'sincronizzare la password cambiata in produzione guardianazionaleambientale.eu
                        mysqlconn.Close()
                        mysqlconn = New MySqlConnection(ConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString)
                        mysqlconn.Open()
                        mysqlcomm = New MySqlCommand(comando, mysqlconn)
                        result_aggiornamento = mysqlcomm.ExecuteNonQuery()
                        Dim msg As String = String.Empty
                        If (result_aggiornamento = 1) Then
                            msg = "Sincronizzata con successo la password in produzione"
                        End If
                        Me.lbl_status_cambiopassword.Text = "Password cambiata con successo!! Clicca sul link sottostante per accedere all'area riservata" & "<br />"
                        Me.lbl_status_cambiopassword.Text = Me.lbl_status_cambiopassword.Text + msg
                        Me.lbl_status_cambiopassword.Text = Me.lbl_status_cambiopassword.Text & "<br />"
                        Me.lbl_status_cambiopassword.Text = Me.lbl_status_cambiopassword.Text & "<a href='http://www.guardianazionaleambientale.eu/riservata.aspx'>Area riservata</a>"

                    End If

                Else
                    Me.lbl_status_cambiopassword.Text = "Errore cambio password OTP SCADUTO e/o OTP non valido"
                    Me.lbl_status_cambiopassword.Visible = True

                End If

            Catch ex As Exception

            End Try







        End If



    End Sub
End Class