Public Class ins_soc
    Inherits System.Web.UI.Page
    Public matricola As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        matricola = Request("id_soc")
        HiddenField1.Value = matricola
    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("ins_dec.aspx?matr=" & matricola)
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Response.Redirect("ins_arm.aspx?matr=" & matricola)
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Response.Redirect("ins_veic.aspx?matr=" & matricola)
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Response.Redirect("ins_fam.aspx?matr=" & matricola)
    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        Response.Redirect("ins_ric.aspx?matr=" & matricola)
    End Sub

    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click
        Response.Redirect("ins_istr.aspx?matr=" & matricola)
    End Sub

    Protected Sub Button7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button7.Click
        Response.Redirect("ins_proc.aspx?matr=" & matricola)
    End Sub

    Protected Sub Button8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button8.Click
        Response.Redirect("ins_cond.aspx?matr=" & matricola)
    End Sub

    Protected Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Response.Redirect("ins_settore.aspx?matr=" & matricola)
    End Sub

    Protected Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        ClientScript.RegisterStartupScript(Me.GetType, "win", "<script>window.open('invio_docum.aspx?matr=" & matricola & "')</script>")
    End Sub

End Class