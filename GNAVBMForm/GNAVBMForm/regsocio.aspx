<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="regsocio.aspx.vb" Inherits="GNAVBMForm.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title></title>
    <script language="Javascript">

        /* Pour faire une vérification sans autoriser le point ("."), suivez les instructions qui sont écrites en commentaire */

        function verif_dat(champ) {
            var chiffres = new RegExp("[0-9/]"); /* Modifier pour : var chiffres = new RegExp("[0-9]");  new RegExp("[a-zA-Z]") */
            var verif;
            var points = 0; /* Supprimer cette ligne */

            for (x = 0; x < champ.value.length; x++) {
                verif = chiffres.test(champ.value.charAt(x));
                if (champ.value.charAt(x) == ".") { points++; } /* Supprimer cette ligne */
                if (points > 1) { verif = false; points = 1; } /* Supprimer cette ligne */
                if (verif == false) {
                    champ.value = champ.value.substr(0, x) + champ.value.substr(x + 1, champ.value.length - x + 1); x--;

                }

            }

        }

        function ErroreCodiceFiscale() {
            alert('Il Codice Fiscale manca o non è corretto!');
        }
        function ErroreSociogiàinserito() {
            alert('Anagrafica già presente negli archivi! Contattare la Segreteria di Presidenza!');
        }

        function verif_num(champ) {
            var chiffres = new RegExp("[0-9]"); /* Modifier pour : var chiffres = new RegExp("[0-9]");  new RegExp("[a-zA-Z]") */
            var verif;
            var points = 0; /* Supprimer cette ligne */

            for (x = 0; x < champ.value.length; x++) {
                verif = chiffres.test(champ.value.charAt(x));
                if (champ.value.charAt(x) == ".") { points++; } /* Supprimer cette ligne */
                if (points > 1) { verif = false; points = 1; } /* Supprimer cette ligne */
                if (verif == false) {
                    champ.value = champ.value.substr(0, x) + champ.value.substr(x + 1, champ.value.length - x + 1); x--;

                }

            }

        }
        
        function verif_letnumM(champ) {
            var chiffres = new RegExp("[a-zA-Z0-9]"); /* Modifier pour : var chiffres = new RegExp("[0-9]"); */
            var verif;
            var points = 0; /* Supprimer cette ligne */

            for (x = 0; x < champ.value.length; x++) {
                verif = chiffres.test(champ.value.charAt(x));
                if (champ.value.charAt(x) == ".") { points++; } /* Supprimer cette ligne */
                if (points > 1) { verif = false; points = 1; } /* Supprimer cette ligne */
                if (verif == false) {
                    champ.value = champ.value.substr(0, x) + champ.value.substr(x + 1, champ.value.length - x + 1); x--;
                    champ.value = champ.value.toUpperCase();
                }
                else {
                    champ.value = champ.value.toUpperCase();
                }
            }

        }

        function verif_letpM(champ) {
            var chiffres = new RegExp("[a-zA-Z' ]"); /* Modifier pour : var chiffres = new RegExp("[0-9]"); */
            var verif;
            var points = 0; /* Supprimer cette ligne */

            for (x = 0; x < champ.value.length; x++) {
                verif = chiffres.test(champ.value.charAt(x));
                if (champ.value.charAt(x) == ".") { points++; } /* Supprimer cette ligne */
                if (points > 1) { verif = false; points = 1; } /* Supprimer cette ligne */
                if (verif == false) {
                    champ.value = champ.value.substr(0, x) + champ.value.substr(x + 1, champ.value.length - x + 1); x--;
                    champ.value = champ.value.replace(/\b./g, function (x) { return x.toUpperCase() }).replace(/\B./g, function (x) { return x.toLowerCase() });
                }
                else {
                    champ.value = champ.value.replace(/\b./g, function (x) { return x.toUpperCase() }).replace(/\B./g, function (x) { return x.toLowerCase() });

                }
            }

        }

        function verif_numtel(champ) {
            var chiffres = new RegExp("[0-9.]"); /* Modifier pour : var chiffres = new RegExp("[0-9]");  new RegExp("[a-zA-Z]") */
            var verif;
            var points = 0; /* Supprimer cette ligne */

            for (x = 0; x < champ.value.length; x++) {
                verif = chiffres.test(champ.value.charAt(x));
                if (champ.value.charAt(x) == ".") { points++; } /* Supprimer cette ligne */
                if (points > 1) { verif = false; points = 1; } /* Supprimer cette ligne */
                if (verif == false) {
                    champ.value = champ.value.substr(0, x) + champ.value.substr(x + 1, champ.value.length - x + 1); x--;

                }

            }

        }
