<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="ric_socio.aspx.vb" Inherits="GNAVBMForm.ric_socio" %>
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

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
    <div>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <asp:Panel ID="Pan_ricerca" runat="server">
               
                <table style="width:960px;">
                    <tr>
                        <td class="auto-style5">Matricola</td>
                        <td class="auto-style2">
                            <asp:TextBox ID="txt_matricola" runat="server" ToolTip="id_socio"></asp:TextBox>
                        </td>
                        <td class="auto-style6">
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_matricola" ErrorMessage="Inserire la matricola" ForeColor="Red" ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
                            <td class="auto-style3">
                                <asp:CheckBox ID="CheckBox1" runat="server" Text="Soci Inattivi" />
                                &nbsp;&nbsp;
                                <asp:CheckBox ID="soc_ord" runat="server" Text="Includi Soci Ordinari" Visible="False" />
                                &nbsp;<asp:CheckBox ID="ricicloCheckBox" runat="server" Text="Riciclati" Visible="False" />
                            </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">
                            Cognome</td>
                        <td class="auto-style2">
                            <asp:TextBox ID="txt_cogn" runat="server" ToolTip="cogn"></asp:TextBox>
                        </td>
                        <td class="auto-style6">
                            Nome</td>
                        <td class="auto-style3">
                            <asp:TextBox ID="txt_nome" runat="server" ToolTip="nom"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">
                            Regione</td>
                        <td class="auto-style2">
                            <asp:DropDownList ID="DD_regione" runat="server" AppendDataBoundItems="True" 
                                DataSourceID="DS_regione" DataTextField="regione" DataValueField="regione" ToolTip="Regione">
                                <asp:ListItem Text="" Value="" Selected="True"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="auto-style6">
                            Provincia</td>
                        <td class="auto-style3">
                            <asp:DropDownList ID="DD_provincia" runat="server" 
                                DataSourceID="DS_provincia" DataTextField="provincia" 
                                DataValueField="provincia" ToolTip="prov_app" AppendDataBoundItems="True">
                                <asp:ListItem Text="" Value="" Selected="True"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">Sede</td>
                        <td class="auto-style2">
                            <asp:DropDownList ID="DD_sede" runat="server" 
                                DataSourceID="DS_sede" DataTextField="sede" DataValueField="sede" 
                                ToolTip="com_app" AppendDataBoundItems="True">
                                <asp:ListItem Text="" Value="" Selected="True"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                         <td class="auto-style6">Qualifica</td>
                        <td class="auto-style3">
                            <asp:DropDownList ID="DD_qualifica" runat="server" ToolTip="Grado">
                            <asp:ListItem Text="" Value="" Selected="True"></asp:ListItem>
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
            <asp:ListItem Text="Dirigente Generale Nazionale" Value="Dirigente Generale Nazionale" ></asp:ListItem>
            <asp:ListItem Text="Dirigente Generale Superiore" Value="Dirigente Generale Superiore"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style6">Settore</td>
                        <td class="auto-style3">
                            <asp:DropDownList ID="settoreDropDownList" runat="server" SelectedValue='<%# Bind("settore") %>' ToolTip="settore">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Ambiente</asp:ListItem>
                                <asp:ListItem>Vigilanza</asp:ListItem>
                                <asp:ListItem>Stampa e diffusione</asp:ListItem>
                                <asp:ListItem>Formazione</asp:ListItem>
                                <asp:ListItem>Protezione Civile</asp:ListItem>
                                <asp:ListItem>Intelligence</asp:ListItem>
                                <asp:ListItem>Pari Opportunità</asp:ListItem>
                                <asp:ListItem>Sanità</asp:ListItem>
                                <asp:ListItem>Culto Religione Cattolica</asp:ListItem>
                                <asp:ListItem>Found Raising</asp:ListItem>
                                <asp:ListItem>Sport e Specialità</asp:ListItem>
                                <asp:ListItem>Incombenze Interne e Disciplinare</asp:ListItem>
                                <asp:ListItem>Rapporti con gli Stati Maggiori</asp:ListItem>
                                <asp:ListItem>Relazioni Istituzionali</asp:ListItem>
                                <asp:ListItem>DAP - Dipartimento Attività Promozionali</asp:ListItem>
                                <asp:ListItem>RIA - Reparto Investigazioni Ambientali</asp:ListItem>
                                <asp:ListItem>RAS - Raggruppamento Analisi Scientifiche</asp:ListItem>
                                <asp:ListItem>Equipaggiamenti Individuali</asp:ListItem>
                                <asp:ListItem>Trasporti Terrestri</asp:ListItem>
                                <asp:ListItem>Trasporti Aereo Navali</asp:ListItem>
                                <asp:ListItem>Ricerca Scientifica</asp:ListItem>
                                <asp:ListItem>Rapporti con gli Stati Esteri</asp:ListItem>
                                <asp:ListItem>Segreteria Nazionale</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        
                        <td colspan="2">
                            <asp:Button ID="Button1" runat="server" Text="Cerca" />
                        </td>
                        <td>
                           <asp:Button runat="server" ID="uxResetButton" Text="Reset" OnClientClick="this.form.reset();return false;" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table> </asp:Panel>
                <%
                    Dim stringaconn = ConfigurationManager.AppSettings("DB").ToString()
                    %>
                <% If stringaconn.Equals("PRODUZIONE") Then %>
                <asp:SqlDataSource ID="DS_regione" runat="server"
                    
                    ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" 
                    SelectCommand="SELECT DISTINCT regione FROM tbl_sedi WHERE regione &lt;&gt; '' ORDER BY regione ASC"></asp:SqlDataSource>
                <asp:SqlDataSource ID="DS_provincia" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" 
                    SelectCommand="SELECT DISTINCT provincia FROM tbl_sedi WHERE provincia &lt;&gt; '' ORDER BY provincia ASC">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="DS_sede" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" 
                    SelectCommand="SELECT DISTINCT sede FROM tbl_sedi WHERE sede &lt;&gt; '' ORDER BY sede ASC">
                </asp:SqlDataSource>
               <%
                   End If
                   %>

                 <% If stringaconn.Equals("TEST") Then %>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                    
                    ConnectionString="<%$ ConnectionStrings:GNATEST_ConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:GNATEST_ConnectionString.ProviderName %>" 
                    SelectCommand="SELECT DISTINCT regione FROM tbl_sedi WHERE regione &lt;&gt; '' ORDER BY regione ASC"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:GNATEST_ConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" 
                    SelectCommand="SELECT DISTINCT provincia FROM tbl_sedi WHERE provincia &lt;&gt; '' ORDER BY provincia ASC">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:GNATEST_ConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:GNATEST_ConnectionString.ProviderName %>" 
                    SelectCommand="SELECT DISTINCT sede FROM tbl_sedi WHERE sede &lt;&gt; '' ORDER BY sede ASC">
                </asp:SqlDataSource>
               <%
                   End If
                   %>

            </asp:View>
            <asp:View ID="View2" runat="server">
                <asp:Panel ID="Pan_reg" runat="server">
               
                <table style="width:550px;">
                    <tr>
                        <td>Matricola</td>
                        <td>
                            <asp:TextBox ID="txt_matricola2" runat="server" ToolTip="id_socio"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;<td>
                                <asp:CheckBox ID="CheckBox2" runat="server" Text="Soci Inattivi" />
                            </td>
                    </tr>
                    <tr>
                        <td>
                            Cognome</td>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server" ToolTip="cogn"></asp:TextBox>
                        </td>
                        <td>
                            Nome</td>
                        <td>
                            <asp:TextBox ID="TextBox3" runat="server" ToolTip="nom"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Regione</td>
                        <td>
                            <asp:Label ID="lbl_regione" runat="server" Text="" ToolTip="regione"></asp:Label>
                        </td>
                        <td>
                            Provincia</td>
                        <td>
                            <asp:DropDownList ID="DropDownList2" runat="server" 
                                DataSourceID="DS_provincia2" DataTextField="provincia" 
                                DataValueField="provincia" ToolTip="prov_app" AppendDataBoundItems="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>Sede</td>
                        <td>
                            <asp:DropDownList ID="DropDownList3" runat="server" 
                                DataSourceID="DS_sede2" DataTextField="sede" DataValueField="sede" 
                                ToolTip="com_app" AppendDataBoundItems="True">
                            </asp:DropDownList>
                        </td>
                         <td>Qualifica</td>
                        <td>
                            <asp:DropDownList ID="DD_qual2" runat="server" ToolTip="Grado">
                            <asp:ListItem Text="" Value="" Selected="True"></asp:ListItem>
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
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        
                        <td colspan="2">
                            <asp:Button ID="Button2" runat="server" Text="Cerca" />
                        </td>
                        <td colspan="2">
                           <asp:Button runat="server" ID="Button3" Text="Reset" OnClientClick="this.form.reset();return false;" />
                        </td>
                    </tr>
                </table> </asp:Panel>
                <%  
                    Dim stringaconn = ConfigurationManager.AppSettings("DB").ToString()
                    %> 
                <% If stringaconn.Equals("PRODUZIONE") Then %>
                <asp:SqlDataSource ID="DS_provincia2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" 
                    
                    SelectCommand="SELECT provincia, regione FROM tbl_sedi WHERE (regione = ?)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="lbl_regione" Name="regione" 
                            PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="DS_sede2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" 
                    
                    SelectCommand="SELECT DISTINCT sede FROM tbl_sedi WHERE sede &lt;&gt; '' ORDER BY sede ASC">
                </asp:SqlDataSource>
                <%
                    End If
                    %>
               
                 <% If stringaconn.Equals("TEST") Then %>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:GNATEST_ConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:GNATEST_ConnectionString.ProviderName %>" 
                    
                    SelectCommand="SELECT provincia, regione FROM tbl_sedi WHERE (regione = ?)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="lbl_regione" Name="regione" 
                            PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:GNATEST_ConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:GNATEST_ConnectionString.ProviderName %>" 
                    
                    SelectCommand="SELECT DISTINCT sede FROM tbl_sedi WHERE sede &lt;&gt; '' ORDER BY sede ASC">
                </asp:SqlDataSource>
                <%
                    End If
                    %>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <asp:Panel ID="Pan_prov" runat="server">
               
                <table style="width:550px;">
                    <tr>
                        <td>Matricola</td>
                        <td>
                            <asp:TextBox ID="txt_matricola3" runat="server" ToolTip="id_socio"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;<td>
                                <asp:CheckBox ID="CheckBox3" runat="server" Text="Soci Inattivi" />
                            </td>
                    </tr>
                    <tr>
                        <td>
                            Cognome</td>
                        <td>
                            <asp:TextBox ID="TextBox5" runat="server" ToolTip="cogn"></asp:TextBox>
                        </td>
                        <td>
                            Nome</td>
                        <td>
                            <asp:TextBox ID="TextBox6" runat="server" ToolTip="nom"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Regione</td>
                        <td>
                            <asp:Label ID="lbl_regione2" runat="server" Text="" ToolTip="regione"></asp:Label>
                        </td>
                        <td>
                            Provincia</td>
                        <td>
                            <asp:Label ID="lbl_prov" runat="server" Text="" ToolTip="prov_app"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Sede</td>
                        <td>
                            <asp:DropDownList ID="DD_sede2" runat="server" 
                                DataSourceID="DS_sede3" DataTextField="sede" DataValueField="sede" 
                                ToolTip="com_app" AppendDataBoundItems="True">
                            </asp:DropDownList>
                        </td>
                         <td>Qualifica</td>
                        <td>
                            <asp:DropDownList ID="DD_qual3" runat="server" ToolTip="Grado">
                            <asp:ListItem Text="" Value="" Selected="True"></asp:ListItem>
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
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        
                        <td colspan="2">
                            <asp:Button ID="Button4" runat="server" Text="Cerca" />
                        </td>
                        <td colspan="2">
                           <asp:Button runat="server" ID="Button5" Text="Reset" OnClientClick="this.form.reset();return false;" />
                        </td>
                    </tr>
                </table> </asp:Panel>
                <% 

                    Dim stringaconn = ConfigurationManager.AppSettings("DB").ToString()
                %> 
               <% If stringaconn.Equals("PRODUZIONE") Then %>    
                <asp:SqlDataSource ID="DS_sede3" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" 
                    
                    SelectCommand="SELECT DISTINCT * FROM tbl_sedi WHERE (provincia = ?)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="lbl_prov" Name="provincia" PropertyName="Text" 
                            Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
               <%
                   End If
                   %>
            </asp:View>
            <asp:View ID="View4" runat="server">
                <asp:Panel ID="Pan_sede" runat="server">
               
                <table style="width:550px;">
                    <tr>
                        <td>Matricola</td>
                        <td>
                            <asp:TextBox ID="txt_matricola4" runat="server" ToolTip="id_socio"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;<td>
                                <asp:CheckBox ID="CheckBox4" runat="server" Text="Soci Inattivi" />
                            </td>
                    </tr>
                    <tr>
                        <td>
                            Cognome</td>
                        <td>
                            <asp:TextBox ID="TextBox8" runat="server" ToolTip="cogn"></asp:TextBox>
                        </td>
                        <td>
                            Nome</td>
                        <td>
                            <asp:TextBox ID="TextBox9" runat="server" ToolTip="nom"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Regione</td>
                        <td>
                            <asp:Label ID="lbl_regione3" runat="server" Text="" ToolTip="regione"></asp:Label>
                        </td>
                        <td>
                            Provincia</td>
                        <td>
                            <asp:Label ID="lbl_prov2" runat="server" Text="" ToolTip="prov_app"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Sede</td>
                        <td>
                            <asp:Label ID="lbl_sede" runat="server" Text="" ToolTip="com_app"></asp:Label>
                        </td>
                         <td>Qualifica</td>
                        <td>
                            <asp:DropDownList ID="DD_qual4" runat="server" ToolTip="Grado">
                            <asp:ListItem Text="" Value="" Selected="True"></asp:ListItem>
            <asp:ListItem Text="Aspirante" Value="Aspirante"></asp:ListItem>
            <asp:ListItem Text="Agente" Value="Agente"></asp:ListItem>
            <asp:ListItem Text="Agente Scelto" Value="Agente Scelto"></asp:ListItem>
            <asp:ListItem Text="Assistente" Value="Assistente"></asp:ListItem>
            <asp:ListItem Text="Assistente Capo" Value="Assistente Capo"></asp:ListItem>
            <asp:ListItem Text="Vice Responsabile Distaccamento" Value="Vice Responsabile Distaccamento"></asp:ListItem>
            <asp:ListItem Text="Responsabile di Distaccamento" Value="Responsabile di Distaccamento"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        
                        <td colspan="2">
                            <asp:Button ID="Button6" runat="server" Text="Cerca" />
                        </td>
                        <td colspan="2">
                           <asp:Button runat="server" ID="Button7" Text="Reset" OnClientClick="this.form.reset();return false;" />
                        </td>
                    </tr>
                </table> </asp:Panel>

            </asp:View>
                <asp:View ID="View5" runat="server">
                    <asp:Panel ID="Pan_intermedio" runat="server">
                        <table style="width:550px;">
                            <tr>
                                <td>Matricola</td>
                                <td>
                                    <asp:TextBox ID="txt_matricola5" runat="server" ToolTip="id_socio"></asp:TextBox>
                                </td>
                                <td>&nbsp;<td>
                                    <asp:CheckBox ID="CheckBox5" runat="server" Text="Soci Inattivi" />
                                    </td>
                                </td>
                            </tr>
                            <tr>
                                <td>Cognome</td>
                                <td>
                                    <asp:TextBox ID="TextBox10" runat="server" ToolTip="cogn"></asp:TextBox>
                                </td>
                                <td>Nome</td>
                                <td>
                                    <asp:TextBox ID="TextBox11" runat="server" ToolTip="nom"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Sedi</td>
                                <td>
                                    <asp:DropDownList ID="DD_sedi" runat="server" ToolTip="com_app">
                                    </asp:DropDownList>
                                </td>
                                <td>Qualifica</td>
                                <td>
                                    <asp:DropDownList ID="DD_qual5" runat="server" ToolTip="Grado">
                                        <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Aspirante" Value="Aspirante"></asp:ListItem>
                                        <asp:ListItem Text="Agente" Value="Agente"></asp:ListItem>
                                        <asp:ListItem Text="Agente Scelto" Value="Agente Scelto"></asp:ListItem>
                                        <asp:ListItem Text="Assistente" Value="Assistente"></asp:ListItem>
                                        <asp:ListItem Text="Assistente Capo" Value="Assistente Capo"></asp:ListItem>
                                        <asp:ListItem Text="Vice Responsabile Distaccamento" Value="Vice Responsabile Distaccamento"></asp:ListItem>
                                        <asp:ListItem Text="Responsabile di Distaccamento" Value="Responsabile di Distaccamento"></asp:ListItem>
                                        <asp:ListItem Text="Dirigente Intermedio" Value="Dirigente Intermedio"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="Button15" runat="server" Text="Cerca" />
                                </td>
                                <td colspan="2">
                                    <asp:Button ID="Button16" runat="server" OnClientClick="this.form.reset();return false;" Text="Reset" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </asp:View>
            
        </asp:MultiView>
