<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="iscrizione.aspx.vb" Inherits="GNAVBMForm.iscrizione" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br /><br />
    <h1 style="height: 39px; text-align: center;">Modulo di iscrizione per persone fisiche</h1>
    <table border="1" style="width:auto">
       <tr>
               <td colspan="2" style="text-align:center">
               <span style="font-size: medium">
               <strong>Dati anagrafici</strong></span></td>           
       </tr>
       <tr>
           <td style="width:337px"><b>Cognome *</b></td>
           <td style="width:99%"><input style="background-color:aquamarine;color:black; width:50%; text-transform:capitalize" type="text"  id="txt_cognome" runat="server" /></td>
       </tr>
       <tr>
           <td style="width:337px"><b>Nome *</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black; width:50%; text-transform:capitalize" type="text" size="30" id="txt_nome" runat="server" /></td>
       </tr>
        <tr>
           <td style="width:337px"><b>Data di nascita *</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black;" type="date"  id="txt_datanascita" runat="server" /></td>
       </tr>
       <tr>
           <td style="width:337px"><b>Luogo di nascita*</b></td>
           <td style="width:99%"><asp:DropDownList ID="listacomuni_ctl" runat="server" AutoPostBack="True">
               <asp:ListItem>Comuni</asp:ListItem>
               </asp:DropDownList></td>
       </tr>
       <tr>
           <td style="width:337px"><b>Provincia di nascita *</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black;" readonly="true" type="text"  id="txt_prov" runat="server" /></td>
      </tr>
       <tr>
           <td style="width:337px"><b>Indirizzo di residenza *</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black;width:100%;text-transform:capitalize" type="text"  id="txt_indirizzo" runat="server" /></td>
       </tr>
       <tr>
           <td style="width:337px"><b>Numero civico *</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black;" type="text"  id="txt_civico" runat="server" /></td>
       </tr>
        <tr>
           <td style="width:337px"><b>Città di residenza *</b></td>
           <td style="width:99%"><asp:DropDownList ID="listacity_ctl" runat="server" AutoPostBack="True">
                 <asp:ListItem>City</asp:ListItem></asp:DropDownList>
               </td>
       </tr>
        <tr>
           <td style="width:337px"><b>Cap *</b></td>
           <td style="width:99%"><asp:DropDownList ID="listacap_ctl" runat="server" AutoPostBack="True">
                 <asp:ListItem></asp:ListItem></asp:DropDownList>
               </td>
       </tr>
        <tr>
           <td style="width:337px"><b>Provincia residenza *</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black;" readonly="true"  type="text"  id="txt_prov_res" runat="server" /></td>
       </tr>
       <tr>
           <td style="width:337px"><b>Codice fiscale *</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black; width: 160px; text-transform:uppercase" maxlength="16"  type="text"   id="txt_codicefiscale" runat="server" /></td>
       </tr>
         <tr>
           <td colspan="2" style="text-align:center">
               <strong><span style="font-size: medium">Documento di identità</span></strong>
           </td>
           
       </tr>
        <tr>
            <td style="width:337px"><b>Tipo *</b></td>
           <td style="width:99%"><asp:DropDownList ID="listatipodocumento" runat="server" AutoPostBack="True">
                 <asp:ListItem>Patente</asp:ListItem>
                 <asp:ListItem>Passaporto</asp:ListItem>
                 <asp:ListItem>Carta d&#39;identità</asp:ListItem>
                 <asp:ListItem>Porto d&#39;Armi</asp:ListItem>
                 <asp:ListItem>Altro</asp:ListItem>
               </asp:DropDownList>
               </td>
        </tr>
        <tr>
            <td style="width:337px"><b>Numero *</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black;text-transform:uppercase"   type="text"  id="txt_numerodoc" runat="server" /></td>
        </tr>
        <tr>
           
           <td style="width:337px"><b>Data rilascio *</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black;" type="date"  id="data_rilascio" runat="server" /></td>
       </tr>
         <tr>
           
           <td style="width:337px"><b>Data scadenza *</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black;" type="date"  id="data_scadenza" runat="server" /></td>
       </tr>
        <tr>
           <td style="width:337px"><b>Ente/Luogo di rilascio *</b></td>
           <td style="width:99%"><asp:DropDownList ID="enterilascio" runat="server" AutoPostBack="True">
               <asp:ListItem>Comune</asp:ListItem>
               <asp:ListItem>Prefettura</asp:ListItem>
               <asp:ListItem>Questura</asp:ListItem>
               <asp:ListItem>MCTC</asp:ListItem>
               </asp:DropDownList>
               <asp:DropDownList ID="luogorilascio" runat="server" AutoPostBack="True">
               <asp:ListItem>Comuni</asp:ListItem>
               </asp:DropDownList>
       </td>
       </tr>
         <tr>
           <td colspan="2" style="text-align:center">
               <strong><span style="font-size: medium">Recapiti</span></strong>
           </td>
           
       </tr>
        <tr>
            <td style="width:337px"><b>Mobile *</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black"   type="text"  id="txtmobilenumber" runat="server" /></td>
        </tr>
        <tr>
            <td style="width:337px"><b>Mobile ufficio </b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black"   type="text"  id="txtmobilnumberuff" runat="server" /></td>
        </tr>
        <tr>
            <td style="width:337px"><b>Tel abitazione</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black"   type="text"  id="txttelefonoab" runat="server" /></td>
        </tr>
        <tr>
            <td style="width:337px"><b>Tel ufficio</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black"   type="text"  id="txttelefonouff" runat="server" /></td>
        </tr>
        <tr>
            <td style="width:337px"><b>Email *</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black;width:21%"   type="text"  id="txtemail" runat="server" /></td>
        </tr>
        <tr>
            <td style="width:337px"><b>Email ufficio</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black;width:21%"   type="text"  id="txtemailuff" runat="server" /></td>
        </tr>
         <tr>
            <td style="width:337px"><strong>Statura *</strong></td>
             <td style="width: 99%">
                 <input style="background-color: aquamarine; color: black; width: 21%" type="text" id="txttitolostudio0" runat="server" /></td>
        </tr>
        <tr>
            <td style="width:337px"><strong>Colore capelli *</strong></td>
             <td style="width: 99%">
                 <asp:DropDownList ID="listatipodocumento0" runat="server" AutoPostBack="True">
                     <asp:ListItem Value="Bianchi"></asp:ListItem>
                 <asp:ListItem Value="Biondi"></asp:ListItem>
                 <asp:ListItem Value="Brizzolati"></asp:ListItem>
                     <asp:ListItem Value="Bruni"></asp:ListItem>
                 <asp:ListItem Value="Castani"></asp:ListItem>
