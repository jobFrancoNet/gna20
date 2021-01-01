Imports AjaxControlToolkit
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Private Sub MasterPage_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim acc As AjaxControlToolkit.Accordion
        Try
            acc = CType(Page.FindControl("Accordion1"), AjaxControlToolkit.Accordion)
            Dim S As New Style
            S.CssClass = "collapsed:true"
            acc.Panes(0).ApplyStyle(S)
        Catch ex As Exception

        End Try
    End Sub
End Class

