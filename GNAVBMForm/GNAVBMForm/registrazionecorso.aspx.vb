Imports Newtonsoft.Json
Imports System.Linq
Imports GNAVBMForm.Comuni
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports GNAVBMForm.AreaCorsi
Public Class registrazionecorso
    Inherits System.Web.UI.Page

    Public LISTACOMUNI As List(Of Comuni)
    Public json As String
    Public stringaconnessione_corsi As String = System.Configuration.ConfigurationManager.ConnectionStrings("GNACORSI_ConnectionString").ConnectionString
    Public stringaconnessione_gna As String = System.Configuration.ConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
    Public mysqlconn As MySqlConnection
    Public mysqlcomm As MySqlCommand
    Public mysqlcomm_gna As MySqlCommand
    Public adapt As MySqlDataAdapter
    Public dtset_corsi As DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then

            'preleva da anagrafica corsi tutti i corsi attivi...
            btn_registra.Enabled = False
            mysqlconn = New MySqlConnection(stringaconnessione_corsi)
            mysqlcomm = New MySqlCommand()
            mysqlcomm.CommandText = "Select * from Anagrafica_corsi where Attivo=1"
            mysqlcomm.Connection = mysqlconn

            mysqlconn.Open()
            adapt = New MySqlDataAdapter()
            adapt.SelectCommand = mysqlcomm

            dtset_corsi = New DataSet
            dtset_corsi.DataSetName = "Corsi"

            adapt.Fill(dtset_corsi, "ElencoCorsi")

            listacorsi.DataSource = dtset_corsi.Tables(0)

            listacorsi.DataMember = "IdCorso"

            listacorsi.DataTextField = "NomeCorso"

            listacorsi.DataValueField = "IdCorso"

            listacorsi.DataBind()


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
        Dim code As Integer
        Try
            code = Request.QueryString("code")
            listacorsi.Items(code - 1).Selected = True
            listacorsi.Enabled = False
        Catch ex As Exception
            code = 1
            listacorsi.Items(code - 1).Selected = True
            listacorsi.Enabled = False

        End Try


        If (code = 1) Then
            basico.Checked = True
            basico.Enabled = False

            critico.Enabled = False
            soluzione_completa.Enabled = False

        End If

        If (code = 2) Then
            critico.Checked = True
            critico.Enabled = False

            basico.Enabled = False
            soluzione_completa.Enabled = False
        End If

        If (code = 3) Then
            soluzione_completa.Checked = True
            soluzione_completa.Enabled = False

            basico.Enabled = False
            critico.Enabled = False
        End If
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



    Protected Sub gna_CheckedChanged(sender As Object, e As EventArgs) Handles gna.CheckedChanged

        If (gna.Checked = True) Then
            mininterno_poliziastato.Enabled = False
            mingiustizia_poliziaPenitenziaria.Enabled = False
            mindifesa_carabinieri.Enabled = False
            minfinanze_guardiafinanza.Enabled = False
            PCDM_protezionecivile.Enabled = False
            vigilifuoco.Enabled = False
            poliziamunicipale.Enabled = False
            associazionepolstato.Enabled = False
            associazioneNazCarabinieri.Enabled = False
            associazionenazfinanzieri.Enabled = False
            altrienti_azienda.Enabled = False
            txt_altro.Visible = False
        Else
            mininterno_poliziastato.Enabled = True
            mingiustizia_poliziaPenitenziaria.Enabled = True
            mindifesa_carabinieri.Enabled = True
            minfinanze_guardiafinanza.Enabled = True
            PCDM_protezionecivile.Enabled = True
            vigilifuoco.Enabled = True
            poliziamunicipale.Enabled = True
            associazionepolstato.Enabled = True
            associazioneNazCarabinieri.Enabled = True
            associazionenazfinanzieri.Enabled = True
            altrienti_azienda.Enabled = True
            txt_altro.Visible = True
        End If


        If gna.Checked = True Then
            'se fleggato attiva sezione input matricola
            sezmatr.Style.Item("Visibility") = "visible"
            inputmatr.Style.Item("Visibility") = "visible"

            sezcred.Style.Item("Visibility") = "hidden"
            inputcred_user.Style.Item("Visibility") = "hidden"
            inputcred_password.Style.Item("Visibility") = "hidden"

        Else
            sezmatr.Style.Item("Visibility") = "hidden"
            inputmatr.Style.Item("Visibility") = "hidden"

            sezcred.Style.Item("Visibility") = "visible"
            inputcred_user.Style.Item("Visibility") = "visible"
            inputcred_password.Style.Item("Visibility") = "visible"

        End If
    End Sub

    Protected Sub btn_registra_Click(sender As Object, e As ImageClickEventArgs) Handles btn_registra.Click


        'Ordine di salvataggio dati al pulsante di registrazione

        '1) Anagrafica Recapito
        '2) Anagrafica Profilo
        '3) Anagrafica utente
        '4) Anagrafica doc_ric
        '5) Pagamenti corsi

        Dim form_reg As registrazionecorso

        form_reg = Me

        'Dim compila As New CompilaModuloPdf("DRONI", Page, form_reg)

        '6) COMPILAZIONE MODULO PDF E INVIO EMAIL....

        'step 1 raccogli informazioni recapito

        Dim gestionerecapito As New GestioneRecapito()

        If (Me.txtmobilenumber.Value <> "") Then
            gestionerecapito.MobilePhone = Me.txtmobilenumber.Value
        End If

        If (Me.txtmobilnumberuff.Value <> "") Then
            gestionerecapito.mobile_ufficio = Me.txtmobilnumberuff.Value
        End If

        If (Me.txttelefonoab.Value <> "") Then
            gestionerecapito.telefonoabitazione = Me.txttelefonoab.Value
        End If

        If (Me.txttelefonouff.Value <> "") Then
            gestionerecapito.telefonoufficio = Me.txttelefonouff.Value
        End If

        If (Me.txtemail.Value <> "") Then
            gestionerecapito.email = Me.txtemail.Value
        End If

        If (Me.txtemailuff.Value <> "") Then
            gestionerecapito.emailufficio = Me.txtemailuff.Value
        End If

        'step 1a salvataggio info recapito nel db
        gestionerecapito.SalvaRecapitoUtente(stringaconnessione_corsi)

        Dim id_recapito = gestionerecapito.IdRecapito

        'inizializzazione gestione utente
        Dim Gestioneutente As New GestioneUtente

        If (gna.Checked = True) Then

            Gestioneutente.Cognome = txt_cognome.Value
            Gestioneutente.nome = txt_nome.Value
            Gestioneutente.Matricola = matricola.Value
            Gestioneutente.CodiceFiscale = txt_codicefiscale.Value
            Gestioneutente.OttieniUserIdPasswordbyMatricola(matricola.Value, mysqlcomm, mysqlconn, stringaconnessione_gna, stringaconnessione_corsi, mysqlcomm_gna)
        Else


            Gestioneutente.Cognome = txt_cognome.Value
            Gestioneutente.nome = txt_nome.Value
            Gestioneutente.UserId = user_id_corsista.Value
            Gestioneutente.password = pwd_corsista.Value
            Gestioneutente.CodiceFiscale = txt_codicefiscale.Value
        End If



        'step2 Gestione profilo...
        'DataNascita
        'LuogoNascita
        'ProvNascita
        'Indirizzo
        'Civico
        'Città_residenza
        'Cap_residenza
        'Prov_residenza
        'TipoUtente
        'IdRecapito
        'TitoloStudio

        Dim gest_profile As New GestioneProfilo()

        If (gna.Checked = True) Then
            gest_profile.TipoUtente = "Socio Gna"
        Else
            gest_profile.TipoUtente = "Corsista esterno"
        End If


        'raccolta dati dal form
        gest_profile.datanascita = Me.txt_datanascita.Value
        gest_profile.luogonascita = Me.listacomuni_ctl.SelectedValue
        gest_profile.provnascita = Me.txt_prov.Value
        gest_profile.Indirizzo = Me.txt_indirizzo.Value
        gest_profile.civico = Me.txt_civico.Value
        gest_profile.Città_residenza = Me.listacity_ctl.SelectedValue
        gest_profile.Cap_residenza = Me.listacap_ctl.SelectedValue
        gest_profile.Prov_residenza = Me.txt_prov_res.Value
        gest_profile.codicefiscale = Me.txt_codicefiscale.Value
        gest_profile.TitoloStudio = Me.txttitolostudio.Value

        mysqlconn = New MySqlConnection()

        mysqlcomm = New MySqlCommand()
        mysqlcomm.Connection = mysqlconn

        gest_profile.IdRecapito = id_recapito
        Gestioneutente.CodiceFiscale = gest_profile.codicefiscale
        gest_profile.SalvaProfiloUtente(mysqlconn, mysqlcomm, Gestioneutente, stringaconnessione_gna, stringaconnessione_corsi, form_reg)

        Dim gestdoc_identità As New GestioneDocIdentità()

        gestdoc_identità.IdUtente = Gestioneutente.IdUtente
        gestdoc_identità.Tipodoc = form_reg.listatipodocumento.SelectedValue
        gestdoc_identità.enterilascio = form_reg.enterilascio.SelectedValue
        gestdoc_identità.DataRilascio = form_reg.data_rilascio.Value
        gestdoc_identità.Datascadenza = form_reg.data_scadenza.Value
        gestdoc_identità.NumeroDocumento = form_reg.txt_numerodoc.Value

        mysqlconn = New MySqlConnection(stringaconnessione_corsi)

        gestdoc_identità.SalvaDocumentoIdentità(gestdoc_identità.IdUtente, mysqlconn, mysqlcomm)

        Dim gestpag As New GestionePagamentoCorso()

        gestpag.IdUtente = Gestioneutente.IdUtente

        If (basico.Checked) Then
            gestpag.IdCorso = 1
        End If
        If (critico.Checked) Then
            gestpag.IdCorso = 2
        End If
        If (soluzione_completa.Checked) Then
            gestpag.IdCorso = 3
        End If

        gestpag.IdModalità = gestpag.OttieniIdModalitàPagamento(form_reg, mysqlconn, mysqlcomm)


        mysqlconn = New MySqlConnection(stringaconnessione_corsi)
        mysqlconn.Open()
        mysqlcomm = New MySqlCommand()
        mysqlcomm.Connection = mysqlconn




        Dim prezzocorso As Double = gestpag.OttieniPagamento30percento(gestpag.IdCorso, mysqlconn, mysqlcomm)

        gestpag.totalepagato = prezzocorso

        Dim resultquery As Integer = gestpag.SalvataggioInfoPagamento(mysqlconn, mysqlcomm)


        Dim compila As New CompilaModuloPdf("DRONI", Page, form_reg)



    End Sub

    Private Sub mininterno_poliziastato_CheckedChanged(sender As Object, e As EventArgs) Handles mininterno_poliziastato.CheckedChanged

        If (mininterno_poliziastato.Checked = True) Then
            gna.Enabled = False
            mingiustizia_poliziaPenitenziaria.Enabled = False
            mindifesa_carabinieri.Enabled = False
            minfinanze_guardiafinanza.Enabled = False
            PCDM_protezionecivile.Enabled = False
            vigilifuoco.Enabled = False
            poliziamunicipale.Enabled = False
            associazionepolstato.Enabled = False
            associazioneNazCarabinieri.Enabled = False
            associazionenazfinanzieri.Enabled = False
            altrienti_azienda.Enabled = False
            txt_altro.Visible = False
        Else
            gna.Enabled = True
            mingiustizia_poliziaPenitenziaria.Enabled = True
            mindifesa_carabinieri.Enabled = True
            minfinanze_guardiafinanza.Enabled = True
            PCDM_protezionecivile.Enabled = True
            vigilifuoco.Enabled = True
            poliziamunicipale.Enabled = True
            associazionepolstato.Enabled = True
            associazioneNazCarabinieri.Enabled = True
            associazionenazfinanzieri.Enabled = True
            altrienti_azienda.Enabled = True
            txt_altro.Visible = True
        End If
    End Sub

    Private Sub mingiustizia_poliziaPenitenziaria_CheckedChanged(sender As Object, e As EventArgs) Handles mingiustizia_poliziaPenitenziaria.CheckedChanged
        If (mingiustizia_poliziaPenitenziaria.Checked = True) Then
            gna.Enabled = False
            mininterno_poliziastato.Enabled = False
            mindifesa_carabinieri.Enabled = False
            minfinanze_guardiafinanza.Enabled = False
            PCDM_protezionecivile.Enabled = False
            vigilifuoco.Enabled = False
            poliziamunicipale.Enabled = False
            associazionepolstato.Enabled = False
            associazioneNazCarabinieri.Enabled = False
            associazionenazfinanzieri.Enabled = False
            altrienti_azienda.Enabled = False
            txt_altro.Visible = False
        Else
            gna.Enabled = True
            mininterno_poliziastato.Enabled = True
            mindifesa_carabinieri.Enabled = True
            minfinanze_guardiafinanza.Enabled = True
            PCDM_protezionecivile.Enabled = True
            vigilifuoco.Enabled = True
            poliziamunicipale.Enabled = True
            associazionepolstato.Enabled = True
            associazioneNazCarabinieri.Enabled = True
            associazionenazfinanzieri.Enabled = True
            altrienti_azienda.Enabled = True
            txt_altro.Visible = True
        End If
    End Sub

    Private Sub mindifesa_carabinieri_CheckedChanged(sender As Object, e As EventArgs) Handles mindifesa_carabinieri.CheckedChanged
        If (mindifesa_carabinieri.Checked = True) Then
            gna.Enabled = False
            mininterno_poliziastato.Enabled = False
            mingiustizia_poliziaPenitenziaria.Enabled = False
            minfinanze_guardiafinanza.Enabled = False
            PCDM_protezionecivile.Enabled = False
            vigilifuoco.Enabled = False
            poliziamunicipale.Enabled = False
            associazionepolstato.Enabled = False
            associazioneNazCarabinieri.Enabled = False
            associazionenazfinanzieri.Enabled = False
            altrienti_azienda.Enabled = False
            txt_altro.Visible = False
        Else
            gna.Enabled = True
            mininterno_poliziastato.Enabled = True
            mingiustizia_poliziaPenitenziaria.Enabled = True
            minfinanze_guardiafinanza.Enabled = True
            PCDM_protezionecivile.Enabled = True
            vigilifuoco.Enabled = True
            poliziamunicipale.Enabled = True
            associazionepolstato.Enabled = True
            associazioneNazCarabinieri.Enabled = True
            associazionenazfinanzieri.Enabled = True
            altrienti_azienda.Enabled = True
            txt_altro.Visible = True
        End If
    End Sub

    Private Sub minfinanze_guardiafinanza_CheckedChanged(sender As Object, e As EventArgs) Handles minfinanze_guardiafinanza.CheckedChanged
        If (minfinanze_guardiafinanza.Checked = True) Then
            gna.Enabled = False
            mininterno_poliziastato.Enabled = False
            mingiustizia_poliziaPenitenziaria.Enabled = False
            mindifesa_carabinieri.Enabled = False
            PCDM_protezionecivile.Enabled = False
            vigilifuoco.Enabled = False
            poliziamunicipale.Enabled = False
            associazionepolstato.Enabled = False
            associazioneNazCarabinieri.Enabled = False
            associazionenazfinanzieri.Enabled = False
            altrienti_azienda.Enabled = False
            txt_altro.Visible = False
        Else
            gna.Enabled = True
            mininterno_poliziastato.Enabled = True
            mingiustizia_poliziaPenitenziaria.Enabled = True
            mindifesa_carabinieri.Enabled = True
            PCDM_protezionecivile.Enabled = True
            vigilifuoco.Enabled = True
            poliziamunicipale.Enabled = True
            associazionepolstato.Enabled = True
            associazioneNazCarabinieri.Enabled = True
            associazionenazfinanzieri.Enabled = True
            altrienti_azienda.Enabled = True
            txt_altro.Visible = True
        End If
    End Sub

    Private Sub PCDM_protezionecivile_CheckedChanged(sender As Object, e As EventArgs) Handles PCDM_protezionecivile.CheckedChanged
        If (PCDM_protezionecivile.Checked = True) Then
            gna.Enabled = False
            mininterno_poliziastato.Enabled = False
            mingiustizia_poliziaPenitenziaria.Enabled = False
            mindifesa_carabinieri.Enabled = False
            minfinanze_guardiafinanza.Enabled = False
            vigilifuoco.Enabled = False
            poliziamunicipale.Enabled = False
            associazionepolstato.Enabled = False
            associazioneNazCarabinieri.Enabled = False
            associazionenazfinanzieri.Enabled = False
            altrienti_azienda.Enabled = False
            txt_altro.Visible = False
        Else
            gna.Enabled = True
            mininterno_poliziastato.Enabled = True
            mingiustizia_poliziaPenitenziaria.Enabled = True
            mindifesa_carabinieri.Enabled = True
            minfinanze_guardiafinanza.Enabled = True
            vigilifuoco.Enabled = True
            poliziamunicipale.Enabled = True
            associazionepolstato.Enabled = True
            associazioneNazCarabinieri.Enabled = True
            associazionenazfinanzieri.Enabled = True
            altrienti_azienda.Enabled = True
            txt_altro.Visible = True
        End If
    End Sub

    Private Sub vigilifuoco_CheckedChanged(sender As Object, e As EventArgs) Handles vigilifuoco.CheckedChanged
        If (vigilifuoco.Checked = True) Then
            gna.Enabled = False
            mininterno_poliziastato.Enabled = False
            mingiustizia_poliziaPenitenziaria.Enabled = False
            mindifesa_carabinieri.Enabled = False
            minfinanze_guardiafinanza.Enabled = False
            PCDM_protezionecivile.Enabled = False
            poliziamunicipale.Enabled = False
            associazionepolstato.Enabled = False
            associazioneNazCarabinieri.Enabled = False
            associazionenazfinanzieri.Enabled = False
            altrienti_azienda.Enabled = False
            txt_altro.Visible = False
        Else
            gna.Enabled = True
            mininterno_poliziastato.Enabled = True
            mingiustizia_poliziaPenitenziaria.Enabled = True
            mindifesa_carabinieri.Enabled = True
            minfinanze_guardiafinanza.Enabled = True
            PCDM_protezionecivile.Enabled = True
            poliziamunicipale.Enabled = True
            associazionepolstato.Enabled = True
            associazioneNazCarabinieri.Enabled = True
            associazionenazfinanzieri.Enabled = True
            altrienti_azienda.Enabled = True
            txt_altro.Visible = True
        End If
    End Sub

    Private Sub poliziamunicipale_CheckedChanged(sender As Object, e As EventArgs) Handles poliziamunicipale.CheckedChanged
        If (poliziamunicipale.Checked = True) Then
            gna.Enabled = False
            mininterno_poliziastato.Enabled = False
            mingiustizia_poliziaPenitenziaria.Enabled = False
            mindifesa_carabinieri.Enabled = False
            minfinanze_guardiafinanza.Enabled = False
            PCDM_protezionecivile.Enabled = False
            vigilifuoco.Enabled = False
            associazionepolstato.Enabled = False
            associazioneNazCarabinieri.Enabled = False
            associazionenazfinanzieri.Enabled = False
            altrienti_azienda.Enabled = False
            txt_altro.Visible = False
        Else
            gna.Enabled = True
            mininterno_poliziastato.Enabled = True
            mingiustizia_poliziaPenitenziaria.Enabled = True
            mindifesa_carabinieri.Enabled = True
            minfinanze_guardiafinanza.Enabled = True
            PCDM_protezionecivile.Enabled = True
            vigilifuoco.Enabled = True
            associazionepolstato.Enabled = True
            associazioneNazCarabinieri.Enabled = True
            associazionenazfinanzieri.Enabled = True
            altrienti_azienda.Enabled = True
            txt_altro.Visible = True
        End If
    End Sub

    Private Sub associazionepolstato_CheckedChanged(sender As Object, e As EventArgs) Handles associazionepolstato.CheckedChanged
        If (associazionepolstato.Checked = True) Then
            gna.Enabled = False
            mininterno_poliziastato.Enabled = False
            mingiustizia_poliziaPenitenziaria.Enabled = False
            mindifesa_carabinieri.Enabled = False
            minfinanze_guardiafinanza.Enabled = False
            PCDM_protezionecivile.Enabled = False
            vigilifuoco.Enabled = False
            poliziamunicipale.Enabled = False
            associazioneNazCarabinieri.Enabled = False
            associazionenazfinanzieri.Enabled = False
            altrienti_azienda.Enabled = False
            txt_altro.Visible = False
        Else
            gna.Enabled = True
            mininterno_poliziastato.Enabled = True
            mingiustizia_poliziaPenitenziaria.Enabled = True
            mindifesa_carabinieri.Enabled = True
            minfinanze_guardiafinanza.Enabled = True
            PCDM_protezionecivile.Enabled = True
            vigilifuoco.Enabled = True
            poliziamunicipale.Enabled = True
            associazioneNazCarabinieri.Enabled = True
            associazionenazfinanzieri.Enabled = True
            altrienti_azienda.Enabled = True
            txt_altro.Visible = True
        End If
    End Sub

    Private Sub associazioneNazCarabinieri_CheckedChanged(sender As Object, e As EventArgs) Handles associazioneNazCarabinieri.CheckedChanged
        If (associazioneNazCarabinieri.Checked = True) Then
            gna.Enabled = False
            mininterno_poliziastato.Enabled = False
            mingiustizia_poliziaPenitenziaria.Enabled = False
            mindifesa_carabinieri.Enabled = False
            minfinanze_guardiafinanza.Enabled = False
            PCDM_protezionecivile.Enabled = False
            vigilifuoco.Enabled = False
            poliziamunicipale.Enabled = False
            associazionepolstato.Enabled = False
            associazionenazfinanzieri.Enabled = False
            altrienti_azienda.Enabled = False
            txt_altro.Visible = False
        Else
            gna.Enabled = True
            mininterno_poliziastato.Enabled = True
            mingiustizia_poliziaPenitenziaria.Enabled = True
            mindifesa_carabinieri.Enabled = True
            minfinanze_guardiafinanza.Enabled = True
            PCDM_protezionecivile.Enabled = True
            vigilifuoco.Enabled = True
            poliziamunicipale.Enabled = True
            associazionepolstato.Enabled = True
            associazionenazfinanzieri.Enabled = True
            altrienti_azienda.Enabled = True
            txt_altro.Visible = True
        End If
    End Sub

    Private Sub associazionenazfinanzieri_CheckedChanged(sender As Object, e As EventArgs) Handles associazionenazfinanzieri.CheckedChanged
        If (associazionenazfinanzieri.Checked = True) Then
            gna.Enabled = False
            mininterno_poliziastato.Enabled = False
            mingiustizia_poliziaPenitenziaria.Enabled = False
            mindifesa_carabinieri.Enabled = False
            minfinanze_guardiafinanza.Enabled = False
            PCDM_protezionecivile.Enabled = False
            vigilifuoco.Enabled = False
            poliziamunicipale.Enabled = False
            associazionepolstato.Enabled = False
            associazioneNazCarabinieri.Enabled = False
            altrienti_azienda.Enabled = False
            txt_altro.Visible = False
        Else
            gna.Enabled = True
            mininterno_poliziastato.Enabled = True
            mingiustizia_poliziaPenitenziaria.Enabled = True
            mindifesa_carabinieri.Enabled = True
            minfinanze_guardiafinanza.Enabled = True
            PCDM_protezionecivile.Enabled = True
            vigilifuoco.Enabled = True
            poliziamunicipale.Enabled = True
            associazionepolstato.Enabled = True
            associazioneNazCarabinieri.Enabled = True
            altrienti_azienda.Enabled = True
            txt_altro.Visible = True
        End If
    End Sub

    Private Sub altrienti_azienda_CheckedChanged(sender As Object, e As EventArgs) Handles altrienti_azienda.CheckedChanged
        If (altrienti_azienda.Checked = True) Then
            gna.Enabled = False
            mininterno_poliziastato.Enabled = False
            mingiustizia_poliziaPenitenziaria.Enabled = False
            mindifesa_carabinieri.Enabled = False
            minfinanze_guardiafinanza.Enabled = False
            PCDM_protezionecivile.Enabled = False
            vigilifuoco.Enabled = False
            poliziamunicipale.Enabled = False
            associazionepolstato.Enabled = False
            associazioneNazCarabinieri.Enabled = False
            associazionenazfinanzieri.Enabled = False
            txt_altro.Visible = True
        Else
            gna.Enabled = True
            mininterno_poliziastato.Enabled = True
            mingiustizia_poliziaPenitenziaria.Enabled = True
            mindifesa_carabinieri.Enabled = True
            minfinanze_guardiafinanza.Enabled = True
            PCDM_protezionecivile.Enabled = True
            vigilifuoco.Enabled = True
            poliziamunicipale.Enabled = True
            associazionepolstato.Enabled = True
            associazioneNazCarabinieri.Enabled = True
            associazionenazfinanzieri.Enabled = True
            txt_altro.Visible = True
        End If
    End Sub

    Private Sub Modalità1_CheckedChanged(sender As Object, e As EventArgs) Handles Modalità1.CheckedChanged
        If (Modalità1.Checked = True) Then
            Modalità2.Enabled = False
            Modalità3.Enabled = False
        Else
            Modalità1.Enabled = True
            Modalità2.Enabled = True
            Modalità3.Enabled = True
        End If
    End Sub

    Private Sub Modalità2_CheckedChanged(sender As Object, e As EventArgs) Handles Modalità2.CheckedChanged
        If (Modalità2.Checked = True) Then
            Modalità1.Enabled = False
            Modalità3.Enabled = False
        Else
            Modalità1.Enabled = True
            Modalità2.Enabled = True
            Modalità3.Enabled = True
        End If
    End Sub

    Private Sub Modalità3_CheckedChanged(sender As Object, e As EventArgs) Handles Modalità3.CheckedChanged
        If (Modalità3.Checked = True) Then
            Modalità1.Enabled = False
            Modalità2.Enabled = False
        Else
            Modalità1.Enabled = True
            Modalità2.Enabled = True
            Modalità3.Enabled = True
        End If
    End Sub

    Private Sub SI_CheckedChanged(sender As Object, e As EventArgs) Handles SI.CheckedChanged
        'If (SI.Checked = True) Then
        '    btn_registra.Enabled = True
        '    NO.Checked = False
        'End If

        'set delle info da ritenere obbligatorie

        Dim test As Boolean

            Dim test1 As Boolean = Me.listacity_ctl.SelectedValue = "Seleziona comune"

            test = Me.txt_cognome.Value = "" Or txt_nome.Value = "" Or txt_datanascita.Value = "" Or
                  Me.listacity_ctl.SelectedValue = "Seleziona comune" Or txt_indirizzo.Value = "" Or txt_civico.Value = "" _
                  Or Me.txt_codicefiscale.Value = "" Or Me.listatipodocumento.SelectedValue = "Tipo documento" Or
                    Me.txt_numerodoc.Value = "" Or Me.data_rilascio.Value = "" Or Me.data_scadenza.Value = "" Or
                    Me.enterilascio.SelectedValue = "Ente Rilascio" Or Me.luogorilascio.SelectedValue = "Seleziona comune" _
                    Or Me.txtmobilenumber.Value = "" Or Me.txtemail.Value = "" Or Me.txttitolostudio.Value = ""
            If (test = True) Then
                Me.errore_successo.InnerHtml = "<p align='center'>Elenco errori compilazione Form</p>"

            End If

            Me.errore_successo.InnerHtml = Me.errore_successo.InnerHtml & "<ol type='square'>"
            If (Me.txt_cognome.Value = "") Then
                Me.errore_successo.InnerHtml = Me.errore_successo.InnerHtml & "<li>Cognome obbligatorio</li>"
            End If
            If (Me.txt_nome.Value = "") Then
                Me.errore_successo.InnerHtml = Me.errore_successo.InnerHtml & "<li>Nome obbligatorio</li>"
            End If
            If (Me.txt_datanascita.Value = "") Then
                Me.errore_successo.InnerHtml = Me.errore_successo.InnerHtml & "<li>Data di nascita obbligatoria</li>"
            End If
            If (Me.listacity_ctl.SelectedValue = "Seleziona comune") Then
                Me.errore_successo.InnerHtml = Me.errore_successo.InnerHtml & "<li>Comune obbligatorio</li>"
            End If
            If (Me.txt_indirizzo.Value = "") Then
                Me.errore_successo.InnerHtml = Me.errore_successo.InnerHtml & "<li>Indirizzo obbligatorio</li>"
            End If
            If (Me.txt_civico.Value = "") Then
                Me.errore_successo.InnerHtml = Me.errore_successo.InnerHtml & "<li>Numero civico obbligatorio</li>"
            End If
            If (Me.txt_codicefiscale.Value = "") Then
                Me.errore_successo.InnerHtml = Me.errore_successo.InnerHtml & "<li>Codice fiscale obbligatorio</li>"
            End If
            If (Me.listatipodocumento.SelectedValue = "TipoDocumento") Then
                Me.errore_successo.InnerHtml = Me.errore_successo.InnerHtml & "<li>Tipo Documento obbligatorio</li>"
            End If
            If (Me.txt_numerodoc.Value = "") Then
                Me.errore_successo.InnerHtml = Me.errore_successo.InnerHtml & "<li>Numero documento obbligatorio</li>"
            End If
            If (Me.data_rilascio.Value = "") Then
                Me.errore_successo.InnerHtml = Me.errore_successo.InnerHtml & "<li>Data rilascio obbligatoria</li>"
            End If
            If (Me.data_scadenza.Value = "") Then
                Me.errore_successo.InnerHtml = Me.errore_successo.InnerHtml & "<li>Data scadenza obbligatoria</li>"
            End If
            If (Me.enterilascio.SelectedValue = "Ente Rilascio") Then
                Me.errore_successo.InnerHtml = Me.errore_successo.InnerHtml & "<li>Ente rilascio obbligatorio</li>"
            End If
            If (Me.luogorilascio.SelectedValue = "Seleziona comune") Then
                Me.errore_successo.InnerHtml = Me.errore_successo.InnerHtml & "<li>Luogo rilascio obbligatorio</li>"
            End If
            If (Me.txtmobilenumber.Value = "") Then
                Me.errore_successo.InnerHtml = Me.errore_successo.InnerHtml & "<li>Numero cellulare obbligatorio</li>"
            End If
            If (Me.txtemail.Value = "") Then
                Me.errore_successo.InnerHtml = Me.errore_successo.InnerHtml & "<li>Indirizzo email obbligatorio</li>"
            End If
            If (Me.txttitolostudio.Value = "") Then
                Me.errore_successo.InnerHtml = Me.errore_successo.InnerHtml & "<li>Titolo di studio obbligatorio</li>"
            End If
            Me.errore_successo.InnerHtml = Me.errore_successo.InnerHtml & "</ol>"

                'If (Me.txt_cognome.Value = "") Then
                '    Me.errore_successo.InnerHtml = "<p align='center'>Elenco errori compilazione Form</p>"
                '    Me.errore_successo.InnerHtml = Me.errore_successo.InnerHtml & "<ol type='square'><li>Cognome obbligatorio</li>"
                '    If (Me.txt_nome.Value = "") Then
                '        Me.errore_successo.InnerHtml = Me.errore_successo.InnerHtml & "<li>Nome obbligatorio</li>"
                '    End If
                '    If (Me.txt_datanascita.Value = "") Then
                '        Me.errore_successo.InnerHtml = Me.errore_successo.InnerHtml & "<li>Data di nascita obbligatoria</li>"
                '    End If
                '    'Cognome *Nome *Data di nascita *Luogo di nascita*Provincia di nascita *Indirizzo di residenza *Numero civico *Città di residenza *Cap *Provincia residenza 
                '    *Codice fiscale *Documento di identità Tipo *Numero *Data rilascio *Data scadenza *Ente/Luogo di rilascio *Recapiti Mobile *Mobile ufficio Tel abitazioneTel ufficioEmail *Email ufficioTitolo di Studio *
                '    Me.errore_successo.InnerHtml = Me.errore_successo.InnerHtml & "</ol>"
                NO.Checked = True
                btn_registra.Enabled = False
                SI.Checked = False

            test = Me.txt_cognome.Value = "" Or txt_nome.Value = "" Or txt_datanascita.Value = "" Or
                 Me.listacity_ctl.SelectedValue = "Seleziona comune" Or txt_indirizzo.Value = "" Or txt_civico.Value = "" _
                 Or Me.txt_codicefiscale.Value = "" Or Me.listatipodocumento.SelectedValue = "Tipo documento" Or
                   Me.txt_numerodoc.Value = "" Or Me.data_rilascio.Value = "" Or Me.data_scadenza.Value = "" Or
                   Me.enterilascio.SelectedValue = "Ente Rilascio" Or Me.luogorilascio.SelectedValue = "Seleziona comune" _
                   Or Me.txtmobilenumber.Value = "" Or Me.txtemail.Value = "" Or Me.txttitolostudio.Value = ""

            If (test = False) Then
                Me.errore_successo.InnerHtml = "<p align='center'>Validazione dati inseriti avvenuta correttamente</p>"
            SI.Checked = True
            btn_registra.Enabled = True
            NO.Checked = False

        End If



        'btn_registra.Enabled = False
        'SI.Checked = Fals
    End Sub

    Private Sub NO_CheckedChanged(sender As Object, e As EventArgs) Handles NO.CheckedChanged
        If (NO.Checked = True) Then
            btn_registra.Enabled = False
            SI.Checked = False
        Else

        End If
    End Sub
End Class