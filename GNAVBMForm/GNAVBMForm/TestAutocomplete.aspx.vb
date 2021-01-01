Imports Newtonsoft.Json

Public Class TestAutocomplete
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub tbListOfCountries_TextChanged(sender As Object, e As EventArgs) Handles tbListOfCountries.TextChanged
        Dim LISTACOMUNI As List(Of Comuni)
        Dim json As String
        json = System.IO.File.ReadAllText(Server.MapPath("comuni/comuni.json"))

        LISTACOMUNI = JsonConvert.DeserializeObject(Of List(Of Comuni))(json)

        Dim City_selezionata As String = Me.tbListOfCountries.Text
        Dim prov = From provincia In LISTACOMUNI
                   Where provincia.Nome = City_selezionata
                   Select provincia.Sigla

        Me.provincia.Text = prov.FirstOrDefault().ToString()
    End Sub
End Class