<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="ins_dimissioni.aspx.vb" Inherits="GNAVBMForm.ins_dimissioni" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server" Visible="False">
            Matricola<br />
            <asp:TextBox ID="txt_matr" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Cerca" />
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Visible="False">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" 
                DeleteCommand="DELETE FROM tbl_socio1 WHERE id_socio = ?" 
                InsertCommand="INSERT INTO tbl_socio1 (id_socio, dim_g, dat_dim_g, dim_s, dat_dim_s, sospensione, data_inz_sosp, data_fin_sosp, motivo_sosp, espulsione, data_espul, motivo_espul, decadenza, data_decad, reciclabile) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)" 
                ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" 
                SelectCommand="SELECT id_socio, dim_g, dat_dim_g, dim_s, dat_dim_s, sospensione, data_inz_sosp, data_fin_sosp, motivo_sosp, espulsione, data_espul, motivo_espul, decadenza, data_decad, reciclabile FROM tbl_socio1 WHERE (id_socio = ?)" 
                UpdateCommand="UPDATE tbl_socio1 SET dim_g = ?, dat_dim_g = ?, dim_s = ?, dat_dim_s = ?, sospensione = ?, data_inz_sosp = ?, data_fin_sosp = ?, motivo_sosp = ?, espulsione = ?, data_espul = ?, motivo_espul = ?, decadenza = ?, data_decad = ?, reciclabile = ? WHERE id_socio = ?">
                <DeleteParameters>
                    <asp:Parameter Name="id_socio" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="id_socio" Type="Int32" />
                    <asp:Parameter Name="dim_g" Type="String" />
                    <asp:Parameter Name="dat_dim_g" Type="String" />
                    <asp:Parameter Name="dim_s" Type="String" />
                    <asp:Parameter Name="dat_dim_s" Type="String" />
                    <asp:Parameter Name="sospensione" Type="String" />
                    <asp:Parameter Name="data_inz_sosp" Type="String" />
                    <asp:Parameter Name="data_fin_sosp" Type="String" />
                    <asp:Parameter Name="motivo_sosp" Type="String" />
                    <asp:Parameter Name="espulsione" Type="String" />
                    <asp:Parameter Name="data_espul" Type="String" />
                    <asp:Parameter Name="decadenza" Type="String" />
                    <asp:Parameter Name="data_decad" Type="String" />
                    <asp:Parameter Name="motivo_espul" Type="String" />
                    <asp:Parameter Name="reciclabile" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="txt_matr" Name="id_socio" PropertyName="Text" Type="Int32" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="dim_g" Type="String" />
                    <asp:Parameter Name="dat_dim_g" Type="String" />
                    <asp:Parameter Name="dim_s" Type="String" />
                    <asp:Parameter Name="dat_dim_s" Type="String" />
                    <asp:Parameter Name="sospensione" Type="String" />
                    <asp:Parameter Name="data_inz_sosp" Type="String" />
                    <asp:Parameter Name="data_fin_sosp" Type="String" />
                    <asp:Parameter Name="motivo_sosp" Type="String" />
                    <asp:Parameter Name="espulsione" Type="String" />
                    <asp:Parameter Name="data_espul" Type="String" />
                    <asp:Parameter Name="motivo_espul" Type="String" />
                    <asp:Parameter Name="decadenza" Type="String" />
                    <asp:Parameter Name="data_decad" Type="String" />
                    <asp:Parameter Name="id_socio" Type="Int32" />
                    <asp:Parameter Name="reciclabile" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
            <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="#CC0000" NavigateUrl="ins_dimissioni.aspx" Visible="False">QUI</asp:HyperLink>
            <br />
            <asp:FormView ID="FormView1" runat="server" DataSourceID="SqlDataSource1" DataKeyNames="id_socio" DefaultMode="Edit" Width="549px">
                <EditItemTemplate>
                    Matricola:
                    <asp:Label ID="id_socioLabel1" runat="server" Text='<%# Eval("id_socio") %>' />
                    <br />
                    <table style="width:100%;">
                        <caption>
                            DIMISSIONE GUARDIA</caption>
                        <tr>
                            <td class="auto-style2">Dimissione</td>
                            <td>
                                <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("dim_g") %>' AutoPostBack="True" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Data Dimissione</td>
                            <td>
                                <asp:TextBox ID="dat_dim_gTextBox" runat="server" Text='<%# Bind("dat_dim_g") %>' />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table style="width:100%;">
                        <caption>
                            DIMISSIONE SOCIO</caption>
                        <tr>
                            <td class="auto-style2">Dimissione</td>
                            <td>
                                <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# Bind("dim_s") %>' AutoPostBack="True" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Data Dimissione</td>
                            <td>
                                <asp:TextBox ID="dat_dim_sTextBox" runat="server" Text='<%# Bind("dat_dim_s") %>' />
                            </td>
                        </tr>
                    </table>
