<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="registrazionecorso.aspx.vb" Inherits="GNAVBMForm.registrazionecorso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br /><br />
    <h1 style="height: 39px">REGISTRAZIONE CORSO</h1>
    <table border="1" style="width:auto">
       <tr>
           <td colspan="2" style="text-align:center">
               <strong><span style="font-size: medium">MODULO DI REGISTRAZIONE CORSO:</span></strong>
               </td>
        </tr>
           <tr>
                   <td colspan="2" style="text-align: center"><asp:DropDownList ID="listacorsi" runat="server">
                   <asp:ListItem>Corso DRONI Modulo “A Maggio 2019</asp:ListItem>
                   <asp:ListItem Enabled="False">Corso SICUREZZA Modulo B Giugno 2019</asp:ListItem>
                   <asp:ListItem Enabled="False">Corso SICUREZZA DELLA COMUNICAZIONE Modulo C Luglio 2019</asp:ListItem>
                   <asp:ListItem Enabled="False">Corso SICUREZZA Informatica Modulo D Novembre 2019</asp:ListItem>
                   <asp:ListItem Enabled="False">Corso SICUREZZA Tecniche di intervento Modulo E Dicembre 2019</asp:ListItem>
                   <asp:ListItem Enabled="False">Corso SICUREZZA Sette Sataniche Modulo F Gennaio 2020</asp:ListItem>
                   <asp:ListItem Enabled="False">Tutti</asp:ListItem>
               </asp:DropDownList></td>
           </tr>
                
            
       
       <tr>
           <td colspan="2" style="text-align:center">
               <strong><span style="font-size: medium">Dati dell'aspirante corsista</span></strong>
           </td>
           
       </tr>
       <tr>
           <td style="width:264px"><b>Cognome *</b></td>
           <td style="width:99%"><input style="background-color:aquamarine;color:black; width:100%;text-transform:capitalize" type="text"  id="txt_cognome" runat="server" /></td>
       </tr>
       <tr>
           <td style="width:264px"><b>Nome *</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black; width:100%;text-transform:capitalize" type="text" size="30" id="txt_nome" runat="server" /></td>
       </tr>
        <tr>
           <td style="width:264px"><b>Data di nascita *</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black;" type="date"  id="txt_datanascita" runat="server" /></td>
       </tr>
       <tr>
           <td style="width:264px"><b>Luogo di nascita*</b></td>
           <td style="width:99%"><asp:DropDownList ID="listacomuni_ctl" runat="server" AutoPostBack="True">
               <asp:ListItem>Comuni</asp:ListItem>
               </asp:DropDownList>
       </tr>
       <tr>
           <td style="width:264px"><b>Provincia di nascita *</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black;" readonly="true" type="text"  id="txt_prov" runat="server" /></td>
      </tr>
       <tr>
           <td style="width:264px"><b>Indirizzo di residenza *</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black;width:100%;text-transform:capitalize" type="text"  id="txt_indirizzo" runat="server" /></td>
       </tr>
       <tr>
           <td style="width:264px"><b>Numero civico *</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black;" type="text"  id="txt_civico" runat="server" /></td>
       </tr>
        <tr>
           <td style="width:264px"><b>Città di residenza *</b></td>
           <td style="width:99%"><asp:DropDownList ID="listacity_ctl" runat="server" AutoPostBack="True">
                 <asp:ListItem>City</asp:ListItem></asp:DropDownList>
               </td>
       </tr>
        <tr>
           <td style="width:264px"><b>Cap *</b></td>
           <td style="width:99%"><asp:DropDownList ID="listacap_ctl" runat="server" AutoPostBack="True">
                 <asp:ListItem></asp:ListItem></asp:DropDownList>
       </tr>
        <tr>
           <td style="width:264px"><b>Provincia residenza *</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black;" readonly="true"  type="text"  id="txt_prov_res" runat="server" /></td>
       </tr>
       <tr>
           <td style="width:264px"><b>Codice fiscale *</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black; width: 160px; text-transform:uppercase" maxlength="16"  type="text"   id="txt_codicefiscale" runat="server" /></td>
       </tr>
         <tr>
           <td colspan="2" style="text-align:center">
               <strong><span style="font-size: medium">Documento di identità</span></strong>
           </td>
           
       </tr>
        <tr>
            <td style="width:264px"><b>Tipo *</b></td>
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
            <td style="width:264px"><b>Numero *</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black;text-transform:uppercase"   type="text"  id="txt_numerodoc" runat="server" /></td>
        </tr>
        <tr>
           
           <td style="width:264px"><b>Data rilascio *</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black;" type="date"  id="data_rilascio" runat="server" /></td>
       </tr>
         <tr>
           
           <td style="width:264px"><b>Data scadenza *</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black;" type="date"  id="data_scadenza" runat="server" /></td>
       </tr>
        <tr>
           <td style="width:264px"><b>Ente/Luogo di rilascio *</b></td>
           <td style="width:99%"><asp:DropDownList ID="enterilascio" runat="server" AutoPostBack="True">
               <asp:ListItem>Comune</asp:ListItem>
               <asp:ListItem>Prefettura</asp:ListItem>
               <asp:ListItem>Questura</asp:ListItem>
               <asp:ListItem>MCTC</asp:ListItem>
               </asp:DropDownList>
               <asp:DropDownList ID="luogorilascio" runat="server" AutoPostBack="True">
               <asp:ListItem>Comuni</asp:ListItem>
               </asp:DropDownList>

       </tr>
         <tr>
           <td colspan="2" style="text-align:center">
               <strong><span style="font-size: medium">Recapiti</span></strong>
           </td>
           
       </tr>
        <tr>
            <td style="width:264px"><b>Mobile *</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black"   type="text"  id="txtmobilenumber" runat="server" /></td>
        </tr>
        <tr>
            <td style="width:264px"><b>Mobile ufficio </b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black"   type="text"  id="txtmobilnumberuff" runat="server" /></td>
        </tr>
        <tr>
            <td style="width:264px"><b>Tel abitazione</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black"   type="text"  id="txttelefonoab" runat="server" /></td>
        </tr>
        <tr>
            <td style="width:264px"><b>Tel ufficio</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black"   type="text"  id="txttelefonouff" runat="server" /></td>
        </tr>
        <tr>
            <td style="width:264px"><b>Email *</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black;width:50%"   type="text"  id="txtemail" runat="server" /></td>
        </tr>
        <tr>
            <td style="width:264px"><b>Email ufficio</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black;width:50%"   type="text"  id="txtemailuff" runat="server" /></td>
        </tr>
         <tr>
            <td style="width:264px"><b>Titolo di Studio *</b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black;width:50%"   type="text"  id="txttitolostudio" runat="server" /></td>
        </tr>
          <tr>
           <td colspan="4" style="text-align:center">
               <strong><span style="font-size: medium">Professione/Appartenenza *</span></strong></td>
           <tr>
               <td colspan="4">
               <asp:CheckBox ID="gna" Width="300" Height="20" Text="Guardia Nazionale Ambientale" runat="server" />
               <asp:CheckBox ID="mininterno_poliziastato" Width="300" Height="20"  Text="Ministero dell'Interno Polizia di Stato" runat="server" />
               <asp:CheckBox ID="mindifesa_carabinieri" Width="300" Height="20"  Text="Ministero della Difesa/Carabinieri" runat="server" />
               <asp:CheckBox ID="minfinanze_guardiafinanza" Width="300" Height="20"  Text="Ministero delle Finanze/Guardia Finanza" runat="server" />
                <asp:CheckBox ID="PCDM_protezionecivile" Width="300" Height="20"  Text="PCDM/Protezione civile" runat="server" />
                <asp:CheckBox ID="vigilifuoco" Width="300" Height="20"  Text="Vigili del Fuoco" runat="server" />
                <asp:CheckBox ID="poliziamunicipale" Width="300" Height="20"  Text="Polizia Municipale" runat="server" />
                <asp:CheckBox ID="associazionepolstato" Width="300" Height="20"  Text="Associazione Nazionale Polizia di Stato" runat="server" />
                <asp:CheckBox ID="associazioneNazCarabinieri" Width="300" Height="20"  Text="Associazione Nazionale Carabinieri" runat="server" />
                <asp:CheckBox ID="associazionenazfinanzieri" Width="300" Height="20"  Text="Associazione Nazionale Finanzieri d'Italia" runat="server" />
                 <asp:CheckBox ID="mingiustizia_poliziaPenitenziaria" Width="300" Height="20"  Text="Ministero della Giustizia Polizia Penitenziaria" runat="server" />
                </td>
            </tr>
               <tr>
                <td style="width: 264px">
                <asp:CheckBox ID="altrienti_azienda" Width="300" Height="20"  Text="Altri enti o Aziende" runat="server" /></td>
                <td><input  style="background-color:aquamarine;color:black;width:50%"   type="txt_altro"  id="Text1" runat="server" /></td>
               </tr>
                         
       </tr>
          <tr>
           <td colspan="2" style="text-align:center">
               <strong><span style="font-size: medium">Modalità/Adesione pagamento</span></strong>
           </td>
         </tr>
        <tr>
            <td style="width: 264px">
                <strong>
                <asp:CheckBox ID="basico" Width="350" Height="20" Text="Basico" runat="server" /></strong></td>
             <td>
                 <strong>Il costo complessivo del corso basico è di €. 800,00
