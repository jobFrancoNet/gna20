<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="riservata.aspx.vb" Inherits="GNAVBMForm.riservata" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
   <style type="text/css">

b { color: #000040; }

h2 { 
	font-family: Arial !important;
	font-size: 13px;
	text-align: center;
	color: #ffffff;
	background-color: #000040;
	padding: 3px;
	margin: 0px !important;
	width: 99%; }

caption { 
	font-family: Arial !important;
	font-size: 13px;
	text-align: center;
	color: #ffffff;
	background-color: #000040;
	padding: 3px;
	margin: 0px !important;
	width: 100%; }

#benvenuto { 
	border: 1px solid #a3a3a3;
	width: 846px;
	padding: 15px;
	margin-bottom: 30px;
	height: 90px; }

#documenti { 
	border: 1px solid #a3a3a3;
	width: 846px;
	padding: 15px;
	height: 100%;
	clear: both; 
    }

#circolari { 
    border: 1px solid #a3a3a3;
	width: 846px;
	padding: 15px;
	margin-bottom: 30px;
	height: 250px; }

#iscrizioni { 
	height: 470px; }

#esclusioni { 
	height: 470px; }

.div-sx {
	border: 1px solid #a3a3a3;
	width: 393px;
	padding: 15px;
	margin-bottom: 30px;
	margin-right: 15px;
	height: 180px; }

