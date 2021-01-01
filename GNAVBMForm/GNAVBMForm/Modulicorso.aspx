<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="Modulicorso.aspx.vb" Inherits="GNAVBMForm.Modulicorso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
            body
            {
                font-family: Arial;
                font-size: 12px;
            }
            /* Accordion */
            .accordionHeader
            {
                border: 1px solid #2F4F4F;
                color: white;
                background-color: #2E4d7B;
                font-family: Arial, Sans-Serif;
                font-size: 12px;
                font-weight: bold;
                padding: 5px;
                margin-top: 5px;
                cursor: pointer;
            }
 
            #master_content .accordionHeader a
            {
                color: #FFFFFF;
                background: none;
                text-decoration: none;
            }
 
                #master_content .accordionHeader a:hover
                {
                    background: none;
                    text-decoration: underline;
                }
 
            .accordionHeaderSelected
            {
                border: 1px solid #2F4F4F;
                color: white;
                background-color: #5078B3;
                font-family: Arial, Sans-Serif;
                font-size: 12px;
                font-weight: bold;
                padding: 5px;
                margin-top: 5px;
                cursor: pointer;
            }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     
         <ajaxtoolkit:accordion id="MyAccordion" runat="server" selectedindex="0" headercssclass="accordionHeader" headerselectedcssclass="accordionHeaderSelected" contentcssclass="accordionContent" fadetransitions="false" framespersecond="40" transitionduration="250" autosize="None" requireopenedpane="false" suppressheaderpostbacks="true" width="100%" Height="100%">
     <panes>
         <ajaxtoolkit:accordionpane id="AccordionPane1" runat="server">
             <header>
                 <%--//--- Heading -----%>
                 <span class="accordionLink">Modulo A1 - Corso basico per pilota di droni 24 - 25 - 26 - 27 - 28 giugno 2019</span>
             </header>
             <%--//--- Content -----%>
              <content>
                <iframe style="width:100%; height:600px;overflow:auto" src="contenuto_moduloA1.aspx"></iframe>
             </content>
         </ajaxtoolkit:accordionpane>
          <ajaxtoolkit:accordionpane id="AccordionPane7" runat="server">
             <header>
                 <%--//--- Heading -----%>
                 <span class="accordionLink">Modulo A2 - Corso critico per pilota di droni</span>
             </header>
             <%--//--- Content -----%>
              <content>
                <iframe style="width:100%; height:500px;overflow:auto" src="contenuto_moduloA2.aspx"></iframe>
             </content>
         </ajaxtoolkit:accordionpane>
          <ajaxtoolkit:accordionpane id="AccordionPane8" runat="server">
             <header>
                 <%--//--- Heading -----%>
                 <span class="accordionLink">Modulo A3 - Corso completo per pilota di droni (basico + critico)</span>
             </header>
             <%--//--- Content -----%>
              <content>
                <iframe style="width:100%; height:900px;overflow:auto" src="contenuto_moduloA3.aspx"></iframe>
             </content>
         </ajaxtoolkit:accordionpane>
         <ajaxtoolkit:accordionpane id="AccordionPane2" runat="server">
             <%--//--- Heading -----%>
             <header>
                 <span class="accordionLink">Modulo B - Corso per la figura del Security Manager 3 - 4 - 5 - 6 luglio 2019</span>
             </header>
             <%--//--- Content -----%>
             <content>
                 Pagina in corso di realizzazione
             </content>
         </ajaxtoolkit:accordionpane>
         <ajaxtoolkit:accordionpane id="AccordionPane3" runat="server">
             <%--//--- Heading -----%>
             <header>
                 <span class="accordionLink">Modulo C - Corso per esperti in Sicurezza nel trattamento dati e Comunicazione</span>
             </header>
             <%--//--- Content -----%>
             <content>
               Pagina in corso di realizzazione
             </content>
         </ajaxtoolkit:accordionpane>
         <ajaxtoolkit:accordionpane id="AccordionPane4" runat="server">
             <%--//--- Heading -----%>
             <header>
                 <span class="accordionLink">Modulo D - Corso per esperti in Sicurezza dell'informatica Forense - delle infrastrutture e delle Reti</span>
             </header>
             <%--//--- Content -----%>
             <content>
                 Pagina in corso di realizzazione
             </content>
         </ajaxtoolkit:accordionpane>
         <ajaxtoolkit:accordionpane id="AccordionPane5" runat="server">
             <%--//--- Heading -----%>
             <header>
                 <span class="accordionLink">Modulo E -Corso per esperti in Sicurezza e nelle tecniche di intervento operativo</span>
             </header>
             <%--//--- Content -----%>
             <content>
                 Pagina in corso di realizzazione
             </content>
         </ajaxtoolkit:accordionpane>
          <ajaxtoolkit:accordionpane id="AccordionPane6" runat="server">
             <%--//--- Heading -----%>
             <header>
                 <span class="accordionLink">Modulo F -Corso per esperti in Sicurezza Ambientale</span>
             </header>
             <%--//--- Content -----%>
             <content>
                 Pagina in corso di realizzazione
             </content>
         </ajaxtoolkit:accordionpane>
       
     </panes>
 </ajaxtoolkit:accordion>
     
    
</asp:Content>