</strong>
                 <br />
                 All’atto dell’iscrizione dovrà essere corrisposto il 30% pari ad €. 240,00 della quota del corso prescelto e contemporaneamente la presentazione dei documenti richiesti
Il restante pari ad €. 560,00 dovrà essere corrisposto entro il quinto giorno antecedente la data di inizio corso
             </td>
        </tr>
        <tr>
            <td style="width: 264px"> <strong> <asp:CheckBox ID="critico" Width="350" Height="20" Text="Critico" runat="server" /></strong></td>
            <td><strong>Il costo complessivo del corso critico è di €. 650,00 </strong>
                <br />
                All’atto dell’iscrizione dovrà essere corrisposto il 30% pari ad €. 213,00 della quota del corso prescelto e contemporaneamente la presentazione dei documenti richiesti
Il restante pari ad €. 437,00 dovrà essere corrisposto entro il quinto giorno antecedente la data di inizio corso</td>
        </tr>
        <tr>
            <td style="width: 264px">
                <strong>
                <asp:CheckBox ID="soluzione_completa" Width="350" Height="20" Text="Basico + Critico unica soluzione" runat="server" /></strong></td>
            </td>
            <td>
                <strong>Il costo complessivo del corso basico+critico in unica soluzione è di €. 1.300,00 </strong>
                <br />
                All’atto dell’iscrizione dovrà essere corrisposto il 30% pari ad €. 390,00 della quota del corso prescelto e contemporaneamente la presentazione dei documenti richiesti
