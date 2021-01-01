Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Web.Configuration

' Per consentire la chiamata di questo servizio Web dallo script utilizzando ASP.NET AJAX, rimuovere il commento dalla riga seguente.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class VerificaCodiceFiscale_iscritto
    Inherits System.Web.Services.WebService
    Public strConn As String = WebConfigurationManager.ConnectionStrings("GNATEST_ConnectionString").ConnectionString
    <WebMethod()>
    Public Function VerificaCodiceFiscaleIscritto(cf As String) As DTOUserSocio
        Dim dt_socio As New DTOUserSocio
        Dim mysqlconn As New MySqlConnection(strConn)
        mysqlconn.Open()
        Dim comando As MySqlCommand
        comando = New MySqlCommand()
        comando.Connection = mysqlconn
        comando.CommandText = "select tb1.cogn,tb1.nom,tb1.cf,tb1.id_socio,tb1.e_mail,tb1.e_mail_srv,tb3.cell1 from tbl_socio1 tb1 join tbl_accesso tb2 on tb1.id_socio=tb2.Matricola join tbl_telefono1 tb3 on tb1.id_tel=tb3.id_tel where tb1.cf='" & cf & "'"
        Dim adapt As New MySqlDataAdapter()
        adapt.SelectCommand = comando

        Dim dt_socio_result As New DataSet

        adapt.Fill(dt_socio_result, "socio")

        If (dt_socio_result.Tables(0).Rows.Count > 0) Then
            dt_socio.COGNOME = dt_socio_result.Tables(0).Rows(0).Field(Of String)("cogn")
            dt_socio.NOME = dt_socio_result.Tables(0).Rows(0).Field(Of String)("nom")
            dt_socio.Matricola = dt_socio_result.Tables(0).Rows(0).Field(Of Integer)("Id_Socio")
            dt_socio.CODICEFISCALE = cf
            dt_socio.email = dt_socio_result.Tables(0).Rows(0).Field(Of String)("e_mail")
            dt_socio.email_srv = dt_socio_result.Tables(0).Rows(0).Field(Of String)("e_mail_srv")
            dt_socio.cellulare = dt_socio_result.Tables(0).Rows(0).Field(Of String)("cell1")
        Else
            dt_socio = Nothing
        End If
        Return dt_socio

    End Function

End Class