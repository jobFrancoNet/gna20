Imports System.Web.Configuration
Imports MySql.Data.MySqlClient

Public Class ins_arm
    Inherits System.Web.UI.Page
    Public id_matr As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        id_matr = Request("matr")
        Response.Write("GESTIONE ARMI PER IL SOCIO CON MATRICOLA " & id_matr)
        Dim strconnatt As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
        Dim connatt As New MySqlConnection(strconnatt)
        Dim commatt As New MySqlCommand
        commatt.Connection = connatt
        Dim attiv As String
        Dim ind_ip As String = Request.ServerVariables("REMOTE_ADDR")
        attiv = Request.Cookies("SITOGNA")("cogn") & " " & Request.Cookies("SITOGNA")("nome") & " ha effettuato l'accesso alla pagina delle armi per il socio " & Request.QueryString("matr")
        commatt.CommandText = "INSERT INTO tbl_log (attivita,indirizzo_ip) VALUES ('" & attiv.Replace("'", "''") & "','" & ind_ip & "');"
        connatt.Open()
        commatt.ExecuteNonQuery()
        connatt.Close()
    End Sub
    Protected Sub FormView1_ItemInserted(sender As Object, e As FormViewInsertedEventArgs) Handles FormView1.ItemInserted
        Dim strconnatt As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
        Dim connatt As New MySqlConnection(strconnatt)
        Dim commatt As New MySqlCommand
        commatt.Connection = connatt
        Dim attiv As String
        Dim ind_ip As String = Request.ServerVariables("REMOTE_ADDR")
        attiv = Request.Cookies("SITOGNA")("cogn") & " " & Request.Cookies("SITOGNA")("nome") & " ha aggiunto un arma per il socio " & Request.QueryString("matr")
        commatt.CommandText = "INSERT INTO tbl_log (attivita,indirizzo_ip) VALUES ('" & attiv.Replace("'", "''") & "','" & ind_ip & "');"
        connatt.Open()
        commatt.ExecuteNonQuery()
        connatt.Close()
    End Sub

    Protected Sub GridView1_RowDeleted(sender As Object, e As GridViewDeletedEventArgs) Handles GridView1.RowDeleted
        Dim strconnatt As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
        Dim connatt As New MySqlConnection(strconnatt)
        Dim commatt As New MySqlCommand
        commatt.Connection = connatt
        Dim attiv As String
        Dim ind_ip As String = Request.ServerVariables("REMOTE_ADDR")
        attiv = Request.Cookies("SITOGNA")("cogn") & " " & Request.Cookies("SITOGNA")("nome") & " ha cancellato un arma per il socio " & Request.QueryString("matr")
        commatt.CommandText = "INSERT INTO tbl_log (attivita,indirizzo_ip) VALUES ('" & attiv.Replace("'", "''") & "','" & ind_ip & "');"
        connatt.Open()
        commatt.ExecuteNonQuery()
        connatt.Close()
    End Sub

    Protected Sub GridView1_RowUpdated(sender As Object, e As GridViewUpdatedEventArgs) Handles GridView1.RowUpdated
        Dim strconnatt As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
        Dim connatt As New MySqlConnection(strconnatt)
        Dim commatt As New MySqlCommand
        commatt.Connection = connatt
        Dim attiv As String
        Dim ind_ip As String = Request.ServerVariables("REMOTE_ADDR")
        attiv = Request.Cookies("SITOGNA")("cogn") & " " & Request.Cookies("SITOGNA")("nome") & " ha modificato un arma per il socio " & Request.QueryString("matr")
        commatt.CommandText = "INSERT INTO tbl_log (attivita,indirizzo_ip) VALUES ('" & attiv.Replace("'", "''") & "','" & ind_ip & "');"
        connatt.Open()
        commatt.ExecuteNonQuery()
        connatt.Close()
    End Sub
End Class