<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="ins_settore.aspx.vb" Inherits="GNAVBMForm.ins_settore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font-family: Calibri">
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <asp:FormView ID="FormView1" runat="server" DataSourceID="SqlDataSource1" DataKeyNames="id_settore" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Both">
            <EditItemTemplate>
                ID_settore:&nbsp;<asp:Label ID="id_settoreLabel" runat="server" Text='<%# Eval("id_settore") %>' />
                <br />
                Matricola:
                <asp:Label ID="matricolaLabel" runat="server" Text='<%# Bind("matricola") %>' />
                <br />
                <table style="width:100%;">
                    <tr>
                        <td>Divisione Ambiente</td>
                        <td>
                            <asp:CheckBox ID="CheckBox24" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Vigilanza</td>
                        <td>
                            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("vigilanza") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Stampa e Diffusione</td>
                        <td>
                            <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# Bind("stampa_diff") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Formazione</td>
                        <td>
                            <asp:CheckBox ID="CheckBox3" runat="server" Checked='<%# Bind("formazione") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Protezione Civile</td>
                        <td>
                            <asp:CheckBox ID="CheckBox4" runat="server" Checked='<%# Bind("prot_civ") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Intelligence</td>
                        <td>
                            <asp:CheckBox ID="CheckBox5" runat="server" Checked='<%# Bind("intelligence") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Pari Opportunità</td>
                        <td>
                            <asp:CheckBox ID="CheckBox6" runat="server" Checked='<%# Bind("pari_opp") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Comparto Sanità</td>
                        <td>
                            <asp:CheckBox ID="CheckBox7" runat="server" Checked='<%# Bind("sanita") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Culto Religione Cattolica</td>
                        <td>
                            <asp:CheckBox ID="CheckBox8" runat="server" Checked='<%# Bind("culto_rel") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Found Raising</td>
                        <td>
                            <asp:CheckBox ID="CheckBox9" runat="server" Checked='<%# Bind("fondi") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Sport e Specialità</td>
                        <td>
                            <asp:CheckBox ID="CheckBox10" runat="server" Checked='<%# Bind("sport") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Incombenze Interne e Disciplinare</td>
                        <td>
                            <asp:CheckBox ID="CheckBox11" runat="server" Checked='<%# Bind("disciplinare") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Rapporti con gli Stati Maggiori</td>
                        <td>
                            <asp:CheckBox ID="CheckBox12" runat="server" Checked='<%# Bind("statimaggiori") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Relazioni Istituzionali</td>
                        <td>
                            <asp:CheckBox ID="CheckBox13" runat="server" Checked='<%# Bind("rel_istit") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Dipartimento Attività Promozionali</td>
                        <td>
                            <asp:CheckBox ID="CheckBox14" runat="server" Checked='<%# Bind("dap") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Reparto Investigazioni Ambientali</td>
                        <td>
                            <asp:CheckBox ID="CheckBox15" runat="server" Checked='<%# Bind("ria") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Raggruppamento Analisi Scientifiche</td>
                        <td>
                            <asp:CheckBox ID="CheckBox16" runat="server" Checked='<%# Bind("ras") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Equipaggiamenti individuali</td>
                        <td>
                            <asp:CheckBox ID="CheckBox17" runat="server" Checked='<%# Bind("equipaggiamenti") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Trasporti Terrestri </td>
                        <td>
                            <asp:CheckBox ID="CheckBox18" runat="server" Checked='<%# Bind("trasporti_ter") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Trasporti Aereo Navali</td>
                        <td>
                            <asp:CheckBox ID="CheckBox19" runat="server" Checked='<%# Bind("t_aereonavale") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Ricerca Scientifica</td>
                        <td>
                            <asp:CheckBox ID="CheckBox20" runat="server" Checked='<%# Bind("ricerca") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Rapporti con gli Stati Esteri</td>
                        <td>
                            <asp:CheckBox ID="CheckBox21" runat="server" Checked='<%# Bind("esteri") %>' />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Aggiorna" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Annulla" />
            </EditItemTemplate>
            <EditRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <EmptyDataTemplate>
                <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="Nuovo" />
            </EmptyDataTemplate>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <InsertItemTemplate>
                <table style="width:100%;">
                    <tr>
                        <td>Divisione Ambiente</td>
                        <td>
                            <asp:CheckBox ID="CheckBox23" runat="server" Checked='<%# Bind("ambiente") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Vigilanza</td>
                        <td>
                            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("vigilanza") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Stampa e Diffusione</td>
                        <td>
                            <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# Bind("stampa_diff") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Formazione</td>
                        <td>
                            <asp:CheckBox ID="CheckBox3" runat="server" Checked='<%# Bind("formazione") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Protezione Civile</td>
                        <td>
                            <asp:CheckBox ID="CheckBox4" runat="server" Checked='<%# Bind("prot_civ") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Intelligence</td>
                        <td>
                            <asp:CheckBox ID="CheckBox5" runat="server" Checked='<%# Bind("intelligence") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Pari Opportunità</td>
                        <td>
                            <asp:CheckBox ID="CheckBox6" runat="server" Checked='<%# Bind("pari_opp") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Comparto Sanità</td>
                        <td>
                            <asp:CheckBox ID="CheckBox7" runat="server" Checked='<%# Bind("sanita") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Culto Religione Cattolica</td>
                        <td>
                            <asp:CheckBox ID="CheckBox8" runat="server" Checked='<%# Bind("culto_rel") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Found Raising</td>
                        <td>
                            <asp:CheckBox ID="CheckBox9" runat="server" Checked='<%# Bind("fondi") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Sport e Specialità</td>
                        <td>
                            <asp:CheckBox ID="CheckBox10" runat="server" Checked='<%# Bind("sport") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Incombenze Interne e Disciplinare</td>
                        <td>
                            <asp:CheckBox ID="CheckBox11" runat="server" Checked='<%# Bind("disciplinare") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Rapporti con gli Stati Maggiori</td>
                        <td>
                            <asp:CheckBox ID="CheckBox12" runat="server" Checked='<%# Bind("statimaggiori") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Relazioni Istituzionali</td>
                        <td>
                            <asp:CheckBox ID="CheckBox13" runat="server" Checked='<%# Bind("rel_istit") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Dipartimento Attività Promozionali</td>
                        <td>
                            <asp:CheckBox ID="CheckBox14" runat="server" Checked='<%# Bind("dap") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Reparto Investigazioni Ambientali</td>
                        <td>
                            <asp:CheckBox ID="CheckBox15" runat="server" Checked='<%# Bind("ria") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Raggruppamento Analisi Scientifiche</td>
                        <td>
                            <asp:CheckBox ID="CheckBox16" runat="server" Checked='<%# Bind("ras") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Equipaggiamenti individuali</td>
                        <td>
                            <asp:CheckBox ID="CheckBox17" runat="server" Checked='<%# Bind("equipaggiamenti") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Trasporti Terrestri </td>
                        <td>
                            <asp:CheckBox ID="CheckBox18" runat="server" Checked='<%# Bind("trasporti_ter") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Trasporti Aereo Navali</td>
                        <td>
                            <asp:CheckBox ID="CheckBox19" runat="server" Checked='<%# Bind("t_aereonavale") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Ricerca Scientifica</td>
                        <td>
                            <asp:CheckBox ID="CheckBox20" runat="server" Checked='<%# Bind("ricerca") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Rapporti con gli Stati Esteri</td>
                        <td>
                            <asp:CheckBox ID="CheckBox21" runat="server" Checked='<%# Bind("esteri") %>' />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Inserisci" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Annulla" />
            </InsertItemTemplate>
            <ItemTemplate>
                Matricola:
                <asp:Label ID="matricolaLabel" runat="server" Text='<%# Bind("matricola") %>' />
                <br />
                <table style="width:100%;">
                    <tr>
                        <td>Divisione Ambiente</td>
                        <td>
                            <asp:CheckBox ID="CheckBox22" runat="server" Checked='<%# Bind("ambiente") %>' Enabled="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Vigilanza</td>
                        <td>
                            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("vigilanza") %>' Enabled="False" />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Stampa e Diffusione</td>
                        <td>
                            <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# Bind("stampa_diff") %>' Enabled="False" />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Formazione</td>
                        <td>
                            <asp:CheckBox ID="CheckBox3" runat="server" Checked='<%# Bind("formazione") %>' Enabled="False" />
                        </td>
                    </tr><tr>
                        <td>Divisione Protezione Civile</td>
                        <td>
                            <asp:CheckBox ID="CheckBox4" runat="server" Checked='<%# Bind("prot_civ") %>' Enabled="False" />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Intelligence</td>
                        <td>
                            <asp:CheckBox ID="CheckBox5" runat="server" Checked='<%# Bind("intelligence") %>' Enabled="False" />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Pari Opportunità</td>
                        <td>
                            <asp:CheckBox ID="CheckBox6" runat="server" Checked='<%# Bind("pari_opp") %>' Enabled="False" />
                        </td>
                    </tr><tr>
                        <td>Comparto Sanità</td>
                        <td>
                            <asp:CheckBox ID="CheckBox7" runat="server" Checked='<%# Bind("sanita") %>' Enabled="False" />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Culto Religione Cattolica</td>
                        <td>
                            <asp:CheckBox ID="CheckBox8" runat="server" Checked='<%# Bind("culto_rel") %>' Enabled="False" />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Found Raising</td>
                        <td>
                            <asp:CheckBox ID="CheckBox9" runat="server" Checked='<%# Bind("fondi") %>' Enabled="False" />
                        </td>
                    </tr><tr>
                        <td>Divisione Sport e Specialità</td>
                        <td>
                            <asp:CheckBox ID="CheckBox10" runat="server" Checked='<%# Bind("sport") %>' Enabled="False" />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Incombenze Interne e Disciplinare</td>
                        <td>
                            <asp:CheckBox ID="CheckBox11" runat="server" Checked='<%# Bind("disciplinare") %>' Enabled="False" />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Rapporti con gli Stati Maggiori</td>
                        <td>
                            <asp:CheckBox ID="CheckBox12" runat="server" Checked='<%# Bind("statimaggiori") %>' Enabled="False" />
                        </td>
                    </tr><tr>
                        <td>Divisione Relazioni Istituzionali</td>
                        <td>
                            <asp:CheckBox ID="CheckBox13" runat="server" Checked='<%# Bind("rel_istit") %>' Enabled="False" />
                        </td>
                    </tr>
                    <tr>
                        <td>Dipartimento Attività Promozionali</td>
                        <td>
                            <asp:CheckBox ID="CheckBox14" runat="server" Checked='<%# Bind("dap") %>' Enabled="False" />
                        </td>
                    </tr>
                    <tr>
                        <td>Reparto Investigazioni Ambientali</td>
                        <td>
                            <asp:CheckBox ID="CheckBox15" runat="server" Checked='<%# Bind("ria") %>' Enabled="False" />
                        </td>
                    </tr><tr>
                        <td>Raggruppamento Analisi Scientifiche</td>
                        <td>
                            <asp:CheckBox ID="CheckBox16" runat="server" Checked='<%# Bind("ras") %>' Enabled="False" />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Equipaggiamenti individuali</td>
                        <td>
                            <asp:CheckBox ID="CheckBox17" runat="server" Checked='<%# Bind("equipaggiamenti") %>' Enabled="False" />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Trasporti Terrestri </td>
                        <td>
                            <asp:CheckBox ID="CheckBox18" runat="server" Checked='<%# Bind("trasporti_ter") %>' Enabled="False" />
                        </td>
                    </tr><tr>
                        <td>Divisione Trasporti Aereo Navali</td>
                        <td>
                            <asp:CheckBox ID="CheckBox19" runat="server" Checked='<%# Bind("t_aereonavale") %>' Enabled="False" />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Ricerca Scientifica</td>
                        <td>
                            <asp:CheckBox ID="CheckBox20" runat="server" Checked='<%# Bind("ricerca") %>' Enabled="False" />
                        </td>
                    </tr>
                    <tr>
                        <td>Divisione Rapporti con gli Stati Esteri</td>
                        <td>
                            <asp:CheckBox ID="CheckBox21" runat="server" Checked='<%# Bind("esteri") %>' Enabled="False" />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Modifica" />
                &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Elimina" />
                &nbsp;
            </ItemTemplate>
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
        </asp:FormView>
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" 
            DeleteCommand="DELETE FROM tbl_settori WHERE id_settore = ?" 
            InsertCommand="INSERT INTO tbl_settori (id_settore, matricola, ambiente, vigilanza, stampa_diff, formazione, prot_civ, intelligence, pari_opp, sanita, culto_rel, fondi, sport, disciplinare, statimaggiori, rel_istit, dap, ria, ras, equipaggiamenti, trasporti_ter, t_aereonavale, ricerca, esteri) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)" 
            ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" 
            SelectCommand="SELECT * FROM tbl_settori WHERE (matricola = ?)" 
            UpdateCommand="UPDATE tbl_settori SET matricola = ?, ambiente = ?, vigilanza = ?, stampa_diff = ?, formazione = ?, prot_civ = ?, intelligence = ?, pari_opp = ?, sanita = ?, culto_rel = ?, fondi = ?, sport = ?, disciplinare = ?, statimaggiori = ?, rel_istit = ?, dap = ?, ria = ?, ras = ?, equipaggiamenti = ?, trasporti_ter = ?, t_aereonavale = ?, ricerca = ?, esteri = ? WHERE id_settore = ?">
            <DeleteParameters>
                <asp:Parameter Name="id_settore" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="id_settore" Type="Int32" />
                <asp:QueryStringParameter Name="matricola" QueryStringField="matr" Type="Int32" />
                <asp:Parameter Name="ambiente" Type="String" />
                <asp:Parameter Name="vigilanza" Type="String" />
                <asp:Parameter Name="stampa_diff" Type="String" />
                <asp:Parameter Name="formazione" Type="String" />
                <asp:Parameter Name="prot_civ" Type="String" />
                <asp:Parameter Name="intelligence" Type="String" />
                <asp:Parameter Name="pari_opp" Type="String" />
                <asp:Parameter Name="sanita" Type="String" />
                <asp:Parameter Name="culto_rel" Type="String" />
                <asp:Parameter Name="fondi" Type="String" />
                <asp:Parameter Name="sport" Type="String" />
                <asp:Parameter Name="disciplinare" Type="String" />
                <asp:Parameter Name="statimaggiori" Type="String" />
                <asp:Parameter Name="rel_istit" Type="String" />
                <asp:Parameter Name="dap" Type="String" />
                <asp:Parameter Name="ria" Type="String" />
                <asp:Parameter Name="ras" Type="String" />
                <asp:Parameter Name="equipaggiamenti" Type="String" />
                <asp:Parameter Name="trasporti_ter" Type="String" />
                <asp:Parameter Name="t_aereonavale" Type="String" />
                <asp:Parameter Name="ricerca" Type="String" />
                <asp:Parameter Name="esteri" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="matricola" QueryStringField="matr" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:QueryStringParameter Name="matricola" QueryStringField="matr" Type="Int32" />
                <asp:Parameter Name="ambiente" Type="String" />
                <asp:Parameter Name="vigilanza" Type="String" />
                <asp:Parameter Name="stampa_diff" Type="String" />
                <asp:Parameter Name="formazione" Type="String" />
                <asp:Parameter Name="prot_civ" Type="String" />
                <asp:Parameter Name="intelligence" Type="String" />
                <asp:Parameter Name="pari_opp" Type="String" />
                <asp:Parameter Name="sanita" Type="String" />
                <asp:Parameter Name="culto_rel" Type="String" />
                <asp:Parameter Name="fondi" Type="String" />
                <asp:Parameter Name="sport" Type="String" />
                <asp:Parameter Name="disciplinare" Type="String" />
                <asp:Parameter Name="statimaggiori" Type="String" />
                <asp:Parameter Name="rel_istit" Type="String" />
                <asp:Parameter Name="dap" Type="String" />
                <asp:Parameter Name="ria" Type="String" />
                <asp:Parameter Name="ras" Type="String" />
                <asp:Parameter Name="equipaggiamenti" Type="String" />
                <asp:Parameter Name="trasporti_ter" Type="String" />
                <asp:Parameter Name="t_aereonavale" Type="String" />
                <asp:Parameter Name="ricerca" Type="String" />
                <asp:Parameter Name="esteri" Type="String" />
                <asp:Parameter Name="id_settore" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
