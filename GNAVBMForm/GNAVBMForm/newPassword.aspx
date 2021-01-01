<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="newPassword.aspx.vb" Inherits="GNAVBMForm.newPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

  .formattazione {
          text-align:left;
          font-family:'Century Gothic';
          padding-left:10px;
              }
    </style>
    <script type="text/javascript">
        function Password_modificata() {
            alert("La password nuova è stata correttamente salvata!!")
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="pagina"> 
    <div class="modulo border-radius" style="width:500px">
    <h1>MODIFICA PASSWORD</h1>
    <p>&nbsp;</p>
    <label><p class="labelstyle">Inserire nel campo sottostante il codice OTP ricevuto via email:</p>
    <asp:TextBox ID="codiceotp" runat="server"  Width="420px"></asp:TextBox></label>
    <label><p class="labelstyle">Digitare una nuova password</p>
    <asp:TextBox ID="newpass" runat="server" TextMode="Password" Width="420px"></asp:TextBox></label>
    <label><p class="labelstyle">Ripetere la nuova password</p>
    <asp:TextBox ID="newpass1" runat="server" TextMode="Password" Width="420px"></asp:TextBox></label>
    <div class="auto-style1">

	<asp:ImageButton ID="modificapassword" runat="server" ImageUrl="~/img/pulsante-salva.png" BorderStyle="None" ValidationGroup="password_new" CausesValidation="true" OnClick="modificapassword_Click" />
	</div> 
    <asp:ValidationSummary ID="ValidationSummary1" ShowSummary="true" ValidationGroup="password_new" runat="server" />
   
    <asp:RequiredFieldValidator ID="RequiredFiledValidatio3" runat="server" ValidationGroup="password_new" ControlToValidate="codiceotp" ErrorMessage="Codice OTP obbligatorio" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ValidationGroup="password_new"
        ControlToValidate="newpass" ErrorMessage="Digitare una password" Display="None"></asp:RequiredFieldValidator>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ValidationGroup="password_new"
        ControlToValidate="newpass1" ErrorMessage="Conferma obbligatoria della password" Display="None"></asp:RequiredFieldValidator>    
	    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="newpass1" ControlToValidate="newpass" ErrorMessage="Le password non coincidono" ValidationGroup="password_new" Display="None"></asp:CompareValidator>
	<br/>
	<hr/>
        
    </div>
	<br/>
	
</div>
<div style="text-align:left">
        <asp:Label ID="lbl_status_cambiopassword" CssClass="formattazione" runat="server" Visible="false" Text="" Height="107px" Width="956px"></asp:Label>
 
	
    </div>
</asp:Content>