&nbsp;<br />
                    <table style="width:100%;">
                        <caption>
                            SOSPENSIONE</caption>
                        <tr>
                            <td class="auto-style2">Sospensione</td>
                            <td>
                                <asp:CheckBox ID="CheckBox3" runat="server" Checked='<%# Bind("sospensione") %>' AutoPostBack="True" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Data Inizio</td>
                            <td>
                                <asp:TextBox ID="data_inz_sospTextBox" runat="server" Text='<%# Bind("data_inz_sosp") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Data Fine</td>
                            <td>
                                <asp:TextBox ID="data_fin_sospTextBox" runat="server" Text='<%# Bind("data_fin_sosp") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Motivo</td>
                            <td>
                                <asp:TextBox ID="motivo_sospTextBox" runat="server" Text='<%# Bind("motivo_sosp") %>' Width="365px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <br />
                    <table style="width:100%;">
                        <caption>
                            ESPULSIONE</caption>
                        <tr>
                            <td class="auto-style2">Espulsione</td>
                            <td>
                                <asp:CheckBox ID="CheckBox4" runat="server" Checked='<%# Bind("espulsione") %>' AutoPostBack="True" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Data</td>
                            <td>
                                <asp:TextBox ID="data_espulTextBox" runat="server" Text='<%# Bind("data_espul") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td>
                                <asp:TextBox ID="motivo_espulTextBox" runat="server" Text='<%# Bind("motivo_espul") %>' Width="365px" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table style="width:100%;">
                        <caption>
                            DECADENZA IN BASE ART. 14 STATUTO NAZIONALE</caption>
                        <tr>
                            <td class="auto-style2">Decadenza</td>
                            <td>
                                <asp:CheckBox ID="CheckBox6" runat="server" AutoPostBack="True" Checked='<%# Bind("decadenza") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Data Decadenza</td>
                            <td>
                                <asp:TextBox ID="dat_decadTextBox" runat="server" Text='<%# Bind("data_decad") %>' />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table style="width:100%;">
                        <caption>
                            RICICLO MATRICOLA</caption>
                        <tr>
                            <td class="auto-style2">Riciclabile</td>
                            <td>
                                <asp:CheckBox ID="CheckBox5" runat="server" Checked='<%# Bind("reciclabile") %>' />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Aggiorna" />
                    &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Annulla" />
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <asp:Label ID="lbl_vuoto" runat="server" ForeColor="Red">MATRICOLA INESISTENTE, PER ESEGUIRE UNA NUOVA RICERCA CLICCA</asp:Label>
                    <asp:HyperLink ID="HP_vuoto" runat="server" ForeColor="#CC0000" NavigateUrl="ins_dimissioni.aspx">QUI</asp:HyperLink>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    dim_g:
                    <asp:TextBox ID="dim_gTextBox" runat="server" Text='<%# Bind("dim_g") %>' />
                    <br />
                    dat_dim_g:
                    <asp:TextBox ID="dat_dim_gTextBox" runat="server" Text='<%# Bind("dat_dim_g") %>' />
                    <br />
                    dim_s:
                    <asp:TextBox ID="dim_sTextBox" runat="server" Text='<%# Bind("dim_s") %>' />
                    <br />
                    dat_dim_s:
                    <asp:TextBox ID="dat_dim_sTextBox" runat="server" Text='<%# Bind("dat_dim_s") %>' />
                    <br />
                    sospensione:
                    <asp:TextBox ID="sospensioneTextBox" runat="server" Text='<%# Bind("sospensione") %>' />
                    <br />
                    data_inz_sosp:
                    <asp:TextBox ID="data_inz_sospTextBox" runat="server" Text='<%# Bind("data_inz_sosp") %>' />
                    <br />
                    data_fin_sosp:
                    <asp:TextBox ID="data_fin_sospTextBox" runat="server" Text='<%# Bind("data_fin_sosp") %>' />
                    <br />
                    motivo_sosp:
                    <asp:TextBox ID="motivo_sospTextBox" runat="server" Text='<%# Bind("motivo_sosp") %>' />
                    <br />
                    espulsione:
                    <asp:TextBox ID="espulsioneTextBox" runat="server" Text='<%# Bind("espulsione") %>' />
                    <br />
                    data_espul:
                    <asp:TextBox ID="data_espulTextBox" runat="server" Text='<%# Bind("data_espul") %>' />
                    <br />
                    motivo_espul:
                    <asp:TextBox ID="motivo_espulTextBox" runat="server" Text='<%# Bind("motivo_espul") %>' />
                    <br />
                    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Inserisci" />
                    &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Annulla" />
                </InsertItemTemplate>
                <ItemTemplate>
                    id_socio:
                    <asp:Label ID="id_socioLabel" runat="server" Text='<%# Eval("id_socio") %>' />
                    <br />
                    dim_g:
                    <asp:Label ID="dim_gLabel" runat="server" Text='<%# Bind("dim_g") %>' />
                    <br />
                    dat_dim_g:
                    <asp:Label ID="dat_dim_gLabel" runat="server" Text='<%# Bind("dat_dim_g") %>' />
                    <br />
                    dim_s:
                    <asp:Label ID="dim_sLabel" runat="server" Text='<%# Bind("dim_s") %>' />
                    <br />
                    dat_dim_s:
                    <asp:Label ID="dat_dim_sLabel" runat="server" Text='<%# Bind("dat_dim_s") %>' />
                    <br />
                    sospensione:
                    <asp:Label ID="sospensioneLabel" runat="server" Text='<%# Bind("sospensione") %>' />
                    <br />
                    data_inz_sosp:
                    <asp:Label ID="data_inz_sospLabel" runat="server" Text='<%# Bind("data_inz_sosp") %>' />
                    <br />
                    data_fin_sosp:
                    <asp:Label ID="data_fin_sospLabel" runat="server" Text='<%# Bind("data_fin_sosp") %>' />
                    <br />
                    motivo_sosp:
                    <asp:Label ID="motivo_sospLabel" runat="server" Text='<%# Bind("motivo_sosp") %>' />
                    <br />
                    espulsione:
                    <asp:Label ID="espulsioneLabel" runat="server" Text='<%# Bind("espulsione") %>' />
                    <br />
                    data_espul:
                    <asp:Label ID="data_espulLabel" runat="server" Text='<%# Bind("data_espul") %>' />
                    <br />
                    motivo_espul:
                    <asp:Label ID="motivo_espulLabel" runat="server" Text='<%# Bind("motivo_espul") %>' />
                    <br />
                    <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Modifica" />
                    &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Elimina" />
                    &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="Nuovo" />
                </ItemTemplate>
            </asp:FormView>
        </asp:Panel>
    </div>
</asp:Content>
