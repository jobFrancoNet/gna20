Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Web.Configuration


' Per consentire la chiamata di questo servizio Web dallo script utilizzando ASP.NET AJAX, rimuovere il commento dalla riga seguente.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class GetinfocognomnomSoci
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function GetInfoSoci(codiceFiscale As String) As String
        Dim idsocio As String = String.Empty
        Dim stringaconn As String = ConfigurationManager.ConnectionStrings("GNATEST_ConnectionString").ConnectionString
        Dim CONN As New MySqlConnection(stringaconn)
        CONN.Open()

        Dim comando As New MySqlCommand()
        comando.CommandText = "Select Id_Socio from tbl_socio1 where cf='" & codiceFiscale & "'"
        comando.Connection = CONN
        Dim sqldata As MySqlDataReader
        sqldata = comando.ExecuteReader()
        While (sqldata.Read)
            idsocio = sqldata("Id_Socio")
        End While
        Return idsocio
    End Function

    <WebMethod()>
    Public Function GetInfoUserByIdSocio(idsocio As Integer) As String
        Dim stringaconn As String = ConfigurationManager.ConnectionStrings("GNATEST_ConnectionString").ConnectionString
        Dim CONN As New MySqlConnection(stringaconn)
        CONN.Open()
        Dim utente As String = String.Empty
        Dim comando As New MySqlCommand()
        comando.CommandText = "Select user from tbl_accesso where matricola=" & idsocio
        comando.Connection = CONN
        Dim sqldata As MySqlDataReader
        sqldata = comando.ExecuteReader()
        While (sqldata.Read)
            utente = sqldata("user")
        End While
        Return utente
    End Function

End Class