.div-dx {
	border: 1px solid #a3a3a3;
	width: 393px;
	padding: 15px;
	margin-bottom: 30px;
	margin-left: 15px; 
	height: 180px; }

    </style>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="pagina">
	<h1>AREA RISERVATA</h1>
		<div id="benvenuto" class="border-radius">
			<h2>Benvenuto</h2>
			<br/>
			<table border="0" width="100%">
			<tr>
			<td width="42%">
			<b>Utente: </b><%: nome%> <%: cogn%><br/>
			<b>Qualifica: </b><%: qual%><br/>
			<b>Incarico: </b><%: incarico %><br/>
			</td>
			<td>
			<a runat="server" id="ticketButton" href="ticket.aspx" target="_blank">APRI UN TICKET</a><br/>
			</td>
			<td align="right">
			<div class="pulsante-logout"><asp:ImageButton ID="Button1" runat="server" ImageUrl="~/img/pulsante-logout.png" BorderStyle="None" ValidationGroup="1" /></div>
			</td>
			</tr>
			</table>
		</div>


		<asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                
			   <div id="circolari" class="border-radius">
		<h2>Circolari e comunicazioni interne</h2>
		<br/>
		<asp:DataList ID="DataList2" runat="server" DataSourceID="SqlDataSource1" CellPadding="4" DataKeyField="id_news" Width="100%">
                <AlternatingItemStyle BackColor="White"/>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="#F7F6F3" />
                <ItemTemplate>
                     <asp:Label ID="titoloLabel" runat="server" Font-Bold="True" ForeColor="000040" Text='<%# Eval("titolo") %>'/>
		     <br />
                     <asp:Label ID="descrizioneLabel" runat="server" Text='<%# Eval("descrizione") %>' />
                     <br />
                     <asp:HyperLink ID="HyperLink2" runat="server" Target="_blank" NavigateUrl='<%# strFileAl + Eval("file") %>' Text="Clicca qui per aprire l'allegato" Font-Size="X-Small"></asp:HyperLink>
                     <br />
                </ItemTemplate>
                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True"/>
                </asp:DataList>
                <br />
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/stor_circol.aspx" Target="_blank">Visualizza tutte le circolari</asp:HyperLink>
                <br />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM tbl_news WHERE privato='True' ORDER BY data_ora DESC LIMIT 3"></asp:SqlDataSource>
				</div>
                    <div id="colonna-sx">
                    <div id="iscrizioni" class="div-sx border-radius">
                        <h2>Iscrizioni</h2>
                        <br />

                        <asp:DataList ID="DataList8" runat="server" CellPadding="4" DataSourceID="SqlDataSource7" Width="100%">
                            <AlternatingItemStyle BackColor="White" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <ItemStyle BackColor="#F7F6F3" />
                            <ItemTemplate>
                                <b>Data Iscrizione:</b>
                                <asp:Label ID="data_iscrizioneLabel0" runat="server" Text='<%# Eval("dat_iscr") %>' />
                                &nbsp;&nbsp;<b>Matricola:</b>
                                <asp:Label ID="id_socioLabel0" runat="server" Text='<%# Eval("id_socio") %>' />
                                <br />
                                <b>Nominativo:</b>
                                <asp:Label ID="cognLabel0" runat="server" Text='<%# Eval("cogn") %>' />
                                <asp:Label ID="nomLabel0" runat="server" Text='<%# Eval("nom") %>' />
                                &nbsp;&nbsp;<b>Sede:</b>
                                <asp:Label ID="com_appLabel0" runat="server" Text='<%# Eval("com_app") %>' />
                                <br />
                                <br />
                            </ItemTemplate>
                            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" />
                        </asp:DataList>
                        <br />
                        <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/stor_iscrizioni.aspx" Target="_blank">Visualizza tutte le nuove iscrizioni</asp:HyperLink>
                        <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" SelectCommand="SELECT id_socio, dat_iscr, com_app, cogn, nom FROM tbl_socio1 ORDER BY id_socio DESC LIMIT 6"></asp:SqlDataSource>

                        </div>
                        <div class="div-sx border-radius" runat="server" id="boxcorsi">
                            <h2>Gestione corsi attivi</h2>
                            <br />
                            <asp:SqlDataSource ID="SqLCorsi" runat="server" ConnectionString="<%$ ConnectionStrings:GNACORSI_ConnectionString %>" ProviderName="<%$ ConnectionStrings:GNACORSI_ConnectionString.ProviderName %>" SelectCommand="SELECT NomeCorso FROM anagrafica_corsi"></asp:SqlDataSource>
                            <asp:DataList ID="ELENCO_CORSI" runat="server" DataSourceID="SqLCorsi">
                                <ItemTemplate>
                           
                                <asp:Label ID="LINKCORSO" runat="server" Text='<%# Eval("NomeCorso") %>'  />
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
			   <div class="div-sx border-radius">
			            <h2>Gestione soci</h2>
			            <br/>
				    <a href="regsocio.aspx" target="_blank">Inserisci nuovo socio</a><br/>
			            <a href="ric_socio.aspx" target="_blank">Ricerca / modifica / visualizza scheda socio</a><br/>
			            <a href="ins_dimissioni.aspx" target="_blank">Gestione dimissioni / sospensioni</a><br/>
			            <a href="matricole_old.aspx" target="_blank">Riassegnazione matricole</a><br/>
			            <a href="scambio_matr.aspx" target="_blank">Scambio matricole</a><br/>
			            <a href="gest_quote.aspx" target="_blank">Gestione quote</a><br />
                        <a href="mod_anagrafica.aspx" target="_blank">Modifica la tua anagrafica</a><br /> 
                        <a href="quote_socio.aspx" target="_blank">Gestisci le tue quote sociali</a><br />
			        </div>
    			    <div class="div-sx border-radius">
 				    <h2>Gestione simpatizzanti</h2>
			            <br/>
				    <a href="ins_simpatizzanti.aspx" target="_blank">Inserisci nuovo simpatizzante</a><br/>
			            <a href="gest_simpatizzanti.aspx" target="_blank">Ricerca / modifica / visualizza scheda simpatizzante</a><br/>
			        </div>
			        <div class="div-sx border-radius">
			            <h2>Gestione economica sedi</h2>
			            <br/>
			            <a href="">Inserisci nuova spesa / donazione</a><br/>
			            <a href="">Ricerca / modifica / visualizza donazione</a><br/>
			            <a href="">Visualizza rendiconto di periodo</a><br/>
			        </div>
			        <div class="div-sx border-radius">
			            <h2>Inserimenti</h2>
			            <br/>
			            <a href="ins_sedi.aspx" target="_blank">Inserisci sedi</a><br/>
			            <a href="">Inserisci convenzioni</a><br/>
			            <a href="">Inserisci documenti</a><br/>
			            <a href="">Inserisci bilancio</a><br/>
                        <a href="ins_news.aspx" target="_blank">Inserisci news</a><br/>
			        </div>
		        </div>
		        <div id="colonna-dx">
				<div id="esclusioni" class="div-dx border-radius">
				<h2>Esclusioni</h2>
		<br/>
		<asp:DataList ID="DataList3" runat="server" DataSourceID="SqlDataSource2" CellPadding="4" Width="100%">
                <AlternatingItemStyle BackColor="White" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="#F7F6F3" />
                <ItemTemplate>
                    <b>Data Uscita:</b>
                    <asp:Label ID="date_usciteLabel" runat="server" Text='<%# Eval("date_uscite") %>' />
                    &nbsp;&nbsp;<b>Matricola:</b>
                    <asp:Label ID="id_socioLabel" runat="server" Text='<%# Eval("id_socio") %>' />
                    <br />
		    <b>Nominativo:</b>
                    <asp:Label ID="cognLabel" runat="server" Text='<%# Eval("cogn") %>' />
		    <asp:Label ID="nomLabel" runat="server" Text='<%# Eval("nom") %>' />
                    &nbsp;&nbsp;<b>Sede:</b>
                    <asp:Label ID="com_appLabel" runat="server" Text='<%# Eval("com_app") %>' />
                    <br /><b>Motivazione:</b>&nbsp;<asp:Label ID="motivazioneLabel" runat="server"></asp:Label>
                    <br />
                    <asp:HiddenField ID="dimgHF" runat="server" Value='<%# Eval("dim_g") %>' />
                    <asp:HiddenField ID="dimsHF" runat="server" Value='<%# Eval("dim_s") %>' />
                    <asp:HiddenField ID="sospHF" runat="server" Value='<%# Eval("sospensione") %>' />
                    <asp:HiddenField ID="espulHF" runat="server" Value='<%# Eval("espulsione") %>' />
                    
                    <asp:HiddenField ID="motivo_sospHF" runat="server" Value='<%# Eval("motivo_sosp") %>' />
                    <asp:HiddenField ID="motivo_espulHF" runat="server" Value='<%# Eval("motivo_espul") %>' />
                    
                    <asp:HiddenField ID="decadenzaHF" runat="server" Value='<%# Eval("decadenza") %>' />
                    
                </ItemTemplate>
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True"/>
                </asp:DataList>
                <br />
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/stor_uscite.aspx" Target="_blank">Visualizza tutte le esclusioni</asp:HyperLink>
                <br />
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" SelectCommand="SELECT `dat_dim_g` AS `date_uscite`, `id_socio`, `cogn`, `nom`, `com_app`, `dim_g`, `dim_s`, `sospensione`, `espulsione`, `motivo_sosp`, `motivo_espul`, `decadenza` FROM `tbl_socio1` WHERE `dim_g` = 'True' UNION SELECT `dat_dim_s`, `id_socio`, `cogn`, `nom`, `com_app`, `dim_g`, `dim_s`, `sospensione`, `espulsione`, `motivo_sosp`, `motivo_espul`, `decadenza` FROM `tbl_socio1` WHERE `dim_s` = 'True' UNION SELECT `data_inz_sosp`, `id_socio`, `cogn`, `nom`, `com_app`, `dim_g`, `dim_s`, `sospensione`, `espulsione`, `motivo_sosp`, `motivo_espul`, `decadenza` FROM `tbl_socio1` WHERE `sospensione` = 'True' UNION SELECT `data_espul`, `id_socio`, `cogn`, `nom`, `com_app`, `dim_g`, `dim_s`, `sospensione`, `espulsione`, `motivo_sosp`, `motivo_espul`, `decadenza` FROM `tbl_socio1` WHERE `espulsione` = 'True' UNION SELECT `data_decad`, `id_socio`, `cogn`, `nom`, `com_app`, `dim_g`, `dim_s`, `sospensione`, `espulsione`, `motivo_sosp`, `motivo_espul`, `decadenza` FROM `tbl_socio1` WHERE `decadenza` = 'True' ORDER BY STR_TO_DATE(`date_uscite`, '%d/%m/%Y') DESC LIMIT 6"></asp:SqlDataSource>
		</div>
			        <div class="div-dx border-radius">
			            <h2>Gestione sito</h2>
			            <br/>
			            <a href="agg_galleria.aspx" target="_blank">Aggiungi foto galleria</a><br/>
			            <a href="agg_articoli.aspx" target="_blank">Aggiungi articolo</a><br/>
			            <a href="#">Inserisci contatti</a><br/>
			            <a href="ins_accesso.aspx" target="_blank">Genera accesso</a><br/>
			            <a href="mod_pwd.aspx" target="_blank">Modifica password</a><br/>
			            <a href="http://webmail.guardianazionaleambientale.eu" target="_blank">Leggi email</a>
			        </div>

				<div class="div-dx border-radius">
			            <h2>Gestione servizi</h2>
			            <br/>
			            <a href="">Inserisci nuovo servizio</a><br/>
			            <a href="">Ricerca / modifica / visualizza servizio</a><br/>
			            <a href="">Compila relazione di servizio</a><br/>
			            <a href="">Gestione economica servizi</a><br/>
			            <a href="">Gestione calendario servizi</a><br/>
                    -------------------------------<br />
                    <a href="elenco_rapp_asso.aspx" target="_blank">Gestione Schede ASSO</a><br />
                    <a href="visualizza_sacchetti.aspx" target="_blank">Visualizza Sacchetti ASSO</a><br />
			        </div> 
			        <div class="div-dx border-radius">
			            <h2>Gestione equipaggiamenti e automezzi</h2>
			            <br/>
			            <a href="gest_equip_individuali.aspx" target="_blank">Gestione equipaggiamenti individuali</a><br/>
			            <a href="#">Gestione equipaggiamenti generali</a><br/>
				    <a href="ins_mezzi.aspx" target="_blank">Inserisci / modifica automezzo</a><br/>
			            <a href="vis_mezzi.aspx" target="_blank">Visualizza / richiedi automezzo</a><br/>
			        </div>
			        <div class="div-dx border-radius">
			            <h2>Report</h2>
			            <br/>
			            <a href="vis_log.aspx" target="_blank">Visualizza log</a><br/>
			            <a href="vis_log_tes.aspx" target="_blank">Visualizza log tesserini</a><br/>
			            <a href="">Elenco telefonico</a><br/>
                        <asp:HyperLink ID="HyperLink7" runat="server" Target="_blank" NavigateUrl="~/ver_versamenti.aspx">Quote Sociali</asp:HyperLink><br/>
                        <asp:HyperLink ID="HyperLink8" runat="server" Target="_blank" NavigateUrl="~/soci_regola_contr.aspx">Soci in regola</asp:HyperLink>
			            <br />
                        <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/stampexsedi.aspx" Target="_blank" Visible="False">Rinnovo quote - stampe comulative</asp:HyperLink>
			        </div>
		        </div>
            </asp:View>
            <asp:View ID="View2" runat="server">
               
                    <div id="circolari" class="border-radius">
		<h2>Circolari e comunicazioni interne</h2>
		<br/>
		<asp:DataList ID="DataList4" runat="server" DataSourceID="SqlDataSource1" CellPadding="4" DataKeyField="id_news" Height="20px" Width="100%">
                <AlternatingItemStyle BackColor="White"/>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="#F7F6F3" />
                <ItemTemplate>
                     <asp:Label ID="titoloLabel" runat="server" Font-Bold="True" ForeColor="000040" Text='<%# Eval("titolo") %>'/>
		     <br />
                     <asp:Label ID="descrizioneLabel" runat="server" Text='<%# Eval("descrizione") %>' />
                     <br />
                     <asp:HyperLink ID="HyperLink2" runat="server" Target="_blank" NavigateUrl='<%# strFileAl + Eval("file") %>' Text="Clicca qui per aprire l'allegato" Font-Size="X-Small"></asp:HyperLink>
                     <br />
                </ItemTemplate>
                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True"/>
                </asp:DataList>
                <br />
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/stor_circol.aspx" Target="_blank">Visualizza tutte le circolari</asp:HyperLink>
                <br />
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM tbl_news WHERE privato='True' ORDER BY data_ora DESC LIMIT 5"></asp:SqlDataSource>
				</div> 
                <div id="colonna-sx">
                    <div id="iscrizioni" class="div-sx border-radius">
                        <h2>Iscrizioni</h2>
                        <br />

                        <asp:DataList ID="DataList9" runat="server" CellPadding="4" DataSourceID="SqlDataSource7" Width="100%">
                            <AlternatingItemStyle BackColor="White" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <ItemStyle BackColor="#F7F6F3" />
                            <ItemTemplate>
                                <b>Data Iscrizione:</b>
                                <asp:Label ID="data_iscrizioneLabel0" runat="server" Text='<%# Eval("dat_iscr") %>' />
                                &nbsp;&nbsp;<b>Matricola:</b>
                                <asp:Label ID="id_socioLabel0" runat="server" Text='<%# Eval("id_socio") %>' />
                                <br />
                                <b>Nominativo:</b>
                                <asp:Label ID="cognLabel0" runat="server" Text='<%# Eval("cogn") %>' />
                                <asp:Label ID="nomLabel0" runat="server" Text='<%# Eval("nom") %>' />
                                &nbsp;&nbsp;<b>Sede:</b>
                                <asp:Label ID="com_appLabel0" runat="server" Text='<%# Eval("com_app") %>' />
                                <br />
                                <br />
                            </ItemTemplate>
                            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" />
                        </asp:DataList>
                        <br />
                        <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/stor_iscrizioni.aspx" Target="_blank">Visualizza tutte le nuove iscrizioni</asp:HyperLink>
                        <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" SelectCommand="SELECT id_socio, dat_iscr, com_app, cogn, nom FROM tbl_socio1 ORDER BY id_socio DESC LIMIT 6"></asp:SqlDataSource>

                        </div>
    			    <div class="div-sx border-radius">
			            <h2>Gestione soci</h2>
			            <br/>
			            <a href="ric_socio.aspx" target="_blank">Ricerca / modifica / visualizza scheda socio</a><br/>
			            <a href="reg_socio.aspx" target="_blank">Inserisci nuovo socio</a><br />
                        <a href="mod_anagrafica.aspx" target="_blank">Modifica la tua anagrafica</a><br /> 
                        <a href="quote_socio.aspx" target="_blank">Gestisci le tue quote sociali</a><br /> <br/>
			        </div>
                    <div class="div-sx border-radius">
 				    <h2>Gestione simpatizzanti</h2>
			            <br/>
				    <a href="ins_simpatizzanti.aspx" target="_blank">Inserisci nuovo simpatizzante</a><br/>
			            <a href="gest_simpatizzanti.aspx" target="_blank">Ricerca / modifica / visualizza scheda simpatizzante</a><br/>
			        </div>
			        <!-- <div class="div-sx border-radius">
			            <h2>Gestione servizi</h2>
			            <br/>
			            <a href="">Link</a><br/>
			            <a href="">Link</a><br/>
			            <a href="">Link</a><br/>
			            <a href="">Link</a><br/>
			            <a href="">Link</a><br/>
			            <a href="">Link</a><br/>
			        </div> -->
			        <div class="div-sx border-radius">
			            <h2>Gestione automezzi</h2>
			            <br/>
			            <a href="ins_mezzi.aspx" target="_blank">Inserisci / modifica</a><br/>
			            <a href="vis_mezzi.aspx" target="_blank">Visualizza / richiedi</a><br/>
			        </div>
		        </div>
		        <div id="colonna-dx">
                    <div id="esclusioni" class="div-dx border-radius">
				<h2>Esclusioni</h2>
		<br/>
		<asp:DataList ID="DataList5" runat="server" DataSourceID="SqlDataSource2" CellPadding="4" Width="100%">
                <AlternatingItemStyle BackColor="White" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="#F7F6F3" />
                <ItemTemplate>
                    <b>Data Uscita:</b>
                    <asp:Label ID="date_usciteLabel" runat="server" Text='<%# Eval("date_uscite") %>' />
                    &nbsp;&nbsp;<b>Matricola:</b>
                    <asp:Label ID="id_socioLabel" runat="server" Text='<%# Eval("id_socio") %>' />
                    <br />
		    <b>Nominativo:</b>
                    <asp:Label ID="cognLabel" runat="server" Text='<%# Eval("cogn") %>' />
		    <asp:Label ID="nomLabel" runat="server" Text='<%# Eval("nom") %>' />
                    &nbsp;&nbsp;<b>Sede:</b>
                    <asp:Label ID="com_appLabel" runat="server" Text='<%# Eval("com_app") %>' />
                    <br /><b>Motivazione:</b>&nbsp;<asp:Label ID="motivazioneLabel" runat="server"></asp:Label>
                    <br />
                    <asp:HiddenField ID="dimgHF" runat="server" Value='<%# Eval("dim_g") %>' />
                    <asp:HiddenField ID="dimsHF" runat="server" Value='<%# Eval("dim_s") %>' />
                    <asp:HiddenField ID="sospHF" runat="server" Value='<%# Eval("sospensione") %>' />
                    <asp:HiddenField ID="espulHF" runat="server" Value='<%# Eval("espulsione") %>' />
                    
                    <asp:HiddenField ID="motivo_sospHF" runat="server" Value='<%# Eval("motivo_sosp") %>' />
                    <asp:HiddenField ID="motivo_espulHF" runat="server" Value='<%# Eval("motivo_espul") %>' />

                    <asp:HiddenField ID="decadenzaHF" runat="server" Value='<%# Eval("decadenza") %>' />
                    
                </ItemTemplate>
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True"/>
                </asp:DataList>
                <br />
                <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/stor_uscite.aspx" Target="_blank">Visualizza tutte le esclusioni</asp:HyperLink>
                <br />
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" SelectCommand="SELECT `dat_dim_g` AS `date_uscite`, `id_socio`, `cogn`, `nom`, `com_app`, `dim_g`, `dim_s`, `sospensione`, `espulsione`, `motivo_sosp`, `motivo_espul`, `decadenza` FROM `tbl_socio1` WHERE `dim_g` = 'True' UNION SELECT `dat_dim_s`, `id_socio`, `cogn`, `nom`, `com_app`, `dim_g`, `dim_s`, `sospensione`, `espulsione`, `motivo_sosp`, `motivo_espul`, `decadenza` FROM `tbl_socio1` WHERE `dim_s` = 'True' UNION SELECT `data_inz_sosp`, `id_socio`, `cogn`, `nom`, `com_app`, `dim_g`, `dim_s`, `sospensione`, `espulsione`, `motivo_sosp`, `motivo_espul`, `decadenza` FROM `tbl_socio1` WHERE `sospensione` = 'True' UNION SELECT `data_espul`, `id_socio`, `cogn`, `nom`, `com_app`, `dim_g`, `dim_s`, `sospensione`, `espulsione`, `motivo_sosp`, `motivo_espul`, `decadenza` FROM `tbl_socio1` WHERE `espulsione` = 'True' UNION SELECT `data_decad`, `id_socio`, `cogn`, `nom`, `com_app`, `dim_g`, `dim_s`, `sospensione`, `espulsione`, `motivo_sosp`, `motivo_espul`, `decadenza` FROM `tbl_socio1` WHERE `decadenza` = 'True' ORDER BY STR_TO_DATE(`date_uscite`, '%d/%m/%Y') DESC LIMIT 6"></asp:SqlDataSource>
		</div>
			        <div class="div-dx border-radius">
			            <h2>Gestione sito</h2>
			            <br/>
			            <a href="agg_galleria.aspx" target="_blank">Aggiungi foto galleria</a><br/>
			            <a href="agg_articoli.aspx" target="_blank">Aggiungi articolo</a><br/>
			            <a href="mod_pwd.aspx" target="_blank">Modifica password</a><br/>
			            <a href="http://webmail.guardianazionaleambientale.eu" target="_blank">Leggi email</a>
			        </div>
                    <div class="div-dx border-radius">
			            <h2>Gestione servizi</h2>
			            <br/>
			            <a href="">Inserisci nuovo servizio</a><br/>
			            <a href="">Ricerca / modifica / visualizza servizio</a><br/>
			            <a href="">Compila relazione di servizio</a><br/>
			            <a href="">Gestione economica servizi</a><br/>
			            <a href="">Gestione calendario servizi</a><br/>
                        -------------------------------<br />
                    <a href="elenco_rapp_asso.aspx" target="_blank">Gestione Schede ASSO</a><br />
			        </div> 
			        <div class="div-dx border-radius">
			            <h2>Report</h2>
			            <br/>
			            <a href="">Elenco telefonico</a><br/>
			        </div>
			        <div class="div-dx border-radius">
			            <h2>Gestione equipaggiamenti</h2>
			            <br/>
			            <a href="gest_equip_individuali.aspx" target="_blank">Equipaggiamenti individuali</a><br/>
			            <a href="#">Equipaggiamenti generali</a><br/>
			        </div>
			        
                </div>
                </asp:View>
            <asp:View ID="View3" runat="server">
                
                    <div id="circolari" class="border-radius">
		<h2>Circolari e comunicazioni interne</h2>
		<br/>
		<asp:DataList ID="DataList6" runat="server" DataSourceID="SqlDataSource1" CellPadding="4" DataKeyField="id_news" Height="20px" Width="100%">
                <AlternatingItemStyle BackColor="White"/>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="#F7F6F3" />
                <ItemTemplate>
                     <asp:Label ID="titoloLabel" runat="server" Font-Bold="True" ForeColor="000040" Text='<%# Eval("titolo") %>'/>
		     <br />
                     <asp:Label ID="descrizioneLabel" runat="server" Text='<%# Eval("descrizione") %>' />
                     <br />
                     <asp:HyperLink ID="HyperLink2" runat="server" Target="_blank" NavigateUrl='<%# strFileAl + Eval("file") %>' Text="Clicca qui per aprire l'allegato" Font-Size="X-Small"></asp:HyperLink>
                     <br />
                </ItemTemplate>
                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True"/>
                </asp:DataList>
                <br />
                <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/stor_circol.aspx" Target="_blank">Visualizza tutte le circolari</asp:HyperLink>
                <br />
                <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM tbl_news WHERE privato='True' ORDER BY data_ora DESC LIMIT 5"></asp:SqlDataSource>
				</div>
                <div id="colonna-sx">
                    <div id="iscrizioni" class="div-sx border-radius">
                        <h2>Iscrizioni</h2>
                        <br />

                        <asp:DataList ID="DataList10" runat="server" CellPadding="4" DataSourceID="SqlDataSource7" Width="100%">
                            <AlternatingItemStyle BackColor="White" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <ItemStyle BackColor="#F7F6F3" />
                            <ItemTemplate>
                                <b>Data Iscrizione:</b>
                                <asp:Label ID="data_iscrizioneLabel0" runat="server" Text='<%# Eval("dat_iscr") %>' />
                                &nbsp;&nbsp;<b>Matricola:</b>
                                <asp:Label ID="id_socioLabel0" runat="server" Text='<%# Eval("id_socio") %>' />
                                <br />
                                <b>Nominativo:</b>
                                <asp:Label ID="cognLabel0" runat="server" Text='<%# Eval("cogn") %>' />
                                <asp:Label ID="nomLabel0" runat="server" Text='<%# Eval("nom") %>' />
                                &nbsp;&nbsp;<b>Sede:</b>
                                <asp:Label ID="com_appLabel0" runat="server" Text='<%# Eval("com_app") %>' />
                                <br />
                                <br />
                            </ItemTemplate>
                            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" />
                        </asp:DataList>
                        <br />
                        <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/stor_iscrizioni.aspx" Target="_blank">Visualizza tutte le nuove iscrizioni</asp:HyperLink>
                        <asp:SqlDataSource ID="SqlDataSource9" runat="server" ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" SelectCommand="SELECT id_socio, dat_iscr, com_app, cogn, nom FROM tbl_socio1 ORDER BY id_socio DESC LIMIT 6"></asp:SqlDataSource>

                        </div>
    			    <div class="div-sx border-radius">
			            <h2>Gestione socio</h2>
			            <br/>
			            <a href="mod_anagrafica.aspx" target="_blank">Modifica la tua anagrafica</a><br/>
			            <a href="quote_socio.aspx" target="_blank">Gestisci le tue quote sociali</a><br />
                        <a href="#" target="_blank">(new) Comunicazioni interne riservate</a><br/>
			        </div>
                    <div class="div-sx border-radius">
			            <h2>Gestione equipaggiamenti</h2>
			            <br/>
			            <a href="gest_equip_individuali.aspx" target="_blank">Equipaggiamenti individuali</a><br/>
			        </div>
                    <!-- <div class="div-sx border-radius">
 				    <h2>Gestione simpatizzanti</h2>
			            <br/>
				    <a href="ins_simpatizzanti.aspx" target="_blank">Inserisci nuovo simpatizzante</a><br/>
			            <a href="gest_simpatizzanti.aspx" target="_blank">Ricerca / modifica / visualizza scheda simpatizzante</a><br/>
			        </div> -->
			        <!-- <div class="div-sx border-radius">
			            <h2>Gestione servizi</h2>
			            <br/>
			            <a href="">Link</a><br/>
			            <a href="">Link</a><br/>
			            <a href="">Link</a><br/>
			            <a href="">Link</a><br/>
			            <a href="">Link</a><br/>
			            <a href="">Link</a><br/>
			        </div> -->
			        <!-- <div class="div-sx border-radius">
			            <h2>Gestione automezzi</h2>
			            <br/>
			            <a href="ins_mezzi.aspx" target="_blank">Inserisci / modifica</a><br/>
			            <a href="vis_mezzi.aspx" target="_blank">Visualizza / richiedi</a><br/>
			        </div> -->
		        </div>
		        <div id="colonna-dx">
                    <div id="esclusioni" class="div-dx border-radius">
				<h2>Esclusioni</h2>
		<br/>
		<asp:DataList ID="DataList7" runat="server" DataSourceID="SqlDataSource2" CellPadding="4" Width="100%">
                <AlternatingItemStyle BackColor="White" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="#F7F6F3" />
                <ItemTemplate>
                    <b>Data Uscita:</b>
                    <asp:Label ID="date_usciteLabel" runat="server" Text='<%# Eval("date_uscite") %>' />
                    &nbsp;&nbsp;<b>Matricola:</b>
                    <asp:Label ID="id_socioLabel" runat="server" Text='<%# Eval("id_socio") %>' />
                    <br />
		    <b>Nominativo:</b>
                    <asp:Label ID="cognLabel" runat="server" Text='<%# Eval("cogn") %>' />
		    <asp:Label ID="nomLabel" runat="server" Text='<%# Eval("nom") %>' />
                    &nbsp;&nbsp;<b>Sede:</b>
                    <asp:Label ID="com_appLabel" runat="server" Text='<%# Eval("com_app") %>' />
                    <br /><b>Motivazione:</b>&nbsp;<asp:Label ID="motivazioneLabel" runat="server"></asp:Label>
                    <br />
                    <asp:HiddenField ID="dimgHF" runat="server" Value='<%# Eval("dim_g") %>' />
                    <asp:HiddenField ID="dimsHF" runat="server" Value='<%# Eval("dim_s") %>' />
                    <asp:HiddenField ID="sospHF" runat="server" Value='<%# Eval("sospensione") %>' />
                    <asp:HiddenField ID="espulHF" runat="server" Value='<%# Eval("espulsione") %>' />
                    
                    <asp:HiddenField ID="motivo_sospHF" runat="server" Value='<%# Eval("motivo_sosp") %>' />
                    <asp:HiddenField ID="motivo_espulHF" runat="server" Value='<%# Eval("motivo_espul") %>' />

                    <asp:HiddenField ID="decadenzaHF" runat="server" Value='<%# Eval("decadenza") %>' />
                    
                </ItemTemplate>
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True"/>
                </asp:DataList>
                <br />
                <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/stor_uscite.aspx" Target="_blank">Visualizza tutte le esclusioni</asp:HyperLink>
                <br />
                <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" SelectCommand="SELECT `dat_dim_g` AS `date_uscite`, `id_socio`, `cogn`, `nom`, `com_app`, `dim_g`, `dim_s`, `sospensione`, `espulsione`, `motivo_sosp`, `motivo_espul`, `decadenza` FROM `tbl_socio1` WHERE `dim_g` = 'True' UNION SELECT `dat_dim_s`, `id_socio`, `cogn`, `nom`, `com_app`, `dim_g`, `dim_s`, `sospensione`, `espulsione`, `motivo_sosp`, `motivo_espul`, `decadenza` FROM `tbl_socio1` WHERE `dim_s` = 'True' UNION SELECT `data_inz_sosp`, `id_socio`, `cogn`, `nom`, `com_app`, `dim_g`, `dim_s`, `sospensione`, `espulsione`, `motivo_sosp`, `motivo_espul`, `decadenza` FROM `tbl_socio1` WHERE `sospensione` = 'True' UNION SELECT `data_espul`, `id_socio`, `cogn`, `nom`, `com_app`, `dim_g`, `dim_s`, `sospensione`, `espulsione`, `motivo_sosp`, `motivo_espul`, `decadenza` FROM `tbl_socio1` WHERE `espulsione` = 'True' UNION SELECT `data_decad`, `id_socio`, `cogn`, `nom`, `com_app`, `dim_g`, `dim_s`, `sospensione`, `espulsione`, `motivo_sosp`, `motivo_espul`, `decadenza` FROM `tbl_socio1` WHERE `decadenza` = 'True' ORDER BY STR_TO_DATE(`date_uscite`, '%d/%m/%Y') DESC LIMIT 6"></asp:SqlDataSource>
		</div>
			        <div class="div-dx border-radius">
			            <h2>Gestione sito</h2>
			            <br/>
			            <a href="mod_pwd.aspx" target="_blank">Modifica password</a><br/>
			            <a href="http://webmail.guardianazionaleambientale.eu" target="_blank">Leggi email</a>
			        </div>
                    <div class="div-dx border-radius">
			            <h2>Gestione servizi</h2>
			            <br/>
			            <a href="#">Inserisci nuovo servizio</a><br/>
			            <a href="#">Ricerca / modifica / visualizza servizio</a><br/>
			            <a href="#">Compila relazione di servizio</a><br/>
			            <a href="#">Gestione economica servizi</a><br/>
			            <a href="#">Gestione calendario servizi</a><br/>
                        -------------------------------<br />
                    <a href="elenco_rapp_asso.aspx" target="_blank">Gestione Schede ASSO</a><br />
			        </div> 
			        <div class="div-dx border-radius">
			            <h2>Report</h2>
			            <br/>
			            <a href="#">Elenco telefonico</a><br/>
			        </div>
			        
			        
                </div>
                </asp:View>
            <asp:View ID="View4" runat="server">
                <div class="div-sx border-radius">
			            <h2>Gestione ASSOBIOPLASTICHE</h2>
			            <br/>
				    <a href="visualizza_sacchetti.aspx" target="_blank">Visualizza sacchetti</a><br/>
			            <a href="mod_pwd.aspx" target="_blank">Modifica PWD di accesso</a><br/>
			            
			        </div>
            </asp:View>
       		</asp:MultiView>
        <asp:Panel ID="Panel1" runat="server">
		<div id="documenti" class="border-radius">
		<h2>Documenti di utilità per le sedi</h2>
		<br/>
    	   	<asp:DataList ID="DataList1" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" CellPadding="4" Font-Bold="False" Width="100%" >
        	<AlternatingItemStyle BackColor="White" />
        	<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        	<HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Italic="False" 
            	Font-Names="Tahoma" Font-Overline="False" Font-Strikeout="False" 
            	Font-Underline="False" ForeColor="White" />
        	<ItemStyle BackColor="#F7F6F3" />
        	<ItemTemplate> 
                <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Eval("Name") %>' NavigateUrl='<%# strfile + Eval("Name") %>' Target="_blank"> </asp:HyperLink>
        	</ItemTemplate>
        	<SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" />
		</asp:DataList>
		</div>	

        </asp:Panel>
       </div>


</asp:Content>

