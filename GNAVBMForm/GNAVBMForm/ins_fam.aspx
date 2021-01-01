<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="ins_fam.aspx.vb" Inherits="GNAVBMForm.ins_fam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="id_famiglia" 
            DataSourceID="DS_famiglia" DefaultMode="Insert" CellPadding="4" 
            ForeColor="#333333" Width="693px">
            <EditItemTemplate>
                id_famiglia:
                <asp:Label ID="id_famigliaLabel1" runat="server" 
                    Text='<%# Eval("id_famiglia") %>' />
                <br />
                matricola:
                <asp:TextBox ID="matricolaTextBox" runat="server" 
                    Text='<%# Bind("matricola") %>' />
                <br />
                cogn_fam:
                <asp:TextBox ID="cogn_famTextBox" runat="server" 
                    Text='<%# Bind("cogn_fam") %>' />
                <br />
                nome_fam:
                <asp:TextBox ID="nome_famTextBox" runat="server" 
                    Text='<%# Bind("nome_fam") %>' />
                <br />
                data_nasc_fam:
                <asp:TextBox ID="data_nasc_famTextBox" runat="server" 
                    Text='<%# Bind("data_nasc_fam") %>' />
                <br />
                luogo_nasc_fam:
                <asp:TextBox ID="luogo_nasc_famTextBox" runat="server" 
                    Text='<%# Bind("luogo_nasc_fam") %>' />
                <br />
                grado_par_fam:
                <asp:TextBox ID="grado_par_famTextBox" runat="server" 
                    Text='<%# Bind("grado_par_fam") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                    CommandName="Update" Text="Aggiorna" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                    CausesValidation="False" CommandName="Cancel" Text="Annulla" />
            </EditItemTemplate>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <InsertItemTemplate>
                <table style="width:100%;">
                    <tr>
                        <td>
                            Cognome Familiare</td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("cogn_fam") %>' Height="22px" style="margin-left: 0px" Width="180px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nome Familiare</td>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("nome_fam") %>' Height="22px" Width="180px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Data Nascita</td>
                        <td>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("data_nasc_fam") %>' Width="180px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Luogo Nascita</td>
                        <td>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("luogo_nasc_fam") %>' Height="22px" Width="180px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Grado Parentela</td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server" 
                                SelectedValue='<%# Bind("grado_par_fam") %>' Height="22px" Width="180px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Marito</asp:ListItem>
                                <asp:ListItem>Moglie</asp:ListItem>
                                <asp:ListItem>Figlio</asp:ListItem>
                                <asp:ListItem>Figlia</asp:ListItem>
                                <asp:ListItem>Suocero</asp:ListItem>
                                <asp:ListItem>Suocera</asp:ListItem>
                                <asp:ListItem>Padre</asp:ListItem>
                                <asp:ListItem>Madre</asp:ListItem>
                                <asp:ListItem>Fratello</asp:ListItem>
                                <asp:ListItem>Sorella</asp:ListItem>
                                <asp:ListItem>Cognato</asp:ListItem>
                                <asp:ListItem>Cognata</asp:ListItem>
                                <asp:ListItem>Convivente</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="Btn_ins" runat="server" Text="Inserisci" CommandName="Insert" CausesValidation="true" />
                        </td>
                    </tr>
                </table>
            </InsertItemTemplate>
            <ItemTemplate>
                id_famiglia:
                <asp:Label ID="id_famigliaLabel" runat="server" 
                    Text='<%# Eval("id_famiglia") %>' />
                <br />
                matricola:
                <asp:Label ID="matricolaLabel" runat="server" Text='<%# Bind("matricola") %>' />
                <br />
                cogn_fam:
                <asp:Label ID="cogn_famLabel" runat="server" Text='<%# Bind("cogn_fam") %>' />
                <br />
                nome_fam:
                <asp:Label ID="nome_famLabel" runat="server" Text='<%# Bind("nome_fam") %>' />
                <br />
                data_nasc_fam:
                <asp:Label ID="data_nasc_famLabel" runat="server" 
                    Text='<%# Bind("data_nasc_fam") %>' />
                <br />
                luogo_nasc_fam:
                <asp:Label ID="luogo_nasc_famLabel" runat="server" 
                    Text='<%# Bind("luogo_nasc_fam") %>' />
                <br />
                grado_par_fam:
                <asp:Label ID="grado_par_famLabel" runat="server" 
                    Text='<%# Bind("grado_par_fam") %>' />
                <br />
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
                    CommandName="Edit" Text="Modifica" />
                &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" 
                    CommandName="Delete" Text="Elimina" />
                &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" 
                    CommandName="New" Text="Nuovo" />
            </ItemTemplate>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
        </asp:FormView>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id_famiglia" 
            DataSourceID="DS_famiglia">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ButtonType="Button" />
                <asp:BoundField DataField="id_famiglia" HeaderText="id_famiglia" 
                    InsertVisible="False" ReadOnly="True" SortExpression="id_famiglia" 
                    Visible="False" />
                <asp:BoundField DataField="matricola" HeaderText="matricola" 
                    SortExpression="matricola" Visible="False" />
                <asp:BoundField DataField="cogn_fam" HeaderText="Cognome Familiare" 
                    SortExpression="cogn_fam" />
                <asp:BoundField DataField="nome_fam" HeaderText="Nome Familiare" 
                    SortExpression="nome_fam" />
                <asp:BoundField DataField="data_nasc_fam" HeaderText="Data Nascita" 
                    SortExpression="data_nasc_fam" />
                <asp:BoundField DataField="luogo_nasc_fam" HeaderText="Luogo Nascita" 
                    SortExpression="luogo_nasc_fam" />
                <asp:BoundField DataField="grado_par_fam" HeaderText="Grado Parentela" 
                    SortExpression="grado_par_fam" />
            </Columns>
            <EmptyDataTemplate>
                Non ci sono familiari inseriti per il socio
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:SqlDataSource ID="DS_famiglia" runat="server" 
            ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" 
            DeleteCommand="DELETE FROM tbl_famiglia WHERE id_famiglia = ?" 
            InsertCommand="INSERT INTO tbl_famiglia (matricola, cogn_fam, nome_fam, data_nasc_fam, luogo_nasc_fam, grado_par_fam) VALUES (?, ?, ?, ?, ?, ?)" 
            ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" 
            SelectCommand="SELECT * FROM tbl_famiglia WHERE (matricola = ?)" 
            UpdateCommand="UPDATE tbl_famiglia SET cogn_fam = ?, nome_fam = ?, data_nasc_fam = ?, luogo_nasc_fam = ?, grado_par_fam = ? WHERE id_famiglia = ?">
            <DeleteParameters>
                <asp:Parameter Name="id_famiglia" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:QueryStringParameter Name="matricola" Type="Int32" QueryStringField="matr" />
                <asp:Parameter Name="cogn_fam" Type="String" />
                <asp:Parameter Name="nome_fam" Type="String" />
                <asp:Parameter Name="data_nasc_fam" Type="String" />
                <asp:Parameter Name="luogo_nasc_fam" Type="String" />
                <asp:Parameter Name="grado_par_fam" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="matricola" QueryStringField="matr" 
                    Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="cogn_fam" Type="String" />
                <asp:Parameter Name="nome_fam" Type="String" />
                <asp:Parameter Name="data_nasc_fam" Type="String" />
                <asp:Parameter Name="luogo_nasc_fam" Type="String" />
                <asp:Parameter Name="grado_par_fam" Type="String" />
                <asp:Parameter Name="id_famiglia" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
