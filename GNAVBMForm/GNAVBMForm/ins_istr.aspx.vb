Imports System.Web.Configuration
Imports MySql.Data.MySqlClient

Public Class ins_istr
    Inherits System.Web.UI.Page
    Public id_matr As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        id_matr = Request("matr")
        Response.Write("GESTIONE ISTRUZIONE PER IL SOCIO CON MATRICOLA " & id_matr)
        Dim strconnatt As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
        Dim connatt As New MySqlConnection(strconnatt)
        Dim commatt As New MySqlCommand
        commatt.Connection = connatt
        Dim attiv As String
        Dim ind_ip As String = Request.ServerVariables("REMOTE_ADDR")
        attiv = Request.Cookies("SITOGNA")("cogn") & " " & Request.Cookies("SITOGNA")("nome") & " ha effettuato l'accesso alla pagina istruzione per il socio " & Request.QueryString("matr")
        commatt.CommandText = "INSERT INTO tbl_log (attivita,indirizzo_ip) VALUES ('" & attiv.Replace("'", "''") & "','" & ind_ip & "');"
        connatt.Open()
        commatt.ExecuteNonQuery()
        connatt.Close()
    End Sub

End Class