<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="OtpRequest_verifiedemail.aspx.vb" Inherits="GNAVBMForm.OtpRequest_verifiedemail" %>
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

           .auto-style2 {
               margin-top: 6px;
           }

       .formattazione {
          text-align:left;
          font-family:'Century Gothic';
          padding-left:10px;
              }
    </style>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="pagina"> 
    <div class="modulo border-radius">
    <h1>VERIFICA INDIRIZZO EMAIL CON OTP</h1>
    <p>&nbsp;</p>
    <label><asp:Label ID="Label1" runat="server" Text="OTP   " CssClass="auto-style2" Height="23px"></asp:Label>
    <asp:TextBox ID="OTP_NUMBER" runat="server"></asp:TextBox></label>
     <div class="auto-style1">

	<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/pulsante-Verifica.png" BorderStyle="None" ValidationGroup="email_verifica" CausesValidation="true" OnClick="ImageButton1_Click" />
    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/img/pulsante-areariservata.png" BorderStyle="None" Visible="false" OnClick="ImageButton2_Click" />
   
	</div>
     </div>
    </div>
     <div style="text-align:left">
         <asp:Label ID="lbl_Messaggio" CssClass="formattazione" runat="server" Visible="false" Text="" Height="107px" Width="956px"></asp:Label>
    </div>
</asp:Content>

