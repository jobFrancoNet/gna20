Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Net
Imports System.Drawing
Imports System.Web.Configuration
Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports System.Net.Mail
Imports System.EventArgs
Imports GNAVBMForm
Imports GNAVBMForm.WebServicegna.CalcoloCodiceFiscaleSoapClient
Imports GNAVBMForm.WebServicegna

Public Class WebForm1
    Inherits System.Web.UI.Page
    Public id_soc As Integer
    Public cod_fisc_gen As String

    Public strconn As String = String.Empty

    Protected Function SwitchDB() As String

        If (ConfigurationManager.AppSettings("DB").Equals("TEST")) Then
            strconn = WebConfigurationManager.ConnectionStrings("GNATEST_ConnectionString").ConnectionString
        End If
        If (ConfigurationManager.AppSettings("DB").Equals("PRODUZIONE")) Then
            strconn = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
        End If

        Return strconn
    End Function



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txt_cogn.Attributes.Add("onKeyUp", "verif_letpM(this);")
        txt_nom.Attributes.Add("onKeyUp", "verif_letpM(this);")
        txt_via.Attributes.Add("onKeyUp", "verif_letpM(this);")
        txt_codfis.Attributes.Add("onKeyUp", "verif_letnumM(this);")
        txt_mail.Attributes.Add("onKeyUp", "this.value=this.value.toLowerCase();")
        txt_dtnas.Attributes.Add("onKeyUp", "verif_dat(this);")
        txt_cap.Attributes.Add("onKeyUp", "verif_num(this);")
        txt_ndoc.Attributes.Add("onKeyUp", "verif_letnumM(this);")
        txt_dtrild.Attributes.Add("onKeyUp", "verif_dat(this);")
        txt_dtscd.Attributes.Add("onKeyUp", "verif_dat(this);")
        txt_entrildoc.Attributes.Add("onKeyUp", "verif_letpM(this);")
        txt_prof.Attributes.Add("onKeyUp", "verif_letpM(this);")
        txt_email_srv.Attributes.Add("onKeyUp", "this.value=this.value.toLowerCase();")
        txt_telab.Attributes.Add("onKeyUp", "verif_numtel(this);")
        txt_cell.Attributes.Add("onKeyUp", "verif_numtel(this);")
        txt_cell2.Attributes.Add("onKeyUp", "verif_numtel(this);")
        txt_cells.Attributes.Add("onKeyUp", "verif_numtel(this);")
        txt_teluff.Attributes.Add("onKeyUp", "verif_numtel(this);")
        txt_fax.Attributes.Add("onKeyUp", "verif_numtel(this);")

        strconn = SwitchDB()

        If (Request.Cookies("SITOGNA") Is Nothing) Then
            Response.Redirect("login.aspx")
        Else
            If Request.Cookies("SITOGNA")("cogn") Is Nothing Or Request.Cookies("SITOGNA")("cogn") = "" Then
                Response.Redirect("login.aspx")
            Else
                If Not Page.IsPostBack Then
                    Dim ind_ip As String = Request.ServerVariables("REMOTE_ADDR")
                    Dim attiv As String
                    attiv = Request.Cookies("SITOGNA")("cogn") & " " & Request.Cookies("SITOGNA")("nome") & " è entrato nella pagina di inserimento nuovo socio"


                    Dim conn As New MySqlConnection(strconn)

                    Dim StrSql As String = "INSERT INTO tbl_log (attivita,indirizzo_ip) VALUES ('" & attiv.Replace("'", "''") & "','" & ind_ip & "');"
                    Dim comm As New MySqlCommand(StrSql, conn)
                    conn.Open()
                    comm.ExecuteNonQuery()
                    conn.Close()
                End If
                Dim data_isc As DateTime = Now()
                txt_dtisc.Text = data_isc.Date
                If Request.Cookies("SITOGNA")("qual") = "Presidente" Or Request.Cookies("SITOGNA")("qual") = "Segreteria Presidente" Then
                    txt_dtisc.ReadOnly = False
                Else
                    If Not Page.IsPostBack Then
                        DD_grado.Items.Clear()
                        DD_grado.Items.Add(New ListItem("", ""))
                        DD_grado.Items.Add(New ListItem("Aspirante", "Aspirante"))
                    End If
                End If
            End If
        End If
    End Sub

    Private Function ResizeAndSave(ByVal imgStr As Stream, ByVal FileName As String) As System.Drawing.Image
        'creo il bitmap dallo stream
        Dim bmpStream As System.Drawing.Image = System.Drawing.Image.FromStream(imgStr)

        'creo un nuovo bitmap ridimensionandolo 
        Dim W As Integer
        Dim H As Integer
        If bmpStream.Width > 319 Then
            W = 319
            H = 343
        Else
            W = bmpStream.Width
            H = bmpStream.Height
        End If

        Dim img As New Bitmap(bmpStream, New Size(W, H))

        'salvo l'immagine ridimensionata
        img.Save(FileName, System.Drawing.Imaging.ImageFormat.Jpeg)

    End Function

    Private Function email(ByVal stringa As String) As String
        email = stringa
        email = Replace(email, "'", "")
        email = Replace(email, " ", "")
        email = Replace(email, "ì", "i")
        email = Replace(email, "à", "a")
        email = Replace(email, "è", "e")
        email = Replace(email, "é", "e")
        email = Replace(email, "ò", "o")
        email = Replace(email, "ù", "u")
    End Function

    Protected Sub DD_provnas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DD_provnas.SelectedIndexChanged
        DD_lgnas.Items.Clear()
        DD_lgnas.ClearSelection()
    End Sub

    Protected Sub DD_provres_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DD_provres.SelectedIndexChanged
        DD_citres.Items.Clear()
        DD_citres.ClearSelection()
    End Sub

    Protected Sub DD_regapp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DD_regapp.SelectedIndexChanged
        DD_provapp.Items.Clear()
        DD_provapp.ClearSelection()
    End Sub

    Protected Sub DD_provapp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DD_provapp.SelectedIndexChanged
        DD_sedeapp.Items.Clear()
        DD_sedeapp.ClearSelection()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click


        Dim calcodf As WebServicegna.CalcoloCodiceFiscaleSoapClient = New GNAVBMForm.WebServicegna.CalcoloCodiceFiscaleSoapClient()


        Dim sesso As String
        If DD_ses.SelectedValue = "Maschio" Then
            sesso = "M"
        Else
            sesso = "F"
        End If

        Dim codfisc As New codfisc

        Dim luogonascita As String = Microsoft.VisualBasic.UCase(DD_lgnas.SelectedValue)

        codfisc = (calcodf.calcolocodicefiscaleV2(txt_nom.Text, txt_cogn.Text, txt_dtnas.Text, luogonascita, sesso))
        If codfisc.codicefiscale <> txt_codfis.Text Then
            'ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Il Codice Fiscale manca o non è corretto!')", True)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alerterrore", "<script type='text/javascript'>ErroreCodiceFiscale();</script>")
            Exit Sub
        End If
        'Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
        'Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNATEST_ConnectionString").ConnectionString
        Dim conn As New MySqlConnection(strconn)
        Dim strSql As String
        strSql = "SELECT cf FROM tbl_socio1 WHERE cf = '" & txt_codfis.Text & "'"
        Dim comm As New MySqlCommand
        comm.Connection = conn
        comm.CommandText = strSql
        conn.Open()
        Dim rs As MySqlDataReader = comm.ExecuteReader
        rs.Read()
        If rs.HasRows Then
            'ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "alert('Socio già inserito!');", True)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alerterrore", "<script type='text/javascript'>ErroreSociogiàinserito();</script>")
            rs.Close()
            conn.Close()
            Exit Sub
        Else
            rs.Close()

            comm.CommandText = "INSERT INTO tbl_documento1 (tipo_doc,num_doc_id,data_ril_doc,data_scad_doc,ente_ril_doc) VALUES ('" & DD_docid.SelectedValue.Replace("'", "''") & "','" & txt_ndoc.Text.ToString & "','" & txt_dtrild.Text & "','" & txt_dtscd.Text & "','" & txt_entrildoc.Text.Replace("'", "''") & "');"
            comm.ExecuteNonQuery()

            comm.CommandText = "SELECT @@IDENTITY AS ultimo_id"
            Dim ult_id_doc As Integer = comm.ExecuteScalar()

            comm.CommandText = "INSERT INTO tbl_telefono1 (tel_c1,cell1,cell2,cell3,tel_uff1,fax1) VALUES ('" & txt_telab.Text & "','" & txt_cell.Text & "','" & txt_cell2.Text & "','" & txt_cells.Text & "','" & txt_teluff.Text & "','" & txt_fax.Text & "');"
            comm.ExecuteNonQuery()

            comm.CommandText = "SELECT @@IDENTITY AS ultimo_id"
            Dim ult_id_tel As Integer = comm.ExecuteScalar()

            comm.CommandText = "INSERT INTO tbl_patenti1 (pat_a,pat_b,pat_c,pat_d,pat_e) VALUES ('" & CType(ck_pata.Checked, String) & "','" & CType(ck_patb.Checked, String) & "','" & CType(ck_patc.Checked, String) & "','" & CType(ck_patd.Checked, String) & "','" & CType(ck_pate.Checked, String) & "');"
            comm.ExecuteNonQuery()

            comm.CommandText = "SELECT @@IDENTITY AS ultimo_id"
            Dim ult_id_pat As Integer = comm.ExecuteScalar()

            comm.CommandText = "INSERT INTO tbl_attinenze1 (ittica,venatoria,ambientale,zoofila,marittima,fluviale,sett_ric_scie,gest_par_oasi,giuridico,rel_est_uff_stampa,prot_civ,edu_amb,altre_att) VALUES ('" & CType(att1.Checked, String) & "','" & CType(att2.Checked, String) & "','" & CType(att3.Checked, String) & "','" & CType(att4.Checked, String) & "','" & CType(att5.Checked, String) & "','" & CType(att7.Checked, String) & "','" & CType(att8.Checked, String) & "','" & CType(att9.Checked, String) & "','" & CType(att6.Checked, String) & "','" & CType(att11.Checked, String) & "','" & CType(att12.Checked, String) & "','" & CType(att10.Checked, String) & "','" & txt_alatt.Text.Replace("'", "''") & "');"
            comm.ExecuteNonQuery()

            comm.CommandText = "SELECT @@IDENTITY AS ultimo_id"
            Dim ult_id_att As String = comm.ExecuteScalar()
            Dim car_foto As Integer = 0
            Dim myFoto As String
            If (Up_foto.PostedFile.ContentType = "image/jpeg" Or Up_foto.PostedFile.ContentType = "image/pjpeg") Then

                myFoto = Up_foto.FileName

                'salvo così com'è
                Up_foto.SaveAs("x:\inetpub\vhosts\guardianazionaleambientale.eu\httpdocs\Public\" + myFoto)

                'Creo lo Stream e lo passo alla funzione insieme alle dimensioni al percorso e al nome del file.
                Dim DataM As New MemoryStream(Up_foto.FileBytes)
                ResizeAndSave(DataM, "x:\inetpub\vhosts\guardianazionaleambientale.eu\httpdocs\Public\foto\" + myFoto)
                Dim filePath As String
                Dim percorso As String = "~/Public/"
                percorso += myFoto

                filePath = Server.MapPath(percorso)
                File.Delete(filePath)

                comm.CommandText = "INSERT INTO tbl_foto1(foto) VALUES ('" & myFoto & "');"
                comm.ExecuteNonQuery()
                car_foto = 1
            Else
                myFoto = "nndisp.jpg"
                comm.CommandText = "INSERT INTO tbl_foto1(foto) VALUES ('" & myFoto & "');"
                comm.ExecuteNonQuery()
            End If
            comm.CommandText = "SELECT @@IDENTITY AS ultimo_id"
            Dim ult_id_fot As Integer = comm.ExecuteScalar()

            comm.CommandText = "INSERT INTO tbl_socio_mod (id_doc,id_tel,id_patente,id_attinenze,guardia,qual_amm,grado,categ,com_app,prov_app,dat_iscr,regione,cogn,nom,dat_nasc,luog_nasc,prov_nasc,citt_res,via,num,cap,prov_res,cf,prof,stato_civ,alt,col_occ,col_cap,gr_sang,RH,not_car,foto,disp,pred_man_armi,pred_guida_veloce,e_mail,e_mail_srv,sesso) VALUES ('" & ult_id_doc & "','" & ult_id_tel & "','" & ult_id_pat & "','" & ult_id_att & "','" & CType(chk_guardia.Checked, String) & "','" & DD_qualamm.SelectedValue & "','" & DD_grado.SelectedValue & "','" & DD_tpsoc.SelectedValue & "','" & DD_sedeapp.SelectedValue.Replace("'", "''") & "','" & DD_provapp.SelectedValue.Replace("'", "''") & "','" & txt_dtisc.Text & "','" & DD_regapp.SelectedValue.Replace("'", "''") & "','" & txt_cogn.Text.Replace("'", "''") & "','" & txt_nom.Text.Replace("'", "''") & "','" & txt_dtnas.Text & "','" & DD_lgnas.SelectedValue.Replace("'", "''") & "','" & DD_provnas.SelectedValue.Replace("'", "''") & "','" & DD_citres.SelectedValue.Replace("'", "''") & "','" & txt_via.Text.Replace("'", "''") & "','" & txt_civ.Text & "','" & txt_cap.Text & "','" & DD_provres.SelectedValue.ToString & "','" & txt_codfis.Text.ToUpper & "','" & txt_prof.Text.ToString & "','" & DD_staciv.SelectedValue.ToString & "','" & txt_alt.Text & "','" & DD_colocc.Text & "','" & DD_colcap.Text & "','" & DD_grsang.SelectedValue & "','" & DD_rh.SelectedValue & "','" & txt_note.Text & "','" & ult_id_fot & "','" & txt_disp.Text.ToString & "','" & DD_predarm.SelectedValue.ToString & "','" & DD_guidvel.SelectedValue.ToString & "','" & txt_mail.Text & "','" & txt_email_srv.Text & "','" & DD_ses.SelectedValue.ToString & "');"
            comm.ExecuteNonQuery()

            comm.CommandText = "INSERT INTO tbl_socio1 (id_doc,id_tel,id_patente,id_attinenze,guardia,qual_amm,grado,categ,com_app,prov_app,dat_iscr,regione,cogn,nom,dat_nasc,luog_nasc,prov_nasc,citt_res,via,num,cap,prov_res,cf,prof,stato_civ,alt,col_occ,col_cap,gr_sang,RH,not_car,foto,disp,pred_man_armi,pred_guida_veloce,e_mail,e_mail_srv,sesso) VALUES ('" & ult_id_doc & "','" & ult_id_tel & "','" & ult_id_pat & "','" & ult_id_att & "','" & CType(chk_guardia.Checked, String) & "','" & DD_qualamm.SelectedValue & "','" & DD_grado.SelectedValue & "','" & DD_tpsoc.SelectedValue & "','" & DD_sedeapp.SelectedValue.Replace("'", "''") & "','" & DD_provapp.SelectedValue.Replace("'", "''") & "','" & txt_dtisc.Text & "','" & DD_regapp.SelectedValue.Replace("'", "''") & "','" & txt_cogn.Text.Replace("'", "''") & "','" & txt_nom.Text.Replace("'", "''") & "','" & txt_dtnas.Text & "','" & DD_lgnas.SelectedValue.Replace("'", "''") & "','" & DD_provnas.SelectedValue.Replace("'", "''") & "','" & DD_citres.SelectedValue.Replace("'", "''") & "','" & txt_via.Text.Replace("'", "''") & "','" & txt_civ.Text & "','" & txt_cap.Text & "','" & DD_provres.SelectedValue.ToString & "','" & txt_codfis.Text.ToUpper & "','" & txt_prof.Text.ToString & "','" & DD_staciv.SelectedValue.ToString & "','" & txt_alt.Text & "','" & DD_colocc.Text & "','" & DD_colcap.Text & "','" & DD_grsang.SelectedValue & "','" & DD_rh.SelectedValue & "','" & txt_note.Text & "','" & ult_id_fot & "','" & txt_disp.Text.ToString & "','" & DD_predarm.SelectedValue.ToString & "','" & DD_guidvel.SelectedValue.ToString & "','" & txt_mail.Text & "','" & txt_email_srv.Text & "','" & DD_ses.SelectedValue.ToString & "');"
            comm.ExecuteNonQuery()

            comm.CommandText = "SELECT @@IDENTITY AS ultimo_id"
            Dim ult_id_soc As Integer = comm.ExecuteScalar()

            comm.CommandText = "INSERT INTO tbl_accettazione1 (matricola) VALUES ('" & ult_id_soc & "');"
            comm.ExecuteNonQuery()

            Dim tipo_soc As String = DD_tpsoc.SelectedValue

            Dim imp_dov As Decimal = 0
            Dim a As Integer = Now.Year
            Dim dat_isc As Date = txt_dtisc.Text
            Dim matr As Integer = ult_id_soc
            Select Case tipo_soc
                Case "Socio Sostenitore"
                    If dat_isc >= "01/09/" & a And dat_isc <= "31/12/" & a Then
                        imp_dov = "26,00"
                    ElseIf dat_isc >= "01/05/" & a And dat_isc <= "31/08/" & a Then
                        imp_dov = "52,00"
                    Else
                        imp_dov = "78,00"
                    End If
                Case "Socio Benemerito"
                    If dat_isc >= "01/09/" & a And dat_isc <= "31/12/" & a Then
                        imp_dov = "41,00"
                    ElseIf dat_isc >= "01/05/" & a And dat_isc <= "31/08/" & a Then
                        imp_dov = "82,00"
                    Else
                        imp_dov = "123,00"
                    End If
                Case "Socio Junior"
                    If dat_isc >= "01/09/" & a And dat_isc <= "31/12/" & a Then
                        imp_dov = "13,00"
                    ElseIf dat_isc >= "01/05/" & a And dat_isc <= "31/08/" & a Then
                        imp_dov = "26,00"
                    Else
                        imp_dov = "39,00"
                    End If

                Case "Socio Ordinario"
                    If dat_isc >= "01/09/" & a And dat_isc <= "31/12/" & a Then
                        imp_dov = "9,00"
                    ElseIf dat_isc >= "01/05/" & a And dat_isc <= "31/08/" & a Then
                        imp_dov = "18,00"
                    Else
                        imp_dov = "27,00"
                    End If

                Case "Socio Corporate"
                    If dat_isc >= "01/09/" & a And dat_isc <= "31/12/" & a Then
                        imp_dov = "101,00"
                    ElseIf dat_isc >= "01/05/" & a And dat_isc <= "31/08/" & a Then
                        imp_dov = "202,00"
                    Else
                        imp_dov = "303,00"
                    End If

            End Select

            comm.CommandText = "INSERT INTO tbl_versamenti (matricola, anno, imp_dov) VALUES ('" & matr & "', '" & a & "', '" & Replace(imp_dov, ",", ".") & "')"
            comm.ExecuteNonQuery()

            conn.Close()
            If car_foto = 1 Then
                Dim smtpcliente As SmtpClient = New SmtpClient()
                Dim msgemaile As MailMessage = New MailMessage()

                Dim mittentee As MailAddress = New MailAddress("noreply@guardianazionaleambientale.eu", "NOREPLY - Comunicazioni GNA")

                Dim nomefilee As String = Nothing

                ' Preparo il messaggio
                msgemaile.From = mittentee
                msgemaile.To.Add("presidenza@guardianazionaleambientale.eu")
                msgemaile.To.Add("segreteria@guardianazionaleambientale.eu")
                Dim strBodye As String
                msgemaile.Subject = "GNA - Invio Documentazione"
                strBodye = "Ti informo che in data " & Now() & " " & Request.Cookies("SITOGNA")("nome") & " " & Request.Cookies("SITOGNA")("cogn") & " ha inviato un documento per il socio con la matricola " & ult_id_soc & ".<br /><br />"
                strBodye = strBodye & "Tipo documento: Foto.<br /><br />"
                strBodye = strBodye & "In allegato il documento.<br /><br />"
                strBodye = strBodye & "Clicca qui per visionare la modifica: <a href='http://www.guardianazionaleambientale.eu/corr_doc.aspx?matr=" & ult_id_soc & "' target='_blank'>VISIONA</a><br>"
                msgemaile.Body = strBodye
                msgemaile.IsBodyHtml = True
                Dim allegato As Attachment = New Attachment(MapPath("public/documentazione/" & myFoto))
                msgemaile.Attachments.Add(allegato)
                'Imposto il server
                smtpcliente.Host = "smtp.guardianazionaleambientale.eu"
                smtpcliente.Credentials = New System.Net.NetworkCredential("noreply@guardianazionaleambientale.eu", "tGNOrvLpGxL")

                Try
                    'Invio dell'email
                    smtpcliente.Send(msgemaile)
                    Response.Write("Documento inviato all'ufficio preposto per l'accettazione<br><br>")

                Catch ex As Exception

                    Response.Write("Si è verificato un errore durante l'invio<br><br>" & ex.ToString())
                    smtpcliente.Dispose()
                    msgemaile.Dispose()

                Finally

                    If (nomefilee <> Nothing And File.Exists(MapPath(nomefilee))) Then
                        File.Delete(MapPath(nomefilee))
                    End If

                End Try
            End If
            Dim attiv As String
            Dim ind_ip As String = Request.ServerVariables("REMOTE_ADDR")
            attiv = Request.Cookies("SITOGNA")("cogn") & " " & Request.Cookies("SITOGNA")("nome") & " ha inserito un nuovo socio"
            strSql = "INSERT INTO tbl_log (attivita,indirizzo_ip) VALUES ('" & attiv.Replace("'", "''") & "','" & ind_ip & "');"
            comm.CommandText = strSql
            conn.Open()
            comm.ExecuteNonQuery()
            conn.Close()

            'Invio mail
            Dim smtpclient As SmtpClient = New SmtpClient()
            Dim msgemail As MailMessage = New MailMessage()

            Dim mittente As MailAddress = New MailAddress("noreply@guardianazionaleambientale.eu", "NOREPLY - Comunicazioni GNA")

            Dim nomefile As String = Nothing

            ' Preparo il messaggio
            msgemail.From = mittente
            If (ConfigurationManager.AppSettings("DB)").Equals("TEST")) Then
                msgemail.To.Add("test@guardianazionaleambientale.eu")
            Else
                msgemail.To.Add("presidenza@guardianazionaleambientale.eu, segreteria@guardianazionaleambientale.eu, segreteria.nazionale@guardianazionaleambientale.eu, sede.nazionale@guardianazionaleambientale.eu, vicepresidente@guardianazionaleambientale.eu, " + email(DD_regapp.SelectedValue) + "@guardianazionaleambientale.eu, " + email(DD_provapp.SelectedValue) + "@guardianazionaleambientale.eu, distaccamento." + email(DD_sedeapp.SelectedValue) + "@guardianazionaleambientale.eu")

            End If


            Dim strBody As String
            msgemail.Subject = "GNA - Iscrizione nuovo socio"
            strBody = "Vi informo che in data " & Now() & " " & Request.Cookies("SITOGNA")("nome") & " " & Request.Cookies("SITOGNA")("cogn") & " ha inserito un nuovo socio.<br /><br />"
            strBody = strBody & "Matricola: " & ult_id_soc & "<br />"
            strBody = strBody & "Nome: " & txt_nom.Text.Replace("'", "''") & "<br />"
            strBody = strBody & "Cognome: " & txt_cogn.Text.Replace("'", "''") & "<br>"
            strBody = strBody & "Clicca per accettazione: <a href='http://www.guardianazionaleambientale.eu/accet.aspx?matr=" & ult_id_soc & "'>ACCETTAZIONE</a> (Esegui l'accesso all'area riservata prima di cliccare)<br>"
            msgemail.Body = strBody
            msgemail.IsBodyHtml = True

            'Imposto il server
            smtpclient.Host = "smtp.guardianazionaleambientale.eu"
            smtpclient.Credentials = New System.Net.NetworkCredential("noreply@guardianazionaleambientale.eu", "tGNOrvLpGxL")

            Try
                'Invio dell'email
                smtpclient.Send(msgemail)
                messaggio.Text = "Invio effettuato con successo"

            Catch ex As Exception

                messaggio.Text = "Si è verificato un errore durante l'invio" & ex.ToString()
                smtpclient.Dispose()
                msgemail.Dispose()

            Finally

                If (nomefile <> Nothing And File.Exists(MapPath(nomefile))) Then
                    File.Delete(MapPath(nomefile))
                End If

            End Try
            ind_ip = Request.ServerVariables("REMOTE_ADDR")

            attiv = Request.Cookies("SITOGNA")("cogn") & " " & Request.Cookies("SITOGNA")("nome") & " ha inserito un nuovo socio, " & txt_nom.Text & " " & txt_cogn.Text & " matricola " & ult_id_soc
            'Dim strconnrep As String = WebConfigurationManager.ConnectionStrings("GNATEST_ConnectionString").ConnectionString
            Dim connrep As New MySqlConnection(strconn)

            Dim StrSqlrep As String = "INSERT INTO tbl_log (attivita,indirizzo_ip) VALUES ('" & attiv.Replace("'", "''") & "','" & ind_ip & "');"
            Dim commrep As New MySqlCommand(StrSqlrep, connrep)
            connrep.Open()
            commrep.ExecuteNonQuery()
            connrep.Close()

            Session("id_soc") = ult_id_soc
            Response.Redirect("ins_soc.aspx?id_soc=" & ult_id_soc & "")
        End If
    End Sub

    Protected Sub txt_codfis_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codfis.TextChanged
        txt_codfis.Text = txt_codfis.Text.ToUpper()
    End Sub

    Protected Sub txt_cogn_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cogn.TextChanged
        'txt_cogn.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txt_cogn.Text.ToLower)
        'txt_cogn.Text = UCase(Left(txt_cogn.Text, 1)) & LCase(Right(txt_cogn.Text, Len(txt_cogn.Text) - 1))
    End Sub


    Protected Sub txt_cogn_TextChanged1(sender As Object, e As EventArgs)
        txt_cogn.Text = UCase(Left(txt_cogn.Text, 1)) & LCase(Right(txt_cogn.Text, Len(txt_cogn.Text) - 1))
    End Sub

    Function primalettera(stringa As String) As Object

        primalettera = UCase(Left(stringa, 1)) & LCase(Right(stringa, Len(stringa) - 1))

    End Function

End Class