</script>
    <style type="text/css">

.colonna1 {
	float: left;
	width: 100px;
	left: 0px;
}
.colonna2 {
	float: left;
	width: 220px;
	left: 100px;
}


        .auto-style5
        {
            height: 33px;
        }
        .auto-style6
        {
        }
        .auto-style7
        {
            width: 145px;
            height: 33px;
        }
        .auto-style8
        {
            height: 33px;
        }


        .auto-style12
        {
            height: 33px;
        }
        .auto-style14
        {
            width: 336px;
            height: 33px;
        }
        .auto-style16
        {
            height: 33px;
        }


        .auto-style17
        {
            width: 336px;
        }
        .auto-style18
        {
            width: 145px;
        }
        .TEXTBOX {
            background-color:aquamarine;
        }

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="messaggio" runat="server" CssClass="" Text=""></asp:Label>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"></asp:ScriptManager>
        <table style="width: 1017px;">
            <tr>
                <td class="auto-style5" style="font-family: Georgia; color: #0026ff;" colspan="4">INSERIMENTO NUOVO SOCIO</td>
            </tr>
            <tr>
                <td class="auto-style5" style="font-family: Georgia; color: #0026ff;">Guardia/Volontario</td>
                <td class="auto-style17">
                    <asp:CheckBox ID="chk_guardia" runat="server" Checked="True" />
                </td>
                <td class="auto-style7" style="font-family: Georgia; color: #0026ff;">Telefono Abitazione</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_telab" runat="server" TabIndex="20" CssClass="TEXTBOX"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" style="font-family: Georgia; color: #0026ff;">Cognome</td>
                <td class="auto-style14">
                    <asp:TextBox ID="txt_cogn" runat="server" TabIndex="1" ToolTip="Cognome" CssClass="TEXTBOX"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_cogn" ErrorMessage="Inserire Cognome" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style7" style="font-family: Georgia; color: #0026ff;">Cellulare</td>
                <td class="auto-style16">
                    <asp:TextBox ID="txt_cell" runat="server" TabIndex="21" CssClass="TEXTBOX"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" style="font-family: Georgia; color: #0026ff;">Nome</td>
                <td class="auto-style14">
                    <asp:TextBox ID="txt_nom" runat="server" TabIndex="2" CssClass="TEXTBOX"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_nom" ErrorMessage="Inserire Nome" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style7" style="font-family: Georgia; color: #0026ff;">Cellulare 2</td>
                <td class="auto-style12">
                    <asp:TextBox ID="txt_cell2" runat="server" TabIndex="22" CssClass="TEXTBOX"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" style="font-family: Georgia; color: #0026ff;">Data di Nascita</td>
                <td class="auto-style17">
                    <asp:TextBox ID="txt_dtnas" runat="server" TabIndex="3" CssClass="TEXTBOX"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="txt_dtnas_MaskedEditExtender" runat="server" BehaviorID="txt_dtnas_MaskedEditExtender" Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" MaskType="Date" TargetControlID="txt_dtnas" UserDateFormat="DayMonthYear" />
                    <ajaxToolkit:CalendarExtender ID="txt_dtnas_CalendarExtender" runat="server" BehaviorID="txt_dtnas_CalendarExtender" TargetControlID="txt_dtnas" DefaultView="Years" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_dtnas" ErrorMessage="Inserire Data Nascita" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style7" style="font-family: Georgia; color: #0026ff;">Cellullare Servizio</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_cells" runat="server" TabIndex="23" CssClass="TEXTBOX"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" style="font-family: Georgia; color: #0026ff;">Provincia di Nascita</td>
                <td class="auto-style17">
                    <asp:DropDownList ID="DD_provnas" runat="server" AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="DS_prv_nas" DataTextField="sigla_prov" DataValueField="sigla_prov" TabIndex="4">
                        <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DD_provnas" ErrorMessage="Inserire Prov Nascita" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style7" style="font-family: Georgia; color: #0026ff;">Telefono Ufficio</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_teluff" runat="server" TabIndex="24" CssClass="TEXTBOX"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" style="font-family: Georgia; color: #0026ff;">Luogo di Nascita</td>
                <td class="auto-style17">
                    <asp:DropDownList ID="DD_lgnas" runat="server" AppendDataBoundItems="True" AutoPostBack="False" DataSourceID="DS_lg_nas" DataTextField="comune" DataValueField="comune" TabIndex="5">
                        <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="DD_lgnas" ErrorMessage="Inserire un Luogo Nascita" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style7" style="font-family: Georgia; color: #0026ff;">Fax</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_fax" runat="server" TabIndex="25" CssClass="TEXTBOX"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" style="font-family: Georgia; color: #0026ff;">Provincia di Residenza</td>
                <td class="auto-style17">
                    <asp:DropDownList ID="DD_provres" runat="server" AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="DS_prv_res" DataTextField="sigla_prov" DataValueField="sigla_prov" TabIndex="6">
                        <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DD_provres" ErrorMessage="Inserire Prov Residenza" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style7" style="font-family: Georgia; color: #0026ff;">Email Personale</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_mail" runat="server" TabIndex="26" CssClass="TEXTBOX"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_mail" ErrorMessage="Inserire indirizzo valido" ForeColor="Red" ValidationExpression="^[a-z._-]+\@[a-z._-]+\.[a-z]{2,4}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" style="font-family: Georgia; color: #0026ff;">Città di Residenza</td>
                <td class="auto-style17">
                    <asp:DropDownList ID="DD_citres" runat="server" AppendDataBoundItems="True" AutoPostBack="False" DataSourceID="DS_cit_res" DataTextField="comune" DataValueField="comune" TabIndex="7">
                        <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="DD_citres" ErrorMessage="Inserire una Città Residenza" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style7" style="font-family: Georgia; color: #0026ff;">Data Iscrizione</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_dtisc" runat="server" ReadOnly="True" TabIndex="27" CssClass="TEXTBOX"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="txt_dtisc_MaskedEditExtender" runat="server" BehaviorID="txt_dtisc_MaskedEditExtender" Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" MaskType="Date" TargetControlID="txt_dtisc" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_dtisc" ErrorMessage="Inserire Data Iscrizione" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" style="font-family: Georgia; color: #0026ff;">Indirizzo</td>
                <td class="auto-style17">
                    <asp:TextBox ID="txt_via" runat="server" TabIndex="8" CssClass="TEXTBOX"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txt_via" ErrorMessage="Inserire un Indirizzo" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style7" style="font-family: Georgia; color: #0026ff;">Tipo Socio</td>
                <td class="auto-style8">
                    <asp:DropDownList ID="DD_tpsoc" runat="server" TabIndex="28">
                        <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
                        <asp:ListItem Text="Socio Ordinario" Value="Socio Ordinario"></asp:ListItem>
                        <asp:ListItem Text="Socio Sostenitore" Value="Socio Sostenitore"></asp:ListItem>
                        <asp:ListItem Text="Socio Benemerito" Value="Socio Benemerito"></asp:ListItem>
                        <asp:ListItem Text="Socio Junior" Value="Socio Junior"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="DD_tpsoc" ErrorMessage="Tipo socio obbligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" style="font-family: Georgia; color: #0026ff;">Numero Civico</td>
                <td class="auto-style17">
                    <asp:TextBox ID="txt_civ" runat="server" TabIndex="9" ToolTip="Numero Civico" CssClass="TEXTBOX"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txt_civ" ErrorMessage="Inserire un Civico" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style7" style="font-family: Georgia; color: #0026ff;">Altezza (m,cm)</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_alt" runat="server" TabIndex="29" CssClass="TEXTBOX"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="txt_alt_MaskedEditExtender" runat="server" BehaviorID="txt_alt_MaskedEditExtender" Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="9.99" MaskType="Number" TargetControlID="txt_alt" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_alt" ErrorMessage="Formato altezza errato" ForeColor="Red" ValidationExpression="^[0-9]+\,[0-9]{2}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" style="font-family: Georgia; color: #0026ff;">C.A.P.</td>
                <td class="auto-style17">
                    <asp:TextBox ID="txt_cap" runat="server" MaxLength="5" TabIndex="10" ToolTip="Codice Avviamento Postale" CssClass="TEXTBOX"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txt_cap" ErrorMessage="CAP non valido" ForeColor="Red" ValidationExpression="^[0-9]{5}$"></asp:RegularExpressionValidator>
                </td>
                <td class="auto-style7" style="font-family: Georgia; color: #0026ff;">Colore Capelli</td>
                <td class="auto-style8">
                    <asp:DropDownList ID="DD_colcap" runat="server" TabIndex="28">
                        <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
                        <asp:ListItem Text="Altro" Value="Altro"></asp:ListItem>
                        <asp:ListItem Text="Bianchi" Value="Bianchi"></asp:ListItem>
                        <asp:ListItem Text="Biondi" Value="Biondi"></asp:ListItem>
                        <asp:ListItem Text="Brizzolati" Value="Brizzolati"></asp:ListItem>
                        <asp:ListItem Text="Bruni" Value="Bruni"></asp:ListItem>
                        <asp:ListItem Text="Castani" Value="Castani"></asp:ListItem>
                        <asp:ListItem Text="Grigi" Value="Grigi"></asp:ListItem>
                        <asp:ListItem Text="Neri" Value="Neri"></asp:ListItem>
                        <asp:ListItem Text="Rossi" Value="Rossi"></asp:ListItem>
			<asp:ListItem Text="Calvo" Value="Calvo"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" style="font-family: Georgia; color: #0026ff;">Codice Fiscale</td>
                <td class="auto-style17">
                    <asp:TextBox ID="txt_codfis" runat="server" AutoPostBack="True" MaxLength="16" TabIndex="11" ToolTip="Codice Fiscale" CssClass="TEXTBOX"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txt_codfis" ErrorMessage="Inserire un Codice Fiscale" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style7" style="font-family: Georgia; color: #0026ff;">Colore Occhi</td>
                <td class="auto-style8">
                    <asp:DropDownList ID="DD_colocc" runat="server" TabIndex="28">
                        <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
                        <asp:ListItem Text="Ambra" Value="Ambra"></asp:ListItem>
                        <asp:ListItem Text="Azzurri" Value="Azzurri"></asp:ListItem>
                        <asp:ListItem Text="Castano" Value="Castano"></asp:ListItem>
                        <asp:ListItem Text="Grigi" Value="Grigi"></asp:ListItem>
                        <asp:ListItem Text="Marroni" Value="Marroni"></asp:ListItem>
                        <asp:ListItem Text="Marroni Scuro" Value="Marroni Scuro"></asp:ListItem>
                        <asp:ListItem Text="Neri" Value="Neri"></asp:ListItem>
                        <asp:ListItem Text="Nocciola" Value="Nocciola"></asp:ListItem>
                        <asp:ListItem Text="Verdi" Value="Verdi"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" style="font-family: Georgia; color: #0026ff;">Documento D&#39;Identità</td>
                <td class="auto-style17">
                    <asp:DropDownList ID="DD_docid" runat="server" TabIndex="12">
                        <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
                        <asp:ListItem Text="Carta d'identità" Value="Carta d'identità"></asp:ListItem>
                        <asp:ListItem Text="Patente" Value="Patente"></asp:ListItem>
                        <asp:ListItem Text="Passaporto" Value="Passaporto"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="DD_docid" ErrorMessage="Inserire un Documento" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style7" style="font-family: Georgia; color: #0026ff;">Gruppo Sanguigno</td>
                <td class="auto-style8">
                    <asp:DropDownList ID="DD_grsang" runat="server" TabIndex="32">
                        <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
                        <asp:ListItem Text="0" Value="0"></asp:ListItem>
                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                        <asp:ListItem Text="B" Value="B"></asp:ListItem>
                        <asp:ListItem Text="AB" Value="AB"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" style="font-family: Georgia; color: #0026ff;">Numero Documento</td>
                <td class="auto-style17">
                    <asp:TextBox ID="txt_ndoc" runat="server" TabIndex="13" CssClass="TEXTBOX"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txt_ndoc" ErrorMessage="Inserire un Numero Documento" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style7" style="font-family: Georgia; color: #0026ff;">RH</td>
                <td class="auto-style8">
                    <asp:DropDownList ID="DD_rh" runat="server" TabIndex="33">
                        <asp:ListItem Text="" Value=""></asp:ListItem>
                        <asp:ListItem Text="+" Value="+"></asp:ListItem>
                        <asp:ListItem Text="-" Value="-"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" style="font-family: Georgia; color: #0026ff;">Data Rilascio Documento</td>
                <td class="auto-style17">
                    <asp:TextBox ID="txt_dtrild" runat="server" TabIndex="14"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="txt_dtrild_MaskedEditExtender" runat="server" BehaviorID="txt_dtrild_MaskedEditExtender" Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" MaskType="Date" TargetControlID="txt_dtrild" />
                    <ajaxToolkit:CalendarExtender ID="txt_dtrild_CalendarExtender" runat="server" BehaviorID="txt_dtrild_CalendarExtender" TargetControlID="txt_dtrild" />
                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txt_dtrild" ErrorMessage="Data non valida" ForeColor="Red" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                </td>
                <td class="auto-style7" style="font-family: Georgia; color: #0026ff;">Sesso</td>
                <td class="auto-style8">
                    <asp:DropDownList ID="DD_ses" runat="server" TabIndex="34">
                        <asp:ListItem Text="" Value=""></asp:ListItem>
                        <asp:ListItem Text="Maschio" Value="Maschio"></asp:ListItem>
                        <asp:ListItem Text="Femmina" Value="Femmina"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="DD_ses" ErrorMessage="Sesso obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" style="font-family: Georgia; color: #0026ff;">Data Scadenza Documento</td>
                <td class="auto-style17">
                    <asp:TextBox ID="txt_dtscd" runat="server" TabIndex="15" CssClass="TEXTBOX"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="txt_dtscd_MaskedEditExtender" runat="server" BehaviorID="txt_dtscd_MaskedEditExtender" Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" MaskType="Date" TargetControlID="txt_dtscd" />
                    <ajaxToolkit:CalendarExtender ID="txt_dtscd_CalendarExtender" runat="server" BehaviorID="txt_dtscd_CalendarExtender" TargetControlID="txt_dtscd" />
                    <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="txt_dtscd" ErrorMessage="Data non valida" ForeColor="Red" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                </td>
                <td class="auto-style7" style="font-family: Georgia; color: #0026ff;">Maneggio Armi</td>
                <td class="auto-style8">
                    <asp:DropDownList ID="DD_predarm" runat="server" TabIndex="35">
                        <asp:ListItem Text="" Value=""></asp:ListItem>
                        <asp:ListItem Text="Nessuna" Value="Nessuna"></asp:ListItem>
                        <asp:ListItem Text="Scarsa" Value="Scarsa"></asp:ListItem>
                        <asp:ListItem Text="Discreta" Value="Discreta"></asp:ListItem>
                        <asp:ListItem Text="Buona" Value="Buona"></asp:ListItem>
                        <asp:ListItem Text="Ottima" Value="Ottima"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" style="font-family: Georgia; color: #0026ff;">Ente Rilascio Documento</td>
                <td class="auto-style17">
                    <asp:TextBox ID="txt_entrildoc" runat="server" TabIndex="16" CssClass="TEXTBOX"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txt_entrildoc" ErrorMessage="Inserire un Ente Rilascio" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style7" style="font-family: Georgia; color: #0026ff;">Guida Veloce</td>
                <td class="auto-style8">
                    <asp:DropDownList ID="DD_guidvel" runat="server" TabIndex="36">
                        <asp:ListItem Text="" Value=""></asp:ListItem>
                        <asp:ListItem Text="Nessuna" Value="Nessuna"></asp:ListItem>
                        <asp:ListItem Text="Scarsa" Value="Scarsa"></asp:ListItem>
                        <asp:ListItem Text="Discreta" Value="Discreta"></asp:ListItem>
                        <asp:ListItem Text="Buona" Value="Buona"></asp:ListItem>
                        <asp:ListItem Text="Ottima" Value="Ottima"></asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" style="font-family: Georgia; color: #0026ff;">Professione</td>
                <td class="auto-style17">
                    <asp:TextBox ID="txt_prof" runat="server" TabIndex="17" CssClass="TEXTBOX"></asp:TextBox>
                </td>
                <td class="auto-style7" style="font-family: Georgia; color: #0026ff;">Altre Attinenze</td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_alatt" runat="server" TabIndex="37" CssClass="TEXTBOX"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" style="font-family: Georgia; color: #0026ff;">Stato Civile</td>
                <td class="auto-style17">
                    <asp:DropDownList ID="DD_staciv" runat="server" TabIndex="18">
                        <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
                        <asp:ListItem Text="Celibe" Value="Celibe"></asp:ListItem>
                        <asp:ListItem Text="Nubile" Value="Nubile"></asp:ListItem>
                        <asp:ListItem Text="Sposato" Value="Sposato"></asp:ListItem>
                        <asp:ListItem Text="Sposata" Value="Sposata"></asp:ListItem>
                        <asp:ListItem Text="Separato" Value="Separato"></asp:ListItem>
                        <asp:ListItem Text="Separata" Value="Separata"></asp:ListItem>
                        <asp:ListItem Text="Divorziato" Value="Divorziato"></asp:ListItem>
                        <asp:ListItem Text="Divorziata" Value="Divorziata"></asp:ListItem>
                        <asp:ListItem Text="Vedovo" Value="Vedovo"></asp:ListItem>
                        <asp:ListItem Text="Vedova" Value="Vedova"></asp:ListItem>
                        <asp:ListItem Text="Convivente" Value="Convivente"></asp:ListItem>
                        <asp:ListItem Text="Altro" Value="Altro"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style7" style="font-family: Georgia; color: #0026ff;">Foto</td>
                <td class="auto-style8">
                    <asp:FileUpload ID="Up_foto" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style5" style="font-family: Georgia; color: #0026ff;">Email di Servizio</td>
                <td class="auto-style6" colspan="3">
                    <asp:TextBox ID="txt_email_srv" runat="server" TabIndex="19" Width="250px" CssClass="TEXTBOX"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txt_email_srv" ErrorMessage="Inserire indirizzo valido" ForeColor="Red" ValidationExpression="^[a-z._-]+\@[a-z._-]+\.[a-z]{2,4}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" style="font-family: Georgia; color: #0026ff;">Categoria Patente</td>
                <td class="auto-style17">
                    <asp:CheckBox ID="ck_pata" runat="server" Text="Patente A" />
                    <br />
                    <asp:CheckBox ID="ck_patb" runat="server" Text="Patente B" />
                    <br />
                    <asp:CheckBox ID="ck_patc" runat="server" Text="Patente C" />
                    <br />
                    <asp:CheckBox ID="ck_patd" runat="server" Text="Patente D" />
                    <br />
                    <asp:CheckBox ID="ck_pate" runat="server" Text="Patente E" />
                </td>
                <td class="auto-style18" style="font-family: Georgia; color: #0026ff;">
                    Attinenze</td>
                <td class="auto-style6">
                    <div class="colonna1">
                        <asp:CheckBox ID="att1" runat="server" Text="Ittica" />
                        <br />
                        <asp:CheckBox ID="att2" runat="server" Text="Venatoria" />
                        <br />
                        <asp:CheckBox ID="att3" runat="server" Text="Ambientale" />
                        <br />
                        <asp:CheckBox ID="att4" runat="server" Text="Zoofila" />
                        <br />
                        <asp:CheckBox ID="att5" runat="server" Text="Marittima" />
                        <br />
                        <asp:CheckBox ID="att6" runat="server" Text="Giuridico" />
                    </div>
                    <div class="colonna2">
                        <asp:CheckBox ID="att7" runat="server" Text="Fluviale" />
                        <br />
                        <asp:CheckBox ID="att8" runat="server" Text="Ricerca Scentifica" />
                        <br />
                        <asp:CheckBox ID="att9" runat="server" Text="Gestione Parchi e Oasi" />
                        <br />
                        <asp:CheckBox ID="att10" runat="server" Text="Educazione Ambientale" />
                        <br />
                        <asp:CheckBox ID="att11" runat="server" Text="Relaz esterne e ufficio stampa" />
                        <br />
                        <asp:CheckBox ID="att12" runat="server" Text="Protezione Civile" />
                    </div>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" style="font-family: Georgia; color: #0026ff;">Qualifica</td>
                <td class="auto-style17">
                    <asp:DropDownList ID="DD_grado" runat="server" TabIndex="38">
                        <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
                        <asp:ListItem Text="Aspirante" Value="Aspirante"></asp:ListItem>
                        <asp:ListItem Text="Agente" Value="Agente"></asp:ListItem>
                        <asp:ListItem Text="Agente Scelto" Value="Agente Scelto"></asp:ListItem>
                        <asp:ListItem Text="Assistente" Value="Assistente"></asp:ListItem>
                        <asp:ListItem Text="Assistente Capo" Value="Assistente Capo"></asp:ListItem>
                        <asp:ListItem Text="Vice Responsabile Distaccamento" Value="Vice Responsabile Distaccamento"></asp:ListItem>
                        <asp:ListItem Text="Responsabile di Distaccamento" Value="Responsabile di Distaccamento"></asp:ListItem>
                        <asp:ListItem Text="Dirigente Intermedio" Value="Dirigente Intermedio"></asp:ListItem>
                        <asp:ListItem Text="Dirigente Provinciale di Settore" Value="Dirigente Provinciale di Settore"></asp:ListItem>
                        <asp:ListItem Text="Dirigente Provinciale Vicario" Value="Dirigente Provinciale Vicario"></asp:ListItem>
                        <asp:ListItem Text="Dirigente Provinciale" Value="Dirigente Provinciale"></asp:ListItem>
                        <asp:ListItem Text="Dirigente Regionale di Settore" Value="Dirigente Regionale di Settore"></asp:ListItem>
                        <asp:ListItem Text="Dirigente Regionale Vicario" Value="Dirigente Regionale Vicario"></asp:ListItem>
                        <asp:ListItem Text="Dirigente Regionale" Value="Dirigente Regionale"></asp:ListItem>
                        <asp:ListItem Text="Dirigente Nazionale di Settore" Value="Dirigente Nazionale di Settore"></asp:ListItem>
                        <asp:ListItem Text="Dirigente Interregionale Centro" Value="Dirigente Interregionale Centro"></asp:ListItem>
                        <asp:ListItem Text="Dirigente Interregionale CentroSud" Value="Dirigente Interregionale CentroSud"></asp:ListItem>
                        <asp:ListItem Text="Dirigente Interregionale CentroNord" Value="Dirigente Interregionale CentroNord"></asp:ListItem>
                        <asp:ListItem Text="Dirigente Interregionale Isole" Value="Dirigente Interregionale Isole"></asp:ListItem>
                        <asp:ListItem Text="Dirigente Nazionale DVSF" Value="Dirigente Nazionale DVSF"></asp:ListItem>
                        <asp:ListItem Text="Dirigente Generale DGSF" Value="Dirigente Generale DGSF"></asp:ListItem>
                        <asp:ListItem Text="Dirigente Generale Interregionale" Value="Dirigente Generale Interregionale"></asp:ListItem>
                        <asp:ListItem Text="Dirigente Generale Nazionale Vicario" Value="Dirigente Generale Nazionale Vicario"></asp:ListItem>
                        <asp:ListItem Text="Dirigente Generale Nazionale" Value="Dirigente Generale Nazionale"></asp:ListItem>
                        <asp:ListItem Text="Dirigente Generale Superiore" Value="Dirigente Generale Superiore"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="DD_grado" ErrorMessage="Inserire il grado" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style18" style="font-family: Georgia; color: #0026ff;">
                    Note</td>
                <td class="auto-style6" rowspan="4">
                    <asp:TextBox ID="txt_note" runat="server" Rows="7" TabIndex="39" TextMode="MultiLine" Width="266px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" style="font-family: Georgia; color: #0026ff;">Qualifica Amministrativa</td>
                <td class="auto-style17">
                    <asp:DropDownList ID="DD_qualamm" runat="server" TabIndex="40">
                        <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
                        <asp:ListItem Text="Presidente" Value="Presidente"></asp:ListItem>
                        <asp:ListItem Text="VicePresidente" Value="VicePresidente"></asp:ListItem>
                        <asp:ListItem Text="Consigliere" Value="Consigliere"></asp:ListItem>
                        <asp:ListItem Text="Tesoriere" Value="Tesoriere"></asp:ListItem>
                        <asp:ListItem Text="Segretario" Value="Segretario"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style18" style="font-family: Georgia; color: #0026ff;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5" style="font-family: Georgia; color: #0026ff;">Regione di Appartenenza</td>
                <td class="auto-style17">
                    <asp:DropDownList ID="DD_regapp" runat="server" AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="DS_regioneapp" DataTextField="regione" DataValueField="regione" TabIndex="42">
                        <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="DD_regapp" ErrorMessage="Inserire la regione di appartenenza" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style18" style="font-family: Georgia; color: #0026ff;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5" style="font-family: Georgia; color: #0026ff;">Provincia di Appartenenza</td>
                <td class="auto-style17">
                    <asp:DropDownList ID="DD_provapp" runat="server" AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="DS_provapp" DataTextField="provincia" DataValueField="provincia" TabIndex="43">
                        <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="DD_provapp" ErrorMessage="Inserire la provincia di appartenenza" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style18" style="font-family: Georgia; color: #0026ff;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5" style="font-family: Georgia; color: #0026ff;">Sede di Appartenenza</td>
                <td class="auto-style17">
                    <asp:DropDownList ID="DD_sedeapp" runat="server" AppendDataBoundItems="True" DataSourceID="DS_sedeapp" DataTextField="sede" DataValueField="sede" TabIndex="44">
                        <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="DD_sedeapp" ErrorMessage="Inserire la sede di appartenenza" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style18" style="font-family: Georgia; color: #0026ff;">
                    Disponibilità</td>
                <td class="auto-style6">
                    <asp:TextBox ID="txt_disp" runat="server" TabIndex="45"></asp:TextBox>
                </td>
            </tr>
        </table>
    <asp:ImageButton ID="Button2" runat="server" ImageUrl="~/img/pulsante-salva.png" />
    
    &nbsp;&nbsp;&nbsp;
    <asp:SqlDataSource ID="DS_prv_nas" runat="server" 
        ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" 
        SelectCommand="SELECT * FROM tbl_comuni GROUP BY sigla_prov ORDER BY sigla_prov ASC"></asp:SqlDataSource>

        