&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;<table style="width:1072px;">
            <tr>
                <td class="auto-style1">MATRICOLA: <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
                <td class="auto-style1">
        <asp:Button ID="Button8" runat="server" Text="Modifica" Visible="False" Width="150px" />
                </td>
                <td class="auto-style1"><asp:Button ID="Button10" runat="server" Text="Visualizza" Visible="False" Width="150px" />
                </td>
                <td class="auto-style1">
                    <asp:Button ID="Button11" runat="server" Text="Dimissioni" Visible="False" Width="150px" />
                </td>
                <td class="auto-style1">
                    <asp:Button ID="Button12" runat="server" Text="Documentale" Visible="False" Width="150px" />
                </td>
                <td class="auto-style1">
                    <asp:Button ID="Button17" runat="server" Text="Visualizza log" Visible="False" Width="150px" />
                </td>
            </tr>
            
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style1">
                    <asp:Button ID="Button13" runat="server" Text="Accettazione" Visible="False" Width="150px" />
                </td>
                <td class="auto-style1">
        <asp:Button ID="Button9" runat="server" Text="Genera Tesserino" Visible="False" Enabled="False" Width="150px" />
                </td>
                <td class="auto-style1">
                    <asp:Button ID="Button14" runat="server" Enabled="False" Text="Ristampa Tesserino" Visible="False" Width="150px" />
                </td>
                <td class="auto-style1">
                    <asp:Button ID="Button18" runat="server" Text="Avanzamento Qualifica" Width="150px" Visible="False" />
                </td>
                <td class="auto-style1">
                    &nbsp;</td>
            </tr>
            
        </table>
        <br />
        <asp:Panel ID="Panel1" runat="server" Visible="False">
            <table border="1">
                <tr>
                <td class="auto-style1" colspan="6">
                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Names="Arial Black" Font-Overline="False" Font-Size="Large" ForeColor="#3333CC" Text="REGOLARITA' SOCIO"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Image ID="Image6" runat="server" ImageUrl="~/images/verde.jpg" />
                    &nbsp;IN REGOLA&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Image ID="Image7" runat="server" ImageUrl="~/images/rosso.jpg" />
                    &nbsp;NON IN REGOLA</td>
                
            </tr>
                <tr>
                    <td class="auto-style9">
                        <asp:Label ID="domisc_lbl" runat="server" ForeColor="Red" Text="Domanda di iscrizione"></asp:Label>
                    </td>
                    <td class="auto-style9">
                        <asp:Label ID="docid_lbl" runat="server" ForeColor="Red" Text="Documento Identità"></asp:Label>
                    </td>
                    <td class="auto-style9">
                        <asp:Label ID="codfisc_lbl" runat="server" ForeColor="Red" Text="Codice Fiscale"></asp:Label>
                    </td>
                    <td class="auto-style9">
                        <asp:Label ID="foto_lbl" runat="server" ForeColor="Red" Text="Foto"></asp:Label>
                    </td>
                    <td class="auto-style9">
                        <asp:Label ID="accett_lbl" runat="server" ForeColor="Red" Text="Accettazione"></asp:Label>
                    </td>
                    <td class="auto-style9">
                        <asp:Label ID="quota_lbl" runat="server" ForeColor="Red" Text="Quota Associativa"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <table>
            <tr><td>
                <asp:Label ID="Label2" runat="server" Text="SOCI ATTIVI"></asp:Label>
                &nbsp;
                <asp:Label ID="Label8" runat="server"></asp:Label>
                &nbsp;
                <asp:Image ID="Image5" runat="server" ImageUrl="~/images/accet.jpg" />
