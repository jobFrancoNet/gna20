Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports Newtonsoft.Json

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WebLoadComune
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

    <WebMethod()>
    Public Function LoadComuni(pattern As String) As List(Of String)
        'var Countries = ["ARGENTINA", "AUSTRALIA", "BRAZIL", "BELARUS", "BHUTAN", "CHILE"];
        Dim lista As New List(Of String)
        lista.Add("ARGENTINA")
        lista.Add("AUSTRALIA")
        lista.Add("BRAZIL")
        lista.Add("BELARUS")
        lista.Add("BHUTAN")
        lista.Add("CHILE")

        Dim l = From temp In lista
                Where temp.Contains(pattern)
                Select temp

        Return l.ToList()
    End Function

    <WebMethod()>
    Public Function LoadComuniFromJson(pattern As String) As List(Of String)
        Dim LISTACOMUNI As List(Of Comuni)
        Dim json As String

        json = System.IO.File.ReadAllText(Server.MapPath("comuni/comuni.json"))

        LISTACOMUNI = JsonConvert.DeserializeObject(Of List(Of Comuni))(json)

        Dim lista_regioni = From listreg In LISTACOMUNI
                            Select listreg.Regione.Nome Distinct.ToList()



        Dim lista_comuni = From listcom In LISTACOMUNI
                           Select New With {.comune = listcom.Nome}



        'Dim lista_province = From listprov In LISTACOMUNI
        '                     Select listprov.Provincia.Nome Distinct.ToList()

        'Dim lista_sigle = From listasigle In LISTACOMUNI
        '                  Select listasigle.Sigla Distinct.ToList()


        Dim l = From temp In lista_comuni
                Where temp.comune.Contains(pattern)
                Select temp.comune

        Return l.ToList()

    End Function



End Class