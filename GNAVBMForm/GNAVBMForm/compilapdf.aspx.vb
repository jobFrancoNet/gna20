Imports iTextSharp.text
Imports iTextSharp.text.pdf
Public Class compilapdf
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_compila_Click(sender As Object, e As EventArgs) Handles btn_compila.Click
        Dim percorso As String
        Dim pdf_edit_form As PdfReader
        Dim pdf_compilato As PdfStamper
        Dim dizionario_campi

        Dim elencocampi As String

        percorso = Server.MapPath("Public/modellicorso/Modulo iscrizione droni.pdf")

        Dim percorso_pdf_compilato As String = Server.MapPath("Public/modellicorso/SPALLUZZI_FRANCESCO.PDF")

        'aprire il pdf ottenendo l'oggetto
        pdf_edit_form = New PdfReader(percorso)

        dizionario_campi = From campi In pdf_edit_form.AcroFields.Fields
                           Select nomecampo = campi.Key

        'crea pdf vuoto
        pdf_compilato = New PdfStamper(pdf_edit_form, New System.IO.FileStream(percorso_pdf_compilato, System.IO.FileMode.Create))
        Dim ELENCO_CAMPI As AcroFields
        ELENCO_CAMPI = pdf_compilato.AcroFields
        For Each elencocampi In dizionario_campi
            If (elencocampi = "Nome") Then
                ELENCO_CAMPI.SetField(elencocampi, "FRANCESCO")
            End If
            If (elencocampi = "Cognome") Then
                ELENCO_CAMPI.SetField(elencocampi, "SPALLUZZI")
            End If
        Next
        pdf_compilato.FormFlattening = False
        pdf_compilato.Close()
    End Sub
End Class