&nbsp;Socio Non Accettato</td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="SOCI INATTIVI" Visible="False"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/espul.jpg" Visible="False" />
&nbsp;<asp:Label ID="Label4" runat="server" Text="Espulsione" Visible="False"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/sosp.jpg" Visible="False" />
                    <asp:Label ID="Label5" runat="server" Text="Sospensione" Visible="False"></asp:Label>&nbsp;&nbsp;
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/images/dim_g.jpg" Visible="False" />
                    <asp:Label ID="Label6" runat="server" Text="Dimissione Guardia" Visible="False"></asp:Label>&nbsp;&nbsp;
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/images/dim_s.jpg" Visible="False" />
                    <asp:Label ID="Label7" runat="server" Text="Dimissione Socio" Visible="False"></asp:Label></td>
            </tr>
                <td class="ver_align"><asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
            DataKeyNames="id_socio" DataSourceID="DS_ricerca" 
            OnPageIndexChanged="GridView1_PageIndexChanged" BackColor="White" 
            BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" PageSize="20" Width="800px">
            <Columns>
                <asp:BoundField DataField="id_socio" HeaderText="Matricola" 
                    InsertVisible="False" ReadOnly="True" SortExpression="id_socio" />
                <asp:BoundField DataField="grado" HeaderText="Grado" SortExpression="grado" />
                <asp:BoundField DataField="com_app" HeaderText="Sede" 
                    SortExpression="com_app" />
                <asp:BoundField DataField="prov_app" HeaderText="Provincia" 
                    SortExpression="prov_app" />
                <asp:BoundField DataField="Regione" HeaderText="Regione" 
                    SortExpression="Regione" />
                <asp:BoundField DataField="cogn" HeaderText="Cognome" SortExpression="cogn" />
                <asp:BoundField DataField="nom" HeaderText="Nome" SortExpression="nom" />
                <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
            </Columns>
                    <EmptyDataTemplate>
                        NON CI SONO RISULTATI
                    </EmptyDataTemplate>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerSettings FirstPageText="PRIMO" LastPageText="ULTIMO" Mode="NumericFirstLast" NextPageText="AVANTI" PageButtonCount="20" PreviousPageText="INDIETRO" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" Font-Size="Small" />
            <RowStyle BackColor="White" ForeColor="#003399" Font-Names="Arial" Font-Size="Small" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView></td>
                <td class="ver_align"><asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="id_socio" PageSize="20" DataSourceID="DS_soci_inat" AutoGenerateColumns="False" Visible="False" Width="800px">
                    <Columns>
                            <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
                            <asp:BoundField DataField="id_socio" HeaderText="Matricola" />
                            <asp:BoundField DataField="cogn" HeaderText="Cognome" />
                            <asp:BoundField DataField="nom" HeaderText="Nome" />
                            <asp:BoundField DataField="com_app" HeaderText="Sede" />
                            <asp:CheckBoxField DataField="dim_s" HeaderText="Dim. S." ReadOnly="True" />
                            <asp:CheckBoxField DataField="dim_g" HeaderText="Dim. G." ReadOnly="True" />
                            <asp:CheckBoxField DataField="sospensione" HeaderText="Sosp." ReadOnly="True" />
                            <asp:CheckBoxField DataField="espulsione" HeaderText="Espul." ReadOnly="True" />
                        </Columns>
                        <EmptyDataTemplate>
                            NON CI SONO RISULTATI
                    </EmptyDataTemplate>
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerSettings FirstPageText="PRIMO" LastPageText="ULTIMO" Mode="NumericFirstLast" NextPageText="AVANTI" PageButtonCount="20" PreviousPageText="INDIETRO" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" Font-Size="Small" />
            <RowStyle BackColor="White" ForeColor="#003399" Font-Names="Arial" Font-Size="Small" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
                </asp:GridView></td>
            </tr>
        </table>
        <%
            Dim stringaconn = ConfigurationManager.AppSettings("DB").ToString()
            %>
        <%
            If stringaconn.Equals("PRODUZIONE") Then
            %>
         <asp:SqlDataSource ID="DS_ricerca" runat="server" 
            ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" 
            SelectCommand="SELECT id_socio, grado, com_app, prov_app, Regione, cogn, nom FROM tbl_socio1 WHERE dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' ORDER BY id_socio ASC">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="DS_soci_inat" runat="server"
            ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" 
            SelectCommand="SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE dim_g='True' OR dim_s='True' OR espulsione='True' OR sospensione='True'">
        </asp:SqlDataSource>
        <%
            End If
            %>
         <%
            If stringaconn.Equals("PRODUZIONE") Then
            %>
         <asp:SqlDataSource ID="SqlDataSource6" runat="server" 
            ConnectionString="<%$ ConnectionStrings:GNATEST_ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:GNATEST_ConnectionString.ProviderName %>" 
            SelectCommand="SELECT id_socio, grado, com_app, prov_app, Regione, cogn, nom FROM tbl_socio1 WHERE dim_g='False' AND dim_s='False' AND espulsione='False' AND sospensione='False' AND categ<>'Socio Ordinario' ORDER BY id_socio ASC">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource7" runat="server"
            ConnectionString="<%$ ConnectionStrings:GNATEST_ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:GNATEST_ConnectionString.ProviderName %>" 
            SelectCommand="SELECT id_socio, cogn, nom, com_app, dim_s, dim_g, sospensione, espulsione FROM tbl_socio1 WHERE dim_g='True' OR dim_s='True' OR espulsione='True' OR sospensione='True'">
        </asp:SqlDataSource>
        <%
            End If
            %>
    </div>
</asp:Content>
