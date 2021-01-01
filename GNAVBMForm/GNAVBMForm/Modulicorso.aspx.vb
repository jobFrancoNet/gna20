Public Class Modulicorso
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim id_corso As Integer = Request.QueryString("IdCorso")
        MyAccordion.SelectedIndex = id_corso - 1
        MyAccordion.RequireOpenedPane = True
    End Sub


End Class