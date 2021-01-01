Public Class ins_veic
    Inherits System.Web.UI.Page
    Public id_matr As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        id_matr = Request("matr")
        Response.Write("GESTIONE VEICOLI PER IL SOCIO CON MATRICOLA " & id_matr)
    End Sub

End Class