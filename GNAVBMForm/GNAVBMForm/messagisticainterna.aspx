<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="messagisticainterna.aspx.vb" Inherits="GNAVBMForm.messagisticainterna" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            
           
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <br /><br /><br />
       <h1 style="height: 39px">MESSAGGISTICA INTERNA</h1>
    <table border="1" style="width:auto">
       <tr>
           <td colspan="2" style="text-align:center">
               <strong><span style="font-size: medium">FORM COMPOSIZIONE MESSAGGIO</span></strong>
               </td>
       </tr>
    
       <tr>
           <td style="width:264px"><b>Codice Fiscale</b></td>
           <td style="width:99%"><input style="background-color:aquamarine;color:black; width:100%;text-transform:capitalize"  class = "form-control col-md-3" type="text"  id="txt_codicefiscale" runat="server" />

               <input type="button" id="btn_carica" value="Get User Name" runat="server" />
           </td>
       </tr>
       <tr>
           <td style="width:264px"><b>User Name Destinatario </b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black; width:100%;text-transform:capitalize" type="text" size="30" id="txt_usernamesocio" runat="server" /></td>
       </tr>
        <tr>
           <td style="width:264px"><b>Data invio </b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black;" type="date"  id="txt_datainviomessaggio" runat="server" /></td>
       </tr>
         <tr>
           <td style="width:264px"><b>Oggetto </b></td>
           <td style="width:99%"><input  style="background-color:aquamarine;color:black;" type="text"  id="txt_oggettoMessaggio" runat="server" /></td>
       </tr>
         <tr>
           <td style="width:264px"><b>Testo Messaggio </b></td>
           <td style="width:99%"><textarea  style="background-color:aquamarine;color:black; resize:none; width: 859px; height: 214px;"  id="txt_messaggio" runat="server"></textarea></td>
       </tr>
           <tr>
           <td style="width:264px"><strong>Allegato</strong></td>
           <td style="width:99%"><asp:FileUpload ID="allegati" AllowMultiple="true" runat="server" />
       </tr>
       <tr>
           <td colspan="2" style="text-align:center;width 100%; height: 68px;">
               <span style="font-size: x-small"><asp:ImageButton ID="btn_registra" runat="server" ImageUrl="/img/pulsante-invia.png" /></span></td>
 
       </tr>
    </table>
</asp:Content>
