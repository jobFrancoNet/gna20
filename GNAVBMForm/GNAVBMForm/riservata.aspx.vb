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
Imports System.Data


Public Class riservata
    Inherits System.Web.UI.Page
    Public strfile As String = "~/public/documenti/"
    Public strfileAl As String = "~/public/circolari/"
    Public nome As String
    Public cogn As String
    Public qual As String
    Public incarico As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        boxcorsi.Visible = False
        If (Request.Cookies("SITOGNA") Is Nothing) Then
            Response.Redirect("login.aspx")
        Else
            If Request.Cookies("SITOGNA")("cogn") Is Nothing Or Request.Cookies("SITOGNA")("cogn") = "" Then
                Response.Redirect("login.aspx")
            Else

                Dim dInfo As New DirectoryInfo(Server.MapPath("public/documenti"))
                Dim s_user As String
                nome = Request.Cookies("SITOGNA")("nome")
                cogn = Request.Cookies("SITOGNA")("cogn")
                s_user = Request.Cookies("SITOGNA")("s_user")
                qual = Request.Cookies("SITOGNA")("qual")
                incarico = Request.Cookies("SITOGNA")("incarico")
                Dim utente_loggato As String
                utente_loggato = Request.Cookies("SITOGNA")("Utente")

                'verifica se l'utente è autorizzato a vedere visibile l'area corsi nell'area riservata
                MySqlConnection.ClearAllPools()
                Dim strconn_corsi As String = WebConfigurationManager.ConnectionStrings("GNACORSI_ConnectionString").ConnectionString
                Dim conn_corsi As New MySqlConnection(strconn_corsi)
                Dim strsql_corsi As String = "Select * From anagrafica_autorizzazioni where BINARY UserId = '" & utente_loggato & "'"
                Dim comm_corsi As New MySqlCommand(strsql_corsi, conn_corsi)

                conn_corsi.Open()

                Dim rs As MySqlDataReader = comm_corsi.ExecuteReader()

                If (rs.Read()) Then
                    boxcorsi.Visible = True
                End If

                rs.Close()


                If s_user = "True" Then
                    MultiView1.ActiveViewIndex = 0
                    If qual = "Presidente" Or qual = "Segreteria Presidente" Or qual = "WebMaster" Then
                        HyperLink7.Visible = True
                        HyperLink8.Visible = True
                        HyperLink9.Visible = True
                    Else
                        HyperLink7.Visible = False
                        HyperLink8.Visible = False
                        HyperLink9.Visible = False
                    End If
                Else
                    Select Case qual
                        Case "Aspirante", "Agente", "Agente Scelto", "Assistente", "Assistente Capo"
                            MultiView1.ActiveViewIndex = 2
                        Case "Controllori ASSO"
                            MultiView1.ActiveViewIndex = 3
                            Panel1.Visible = False
                            ticketButton.Visible = False
                        Case Else
                            MultiView1.ActiveViewIndex = 1
                    End Select
                End If

                'Effettuo il Databinding sul controllo Datagrid
                DataList1.DataSource = dInfo.GetFiles()
                DataList1.DataBind()
                Dim ind_ip As String = Request.ServerVariables("REMOTE_ADDR")
                Dim attiv As String
                attiv = Request.Cookies("SITOGNA")("cogn") & " " & Request.Cookies("SITOGNA")("nome") & " ha effettuato l'accesso all'area riservata"
                Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
                Dim conn As New MySqlConnection(strconn)

                Dim StrSql As String = "INSERT INTO tbl_log (attivita,indirizzo_ip) VALUES ('" & attiv.Replace("'", "''") & "','" & ind_ip & "');"
                Dim comm As New MySqlCommand(StrSql, conn)
                conn.Open()
                comm.ExecuteNonQuery()
                conn.Close()
            End If

        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If (Not Request.Cookies("SITOGNA") Is Nothing) Then
            Dim myCookie As HttpCookie
            myCookie = New HttpCookie("SITOGNA")
            myCookie.Expires = DateTime.Now.AddMinutes(-60)
            Response.Cookies.Add(myCookie)
            Response.Redirect("login.aspx")
        End If

    End Sub

    Protected Sub MultiView1_ActiveViewChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MultiView1.ActiveViewChanged

    End Sub

    Protected Sub DataList2_ItemDataBound(sender As Object, e As DataListItemEventArgs) Handles DataList2.ItemDataBound
        Dim DR As DataRowView = CType(e.Item.DataItem, DataRowView)
        If (Not (DR) Is Nothing) Then
            Dim allg As String
            If IsDBNull(DR.Row.ItemArray.GetValue(5)) Then
                allg = ""
            Else
                allg = CType(DR.Row.ItemArray.GetValue(5), String)
            End If

            If allg = "" Then
                Dim btnAl As HyperLink
                btnAl = CType(e.Item.FindControl("HyperLink2"), HyperLink)
                btnAl.Visible = False
            Else
                Dim btnAl As HyperLink
                btnAl = CType(e.Item.FindControl("HyperLink2"), HyperLink)
                btnAl.Visible = True
            End If
        End If
    End Sub

    Protected Sub DataList2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DataList2.SelectedIndexChanged

    End Sub

    Protected Sub DataList3_ItemDataBound(sender As Object, e As DataListItemEventArgs) Handles DataList3.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim dimG As HiddenField = CType(e.Item.FindControl("dimgHF"), HiddenField)
            Dim dimS As HiddenField = CType(e.Item.FindControl("dimsHF"), HiddenField)
            Dim sosp As HiddenField = CType(e.Item.FindControl("sospHF"), HiddenField)
            Dim espul As HiddenField = CType(e.Item.FindControl("espulHF"), HiddenField)
            Dim MotSosp As HiddenField = CType(e.Item.FindControl("motivo_sospHF"), HiddenField)
            Dim MotEspul As HiddenField = CType(e.Item.FindControl("motivo_espulHF"), HiddenField)
            Dim decadenza As HiddenField = CType(e.Item.FindControl("decadenzaHF"), HiddenField)
            Dim motivoLBL As Label = CType(e.Item.FindControl("motivazioneLabel"), Label)
            If dimG.Value = "True" Then
                motivoLBL.Text = "Dimissione da guardia"
                If dimS.Value = "True" Then
                    motivoLBL.Text = "Dimissione da guardia e da socio"
                End If
            ElseIf dimS.Value = "True" Then
                motivoLBL.Text = "Dimissione da socio"
            ElseIf sosp.Value = "True" Then
                motivoLBL.Text = MotSosp.Value
            ElseIf espul.Value = "True" Then
                motivoLBL.Text = MotEspul.Value
            ElseIf decadenza.Value = "True" Then
                motivoLBL.Text = "Decaduto in base all'art 14 dello Statuto Nazionale"
            End If
        End If
    End Sub

    Protected Sub DataList5_ItemDataBound(sender As Object, e As DataListItemEventArgs) Handles DataList5.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim dimG As HiddenField = CType(e.Item.FindControl("dimgHF"), HiddenField)
            Dim dimS As HiddenField = CType(e.Item.FindControl("dimsHF"), HiddenField)
            Dim sosp As HiddenField = CType(e.Item.FindControl("sospHF"), HiddenField)
            Dim espul As HiddenField = CType(e.Item.FindControl("espulHF"), HiddenField)
            Dim MotSosp As HiddenField = CType(e.Item.FindControl("motivo_sospHF"), HiddenField)
            Dim MotEspul As HiddenField = CType(e.Item.FindControl("motivo_espulHF"), HiddenField)
            Dim decadenza As HiddenField = CType(e.Item.FindControl("decadenzaHF"), HiddenField)
            Dim motivoLBL As Label = CType(e.Item.FindControl("motivazioneLabel"), Label)
            If dimG.Value = "True" Then
                motivoLBL.Text = "Dimissione da guardia"
                If dimS.Value = "True" Then
                    motivoLBL.Text = "Dimissione da guardia e da socio"
                End If
            ElseIf dimS.Value = "True" Then
                motivoLBL.Text = "Dimissione da socio"
            ElseIf sosp.Value = "True" Then
                motivoLBL.Text = MotSosp.Value
            ElseIf espul.Value = "True" Then
                motivoLBL.Text = MotEspul.Value
            ElseIf decadenza.Value = "True" Then
                motivoLBL.Text = "Decaduto in base all'art 14 dello Statuto Nazionale"
            End If
        End If
    End Sub

    Protected Sub DataList7_ItemDataBound(sender As Object, e As DataListItemEventArgs) Handles DataList7.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim dimG As HiddenField = CType(e.Item.FindControl("dimgHF"), HiddenField)
            Dim dimS As HiddenField = CType(e.Item.FindControl("dimsHF"), HiddenField)
            Dim sosp As HiddenField = CType(e.Item.FindControl("sospHF"), HiddenField)
            Dim espul As HiddenField = CType(e.Item.FindControl("espulHF"), HiddenField)
            Dim MotSosp As HiddenField = CType(e.Item.FindControl("motivo_sospHF"), HiddenField)
            Dim MotEspul As HiddenField = CType(e.Item.FindControl("motivo_espulHF"), HiddenField)
            Dim decadenza As HiddenField = CType(e.Item.FindControl("decadenzaHF"), HiddenField)
            Dim motivoLBL As Label = CType(e.Item.FindControl("motivazioneLabel"), Label)
            If dimG.Value = "True" Then
                motivoLBL.Text = "Dimissione da guardia"
                If dimS.Value = "True" Then
                    motivoLBL.Text = "Dimissione da guardia e da socio"
                End If
            ElseIf dimS.Value = "True" Then
                motivoLBL.Text = "Dimissione da socio"
            ElseIf sosp.Value = "True" Then
                motivoLBL.Text = MotSosp.Value
            ElseIf espul.Value = "True" Then
                motivoLBL.Text = MotEspul.Value
            ElseIf decadenza.Value = "True" Then
                motivoLBL.Text = "Decaduto in base all'art 14 dello Statuto Nazionale"
            End If
        End If
    End Sub


End Class