<asp:ListItem Value="Grigi"></asp:ListItem>
                 <asp:ListItem Value="Neri"></asp:ListItem>
                     <asp:ListItem Value="Rossi"></asp:ListItem>
                 <asp:ListItem Value="Calvo"></asp:ListItem>
               </asp:DropDownList>
               </td>
        </tr>
        <tr>
            <td style="width:337px"><strong>Colore occhi *</strong></td>
             <td style="width: 99%">
                 <asp:DropDownList ID="listatipodocumento1" runat="server" AutoPostBack="True">
                     <asp:ListItem Value="Ambra"></asp:ListItem>
                 <asp:ListItem Value="Azzurri">Azzurri</asp:ListItem>
                 <asp:ListItem Value="Brizzolati"></asp:ListItem>
                 <asp:ListItem Value="Castani"></asp:ListItem>
<asp:ListItem Value="Grigi"></asp:ListItem>
                     <asp:ListItem Value="Marroni"></asp:ListItem>
                     <asp:ListItem Value="Marroni Scuro"></asp:ListItem>
                 <asp:ListItem Value="Neri"></asp:ListItem>
                 <asp:ListItem Value="Nocciola"></asp:ListItem>
<asp:ListItem Value="Verdi"></asp:ListItem>
               </asp:DropDownList>
               </td>
        </tr>
        <tr>
            <td style="width:337px"><strong>Gruppo sanguigno *</strong></td>
             <td style="width: 99%">
                 <asp:DropDownList ID="listatipodocumento2" runat="server" AutoPostBack="True">
                     <asp:ListItem Value="A"></asp:ListItem>
                 <asp:ListItem Value="B">B</asp:ListItem>
                 <asp:ListItem Value="AB"></asp:ListItem>
                 <asp:ListItem Value="0"></asp:ListItem>
               </asp:DropDownList>
               </td>
        </tr>
        <tr>
            <td style="width:337px; height: 24px;"><strong>Rh *</strong></td>
             <td style="width: 99%; height: 24px;">
                 <asp:DropDownList ID="listatipodocumento3" runat="server" AutoPostBack="True">
                     <asp:ListItem Value="+">+</asp:ListItem>
                 <asp:ListItem Value="-">-</asp:ListItem>
               </asp:DropDownList>
               </td>
        </tr>
        <tr>
            <td style="width:337px"><strong>Patenti *</strong></td>
             <td style="width: 99%">
                 <asp:DropDownList ID="listatipodocumento4" runat="server" AutoPostBack="True">
                     <asp:ListItem Value="AM">AM</asp:ListItem>
                 <asp:ListItem Value="A1">A1</asp:ListItem>
                     <asp:ListItem Value="A2"></asp:ListItem>
                     <asp:ListItem Value="A"></asp:ListItem>
                     <asp:ListItem Value="B1"></asp:ListItem>
                     <asp:ListItem Value="B"></asp:ListItem>
                     <asp:ListItem Value="BE"></asp:ListItem>
                     <asp:ListItem Value="C1"></asp:ListItem>
                     <asp:ListItem Value="C1E"></asp:ListItem>
                     <asp:ListItem Value="C"></asp:ListItem>
                     <asp:ListItem Value="D1"></asp:ListItem>
                     <asp:ListItem Value="D1E"></asp:ListItem>
                     <asp:ListItem Value="D"></asp:ListItem>
                     <asp:ListItem Value="DE"></asp:ListItem>
                     <asp:ListItem Value="KA"></asp:ListItem>
                     <asp:ListItem Value="KB"></asp:ListItem>
                     <asp:ListItem Value="CQC"></asp:ListItem>
                     <asp:ListItem Value="CFP"></asp:ListItem>
                     <asp:ListItem Value="ADR"></asp:ListItem>
               </asp:DropDownList>
               </td>
        </tr>
         <tr>
            <td style="width:337px"><strong>Professione *</strong></td>
             <td style="width: 99%">
                 <input style="background-color: aquamarine; color: black; width: 100%" type="text" id="txttitolostudio" runat="server" /></td>
        </tr>
          <tr>
           <td colspan="2" style="text-align:center; font-size: medium;">
               <strong>Settori di interesse</strong></td>
           <tr>
               <td colspan="2">
               <asp:CheckBox ID="vigilanza" Width="300" Height="20" Text="Vigilanza" runat="server" />
               <asp:CheckBox ID="parchi" Width="300" Height="20"  Text="Parchi ed oasi" runat="server" />
               <asp:CheckBox ID="protezione_civile" Width="300" Height="20"  Text="Protezione Civile" runat="server" />
               <asp:CheckBox ID="disciplinare" Width="300" Height="20"  Text="Incombenze interne e disciplinare" runat="server" />
               <asp:CheckBox ID="tramat" Width="300" Height="20"  Text="Trasporti e materiali" runat="server" />
               <asp:CheckBox ID="eduamb" Width="300" Height="20"  Text="Educazione ambientale" runat="server" />
               <asp:CheckBox ID="giuridico" Width="300" Height="20" Text="Giuridico" runat="server" />
               <asp:CheckBox ID="rapportism" Width="300" Height="20"  Text="Rapporti con gli Stati Maggiori" runat="server" />
               <asp:CheckBox ID="sport" Width="300" Height="20"  Text="Sporto e specialità" runat="server" />
               <asp:CheckBox ID="pariopportunità" Width="300" Height="20"  Text="Pari oppurtunità" runat="server" />
               <asp:CheckBox ID="stampa" Width="300" Height="20"  Text="Stampa e diffusione" runat="server" />
               <asp:CheckBox ID="ras" Width="300" Height="20"  Text="RAS - Raggruppamento analisi scientifiche" runat="server" />
               <asp:CheckBox ID="formazione" Width="300" Height="20" Text="Formazione" runat="server" />
               <asp:CheckBox ID="foundraising" Width="300" Height="20"  Text="Foun raising" runat="server" />
               <asp:CheckBox ID="trasportiarereonavali" Width="300" Height="20"  Text="Trasporti aereonavali" runat="server" />
               <asp:CheckBox ID="ria" Width="300" Height="20"  Text="RIA - Reparto investigazioni ambientali" runat="server" />
               <asp:CheckBox ID="intelligence" Width="300" Height="20"  Text="Intelligence" runat="server" />
               <asp:CheckBox ID="relazioniistituzionali" Width="300" Height="20"  Text="Relazioni istituzionali" runat="server" />
               <asp:CheckBox ID="ricercascientifica" Width="300" Height="20"  Text="Ricerca scientifica" runat="server" />
               <asp:CheckBox ID="dap" Width="300" Height="20"  Text="DAP - Dipartimento attività promozionali" runat="server" />
               <asp:CheckBox ID="sanità" Width="300" Height="20"  Text="Comparto sanità" runat="server" />
               <asp:CheckBox ID="trasportiterrestri" Width="300" Height="20"  Text="Trasporti terrestri" runat="server" />
               <asp:CheckBox ID="rapportiesteri" Width="300" Height="20"  Text="Rapporti con gli Stati esteri" runat="server" />
               <asp:CheckBox ID="religione" Width="300" Height="20"  Text="Culto della Religione Cattolica" runat="server" />
                   <br />
                 <asp:CheckBox ID="equipaggiamenti" Width="300" Height="20"  Text="Equipaggiamenti individuali" runat="server" />
                 <asp:CheckBox ID="legale" Width="300" Height="20"  Text="Legale e contenzioso" runat="server" />
                 <asp:CheckBox ID="segreteria" Width="300" Height="20"  Text="Arre di Segreteria" runat="server" />
                </td>
            </tr>
               <tr>
                <td style="width: 337px">
                <asp:CheckBox ID="altro" Width="300" Height="20"  Text="Altro non indicato" runat="server" /></td>
                <td><input  style="background-color:aquamarine;color:black;width:100%"   type="txt_altro"  id="Text1" runat="server" /></td>
               </tr>
                         
       </tr>
          <tr>
           <td colspan="2" style="text-align:center">
               <strong><span style="font-size: medium">Modalità di adesione</span></strong></td>
         </tr>
        <tr>
            <td style="width: 337px">
                <strong>
                <asp:CheckBox ID="ordinario" Width="350" Height="20" Text="Socio Ordinario" runat="server" /></strong></td>
             <td>
                 Quota d’iscrizione una tantum € 503,00 e versamento minimo € 27,00 annui - riservato a non aspiranti volontari esclusa assicurazione Legge 266/1991</td>
        </tr>
        <tr>
            <td style="width: 337px"> <strong> <asp:CheckBox ID="sostenitore" Width="350" Height="20" Text="Socio Sostenitore" runat="server" /></strong></td>
            <td>Versamento minimo € 78,00 annui inclusa assicurazione obbligatoria L 266/91. Obbligo di svolgimento minimo di n. 4 servizi al mese</td>
        </tr>
        <tr>
            <td style="width: 337px">
                <strong>
                <asp:CheckBox ID="benemerito" Width="350" Height="20" Text="Socio Benemerito" runat="server" /></strong>
            </td>
            <td>
                Quota d’iscrizione una tantum € 1.003,00 e versamento minimo € 123,00 annui inclusa assicurazione obbligatoria Legge 266/91. Nessun obbligo di svolgimento minimo servizi</td>
        </tr>
        <tr>
            <td style="width: 337px">
                <strong>
                <asp:CheckBox ID="junior" Width="350" Height="20" Text="Socio Junior" runat="server" /></strong>
            </td>
            <td>
                Versamento minimo € 39,00 annui riservato ad apiranti minorenni con esclusione dell&#39;assicurazione obbligatoria Legge 266/91</td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center; font-size:small;color: #FFFFFF; background-color: #0000FF"">
                <strong>Ogni versamento deve avvenire solo ed esclusivamente attraverso intermediazione creditizia (banca, posta etc.) Non saranno ritenute valide le iscrizioni perfezionate con elargizioni di denaro contante o con versamenti parziali rispetto allo schema di cui sopra
            </strong>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                Modalità di versamento della quota
