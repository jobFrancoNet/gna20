Imports System.Web.Configuration
Imports MySql.Data.MySqlClient

Public Class ins_dec
    Inherits System.Web.UI.Page
    Public id_matr As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        HF_matricola.Value = Request("matr")
        id_matr = Request("matr")
        Response.Write("GESTIONE DECRETI PER IL SOCIO CON MATRICOLA " & id_matr)
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
        Dim conn As New MySqlConnection(strconn)
        Dim comm As New MySqlCommand
        comm.Connection = conn
        Dim attiv As String
        Dim ind_ip As String = Request.ServerVariables("REMOTE_ADDR")
        attiv = Request.Cookies("SITOGNA")("cogn") & " " & Request.Cookies("SITOGNA")("nome") & " è entrato nella pagina di modifica dei decreti del socio " & id_matr
        comm.CommandText = "INSERT INTO tbl_log (attivita,indirizzo_ip) VALUES ('" & attiv.Replace("'", "''") & "','" & ind_ip & "');"
        conn.Open()
        comm.ExecuteNonQuery()
        conn.Close()
    End Sub
    Protected Sub dec1DropDownList_SelectedIndexChanged(sender As Object, e As EventArgs)
        If Page.IsPostBack Then
            Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
            Dim conn As New MySqlConnection(strconn)
            Dim comm As New MySqlCommand
            comm.Connection = conn

            Dim DD_dec As DropDownList
            DD_dec = CType(FormView1.FindControl("dec1DropDownList"), DropDownList)
            If DD_dec.SelectedValue = "Comunale" Then
                comm.CommandText = "SELECT DISTINCT comune FROM tbl_comuni ORDER BY comune"
                conn.Open()
                Dim rs As MySqlDataReader = comm.ExecuteReader
                Dim DD_ente As DropDownList
                DD_ente = CType(FormView1.FindControl("DropDownList1"), DropDownList)
                DD_ente.Items.Clear()
                DD_ente.Items.Add("")
                While rs.Read
                    DD_ente.Items.Add(rs("comune"))
                End While
            Else
                comm.CommandText = "SELECT DISTINCT provincia FROM tbl_comuni ORDER BY provincia"
                conn.Open()
                Dim rs As MySqlDataReader = comm.ExecuteReader
                Dim DD_ente As DropDownList
                DD_ente = CType(FormView1.FindControl("DropDownList1"), DropDownList)
                DD_ente.Items.Clear()
                DD_ente.Items.Add("")
                While rs.Read
                    DD_ente.Items.Add(rs("provincia"))
                End While
            End If
            conn.Close()
        End If
    End Sub

    Protected Sub FormView1_ItemInserted(sender As Object, e As FormViewInsertedEventArgs) Handles FormView1.ItemInserted
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
        Dim conn As New MySqlConnection(strconn)
        Dim comm As New MySqlCommand
        comm.Connection = conn
        Dim attiv As String
        Dim ind_ip As String = Request.ServerVariables("REMOTE_ADDR")
        attiv = Request.Cookies("SITOGNA")("cogn") & " " & Request.Cookies("SITOGNA")("nome") & " ha inserito un decreto per il socio " & Request.QueryString("matr")
        comm.CommandText = "INSERT INTO tbl_log (attivita,indirizzo_ip) VALUES ('" & attiv.Replace("'", "''") & "','" & ind_ip & "');"
        conn.Open()
        comm.ExecuteNonQuery()
        conn.Close()
    End Sub

    Protected Sub FormView1_ItemUpdated(sender As Object, e As FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated

    End Sub

    Protected Sub FormView1_PageIndexChanging(sender As Object, e As FormViewPageEventArgs) Handles FormView1.PageIndexChanging

    End Sub

    Protected Sub GridView1_RowDeleted(sender As Object, e As GridViewDeletedEventArgs) Handles GridView1.RowDeleted
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
        Dim conn As New MySqlConnection(strconn)
        Dim comm As New MySqlCommand
        comm.Connection = conn
        Dim attiv As String
        Dim ind_ip As String = Request.ServerVariables("REMOTE_ADDR")
        attiv = Request.Cookies("SITOGNA")("cogn") & " " & Request.Cookies("SITOGNA")("nome") & " ha cancellato un decreto del socio " & Request.QueryString("matr")
        comm.CommandText = "INSERT INTO tbl_log (attivita,indirizzo_ip) VALUES ('" & attiv.Replace("'", "''") & "','" & ind_ip & "');"
        conn.Open()
        comm.ExecuteNonQuery()
        conn.Close()
    End Sub

    Protected Sub GridView1_RowUpdated(sender As Object, e As GridViewUpdatedEventArgs) Handles GridView1.RowUpdated
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
        Dim conn As New MySqlConnection(strconn)
        Dim comm As New MySqlCommand
        comm.Connection = conn
        Dim attiv As String
        Dim ind_ip As String = Request.ServerVariables("REMOTE_ADDR")
        attiv = Request.Cookies("SITOGNA")("cogn") & " " & Request.Cookies("SITOGNA")("nome") & " ha modificato un decreto del socio " & Request.QueryString("matr")
        comm.CommandText = "INSERT INTO tbl_log (attivita,indirizzo_ip) VALUES ('" & attiv.Replace("'", "''") & "','" & ind_ip & "');"
        conn.Open()
        comm.ExecuteNonQuery()
        conn.Close()
    End Sub
End Class