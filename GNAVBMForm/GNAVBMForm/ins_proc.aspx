<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="ins_proc.aspx.vb" Inherits="GNAVBMForm.ins_proc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font-family: Calibri">
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="id_proc" 
            DataSourceID="DS_procedure" DefaultMode="Insert" CellPadding="4" 
            ForeColor="#333333" Width="568px">
            <EditItemTemplate>
                id_proc:
                <asp:Label ID="id_procLabel1" runat="server" Text='<%# Eval("id_proc") %>' />
                <br />
                matricola:
                <asp:TextBox ID="matricolaTextBox" runat="server" 
                    Text='<%# Bind("matricola") %>' />
                <br />
                dat_not_reato:
                <asp:TextBox ID="dat_not_reatoTextBox" runat="server" 
                    Text='<%# Bind("dat_not_reato") %>' />
                <br />
                procura:
                <asp:TextBox ID="procuraTextBox" runat="server" Text='<%# Bind("procura") %>' />
                <br />
                n_proc:
                <asp:TextBox ID="n_procTextBox" runat="server" Text='<%# Bind("n_proc") %>' />
                <br />
                note:
                <asp:TextBox ID="noteTextBox" runat="server" Text='<%# Bind("note") %>' />
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
                            Data notizia</td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("dat_not_reato") %>' Height="22px" OnTextChanged="TextBox1_TextChanged" Width="180px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Procura</td>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("procura") %>' Height="22px" Width="180px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            N. Procedimento</td>
                        <td>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("n_proc") %>' Height="22px" Width="180px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Note</td>
                        <td>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("note") %>' Height="22px" Width="180px"></asp:TextBox>
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
                id_proc:
                <asp:Label ID="id_procLabel" runat="server" Text='<%# Eval("id_proc") %>' />
                <br />
                matricola:
                <asp:Label ID="matricolaLabel" runat="server" Text='<%# Bind("matricola") %>' />
                <br />
                dat_not_reato:
                <asp:Label ID="dat_not_reatoLabel" runat="server" 
                    Text='<%# Bind("dat_not_reato") %>' />
                <br />
                procura:
                <asp:Label ID="procuraLabel" runat="server" Text='<%# Bind("procura") %>' />
                <br />
                n_proc:
                <asp:Label ID="n_procLabel" runat="server" Text='<%# Bind("n_proc") %>' />
                <br />
                note:
                <asp:Label ID="noteLabel" runat="server" Text='<%# Bind("note") %>' />
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
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id_proc" 
            DataSourceID="DS_procedure">
            <Columns>
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" 
                    ShowEditButton="True" />
                <asp:BoundField DataField="id_proc" HeaderText="id_proc" InsertVisible="False" 
                    ReadOnly="True" SortExpression="id_proc" Visible="False" />
                <asp:BoundField DataField="matricola" HeaderText="matricola" 
                    SortExpression="matricola" Visible="False" />
                <asp:BoundField DataField="dat_not_reato" HeaderText="dat_not_reato" 
                    SortExpression="dat_not_reato" />
                <asp:BoundField DataField="procura" HeaderText="procura" 
                    SortExpression="procura" />
                <asp:BoundField DataField="n_proc" HeaderText="n_proc" 
                    SortExpression="n_proc" />
                <asp:BoundField DataField="note" HeaderText="note" SortExpression="note" />
            </Columns>
            <EmptyDataTemplate>
                Non ci sono procedimenti penali inseriti per il socio
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:SqlDataSource ID="DS_procedure" runat="server" 
            ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" 
            DeleteCommand="DELETE FROM tbl_procepenali WHERE id_proc = ?" 
            InsertCommand="INSERT INTO tbl_procepenali (matricola, dat_not_reato, procura, n_proc, note) VALUES (?, ?, ?, ?, ?)" 
            ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" 
            SelectCommand="SELECT * FROM tbl_procepenali WHERE (matricola = ?)" 
            UpdateCommand="UPDATE tbl_procepenali SET dat_not_reato = ?, procura = ?, n_proc = ?, note = ? WHERE id_proc = ?">
            <DeleteParameters>
                <asp:Parameter Name="id_proc" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:QueryStringParameter Name="matricola" Type="Int32" QueryStringField="matr" />
                <asp:Parameter Name="dat_not_reato" Type="String" />
                <asp:Parameter Name="procura" Type="String" />
                <asp:Parameter Name="n_proc" Type="String" />
                <asp:Parameter Name="note" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="matricola" QueryStringField="matr" 
                    Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="dat_not_reato" Type="String" />
                <asp:Parameter Name="procura" Type="String" />
                <asp:Parameter Name="n_proc" Type="String" />
                <asp:Parameter Name="note" Type="String" />
                <asp:Parameter Name="id_proc" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
