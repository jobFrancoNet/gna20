Imports System.Web.Configuration
Imports MySql.Data.MySqlClient
Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Response.Redirect("SitoInManutenzione.aspx")

        'MySqlConnection.ClearAllPools()

        'If (Request.Cookies("SITOGNA") IsNot Nothing) Then
        '    If Request.Cookies("SITOGNA")("cogn") IsNot Nothing Or Request.Cookies("SITOGNA")("cogn") <> "" Then
        '        Response.Redirect("riservata.aspx")
        '    End If
        'End If

    End Sub

    Protected Function SwitchDB() As String
        Dim strconn = String.Empty
        If (ConfigurationManager.AppSettings("DB").Equals("TEST")) Then
            strconn = WebConfigurationManager.ConnectionStrings("GNATEST_ConnectionString").ConnectionString
        End If
        If (ConfigurationManager.AppSettings("DB").Equals("PRODUZIONE")) Then
            strconn = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
        End If

        Return strconn
    End Function

    Protected Sub Button1_Click(sender As Object, e As ImageClickEventArgs) Handles Button1.Click
        MySqlConnection.ClearAllPools()
        'Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString

        Dim strconn As String = SwitchDB()
        Dim conn As New MySqlConnection(strconn)
        Dim strsql As String = String.Empty
        'risolve la procedura di permettere all'utente di scrivere la password testuale e al db di effettuare un confronto con la password non in chiaro....
        If (ConfigurationManager.AppSettings("DB").Equals("TEST")) Then
            strsql = "Select * From tbl_accesso where BINARY user = '" & usern.Text & "' and BINARY pwd =md5(" & " '" & pwd.Text & "')"
        End If
        If (ConfigurationManager.AppSettings("DB").Equals("PRODUZIONE")) Then
            strsql = "Select * From tbl_accesso where BINARY user = '" & usern.Text & "' and BINARY pwd ='" & pwd.Text & "'"
        End If

        If Request.QueryString("db").Equals("prod") Then
            strsql = "Select * From tbl_accesso where BINARY user = '" & usern.Text & "' and BINARY pwd ='" & pwd.Text & "'"
            conn.Close()
            conn = New MySqlConnection(ConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString)

        End If

        Dim comm As New MySqlCommand(strsql, conn)

        Try
            conn.Open()

            'Dim rs As MySqlDataReader = comm.ExecuteReader()
            Dim dt As DataSet = New DataSet()
            Dim dadapt As MySqlDataAdapter = New MySqlDataAdapter()
            dadapt.SelectCommand = comm
            dadapt.Fill(dt, "socio")


            Dim mycookie As HttpCookie = New HttpCookie("SITOGNA")

            If (dt.Tables(0).Rows.Count() > 0) Then
                mycookie("nome") = dt.Tables(0).Rows(0)("nome")
                mycookie("cogn") = dt.Tables(0).Rows(0)("cognome")
                mycookie("qual") = dt.Tables(0).Rows(0)("qualifica")
                mycookie("s_user") = dt.Tables(0).Rows(0)("s_user")
                mycookie("matricola") = dt.Tables(0).Rows(0)("matricola")
                mycookie("incarico") = dt.Tables(0).Rows(0)("incarico")
                mycookie("email") = dt.Tables(0).Rows(0)("e_mail").ToString
                mycookie("settore") = dt.Tables(0).Rows(0)("settore").ToString
                mycookie("Utente") = dt.Tables(0).Rows(0)("user").ToString
                mycookie("EMAIL_VERIFIED") = dt.Tables(0).Rows(0)("email_verificata").ToString
                mycookie("pwd_exprired") = dt.Tables(0).Rows(0)("pwd_expired").ToString
                mycookie("data_scad_pwd") = dt.Tables(0).Rows(0)("data_scad_pwd").ToString
                mycookie("aggiornamentoemail") = False
                mycookie("idaccesso") = dt.Tables(0).Rows(0)("Id").ToString()

                'mycookie.Expires = DateTime.Now.AddMinutes(120)
                Response.Cookies.Add(mycookie)
                dt = Nothing
                conn.Close()
                If (Request.Cookies("SITOGNA")("EMAIL_VERIFIED").Equals("0")) Then
                    Response.Redirect("emailverified.aspx")
                Else
                    Response.Redirect("riservata.aspx")
                End If
            Else
                dt = Nothing
                conn.Close()
                ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "alert('USER o PASSWORD errati! Rispettare le lettere maiuscole')", True)
            End If
        Catch Ex As Exception

        End Try

        conn.Dispose()

    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        Response.Redirect("registrazione.aspx?matr=" & TextBox2.Text)
    End Sub

    Protected Sub recupera_password_Click(sender As Object, e As ImageClickEventArgs) Handles recupera_password.Click
        Response.Redirect("Recuperapassword.aspx")
    End Sub
End Class