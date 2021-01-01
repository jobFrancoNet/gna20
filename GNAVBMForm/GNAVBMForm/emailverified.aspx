<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="emailverified.aspx.vb" Inherits="GNAVBMForm.emailverified" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
<link href="css/login.css" rel="stylesheet" type="text/css" />


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

       .auto-style1 {
           text-align: center;
       }

       .labelstyle {
         padding-left:5px;
       }

    </style>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="pagina"> 
    <div class="modulo border-radius" style="width:500px">
    <h1>FORM VERIFICA EMAIL</h1>
    <p>&nbsp;</p>
    <label><p class="labelstyle">Email dichiarata</p>
    <asp:TextBox ID="emaildich" runat="server" Width="420px"></asp:TextBox></label>
    <label><p class="labelstyle">Email da  verificare</p>
    <asp:TextBox ID="emailver" runat="server" Width="420px"></asp:TextBox></label>
    <label><p class="labelstyle">Conferma Email da verificare</p>
    <asp:TextBox ID="emailver1" runat="server" Width="420px"></asp:TextBox></label>
    <div class="auto-style1">

	<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/pulsante-Verifica.png" BorderStyle="None" ValidationGroup="email_verifica" CausesValidation="true" OnClick="ImageButton1_Click" />
	</div> 
    <asp:ValidationSummary ID="ValidationSummary1" ShowSummary="true" ValidationGroup="email_verifica" runat="server" />
   
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ValidationGroup="email_verifica"
        ControlToValidate="emailver" ErrorMessage="Email da verificare obbligatoria" Display="None"></asp:RequiredFieldValidator>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ValidationGroup="email_verifica"
        ControlToValidate="emailver1" ErrorMessage="Conferma email obbligatoria" Display="None"></asp:RequiredFieldValidator>    
	    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="emailver1" ControlToValidate="emailver" ErrorMessage="Le email non corrispondono" ValidationGroup="email_verifica" Display="None"></asp:CompareValidator>
	<br/>
	<hr>
	    <asp:Label ID="lbl_status_inviomail" runat="server" Visible="False"></asp:Label>
	<br/>
	
</div>

 
	
    </div>
</asp:Content>