L'accettazione dell'iscrizione è subordinata all'avvenuto versamento della quota di iscrizione ed il pagamento nelle forme seguenti deve essere allegato alla richiesta di iscrizione.
            </td>
        </tr>
        <tr>
            <td style="width: 337px">
                 <strong>
                 <asp:CheckBox ID="Modalità1" Width="350" Height="20" Text="Assegno Bancario o Circolare" runat="server" /></strong>
            </td>
            <td>
                Assegno Bancario o Circolare deve essere Non Trasferibile ed intestato a Guardia Nazionale Ambientale (l'assegno deve essere inviato, unitamente al presente modulo compilato, per posta raccomandata o assicurata)
            </td>
        </tr>
        <tr>
            <td style="width: 337px">
                <strong>
                <asp:CheckBox ID="Modalità2" Width="350" Height="20" Text="Bonifico" runat="server" /></strong>
            </td>
            <td>
                Bonifico (la copia del bonifico deve essere inviata tramite fax o e-mail contestualmente al presente modulo)
                IBAN: IT80 I076 0114 4000 0002 3616 600 Intestato a Guardia Nazionale Ambientale
                IBAN: IT66 Q033 5901 6001 0000 0151 062 Intestato a Guardia Nazionale Ambientale
            </td>
        </tr>
        <tr>
            <td style="width: 337px"><strong><asp:CheckBox ID="Modalità3" Width="350" Height="20" Text="Bollettino di c/c postale" runat="server" /></strong></td>
            <td>
                Bollettino di C/C Postale (la copia del bollettino deve essere inviata tramite fax o e-mail contestualmente al presente modulo)
Conto Corrente Postale n. 23616600 Intestato a Guardia Nazionale Ambientale
            </td>
        </tr>
        <tr>
           <td colspan="2" style="text-align:center; font-size: medium;">
               <strong>Composizione nucleo familiare</strong></td>
           </tr>
        <tr>
            <td colspan="2">
                Autorizzazione al trattamento dei dati personali
Con la sottoscrizione del presente modulo di iscrizione autorizzo la Guardia Nazionale Ambientale al trattamento dei miei dati personali ai sensi dell’art. 13 del Decreto Legislativo 30 giugno 2003, n. 196 “Codice in materia di protezione dei dati personali” e dell’art. 13 del GDPR (Regolamento UE 2016/679), s.m.i. e successive.<br />
                <br />
                <asp:RadioButton ID="SI" Text="SI AUTORIZZO" runat="server" Width="171px" Height="20px" />
                <asp:RadioButton ID="NO" Text="NON AUTORIZZO" Checked="true" runat="server" Width="171px" Height="20px" />
            &nbsp;<br />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="background-color: #0000FF; color: #FFFFFF;">
                La Guardia Nazionale Ambientale si riserva la facoltà di accettare o rifiutare l’iscrizione qualora il Consiglio Direttivo dell’Organizzazione non ritenga compatibili una o più caratteristiche dell’aspirante socio con quanto previsto nello Statuto Nazionale o nel Regolamento Nazionale o con le finalità istituzionali. In caso di accettazione la Guardia Nazionale Ambientale tratterrà la quota associativa versata che non potrà essere restituita in nessun caso ivi compreso quello di recesso del Socio. L’avvenuta accettazione di iscrizione sarà testimoniata dall’apposizione della firma del Presidente o altro Delegato del Consiglio Direttivo nel riquadro sottostante. Nel caso di rifiuto di iscrizione la Guardia Nazionale Ambientale non sarà tenuta a dare nessuna spiegazione circa la decisione del Consiglio Direttivo di rifiuto e procederà alla restituzione della somma versata per l’iscrizione con le stesse modalità con cui la quota è stata versata. Resta espressamente esclusa qualsiasi 
                forma di risarcimento a favore dell’Aspirante Socio da parte della Guardia Nazionale Ambientale.</td>
        </tr>
        <tr>
           <td colspan="2" style="text-align: center; width: 100%"> &nbsp;<span style="font-size: x-small"><asp:ImageButton ID="btn_registra" runat="server" ImageUrl="/img/pulsante-registrati.png" ValidationGroup="2" /></span></div></td>
 
       </tr>
   </table>
</asp:Content>
