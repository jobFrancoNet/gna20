Imports System.Web.Configuration
Imports MySql.Data.MySqlClient

Public Class ins_dimissioni
    Inherits System.Web.UI.Page
    Public num_rec As Int32
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Request.Cookies("SITOGNA") Is Nothing) Then
            Response.Redirect("login.aspx")
        Else
            If Request.Cookies("SITOGNA")("qual") = "Presidente" Or Request.Cookies("SITOGNA")("qual") = "Segreteria Presidente" Or Request.Cookies("SITOGNA")("qual") = "WebMaster" Then
                If Request.QueryString("matr") <> "" Then
                    txt_matr.Text = Request.QueryString("matr")
                End If
                If txt_matr.Text = "" Then
                    Panel1.Visible = True
                    Panel2.Visible = False
                Else
                    Panel1.Visible = False
                    Panel2.Visible = True
                End If
                Dim strconnatt As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
                Dim connatt As New MySqlConnection(strconnatt)
                Dim commatt As New MySqlCommand
                commatt.Connection = connatt
                Dim attiv As String
                Dim ind_ip As String = Request.ServerVariables("REMOTE_ADDR")
                attiv = Request.Cookies("SITOGNA")("cogn") & " " & Request.Cookies("SITOGNA")("nome") & " è entrato nella pagina delle dimissioni"
                commatt.CommandText = "INSERT INTO tbl_log (attivita,indirizzo_ip) VALUES ('" & attiv.Replace("'", "''") & "','" & ind_ip & "');"
                connatt.Open()
                commatt.ExecuteNonQuery()
                connatt.Close()
            Else
                Response.Write("NON HAI I PERMESSI PER ACCEDERE A QUESTA PAGINA")
                Dim strconnatt As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
                Dim connatt As New MySqlConnection(strconnatt)
                Dim commatt As New MySqlCommand
                commatt.Connection = connatt
                Dim attiv As String
                Dim ind_ip As String = Request.ServerVariables("REMOTE_ADDR")
                attiv = Request.Cookies("SITOGNA")("cogn") & " " & Request.Cookies("SITOGNA")("nome") & " ha tentato di accedere alla pagina delle dimissioni"
                commatt.CommandText = "INSERT INTO tbl_log (attivita,indirizzo_ip) VALUES ('" & attiv.Replace("'", "''") & "','" & ind_ip & "');"
                connatt.Open()
                commatt.ExecuteNonQuery()
                connatt.Close()
            End If
        End If
    End Sub

End Class