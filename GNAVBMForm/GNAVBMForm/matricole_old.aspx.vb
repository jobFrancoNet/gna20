Imports System.Web.Configuration
Imports MySql.Data.MySqlClient

Public Class matricole_old
    Inherits System.Web.UI.Page

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    'End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim selRow As Integer = GridView2.SelectedDataKey.Value
        ClientScript.RegisterStartupScript(Me.GetType, "win", "<script>window.open('vis_socio.aspx?matr=" & selRow & "')</script>")
    End Sub

    Protected Sub GridView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView2.SelectedIndexChanged
        Button1.Visible = True
        Button2.Visible = True
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim selRow As Integer = GridView2.SelectedDataKey.Value
        ClientScript.RegisterStartupScript(Me.GetType, "win", "<script>window.open('vis_matr_old.aspx?matr=" & selRow & "')</script>")
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim confirmValue As String = Request.Form("confirm_value")
        If confirmValue = "Si" Then
            Dim matr As Integer = GridView1.SelectedDataKey.Value
            Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
            Dim conn As New MySqlConnection(strconn)
            Dim strSQL As String = "INSERT tbl_matricole_old (matricola_old, grado, com_app, prov_app, dat_iscr, regione, cogn, nom, citt_res, via, num, cap, prov_res, cf, foto, dat_dim_g, dat_dim_s, dat_espul, motivo_espul, tel_c1, tel_c2, cell1, cell2, cell3, tel_uff1, tel_uff2, fax1, fax2) SELECT tbl_socio1.id_socio, tbl_socio1.grado, tbl_socio1.com_app, tbl_socio1.prov_app, tbl_socio1.dat_iscr, tbl_socio1.Regione, tbl_socio1.cogn, tbl_socio1.nom, tbl_socio1.citt_res, tbl_socio1.via, tbl_socio1.num, tbl_socio1.cap, tbl_socio1.prov_res, tbl_socio1.cf, tbl_foto1.foto, tbl_socio1.dat_dim_g, tbl_socio1.dat_dim_s, tbl_socio1.data_espul, tbl_socio1.motivo_espul, tbl_telefono1.tel_c1, tbl_telefono1.tel_c2, tbl_telefono1.cell1, tbl_telefono1.cell2, tbl_telefono1.cell3, tbl_telefono1.tel_uff1, tbl_telefono1.tel_uff2, tbl_telefono1.fax1, tbl_telefono1.fax2 FROM tbl_socio1 INNER JOIN tbl_telefono1 ON tbl_socio1.id_tel = tbl_telefono1.id_tel INNER JOIN tbl_foto1 ON tbl_socio1.foto = tbl_foto1.id_fot WHERE tbl_socio1.id_socio = '" & matr & "'"
            Dim comm As New MySqlCommand(strSQL, conn)
            conn.Open()
            comm.ExecuteNonQuery()
            conn.Close()
            Dim data_isc As DateTime = Now()
            comm.CommandText = "UPDATE tbl_socio1 AS S INNER JOIN tbl_socio_mod AS M ON S.id_socio = M.id_socio INNER JOIN tbl_telefono1 AS T ON S.id_tel = T.id_tel INNER JOIN tbl_foto1 AS F ON S.foto = F.id_fot INNER JOIN tbl_documento1 AS D ON S.id_doc = S.id_doc INNER JOIN tbl_patenti1 AS P ON S.id_patente = P.id_patente INNER JOIN tbl_attinenze1 AS A ON S.id_attinenze = A.id_attinenze SET S.guardia='False', S.qual_amm='', S.delega='', S.grado='', S.categ='', S.com_app='', S.prov_app='', S.dat_iscr='" & data_isc.Date & "', S.regione='', S.cogn='', S.nom='', S.dat_nasc='', S.luog_nasc='', S.prov_nasc='', S.citt_res='', S.via='', S.num='', S.cap='', S.prov_res='', S.cf='', S.prof='', S.stato_civ='', S.alt='', S.col_occ='', S.col_cap='', S.gr_sang='', S.RH='', S.not_car='', S.disp='', S.pred_man_armi='', S.pred_guida_veloce='', S.e_mail='', S.e_mail_srv='', S.sesso='', S.reciclabile='False', S.matricola_mod = NULL, M.guardia='False', M.qual_amm='', M.delega='', M.grado='', M.categ='', M.com_app='', M.prov_app='', M.dat_iscr='" & data_isc.Date & "', M.regione='', M.cogn='', M.nom='', M.dat_nasc='', M.luog_nasc='', M.prov_nasc='', M.citt_res='', M.via='', M.num='', M.cap='', M.prov_res='', M.cf='', M.prof='', M.stato_civ='', M.alt='', M.col_occ='', M.col_cap='', M.gr_sang='', M.RH='', M.not_car='', M.disp='', M.pred_man_armi='', M.pred_guida_veloce='', M.e_mail='', M.e_mail_srv='', M.sesso='', T.tel_c1='', T.tel_c2='', T.cell1='', T.cell2='', T.cell3='', T.tel_uff1='', T.tel_uff2='', T.fax1='', T.fax2='', F.foto='nndisp.jpg', D.tipo_doc='', D.num_doc_id='', D.data_ril_doc='', D.data_scad_doc='', D.ente_ril_doc='', P.pat_a='False', P.pat_b='False', P.pat_c='False', P.pat_d='False', P.pat_e='False', A.ittica='False', A.venatoria='False', A.ambientale='False', A.zoofila='False', A.marittima='False', A.fluviale='False', A.sett_ric_scie='False', A.gest_par_oasi='False', A.giuridico='False', A.rel_est_uff_stampa='False', A.prot_civ='False', A.edu_amb='False', A.altre_att='' WHERE S.id_socio='" & matr & "'"
            conn.Open()
            comm.ExecuteNonQuery()
            conn.Close()
            comm.CommandText = "DELETE FROM tbl_decreti1 WHERE matricola = '" & matr & "'"
            conn.Open()
            comm.ExecuteNonQuery()
            conn.Close()
            comm.CommandText = "DELETE FROM tbl_armi1 WHERE matricola = '" & matr & "'"
            conn.Open()
            comm.ExecuteNonQuery()
            conn.Close()
            comm.CommandText = "DELETE FROM tbl_veicolo1 WHERE matricola = '" & matr & "'"
            conn.Open()
            comm.ExecuteNonQuery()
            conn.Close()
            comm.CommandText = "DELETE FROM tbl_famiglia WHERE matricola = '" & matr & "'"
            conn.Open()
            comm.ExecuteNonQuery()
            conn.Close()
            comm.CommandText = "DELETE FROM tbl_riconoscimenti1 WHERE matricola = '" & matr & "'"
            conn.Open()
            comm.ExecuteNonQuery()
            conn.Close()
            comm.CommandText = "DELETE FROM tbl_istruzione WHERE matricola = '" & matr & "'"
            conn.Open()
            comm.ExecuteNonQuery()
            conn.Close()
            comm.CommandText = "DELETE FROM tbl_procepenali WHERE matricola = '" & matr & "'"
            conn.Open()
            comm.ExecuteNonQuery()
            conn.Close()
            comm.CommandText = "DELETE FROM tbl_condanne WHERE matricola = '" & matr & "'"
            conn.Open()
            comm.ExecuteNonQuery()
            conn.Close()
            comm.CommandText = "DELETE FROM tbl_settori WHERE matricola = '" & matr & "'"
            conn.Open()
            comm.ExecuteNonQuery()
            conn.Close()
            Response.Redirect("mod_socio.aspx?matr=" & matr)

        Else
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "alert('Operazione annullata!')", True)
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Button3.Visible = True
        Button4.Visible = True
    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim selRow As Integer = GridView1.SelectedDataKey.Value
        ClientScript.RegisterStartupScript(Me.GetType, "win", "<script>window.open('vis_socio.aspx?matr=" & selRow & "')</script>")
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If (Request.Cookies("SITOGNA") Is Nothing) Then
            Response.Redirect("login.aspx")
        Else
            If Request.Cookies("SITOGNA")("qual") = "Presidente" Or Request.Cookies("SITOGNA")("qual") = "Segreteria Presidente" Or Request.Cookies("SITOGNA")("qual") = "WebMaster" Then
                Panel1.Visible = True
            Else
                Response.Write("Non hai i permessi per accedere a questa pagina")
                Panel1.Visible = False
            End If
        End If
    End Sub
End Class