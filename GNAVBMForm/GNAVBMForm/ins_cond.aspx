<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="ins_cond.aspx.vb" Inherits="GNAVBMForm.ins_cond" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font-family: Calibri">
        <asp:FormView ID="FormView1" runat="server" CellPadding="4" 
            DataKeyNames="id_cond" DataSourceID="DS_condanne" DefaultMode="Insert" 
            ForeColor="#333333" Width="569px">
            <EditItemTemplate>
                id_cond:
                <asp:Label ID="id_condLabel1" runat="server" Text='<%# Eval("id_cond") %>' />
                <br />
                matricola:
                <asp:TextBox ID="matricolaTextBox" runat="server" 
                    Text='<%# Bind("matricola") %>' />
                <br />
                data_prov:
                <asp:TextBox ID="data_provTextBox" runat="server" 
                    Text='<%# Bind("data_prov") %>' />
                <br />
                tribunale:
                <asp:TextBox ID="tribunaleTextBox" runat="server" 
                    Text='<%# Bind("tribunale") %>' />
                <br />
                n_proc:
                <asp:TextBox ID="n_procTextBox" runat="server" Text='<%# Bind("n_proc") %>' />
                <br />
                pena:
                <asp:TextBox ID="penaTextBox" runat="server" Text='<%# Bind("pena") %>' />
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
                            Data Provvedimento</td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("data_prov") %>' Height="22px" Width="180px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Tribunale</td>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("tribunale") %>' Height="22px" Width="180px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            N. proc.</td>
                        <td>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("n_proc") %>' Height="22px" Width="180px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Pena o sanzione</td>
                        <td>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("pena") %>' Height="22px" Width="180px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="Button1" runat="server" CommandName="Insert" Text="Inserisci" />
                        </td>
                    </tr>
                </table>
            </InsertItemTemplate>
            <ItemTemplate>
                id_cond:
                <asp:Label ID="id_condLabel" runat="server" Text='<%# Eval("id_cond") %>' />
                <br />
                matricola:
                <asp:Label ID="matricolaLabel" runat="server" Text='<%# Bind("matricola") %>' />
                <br />
                data_prov:
                <asp:Label ID="data_provLabel" runat="server" Text='<%# Bind("data_prov") %>' />
                <br />
                tribunale:
                <asp:Label ID="tribunaleLabel" runat="server" Text='<%# Bind("tribunale") %>' />
                <br />
                n_proc:
                <asp:Label ID="n_procLabel" runat="server" Text='<%# Bind("n_proc") %>' />
                <br />
                pena:
                <asp:Label ID="penaLabel" runat="server" Text='<%# Bind("pena") %>' />
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
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id_cond" 
            DataSourceID="DS_condanne">
            <Columns>
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" 
                    ShowEditButton="True" />
                <asp:BoundField DataField="id_cond" HeaderText="id_cond" InsertVisible="False" 
                    ReadOnly="True" SortExpression="id_cond" Visible="False" />
                <asp:BoundField DataField="matricola" HeaderText="matricola" 
                    SortExpression="matricola" Visible="False" />
                <asp:BoundField DataField="data_prov" HeaderText="data_prov" 
                    SortExpression="data_prov" />
                <asp:BoundField DataField="tribunale" HeaderText="tribunale" 
                    SortExpression="tribunale" />
                <asp:BoundField DataField="n_proc" HeaderText="n_proc" 
                    SortExpression="n_proc" />
                <asp:BoundField DataField="pena" HeaderText="pena" SortExpression="pena" />
            </Columns>
            <EmptyDataTemplate>
                Non ci sono condanne penali inserite per il socio
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:SqlDataSource ID="DS_condanne" runat="server" 
            ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" 
            DeleteCommand="DELETE FROM tbl_condanne WHERE id_cond = ?" 
            InsertCommand="INSERT INTO tbl_condanne (matricola, data_prov, tribunale, n_proc, pena) VALUES (?, ?, ?, ?, ?)" 
            ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" 
            SelectCommand="SELECT * FROM tbl_condanne WHERE matricola = ?" 
            UpdateCommand="UPDATE tbl_condanne SET data_prov = ?, tribunale = ?, n_proc = ?, pena = ? WHERE id_cond = ?">
            <DeleteParameters>
                <asp:Parameter Name="id_cond" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:QueryStringParameter Name="matricola" Type="Int32" QueryStringField="matr" />
                <asp:Parameter Name="data_prov" Type="String" />
                <asp:Parameter Name="tribunale" Type="String" />
                <asp:Parameter Name="n_proc" Type="String" />
                <asp:Parameter Name="pena" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="matricola" QueryStringField="matr" 
                    Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="data_prov" Type="String" />
                <asp:Parameter Name="tribunale" Type="String" />
                <asp:Parameter Name="n_proc" Type="String" />
                <asp:Parameter Name="pena" Type="String" />
                <asp:Parameter Name="id_cond" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
