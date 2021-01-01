<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="RecuperaPassword.aspx.vb" Inherits="GNAVBMForm.RecuperaPassword" %>
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

.modulo.border-radius {
    width:432px;
    height:300px;
}

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

     

       

     

    </style>
<script type="text/javascript">
    function ErroreCF_inesistente() {
        alert("il codice fiscale digitato non esiste nei nostri sistemi; Digitare un codice fiscale valido!!");
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="pagina"> 
    <div class="modulo border-radius">
    <h1>SERVIZIO RECUPERA PASSWORD</h1>
    <p>&nbsp;</p>
    <label><p class="labelstyle">Inserisci il tuo codice fiscale</p>
     <asp:TextBox ID="codicefiscale" runat="server" Width="372px"></asp:TextBox></label>
     <div class="auto-style1">

	<asp:ImageButton ID="verifica_codicefiscale" runat="server" ImageUrl="~/img/pulsante-Verifica.png" BorderStyle="None" OnClick="verifica_codicefiscale_Click"  /> <br /> <br />
         
         <asp:Label ID="lbl_messaggio" runat="server" Font-Bold="True" ForeColor="Red" Width="430px"></asp:Label>
            
	</div>
    </div>
 </div>
</asp:Content>