Il restante pari ad €. 910,00 dovrà essere corrisposto entro il quinto giorno antecedente la data di inizio corso </td>
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
            <td style="width: 264px">
                 <strong>
                 <asp:CheckBox ID="Modalità1" Width="350" Height="20" Text="Assegno Bancario o Circolare" runat="server" /></strong></td>
            </td>
            <td>
                Assegno Bancario o Circolare deve essere Non Trasferibile ed intestato a Guardia Nazionale Ambientale (l'assegno deve essere inviato, unitamente al presente modulo compilato, per posta raccomandata o assicurata)
            </td>
        </tr>
        <tr>
            <td style="width: 264px">
                <strong>
                <asp:CheckBox ID="Modalità2" Width="350" Height="20" Text="Bonifico" runat="server" /></strong></td>
            </td>
            <td>
                Bonifico (la copia del bonifico deve essere inviata tramite fax o e-mail contestualmente al presente modulo)
                IBAN: IT80 I076 0114 4000 0002 3616 600 Intestato a Guardia Nazionale Ambientale
                IBAN: IT66 Q033 5901 6001 0000 0151 062 Intestato a Guardia Nazionale Ambientale
            </td>
        </tr>
        <tr>
            <td style="width: 264px"><strong><asp:CheckBox ID="Modalità3" Width="350" Height="20" Text="Bollettino di c/c postale" runat="server" /></strong></td>
            <td>
                Bollettino di C/C Postale (la copia del bollettino deve essere inviata tramite fax o e-mail contestualmente al presente modulo)
Conto Corrente Postale n. 23616600 Intestato a Guardia Nazionale Ambientale
            </td>
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
            <td colspan="2" style="background-color: #0000FF">
                <span style="color: #FFFFFF"><strong>*
                Il corso ai prezzi convenzionati sotto indicati è riservato al personale della Guardia Nazionale Ambientale, alle FF.OO. e FF.AA ed agli enti o aziende convenzionate. Per tutti coloro che non appartengono alle predette categorie è possibile partecipare al corso con le modalità sopra indicate mediante iscrizione alla Guardia Nazionale Ambientale da perfezionare direttamente in sede entro la data di inizio del corso. Info segreteria@guardianazionaleambientale.eu o 06 40410902 opzione 7. La compilazione di tutti I campi contrassegnati con * è obbligatoria</strong></span></td>
        </tr>
        <tr>
           <td colspan="2" style="text-align:center;width 100%; height: 68px;">
               <span style="font-size: x-small"><asp:ImageButton ID="btn_registra" runat="server" ImageUrl="/img/pulsante-registrati.png" ValidationGroup="2" /></span></div></td>
 
       </tr>
   </table>
</asp:Content>
