<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="Login.aspx.vb" Inherits="GNAVBMForm.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <p>
        </p>
   
    <link href="css/login.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="pagina"> 
    <div class="modulo border-radius">
    <h1>ACCEDI ALL'AREA RISERVATA</h1>
    <p>&nbsp;</p>
    <label><asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
    <asp:TextBox ID="usern" runat="server"></asp:TextBox></label>
    <label><asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
    <asp:TextBox ID="pwd" runat="server" TextMode="Password"></asp:TextBox></label>
    <div class="pulsante-login">
	<asp:ImageButton ID="Button1" runat="server" ImageUrl="~/img/pulsante-login.png" BorderStyle="None" ValidationGroup="1" />
	</div> 
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
   
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="usern" ErrorMessage="Username obbligatorio" Display="None"></asp:RequiredFieldValidator>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="pwd" ErrorMessage="Password obbligatoria" Display="None"></asp:RequiredFieldValidator>
        
	<br/>
	<hr>
	<br/>
	<br/>
	Sei iscritto alla GNA ma non hai ancora le credenziali per l'accesso? trati ora</b>, inserisci la tua matricola:	
	<br/>
	<br/>
	<center>
	<table>
	<tr>
	<td>Matricola</td><td><div id="casella-registrati-prova"><asp:TextBox ID="TextBox2" runat="server" ValidationGroup="2"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox2" ErrorMessage="*" ForeColor="Red" ValidationGroup="2"></asp:RequiredFieldValidator></div></td>
	</tr>
	</table>
	</center>
	<div id="pulsante-registrati-prova">
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/img/pulsante-registrati.png" ValidationGroup="2" /></div>
	<br/>
        <br/>
    <br/>
	<hr> 
       <table>
        <tr>
          <td>Non ricordi più la password? 
              <br />
              Utilizza il servizio recupero password!<br />
              <br />
              <strong>Clicca sul pulsante qui sotto e segui le istruzioni</strong></td>
        </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td><asp:ImageButton ID="recupera_password" runat="server" ImageUrl="/img/pulsante-recupera.png" OnClick="recupera_password_Click" /></td>
            </tr>
    </table>
    </div>
    
     
</div>
</asp:Content>

