Public Class ins_settore
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim matr As String = Request("matr")
        Label1.Text = "MATRICOLA: " & matr
    End Sub

End Class