Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Net
Imports System.Net.Mail
Imports System.Web
Imports System.Web.UI.Page
Public Class CompilaModuloPdf


    Public Sub New(nomemodulo As String, PageWebForm As Page, formreg As registrazionecorso)

        If (nomemodulo = "DRONI") Then
            ExecuteCompilaModuloDroni(nomemodulo, PageWebForm, formreg)
        End If
    End Sub

    Private Sub ExecuteCompilaModuloDroni(nomemodulo As String, page_webform As Page, freg As registrazionecorso)
        Dim percorsomodulo As String = page_webform.Server.MapPath("Public/modellicorso/Modulo droni web.pdf")

        Dim percorso_modulo_compilato = page_webform.Server.MapPath("Public/Documenti/" & nomemodulo & "_" & freg.txt_cognome.Value & "_" & freg.txt_nome.Value & ".pdf")


        Dim pdf_edit_form As PdfReader
        Dim pdf_compilato As PdfStamper
        Dim dizionario_campi

        pdf_edit_form = New PdfReader(percorsomodulo)

        dizionario_campi = From campi In pdf_edit_form.AcroFields.Fields
                           Select nomecampo = campi.Key

        'crea pdf vuoto
        pdf_compilato = New PdfStamper(pdf_edit_form, New System.IO.FileStream(percorso_modulo_compilato, System.IO.FileMode.Create))
        Dim ELENCO_CAMPI As AcroFields
        ELENCO_CAMPI = pdf_compilato.AcroFields
        For Each elencocampi In dizionario_campi
            If (elencocampi = "Nome") Then
                ELENCO_CAMPI.SetField(elencocampi, freg.txt_nome.Value)
            End If
            If (elencocampi = "Cognome") Then
                ELENCO_CAMPI.SetField(elencocampi, freg.txt_cognome.Value)
            End If
            If (elencocampi = "Data di nascita") Then
                'Dim data As Date = Convert.ToDateTime(freg.txt_datanascita.Value)
                'Dim giorno = data.Day
                'If (giorno <= 9) Then
                '    giorno = "0" & LTrim(Str(giorno))
                'End If
                'Dim mese = data.Month
                'If (mese <= 9) Then
                '    mese = "0" & LTrim(Str(mese))
                'End If
                'Dim data_testo = giorno & "/" & mese & data.Year.ToString()
                ELENCO_CAMPI.SetField(elencocampi, freg.txt_datanascita.Value)
            End If
            If (elencocampi = "Luogo di nascita") Then
                ELENCO_CAMPI.SetField(elencocampi, freg.listacomuni_ctl.SelectedValue)
            End If
            If (elencocampi = "Prov") Then
                ELENCO_CAMPI.SetField(elencocampi, freg.txt_prov.Value)
            End If
            If (elencocampi = "Indirizzo") Then
                ELENCO_CAMPI.SetField(elencocampi, freg.txt_indirizzo.Value)
            End If
            If (elencocampi = "N") Then
                ELENCO_CAMPI.SetField(elencocampi, freg.txt_civico.Value)
            End If
            If (elencocampi = "CAP") Then
                ELENCO_CAMPI.SetField(elencocampi, freg.listacap_ctl.SelectedValue)
            End If
            If (elencocampi = "Città") Then
                ELENCO_CAMPI.SetField(elencocampi, freg.listacity_ctl.SelectedValue)
            End If
            If (elencocampi = "Prov_2") Then
                ELENCO_CAMPI.SetField(elencocampi, freg.txt_prov_res.Value)
            End If
            If (elencocampi = "Codice fiscale obbligatorio") Then
                ELENCO_CAMPI.SetField(elencocampi, freg.txt_codicefiscale.Value.ToUpper())
            End If
            If (elencocampi = "Tipo") Then
                ELENCO_CAMPI.SetField(elencocampi, freg.listatipodocumento.SelectedValue)
            End If
            If (elencocampi = "Numero") Then
                ELENCO_CAMPI.SetField(elencocampi, freg.txt_numerodoc.Value.ToUpper())
            End If
            If (elencocampi = "Data rilascio") Then
                'Dim data As Date = Convert.ToDateTime(freg.data_rilascio.Value)
                'Dim giorno = data.Day
                'If (giorno <= 9) Then
                '    giorno = "0" & LTrim(Str(giorno))
                'End If
                'Dim mese = data.Month
                'If (mese <= 9) Then
                '    mese = "0" & LTrim(Str(mese))
                'End If
                'Dim data_testo = giorno & "/" & mese & data.Year.ToString()
                ELENCO_CAMPI.SetField(elencocampi, freg.data_rilascio.Value)
            End If
            If (elencocampi = "Data scadenza") Then
                'Dim data As Date = Convert.ToDateTime(freg.data_scadenza.Value)
                'Dim giorno = data.Day
                'If (giorno <= 9) Then
                '    giorno = "0" & LTrim(Str(giorno))
                'End If
                'Dim mese = data.Month
                'If (mese <= 9) Then
                '    mese = "0" & LTrim(Str(mese))
                'End If
                'Dim data_testo = giorno & "/" & mese & data.Year.ToString()
                ELENCO_CAMPI.SetField(elencocampi, freg.data_scadenza.Value)
            End If
            If (elencocampi = "Ente rilascio") Then
                ELENCO_CAMPI.SetField(elencocampi, freg.enterilascio.SelectedValue)
            End If
            If (elencocampi = "Mobile") Then
                ELENCO_CAMPI.SetField(elencocampi, freg.txtmobilenumber.Value)
            End If
            If (elencocampi = "Tel Ab") Then
                ELENCO_CAMPI.SetField(elencocampi, freg.txttelefonoab.Value)
            End If
            If (elencocampi = "E  mail") Then
                ELENCO_CAMPI.SetField(elencocampi, freg.txtemail.Value)
            End If
            If (elencocampi = "Mobile Uff") Then
                ELENCO_CAMPI.SetField(elencocampi, freg.txtmobilnumberuff.Value)
            End If
            If (elencocampi = "Tel Uff") Then
                ELENCO_CAMPI.SetField(elencocampi, freg.txttelefonouff.Value)
            End If

            If (elencocampi = "E  mail Uff") Then
                ELENCO_CAMPI.SetField(elencocampi, freg.txtemailuff.Value)
            End If
            If (elencocampi = "Titolo di Studio") Then
                ELENCO_CAMPI.SetField(elencocampi, freg.txttitolostudio.Value)
            End If

            If (elencocampi = "GNA" And freg.gna.Checked = True) Then
                'mettere a stato off tutte le altre possibilità
                ELENCO_CAMPI.SetField("Protezione Civile", "Off")
                ELENCO_CAMPI.SetField("ANC", "Off")
                ELENCO_CAMPI.SetField("Polizia di Stato", "Off")
                ELENCO_CAMPI.SetField("Vigili del Fuoco", "Off")
                ELENCO_CAMPI.SetField("ANFI", "Off")
                ELENCO_CAMPI.SetField("Carabinieri", "Off")
                ELENCO_CAMPI.SetField("Polizia Locale", "Off")
                ELENCO_CAMPI.SetField("Polizia Penitenziaria", "Off")
                ELENCO_CAMPI.SetField("Guardia di Finanza", "Off")
                ELENCO_CAMPI.SetField("ANPS", "Off")
                ELENCO_CAMPI.SetField("Altri", "Off")
            End If

            If (elencocampi = "Protezione Civile" And freg.PCDM_protezionecivile.Checked = True) Then
                ELENCO_CAMPI.SetField("GNA", "Off")
                ELENCO_CAMPI.SetField("ANC", "Off")
                ELENCO_CAMPI.SetField("Polizia di Stato", "Off")
                ELENCO_CAMPI.SetField("Vigili del Fuoco", "Off")
                ELENCO_CAMPI.SetField("ANFI", "Off")
                ELENCO_CAMPI.SetField("Carabinieri", "Off")
                ELENCO_CAMPI.SetField("Polizia Locale", "Off")
                ELENCO_CAMPI.SetField("Polizia Penitenziaria", "Off")
                ELENCO_CAMPI.SetField("Guardia di Finanza", "Off")
                ELENCO_CAMPI.SetField("ANPS", "Off")
                ELENCO_CAMPI.SetField("Altri", "Off")
            End If

            If (elencocampi = "ANC" And freg.associazioneNazCarabinieri.Checked = True) Then
                ELENCO_CAMPI.SetField("GNA", "Off")
                ELENCO_CAMPI.SetField("Protezione Civile", "Off")
                ELENCO_CAMPI.SetField("Polizia di Stato", "Off")
                ELENCO_CAMPI.SetField("Vigili del Fuoco", "Off")
                ELENCO_CAMPI.SetField("ANFI", "Off")
                ELENCO_CAMPI.SetField("Carabinieri", "Off")
                ELENCO_CAMPI.SetField("Polizia Locale", "Off")
                ELENCO_CAMPI.SetField("Polizia Penitenziaria", "Off")
                ELENCO_CAMPI.SetField("Guardia di Finanza", "Off")
                ELENCO_CAMPI.SetField("ANPS", "Off")
                ELENCO_CAMPI.SetField("Altri", "Off")
            End If

            If (elencocampi = "Polizia di Stato" And freg.mininterno_poliziastato.Checked = True) Then
                ELENCO_CAMPI.SetField("GNA", "Off")
                ELENCO_CAMPI.SetField("Protezione Civile", "Off")
                ELENCO_CAMPI.SetField("ANC", "Off")
                ELENCO_CAMPI.SetField("Vigili del Fuoco", "Off")
                ELENCO_CAMPI.SetField("ANFI", "Off")
                ELENCO_CAMPI.SetField("Carabinieri", "Off")
                ELENCO_CAMPI.SetField("Polizia Locale", "Off")
                ELENCO_CAMPI.SetField("Polizia Penitenziaria", "Off")
                ELENCO_CAMPI.SetField("Guardia di Finanza", "Off")
                ELENCO_CAMPI.SetField("ANPS", "Off")
                ELENCO_CAMPI.SetField("Altri", "Off")
            End If

            If (elencocampi = "Vigili del Fuoco" And freg.vigilifuoco.Checked = True) Then
                ELENCO_CAMPI.SetField("GNA", "Off")
                ELENCO_CAMPI.SetField("Protezione Civile", "Off")
                ELENCO_CAMPI.SetField("ANC", "Off")
                ELENCO_CAMPI.SetField("Polizia di Stato", "Off")
                ELENCO_CAMPI.SetField("ANFI", "Off")
                ELENCO_CAMPI.SetField("Carabinieri", "Off")
                ELENCO_CAMPI.SetField("Polizia Locale", "Off")
                ELENCO_CAMPI.SetField("Polizia Penitenziaria", "Off")
                ELENCO_CAMPI.SetField("Guardia di Finanza", "Off")
                ELENCO_CAMPI.SetField("ANPS", "Off")
                ELENCO_CAMPI.SetField("Altri", "Off")
            End If

            If (elencocampi = "ANFI" And freg.associazionenazfinanzieri.Checked = True) Then
                ELENCO_CAMPI.SetField("GNA", "Off")
                ELENCO_CAMPI.SetField("Protezione Civile", "Off")
                ELENCO_CAMPI.SetField("ANC", "Off")
                ELENCO_CAMPI.SetField("Polizia di Stato", "Off")
                ELENCO_CAMPI.SetField("Vigili del Fuoco", "Off")
                ELENCO_CAMPI.SetField("Carabinieri", "Off")
                ELENCO_CAMPI.SetField("Polizia Locale", "Off")
                ELENCO_CAMPI.SetField("Polizia Penitenziaria", "Off")
                ELENCO_CAMPI.SetField("Guardia di Finanza", "Off")
                ELENCO_CAMPI.SetField("ANPS", "Off")
                ELENCO_CAMPI.SetField("Altri", "Off")
            End If

            If (elencocampi = "Carabinieri" And freg.mindifesa_carabinieri.Checked = True) Then
                ELENCO_CAMPI.SetField("GNA", "Off")
                ELENCO_CAMPI.SetField("Protezione Civile", "Off")
                ELENCO_CAMPI.SetField("ANC", "Off")
                ELENCO_CAMPI.SetField("Polizia di Stato", "Off")
                ELENCO_CAMPI.SetField("Vigili del Fuoco", "Off")
                ELENCO_CAMPI.SetField("ANFI", "Off")
                ELENCO_CAMPI.SetField("Polizia Locale", "Off")
                ELENCO_CAMPI.SetField("Polizia Penitenziaria", "Off")
                ELENCO_CAMPI.SetField("Guardia di Finanza", "Off")
                ELENCO_CAMPI.SetField("ANPS", "Off")
                ELENCO_CAMPI.SetField("Altri", "Off")
            End If

            If (elencocampi = "Polizia Locale" And freg.poliziamunicipale.Checked = True) Then
                ELENCO_CAMPI.SetField("GNA", "Off")
                ELENCO_CAMPI.SetField("Protezione Civile", "Off")
                ELENCO_CAMPI.SetField("ANC", "Off")
                ELENCO_CAMPI.SetField("Polizia di Stato", "Off")
                ELENCO_CAMPI.SetField("Vigili del Fuoco", "Off")
                ELENCO_CAMPI.SetField("ANFI", "Off")
                ELENCO_CAMPI.SetField("Carabinieri", "Off")
                ELENCO_CAMPI.SetField("Polizia Penitenziaria", "Off")
                ELENCO_CAMPI.SetField("Guardia di Finanza", "Off")
                ELENCO_CAMPI.SetField("ANPS", "Off")
                ELENCO_CAMPI.SetField("Altri", "Off")
            End If

            If (elencocampi = "Polizia Penitenziaria" And freg.mingiustizia_poliziaPenitenziaria.Checked = True) Then
                ELENCO_CAMPI.SetField("GNA", "Off")
                ELENCO_CAMPI.SetField("Protezione Civile", "Off")
                ELENCO_CAMPI.SetField("ANC", "Off")
                ELENCO_CAMPI.SetField("Polizia di Stato", "Off")
                ELENCO_CAMPI.SetField("Vigili del Fuoco", "Off")
                ELENCO_CAMPI.SetField("ANFI", "Off")
                ELENCO_CAMPI.SetField("Carabinieri", "Off")
                ELENCO_CAMPI.SetField("Polizia Locale", "Off")
                ELENCO_CAMPI.SetField("Guardia di Finanza", "Off")
                ELENCO_CAMPI.SetField("ANPS", "Off")
                ELENCO_CAMPI.SetField("Altri", "Off")
            End If

            If (elencocampi = "Guardia di Finanza" And freg.minfinanze_guardiafinanza.Checked = True) Then
                ELENCO_CAMPI.SetField("GNA", "Off")
                ELENCO_CAMPI.SetField("Protezione Civile", "Off")
                ELENCO_CAMPI.SetField("ANC", "Off")
                ELENCO_CAMPI.SetField("Polizia di Stato", "Off")
                ELENCO_CAMPI.SetField("Vigili del Fuoco", "Off")
                ELENCO_CAMPI.SetField("ANFI", "Off")
                ELENCO_CAMPI.SetField("Carabinieri", "Off")
                ELENCO_CAMPI.SetField("Polizia Locale", "Off")
                ELENCO_CAMPI.SetField("Polizia Penitenziaria", "Off")
                ELENCO_CAMPI.SetField("ANPS", "Off")
                ELENCO_CAMPI.SetField("Altri", "Off")
            End If


            If (elencocampi = "ANPS" And freg.associazionepolstato.Checked = True) Then
                ELENCO_CAMPI.SetField("GNA", "Off")
                ELENCO_CAMPI.SetField("Protezione Civile", "Off")
                ELENCO_CAMPI.SetField("ANC", "Off")
                ELENCO_CAMPI.SetField("Polizia di Stato", "Off")
                ELENCO_CAMPI.SetField("Vigili del Fuoco", "Off")
                ELENCO_CAMPI.SetField("ANFI", "Off")
                ELENCO_CAMPI.SetField("Carabinieri", "Off")
                ELENCO_CAMPI.SetField("Polizia Locale", "Off")
                ELENCO_CAMPI.SetField("Polizia Penitenziaria", "Off")
                ELENCO_CAMPI.SetField("Guardia di Finanza", "Off")
                ELENCO_CAMPI.SetField("Altri", "Off")
            End If

            If (elencocampi = "Altri" And freg.altrienti_azienda.Checked = True) Then
                ELENCO_CAMPI.SetField("GNA", "Off")
                ELENCO_CAMPI.SetField("Protezione Civile", "Off")
                ELENCO_CAMPI.SetField("ANC", "Off")
                ELENCO_CAMPI.SetField("Polizia di Stato", "Off")
                ELENCO_CAMPI.SetField("Vigili del Fuoco", "Off")
                ELENCO_CAMPI.SetField("ANFI", "Off")
                ELENCO_CAMPI.SetField("Carabinieri", "Off")
                ELENCO_CAMPI.SetField("Polizia Locale", "Off")
                ELENCO_CAMPI.SetField("Polizia Penitenziaria", "Off")
                ELENCO_CAMPI.SetField("Guardia di Finanza", "Off")
                ELENCO_CAMPI.SetField("ANPS", "Off")
                ELENCO_CAMPI.SetField("Altri Enti o Aziende", freg.txt_altro.Value)
            End If

            If (elencocampi = "Basico" And freg.basico.Checked = True) Then
                ELENCO_CAMPI.SetField("Critico", "Off")
                ELENCO_CAMPI.SetField("Basico + Critico", "Off")
            End If

            If (elencocampi = "Critico" And freg.critico.Checked = True) Then
                ELENCO_CAMPI.SetField("Basico", "Off")
                ELENCO_CAMPI.SetField("Basico + Critico", "Off")
            End If

            If (elencocampi = "Basico + Critico" And freg.soluzione_completa.Checked = True) Then
                ELENCO_CAMPI.SetField("Basico", "Off")
                ELENCO_CAMPI.SetField("Critico", "Off")
            End If

            If (elencocampi = "Assegno" And freg.Modalità1.Checked = True) Then
                ELENCO_CAMPI.SetField("Bonifico", "Off")
                ELENCO_CAMPI.SetField("Bollettino", "Off")
            End If
            If (elencocampi = "Bonifico" And freg.Modalità2.Checked = True) Then
                ELENCO_CAMPI.SetField("Assegno", "Off")
                ELENCO_CAMPI.SetField("Bollettino", "Off")
            End If
            If (elencocampi = "Bollettino" And freg.Modalità3.Checked = True) Then
                ELENCO_CAMPI.SetField("Assegno", "Off")
                ELENCO_CAMPI.SetField("Bonifico", "Off")
            End If
        Next
        pdf_compilato.FormFlattening = False
        pdf_compilato.Close()

        'Procedura per invio mail:
        'from corsi@guardianazionaleambientale.eu
        'to mail dichiarata in fase di compilazione form

        Dim Msginvio_mail As MailMessage

        Dim mittente As MailAddress = New MailAddress("corsi@guardianazionalemabientale.eu", "Segreteria Corsi - Email conferma iscrizione")

        Msginvio_mail = New MailMessage()

        Msginvio_mail.From = mittente
        Msginvio_mail.To.Add(freg.txtemail.Value)

        Msginvio_mail.To.Add("presidenza@guardianazionaleambientale.eu")
        Msginvio_mail.To.Add("segreteria@guardianazionaleambientale.eu")

        Msginvio_mail.Body = "INVIO MAIL"



        Msginvio_mail.Subject = "TEST INVIO MAIL"

        Msginvio_mail.IsBodyHtml = True

        Dim allegato_formpdfcompilato As Attachment = New Attachment(page_webform.Server.MapPath("Public/Documenti/" & nomemodulo & "_" & freg.txt_cognome.Value & "_" & freg.txt_nome.Value & ".pdf"))


        Msginvio_mail.Attachments.Add(allegato_formpdfcompilato)
        Msginvio_mail.Priority = MailPriority.High

        'impostazione configurazione host

        Dim smtp_client As SmtpClient = New SmtpClient()

        smtp_client.Host = "smtp.guardianazionaleambientale.eu"
        smtp_client.Credentials = New System.Net.NetworkCredential("corsi@guardianazionaleambientale.eu", "Segreteria2019")

        Try
            'Invio dell'email
            smtp_client.Send(Msginvio_mail)
            freg.errore_successo.InnerHtml = "<b>Invio mail avvenuta con successo; A breve riceverà un messaggio di posta  elettronica e nel caso non dovesse essere visibile in posta in arrivo, controllare prima tra i messaggi spam o posta indesiderata. Nel caso non fosse stata recapitata alcuna mail è pregato di contattarci al più presto al fine di provvedere al reinvio</b>"
        Catch ex As Exception

            freg.errore_successo.InnerHtml = "Si è verificato un errore durante l'invio della mail " & " " & ex.Message.ToString()
            smtp_client.Dispose()
            Msginvio_mail.Dispose()
        End Try
    End Sub
End Class