<asp:SqlDataSource ID="DS_lg_nas" runat="server" 
        ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" 
        SelectCommand="SELECT * FROM tbl_comuni WHERE (sigla_prov = ?)">
    <SelectParameters>
        <asp:ControlParameter ControlID="DD_provnas" Name="sigla_prov" 
            PropertyName="SelectedValue" Type="String" />
    </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="DS_prv_res" runat="server" 
        ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" 
        SelectCommand="SELECT * FROM tbl_comuni GROUP BY sigla_prov ORDER BY sigla_prov ASC"></asp:SqlDataSource>

        
<asp:SqlDataSource ID="DS_cit_res" runat="server" 
        ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" 
        SelectCommand="SELECT * FROM tbl_comuni WHERE (sigla_prov = ?)">
    <SelectParameters>
        <asp:ControlParameter ControlID="DD_provres" Name="sigla_prov" 
            PropertyName="SelectedValue" Type="String" />
    </SelectParameters>
    </asp:SqlDataSource>
        <asp:SqlDataSource ID="DS_regioneapp" runat="server" 
        ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" 
        SelectCommand="SELECT DISTINCT regione FROM tbl_comuni">
    </asp:SqlDataSource>
        <asp:SqlDataSource ID="DS_provapp" runat="server" 
        ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" 
        SelectCommand="SELECT DISTINCT provincia, regione FROM tbl_sedi WHERE (regione = ?) ORDER BY provincia ASC">
    <SelectParameters>
        <asp:ControlParameter ControlID="DD_regapp" Name="regione" 
            PropertyName="SelectedValue" Type="String" />
    </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="DS_sedeapp" runat="server" 
        ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" 
        SelectCommand="SELECT DISTINCT sede, provincia FROM tbl_sedi WHERE (provincia = ?) ORDER BY sede ASC">
    <SelectParameters>
        <asp:ControlParameter ControlID="DD_provapp" Name="provincia" 
            PropertyName="SelectedValue" Type="String" />
    </SelectParameters>
    </asp:SqlDataSource>
    
</asp:Content>
