Imports Newtonsoft.Json
Imports System.Linq
Imports GNAVBMForm.Comuni

Public Class iscrizione
    Inherits System.Web.UI.Page

    Public LISTACOMUNI As List(Of Comuni)
    Public json As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then

            json = System.IO.File.ReadAllText(Server.MapPath("comuni/comuni.json"))

            LISTACOMUNI = JsonConvert.DeserializeObject(Of List(Of Comuni))(json)

            Dim lista_regioni = From listreg In LISTACOMUNI
                                Select listreg.Regione.Nome Distinct.ToList()



            Dim lista_comuni = From listcom In LISTACOMUNI
                               Select New With {.comune = listcom.Nome}



            Dim lista_province = From listprov In LISTACOMUNI
                                 Select listprov.Provincia.Nome Distinct.ToList()

            Dim lista_sigle = From listasigle In LISTACOMUNI
                              Select listasigle.Sigla Distinct.ToList()

            listacomuni_ctl.DataSource = lista_comuni.ToList()
            listacomuni_ctl.DataMember = "Nome"
            listacomuni_ctl.DataValueField = "comune"
            listacomuni_ctl.DataBind()


            listacity_ctl.DataSource = lista_comuni.ToList()
            listacity_ctl.DataMember = "Nome"
            listacity_ctl.DataValueField = "comune"
            listacity_ctl.DataBind()

            luogorilascio.DataSource = lista_comuni.ToList()
            luogorilascio.DataMember = "Nome"
            luogorilascio.DataValueField = "comune"
            luogorilascio.DataBind()
        End If
    End Sub

    Protected Sub btn_registra_Click(sender As Object, e As EventArgs) Handles btn_registra.Click


    End Sub

    Protected Sub listacomuni_ctl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listacomuni_ctl.SelectedIndexChanged

        json = System.IO.File.ReadAllText(Server.MapPath("comuni/comuni.json"))

        LISTACOMUNI = JsonConvert.DeserializeObject(Of List(Of Comuni))(json)

        Dim City_selezionata As String = listacomuni_ctl.SelectedValue
        Dim prov = From provincia In LISTACOMUNI
                   Where provincia.Nome = City_selezionata
                   Select provincia.Sigla

        txt_prov.Value = prov.FirstOrDefault()
    End Sub

    Protected Sub listacity_ctl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listacity_ctl.SelectedIndexChanged
        json = System.IO.File.ReadAllText(Server.MapPath("comuni/comuni.json"))

        LISTACOMUNI = JsonConvert.DeserializeObject(Of List(Of Comuni))(json)

        Dim city_comune_res As String = listacity_ctl.SelectedValue

        Dim prov = From provincia In LISTACOMUNI
                   Where provincia.Nome = city_comune_res
                   Select provincia.Sigla

        listacap_ctl.Items.Clear()


        Dim listacap = (From provincia In LISTACOMUNI
                        Where provincia.Nome = city_comune_res
                        Select provincia.Cap).ToArray()

        txt_prov_res.Value = prov.FirstOrDefault()

        Dim cap_() = listacap

        Dim valorecap As String

        Dim lunghezza As Integer = cap_(0).Count


        For conta = 0 To lunghezza - 1
            valorecap = cap_(0)(conta)
            listacap_ctl.Items.Add(valorecap)
        Next


    End Sub

    Protected Sub associazionenazfinanzieri_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub gna_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub altrienti_azienda_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub basico_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub benemerito1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub listatipodocumento1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub MultiView1_ActiveViewChanged(sender As Object, e As EventArgs)

    End Sub
End Class