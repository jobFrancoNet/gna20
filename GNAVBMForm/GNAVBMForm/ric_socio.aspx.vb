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
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Public Class ric_socio
    Inherits System.Web.UI.Page
    Public text_ric As String
    Public DD_ric As String
    Public lbl_ric As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Request.Cookies("SITOGNA") Is Nothing) Then
            Response.Redirect("login.aspx")
        Else
            If Request.Cookies("SITOGNA")("cogn") Is Nothing Or Request.Cookies("SITOGNA")("cogn") = "" Then
                Response.Redirect("login.aspx")
            Else
                If Not Page.IsPostBack Then
                    Dim ind_ip As String = Request.ServerVariables("REMOTE_ADDR")
                    Dim attiv As String
                    attiv = Request.Cookies("SITOGNA")("cogn") & " " & Request.Cookies("SITOGNA")("nome") & " è entrato nella pagina di ricerca socio"
                    Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
                    Dim conn As New MySqlConnection(strconn)

                    Dim StrSql As String = "INSERT INTO tbl_log (attivita,indirizzo_ip) VALUES ('" & attiv.Replace("'", "''") & "','" & ind_ip & "');"
                    Dim comm As New MySqlCommand(StrSql, conn)
                    conn.Open()
                    comm.ExecuteNonQuery()
                    conn.Close()
                End If
                Dim grado As String = Request.Cookies("SITOGNA")("qual")
                Dim incarico As String = Request.Cookies("SITOGNA")("incarico")
                Select Case grado
                    Case "Presidente", "Segreteria Presidente", "Dirigente Generale Superiore ", "Dirigente Generale Nazionale", "Dirigente Generale Nazionale Vicario", "Amministrativo Nazionale", "Dirigente Generale Interregionale", "Dirigente Interregionale Centro", "Dirigente Interregionale CentroNord", "Dirigente Interregionale CentroSud", "Dirigente Interregionale Isole", "Dirigente Nazionale di Settore", "WebMaster", "Dirigente Generale DGSF", "Dirigente Nazionale DVSF", "Webmaster"
                        MultiView1.ActiveViewIndex = 0
                        If grado = "Presidente" Or grado = "Segreteria Presidente" Or grado = "WebMaster" Then
                            'Button9.Enabled = True
                            'Button14.Enabled = True
                            soc_ord.Visible = True
                            ricicloCheckBox.Visible = True
                        End If
                        Select Case grado
                            Case "Dirigente Interregionale Centro"
                                DS_regione.SelectCommand = "SELECT DISTINCT regione FROM tbl_sedi WHERE interregionale = 'Centro' ORDER BY regione ASC"
                                DS_provincia.SelectCommand = "SELECT DISTINCT provincia FROM tbl_sedi WHERE interregionale = 'Centro' AND provincia <> '' ORDER BY provincia ASC"
                                DS_sede.SelectCommand = "SELECT DISTINCT sede FROM tbl_sedi WHERE interregionale = 'Centro' AND sede <> '' ORDER BY sede ASC"
                                Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
                                Dim conn As New MySqlConnection(strconn)

                                Dim StrSql As String = "SELECT DISTINCT regione FROM tbl_sedi WHERE interregionale = 'Centro' ORDER BY regione ASC"
                                Dim comm As New MySqlCommand(StrSql, conn)
                                conn.Open()
                                Dim rs As MySqlDataReader = comm.ExecuteReader
                                Dim WhereCond As String = ""
                                While rs.Read
                                    WhereCond = WhereCond & "regione='" & rs("regione").ToString & "' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False' OR "
                                End While
                                WhereCond = WhereCond.Trim()
                                If WhereCond.ToUpper().EndsWith("OR") Then
                                    WhereCond = WhereCond.Remove(WhereCond.Length - 2, 2)
                                End If
                                conn.Close()
                                If Not Page.IsPostBack Then
                                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE " & WhereCond & " AND categ<>'Socio Ordinario' ORDER BY id_socio ASC;"
                                    'DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCond & "dim_g='True' OR " & WhereCond & "dim_s='True' OR " & WhereCond & "espulsione='True' OR " & WhereCond & "sospensione='True'"
                                End If

                            Case "Dirigente Interregionale CentroNord"
                                DS_regione.SelectCommand = "SELECT DISTINCT regione FROM tbl_sedi WHERE interregionale = 'CentroNord' ORDER BY regione ASC"
                                DS_provincia.SelectCommand = "SELECT DISTINCT provincia FROM tbl_sedi WHERE interregionale = 'CentroNord' AND provincia <> '' ORDER BY provincia ASC"
                                DS_sede.SelectCommand = "SELECT DISTINCT sede FROM tbl_sedi WHERE interregionale = 'CentroNord' AND sede <> '' ORDER BY sede ASC"
                                Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
                                Dim conn As New MySqlConnection(strconn)

                                Dim StrSql As String = "SELECT DISTINCT regione FROM tbl_sedi WHERE interregionale = 'CentroNord' ORDER BY regione ASC"
                                Dim comm As New MySqlCommand(StrSql, conn)
                                conn.Open()
                                Dim rs As MySqlDataReader = comm.ExecuteReader
                                Dim WhereCond As String = ""
                                While rs.Read
                                    WhereCond = WhereCond & "regione='" & rs("regione").ToString & "' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False' OR "
                                End While
                                WhereCond = WhereCond.Trim()
                                If WhereCond.ToUpper().EndsWith("OR") Then
                                    WhereCond = WhereCond.Remove(WhereCond.Length - 2, 2)
                                End If
                                conn.Close()
                                If Not Page.IsPostBack Then
                                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE " & WhereCond & " ORDER BY id_socio ASC;"
                                    'DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCond & "dim_g='True' OR " & WhereCond & "dim_s='True' OR " & WhereCond & "espulsione='True' OR " & WhereCond & "sospensione='True'"
                                    Dim stringa As String = "SELECT * FROM tbl_socio1 WHERE " & WhereCond & " ORDER BY id_socio ASC;"
                                    'Response.Write(stringa)
                                End If
                            Case "Dirigente Interregionale CentroSud"
                                DS_regione.SelectCommand = "SELECT DISTINCT regione FROM tbl_sedi WHERE interregionale = 'CentroSud' ORDER BY regione ASC"
                                DS_provincia.SelectCommand = "SELECT DISTINCT provincia FROM tbl_sedi WHERE interregionale = 'CentroSud' AND provincia <> '' ORDER BY provincia ASC"
                                DS_sede.SelectCommand = "SELECT DISTINCT sede FROM tbl_sedi WHERE interregionale = 'CentroSud' AND sede <> '' ORDER BY sede ASC"
                                Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
                                Dim conn As New MySqlConnection(strconn)

                                Dim StrSql As String = "SELECT DISTINCT regione FROM tbl_sedi WHERE interregionale = 'CentroSud' ORDER BY regione ASC"
                                Dim comm As New MySqlCommand(StrSql, conn)
                                conn.Open()
                                Dim rs As MySqlDataReader = comm.ExecuteReader
                                Dim WhereCond As String = ""
                                While rs.Read
                                    WhereCond = WhereCond & "regione='" & rs("regione").ToString & "' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False' OR "
                                End While
                                WhereCond = WhereCond.Trim()
                                If WhereCond.ToUpper().EndsWith("OR") Then
                                    WhereCond = WhereCond.Remove(WhereCond.Length - 2, 2)
                                End If
                                conn.Close()
                                If Not Page.IsPostBack Then
                                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE " & WhereCond & "ORDER BY id_socio ASC;"
                                    'DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCond & "dim_g='True' OR " & WhereCond & "dim_s='True' OR " & WhereCond & "espulsione='True' OR " & WhereCond & "sospensione='True'"
                                    Dim stringa As String = "SELECT * FROM tbl_socio1 WHERE " & WhereCond & "ORDER BY id_socio ASC;"
                                    'Response.Write(stringa)
                                End If
                            Case "Dirigente Interregionale Isole"
                                DS_regione.SelectCommand = "SELECT DISTINCT regione FROM tbl_sedi WHERE interregionale = 'Isole' ORDER BY regione ASC"
                                DS_provincia.SelectCommand = "SELECT DISTINCT provincia FROM tbl_sedi WHERE interregionale = 'Isole' AND provincia <> '' ORDER BY provincia ASC"
                                DS_sede.SelectCommand = "SELECT DISTINCT sede FROM tbl_sedi WHERE interregionale = 'Isole' AND sede <> '' ORDER BY sede ASC"
                                Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
                                Dim conn As New MySqlConnection(strconn)

                                Dim StrSql As String = "SELECT DISTINCT regione FROM tbl_sedi WHERE interregionale = 'Isole' ORDER BY regione ASC"
                                Dim comm As New MySqlCommand(StrSql, conn)
                                conn.Open()
                                Dim rs As MySqlDataReader = comm.ExecuteReader
                                Dim WhereCond As String = ""
                                While rs.Read
                                    WhereCond = WhereCond & "regione='" & rs("regione").ToString & "' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False' OR "
                                End While
                                WhereCond = WhereCond.Trim()
                                If WhereCond.ToUpper().EndsWith("OR") Then
                                    WhereCond = WhereCond.Remove(WhereCond.Length - 2, 2)
                                End If
                                conn.Close()
                                If Not Page.IsPostBack Then
                                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE " & WhereCond & "ORDER BY id_socio ASC;"
                                    'DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCond & "dim_g='True' OR " & WhereCond & "dim_s='True' OR " & WhereCond & "espulsione='True' OR " & WhereCond & "sospensione='True'"
                                    Dim stringa As String = "SELECT * FROM tbl_socio1 WHERE " & WhereCond & "ORDER BY id_socio ASC;"
                                    'Response.Write(stringa)
                                End If
                            Case "Dirigente Nazionale di Settore", "Dirigente Nazionale DVSF", "Dirigente Generale DGSF"
                                Dim settore As String = Request.Cookies("SITOGNA")("settore")
                                Select Case settore
                                    Case "Ambiente"
                                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.ambiente='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                        Label8.Text = "SETTORE AMBIENTE"
                                    Case "Vigilanza"
                                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.vigilanza='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                        Label8.Text = "SETTORE VIGILANZA"
                                    Case "Stampa e diffusione"
                                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.stampa_diff='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                        Label8.Text = "SETTORE STAMPA E DIFFUSIONE"
                                    Case "Formazione"
                                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.formazione='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                        Label8.Text = "SETTORE FORMAZIONE"
                                    Case "Protezione Civile"
                                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.prot_civ='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                        Label8.Text = "SETTORE PROTEZIONE CIVILE"
                                    Case "Intelligence"
                                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.intelligence='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                        Label8.Text = "SETTORE INTELLIGENCE"
                                    Case "Pari Opportunità"
                                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.pari_opp='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                        Label8.Text = "SETTORE PARI OPPORTUNITA'"
                                    Case "Sanità"
                                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.sanita='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                        Label8.Text = "COMPARTO SANITA'"
                                    Case "Culto Religione Cattolica"
                                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.culto_rel='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                        Label8.Text = "SETTORE CULTO RELIGIONE CATTOLICA"
                                    Case "Found Raising"
                                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.fondi='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                        Label8.Text = "SETTORE FOUND RAISING"
                                    Case "Sport e Specialità"
                                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.sport='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                        Label8.Text = "SETTORE SPORT E SPECIALITA'"
                                    Case "Incombenze Interne e Disciplinare"
                                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.disciplinare='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                        Label8.Text = "SETTORE INCOMBENZE INTERNE E DISPICLINARE"
                                    Case "Rapporti con gli Stati Maggiori"
                                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.statimaggiori='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                        Label8.Text = "SETTORE RAPPORTI CON GLI STATI MAGGIORI"
                                    Case "Relazioni Istituzionali"
                                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.rel_istit='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                        Label8.Text = "SETTORE RELAZIONI ISTITUZIONALI"
                                    Case "DAP – Dipartimento Attività Promozionali"
                                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.dap='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                        Label8.Text = "SETTORE DIPARTIMENTO ATTIVITA' PROMOZIONALI"
                                    Case "RIA – Reparto Investigazioni Ambientali"
                                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.ria='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                        Label8.Text = "SETTORE REPARTO INVESTIGAZIONI AMBIENTALI"
                                    Case "RAS – Raggruppamento Analisi Scientifiche"
                                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.ras='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                        Label8.Text = "SETTORE RAGGRUPPAMENTO ANALISI SCIENTIFICHE"
                                    Case "Equipaggiamenti Individuali"
                                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.equipaggiamenti='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                        Label8.Text = "SETTORE EQUIPAGGIAMENTI INDIVIDUALI"
                                    Case "Trasporti Terrestri"
                                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.trasporti_ter='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                        Label8.Text = "SETTORE TRASPORTI TERRESTRI"
                                    Case "Trasporti Aereo Navali"
                                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.t_aereonavale='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                        Label8.Text = "SETTORE TRASPORTI AEREO NAVALI"
                                    Case "Ricerca Scientifica"
                                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.ricerca='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                        Label8.Text = "SETTORE RICERCA SCIENTIFICA"
                                    Case "Rapporti con gli Stati Esteri"
                                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.esteri='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                        Label8.Text = "SETTORE RAPPORTI CON GLI STATI ESTERI"
                                    Case "Segreteria Nazionale"
                                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' AND reciclabile = 'False' ORDER BY id_socio ASC;"
                                        Label8.Text = "SETTORE SEGRETERIA NAZIONALE"
                                End Select
                            Case Else
                                If Not Page.IsPostBack Then
                                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' AND reciclabile = 'False' ORDER BY id_socio ASC;"
                                    DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE dim_g='True' OR dim_s='True' OR espulsione='True' OR sospensione='True'"
                                End If
                        End Select


                    Case "Dirigente Regionale", "Dirigente Regionale Vicario", "Amministrativo Regionale", "Dirigente Regionale di Settore"
                        MultiView1.ActiveViewIndex = 1
                        Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
                        Dim conn As New MySqlConnection(strconn)
                        Dim strSql As String
                        Dim matricola As String = Request.Cookies("SITOGNA")("matricola")
                        strSql = "SELECT * FROM tbl_socio1 WHERE id_socio = '" & matricola & "';"
                        Dim comm As New MySqlCommand(strSql, conn)
                        conn.Open()
                        Dim rs As MySqlDataReader = comm.ExecuteReader
                        If rs.Read Then
                            Dim reg_ric As String = rs("regione")
                            Dim prov_ric As String = rs("prov_app")
                            Dim sede_ric As String = rs("com_app")
                            lbl_regione.Text = reg_ric
                        End If
                        rs.Close()
                        conn.Close()
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE regione = '" & lbl_regione.Text & "' AND categ <> 'Socio Ordinario' AND reciclabile = 'False' AND (Grado = 'Aspirante' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Agente' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Agente Scelto' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Assistente' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Assistente Capo' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Vice Responsabile Distaccamento' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Responsabile di Distaccamento' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Dirigente Provinciale di Settore' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Dirigente Provinciale Vicario' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Dirigente Provinciale' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Dirigente Regionale di Settore' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Dirigente Regionale Vicario' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Dirigente Regionale' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False') ORDER BY id_socio ASC;"
                        DS_provincia2.SelectCommand = "SELECT DISTINCT provincia, regione FROM tbl_sedi WHERE regione = '" & lbl_regione.Text & "' ORDER BY provincia ASC;"
                        DS_sede2.SelectCommand = "SELECT DISTINCT sede, regione FROM tbl_sedi WHERE regione = '" & lbl_regione.Text & "' ORDER BY sede ASC;"
                    Case "Dirigente Provinciale", "Dirigente Provinciale Vicario", "Dirigente Provinciale di Settore", "Amministrativo Provinciale"
                        MultiView1.ActiveViewIndex = 2
                        Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
                        Dim conn As New MySqlConnection(strconn)
                        Dim strSql As String
                        Dim matricola As String = Request.Cookies("SITOGNA")("matricola")
                        strSql = "SELECT * FROM tbl_socio1 WHERE id_socio = '" & matricola & "';"
                        Dim comm As New MySqlCommand(strSql, conn)
                        conn.Open()
                        Dim rs As MySqlDataReader = comm.ExecuteReader
                        If rs.Read Then
                            Dim reg_ric As String = rs("regione")
                            Dim prov_ric As String = rs("prov_app")
                            Dim sede_ric As String = rs("com_app")
                            lbl_prov.Text = prov_ric
                            lbl_regione2.Text = reg_ric
                        End If
                        rs.Close()
                        conn.Close()
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE prov_app = '" & lbl_prov.Text & "' AND categ <> 'Socio Ordinario' AND reciclabile = 'False' AND (Grado = 'Aspirante' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Agente' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Agente Scelto' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Assistente' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Assistente Capo' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Vice Responsabile Distaccamento' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Responsabile di Distaccamento' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Dirigente Provinciale di Settore' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Dirigente Provinciale Vicario' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Dirigente Provinciale' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False') ORDER BY id_socio ASC;"
                        DS_sede3.SelectCommand = "SELECT DISTINCT sede, provincia FROM tbl_sedi WHERE provincia = '" & lbl_prov.Text & "' ORDER BY sede ASC;"
                    Case "Responsabile di Distaccamento", "Vice Responsabile Distaccamento", "Amministrativo Distaccamento"
                        MultiView1.ActiveViewIndex = 3
                        Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
                        Dim conn As New MySqlConnection(strconn)
                        Dim strSql As String
                        Dim matricola As String = Request.Cookies("SITOGNA")("matricola")
                        strSql = "SELECT * FROM tbl_socio1 WHERE id_socio = '" & matricola & "';"
                        Dim comm As New MySqlCommand(strSql, conn)
                        conn.Open()
                        Dim rs As MySqlDataReader = comm.ExecuteReader
                        If rs.Read Then
                            Dim reg_ric As String = rs("regione")
                            Dim prov_ric As String = rs("prov_app")
                            Dim sede_ric As String = rs("com_app")
                            lbl_prov2.Text = prov_ric
                            lbl_regione3.Text = reg_ric
                            lbl_sede.Text = sede_ric
                        End If
                        rs.Close()
                        conn.Close()
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE com_app = '" & lbl_sede.Text & "' AND categ <> 'Socio Ordinario' AND reciclabile = 'False' AND (Grado = 'Aspirante' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Agente' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Agente Scelto' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Assistente' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Assistente Capo' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Vice Responsabile Distaccamento' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Responsabile di Distaccamento' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Dirigente Intermedio' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False') ORDER BY id_socio ASC;"
                    Case "Dirigente Intermedio"
                        MultiView1.ActiveViewIndex = 4
                        Dim whereCla As String = ""
                        Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
                        Dim conn As New MySqlConnection(strconn)
                        Dim strSql As String
                        Dim matricola As String = Request.Cookies("SITOGNA")("matricola")
                        strSql = "SELECT * FROM tbl_gruppidist WHERE matricola = '" & matricola & "';"
                        Dim comm As New MySqlCommand(strSql, conn)
                        conn.Open()
                        Dim rs As MySqlDataReader = comm.ExecuteReader
                        Dim List As System.Web.UI.WebControls.ListItem
                        If Not Page.IsPostBack Then
                            DD_sedi.Items.Clear()
                            List = New WebControls.ListItem("", "", True)
                            DD_sedi.Items.Add(List)
                        End If
                        While rs.Read
                            If Not Page.IsPostBack Then
                                List = New WebControls.ListItem(rs("sede"), rs("sede"), True)
                                DD_sedi.Items.Add(List)
                            End If
                            whereCla = whereCla & "com_app = '" & rs("sede") & "' OR "
                        End While
                        whereCla = whereCla.Trim()
                        If whereCla.ToUpper().EndsWith("OR") Then
                            whereCla = whereCla.Remove(whereCla.Length - 3, 3)
                        End If
                        rs.Close()
                        conn.Close()
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE (" & whereCla & ") AND categ <> 'Socio Ordinario' AND reciclabile = 'False' AND (Grado = 'Aspirante' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Agente' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Agente Scelto' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Assistente' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Assistente Capo' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Vice Responsabile Distaccamento' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' OR Grado = 'Responsabile di Distaccamento' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'OR Grado = 'Dirigente Intermedio' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False') ORDER BY id_socio ASC;"

                    Case Else
                        Pan_ricerca.Visible = False
                        GridView1.Visible = False
                        Response.Write("CI SONO PROBLEMI DI RICONOSCIMENTO. RIESEGUI IL LOGIN")
                End Select
            End If
        End If
    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim WhereCondition As String = ""
        Dim ctrl As Control
        For Each ctrl In Pan_ricerca.Controls
            If TypeOf (ctrl) Is TextBox Then
                If Not CType(ctrl, TextBox).Text.Equals("") Then
                    If CType(ctrl, TextBox).ToolTip.Equals("id_socio") Then
                        WhereCondition = WhereCondition & CType(ctrl, TextBox).ToolTip.ToString() & " = '" & CType(ctrl, TextBox).Text.ToString() & "' AND "
                    Else
                        text_ric = Replace(CType(ctrl, TextBox).Text.ToString(), "'", "''")
                        WhereCondition = WhereCondition & CType(ctrl, TextBox).ToolTip.ToString() & " LIKE '%" & text_ric & "%' AND "
                    End If

                End If
            ElseIf TypeOf (ctrl) Is DropDownList Then
                If Not CType(ctrl, DropDownList).ToolTip.Equals("settore") Then
                    If Not CType(ctrl, DropDownList).SelectedValue.Equals("") Then
                        DD_ric = Replace(CType(ctrl, DropDownList).SelectedValue.ToString(), "'", "''")
                        WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & DD_ric & "' AND "
                    End If
                End If


            ElseIf TypeOf (ctrl) Is Label Then
                If Not CType(ctrl, Label).Text.Equals("") Then
                    lbl_ric = Replace(CType(ctrl, Label).Text.ToString(), "'", "''")
                    WhereCondition = WhereCondition & CType(ctrl, Label).ToolTip.ToString() & " = '" & lbl_ric & "' AND "
                End If
            ElseIf TypeOf (ctrl) Is CheckBox Then
                If CType(ctrl, CheckBox).ID.Equals("soc_ord") Then
                    If CType(ctrl, CheckBox).Visible = True Then
                        If CType(ctrl, CheckBox).Checked = False Then
                            WhereCondition = WhereCondition & " categ <> 'Socio Ordinario' AND "
                        Else
                            WhereCondition = WhereCondition & " categ LIKE '%Socio%' AND "
                        End If
                    Else
                        WhereCondition = WhereCondition & " categ <> 'Socio Ordinario' AND "
                    End If
                End If
                If CType(ctrl, CheckBox).ID.Equals("ricicloCheckBox") Then
                    If CType(ctrl, CheckBox).Visible = True Then
                        If CType(ctrl, CheckBox).Checked = False Then
                            WhereCondition = WhereCondition & " reciclabile = 'False' AND "
                        End If
                    Else
                        WhereCondition = WhereCondition & " reciclabile = 'False' AND "
                    End If
                End If
            End If
        Next
        If CheckBox1.Checked = True Then
            GridView2.Visible = True
            Label3.Visible = True
            Label4.Visible = True
            Label5.Visible = True
            Label6.Visible = True
            Label7.Visible = True
            Image1.Visible = True
            Image2.Visible = True
            Image3.Visible = True
            Image4.Visible = True
        Else
            GridView2.Visible = False
            Label3.Visible = False
            Label4.Visible = False
            Label5.Visible = False
            Label6.Visible = False
            Label7.Visible = False
            Image1.Visible = False
            Image2.Visible = False
            Image3.Visible = False
            Image4.Visible = False
        End If
        WhereCondition = WhereCondition.Trim()
        If WhereCondition.ToUpper().EndsWith("AND") Then
            WhereCondition = WhereCondition.Remove(WhereCondition.Length - 3, 3)
        End If
        Dim grado As String = Request.Cookies("SITOGNA")("qual")
        If WhereCondition = "" Then
            Select Case grado
                Case "Dirigente Interregionale Centro"
                    Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
                    Dim conn As New MySqlConnection(strconn)

                    Dim StrSql As String = "SELECT DISTINCT regione FROM tbl_sedi WHERE interregionale = 'Centro' ORDER BY regione ASC"
                    Dim comm As New MySqlCommand(StrSql, conn)
                    conn.Open()
                    Dim rs As MySqlDataReader = comm.ExecuteReader
                    Dim WhereCond As String = ""
                    Dim WhereCond2 As String = ""
                    While rs.Read
                        WhereCond = WhereCond & "regione='" & rs("regione").ToString & "' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' AND reciclabile = 'False' OR "
                        WhereCond2 = WhereCond2 & "regione='" & rs("regione").ToString & "' AND dim_g='False' OR regione='" & rs("regione").ToString & " AND dim_s='False' OR regione='" & rs("regione").ToString & " AND espulsione='False' OR regione='" & rs("regione").ToString & " AND sospensione='False' OR "
                    End While
                    WhereCond = WhereCond.Trim()
                    If WhereCond.ToUpper().EndsWith("OR") Then
                        WhereCond = WhereCond.Remove(WhereCond.Length - 2, 2)
                    End If
                    WhereCond2 = WhereCond2.Trim()
                    If WhereCond2.ToUpper().EndsWith("OR") Then
                        WhereCond2 = WhereCond2.Remove(WhereCond2.Length - 2, 2)
                    End If
                    conn.Close()
                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE " & WhereCond & "ORDER BY id_socio ASC;"
                    DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCond2 & ""
                Case "Dirigente Interregionale CentroNord"
                    Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
                    Dim conn As New MySqlConnection(strconn)

                    Dim StrSql As String = "SELECT DISTINCT regione FROM tbl_sedi WHERE interregionale = 'CentroNord' ORDER BY regione ASC"
                    Dim comm As New MySqlCommand(StrSql, conn)
                    conn.Open()
                    Dim rs As MySqlDataReader = comm.ExecuteReader
                    Dim WhereCond As String = ""
                    Dim WhereCond2 As String = ""
                    While rs.Read
                        WhereCond = WhereCond & "regione='" & rs("regione").ToString & "' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' AND reciclabile = 'False' OR "
                        WhereCond2 = WhereCond2 & "regione='" & rs("regione").ToString & "' AND dim_g='False' OR regione='" & rs("regione").ToString & " AND dim_s='False' OR regione='" & rs("regione").ToString & " AND espulsione='False' OR regione='" & rs("regione").ToString & " AND sospensione='False' OR "
                    End While
                    WhereCond = WhereCond.Trim()
                    If WhereCond.ToUpper().EndsWith("OR") Then
                        WhereCond = WhereCond.Remove(WhereCond.Length - 2, 2)
                    End If
                    WhereCond2 = WhereCond2.Trim()
                    If WhereCond2.ToUpper().EndsWith("OR") Then
                        WhereCond2 = WhereCond2.Remove(WhereCond2.Length - 2, 2)
                    End If
                    conn.Close()
                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE " & WhereCond & "ORDER BY id_socio ASC;"
                    DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCond2 & ""
                Case "Dirigente Interregionale CentroSud"
                    Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
                    Dim conn As New MySqlConnection(strconn)

                    Dim StrSql As String = "SELECT DISTINCT regione FROM tbl_sedi WHERE interregionale = 'CentroSud' ORDER BY regione ASC"
                    Dim comm As New MySqlCommand(StrSql, conn)
                    conn.Open()
                    Dim rs As MySqlDataReader = comm.ExecuteReader
                    Dim WhereCond As String = ""
                    Dim WhereCond2 As String = ""
                    While rs.Read
                        WhereCond = WhereCond & "regione='" & rs("regione").ToString & "' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' AND reciclabile = 'False' OR "
                        WhereCond2 = WhereCond2 & "regione='" & rs("regione").ToString & "' AND dim_g='False' OR regione='" & rs("regione").ToString & " AND dim_s='False' OR regione='" & rs("regione").ToString & " AND espulsione='False' OR regione='" & rs("regione").ToString & " AND sospensione='False' OR "
                    End While
                    WhereCond = WhereCond.Trim()
                    If WhereCond.ToUpper().EndsWith("OR") Then
                        WhereCond = WhereCond.Remove(WhereCond.Length - 2, 2)
                    End If
                    WhereCond2 = WhereCond2.Trim()
                    If WhereCond2.ToUpper().EndsWith("OR") Then
                        WhereCond2 = WhereCond2.Remove(WhereCond2.Length - 2, 2)
                    End If
                    conn.Close()
                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE " & WhereCond & "ORDER BY id_socio ASC;"
                    DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCond2 & ""
                Case "Dirigente Interregionale Isole"
                    Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
                    Dim conn As New MySqlConnection(strconn)

                    Dim StrSql As String = "SELECT DISTINCT regione FROM tbl_sedi WHERE interregionale = 'Isole' ORDER BY regione ASC"
                    Dim comm As New MySqlCommand(StrSql, conn)
                    conn.Open()
                    Dim rs As MySqlDataReader = comm.ExecuteReader
                    Dim WhereCond As String = ""
                    Dim WhereCond2 As String = ""
                    While rs.Read
                        WhereCond = WhereCond & "regione='" & rs("regione").ToString & "' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' AND reciclabile = 'False' OR "
                        WhereCond2 = WhereCond2 & "regione='" & rs("regione").ToString & "' AND dim_g='False' OR regione='" & rs("regione").ToString & " AND dim_s='False' OR regione='" & rs("regione").ToString & " AND espulsione='False' OR regione='" & rs("regione").ToString & " AND sospensione='False' OR "
                    End While
                    WhereCond = WhereCond.Trim()
                    If WhereCond.ToUpper().EndsWith("OR") Then
                        WhereCond = WhereCond.Remove(WhereCond.Length - 2, 2)
                    End If
                    WhereCond2 = WhereCond2.Trim()
                    If WhereCond2.ToUpper().EndsWith("OR") Then
                        WhereCond2 = WhereCond2.Remove(WhereCond2.Length - 2, 2)
                    End If
                    conn.Close()
                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE " & WhereCond & "ORDER BY id_socio ASC;"
                    DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCond2 & ""
                Case "Dirigente Nazionale di Settore", "Dirigente Nazionale DVSF", "Dirigente Generale DGSF"
                    'Dim settore As String = Request.Cookies("SITOGNA")("settore")
                    Dim settore As String = settoreDropDownList.SelectedValue
                    Select Case settore
                        Case "Ambiente"
                            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.ambiente='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' AND reciclabile = 'False'"
                            DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.ambiente='True' AND dim_g='True' OR tbl_settori.ambiente='True' AND dim_s='True' OR tbl_settori.ambiente='True' AND espulsione='True' OR tbl_settori.ambiente='True' AND sospensione='True'"
                            Label8.Text = "SETTORE AMBIENTE"
                        Case "Vigilanza"
                            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.vigilanza='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' AND reciclabile = 'False'"
                            DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.vigilanza='True' AND dim_g='True' OR tbl_settori.vigilanza='True' AND dim_s='True' OR tbl_settori.vigilanza='True' AND espulsione='True' OR tbl_settori.vigilanza='True' AND sospensione='True'"
                            Label8.Text = "SETTORE VIGILANZA"
                        Case "Stampa e diffusione"
                            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.stampa_diff='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' AND reciclabile = 'False'"
                            DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.stampa_diff='True' AND dim_g='True' OR tbl_settori.stampa_diff='True' AND dim_s='True' OR tbl_settori.stampa_diff='True' AND espulsione='True' OR tbl_settori.stampa_diff='True' AND sospensione='True'"
                            Label8.Text = "SETTORE STAMPA E DIFFUSIONE"
                        Case "Formazione"
                            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.formazione='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' AND reciclabile = 'False'"
                            DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.formazione='True' AND dim_g='True' OR tbl_settori.formazione='True' AND dim_s='True' OR tbl_settori.formazione='True' AND espulsione='True' OR tbl_settori.formazione='True' AND sospensione='True'"
                            Label8.Text = "SETTORE FORMAZIONE"
                        Case "Protezione Civile"
                            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.prot_civ='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' AND reciclabile = 'False'"
                            DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.prot_civ='True' AND dim_g='True' OR tbl_settori.prot_civ='True' AND dim_s='True' OR tbl_settori.prot_civ='True' AND espulsione='True' OR tbl_settori.prot_civ='True' AND sospensione='True'"
                            Label8.Text = "SETTORE PROTEZIONE CIVILE"
                        Case "Intelligence"
                            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.intelligence='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' AND reciclabile = 'False'"
                            DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.intelligence='True' AND dim_g='True' OR tbl_settori.intelligence='True' AND dim_s='True' OR tbl_settori.intelligence='True' AND espulsione='True' OR tbl_settori.intelligence='True' AND sospensione='True'"
                            Label8.Text = "SETTORE INTELLIGENCE"
                        Case "Pari Opportunità"
                            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.pari_opp='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' AND reciclabile = 'False'"
                            DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.pari_opp='True' AND dim_g='True' OR tbl_settori.pari_opp='True' AND dim_s='True' OR tbl_settori.pari_opp='True' AND espulsione='True' OR tbl_settori.pari_opp='True' AND sospensione='True'"
                            Label8.Text = "SETTORE PARI OPPORTUNITA'"
                        Case "Sanità"
                            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.sanita='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' AND reciclabile = 'False'"
                            DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.sanita='True' AND dim_g='True' OR tbl_settori.sanita='True' AND dim_s='True' OR tbl_settori.sanita='True' AND espulsione='True' OR tbl_settori.sanita='True' AND sospensione='True'"
                            Label8.Text = "COMPARTO SANITA'"
                        Case "Culto Religione Cattolica"
                            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.culto_rel='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' AND reciclabile = 'False'"
                            DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.culto_rel='True' AND dim_g='True' OR tbl_settori.culto_rel='True' AND dim_s='True' OR tbl_settori.culto_rel='True' AND espulsione='True' OR tbl_settori.culto_rel='True' AND sospensione='True'"
                            Label8.Text = "SETTORE CULTO RELIGIONE CATTOLICA"
                        Case "Found Raising"
                            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.fondi='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' AND reciclabile = 'False'"
                            DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.fondi='True' AND dim_g='True' OR tbl_settori.fondi='True' AND dim_s='True' OR tbl_settori.fondi='True' AND espulsione='True' OR tbl_settori.fondi='True' AND sospensione='True'"
                            Label8.Text = "SETTORE FOUND RAISING"
                        Case "Sport e Specialità"
                            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.sport='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' AND reciclabile = 'False'"
                            DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.sport='True' AND dim_g='True' OR tbl_settori.sport='True' AND dim_s='True' OR tbl_settori.sport='True' AND espulsione='True' OR tbl_settori.sport='True' AND sospensione='True'"
                            Label8.Text = "SETTORE SPORT E SPECIALITA'"
                        Case "Incombenze Interne e Disciplinare"
                            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.disciplinare='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' AND reciclabile = 'False'"
                            DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.disciplinare='True' AND dim_g='True' OR tbl_settori.disciplinare='True' AND dim_s='True' OR tbl_settori.disciplinare='True' AND espulsione='True' OR tbl_settori.disciplinare='True' AND sospensione='True'"
                            Label8.Text = "SETTORE INCOMBENZE INTERNE E DISPICLINARE"
                        Case "Rapporti con gli Stati Maggiori"
                            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.statimaggiori='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' AND reciclabile = 'False'"
                            DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.statimaggiori='True' AND dim_g='True' OR tbl_settori.statimaggiori='True' AND dim_s='True' OR tbl_settori.statimaggiori='True' AND espulsione='True' OR tbl_settori.statimaggiori='True' AND sospensione='True'"
                            Label8.Text = "SETTORE RAPPORTI CON GLI STATI MAGGIORI"
                        Case "Relazioni Istituzionali"
                            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.rel_istit='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' AND reciclabile = 'False'"
                            DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.rel_istit='True' AND dim_g='True' OR tbl_settori.rel_istit='True' AND dim_s='True' OR tbl_settori.rel_istit='True' AND espulsione='True' OR tbl_settori.rel_istit='True' AND sospensione='True'"
                            Label8.Text = "SETTORE RELAZIONI ISTITUZIONALI"
                        Case "DAP - Dipartimento Attività Promozionali"
                            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.dap='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' AND reciclabile = 'False'"
                            DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.dap='True' AND dim_g='True' OR tbl_settori.dap='True' AND dim_s='True' OR tbl_settori.dap='True' AND espulsione='True' OR tbl_settori.dap='True' AND sospensione='True'"
                            Label8.Text = "SETTORE DIPARTIMENTO ATTIVITA' PROMOZIONALI"
                        Case "RIA - Reparto Investigazioni Ambientali"
                            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.ria='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' AND reciclabile = 'False'"
                            DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.ria='True' AND dim_g='True' OR tbl_settori.ria='True' AND dim_s='True' OR tbl_settori.ria='True' AND espulsione='True' OR tbl_settori.ria='True' AND sospensione='True'"
                            Label8.Text = "SETTORE REPARTO INVESTIGAZIONI AMBIENTALI"
                        Case "RAS - Raggruppamento Analisi Scientifiche"
                            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.ras='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' AND reciclabile = 'False'"
                            DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.ras='True' AND dim_g='True' OR tbl_settori.ras='True' AND dim_s='True' OR tbl_settori.ras='True' AND espulsione='True' OR tbl_settori.ras='True' AND sospensione='True'"
                            Label8.Text = "SETTORE RAGGRUPPAMENTO ANALISI SCIENTIFICHE"
                        Case "Equipaggiamenti Individuali"
                            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.equipaggiamenti='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' AND reciclabile = 'False'"
                            DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.equipaggiamenti='True' AND dim_g='True' OR tbl_settori.equipaggiamenti='True' AND dim_s='True' OR tbl_settori.equipaggiamenti='True' AND espulsione='True' OR tbl_settori.equipaggiamenti='True' AND sospensione='True'"
                            Label8.Text = "SETTORE EQUIPAGGIAMENTI INDIVIDUALI"
                        Case "Trasporti Terrestri"
                            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.trasporti_ter='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' AND reciclabile = 'False'"
                            DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.trasporti_ter='True' AND dim_g='True' OR tbl_settori.trasporti_ter='True' AND dim_s='True' OR tbl_settori.trasporti_ter='True' AND espulsione='True' OR tbl_settori.trasporti_ter='True' AND sospensione='True'"
                            Label8.Text = "SETTORE TRASPORTI TERRESTRI"
                        Case "Trasporti Aereo Navali"
                            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.t_aereonavale='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' AND reciclabile = 'False'"
                            DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.t_aereonavale='True' AND dim_g='True' OR tbl_settori.t_aereonavale='True' AND dim_s='True' OR tbl_settori.t_aereonavale='True' AND espulsione='True' OR tbl_settori.t_aereonavale='True' AND sospensione='True'"
                            Label8.Text = "SETTORE TRASPORTI AEREO NAVALI"
                        Case "Ricerca Scientifica"
                            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.ricerca='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' AND reciclabile = 'False'"
                            DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.ricerca='True' AND dim_g='True' OR tbl_settori.ricerca='True' AND dim_s='True' OR tbl_settori.ricerca='True' AND espulsione='True' OR tbl_settori.ricerca='True' AND sospensione='True'"
                            Label8.Text = "SETTORE RICERCA SCIENTIFICA"
                        Case "Rapporti con gli Stati Esteri"
                            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.esteri='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' AND reciclabile = 'False'"
                            DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.esteri='True' AND dim_g='True' OR tbl_settori.esteri='True' AND dim_s='True' OR tbl_settori.esteri='True' AND espulsione='True' OR tbl_settori.esteri='True' AND sospensione='True'"
                            Label8.Text = "SETTORE RAPPORTI CON GLI STATI ESTERI"
                        Case "Segreteria Nazionale"
                            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' AND reciclabile = 'False' ORDER BY id_socio ASC;"
                            DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE dim_g='True' OR dim_s='True' OR espulsione='True' OR sospensione='True'"
                            Label8.Text = "SETTORE SEGRETERIA NAZIONALE"
                    End Select
                Case Else
                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' AND reciclabile = 'False' ORDER BY id_socio ASC;"
                    DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE dim_g='True' OR dim_s='True' OR espulsione='True' OR sospensione='True'"
            End Select
        Else
            If grado = "Dirigente Nazionale di Settore" Or grado = "Dirigente Nazionale DVSF" Or grado = "Dirigente Generale DGSF" Then
                'Dim settore As String = Request.Cookies("SITOGNA")("settore")
                Dim settore As String = settoreDropDownList.SelectedValue
                Select Case settore
                    Case "Ambiente"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ambiente='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ambiente='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.ambiente='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.ambiente='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.ambiente='True' AND sospensione='True'"
                        Label8.Text = "SETTORE AMBIENTE"
                    Case "Vigilanza"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.vigilanza='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.vigilanza='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.vigilanza='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.vigilanza='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.vigilanza='True' AND sospensione='True'"
                        Label8.Text = "SETTORE VIGILANZA"
                    Case "Stampa e diffusione"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.stampa_diff='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.stampa_diff='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.stampa_diff='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.stampa_diff='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.stampa_diff='True' AND sospensione='True'"
                        Label8.Text = "SETTORE STAMPA E DIFFUSIONE"
                    Case "Formazione"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.formazione='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.formazione='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.formazione='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.formazione='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.formazione='True' AND sospensione='True'"
                        Label8.Text = "SETTORE FORMAZIONE"
                    Case "Protezione Civile"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.prot_civ='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.prot_civ='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.prot_civ='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.prot_civ='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.prot_civ='True' AND sospensione='True'"
                        Label8.Text = "SETTORE PROTEZIONE CIVILE"
                    Case "Intelligence"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.intelligence='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.intelligence='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.intelligence='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.intelligence='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.intelligence='True' AND sospensione='True'"
                        Label8.Text = "SETTORE INTELLIGENCE"
                    Case "Pari Opportunità"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.pari_opp='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.pari_opp='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.pari_opp='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.pari_opp='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.pari_opp='True' AND sospensione='True'"
                        Label8.Text = "SETTORE PARI OPPORTUNITA'"
                    Case "Sanità"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.sanita='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.sanita='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.sanita='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.sanita='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.sanita='True' AND sospensione='True'"
                        Label8.Text = "COMPARTO SANITA'"
                    Case "Culto Religione Cattolica"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.culto_rel='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.culto_rel='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.culto_rel='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.culto_rel='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.culto_rel='True' AND sospensione='True'"
                        Label8.Text = "SETTORE CULTO RELIGIONE CATTOLICA"
                    Case "Found Raising"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.fondi='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.fondi='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.fondi='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.fondi='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.fondi='True' AND sospensione='True'"
                        Label8.Text = "SETTORE FOUND RAISING"
                    Case "Sport e Specialità"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.sport='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.sport='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.sport='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.sport='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.sport='True' AND sospensione='True'"
                        Label8.Text = "SETTORE SPORT E SPECIALITA'"
                    Case "Incombenze Interne e Disciplinare"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.disciplinare='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.disciplinare='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.disciplinare='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.disciplinare='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.disciplinare='True' AND sospensione='True'"
                        Label8.Text = "SETTORE INCOMBENZE INTERNE E DISPICLINARE"
                    Case "Rapporti con gli Stati Maggiori"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.statimaggiori='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.statimaggiori='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.statimaggiori='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.statimaggiori='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.statimaggiori='True' AND sospensione='True'"
                        Label8.Text = "SETTORE RAPPORTI CON GLI STATI MAGGIORI"
                    Case "Relazioni Istituzionali"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.rel_istit='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.rel_istit='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.rel_istit='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.rel_istit='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.rel_istit='True' AND sospensione='True'"
                        Label8.Text = "SETTORE RELAZIONI ISTITUZIONALI"
                    Case "DAP - Dipartimento Attività Promozionali"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.dap='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.dap='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.dap='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.dap='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.dap='True' AND sospensione='True'"
                        Label8.Text = "SETTORE DIPARTIMENTO ATTIVITA' PROMOZIONALI"
                    Case "RIA - Reparto Investigazioni Ambientali"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ria='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ria='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.ria='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.ria='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.ria='True' AND sospensione='True'"
                        Label8.Text = "SETTORE REPARTO INVESTIGAZIONI AMBIENTALI"
                    Case "RAS - Raggruppamento Analisi Scientifiche"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ras='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ras='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.ras='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.ras='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.ras='True' AND sospensione='True'"
                        Label8.Text = "SETTORE RAGGRUPPAMENTO ANALISI SCIENTIFICHE"
                    Case "Equipaggiamenti Individuali"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.equipaggiamenti='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.equipaggiamenti='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.equipaggiamenti='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.equipaggiamenti='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.equipaggiamenti='True' AND sospensione='True'"
                        Label8.Text = "SETTORE EQUIPAGGIAMENTI INDIVIDUALI"
                    Case "Trasporti Terrestri"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.trasporti_ter='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.trasporti_ter='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.trasporti_ter='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.trasporti_ter='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.trasporti_ter='True' AND sospensione='True'"
                        Label8.Text = "SETTORE TRASPORTI TERRESTRI"
                    Case "Trasporti Aereo Navali"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.t_aereonavale='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.t_aereonavale='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.t_aereonavale='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.t_aereonavale='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.t_aereonavale='True' AND sospensione='True'"
                        Label8.Text = "SETTORE TRASPORTI AEREO NAVALI"
                    Case "Ricerca Scientifica"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ricerca='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCondition & " AND tbl_settori.ricerca='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.ricerca='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.ricerca='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.ricerca='True' AND sospensione='True'"
                        Label8.Text = "SETTORE RICERCA SCIENTIFICA"
                    Case "Rapporti con gli Stati Esteri"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.esteri='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCondition & " AND tbl_settori.esteri='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.esteri='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.esteri='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.esteri='True' AND sospensione='True'"
                        Label8.Text = "SETTORE RAPPORTI CON GLI STATI ESTERI"
                    Case "Segreteria Nazionale"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' ORDER BY id_socio ASC;"
                        DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='True' OR " & WhereCondition & " AND dim_s='True' OR " & WhereCondition & " AND espulsione='True' OR " & WhereCondition & " AND sospensione='True'"
                        Label8.Text = "SETTORE SEGRETERIA NAZIONALE"
                    Case Else
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' ORDER BY id_socio ASC;"
                        DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='True' OR " & WhereCondition & " AND dim_s='True' OR " & WhereCondition & " AND espulsione='True' OR " & WhereCondition & " AND sospensione='True'"
                        Label8.Text = "SETTORE TUTTI"
                End Select
            Else
                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' ORDER BY id_socio ASC;"
                DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='True' OR " & WhereCondition & " AND dim_s='True' OR " & WhereCondition & " AND espulsione='True' OR " & WhereCondition & " AND sospensione='True'"
            End If
        End If
        GridView1.PageIndex = 0
        GridView2.PageIndex = 0
        GridView2.DataBind()
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim WhereCondition As String = ""
        Dim ctrl As Control
        For Each ctrl In Pan_reg.Controls
            If TypeOf (ctrl) Is TextBox Then
                If Not CType(ctrl, TextBox).Text.Equals("") Then
                    If CType(ctrl, TextBox).ToolTip.Equals("id_socio") Then
                        WhereCondition = WhereCondition & CType(ctrl, TextBox).ToolTip.ToString() & " = '" & CType(ctrl, TextBox).Text.ToString() & "' AND "
                    Else
                        text_ric = Replace(CType(ctrl, TextBox).Text.ToString(), "'", "''")
                        WhereCondition = WhereCondition & CType(ctrl, TextBox).ToolTip.ToString() & " LIKE '%" & text_ric & "%' AND "
                    End If

                End If
            ElseIf TypeOf (ctrl) Is DropDownList Then
                If Not CType(ctrl, DropDownList).SelectedValue.Equals("") Then
                    DD_ric = Replace(CType(ctrl, DropDownList).SelectedValue.ToString(), "'", "''")
                    WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & DD_ric & "' AND "
                Else
                    If CType(ctrl, DropDownList).ID.Equals("DD_qual2") Then
                        Dim num_item As Integer = DD_qual2.Items.Count
                        Dim i As Integer
                        DD_qual2.SelectedIndex = 0
                        WhereCondition = WhereCondition & "("
                        For i = 1 To num_item
                            If Not DD_qual2.SelectedValue.Equals("") Then
                                If i = num_item Then
                                    WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & CType(ctrl, DropDownList).SelectedValue.ToString() & "') AND "
                                Else
                                    WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & CType(ctrl, DropDownList).SelectedValue.ToString() & "' OR "
                                End If
                                DD_qual2.SelectedIndex = i
                            Else
                                DD_qual2.SelectedIndex = i
                            End If
                        Next

                        DD_qual2.SelectedIndex = 0
                    End If
                End If
            ElseIf TypeOf (ctrl) Is Label Then
                If Not CType(ctrl, Label).Text.Equals("") Then
                    lbl_ric = Replace(CType(ctrl, Label).Text.ToString(), "'", "''")
                    WhereCondition = WhereCondition & CType(ctrl, Label).ToolTip.ToString() & " = '" & lbl_ric & "' AND "
                End If
            End If

        Next
        WhereCondition = WhereCondition & "categ <> 'Socio Ordinario' AND reciclabile = 'False' AND "
        WhereCondition = WhereCondition.Trim()
        If WhereCondition.ToUpper().EndsWith("AND") Then
            WhereCondition = WhereCondition.Remove(WhereCondition.Length - 3, 3)
        End If
        If WhereCondition.ToUpper().EndsWith("OR") Then
            WhereCondition = WhereCondition.Remove(WhereCondition.Length - 2, 2)
        End If
        If CheckBox2.Checked = True Then
            GridView2.Visible = True
            Label3.Visible = True
            Label4.Visible = True
            Label5.Visible = True
            Label6.Visible = True
            Label7.Visible = True
            Image1.Visible = True
            Image2.Visible = True
            Image3.Visible = True
            Image4.Visible = True
        Else
            GridView2.Visible = False
            Label3.Visible = False
            Label4.Visible = False
            Label5.Visible = False
            Label6.Visible = False
            Label7.Visible = False
            Image1.Visible = False
            Image2.Visible = False
            Image3.Visible = False
            Image4.Visible = False
        End If
        Dim grado As String = Request.Cookies("SITOGNA")("qual")
        Dim settore As String = Request.Cookies("SITOGNA")("settore")
        If WhereCondition = "" Then
            If grado = "Dirigente Regionale di Settore" Then
                Select Case settore
                    Case "Ambiente"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.ambiente='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.ambiente='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.ambiente='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.ambiente='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.ambiente='True' AND sospensione='True'"
                        Label8.Text = "SETTORE AMBIENTE"
                    Case "Vigilanza"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.vigilanza='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.vigilanza='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.vigilanza='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.vigilanza='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.vigilanza='True' AND sospensione='True'"
                        Label8.Text = "SETTORE VIGILANZA"
                    Case "Stampa e diffusione"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.stampa_diff='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.stampa_diff='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.stampa_diff='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.stampa_diff='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.stampa_diff='True' AND sospensione='True'"
                        Label8.Text = "SETTORE STAMPA E DIFFUSIONE"
                    Case "Formazione"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.formazione='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.formazione='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.formazione='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.formazione='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.formazione='True' AND sospensione='True'"
                        Label8.Text = "SETTORE FORMAZIONE"
                    Case "Protezione Civile"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.prot_civ='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.prot_civ='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.prot_civ='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.prot_civ='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.prot_civ='True' AND sospensione='True'"
                        Label8.Text = "SETTORE PROTEZIONE CIVILE"
                    Case "Intelligence"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.intelligence='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.intelligence='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.intelligence='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.intelligence='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.intelligence='True' AND sospensione='True'"
                        Label8.Text = "SETTORE INTELLIGENCE"
                    Case "Pari Opportunità"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.pari_opp='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.pari_opp='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.pari_opp='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.pari_opp='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.pari_opp='True' AND sospensione='True'"
                        Label8.Text = "SETTORE PARI OPPORTUNITA'"
                    Case "Sanità"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.sanita='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.sanita='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.sanita='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.sanita='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.sanita='True' AND sospensione='True'"
                        Label8.Text = "COMPARTO SANITA'"
                    Case "Culto Religione Cattolica"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.culto_rel='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.culto_rel='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.culto_rel='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.culto_rel='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.culto_rel='True' AND sospensione='True'"
                        Label8.Text = "SETTORE CULTO RELIGIONE CATTOLICA"
                    Case "Found Raising"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.fondi='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.fondi='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.fondi='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.fondi='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.fondi='True' AND sospensione='True'"
                        Label8.Text = "SETTORE FOUND RAISING"
                    Case "Sport e Specialità"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.sport='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.sport='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.sport='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.sport='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.sport='True' AND sospensione='True'"
                        Label8.Text = "SETTORE SPORT E SPECIALITA'"
                    Case "Incombenze Interne e Disciplinare"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.disciplinare='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.disciplinare='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.disciplinare='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.disciplinare='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.disciplinare='True' AND sospensione='True'"
                        Label8.Text = "SETTORE INCOMBENZE INTERNE E DISPICLINARE"
                    Case "Rapporti con gli Stati Maggiori"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.statimaggiori='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.statimaggiori='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.statimaggiori='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.statimaggiori='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.statimaggiori='True' AND sospensione='True'"
                        Label8.Text = "SETTORE RAPPORTI CON GLI STATI MAGGIORI"
                    Case "Relazioni Istituzionali"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.rel_istit='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.rel_istit='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.rel_istit='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.rel_istit='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.rel_istit='True' AND sospensione='True'"
                        Label8.Text = "SETTORE RELAZIONI ISTITUZIONALI"
                    Case "DAP – Dipartimento Attività Promozionali"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.dap='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.dap='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.dap='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.dap='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.dap='True' AND sospensione='True'"
                        Label8.Text = "SETTORE DIPARTIMENTO ATTIVITA' PROMOZIONALI"
                    Case "RIA – Reparto Investigazioni Ambientali"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.ria='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.ria='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.ria='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.ria='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.ria='True' AND sospensione='True'"
                        Label8.Text = "SETTORE REPARTO INVESTIGAZIONI AMBIENTALI"
                    Case "RAS – Raggruppamento Analisi Scientifiche"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.ras='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.ras='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.ras='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.ras='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.ras='True' AND sospensione='True'"
                        Label8.Text = "SETTORE RAGGRUPPAMENTO ANALISI SCIENTIFICHE"
                    Case "Equipaggiamenti Individuali"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.equipaggiamenti='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.equipaggiamenti='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.equipaggiamenti='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.equipaggiamenti='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.equipaggiamenti='True' AND sospensione='True'"
                        Label8.Text = "SETTORE EQUIPAGGIAMENTI INDIVIDUALI"
                    Case "Trasporti Terrestri"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.trasporti_ter='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.trasporti_ter='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.trasporti_ter='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.trasporti_ter='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.trasporti_ter='True' AND sospensione='True'"
                        Label8.Text = "SETTORE TRASPORTI TERRESTRI"
                    Case "Trasporti Aereo Navali"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.t_aereonavale='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.t_aereonavale='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.t_aereonavale='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.t_aereonavale='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.t_aereonavale='True' AND sospensione='True'"
                        Label8.Text = "SETTORE TRASPORTI AEREO NAVALI"
                    Case "Ricerca Scientifica"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.ricerca='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.ricerca='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.ricerca='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.ricerca='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.ricerca='True' AND sospensione='True'"
                        Label8.Text = "SETTORE RICERCA SCIENTIFICA"
                    Case "Rapporti con gli Stati Esteri"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.esteri='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.esteri='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.esteri='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.esteri='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.esteri='True' AND sospensione='True'"
                        Label8.Text = "SETTORE RAPPORTI CON GLI STATI ESTERI"
                End Select
            Else
                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE regione = '" & lbl_regione.Text & "' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' ORDER BY id_socio ASC;"
                DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE dim_g='True' OR dim_s='True' OR espulsione='True' OR sospensione='True'"
            End If
        Else
            If grado = "Dirigente Regionale di Settore" Then
                Select Case settore
                    Case "Ambiente"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ambiente='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ambiente='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.ambiente='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.ambiente='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.ambiente='True' AND sospensione='True'"
                        Label8.Text = "SETTORE AMBIENTE"
                    Case "Vigilanza"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.vigilanza='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.vigilanza='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.vigilanza='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.vigilanza='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.vigilanza='True' AND sospensione='True'"
                        Label8.Text = "SETTORE VIGILANZA"
                    Case "Stampa e diffusione"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.stampa_diff='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.stampa_diff='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.stampa_diff='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.stampa_diff='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.stampa_diff='True' AND sospensione='True'"
                        Label8.Text = "SETTORE STAMPA E DIFFUSIONE"
                    Case "Formazione"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.formazione='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.formazione='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.formazione='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.formazione='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.formazione='True' AND sospensione='True'"
                        Label8.Text = "SETTORE FORMAZIONE"
                    Case "Protezione Civile"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.prot_civ='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.prot_civ='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.prot_civ='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.prot_civ='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.prot_civ='True' AND sospensione='True'"
                        Label8.Text = "SETTORE PROTEZIONE CIVILE"
                    Case "Intelligence"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.intelligence='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.intelligence='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.intelligence='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.intelligence='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.intelligence='True' AND sospensione='True'"
                        Label8.Text = "SETTORE INTELLIGENCE"
                    Case "Pari Opportunità"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.pari_opp='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.pari_opp='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.pari_opp='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.pari_opp='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.pari_opp='True' AND sospensione='True'"
                        Label8.Text = "SETTORE PARI OPPORTUNITA'"
                    Case "Sanità"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.sanita='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.sanita='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.sanita='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.sanita='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.sanita='True' AND sospensione='True'"
                        Label8.Text = "COMPARTO SANITA'"
                    Case "Culto Religione Cattolica"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.culto_rel='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.culto_rel='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.culto_rel='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.culto_rel='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.culto_rel='True' AND sospensione='True'"
                        Label8.Text = "SETTORE CULTO RELIGIONE CATTOLICA"
                    Case "Found Raising"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.fondi='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.fondi='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.fondi='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.fondi='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.fondi='True' AND sospensione='True'"
                        Label8.Text = "SETTORE FOUND RAISING"
                    Case "Sport e Specialità"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.sport='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.sport='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.sport='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.sport='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.sport='True' AND sospensione='True'"
                        Label8.Text = "SETTORE SPORT E SPECIALITA'"
                    Case "Incombenze Interne e Disciplinare"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.disciplinare='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.disciplinare='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.disciplinare='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.disciplinare='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.disciplinare='True' AND sospensione='True'"
                        Label8.Text = "SETTORE INCOMBENZE INTERNE E DISPICLINARE"
                    Case "Rapporti con gli Stati Maggiori"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.statimaggiori='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.statimaggiori='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.statimaggiori='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.statimaggiori='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.statimaggiori='True' AND sospensione='True'"
                        Label8.Text = "SETTORE RAPPORTI CON GLI STATI MAGGIORI"
                    Case "Relazioni Istituzionali"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.rel_istit='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.rel_istit='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.rel_istit='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.rel_istit='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.rel_istit='True' AND sospensione='True'"
                        Label8.Text = "SETTORE RELAZIONI ISTITUZIONALI"
                    Case "DAP – Dipartimento Attività Promozionali"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.dap='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.dap='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.dap='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.dap='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.dap='True' AND sospensione='True'"
                        Label8.Text = "SETTORE DIPARTIMENTO ATTIVITA' PROMOZIONALI"
                    Case "RIA – Reparto Investigazioni Ambientali"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ria='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ria='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.ria='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.ria='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.ria='True' AND sospensione='True'"
                        Label8.Text = "SETTORE REPARTO INVESTIGAZIONI AMBIENTALI"
                    Case "RAS – Raggruppamento Analisi Scientifiche"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ras='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ras='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.ras='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.ras='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.ras='True' AND sospensione='True'"
                        Label8.Text = "SETTORE RAGGRUPPAMENTO ANALISI SCIENTIFICHE"
                    Case "Equipaggiamenti Individuali"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.equipaggiamenti='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.equipaggiamenti='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.equipaggiamenti='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.equipaggiamenti='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.equipaggiamenti='True' AND sospensione='True'"
                        Label8.Text = "SETTORE EQUIPAGGIAMENTI INDIVIDUALI"
                    Case "Trasporti Terrestri"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.trasporti_ter='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.trasporti_ter='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.trasporti_ter='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.trasporti_ter='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.trasporti_ter='True' AND sospensione='True'"
                        Label8.Text = "SETTORE TRASPORTI TERRESTRI"
                    Case "Trasporti Aereo Navali"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.t_aereonavale='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.t_aereonavale='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.t_aereonavale='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.t_aereonavale='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.t_aereonavale='True' AND sospensione='True'"
                        Label8.Text = "SETTORE TRASPORTI AEREO NAVALI"
                    Case "Ricerca Scientifica"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ricerca='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ricerca='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.ricerca='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.ricerca='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.ricerca='True' AND sospensione='True'"
                        Label8.Text = "SETTORE RICERCA SCIENTIFICA"
                    Case "Rapporti con gli Stati Esteri"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.esteri='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.esteri='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.esteri='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.esteri='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.esteri='True' AND sospensione='True'"
                        Label8.Text = "SETTORE RAPPORTI CON GLI STATI ESTERI"
                End Select
            Else
                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' ORDER BY id_socio ASC;"
                DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='True' OR " & WhereCondition & " AND dim_s='True' OR " & WhereCondition & " AND espulsione='True' OR " & WhereCondition & " AND sospensione='True'"
            End If

        End If
        GridView1.PageIndex = 0
        GridView2.PageIndex = 0
        GridView2.DataBind()
        Response.Write(WhereCondition)
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim WhereCondition As String = ""
        Dim ctrl As Control
        For Each ctrl In Pan_prov.Controls
            If TypeOf (ctrl) Is TextBox Then
                If Not CType(ctrl, TextBox).Text.Equals("") Then
                    If CType(ctrl, TextBox).ToolTip.Equals("id_socio") Then
                        WhereCondition = WhereCondition & CType(ctrl, TextBox).ToolTip.ToString() & " = '" & CType(ctrl, TextBox).Text.ToString() & "' AND "
                    Else
                        text_ric = Replace(CType(ctrl, TextBox).Text.ToString(), "'", "''")
                        WhereCondition = WhereCondition & CType(ctrl, TextBox).ToolTip.ToString() & " LIKE '%" & text_ric & "%' AND "
                    End If

                End If
            ElseIf TypeOf (ctrl) Is DropDownList Then
                If Not CType(ctrl, DropDownList).SelectedValue.Equals("") Then
                    DD_ric = Replace(CType(ctrl, DropDownList).SelectedValue.ToString(), "'", "''")
                    WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & DD_ric & "' AND "
                Else
                    If CType(ctrl, DropDownList).ID.Equals("DD_qual3") Then
                        Dim num_item As Integer = DD_qual2.Items.Count
                        Dim i As Integer
                        DD_qual3.SelectedIndex = 0
                        WhereCondition = WhereCondition & "("
                        For i = 1 To num_item
                            If Not DD_qual3.SelectedValue.Equals("") Then
                                If i = num_item Then
                                    WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & CType(ctrl, DropDownList).SelectedValue.ToString() & "') AND "
                                Else
                                    WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & CType(ctrl, DropDownList).SelectedValue.ToString() & "' OR "
                                End If
                                DD_qual3.SelectedIndex = i
                            Else
                                DD_qual3.SelectedIndex = i
                            End If
                        Next

                        DD_qual3.SelectedIndex = 0
                    End If
                End If
            ElseIf TypeOf (ctrl) Is Label Then
                If Not CType(ctrl, Label).Text.Equals("") Then
                    lbl_ric = Replace(CType(ctrl, Label).Text.ToString(), "'", "''")
                    WhereCondition = WhereCondition & CType(ctrl, Label).ToolTip.ToString() & " = '" & lbl_ric & "' AND "
                End If
            End If

        Next
        WhereCondition = WhereCondition & "categ <> 'Socio Ordinario' AND reciclabile = 'False' AND "
        WhereCondition = WhereCondition.Trim()
        If WhereCondition.ToUpper().EndsWith("AND") Then
            WhereCondition = WhereCondition.Remove(WhereCondition.Length - 3, 3)
        End If
        If WhereCondition.ToUpper().EndsWith("OR") Then
            WhereCondition = WhereCondition.Remove(WhereCondition.Length - 2, 2)
        End If
        If CheckBox3.Checked = True Then
            GridView2.Visible = True
            Label3.Visible = True
            Label4.Visible = True
            Label5.Visible = True
            Label6.Visible = True
            Label7.Visible = True
            Image1.Visible = True
            Image2.Visible = True
            Image3.Visible = True
            Image4.Visible = True
        Else
            GridView2.Visible = False
            Label3.Visible = False
            Label4.Visible = False
            Label5.Visible = False
            Label6.Visible = False
            Label7.Visible = False
            Image1.Visible = False
            Image2.Visible = False
            Image3.Visible = False
            Image4.Visible = False
        End If
        Dim grado As String = Response.Cookies("SITOGNA")("qual")
        Dim settore As String = Request.Cookies("SITOGNA")("settore")
        If WhereCondition = "" Then
            If grado = "Dirigente Provinciale di Settore" Then
                Select Case settore
                    Case "Ambiente"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ambiente='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ambiente='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ambiente='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ambiente='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ambiente='True' AND sospensione='True'"
                        Label8.Text = "SETTORE AMBIENTE"
                    Case "Vigilanza"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.vigilanza='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.vigilanza='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.vigilanza='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.vigilanza='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.vigilanza='True' AND sospensione='True'"
                        Label8.Text = "SETTORE VIGILANZA"
                    Case "Stampa e diffusione"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.stampa_diff='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.stampa_diff='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.stampa_diff='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.stampa_diff='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.stampa_diff='True' AND sospensione='True'"
                        Label8.Text = "SETTORE STAMPA E DIFFUSIONE"
                    Case "Formazione"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.formazione='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.formazione='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.formazione='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.formazione='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.formazione='True' AND sospensione='True'"
                        Label8.Text = "SETTORE FORMAZIONE"
                    Case "Protezione Civile"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.prot_civ='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.prot_civ='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.prot_civ='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.prot_civ='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.prot_civ='True' AND sospensione='True'"
                        Label8.Text = "SETTORE PROTEZIONE CIVILE"
                    Case "Intelligence"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.intelligence='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.intelligence='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.intelligence='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.intelligence='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.intelligence='True' AND sospensione='True'"
                        Label8.Text = "SETTORE INTELLIGENCE"
                    Case "Pari Opportunità"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.pari_opp='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.pari_opp='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.pari_opp='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.pari_opp='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.pari_opp='True' AND sospensione='True'"
                        Label8.Text = "SETTORE PARI OPPORTUNITA'"
                    Case "Sanità"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.sanita='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.sanita='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.sanita='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.sanita='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.sanita='True' AND sospensione='True'"
                        Label8.Text = "COMPARTO SANITA'"
                    Case "Culto Religione Cattolica"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.culto_rel='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.culto_rel='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.culto_rel='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.culto_rel='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.culto_rel='True' AND sospensione='True'"
                        Label8.Text = "SETTORE CULTO RELIGIONE CATTOLICA"
                    Case "Found Raising"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.fondi='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.fondi='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.fondi='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.fondi='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.fondi='True' AND sospensione='True'"
                        Label8.Text = "SETTORE FOUND RAISING"
                    Case "Sport e Specialità"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.sport='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.sport='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.sport='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.sport='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.sport='True' AND sospensione='True'"
                        Label8.Text = "SETTORE SPORT E SPECIALITA'"
                    Case "Incombenze Interne e Disciplinare"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.disciplinare='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.disciplinare='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.disciplinare='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.disciplinare='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.disciplinare='True' AND sospensione='True'"
                        Label8.Text = "SETTORE INCOMBENZE INTERNE E DISPICLINARE"
                    Case "Rapporti con gli Stati Maggiori"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.statimaggiori='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.statimaggiori='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.statimaggiori='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.statimaggiori='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.statimaggiori='True' AND sospensione='True'"
                        Label8.Text = "SETTORE RAPPORTI CON GLI STATI MAGGIORI"
                    Case "Relazioni Istituzionali"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.rel_istit='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.rel_istit='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.rel_istit='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.rel_istit='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.rel_istit='True' AND sospensione='True'"
                        Label8.Text = "SETTORE RELAZIONI ISTITUZIONALI"
                    Case "DAP – Dipartimento Attività Promozionali"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.dap='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.dap='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.dap='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.dap='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.dap='True' AND sospensione='True'"
                        Label8.Text = "SETTORE DIPARTIMENTO ATTIVITA' PROMOZIONALI"
                    Case "RIA – Reparto Investigazioni Ambientali"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ria='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ria='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ria='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ria='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ria='True' AND sospensione='True'"
                        Label8.Text = "SETTORE REPARTO INVESTIGAZIONI AMBIENTALI"
                    Case "RAS – Raggruppamento Analisi Scientifiche"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ras='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ras='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ras='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ras='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ras='True' AND sospensione='True'"
                        Label8.Text = "SETTORE RAGGRUPPAMENTO ANALISI SCIENTIFICHE"
                    Case "Equipaggiamenti Individuali"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.equipaggiamenti='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.equipaggiamenti='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.equipaggiamenti='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.equipaggiamenti='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.equipaggiamenti='True' AND sospensione='True'"
                        Label8.Text = "SETTORE EQUIPAGGIAMENTI INDIVIDUALI"
                    Case "Trasporti Terrestri"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.trasporti_ter='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.trasporti_ter='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.trasporti_ter='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.trasporti_ter='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.trasporti_ter='True' AND sospensione='True'"
                        Label8.Text = "SETTORE TRASPORTI TERRESTRI"
                    Case "Trasporti Aereo Navali"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.t_aereonavale='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.t_aereonavale='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.t_aereonavale='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.t_aereonavale='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.t_aereonavale='True' AND sospensione='True'"
                        Label8.Text = "SETTORE TRASPORTI AEREO NAVALI"
                    Case "Ricerca Scientifica"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ricerca='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ricerca='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ricerca='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ricerca='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ricerca='True' AND sospensione='True'"
                        Label8.Text = "SETTORE RICERCA SCIENTIFICA"
                    Case "Rapporti con gli Stati Esteri"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.esteri='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.esteri='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.esteri='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.esteri='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.esteri='True' AND sospensione='True'"
                        Label8.Text = "SETTORE RAPPORTI CON GLI STATI ESTERI"
                End Select
            Else
                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE prov_app='" & lbl_prov.Text & "' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' ORDER BY id_socio ASC;"
                DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE dim_g='True' OR dim_s='True' OR espulsione='True' OR sospensione='True'"
            End If
        Else
            If grado = "Dirigente Provinciale di Settore" Then
                Select Case settore
                    Case "Ambiente"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ambiente='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ambiente='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.ambiente='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.ambiente='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.ambiente='True' AND sospensione='True'"
                        Label8.Text = "SETTORE AMBIENTE"
                    Case "Vigilanza"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.vigilanza='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.vigilanza='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.vigilanza='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.vigilanza='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.vigilanza='True' AND sospensione='True'"
                        Label8.Text = "SETTORE VIGILANZA"
                    Case "Stampa e diffusione"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.stampa_diff='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.stampa_diff='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.stampa_diff='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.stampa_diff='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.stampa_diff='True' AND sospensione='True'"
                        Label8.Text = "SETTORE STAMPA E DIFFUSIONE"
                    Case "Formazione"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.formazione='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.formazione='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.formazione='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.formazione='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.formazione='True' AND sospensione='True'"
                        Label8.Text = "SETTORE FORMAZIONE"
                    Case "Protezione Civile"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.prot_civ='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.prot_civ='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.prot_civ='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.prot_civ='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.prot_civ='True' AND sospensione='True'"
                        Label8.Text = "SETTORE PROTEZIONE CIVILE"
                    Case "Intelligence"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.intelligence='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.intelligence='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.intelligence='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.intelligence='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.intelligence='True' AND sospensione='True'"
                        Label8.Text = "SETTORE INTELLIGENCE"
                    Case "Pari Opportunità"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.pari_opp='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.pari_opp='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.pari_opp='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.pari_opp='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.pari_opp='True' AND sospensione='True'"
                        Label8.Text = "SETTORE PARI OPPORTUNITA'"
                    Case "Sanità"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.sanita='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.sanita='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.sanita='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.sanita='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.sanita='True' AND sospensione='True'"
                        Label8.Text = "COMPARTO SANITA'"
                    Case "Culto Religione Cattolica"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.culto_rel='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.culto_rel='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.culto_rel='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.culto_rel='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.culto_rel='True' AND sospensione='True'"
                        Label8.Text = "SETTORE CULTO RELIGIONE CATTOLICA"
                    Case "Found Raising"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.fondi='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.fondi='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.fondi='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.fondi='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.fondi='True' AND sospensione='True'"
                        Label8.Text = "SETTORE FOUND RAISING"
                    Case "Sport e Specialità"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.sport='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.sport='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.sport='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.sport='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.sport='True' AND sospensione='True'"
                        Label8.Text = "SETTORE SPORT E SPECIALITA'"
                    Case "Incombenze Interne e Disciplinare"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.disciplinare='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.disciplinare='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.disciplinare='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.disciplinare='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.disciplinare='True' AND sospensione='True'"
                        Label8.Text = "SETTORE INCOMBENZE INTERNE E DISPICLINARE"
                    Case "Rapporti con gli Stati Maggiori"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.statimaggiori='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.statimaggiori='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.statimaggiori='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.statimaggiori='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.statimaggiori='True' AND sospensione='True'"
                        Label8.Text = "SETTORE RAPPORTI CON GLI STATI MAGGIORI"
                    Case "Relazioni Istituzionali"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.rel_istit='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.rel_istit='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.rel_istit='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.rel_istit='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.rel_istit='True' AND sospensione='True'"
                        Label8.Text = "SETTORE RELAZIONI ISTITUZIONALI"
                    Case "DAP – Dipartimento Attività Promozionali"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.dap='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.dap='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.dap='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.dap='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.dap='True' AND sospensione='True'"
                        Label8.Text = "SETTORE DIPARTIMENTO ATTIVITA' PROMOZIONALI"
                    Case "RIA – Reparto Investigazioni Ambientali"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ria='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ria='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.ria='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.ria='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.ria='True' AND sospensione='True'"
                        Label8.Text = "SETTORE REPARTO INVESTIGAZIONI AMBIENTALI"
                    Case "RAS – Raggruppamento Analisi Scientifiche"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ras='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ras='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.ras='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.ras='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.ras='True' AND sospensione='True'"
                        Label8.Text = "SETTORE RAGGRUPPAMENTO ANALISI SCIENTIFICHE"
                    Case "Equipaggiamenti Individuali"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.equipaggiamenti='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.equipaggiamenti='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.equipaggiamenti='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.equipaggiamenti='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.equipaggiamenti='True' AND sospensione='True'"
                        Label8.Text = "SETTORE EQUIPAGGIAMENTI INDIVIDUALI"
                    Case "Trasporti Terrestri"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.trasporti_ter='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.trasporti_ter='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.trasporti_ter='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.trasporti_ter='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.trasporti_ter='True' AND sospensione='True'"
                        Label8.Text = "SETTORE TRASPORTI TERRESTRI"
                    Case "Trasporti Aereo Navali"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.t_aereonavale='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.t_aereonavale='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.t_aereonavale='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.t_aereonavale='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.t_aereonavale='True' AND sospensione='True'"
                        Label8.Text = "SETTORE TRASPORTI AEREO NAVALI"
                    Case "Ricerca Scientifica"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ricerca='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ricerca='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.ricerca='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.ricerca='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.ricerca='True' AND sospensione='True'"
                        Label8.Text = "SETTORE RICERCA SCIENTIFICA"
                    Case "Rapporti con gli Stati Esteri"
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.esteri='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                        DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.esteri='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.esteri='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.esteri='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.esteri='True' AND sospensione='True'"
                        Label8.Text = "SETTORE RAPPORTI CON GLI STATI ESTERI"
                End Select
            Else
                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' ORDER BY id_socio ASC;"
                DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='True' OR " & WhereCondition & " AND dim_s='True' OR " & WhereCondition & " AND espulsione='True' OR " & WhereCondition & " AND sospensione='True'"
            End If
        End If
        GridView1.PageIndex = 0
        GridView2.PageIndex = 0
        GridView1.DataBind()
        GridView2.DataBind()
    End Sub

    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim WhereCondition As String = ""
        Dim ctrl As Control
        For Each ctrl In Pan_sede.Controls
            If TypeOf (ctrl) Is TextBox Then
                If Not CType(ctrl, TextBox).Text.Equals("") Then
                    If CType(ctrl, TextBox).ToolTip.Equals("id_socio") Then
                        WhereCondition = WhereCondition & CType(ctrl, TextBox).ToolTip.ToString() & " = '" & CType(ctrl, TextBox).Text.ToString() & "' AND "
                    Else
                        text_ric = Replace(CType(ctrl, TextBox).Text.ToString(), "'", "''")
                        WhereCondition = WhereCondition & CType(ctrl, TextBox).ToolTip.ToString() & " LIKE '%" & text_ric & "%' AND "
                    End If

                End If
            ElseIf TypeOf (ctrl) Is DropDownList Then
                If Not CType(ctrl, DropDownList).SelectedValue.Equals("") Then
                    DD_ric = Replace(CType(ctrl, DropDownList).SelectedValue.ToString(), "'", "''")
                    WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & DD_ric & "' AND "
                Else
                    If CType(ctrl, DropDownList).ID.Equals("DD_qual4") Then
                        Dim num_item As Integer = DD_qual4.Items.Count
                        Dim i As Integer
                        DD_qual4.SelectedIndex = 0
                        WhereCondition = WhereCondition & "("
                        For i = 1 To num_item
                            If Not DD_qual4.SelectedValue.Equals("") Then
                                If i = num_item Then
                                    WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & CType(ctrl, DropDownList).SelectedValue.ToString() & "') AND "
                                Else
                                    WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & CType(ctrl, DropDownList).SelectedValue.ToString() & "' OR "
                                End If
                                DD_qual4.SelectedIndex = i
                            Else
                                DD_qual4.SelectedIndex = i
                            End If
                        Next

                        DD_qual4.SelectedIndex = 0
                    End If
                End If
            ElseIf TypeOf (ctrl) Is Label Then
                If Not CType(ctrl, Label).Text.Equals("") Then
                    lbl_ric = Replace(CType(ctrl, Label).Text.ToString(), "'", "''")
                    WhereCondition = WhereCondition & CType(ctrl, Label).ToolTip.ToString() & " = '" & lbl_ric & "' AND "
                End If
            End If

        Next
        WhereCondition = WhereCondition & "categ <> 'Socio Ordinario' AND reciclabile = 'False' AND "
        WhereCondition = WhereCondition.Trim()
        If WhereCondition.ToUpper().EndsWith("AND") Then
            WhereCondition = WhereCondition.Remove(WhereCondition.Length - 3, 3)
        End If
        If WhereCondition.ToUpper().EndsWith("OR") Then
            WhereCondition = WhereCondition.Remove(WhereCondition.Length - 2, 2)
        End If
        If CheckBox4.Checked = True Then
            GridView2.Visible = True
            Label3.Visible = True
            Label4.Visible = True
            Label5.Visible = True
            Label6.Visible = True
            Label7.Visible = True
            Image1.Visible = True
            Image2.Visible = True
            Image3.Visible = True
            Image4.Visible = True
        Else
            GridView2.Visible = False
            Label3.Visible = False
            Label4.Visible = False
            Label5.Visible = False
            Label6.Visible = False
            Label7.Visible = False
            Image1.Visible = False
            Image2.Visible = False
            Image3.Visible = False
            Image4.Visible = False
        End If
        If WhereCondition = "" Then
            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE com_app='" & lbl_sede.Text & "' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' ORDER BY id_socio ASC;"
            DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE dim_g='True' OR dim_s='True' OR espulsione='True' OR sospensione='True'"
        Else
            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' ORDER BY id_socio ASC;"
            DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='True' OR " & WhereCondition & " AND dim_s='True' OR " & WhereCondition & " AND espulsione='True' OR " & WhereCondition & " AND sospensione='True'"
        End If
        GridView1.PageIndex = 0
        GridView2.PageIndex = 0
        GridView2.DataBind()
    End Sub

    Protected Sub GridView1_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.PageIndexChanged
        Dim grado As String = Request.Cookies("SITOGNA")("qual")
        Select Case grado
            Case "Presidente", "Segreteria Presidente", "Dirigente Generale Superiore ", "Dirigente Generale Nazionale", "Dirigente Generale Nazionale Vicario", "Amministrativo Nazionale", "Dirigente Generale Interregionale", "Dirigente Interregionale Centro", "Dirigente Interregionale CentroNord", "Dirigente Interregionale CentroSud", "Dirigente Interregionale Isole", "Dirigente Nazionale di Settore", "WebMaster", "Dirigente Generale DGSF", "Dirigente Nazionale DVSF"
                Dim WhereCondition As String = ""
                Dim ctrl As Control
                For Each ctrl In Pan_ricerca.Controls
                    If TypeOf (ctrl) Is TextBox Then
                        If Not CType(ctrl, TextBox).Text.Equals("") Then
                            If CType(ctrl, TextBox).ToolTip.Equals("id_socio") Then
                                WhereCondition = WhereCondition & CType(ctrl, TextBox).ToolTip.ToString() & " = '" & CType(ctrl, TextBox).Text.ToString() & "' AND "
                            Else
                                WhereCondition = WhereCondition & CType(ctrl, TextBox).ToolTip.ToString() & " LIKE '%" & CType(ctrl, TextBox).Text.ToString() & "%' AND "
                            End If

                        End If
                    ElseIf TypeOf (ctrl) Is DropDownList Then
                        If Not CType(ctrl, DropDownList).SelectedValue.Equals("") Then
                            WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & CType(ctrl, DropDownList).SelectedValue.ToString() & "' AND "
                        End If
                    ElseIf TypeOf (ctrl) Is Label Then
                        If Not CType(ctrl, Label).Text.Equals("") Then
                            WhereCondition = WhereCondition & CType(ctrl, Label).ToolTip.ToString() & " = '" & CType(ctrl, Label).Text.ToString() & "' AND "
                        End If
                    ElseIf TypeOf (ctrl) Is CheckBox Then
                        If CType(ctrl, CheckBox).ID.Equals("soc_ord") Then
                            If CType(ctrl, CheckBox).Visible = True Then
                                If CType(ctrl, CheckBox).Checked = False Then
                                    WhereCondition = WhereCondition & " categ <> 'Socio Ordinario' AND "
                                Else
                                    WhereCondition = WhereCondition & " categ LIKE '%Socio%' AND "
                                End If
                            Else
                                WhereCondition = WhereCondition & " categ <> 'Socio Ordinario' AND "
                            End If
                        End If
                        If CType(ctrl, CheckBox).ID.Equals("ricicloCheckBox") Then
                            If CType(ctrl, CheckBox).Visible = True Then
                                If CType(ctrl, CheckBox).Checked = False Then
                                    WhereCondition = WhereCondition & " reciclabile = 'False' AND "
                                End If
                            Else
                                WhereCondition = WhereCondition & " reciclabile = 'False' AND "
                            End If
                        End If
                    End If

                Next
                If CheckBox1.Checked = True Then
                    GridView2.Visible = True
                    GridView2.Visible = True
                    Label3.Visible = True
                    Label4.Visible = True
                    Label5.Visible = True
                    Label6.Visible = True
                    Label7.Visible = True
                    Image1.Visible = True
                    Image2.Visible = True
                    Image3.Visible = True
                    Image4.Visible = True
                Else
                    GridView2.Visible = False
                    Label3.Visible = False
                    Label4.Visible = False
                    Label5.Visible = False
                    Label6.Visible = False
                    Label7.Visible = False
                    Image1.Visible = False
                    Image2.Visible = False
                    Image3.Visible = False
                    Image4.Visible = False
                End If

                WhereCondition = WhereCondition.Trim()
                If WhereCondition.ToUpper().EndsWith("AND") Then
                    WhereCondition = WhereCondition.Remove(WhereCondition.Length - 3, 3)
                End If
                If WhereCondition = "" Then
                    Select Case grado
                        Case "Dirigente Interregionale Centro"
                            Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
                            Dim conn As New MySqlConnection(strconn)

                            Dim StrSql As String = "SELECT DISTINCT regione FROM tbl_sedi WHERE interregionale = 'Centro' ORDER BY regione ASC"
                            Dim comm As New MySqlCommand(StrSql, conn)
                            conn.Open()
                            Dim rs As MySqlDataReader = comm.ExecuteReader
                            Dim WhereCond As String = ""
                            While rs.Read
                                WhereCond = WhereCond & "regione='" & rs("regione").ToString & "' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False' OR "
                            End While
                            WhereCond = WhereCond.Trim()
                            If WhereCond.ToUpper().EndsWith("OR") Then
                                WhereCond = WhereCond.Remove(WhereCond.Length - 2, 2)
                            End If
                            conn.Close()
                            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE " & WhereCond & "ORDER BY id_socio ASC;"
                            'DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCond & "dim_g='True' OR " & WhereCond & "dim_s='True' OR " & WhereCond & "espulsione='True' OR " & WhereCond & "sospensione='True'"
                        Case "Dirigente Interregionale CentroNord"
                            Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
                            Dim conn As New MySqlConnection(strconn)

                            Dim StrSql As String = "SELECT DISTINCT regione FROM tbl_sedi WHERE interregionale = 'CentroNord' ORDER BY regione ASC"
                            Dim comm As New MySqlCommand(StrSql, conn)
                            conn.Open()
                            Dim rs As MySqlDataReader = comm.ExecuteReader
                            Dim WhereCond As String = ""
                            While rs.Read
                                WhereCond = WhereCond & "regione='" & rs("regione").ToString & "' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False' OR "
                            End While
                            WhereCond = WhereCond.Trim()
                            If WhereCond.ToUpper().EndsWith("OR") Then
                                WhereCond = WhereCond.Remove(WhereCond.Length - 2, 2)
                            End If
                            conn.Close()
                            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE " & WhereCond & "ORDER BY id_socio ASC;"
                            'DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCond & "dim_g='True' OR " & WhereCond & "dim_s='True' OR " & WhereCond & "espulsione='True' OR " & WhereCond & "sospensione='True'"
                        Case "Dirigente Interregionale CentroSud"
                            Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
                            Dim conn As New MySqlConnection(strconn)

                            Dim StrSql As String = "SELECT DISTINCT regione FROM tbl_sedi WHERE interregionale = 'CentroSud' ORDER BY regione ASC"
                            Dim comm As New MySqlCommand(StrSql, conn)
                            conn.Open()
                            Dim rs As MySqlDataReader = comm.ExecuteReader
                            Dim WhereCond As String = ""
                            While rs.Read
                                WhereCond = WhereCond & "regione='" & rs("regione").ToString & "' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False' OR "
                            End While
                            WhereCond = WhereCond.Trim()
                            If WhereCond.ToUpper().EndsWith("OR") Then
                                WhereCond = WhereCond.Remove(WhereCond.Length - 2, 2)
                            End If
                            conn.Close()
                            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE " & WhereCond & "ORDER BY id_socio ASC;"
                            'DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCond & "dim_g='True' OR " & WhereCond & "dim_s='True' OR " & WhereCond & "espulsione='True' OR " & WhereCond & "sospensione='True'"
                        Case "Dirigente Interregionale Isole"
                            Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
                            Dim conn As New MySqlConnection(strconn)

                            Dim StrSql As String = "SELECT DISTINCT regione FROM tbl_sedi WHERE interregionale = 'Isole' ORDER BY regione ASC"
                            Dim comm As New MySqlCommand(StrSql, conn)
                            conn.Open()
                            Dim rs As MySqlDataReader = comm.ExecuteReader
                            Dim WhereCond As String = ""
                            While rs.Read
                                WhereCond = WhereCond & "regione='" & rs("regione").ToString & "' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False' OR "
                            End While
                            WhereCond = WhereCond.Trim()
                            If WhereCond.ToUpper().EndsWith("OR") Then
                                WhereCond = WhereCond.Remove(WhereCond.Length - 2, 2)
                            End If
                            conn.Close()
                            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE " & WhereCond & "ORDER BY id_socio ASC;"
                            'DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCond & "dim_g='True' OR " & WhereCond & "dim_s='True' OR " & WhereCond & "espulsione='True' OR " & WhereCond & "sospensione='True'"
                        Case "Dirigente Nazionale di Settore", "Dirigente Nazionale DVSF", "Dirigente Generale DGSF"
                            Dim settore As String = Request.Cookies("SITOGNA")("settore")
                            Select Case settore
                                Case "Ambiente"
                                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.ambiente='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                    DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.ambiente='True' AND dim_g='True' OR tbl_settori.ambiente='True' AND dim_s='True' OR tbl_settori.ambiente='True' AND espulsione='True' OR tbl_settori.ambiente='True' AND sospensione='True'"
                                    Label8.Text = "SETTORE AMBIENTE"
                                Case "Vigilanza"
                                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.vigilanza='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                    DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.vigilanza='True' AND dim_g='True' OR tbl_settori.vigilanza='True' AND dim_s='True' OR tbl_settori.vigilanza='True' AND espulsione='True' OR tbl_settori.vigilanza='True' AND sospensione='True'"
                                    Label8.Text = "SETTORE VIGILANZA"
                                Case "Stampa e diffusione"
                                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.stampa_diff='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                    DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.stampa_diff='True' AND dim_g='True' OR tbl_settori.stampa_diff='True' AND dim_s='True' OR tbl_settori.stampa_diff='True' AND espulsione='True' OR tbl_settori.stampa_diff='True' AND sospensione='True'"
                                    Label8.Text = "SETTORE STAMPA E DIFFUSIONE"
                                Case "Formazione"
                                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.formazione='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                    DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.formazione='True' AND dim_g='True' OR tbl_settori.formazione='True' AND dim_s='True' OR tbl_settori.formazione='True' AND espulsione='True' OR tbl_settori.formazione='True' AND sospensione='True'"
                                    Label8.Text = "SETTORE FORMAZIONE"
                                Case "Protezione Civile"
                                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.prot_civ='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                    DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.prot_civ='True' AND dim_g='True' OR tbl_settori.prot_civ='True' AND dim_s='True' OR tbl_settori.prot_civ='True' AND espulsione='True' OR tbl_settori.prot_civ='True' AND sospensione='True'"
                                    Label8.Text = "SETTORE PROTEZIONE CIVILE"
                                Case "Intelligence"
                                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.intelligence='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                    DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.intelligence='True' AND dim_g='True' OR tbl_settori.intelligence='True' AND dim_s='True' OR tbl_settori.intelligence='True' AND espulsione='True' OR tbl_settori.intelligence='True' AND sospensione='True'"
                                    Label8.Text = "SETTORE INTELLIGENCE"
                                Case "Pari Opportunità"
                                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.pari_opp='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                    DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.pari_opp='True' AND dim_g='True' OR tbl_settori.pari_opp='True' AND dim_s='True' OR tbl_settori.pari_opp='True' AND espulsione='True' OR tbl_settori.pari_opp='True' AND sospensione='True'"
                                    Label8.Text = "SETTORE PARI OPPORTUNITA'"
                                Case "Sanità"
                                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.sanita='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                    DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.sanita='True' AND dim_g='True' OR tbl_settori.sanita='True' AND dim_s='True' OR tbl_settori.sanita='True' AND espulsione='True' OR tbl_settori.sanita='True' AND sospensione='True'"
                                    Label8.Text = "COMPARTO SANITA'"
                                Case "Culto Religione Cattolica"
                                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.culto_rel='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                    DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.culto_rel='True' AND dim_g='True' OR tbl_settori.culto_rel='True' AND dim_s='True' OR tbl_settori.culto_rel='True' AND espulsione='True' OR tbl_settori.culto_rel='True' AND sospensione='True'"
                                    Label8.Text = "SETTORE CULTO RELIGIONE CATTOLICA"
                                Case "Found Raising"
                                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.fondi='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                    DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.fondi='True' AND dim_g='True' OR tbl_settori.fondi='True' AND dim_s='True' OR tbl_settori.fondi='True' AND espulsione='True' OR tbl_settori.fondi='True' AND sospensione='True'"
                                    Label8.Text = "SETTORE FOUND RAISING"
                                Case "Sport e Specialità"
                                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.sport='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                    DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.sport='True' AND dim_g='True' OR tbl_settori.sport='True' AND dim_s='True' OR tbl_settori.sport='True' AND espulsione='True' OR tbl_settori.sport='True' AND sospensione='True'"
                                    Label8.Text = "SETTORE SPORT E SPECIALITA'"
                                Case "Incombenze Interne e Disciplinare"
                                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.disciplinare='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                    DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.disciplinare='True' AND dim_g='True' OR tbl_settori.disciplinare='True' AND dim_s='True' OR tbl_settori.disciplinare='True' AND espulsione='True' OR tbl_settori.disciplinare='True' AND sospensione='True'"
                                    Label8.Text = "SETTORE INCOMBENZE INTERNE E DISPICLINARE"
                                Case "Rapporti con gli Stati Maggiori"
                                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.statimaggiori='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                    DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.statimaggiori='True' AND dim_g='True' OR tbl_settori.statimaggiori='True' AND dim_s='True' OR tbl_settori.statimaggiori='True' AND espulsione='True' OR tbl_settori.statimaggiori='True' AND sospensione='True'"
                                    Label8.Text = "SETTORE RAPPORTI CON GLI STATI MAGGIORI"
                                Case "Relazioni Istituzionali"
                                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.rel_istit='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                    DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.rel_istit='True' AND dim_g='True' OR tbl_settori.rel_istit='True' AND dim_s='True' OR tbl_settori.rel_istit='True' AND espulsione='True' OR tbl_settori.rel_istit='True' AND sospensione='True'"
                                    Label8.Text = "SETTORE RELAZIONI ISTITUZIONALI"
                                Case "DAP – Dipartimento Attività Promozionali"
                                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.dap='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                    DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.dap='True' AND dim_g='True' OR tbl_settori.dap='True' AND dim_s='True' OR tbl_settori.dap='True' AND espulsione='True' OR tbl_settori.dap='True' AND sospensione='True'"
                                    Label8.Text = "SETTORE DIPARTIMENTO ATTIVITA' PROMOZIONALI"
                                Case "RIA – Reparto Investigazioni Ambientali"
                                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.ria='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                    DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.ria='True' AND dim_g='True' OR tbl_settori.ria='True' AND dim_s='True' OR tbl_settori.ria='True' AND espulsione='True' OR tbl_settori.ria='True' AND sospensione='True'"
                                    Label8.Text = "SETTORE REPARTO INVESTIGAZIONI AMBIENTALI"
                                Case "RAS – Raggruppamento Analisi Scientifiche"
                                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.ras='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                    DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.ras='True' AND dim_g='True' OR tbl_settori.ras='True' AND dim_s='True' OR tbl_settori.ras='True' AND espulsione='True' OR tbl_settori.ras='True' AND sospensione='True'"
                                    Label8.Text = "SETTORE RAGGRUPPAMENTO ANALISI SCIENTIFICHE"
                                Case "Equipaggiamenti Individuali"
                                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.equipaggiamenti='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                    DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.equipaggiamenti='True' AND dim_g='True' OR tbl_settori.equipaggiamenti='True' AND dim_s='True' OR tbl_settori.equipaggiamenti='True' AND espulsione='True' OR tbl_settori.equipaggiamenti='True' AND sospensione='True'"
                                    Label8.Text = "SETTORE EQUIPAGGIAMENTI INDIVIDUALI"
                                Case "Trasporti Terrestri"
                                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.trasporti_ter='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                    DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.trasporti_ter='True' AND dim_g='True' OR tbl_settori.trasporti_ter='True' AND dim_s='True' OR tbl_settori.trasporti_ter='True' AND espulsione='True' OR tbl_settori.trasporti_ter='True' AND sospensione='True'"
                                    Label8.Text = "SETTORE TRASPORTI TERRESTRI"
                                Case "Trasporti Aereo Navali"
                                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.t_aereonavale='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                    DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.t_aereonavale='True' AND dim_g='True' OR tbl_settori.t_aereonavale='True' AND dim_s='True' OR tbl_settori.t_aereonavale='True' AND espulsione='True' OR tbl_settori.t_aereonavale='True' AND sospensione='True'"
                                    Label8.Text = "SETTORE TRASPORTI AEREO NAVALI"
                                Case "Ricerca Scientifica"
                                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.ricerca='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                    DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.ricerca='True' AND dim_g='True' OR tbl_settori.ricerca='True' AND dim_s='True' OR tbl_settori.ricerca='True' AND espulsione='True' OR tbl_settori.ricerca='True' AND sospensione='True'"
                                    Label8.Text = "SETTORE RICERCA SCIENTIFICA"
                                Case "Rapporti con gli Stati Esteri"
                                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.esteri='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False'"
                                    DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE tbl_settori.esteri='True' AND dim_g='True' OR tbl_settori.esteri='True' AND dim_s='True' OR tbl_settori.esteri='True' AND espulsione='True' OR tbl_settori.esteri='True' AND sospensione='True'"
                                    Label8.Text = "SETTORE RAPPORTI CON GLI STATI ESTERI"
                                Case "Segreteria Nazionale"
                                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False' ORDER BY id_socio ASC;"
                                    DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE dim_g='True' OR dim_s='True' OR espulsione='True' OR sospensione='True'"
                                    Label8.Text = "SETTORE SEGRETERIA NAZIONALE"
                            End Select
                        Case Else
                            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ <> 'Socio Ordinario' AND reciclabile = 'False' ORDER BY id_socio ASC;"
                            DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE dim_g='True' OR dim_s='True' OR espulsione='True' OR sospensione='True'"
                    End Select
                Else
                    If grado = "Dirigente Nazionale di Settore" Or grado = "Dirigente Nazionale DVSF" Or grado = "Dirigente Generale DGSF" Then
                        Dim settore As String = Request.Cookies("SITOGNA")("settore")
                        Select Case settore
                            Case "Ambiente"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ambiente='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ambiente='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.ambiente='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.ambiente='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.ambiente='True' AND sospensione='True'"
                                Label8.Text = "SETTORE AMBIENTE"
                            Case "Vigilanza"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.vigilanza='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.vigilanza='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.vigilanza='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.vigilanza='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.vigilanza='True' AND sospensione='True'"
                                Label8.Text = "SETTORE VIGILANZA"
                            Case "Stampa e diffusione"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.stampa_diff='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.stampa_diff='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.stampa_diff='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.stampa_diff='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.stampa_diff='True' AND sospensione='True'"
                                Label8.Text = "SETTORE STAMPA E DIFFUSIONE"
                            Case "Formazione"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.formazione='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.formazione='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.formazione='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.formazione='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.formazione='True' AND sospensione='True'"
                                Label8.Text = "SETTORE FORMAZIONE"
                            Case "Protezione Civile"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.prot_civ='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.prot_civ='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.prot_civ='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.prot_civ='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.prot_civ='True' AND sospensione='True'"
                                Label8.Text = "SETTORE PROTEZIONE CIVILE"
                            Case "Intelligence"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.intelligence='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.intelligence='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.intelligence='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.intelligence='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.intelligence='True' AND sospensione='True'"
                                Label8.Text = "SETTORE INTELLIGENCE"
                            Case "Pari Opportunità"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.pari_opp='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.pari_opp='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.pari_opp='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.pari_opp='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.pari_opp='True' AND sospensione='True'"
                                Label8.Text = "SETTORE PARI OPPORTUNITA'"
                            Case "Sanità"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.sanita='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.sanita='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.sanita='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.sanita='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.sanita='True' AND sospensione='True'"
                                Label8.Text = "COMPARTO SANITA'"
                            Case "Culto Religione Cattolica"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.culto_rel='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.culto_rel='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.culto_rel='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.culto_rel='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.culto_rel='True' AND sospensione='True'"
                                Label8.Text = "SETTORE CULTO RELIGIONE CATTOLICA"
                            Case "Found Raising"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.fondi='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.fondi='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.fondi='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.fondi='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.fondi='True' AND sospensione='True'"
                                Label8.Text = "SETTORE FOUND RAISING"
                            Case "Sport e Specialità"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.sport='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.sport='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.sport='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.sport='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.sport='True' AND sospensione='True'"
                                Label8.Text = "SETTORE SPORT E SPECIALITA'"
                            Case "Incombenze Interne e Disciplinare"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.disciplinare='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.disciplinare='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.disciplinare='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.disciplinare='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.disciplinare='True' AND sospensione='True'"
                                Label8.Text = "SETTORE INCOMBENZE INTERNE E DISPICLINARE"
                            Case "Rapporti con gli Stati Maggiori"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.statimaggiori='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.statimaggiori='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.statimaggiori='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.statimaggiori='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.statimaggiori='True' AND sospensione='True'"
                                Label8.Text = "SETTORE RAPPORTI CON GLI STATI MAGGIORI"
                            Case "Relazioni Istituzionali"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.rel_istit='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.rel_istit='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.rel_istit='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.rel_istit='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.rel_istit='True' AND sospensione='True'"
                                Label8.Text = "SETTORE RELAZIONI ISTITUZIONALI"
                            Case "DAP – Dipartimento Attività Promozionali"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.dap='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.dap='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.dap='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.dap='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.dap='True' AND sospensione='True'"
                                Label8.Text = "SETTORE DIPARTIMENTO ATTIVITA' PROMOZIONALI"
                            Case "RIA – Reparto Investigazioni Ambientali"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ria='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ria='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.ria='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.ria='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.ria='True' AND sospensione='True'"
                                Label8.Text = "SETTORE REPARTO INVESTIGAZIONI AMBIENTALI"
                            Case "RAS – Raggruppamento Analisi Scientifiche"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ras='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ras='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.ras='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.ras='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.ras='True' AND sospensione='True'"
                                Label8.Text = "SETTORE RAGGRUPPAMENTO ANALISI SCIENTIFICHE"
                            Case "Equipaggiamenti Individuali"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.equipaggiamenti='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.equipaggiamenti='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.equipaggiamenti='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.equipaggiamenti='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.equipaggiamenti='True' AND sospensione='True'"
                                Label8.Text = "SETTORE EQUIPAGGIAMENTI INDIVIDUALI"
                            Case "Trasporti Terrestri"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.trasporti_ter='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.trasporti_ter='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.trasporti_ter='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.trasporti_ter='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.trasporti_ter='True' AND sospensione='True'"
                                Label8.Text = "SETTORE TRASPORTI TERRESTRI"
                            Case "Trasporti Aereo Navali"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.t_aereonavale='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.t_aereonavale='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.t_aereonavale='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.t_aereonavale='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.t_aereonavale='True' AND sospensione='True'"
                                Label8.Text = "SETTORE TRASPORTI AEREO NAVALI"
                            Case "Ricerca Scientifica"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ricerca='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ricerca='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.ricerca='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.ricerca='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.ricerca='True' AND sospensione='True'"
                                Label8.Text = "SETTORE RICERCA SCIENTIFICA"
                            Case "Rapporti con gli Stati Esteri"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.esteri='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.esteri='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.esteri='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.esteri='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.esteri='True' AND sospensione='True'"
                                Label8.Text = "SETTORE RAPPORTI CON GLI STATI ESTERI"
                            Case "Segreteria Nazionale"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' ORDER BY id_socio ASC;"
                                DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='True' OR " & WhereCondition & " AND dim_s='True' OR " & WhereCondition & " AND espulsione='True' OR " & WhereCondition & " AND sospensione='True'"
                                Label8.Text = "SETTORE SEGRETERIA NAZIONALE"
                            Case Else
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' ORDER BY id_socio ASC;"
                                DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='True' OR " & WhereCondition & " AND dim_s='True' OR " & WhereCondition & " AND espulsione='True' OR " & WhereCondition & " AND sospensione='True'"
                                Label8.Text = "SETTORE TUTTI"
                        End Select
                    Else
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' ORDER BY id_socio ASC;"
                        DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='True' OR " & WhereCondition & " AND dim_s='True' OR " & WhereCondition & " AND espulsione='True' OR " & WhereCondition & " AND sospensione='True'"
                    End If
                End If
            Case "Dirigente Regionale", "Dirigente Regionale Vicario", "Amministrativo Regionale", "Dirigente Regionale di Settore"
                Dim WhereCondition As String = ""
                Dim ctrl As Control
                For Each ctrl In Pan_reg.Controls
                    If TypeOf (ctrl) Is TextBox Then
                        If Not CType(ctrl, TextBox).Text.Equals("") Then
                            If CType(ctrl, TextBox).ToolTip.Equals("id_socio") Then
                                WhereCondition = WhereCondition & CType(ctrl, TextBox).ToolTip.ToString() & " = '" & CType(ctrl, TextBox).Text.ToString() & "' AND "
                            Else
                                WhereCondition = WhereCondition & CType(ctrl, TextBox).ToolTip.ToString() & " LIKE '%" & CType(ctrl, TextBox).Text.ToString() & "%' AND "
                            End If

                        End If
                    ElseIf TypeOf (ctrl) Is DropDownList Then
                        If Not CType(ctrl, DropDownList).SelectedValue.Equals("") Then
                            WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & CType(ctrl, DropDownList).SelectedValue.ToString() & "' AND "
                        Else
                            If CType(ctrl, DropDownList).ID.Equals("DD_qual2") Then
                                Dim num_item As Integer = DD_qual2.Items.Count
                                Dim i As Integer
                                DD_qual2.SelectedIndex = 0
                                WhereCondition = WhereCondition & "("
                                For i = 1 To num_item
                                    If Not DD_qual2.SelectedValue.Equals("") Then
                                        If i = num_item Then
                                            WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & CType(ctrl, DropDownList).SelectedValue.ToString() & "') AND "
                                        Else
                                            WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & CType(ctrl, DropDownList).SelectedValue.ToString() & "' OR "
                                        End If
                                        DD_qual2.SelectedIndex = i
                                    Else
                                        DD_qual2.SelectedIndex = i
                                    End If
                                Next

                                DD_qual2.SelectedIndex = 0
                            End If
                        End If
                    ElseIf TypeOf (ctrl) Is Label Then
                        If Not CType(ctrl, Label).Text.Equals("") Then
                            WhereCondition = WhereCondition & CType(ctrl, Label).ToolTip.ToString() & " = '" & CType(ctrl, Label).Text.ToString() & "' AND "
                        End If
                    End If

                Next
                WhereCondition = WhereCondition & "categ <> 'Socio Ordinario' AND reciclabile = 'False' AND "
                WhereCondition = WhereCondition.Trim()
                If WhereCondition.ToUpper().EndsWith("AND") Then
                    WhereCondition = WhereCondition.Remove(WhereCondition.Length - 3, 3)
                End If
                If WhereCondition.ToUpper().EndsWith("OR") Then
                    WhereCondition = WhereCondition.Remove(WhereCondition.Length - 2, 2)
                End If
                If CheckBox2.Checked = True Then
                    GridView2.Visible = True
                    GridView2.Visible = True
                    Label3.Visible = True
                    Label4.Visible = True
                    Label5.Visible = True
                    Label6.Visible = True
                    Label7.Visible = True
                    Image1.Visible = True
                    Image2.Visible = True
                    Image3.Visible = True
                    Image4.Visible = True
                Else
                    GridView2.Visible = False
                    Label3.Visible = False
                    Label4.Visible = False
                    Label5.Visible = False
                    Label6.Visible = False
                    Label7.Visible = False
                    Image1.Visible = False
                    Image2.Visible = False
                    Image3.Visible = False
                    Image4.Visible = False
                End If
                Dim settore As String = Request.Cookies("SITOGNA")("settore")
                If WhereCondition = "" Then
                    If grado = "Dirigente Regionale di Settore" Then
                        Select Case settore
                            Case "Ambiente"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.ambiente='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.ambiente='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.ambiente='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.ambiente='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.ambiente='True' AND sospensione='True'"
                                Label8.Text = "SETTORE AMBIENTE"
                            Case "Vigilanza"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.vigilanza='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.vigilanza='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.vigilanza='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.vigilanza='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.vigilanza='True' AND sospensione='True'"
                                Label8.Text = "SETTORE VIGILANZA"
                            Case "Stampa e diffusione"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.stampa_diff='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.stampa_diff='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.stampa_diff='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.stampa_diff='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.stampa_diff='True' AND sospensione='True'"
                                Label8.Text = "SETTORE STAMPA E DIFFUSIONE"
                            Case "Formazione"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.formazione='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.formazione='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.formazione='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.formazione='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.formazione='True' AND sospensione='True'"
                                Label8.Text = "SETTORE FORMAZIONE"
                            Case "Protezione Civile"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.prot_civ='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.prot_civ='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.prot_civ='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.prot_civ='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.prot_civ='True' AND sospensione='True'"
                                Label8.Text = "SETTORE PROTEZIONE CIVILE"
                            Case "Intelligence"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.intelligence='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.intelligence='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.intelligence='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.intelligence='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.intelligence='True' AND sospensione='True'"
                                Label8.Text = "SETTORE INTELLIGENCE"
                            Case "Pari Opportunità"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.pari_opp='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.pari_opp='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.pari_opp='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.pari_opp='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.pari_opp='True' AND sospensione='True'"
                                Label8.Text = "SETTORE PARI OPPORTUNITA'"
                            Case "Sanità"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.sanita='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.sanita='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.sanita='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.sanita='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.sanita='True' AND sospensione='True'"
                                Label8.Text = "COMPARTO SANITA'"
                            Case "Culto Religione Cattolica"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.culto_rel='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.culto_rel='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.culto_rel='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.culto_rel='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.culto_rel='True' AND sospensione='True'"
                                Label8.Text = "SETTORE CULTO RELIGIONE CATTOLICA"
                            Case "Found Raising"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.fondi='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.fondi='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.fondi='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.fondi='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.fondi='True' AND sospensione='True'"
                                Label8.Text = "SETTORE FOUND RAISING"
                            Case "Sport e Specialità"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.sport='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.sport='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.sport='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.sport='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.sport='True' AND sospensione='True'"
                                Label8.Text = "SETTORE SPORT E SPECIALITA'"
                            Case "Incombenze Interne e Disciplinare"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.disciplinare='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.disciplinare='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.disciplinare='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.disciplinare='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.disciplinare='True' AND sospensione='True'"
                                Label8.Text = "SETTORE INCOMBENZE INTERNE E DISPICLINARE"
                            Case "Rapporti con gli Stati Maggiori"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.statimaggiori='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.statimaggiori='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.statimaggiori='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.statimaggiori='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.statimaggiori='True' AND sospensione='True'"
                                Label8.Text = "SETTORE RAPPORTI CON GLI STATI MAGGIORI"
                            Case "Relazioni Istituzionali"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.rel_istit='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.rel_istit='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.rel_istit='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.rel_istit='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.rel_istit='True' AND sospensione='True'"
                                Label8.Text = "SETTORE RELAZIONI ISTITUZIONALI"
                            Case "DAP – Dipartimento Attività Promozionali"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.dap='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.dap='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.dap='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.dap='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.dap='True' AND sospensione='True'"
                                Label8.Text = "SETTORE DIPARTIMENTO ATTIVITA' PROMOZIONALI"
                            Case "RIA – Reparto Investigazioni Ambientali"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.ria='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.ria='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.ria='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.ria='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.ria='True' AND sospensione='True'"
                                Label8.Text = "SETTORE REPARTO INVESTIGAZIONI AMBIENTALI"
                            Case "RAS – Raggruppamento Analisi Scientifiche"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.ras='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.ras='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.ras='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.ras='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.ras='True' AND sospensione='True'"
                                Label8.Text = "SETTORE RAGGRUPPAMENTO ANALISI SCIENTIFICHE"
                            Case "Equipaggiamenti Individuali"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.equipaggiamenti='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.equipaggiamenti='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.equipaggiamenti='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.equipaggiamenti='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.equipaggiamenti='True' AND sospensione='True'"
                                Label8.Text = "SETTORE EQUIPAGGIAMENTI INDIVIDUALI"
                            Case "Trasporti Terrestri"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.trasporti_ter='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.trasporti_ter='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.trasporti_ter='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.trasporti_ter='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.trasporti_ter='True' AND sospensione='True'"
                                Label8.Text = "SETTORE TRASPORTI TERRESTRI"
                            Case "Trasporti Aereo Navali"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.t_aereonavale='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.t_aereonavale='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.t_aereonavale='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.t_aereonavale='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.t_aereonavale='True' AND sospensione='True'"
                                Label8.Text = "SETTORE TRASPORTI AEREO NAVALI"
                            Case "Ricerca Scientifica"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.ricerca='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.ricerca='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.ricerca='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.ricerca='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.ricerca='True' AND sospensione='True'"
                                Label8.Text = "SETTORE RICERCA SCIENTIFICA"
                            Case "Rapporti con gli Stati Esteri"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.esteri='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE regione = '" & lbl_regione.Text & "' AND tbl_settori.esteri='True' AND dim_g='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.esteri='True' AND dim_s='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.esteri='True' AND espulsione='True' OR regione = '" & lbl_regione.Text & "' AND tbl_settori.esteri='True' AND sospensione='True'"
                                Label8.Text = "SETTORE RAPPORTI CON GLI STATI ESTERI"
                        End Select
                    Else
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE regione = '" & lbl_regione.Text & "' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' ORDER BY id_socio ASC;"
                        DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE dim_g='True' OR dim_s='True' OR espulsione='True' OR sospensione='True'"
                    End If
                Else
                    If grado = "Dirigente Regionale di Settore" Then
                        Select Case settore
                            Case "Ambiente"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ambiente='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ambiente='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.ambiente='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.ambiente='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.ambiente='True' AND sospensione='True'"
                                Label8.Text = "SETTORE AMBIENTE"
                            Case "Vigilanza"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.vigilanza='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.vigilanza='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.vigilanza='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.vigilanza='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.vigilanza='True' AND sospensione='True'"
                                Label8.Text = "SETTORE VIGILANZA"
                            Case "Stampa e diffusione"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.stampa_diff='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.stampa_diff='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.stampa_diff='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.stampa_diff='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.stampa_diff='True' AND sospensione='True'"
                                Label8.Text = "SETTORE STAMPA E DIFFUSIONE"
                            Case "Formazione"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.formazione='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.formazione='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.formazione='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.formazione='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.formazione='True' AND sospensione='True'"
                                Label8.Text = "SETTORE FORMAZIONE"
                            Case "Protezione Civile"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.prot_civ='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.prot_civ='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.prot_civ='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.prot_civ='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.prot_civ='True' AND sospensione='True'"
                                Label8.Text = "SETTORE PROTEZIONE CIVILE"
                            Case "Intelligence"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.intelligence='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.intelligence='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.intelligence='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.intelligence='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.intelligence='True' AND sospensione='True'"
                                Label8.Text = "SETTORE INTELLIGENCE"
                            Case "Pari Opportunità"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.pari_opp='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.pari_opp='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.pari_opp='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.pari_opp='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.pari_opp='True' AND sospensione='True'"
                                Label8.Text = "SETTORE PARI OPPORTUNITA'"
                            Case "Sanità"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.sanita='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.sanita='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.sanita='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.sanita='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.sanita='True' AND sospensione='True'"
                                Label8.Text = "COMPARTO SANITA'"
                            Case "Culto Religione Cattolica"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.culto_rel='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.culto_rel='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.culto_rel='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.culto_rel='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.culto_rel='True' AND sospensione='True'"
                                Label8.Text = "SETTORE CULTO RELIGIONE CATTOLICA"
                            Case "Found Raising"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.fondi='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.fondi='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.fondi='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.fondi='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.fondi='True' AND sospensione='True'"
                                Label8.Text = "SETTORE FOUND RAISING"
                            Case "Sport e Specialità"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.sport='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.sport='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.sport='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.sport='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.sport='True' AND sospensione='True'"
                                Label8.Text = "SETTORE SPORT E SPECIALITA'"
                            Case "Incombenze Interne e Disciplinare"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.disciplinare='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.disciplinare='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.disciplinare='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.disciplinare='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.disciplinare='True' AND sospensione='True'"
                                Label8.Text = "SETTORE INCOMBENZE INTERNE E DISPICLINARE"
                            Case "Rapporti con gli Stati Maggiori"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.statimaggiori='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.statimaggiori='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.statimaggiori='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.statimaggiori='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.statimaggiori='True' AND sospensione='True'"
                                Label8.Text = "SETTORE RAPPORTI CON GLI STATI MAGGIORI"
                            Case "Relazioni Istituzionali"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.rel_istit='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.rel_istit='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.rel_istit='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.rel_istit='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.rel_istit='True' AND sospensione='True'"
                                Label8.Text = "SETTORE RELAZIONI ISTITUZIONALI"
                            Case "DAP – Dipartimento Attività Promozionali"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.dap='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.dap='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.dap='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.dap='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.dap='True' AND sospensione='True'"
                                Label8.Text = "SETTORE DIPARTIMENTO ATTIVITA' PROMOZIONALI"
                            Case "RIA – Reparto Investigazioni Ambientali"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ria='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ria='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.ria='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.ria='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.ria='True' AND sospensione='True'"
                                Label8.Text = "SETTORE REPARTO INVESTIGAZIONI AMBIENTALI"
                            Case "RAS – Raggruppamento Analisi Scientifiche"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ras='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ras='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.ras='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.ras='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.ras='True' AND sospensione='True'"
                                Label8.Text = "SETTORE RAGGRUPPAMENTO ANALISI SCIENTIFICHE"
                            Case "Equipaggiamenti Individuali"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.equipaggiamenti='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.equipaggiamenti='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.equipaggiamenti='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.equipaggiamenti='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.equipaggiamenti='True' AND sospensione='True'"
                                Label8.Text = "SETTORE EQUIPAGGIAMENTI INDIVIDUALI"
                            Case "Trasporti Terrestri"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.trasporti_ter='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.trasporti_ter='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.trasporti_ter='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.trasporti_ter='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.trasporti_ter='True' AND sospensione='True'"
                                Label8.Text = "SETTORE TRASPORTI TERRESTRI"
                            Case "Trasporti Aereo Navali"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.t_aereonavale='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.t_aereonavale='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.t_aereonavale='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.t_aereonavale='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.t_aereonavale='True' AND sospensione='True'"
                                Label8.Text = "SETTORE TRASPORTI AEREO NAVALI"
                            Case "Ricerca Scientifica"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ricerca='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ricerca='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.ricerca='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.ricerca='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.ricerca='True' AND sospensione='True'"
                                Label8.Text = "SETTORE RICERCA SCIENTIFICA"
                            Case "Rapporti con gli Stati Esteri"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.esteri='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.esteri='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.esteri='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.esteri='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.esteri='True' AND sospensione='True'"
                                Label8.Text = "SETTORE RAPPORTI CON GLI STATI ESTERI"
                        End Select
                    Else
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' ORDER BY id_socio ASC;"
                        DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='True' OR " & WhereCondition & " AND dim_s='True' OR " & WhereCondition & " AND espulsione='True' OR " & WhereCondition & " AND sospensione='True'"
                    End If
                End If
            Case "Dirigente Provinciale", "Dirigente Provinciale Vicario", "Dirigente Provinciale di Settore", "Amministrativo Provinciale"
                Dim WhereCondition As String = ""
                Dim ctrl As Control
                For Each ctrl In Pan_prov.Controls
                    If TypeOf (ctrl) Is TextBox Then
                        If Not CType(ctrl, TextBox).Text.Equals("") Then
                            If CType(ctrl, TextBox).ToolTip.Equals("id_socio") Then
                                WhereCondition = WhereCondition & CType(ctrl, TextBox).ToolTip.ToString() & " = '" & CType(ctrl, TextBox).Text.ToString() & "' AND "
                            Else
                                WhereCondition = WhereCondition & CType(ctrl, TextBox).ToolTip.ToString() & " LIKE '%" & CType(ctrl, TextBox).Text.ToString() & "%' AND "
                            End If

                        End If
                    ElseIf TypeOf (ctrl) Is DropDownList Then
                        If Not CType(ctrl, DropDownList).SelectedValue.Equals("") Then
                            WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & CType(ctrl, DropDownList).SelectedValue.ToString() & "' AND "
                        Else
                            If CType(ctrl, DropDownList).ID.Equals("DD_qual3") Then
                                Dim num_item As Integer = DD_qual2.Items.Count
                                Dim i As Integer
                                DD_qual3.SelectedIndex = 0
                                WhereCondition = WhereCondition & "("
                                For i = 1 To num_item
                                    If Not DD_qual3.SelectedValue.Equals("") Then
                                        If i = num_item Then
                                            WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & CType(ctrl, DropDownList).SelectedValue.ToString() & "') AND "
                                        Else
                                            WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & CType(ctrl, DropDownList).SelectedValue.ToString() & "' OR "
                                        End If
                                        DD_qual3.SelectedIndex = i
                                    Else
                                        DD_qual3.SelectedIndex = i
                                    End If
                                Next

                                DD_qual3.SelectedIndex = 0
                            End If
                        End If
                    ElseIf TypeOf (ctrl) Is Label Then
                        If Not CType(ctrl, Label).Text.Equals("") Then
                            WhereCondition = WhereCondition & CType(ctrl, Label).ToolTip.ToString() & " = '" & CType(ctrl, Label).Text.ToString() & "' AND "
                        End If
                    End If

                Next
                WhereCondition = WhereCondition & "categ <> 'Socio Ordinario' AND reciclabile = 'False' AND "
                WhereCondition = WhereCondition.Trim()
                If WhereCondition.ToUpper().EndsWith("AND") Then
                    WhereCondition = WhereCondition.Remove(WhereCondition.Length - 3, 3)
                End If
                If WhereCondition.ToUpper().EndsWith("OR") Then
                    WhereCondition = WhereCondition.Remove(WhereCondition.Length - 2, 2)
                End If
                If CheckBox3.Checked = True Then
                    GridView2.Visible = True
                    GridView2.Visible = True
                    Label3.Visible = True
                    Label4.Visible = True
                    Label5.Visible = True
                    Label6.Visible = True
                    Label7.Visible = True
                    Image1.Visible = True
                    Image2.Visible = True
                    Image3.Visible = True
                    Image4.Visible = True
                Else
                    GridView2.Visible = False
                    Label3.Visible = False
                    Label4.Visible = False
                    Label5.Visible = False
                    Label6.Visible = False
                    Label7.Visible = False
                    Image1.Visible = False
                    Image2.Visible = False
                    Image3.Visible = False
                    Image4.Visible = False
                End If
                Dim settore As String = Request.Cookies("SITOGNA")("settore")
                If WhereCondition = "" Then
                    If grado = "Dirigente Provinciale di Settore" Then
                        Select Case settore
                            Case "Ambiente"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ambiente='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ambiente='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ambiente='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ambiente='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ambiente='True' AND sospensione='True'"
                                Label8.Text = "SETTORE AMBIENTE"
                            Case "Vigilanza"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.vigilanza='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.vigilanza='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.vigilanza='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.vigilanza='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.vigilanza='True' AND sospensione='True'"
                                Label8.Text = "SETTORE VIGILANZA"
                            Case "Stampa e diffusione"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.stampa_diff='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.stampa_diff='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.stampa_diff='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.stampa_diff='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.stampa_diff='True' AND sospensione='True'"
                                Label8.Text = "SETTORE STAMPA E DIFFUSIONE"
                            Case "Formazione"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.formazione='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.formazione='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.formazione='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.formazione='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.formazione='True' AND sospensione='True'"
                                Label8.Text = "SETTORE FORMAZIONE"
                            Case "Protezione Civile"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.prot_civ='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.prot_civ='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.prot_civ='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.prot_civ='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.prot_civ='True' AND sospensione='True'"
                                Label8.Text = "SETTORE PROTEZIONE CIVILE"
                            Case "Intelligence"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.intelligence='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.intelligence='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.intelligence='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.intelligence='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.intelligence='True' AND sospensione='True'"
                                Label8.Text = "SETTORE INTELLIGENCE"
                            Case "Pari Opportunità"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.pari_opp='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.pari_opp='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.pari_opp='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.pari_opp='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.pari_opp='True' AND sospensione='True'"
                                Label8.Text = "SETTORE PARI OPPORTUNITA'"
                            Case "Sanità"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.sanita='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.sanita='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.sanita='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.sanita='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.sanita='True' AND sospensione='True'"
                                Label8.Text = "COMPARTO SANITA'"
                            Case "Culto Religione Cattolica"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.culto_rel='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.culto_rel='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.culto_rel='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.culto_rel='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.culto_rel='True' AND sospensione='True'"
                                Label8.Text = "SETTORE CULTO RELIGIONE CATTOLICA"
                            Case "Found Raising"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.fondi='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.fondi='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.fondi='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.fondi='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.fondi='True' AND sospensione='True'"
                                Label8.Text = "SETTORE FOUND RAISING"
                            Case "Sport e Specialità"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.sport='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.sport='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.sport='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.sport='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.sport='True' AND sospensione='True'"
                                Label8.Text = "SETTORE SPORT E SPECIALITA'"
                            Case "Incombenze Interne e Disciplinare"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.disciplinare='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.disciplinare='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.disciplinare='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.disciplinare='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.disciplinare='True' AND sospensione='True'"
                                Label8.Text = "SETTORE INCOMBENZE INTERNE E DISPICLINARE"
                            Case "Rapporti con gli Stati Maggiori"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.statimaggiori='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.statimaggiori='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.statimaggiori='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.statimaggiori='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.statimaggiori='True' AND sospensione='True'"
                                Label8.Text = "SETTORE RAPPORTI CON GLI STATI MAGGIORI"
                            Case "Relazioni Istituzionali"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.rel_istit='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.rel_istit='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.rel_istit='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.rel_istit='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.rel_istit='True' AND sospensione='True'"
                                Label8.Text = "SETTORE RELAZIONI ISTITUZIONALI"
                            Case "DAP – Dipartimento Attività Promozionali"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.dap='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.dap='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.dap='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.dap='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.dap='True' AND sospensione='True'"
                                Label8.Text = "SETTORE DIPARTIMENTO ATTIVITA' PROMOZIONALI"
                            Case "RIA – Reparto Investigazioni Ambientali"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ria='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ria='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ria='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ria='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ria='True' AND sospensione='True'"
                                Label8.Text = "SETTORE REPARTO INVESTIGAZIONI AMBIENTALI"
                            Case "RAS – Raggruppamento Analisi Scientifiche"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ras='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ras='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ras='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ras='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ras='True' AND sospensione='True'"
                                Label8.Text = "SETTORE RAGGRUPPAMENTO ANALISI SCIENTIFICHE"
                            Case "Equipaggiamenti Individuali"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.equipaggiamenti='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.equipaggiamenti='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.equipaggiamenti='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.equipaggiamenti='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.equipaggiamenti='True' AND sospensione='True'"
                                Label8.Text = "SETTORE EQUIPAGGIAMENTI INDIVIDUALI"
                            Case "Trasporti Terrestri"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.trasporti_ter='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.trasporti_ter='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.trasporti_ter='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.trasporti_ter='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.trasporti_ter='True' AND sospensione='True'"
                                Label8.Text = "SETTORE TRASPORTI TERRESTRI"
                            Case "Trasporti Aereo Navali"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.t_aereonavale='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.t_aereonavale='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.t_aereonavale='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.t_aereonavale='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.t_aereonavale='True' AND sospensione='True'"
                                Label8.Text = "SETTORE TRASPORTI AEREO NAVALI"
                            Case "Ricerca Scientifica"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ricerca='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ricerca='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ricerca='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ricerca='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.ricerca='True' AND sospensione='True'"
                                Label8.Text = "SETTORE RICERCA SCIENTIFICA"
                            Case "Rapporti con gli Stati Esteri"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.esteri='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE prov_app = '" & lbl_prov.Text & "' AND tbl_settori.esteri='True' AND dim_g='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.esteri='True' AND dim_s='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.esteri='True' AND espulsione='True' OR prov_app = '" & lbl_prov.Text & "' AND tbl_settori.esteri='True' AND sospensione='True'"
                                Label8.Text = "SETTORE RAPPORTI CON GLI STATI ESTERI"
                        End Select
                    Else
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE prov_app='" & lbl_prov.Text & "' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' ORDER BY id_socio ASC;"
                        DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE dim_g='True' OR dim_s='True' OR espulsione='True' OR sospensione='True'"
                    End If
                Else
                    If grado = "Dirigente Provinciale di Settore" Then
                        Select Case settore
                            Case "Ambiente"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ambiente='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ambiente='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.ambiente='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.ambiente='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.ambiente='True' AND sospensione='True'"
                                Label8.Text = "SETTORE AMBIENTE"
                            Case "Vigilanza"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.vigilanza='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.vigilanza='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.vigilanza='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.vigilanza='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.vigilanza='True' AND sospensione='True'"
                                Label8.Text = "SETTORE VIGILANZA"
                            Case "Stampa e diffusione"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.stampa_diff='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.stampa_diff='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.stampa_diff='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.stampa_diff='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.stampa_diff='True' AND sospensione='True'"
                                Label8.Text = "SETTORE STAMPA E DIFFUSIONE"
                            Case "Formazione"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.formazione='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.formazione='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.formazione='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.formazione='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.formazione='True' AND sospensione='True'"
                                Label8.Text = "SETTORE FORMAZIONE"
                            Case "Protezione Civile"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.prot_civ='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.prot_civ='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.prot_civ='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.prot_civ='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.prot_civ='True' AND sospensione='True'"
                                Label8.Text = "SETTORE PROTEZIONE CIVILE"
                            Case "Intelligence"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.intelligence='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.intelligence='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.intelligence='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.intelligence='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.intelligence='True' AND sospensione='True'"
                                Label8.Text = "SETTORE INTELLIGENCE"
                            Case "Pari Opportunità"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.pari_opp='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.pari_opp='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.pari_opp='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.pari_opp='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.pari_opp='True' AND sospensione='True'"
                                Label8.Text = "SETTORE PARI OPPORTUNITA'"
                            Case "Sanità"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.sanita='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.sanita='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.sanita='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.sanita='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.sanita='True' AND sospensione='True'"
                                Label8.Text = "COMPARTO SANITA'"
                            Case "Culto Religione Cattolica"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.culto_rel='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.culto_rel='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.culto_rel='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.culto_rel='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.culto_rel='True' AND sospensione='True'"
                                Label8.Text = "SETTORE CULTO RELIGIONE CATTOLICA"
                            Case "Found Raising"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.fondi='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.fondi='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.fondi='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.fondi='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.fondi='True' AND sospensione='True'"
                                Label8.Text = "SETTORE FOUND RAISING"
                            Case "Sport e Specialità"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.sport='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.sport='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.sport='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.sport='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.sport='True' AND sospensione='True'"
                                Label8.Text = "SETTORE SPORT E SPECIALITA'"
                            Case "Incombenze Interne e Disciplinare"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.disciplinare='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.disciplinare='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.disciplinare='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.disciplinare='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.disciplinare='True' AND sospensione='True'"
                                Label8.Text = "SETTORE INCOMBENZE INTERNE E DISPICLINARE"
                            Case "Rapporti con gli Stati Maggiori"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.statimaggiori='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.statimaggiori='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.statimaggiori='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.statimaggiori='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.statimaggiori='True' AND sospensione='True'"
                                Label8.Text = "SETTORE RAPPORTI CON GLI STATI MAGGIORI"
                            Case "Relazioni Istituzionali"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.rel_istit='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.rel_istit='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.rel_istit='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.rel_istit='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.rel_istit='True' AND sospensione='True'"
                                Label8.Text = "SETTORE RELAZIONI ISTITUZIONALI"
                            Case "DAP – Dipartimento Attività Promozionali"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.dap='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.dap='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.dap='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.dap='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.dap='True' AND sospensione='True'"
                                Label8.Text = "SETTORE DIPARTIMENTO ATTIVITA' PROMOZIONALI"
                            Case "RIA – Reparto Investigazioni Ambientali"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ria='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ria='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.ria='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.ria='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.ria='True' AND sospensione='True'"
                                Label8.Text = "SETTORE REPARTO INVESTIGAZIONI AMBIENTALI"
                            Case "RAS – Raggruppamento Analisi Scientifiche"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ras='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ras='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.ras='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.ras='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.ras='True' AND sospensione='True'"
                                Label8.Text = "SETTORE RAGGRUPPAMENTO ANALISI SCIENTIFICHE"
                            Case "Equipaggiamenti Individuali"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.equipaggiamenti='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.equipaggiamenti='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.equipaggiamenti='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.equipaggiamenti='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.equipaggiamenti='True' AND sospensione='True'"
                                Label8.Text = "SETTORE EQUIPAGGIAMENTI INDIVIDUALI"
                            Case "Trasporti Terrestri"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.trasporti_ter='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.trasporti_ter='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.trasporti_ter='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.trasporti_ter='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.trasporti_ter='True' AND sospensione='True'"
                                Label8.Text = "SETTORE TRASPORTI TERRESTRI"
                            Case "Trasporti Aereo Navali"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.t_aereonavale='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.t_aereonavale='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.t_aereonavale='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.t_aereonavale='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.t_aereonavale='True' AND sospensione='True'"
                                Label8.Text = "SETTORE TRASPORTI AEREO NAVALI"
                            Case "Ricerca Scientifica"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ricerca='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.ricerca='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.ricerca='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.ricerca='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.ricerca='True' AND sospensione='True'"
                                Label8.Text = "SETTORE RICERCA SCIENTIFICA"
                            Case "Rapporti con gli Stati Esteri"
                                DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.esteri='True' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False'"
                                DS_soci_inat.SelectCommand = "SELECT * FROM tbl_socio1 INNER JOIN tbl_settori ON tbl_socio1.id_socio = tbl_settori.matricola WHERE " & WhereCondition & " AND tbl_settori.esteri='True' AND dim_g='True' OR " & WhereCondition & " AND tbl_settori.esteri='True' AND dim_s='True' OR " & WhereCondition & " AND tbl_settori.esteri='True' AND espulsione='True' OR " & WhereCondition & " AND tbl_settori.esteri='True' AND sospensione='True'"
                                Label8.Text = "SETTORE RAPPORTI CON GLI STATI ESTERI"
                        End Select
                    Else
                        DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' ORDER BY id_socio ASC;"
                        DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='True' OR " & WhereCondition & " AND dim_s='True' OR " & WhereCondition & " AND espulsione='True' OR " & WhereCondition & " AND sospensione='True'"
                    End If
                End If
            Case "Responsabile di Distaccamento", "Vice Responsabile Distaccamento", "Amministrativo Distaccamento"
                Dim WhereCondition As String = ""
                Dim ctrl As Control
                For Each ctrl In Pan_sede.Controls
                    If TypeOf (ctrl) Is TextBox Then
                        If Not CType(ctrl, TextBox).Text.Equals("") Then
                            If CType(ctrl, TextBox).ToolTip.Equals("id_socio") Then
                                WhereCondition = WhereCondition & CType(ctrl, TextBox).ToolTip.ToString() & " = '" & CType(ctrl, TextBox).Text.ToString() & "' AND "
                            Else
                                WhereCondition = WhereCondition & CType(ctrl, TextBox).ToolTip.ToString() & " LIKE '%" & CType(ctrl, TextBox).Text.ToString() & "%' AND "
                            End If

                        End If
                    ElseIf TypeOf (ctrl) Is DropDownList Then
                        If Not CType(ctrl, DropDownList).SelectedValue.Equals("") Then
                            WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & CType(ctrl, DropDownList).SelectedValue.ToString() & "' AND "
                        Else
                            If CType(ctrl, DropDownList).ID.Equals("DD_qual4") Then
                                Dim num_item As Integer = DD_qual4.Items.Count
                                Dim i As Integer
                                DD_qual4.SelectedIndex = 0
                                WhereCondition = WhereCondition & "("
                                For i = 1 To num_item
                                    If Not DD_qual4.SelectedValue.Equals("") Then
                                        If i = num_item Then
                                            WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & CType(ctrl, DropDownList).SelectedValue.ToString() & "') AND "
                                        Else
                                            WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & CType(ctrl, DropDownList).SelectedValue.ToString() & "' OR "
                                        End If
                                        DD_qual4.SelectedIndex = i
                                    Else
                                        DD_qual4.SelectedIndex = i
                                    End If
                                Next

                                DD_qual4.SelectedIndex = 0
                            End If
                        End If
                    ElseIf TypeOf (ctrl) Is Label Then
                        If Not CType(ctrl, Label).Text.Equals("") Then
                            WhereCondition = WhereCondition & CType(ctrl, Label).ToolTip.ToString() & " = '" & CType(ctrl, Label).Text.ToString() & "' AND "
                        End If
                    End If

                Next
                WhereCondition = WhereCondition & "categ <> 'Socio Ordinario' AND reciclabile = 'False' AND "
                WhereCondition = WhereCondition.Trim()
                If WhereCondition.ToUpper().EndsWith("AND") Then
                    WhereCondition = WhereCondition.Remove(WhereCondition.Length - 3, 3)
                End If
                If WhereCondition.ToUpper().EndsWith("OR") Then
                    WhereCondition = WhereCondition.Remove(WhereCondition.Length - 2, 2)
                End If
                If CheckBox4.Checked = True Then
                    GridView2.Visible = True
                    GridView2.Visible = True
                    Label3.Visible = True
                    Label4.Visible = True
                    Label5.Visible = True
                    Label6.Visible = True
                    Label7.Visible = True
                    Image1.Visible = True
                    Image2.Visible = True
                    Image3.Visible = True
                    Image4.Visible = True
                Else
                    GridView2.Visible = False
                    Label3.Visible = False
                    Label4.Visible = False
                    Label5.Visible = False
                    Label6.Visible = False
                    Label7.Visible = False
                    Image1.Visible = False
                    Image2.Visible = False
                    Image3.Visible = False
                    Image4.Visible = False
                End If
                If WhereCondition = "" Then
                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE com_app='" & lbl_sede.Text & "' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' ORDER BY id_socio ASC;"
                    DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE dim_g='True' OR dim_s='True' OR espulsione='True' OR sospensione='True'"
                Else
                    DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' ORDER BY id_socio ASC;"
                    DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='True' OR " & WhereCondition & " AND dim_s='True' OR " & WhereCondition & " AND espulsione='True' OR " & WhereCondition & " AND sospensione='True'"
                End If
        End Select
    End Sub

    Protected Sub Button8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button8.Click
        ClientScript.RegisterStartupScript(Me.GetType, "win", "<script>window.open('mod_socio.aspx?matr=" & Label1.Text & "')</script>")

    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        Dim DR As DataRowView = CType(e.Row.DataItem, DataRowView)

        If (Not (DR) Is Nothing) Then
            If (CType(DR.Row.ItemArray.GetValue(5), String) = "False") Then
                e.Row.ForeColor = Drawing.Color.Sienna
            End If
            Dim grado As String = Request.Cookies("SITOGNA")("qual")
            Select Case grado
                Case "Dirigente Regionale", "Dirigente Regionale Vicario", "Amministrativo Regionale", "Dirigente Regionale di Settore"
                    Select Case (CType(DR.Row.ItemArray.GetValue(10), String))
                        Case "Dirigente Nazionale di Settore", "Dirigente Interregionale Centro", "Dirigente Interregionale CentroSud", "Dirigente Interregionale CentroNord", "Dirigente Interregionale Isole", "Dirigente Nazionale DVSF", "Dirigente Generale DGSF", "Dirigente Generale Interregionale", "Dirigente Generale Nazionale Vicario", "Dirigente Generale Nazionale", "Dirigente Generale Superiore"
                            'e.Row.Enabled = False
                    End Select
                Case "Dirigente Provinciale", "Dirigente Provinciale Vicario", "Dirigente Provinciale di Settore", "Amministrativo Provinciale"
                    Select Case (CType(DR.Row.ItemArray.GetValue(10), String))
                        Case "Dirigente Nazionale di Settore", "Dirigente Interregionale Centro", "Dirigente Interregionale CentroSud", "Dirigente Interregionale CentroNord", "Dirigente Interregionale Isole", "Dirigente Nazionale DVSF", "Dirigente Generale DGSF", "Dirigente Generale Interregionale", "Dirigente Generale Nazionale Vicario", "Dirigente Generale Nazionale", "Dirigente Generale Superiore", "Dirigente Regionale", "Dirigente Regionale Vicario", "Dirigente Regionale di Settore"
                            'e.Row.Enabled = False
                    End Select
                Case "Dirigente Intermedio"
                    Select Case (CType(DR.Row.ItemArray.GetValue(10), String))
                        Case "Dirigente Nazionale di Settore", "Dirigente Interregionale Centro", "Dirigente Interregionale CentroSud", "Dirigente Interregionale CentroNord", "Dirigente Interregionale Isole", "Dirigente Nazionale DVSF", "Dirigente Generale DGSF", "Dirigente Generale Interregionale", "Dirigente Generale Nazionale Vicario", "Dirigente Generale Nazionale", "Dirigente Generale Superiore", "Dirigente Regionale", "Dirigente Regionale Vicario", "Dirigente Regionale di Settore", "Dirigente Provinciale", "Dirigente Provinciale Vicario", "Dirigente Provinciale di Settore"
                            'e.Row.Enabled = False
                    End Select
                Case "Responsabile di Distaccamento", "Vice Responsabile Distaccamento", "Amministrativo Distaccamento"
                    Select Case (CType(DR.Row.ItemArray.GetValue(10), String))
                        Case "Dirigente Nazionale di Settore", "Dirigente Interregionale Centro", "Dirigente Interregionale CentroSud", "Dirigente Interregionale CentroNord", "Dirigente Interregionale Isole", "Dirigente Nazionale DVSF", "Dirigente Generale DGSF", "Dirigente Generale Interregionale", "Dirigente Generale Nazionale Vicario", "Dirigente Generale Nazionale", "Dirigente Generale Superiore", "Dirigente Regionale", "Dirigente Regionale Vicario", "Dirigente Regionale di Settore", "Dirigente Provinciale", "Dirigente Provinciale Vicario", "Dirigente Provinciale di Settore", "Dirigente Intermedio"
                            'e.Row.Enabled = False
                    End Select
            End Select
        End If

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim selRow As String = GridView1.SelectedDataKey.Value
        Label1.Text = selRow
        Button8.Visible = True
        Button10.Visible = True
        Button11.Visible = True
        Button13.Visible = True
        Button9.Visible = True
        Button14.Visible = True
        Button18.Visible = True
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
        Dim conn As New MySqlConnection(strconn)
        Dim strSQL As String = "SELECT accettazione, docum, finanz FROM tbl_socio1 WHERE id_socio='" & selRow & "'"
        Dim comm As New MySqlCommand(strSQL, conn)
        conn.Open()
        Dim rs As MySqlDataReader = comm.ExecuteReader
        rs.Read()
        Dim accett As String = rs("accettazione")
        Dim docum As String = rs("docum")
        Dim finanz As String = rs("finanz")

        If Request.Cookies("SITOGNA")("qual") = "Presidente" Or Request.Cookies("SITOGNA")("qual") = "Segreteria Presidente" Or Request.Cookies("SITOGNA")("qual") = "WebMaster" Then
            Button12.Visible = True
            Button9.Enabled = True
            Button14.Enabled = True

            If Request.Cookies("SITOGNA")("qual") = "Presidente" Or Request.Cookies("SITOGNA")("qual") = "WebMaster" Then
                Button17.Visible = True

            End If
        Else
            If accett = "True" And docum = "True" And finanz = "True" Then
                Button9.Enabled = True
                Button14.Enabled = True
            Else
                Button9.Enabled = False
                Button14.Enabled = False
            End If
        End If
        Panel1.Visible = True
        Dim conne As New MySqlConnection(strconn)
        Dim strSQLe As String = "SELECT domanda_iscr, doc_ident, cod_fisc, foto FROM tbl_inviodoc WHERE matricola='" & selRow & "'"
        Dim comme As New MySqlCommand(strSQLe, conne)
        conne.Open()
        Dim rse As MySqlDataReader = comme.ExecuteReader

        If rse.HasRows Then
            rse.Read()
            Dim domisc As String = rse("domanda_iscr")
            Dim docid As String = rse("doc_ident")
            Dim codfis As String = rse("cod_fisc")
            Dim foto As String = rse("foto")
            If domisc = "True" Then
                domisc_lbl.ForeColor = Drawing.Color.Green
            Else
                domisc_lbl.ForeColor = Drawing.Color.Red
            End If
            If docid = "True" Then
                docid_lbl.ForeColor = Drawing.Color.Green
            Else
                docid_lbl.ForeColor = Drawing.Color.Red
            End If
            If codfis = "True" Then
                codfisc_lbl.ForeColor = Drawing.Color.Green
            Else
                codfisc_lbl.ForeColor = Drawing.Color.Red
            End If
            If foto = "True" Then
                foto_lbl.ForeColor = Drawing.Color.Green
            Else
                foto_lbl.ForeColor = Drawing.Color.Red
            End If
        Else
            domisc_lbl.ForeColor = Drawing.Color.Red
            docid_lbl.ForeColor = Drawing.Color.Red
            codfisc_lbl.ForeColor = Drawing.Color.Red
            foto_lbl.ForeColor = Drawing.Color.Red
        End If
        conne.Close()
        If accett = "True" Then
            accett_lbl.ForeColor = Drawing.Color.Green
        Else
            accett_lbl.ForeColor = Drawing.Color.Red
        End If
        If finanz = "True" Then
            quota_lbl.ForeColor = Drawing.Color.Green
        Else
            quota_lbl.ForeColor = Drawing.Color.Red
        End If
        conn.Close()
        GridView2.SelectedIndex = -1
    End Sub

    Protected Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim ind_ip As String = Request.ServerVariables("REMOTE_ADDR")
        Dim attiv As String
        attiv = Request.Cookies("SITOGNA")("cogn") & " " & Request.Cookies("SITOGNA")("nome") & " ha stampato il tesserino del socio " & Label1.Text
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
        Dim connlog As New MySqlConnection(strconn)

        Dim StrSqllog As String = "INSERT INTO tbl_log (attivita,indirizzo_ip) VALUES ('" & attiv.Replace("'", "''") & "','" & ind_ip & "');"
        Dim commlog As New MySqlCommand(StrSqllog, connlog)
        connlog.Open()
        commlog.ExecuteNonQuery()
        connlog.Close()

        'stampa il tesserino

        Dim dataI As DateTime = Now()
        Dim conn As New MySqlConnection(strconn)
        Dim strSQL As String = "SELECT * FROM tbl_socio1 WHERE id_socio='" & Label1.Text & "'"
        Dim comm As New MySqlCommand(strSQL, conn)
        conn.Open()
        Dim rs As MySqlDataReader = comm.ExecuteReader
        If rs.HasRows Then
            rs.Read()
            Dim sottosc As String
            If rs("sesso") = "Maschio" Then
                sottosc = "sottoscritto"
            Else
                sottosc = "sottoscritta"
            End If
            Dim connfoto As New MySqlConnection(strconn)
            Dim strSQLfoto As String = "SELECT * FROM tbl_foto1 WHERE id_fot='" & rs("foto") & "'"
            Dim commfoto As New MySqlCommand(strSQLfoto, connfoto)
            connfoto.Open()
            Dim rs_foto As MySqlDataReader = commfoto.ExecuteReader
            rs_foto.Read()
            Dim url_foto As String = "public/foto/" & rs_foto("foto")
            rs_foto.Close()
            connfoto.Close()
            Dim newFile As String = "X:\Inetpub\vhosts\guardianazionaleambientale.eu\httpdocs\public\tesserini\tesserino_" & rs("id_socio") & ".pdf"
            Dim fs As FileStream
            fs = New FileStream(newFile, FileMode.Create, FileAccess.Write, FileShare.None)

            Dim doc As New Document(PageSize.A4, 0, 0, 0, 0)
            Dim write As PdfWriter = PdfWriter.GetInstance(doc, fs)

            doc.Open()
            Dim fronte_guardia As iTextSharp.text.Image
            Select Case rs("grado")
                Case "Aspirante"
                    fronte_guardia = iTextSharp.text.Image.GetInstance(Server.MapPath("img/Aspiranti.jpg"))
                Case "Agente", "Agente Scelto"
                    fronte_guardia = iTextSharp.text.Image.GetInstance(Server.MapPath("img/Agenti_Agenti_Scelti.jpg"))
                Case "Assistente"
                    fronte_guardia = iTextSharp.text.Image.GetInstance(Server.MapPath("img/Funzionari.jpg"))
                Case "Assistente Capo"
                    fronte_guardia = iTextSharp.text.Image.GetInstance(Server.MapPath("img/Funzionari_Capo.jpg"))
                Case "Vice Responsabile Distaccamento", "Responsabile di Distaccamento"
                    fronte_guardia = iTextSharp.text.Image.GetInstance(Server.MapPath("img/Responsabili_Distaccamento.jpg"))
                Case "Dirigente Intermedio"
                    fronte_guardia = iTextSharp.text.Image.GetInstance(Server.MapPath("img/Dirigenti_Intermedi.jpg"))
                Case "Dirigente Provinciale di Settore", "Dirigente Provinciale Vicario", "Dirigente Provinciale"
                    fronte_guardia = iTextSharp.text.Image.GetInstance(Server.MapPath("img/Dirigenti_Provinciali.jpg"))
                Case "Dirigente Regionale di Settore", "Dirigente Regionale Vicario", "Dirigente Regionale"
                    fronte_guardia = iTextSharp.text.Image.GetInstance(Server.MapPath("img/Dirigenti_Regionali.jpg"))
                Case "Dirigente Nazionale di Settore", "Dirigente Interregionale Centro", "Dirigente Interregionale CentroSud", "Dirigente Interregionale CentroNord", "Dirigente Interregionale Isole", "Dirigente Nazionale DVSF"
                    fronte_guardia = iTextSharp.text.Image.GetInstance(Server.MapPath("img/Dirigenti_Nazionali.jpg"))
                Case "Dirigente Generale DGSF", "Dirigente Generale Interregionale", "Dirigente Generale Nazionale Vicario", "Dirigente Generale Nazionale", "Dirigente Generale Superiore"
                    fronte_guardia = iTextSharp.text.Image.GetInstance(Server.MapPath("img/Dirigenti_Generali.jpg"))
                Case Else
                    fronte_guardia = iTextSharp.text.Image.GetInstance(Server.MapPath("img/Aspiranti.jpg"))
            End Select
            Dim fronte_socio As iTextSharp.text.Image
            Select Case rs("categ")
                Case "Socio Ordinario"
                    fronte_socio = iTextSharp.text.Image.GetInstance(Server.MapPath("img/Socio_Ordinario.jpg"))
                Case "Socio Sostenitore"
                    fronte_socio = iTextSharp.text.Image.GetInstance(Server.MapPath("img/Socio_Sostenitori.jpg"))
                Case "Socio Benemerito"
                    fronte_socio = iTextSharp.text.Image.GetInstance(Server.MapPath("img/Socio_Benemeriti.jpg"))
                Case "Socio Simpatizzante"
                    fronte_socio = iTextSharp.text.Image.GetInstance(Server.MapPath("img/Socio_Simpatizzanti.jpg"))
                Case "Socio Junior"
                    fronte_socio = iTextSharp.text.Image.GetInstance(Server.MapPath("img/Socio_Junior.jpg"))
                Case Else
                    fronte_socio = iTextSharp.text.Image.GetInstance(Server.MapPath("img/Socio_Junior.jpg"))
            End Select
            Dim foto As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(Server.MapPath(url_foto))
            Dim foto2 As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(Server.MapPath(url_foto))
            'doc.Add(sfondo)
            fronte_guardia.SetAbsolutePosition(100, 560)
            fronte_guardia.ScalePercent(25)
            fronte_socio.SetAbsolutePosition(100, 100)
            fronte_socio.ScalePercent(25)
            foto.SetAbsolutePosition(132, 636)
            foto.ScalePercent(25)
            foto2.SetAbsolutePosition(132, 176)
            foto2.ScalePercent(25)

            Dim cb As PdfContentByte = write.DirectContent
            Dim bfHelv As BaseFont
            Dim bfHelvB As BaseFont
            bfHelv = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, False)
            bfHelvB = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, False)

            If rs("guardia") = "True" Then
                cb.AddImage(fronte_guardia)
                cb.AddImage(foto)
            End If
            cb.AddImage(fronte_socio)
            cb.AddImage(foto2)
            cb.BeginText()

            'Qualifica
            cb.SetFontAndSize(bfHelv, 7)
            If rs("guardia") = "True" Then
                cb.ShowTextAligned(0, "Qualifica", 218, 737, 0)
            End If
            cb.ShowTextAligned(0, "Qualifica", 218, 277, 0)
            cb.SetFontAndSize(bfHelvB, 8)
            If rs("guardia") = "True" Then
                cb.ShowTextAligned(0, rs("grado"), 218, 729, 0)
            End If
            cb.ShowTextAligned(0, rs("grado"), 218, 269, 0)

            'Matricola
            cb.SetFontAndSize(bfHelv, 7)
            If rs("guardia") = "True" Then
                cb.ShowTextAligned(0, "Matricola", 370, 737, 0)
            End If
            cb.ShowTextAligned(0, "Matricola", 370, 277, 0)
            cb.SetFontAndSize(bfHelvB, 8)
            If rs("guardia") = "True" Then
                cb.ShowTextAligned(0, rs("id_socio"), 370, 729, 0)
            End If
            cb.ShowTextAligned(0, rs("id_socio"), 370, 269, 0)

            'Cognome
            cb.SetFontAndSize(bfHelv, 7)
            If rs("guardia") = "True" Then
                cb.ShowTextAligned(0, "Cognome", 218, 718, 0)
            End If
            cb.ShowTextAligned(0, "Cognome", 218, 258, 0)
            cb.SetFontAndSize(bfHelvB, 8)
            If rs("guardia") = "True" Then
                cb.ShowTextAligned(0, rs("cogn"), 218, 710, 0)
            End If
            cb.ShowTextAligned(0, rs("cogn"), 218, 250, 0)

            'Nome
            cb.SetFontAndSize(bfHelv, 7)
            If rs("guardia") = "True" Then
                cb.ShowTextAligned(0, "Nome", 218, 699, 0)
            End If
            cb.ShowTextAligned(0, "Nome", 218, 240, 0)
            cb.SetFontAndSize(bfHelvB, 8)
            If rs("guardia") = "True" Then
                cb.ShowTextAligned(0, rs("nom"), 218, 691, 0)
            End If
            cb.ShowTextAligned(0, rs("nom"), 218, 232, 0)

            'Data e luogo Nascita
            cb.SetFontAndSize(bfHelv, 7)
            If rs("guardia") = "True" Then
                cb.ShowTextAligned(0, "Data e luogo di nascita", 218, 680, 0)
            End If
            cb.ShowTextAligned(0, "Data e luogo di nascita", 218, 222, 0)
            cb.SetFontAndSize(bfHelvB, 8)
            If rs("guardia") = "True" Then
                cb.ShowTextAligned(0, rs("dat_nasc") & "  " & rs("luog_nasc") & " (" & rs("prov_nasc") & ")", 218, 672, 0)
            End If
            cb.ShowTextAligned(0, rs("dat_nasc") & "  " & rs("luog_nasc") & " (" & rs("prov_nasc") & ")", 218, 214, 0)

            'Altezza
            cb.SetFontAndSize(bfHelv, 7)
            If rs("guardia") = "True" Then
                cb.ShowTextAligned(0, "Altezza", 218, 661, 0)
            End If
            cb.ShowTextAligned(0, "Altezza", 218, 204, 0)
            cb.SetFontAndSize(bfHelvB, 8)
            If rs("guardia") = "True" Then
                cb.ShowTextAligned(0, rs("alt"), 218, 653, 0)
            End If
            cb.ShowTextAligned(0, rs("alt"), 218, 196, 0)

            'Capelli
            cb.SetFontAndSize(bfHelv, 7)
            If rs("guardia") = "True" Then
                cb.ShowTextAligned(0, "Capelli", 250, 661, 0)
            End If
            cb.ShowTextAligned(0, "Capelli", 250, 204, 0)
            cb.SetFontAndSize(bfHelvB, 8)
            If rs("guardia") = "True" Then
                cb.ShowTextAligned(0, UCase(Left(rs("col_cap"), 1)) & LCase(Right(rs("col_cap"), Len(rs("col_cap")) - 1)), 250, 653, 0)
            End If
            cb.ShowTextAligned(0, UCase(Left(rs("col_cap"), 1)) & LCase(Right(rs("col_cap"), Len(rs("col_cap")) - 1)), 250, 196, 0)

            'Occhi
            cb.SetFontAndSize(bfHelv, 7)
            If rs("guardia") = "True" Then
                cb.ShowTextAligned(0, "Occhi", 290, 661, 0)
            End If
            cb.ShowTextAligned(0, "Occhi", 290, 204, 0)
            cb.SetFontAndSize(bfHelvB, 8)
            If rs("guardia") = "True" Then
                cb.ShowTextAligned(0, UCase(Left(rs("col_occ"), 1)) & LCase(Right(rs("col_occ"), Len(rs("col_occ")) - 1)), 290, 653, 0)
            End If
            cb.ShowTextAligned(0, UCase(Left(rs("col_occ"), 1)) & LCase(Right(rs("col_occ"), Len(rs("col_occ")) - 1)), 290, 196, 0)

            'Gruppo Sanguigno
            cb.SetFontAndSize(bfHelv, 7)
            If rs("guardia") = "True" Then
                cb.ShowTextAligned(0, "Gruppo Sanguigno", 340, 661, 0)
            End If
            cb.ShowTextAligned(0, "Gruppo Sanguigno", 340, 204, 0)
            cb.SetFontAndSize(bfHelvB, 8)
            If rs("guardia") = "True" Then
                cb.ShowTextAligned(0, rs("gr_sang") & " RH " & rs("RH"), 340, 653, 0)
            End If
            cb.ShowTextAligned(0, rs("gr_sang") & " RH " & rs("RH"), 340, 196, 0)

            'Validità
            cb.SetFontAndSize(bfHelv, 7)
            If rs("guardia") = "True" Then
                cb.ShowTextAligned(0, "Valida fino al", 218, 642, 0)
            End If
            cb.ShowTextAligned(0, "Valida fino al", 218, 186, 0)
            cb.SetFontAndSize(bfHelvB, 8)
            If rs("guardia") = "True" Then
                cb.ShowTextAligned(0, "31/12/" & dataI.Year, 218, 634, 0)
            End If
            cb.ShowTextAligned(0, "31/12/" & dataI.Year, 218, 178, 0)

            'Ricevuta
            cb.SetFontAndSize(bfHelvB, 9)
            cb.ShowTextAligned(0, "Ricevuta di Consegna", 52, 80, 0)
            cb.SetFontAndSize(bfHelv, 9)
            cb.ShowTextAligned(0, "Io " & sottosc & " " & rs("cogn") & " " & rs("nom") & " dichiaro che in data " & FormatDateTime(Now, vbShortDate) & " ricevo il mio tesserino personale.", 52, 65, 0)
            cb.SetFontAndSize(bfHelvB, 9)
            cb.ShowTextAligned(0, "Firma per ricevuta", 400, 40, 0)
            cb.SetFontAndSize(bfHelvB, 9)
            cb.ShowTextAligned(0, "__________________", 400, 30, 0)


            cb.EndText()

            'codice a barre
            Dim codice As String = Now()
            codice = Replace(codice, ":", "")
            codice = Replace(codice, " ", "")
            codice = Replace(codice, "/", "")
            codice = rs("id_socio") & codice
            Dim code128 As New Barcode128
            code128.Code = codice

            Dim img As iTextSharp.text.Image = code128.CreateImageWithBarcode(cb, iTextSharp.text.BaseColor.BLACK, iTextSharp.text.BaseColor.BLACK)
            If rs("guardia") = "True" Then
                img.SetAbsolutePosition(235, 605)
                img.ScalePercent(70)
                cb.AddImage(img)
            End If

            'riga
            cb.SetLineWidth(1)
            cb.MoveTo(0, 95)
            cb.LineTo(doc.PageSize.Width, 95)
            cb.Stroke()
            If rs("guardia") = "True" Then

                doc.NewPage()
                Dim retro_guardia As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(Server.MapPath("img/Retro.jpg"))

                retro_guardia.SetAbsolutePosition(171, 560)
                retro_guardia.ScalePercent(25)
                cb.AddImage(retro_guardia)
                cb.BeginText()

                cb.SetFontAndSize(bfHelv, 10)
                'decreti

                Dim conndec As New MySqlConnection(strconn)
                Dim strSQLdec As String = "SELECT * FROM tbl_decreti1 WHERE matricola='" & rs("id_socio") & "'"
                Dim commdec As New MySqlCommand(strSQLdec, conndec)
                conndec.Open()
                Dim rs_dec As MySqlDataReader = commdec.ExecuteReader
                If rs_dec.HasRows Then
                    cb.SetFontAndSize(bfHelvB, 7)
                    cb.ShowTextAligned(0, "DECRETI", 341, 735, 0)
                    Dim i As Integer = 1
                    Dim y As Integer = 725
                    While rs_dec.Read
                        cb.SetFontAndSize(bfHelvB, 6)
                        cb.ShowTextAligned(0, i & ".", 323, y, 0)
                        cb.ShowTextAligned(0, "Tipo: " & rs_dec("dec1"), 331, y, 0)
                        cb.ShowTextAligned(0, "Scad: " & rs_dec("data_scad_dec1"), 429, y, 0)
                        cb.ShowTextAligned(0, "Ril: " & rs_dec("dat_ril_dec1"), 383, y, 0)
                        y = y - 9
                        cb.ShowTextAligned(0, "Num: " & rs_dec("num_dec1"), 331, y, 0)
                        cb.ShowTextAligned(0, "Ente: " & rs_dec("ente_dec1"), 381, y, 0)
                        y = y - 9
                        i = i + 1
                        If i = 6 Then
                            Exit While
                        End If
                    End While
                End If
                cb.EndText()
            End If

            doc.Close()


            Dim conncod As New MySqlConnection(strconn)
            Dim strSQLcod As String = "UPDATE tbl_socio1 SET codice_tesserino = '" & codice & "' WHERE id_socio = '" & rs("id_socio") & "'"
            Dim commcod As New MySqlCommand(strSQLcod, conncod)
            conncod.Open()
            commcod.ExecuteNonQuery()
            conncod.Close()
            'Response.Redirect("public/tesserini/tesserino_" & rs("id_socio") & ".pdf")
            ClientScript.RegisterStartupScript(Me.GetType, "win", "<script>window.open('public/tesserini/tesserino_" & rs("id_socio") & ".pdf')</script>")

        Else
            Response.Write("SOCIO NON TROVATO O NON E' POSSIBILI STAMPARE IL TESSERINO PER QUESTO SOCIO")
        End If
        conn.Close()


    End Sub

    Protected Sub GridView2_PageIndexChanged(sender As Object, e As EventArgs) Handles GridView2.PageIndexChanged
        Dim grado As String = Request.Cookies("SITOGNA")("qual")
        Select Case grado
            Case "Presidente", "Segreteria Presidente", "Dirigente Generale Superiore ", "Dirigente Generale Nazionale", "Dirigente Generale Nazionale Vicario", "Amministrativo Nazionale", "Dirigente Generale Interregionale", "Dirigente Interregionale", "Dirigente Nazionale di Settore", "Webmaster", "Dirigente Generale DGSF", "Dirigente Nazionale DVSF"
                Dim WhereCondition As String = ""
                Dim ctrl As Control
                For Each ctrl In Pan_ricerca.Controls
                    If TypeOf (ctrl) Is TextBox Then
                        If Not CType(ctrl, TextBox).Text.Equals("") Then
                            If CType(ctrl, TextBox).ToolTip.Equals("id_socio") Then
                                WhereCondition = WhereCondition & CType(ctrl, TextBox).ToolTip.ToString() & " = '" & CType(ctrl, TextBox).Text.ToString() & "' AND "
                            Else
                                WhereCondition = WhereCondition & CType(ctrl, TextBox).ToolTip.ToString() & " LIKE '%" & CType(ctrl, TextBox).Text.ToString() & "%' AND "
                            End If

                        End If
                    ElseIf TypeOf (ctrl) Is DropDownList Then
                        If Not CType(ctrl, DropDownList).SelectedValue.Equals("") Then
                            WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & CType(ctrl, DropDownList).SelectedValue.ToString() & "' AND "
                        End If
                    ElseIf TypeOf (ctrl) Is Label Then
                        If Not CType(ctrl, Label).Text.Equals("") Then
                            WhereCondition = WhereCondition & CType(ctrl, Label).ToolTip.ToString() & " = '" & CType(ctrl, Label).Text.ToString() & "' AND "
                        End If
                    End If

                Next
                If CheckBox1.Checked = True Then
                    GridView2.Visible = True
                    GridView2.Visible = True
                    Label3.Visible = True
                    Label4.Visible = True
                    Label5.Visible = True
                    Label6.Visible = True
                    Label7.Visible = True
                    Image1.Visible = True
                    Image2.Visible = True
                    Image3.Visible = True
                    Image4.Visible = True
                Else
                    GridView2.Visible = False
                    Label3.Visible = False
                    Label4.Visible = False
                    Label5.Visible = False
                    Label6.Visible = False
                    Label7.Visible = False
                    Image1.Visible = False
                    Image2.Visible = False
                    Image3.Visible = False
                    Image4.Visible = False
                End If

                WhereCondition = WhereCondition.Trim()
                If WhereCondition.ToUpper().EndsWith("AND") Then
                    WhereCondition = WhereCondition.Remove(WhereCondition.Length - 3, 3)
                End If
                If WhereCondition = "" Then
                    DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE dim_g='True' OR dim_s='True' OR espulsione='True' OR sospensione='True'"
                Else
                    DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='True' OR " & WhereCondition & " AND dim_s='True' OR " & WhereCondition & " AND espulsione='True' OR " & WhereCondition & " AND sospensione='True'"
                End If
            Case "Dirigente Regionale", "Dirigente Regionale Vicario", "Amministrativo Regionale", "Dirigente Regionale di Settore"
                Dim WhereCondition As String = ""
                Dim ctrl As Control
                For Each ctrl In Pan_reg.Controls
                    If TypeOf (ctrl) Is TextBox Then
                        If Not CType(ctrl, TextBox).Text.Equals("") Then
                            If CType(ctrl, TextBox).ToolTip.Equals("id_socio") Then
                                WhereCondition = WhereCondition & CType(ctrl, TextBox).ToolTip.ToString() & " = '" & CType(ctrl, TextBox).Text.ToString() & "' AND "
                            Else
                                WhereCondition = WhereCondition & CType(ctrl, TextBox).ToolTip.ToString() & " LIKE '%" & CType(ctrl, TextBox).Text.ToString() & "%' AND "
                            End If

                        End If
                    ElseIf TypeOf (ctrl) Is DropDownList Then
                        If Not CType(ctrl, DropDownList).SelectedValue.Equals("") Then
                            WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & CType(ctrl, DropDownList).SelectedValue.ToString() & "' AND "
                        Else
                            If CType(ctrl, DropDownList).ID.Equals("DD_qual2") Then
                                Dim num_item As Integer = DD_qual2.Items.Count
                                Dim i As Integer
                                DD_qual2.SelectedIndex = 0
                                WhereCondition = WhereCondition & "("
                                For i = 1 To num_item
                                    If Not DD_qual2.SelectedValue.Equals("") Then
                                        If i = num_item Then
                                            WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & CType(ctrl, DropDownList).SelectedValue.ToString() & "') AND"
                                        Else
                                            WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & CType(ctrl, DropDownList).SelectedValue.ToString() & "' OR "
                                        End If
                                        DD_qual2.SelectedIndex = i
                                    Else
                                        DD_qual2.SelectedIndex = i
                                    End If
                                Next

                                DD_qual2.SelectedIndex = 0
                            End If
                        End If
                    ElseIf TypeOf (ctrl) Is Label Then
                        If Not CType(ctrl, Label).Text.Equals("") Then
                            WhereCondition = WhereCondition & CType(ctrl, Label).ToolTip.ToString() & " = '" & CType(ctrl, Label).Text.ToString() & "' AND "
                        End If
                    End If

                Next

                WhereCondition = WhereCondition.Trim()
                If WhereCondition.ToUpper().EndsWith("AND") Then
                    WhereCondition = WhereCondition.Remove(WhereCondition.Length - 3, 3)
                End If
                If WhereCondition.ToUpper().EndsWith("OR") Then
                    WhereCondition = WhereCondition.Remove(WhereCondition.Length - 2, 2)
                End If
                If CheckBox2.Checked = True Then
                    GridView2.Visible = True
                    GridView2.Visible = True
                    Label3.Visible = True
                    Label4.Visible = True
                    Label5.Visible = True
                    Label6.Visible = True
                    Label7.Visible = True
                    Image1.Visible = True
                    Image2.Visible = True
                    Image3.Visible = True
                    Image4.Visible = True
                Else
                    GridView2.Visible = False
                    Label3.Visible = False
                    Label4.Visible = False
                    Label5.Visible = False
                    Label6.Visible = False
                    Label7.Visible = False
                    Image1.Visible = False
                    Image2.Visible = False
                    Image3.Visible = False
                    Image4.Visible = False
                End If
                If WhereCondition = "" Then
                    DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE dim_g='True' OR dim_s='True' OR espulsione='True' OR sospensione='True'"
                Else
                    DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='True' OR " & WhereCondition & " AND dim_s='True' OR " & WhereCondition & " AND espulsione='True' OR " & WhereCondition & " AND sospensione='True'"
                End If
            Case "Dirigente Provinciale", "Dirigente Provinciale Vicario", "Dirigente Provinciale di Settore", "Amministrativo Provinciale"
                Dim WhereCondition As String = ""
                Dim ctrl As Control
                For Each ctrl In Pan_prov.Controls
                    If TypeOf (ctrl) Is TextBox Then
                        If Not CType(ctrl, TextBox).Text.Equals("") Then
                            If CType(ctrl, TextBox).ToolTip.Equals("id_socio") Then
                                WhereCondition = WhereCondition & CType(ctrl, TextBox).ToolTip.ToString() & " = '" & CType(ctrl, TextBox).Text.ToString() & "' AND "
                            Else
                                WhereCondition = WhereCondition & CType(ctrl, TextBox).ToolTip.ToString() & " LIKE '%" & CType(ctrl, TextBox).Text.ToString() & "%' AND "
                            End If

                        End If
                    ElseIf TypeOf (ctrl) Is DropDownList Then
                        If Not CType(ctrl, DropDownList).SelectedValue.Equals("") Then
                            WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & CType(ctrl, DropDownList).SelectedValue.ToString() & "' AND "
                        Else
                            If CType(ctrl, DropDownList).ID.Equals("DD_qual3") Then
                                Dim num_item As Integer = DD_qual2.Items.Count
                                Dim i As Integer
                                DD_qual3.SelectedIndex = 0
                                WhereCondition = WhereCondition & "("
                                For i = 1 To num_item
                                    If Not DD_qual3.SelectedValue.Equals("") Then
                                        If i = num_item Then
                                            WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & CType(ctrl, DropDownList).SelectedValue.ToString() & "') AND"
                                        Else
                                            WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & CType(ctrl, DropDownList).SelectedValue.ToString() & "' OR "
                                        End If
                                        DD_qual3.SelectedIndex = i
                                    Else
                                        DD_qual3.SelectedIndex = i
                                    End If
                                Next

                                DD_qual3.SelectedIndex = 0
                            End If
                        End If
                    ElseIf TypeOf (ctrl) Is Label Then
                        If Not CType(ctrl, Label).Text.Equals("") Then
                            WhereCondition = WhereCondition & CType(ctrl, Label).ToolTip.ToString() & " = '" & CType(ctrl, Label).Text.ToString() & "' AND "
                        End If
                    End If

                Next

                WhereCondition = WhereCondition.Trim()
                If WhereCondition.ToUpper().EndsWith("AND") Then
                    WhereCondition = WhereCondition.Remove(WhereCondition.Length - 3, 3)
                End If
                If WhereCondition.ToUpper().EndsWith("OR") Then
                    WhereCondition = WhereCondition.Remove(WhereCondition.Length - 2, 2)
                End If
                If CheckBox3.Checked = True Then
                    GridView2.Visible = True
                    GridView2.Visible = True
                    Label3.Visible = True
                    Label4.Visible = True
                    Label5.Visible = True
                    Label6.Visible = True
                    Label7.Visible = True
                    Image1.Visible = True
                    Image2.Visible = True
                    Image3.Visible = True
                    Image4.Visible = True
                Else
                    GridView2.Visible = False
                    Label3.Visible = False
                    Label4.Visible = False
                    Label5.Visible = False
                    Label6.Visible = False
                    Label7.Visible = False
                    Image1.Visible = False
                    Image2.Visible = False
                    Image3.Visible = False
                    Image4.Visible = False
                End If
                If WhereCondition = "" Then
                    DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE dim_g='True' OR dim_s='True' OR espulsione='True' OR sospensione='True'"
                Else
                    DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='True' OR " & WhereCondition & " AND dim_s='True' OR " & WhereCondition & " AND espulsione='True' OR " & WhereCondition & " AND sospensione='True'"
                End If
            Case "Responsabile di Distaccamento", "Vice Responsabile Distaccamento", "Amministrativo Distaccamento"
                Dim WhereCondition As String = ""
                Dim ctrl As Control
                For Each ctrl In Pan_sede.Controls
                    If TypeOf (ctrl) Is TextBox Then
                        If Not CType(ctrl, TextBox).Text.Equals("") Then
                            If CType(ctrl, TextBox).ToolTip.Equals("id_socio") Then
                                WhereCondition = WhereCondition & CType(ctrl, TextBox).ToolTip.ToString() & " = '" & CType(ctrl, TextBox).Text.ToString() & "' AND "
                            Else
                                WhereCondition = WhereCondition & CType(ctrl, TextBox).ToolTip.ToString() & " LIKE '%" & CType(ctrl, TextBox).Text.ToString() & "%' AND "
                            End If

                        End If
                    ElseIf TypeOf (ctrl) Is DropDownList Then
                        If Not CType(ctrl, DropDownList).SelectedValue.Equals("") Then
                            WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & CType(ctrl, DropDownList).SelectedValue.ToString() & "' AND "
                        Else
                            If CType(ctrl, DropDownList).ID.Equals("DD_qual4") Then
                                Dim num_item As Integer = DD_qual4.Items.Count
                                Dim i As Integer
                                DD_qual4.SelectedIndex = 0
                                WhereCondition = WhereCondition & "("
                                For i = 1 To num_item
                                    If Not DD_qual4.SelectedValue.Equals("") Then
                                        If i = num_item Then
                                            WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & CType(ctrl, DropDownList).SelectedValue.ToString() & "') AND"
                                        Else
                                            WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & CType(ctrl, DropDownList).SelectedValue.ToString() & "' OR "
                                        End If
                                        DD_qual4.SelectedIndex = i
                                    Else
                                        DD_qual4.SelectedIndex = i
                                    End If
                                Next

                                DD_qual4.SelectedIndex = 0
                            End If
                        End If
                    ElseIf TypeOf (ctrl) Is Label Then
                        If Not CType(ctrl, Label).Text.Equals("") Then
                            WhereCondition = WhereCondition & CType(ctrl, Label).ToolTip.ToString() & " = '" & CType(ctrl, Label).Text.ToString() & "' AND "
                        End If
                    End If

                Next

                WhereCondition = WhereCondition.Trim()
                If WhereCondition.ToUpper().EndsWith("AND") Then
                    WhereCondition = WhereCondition.Remove(WhereCondition.Length - 3, 3)
                End If
                If WhereCondition.ToUpper().EndsWith("OR") Then
                    WhereCondition = WhereCondition.Remove(WhereCondition.Length - 2, 2)
                End If
                If CheckBox4.Checked = True Then
                    GridView2.Visible = True
                    GridView2.Visible = True
                    Label3.Visible = True
                    Label4.Visible = True
                    Label5.Visible = True
                    Label6.Visible = True
                    Label7.Visible = True
                    Image1.Visible = True
                    Image2.Visible = True
                    Image3.Visible = True
                    Image4.Visible = True
                Else
                    GridView2.Visible = False
                    Label3.Visible = False
                    Label4.Visible = False
                    Label5.Visible = False
                    Label6.Visible = False
                    Label7.Visible = False
                    Image1.Visible = False
                    Image2.Visible = False
                    Image3.Visible = False
                    Image4.Visible = False
                End If
                If WhereCondition = "" Then
                    DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE dim_g='True' OR dim_s='True' OR espulsione='True' OR sospensione='True'"
                Else
                    DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='True' OR " & WhereCondition & " AND dim_s='True' OR " & WhereCondition & " AND espulsione='True' OR " & WhereCondition & " AND sospensione='True'"
                End If
        End Select
    End Sub

    Protected Sub GridView2_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView2.RowDataBound
        Dim DR As DataRowView = CType(e.Row.DataItem, DataRowView)

        If (Not (DR) Is Nothing) Then
            If (CType(DR.Row.ItemArray.GetValue(7), String) = "True") Then
                e.Row.ForeColor = Drawing.Color.Violet
            Else
                If (CType(DR.Row.ItemArray.GetValue(6), String) = "True") Then
                    e.Row.ForeColor = Drawing.Color.YellowGreen
                Else
                    If (CType(DR.Row.ItemArray.GetValue(5), String) = "True") Then
                        e.Row.ForeColor = Drawing.Color.Green
                        If (CType(DR.Row.ItemArray.GetValue(4), String) = "True") Then
                            e.Row.ForeColor = Drawing.Color.Red
                        End If
                    Else
                        If (CType(DR.Row.ItemArray.GetValue(4), String) = "True") Then
                            e.Row.ForeColor = Drawing.Color.Red
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Protected Sub GridView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView2.SelectedIndexChanged
        Dim selRow As String = GridView2.SelectedDataKey.Value
        Label1.Text = selRow
        Button8.Visible = True
        Button9.Visible = True
        Button10.Visible = True
        Button13.Visible = True
        Button14.Visible = True
        Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
        Dim conn As New MySqlConnection(strconn)
        Dim strSQL As String = "SELECT accettazione, docum, finanz FROM tbl_socio1 WHERE id_socio='" & selRow & "'"
        Dim comm As New MySqlCommand(strSQL, conn)
        conn.Open()
        Dim rs As MySqlDataReader = comm.ExecuteReader
        rs.Read()
        Dim accett As String = rs("accettazione")
        Dim docum As String = rs("docum")
        Dim finanz As String = rs("finanz")
        If Request.Cookies("SITOGNA")("qual") = "Presidente" Or Request.Cookies("SITOGNA")("qual") = "Segreteria Presidente" Then
            Button12.Visible = True
            Button9.Enabled = True
            Button14.Enabled = True
        Else
            If accett = "True" And docum = "True" And finanz = "True" Then
                Button9.Enabled = True
                Button14.Enabled = True
            Else
                Button9.Enabled = False
                Button14.Enabled = False
            End If
        End If
        If Request.Cookies("SITOGNA")("qual") = "Presidente" Or Request.Cookies("SITOGNA")("qual") = "Segreteria Presidente" Or Request.Cookies("SITOGNA")("qual") = "WebMaster" Then
            Button11.Visible = True
        End If
        Panel1.Visible = True
        Dim conne As New MySqlConnection(strconn)
        Dim strSQLe As String = "SELECT domanda_iscr, doc_ident, cod_fisc, foto FROM tbl_inviodoc WHERE matricola='" & selRow & "'"
        Dim comme As New MySqlCommand(strSQLe, conne)
        conne.Open()
        Dim rse As MySqlDataReader = comme.ExecuteReader

        If rse.HasRows Then
            rse.Read()
            Dim domisc As String = rse("domanda_iscr")
            Dim docid As String = rse("doc_ident")
            Dim codfis As String = rse("cod_fisc")
            Dim foto As String = rse("foto")
            If domisc = "True" Then
                domisc_lbl.ForeColor = Drawing.Color.Green
            Else
                domisc_lbl.ForeColor = Drawing.Color.Red
            End If
            If docid = "True" Then
                docid_lbl.ForeColor = Drawing.Color.Green
            Else
                docid_lbl.ForeColor = Drawing.Color.Red
            End If
            If codfis = "True" Then
                codfisc_lbl.ForeColor = Drawing.Color.Green
            Else
                codfisc_lbl.ForeColor = Drawing.Color.Red
            End If
            If foto = "True" Then
                foto_lbl.ForeColor = Drawing.Color.Green
            Else
                foto_lbl.ForeColor = Drawing.Color.Red
            End If
        Else
            domisc_lbl.ForeColor = Drawing.Color.Red
            docid_lbl.ForeColor = Drawing.Color.Red
            codfisc_lbl.ForeColor = Drawing.Color.Red
            foto_lbl.ForeColor = Drawing.Color.Red
        End If
        conne.Close()
        If accett = "True" Then
            accett_lbl.ForeColor = Drawing.Color.Green
        Else
            accett_lbl.ForeColor = Drawing.Color.Red
        End If
        If finanz = "True" Then
            quota_lbl.ForeColor = Drawing.Color.Green
        Else
            quota_lbl.ForeColor = Drawing.Color.Red
        End If
        conn.Close()
        GridView1.SelectedIndex = -1
    End Sub

    Protected Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        ClientScript.RegisterStartupScript(Me.GetType, "win", "<script>window.open('vis_socio.aspx?matr=" & Label1.Text & "')</script>")

    End Sub

    Protected Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        ClientScript.RegisterStartupScript(Me.GetType, "win", "<script>window.open('ins_dimissioni.aspx?matr=" & Label1.Text & "')</script>")

    End Sub

    Protected Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        ClientScript.RegisterStartupScript(Me.GetType, "win", "<script>window.open('corr_doc.aspx?matr=" & Label1.Text & "')</script>")
    End Sub

    Protected Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        ClientScript.RegisterStartupScript(Me.GetType, "win", "<script>window.open('accet.aspx?matr=" & Label1.Text & "')</script>")
    End Sub

    Protected Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        ClientScript.RegisterStartupScript(Me.GetType, "win", "<script>window.open('public/tesserini/tesserino_" & Label1.Text & ".pdf')</script>")

    End Sub



    Protected Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Dim WhereCondition As String = ""
        Dim ctrl As Control
        For Each ctrl In Pan_intermedio.Controls
            If TypeOf (ctrl) Is TextBox Then
                If Not CType(ctrl, TextBox).Text.Equals("") Then
                    If CType(ctrl, TextBox).ToolTip.Equals("id_socio") Then
                        WhereCondition = WhereCondition & CType(ctrl, TextBox).ToolTip.ToString() & " = '" & CType(ctrl, TextBox).Text.ToString() & "' AND "
                    Else
                        text_ric = Replace(CType(ctrl, TextBox).Text.ToString(), "'", "''")
                        WhereCondition = WhereCondition & CType(ctrl, TextBox).ToolTip.ToString() & " LIKE '%" & text_ric & "%' AND "
                    End If

                End If
            ElseIf TypeOf (ctrl) Is DropDownList Then
                If Not CType(ctrl, DropDownList).SelectedValue.Equals("") Then
                    DD_ric = Replace(CType(ctrl, DropDownList).SelectedValue.ToString(), "'", "''")
                    WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & DD_ric & "' AND "
                Else
                    If CType(ctrl, DropDownList).ID.Equals("DD_sedi") Then
                        Dim strconn As String = WebConfigurationManager.ConnectionStrings("GNA_ConnectionString").ConnectionString
                        Dim conn As New MySqlConnection(strconn)
                        Dim strSql As String
                        Dim matricola As String = Request.Cookies("SITOGNA")("matricola")
                        strSql = "SELECT * FROM tbl_gruppidist WHERE matricola = '" & matricola & "';"
                        Dim comm As New MySqlCommand(strSql, conn)
                        conn.Open()
                        Dim rs As MySqlDataReader = comm.ExecuteReader
                        Dim List As System.Web.UI.WebControls.ListItem
                        If Not Page.IsPostBack Then
                            DD_sedi.Items.Clear()
                            List = New WebControls.ListItem("", "", True)
                            DD_sedi.Items.Add(List)
                        End If
                        WhereCondition = WhereCondition & "("
                        While rs.Read
                            If Not Page.IsPostBack Then
                                List = New WebControls.ListItem(rs("sede"), rs("sede"), True)
                                DD_sedi.Items.Add(List)
                            End If
                            WhereCondition = WhereCondition & "com_app = '" & rs("sede") & "' OR "
                        End While
                        WhereCondition = WhereCondition.Trim()
                        If WhereCondition.ToUpper().EndsWith("OR") Then
                            WhereCondition = WhereCondition.Remove(WhereCondition.Length - 3, 3)
                        End If
                        WhereCondition = WhereCondition & ") AND "
                        rs.Close()
                        conn.Close()

                    End If
                    If CType(ctrl, DropDownList).ID.Equals("DD_qual5") Then
                        Dim num_item As Integer = DD_qual5.Items.Count
                        Dim i As Integer
                        DD_qual5.SelectedIndex = 0
                        WhereCondition = WhereCondition & "("
                        For i = 1 To num_item
                            If Not DD_qual5.SelectedValue.Equals("") Then
                                If i = num_item Then
                                    WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & CType(ctrl, DropDownList).SelectedValue.ToString() & "') AND "
                                Else
                                    WhereCondition = WhereCondition & CType(ctrl, DropDownList).ToolTip.ToString() & " = '" & CType(ctrl, DropDownList).SelectedValue.ToString() & "' OR "
                                End If
                                DD_qual5.SelectedIndex = i
                            Else
                                DD_qual5.SelectedIndex = i
                            End If
                        Next

                        DD_qual5.SelectedIndex = 0
                    End If
                End If
            ElseIf TypeOf (ctrl) Is Label Then
                If Not CType(ctrl, Label).Text.Equals("") Then
                    lbl_ric = Replace(CType(ctrl, Label).Text.ToString(), "'", "''")
                    WhereCondition = WhereCondition & CType(ctrl, Label).ToolTip.ToString() & " = '" & lbl_ric & "' AND "
                End If
            End If

        Next
        WhereCondition = WhereCondition & "categ <> 'Socio Ordinario' AND reciclabile = 'False' AND "
        WhereCondition = WhereCondition.Trim()
        If WhereCondition.ToUpper().EndsWith("AND") Then
            WhereCondition = WhereCondition.Remove(WhereCondition.Length - 3, 3)
        End If
        If WhereCondition.ToUpper().EndsWith("OR") Then
            WhereCondition = WhereCondition.Remove(WhereCondition.Length - 2, 2)
        End If
        If CheckBox5.Checked = True Then
            GridView2.Visible = True
            Label3.Visible = True
            Label4.Visible = True
            Label5.Visible = True
            Label6.Visible = True
            Label7.Visible = True
            Image1.Visible = True
            Image2.Visible = True
            Image3.Visible = True
            Image4.Visible = True
        Else
            GridView2.Visible = False
            Label3.Visible = False
            Label4.Visible = False
            Label5.Visible = False
            Label6.Visible = False
            Label7.Visible = False
            Image1.Visible = False
            Image2.Visible = False
            Image3.Visible = False
            Image4.Visible = False
        End If
        If WhereCondition = "" Then
            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE com_app='" & lbl_sede.Text & "' AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' ORDER BY id_socio ASC;"
            DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE dim_g='True' OR dim_s='True' OR espulsione='True' OR sospensione='True'"
        Else
            'Response.Write("SELECT * FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' ORDER BY id_socio ASC;")
            DS_ricerca.SelectCommand = "SELECT * FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' ORDER BY id_socio ASC;"
            DS_soci_inat.SelectCommand = "SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE " & WhereCondition & " AND dim_g='True' OR " & WhereCondition & " AND dim_s='True' OR " & WhereCondition & " AND espulsione='True' OR " & WhereCondition & " AND sospensione='True'"
        End If
        GridView1.PageIndex = 0
        GridView2.PageIndex = 0
        GridView2.DataBind()
    End Sub

    Protected Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        ClientScript.RegisterStartupScript(Me.GetType, "win", "<script>window.open('vis_log_socio.aspx?matr=" & Label1.Text & "')</script>")
    End Sub

    Protected Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        ClientScript.RegisterStartupScript(Me.GetType, "win", "<script>window.open('avanzamento.aspx?matr=" & Label1.Text & "')</script>")
    End Sub

End Class