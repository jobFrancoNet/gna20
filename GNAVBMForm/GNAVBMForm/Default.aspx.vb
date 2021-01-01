Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub ImageButton2_Click(sender As Object, e As ImageClickEventArgs)
        Dim mycookie As HttpCookie = New HttpCookie("infoCookieGNA")

        mycookie("info") = "OK"
        mycookie.Expires = DateTime.Now.AddYears(50)
        Response.Cookies.Add(mycookie)
        InfoCookiePanel.Visible = False
    End Sub
End Class