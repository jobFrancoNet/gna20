Imports MySql.Data.MySqlClient
Public Class TestConnessione
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_connessione_Click(sender As Object, e As EventArgs) Handles btn_connessione.Click
        Dim stringaconn As String = ConfigurationManager.ConnectionStrings.Item("GNA_ConnectionString").ConnectionString
        Dim mysqlconn As MySqlConnection
        Try
            mysqlconn = New MySqlConnection(stringaconn)
            mysqlconn.Open()
            Response.Write(mysqlconn.ConnectionString.ToString())
        Catch ex As Exception
            Response.Write(ex.Message.ToString())
        End Try

    End Sub
End Class