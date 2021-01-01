Public Class messagisticainterna
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles btn_carica.ServerClick
        Dim servizio As New GetCognomSocio.GetinfocognomnomSociSoapClient()
        Dim id_socio = servizio.GetInfoSoci(Me.txt_codicefiscale.Value)
        Dim utente = servizio.GetInfoUserByIdSocio(id_socio)
        Me.txt_usernamesocio.Value = utente
    End Sub

    Protected Sub Btn_registra_Click(sender As Object, e As System.EventArgs) Handles btn_registra.Click
        Dim allegati As List(Of HttpPostedFile)
        Dim titolo
        Dim path_allegati
        If (Me.allegati.PostedFiles.Count > 1) Then
            allegati = Me.allegati.PostedFiles
        Else
            titolo = Me.allegati.PostedFile.FileName
            path_allegati = Server.MapPath("Public") & "\" & titolo
            Me.allegati.PostedFile.SaveAs(path_allegati)
        End If

    End Sub
End Class