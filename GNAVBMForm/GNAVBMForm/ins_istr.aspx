<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="ins_istr.aspx.vb" Inherits="GNAVBMForm.ins_istr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font-family: Calibri">
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="id_istr" 
            DataSourceID="DS_istruzione" DefaultMode="Insert" CellPadding="4" 
            ForeColor="#333333" style="font-family: Calibri; width: 546px" Width="541px">
            <EditItemTemplate>
                id_istr:
                <asp:Label ID="id_istrLabel1" runat="server" Text='<%# Eval("id_istr") %>' />
                <br />
                matricola:
                <asp:TextBox ID="matricolaTextBox" runat="server" 
                    Text='<%# Bind("matricola") %>' />
                <br />
                dt_conseg:
                <asp:TextBox ID="dt_consegTextBox" runat="server" 
                    Text='<%# Bind("dt_conseg") %>' />
                <br />
                ente_ril:
                <asp:TextBox ID="ente_rilTextBox" runat="server" 
                    Text='<%# Bind("ente_ril") %>' />
                <br />
                punt:
                <asp:TextBox ID="puntTextBox" runat="server" Text='<%# Bind("punt") %>' />
                <br />
                tipo:
                <asp:TextBox ID="tipoTextBox" runat="server" Text='<%# Bind("tipo") %>' />
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
                            Data Conseguimento</td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("dt_conseg") %>' Height="22px" Width="180px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Ente Rilascio</td>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ente_ril") %>' Height="22px" Width="180px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Punteggio</td>
                        <td>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("punt") %>' Height="22px" Width="180px"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            Tipo</td>
                        <td>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("tipo") %>' Height="22px" Width="178px"></asp:TextBox>
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
                id_istr:
                <asp:Label ID="id_istrLabel" runat="server" Text='<%# Eval("id_istr") %>' />
                <br />
                matricola:
                <asp:Label ID="matricolaLabel" runat="server" Text='<%# Bind("matricola") %>' />
                <br />
                dt_conseg:
                <asp:Label ID="dt_consegLabel" runat="server" Text='<%# Bind("dt_conseg") %>' />
                <br />
                ente_ril:
                <asp:Label ID="ente_rilLabel" runat="server" Text='<%# Bind("ente_ril") %>' />
                <br />
                punt:
                <asp:Label ID="puntLabel" runat="server" Text='<%# Bind("punt") %>' />
                <br />
                tipo:
                <asp:Label ID="tipoLabel" runat="server" Text='<%# Bind("tipo") %>' />
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
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id_istr" 
            DataSourceID="DS_istruzione">
            <Columns>
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" 
                    ShowEditButton="True" />
                <asp:BoundField DataField="id_istr" HeaderText="id_istr" InsertVisible="False" 
                    ReadOnly="True" SortExpression="id_istr" Visible="False" />
                <asp:BoundField DataField="matricola" HeaderText="matricola" 
                    SortExpression="matricola" Visible="False" />
                <asp:BoundField DataField="dt_conseg" HeaderText="Data Consegna" 
                    SortExpression="dt_conseg" />
                <asp:BoundField DataField="ente_ril" HeaderText="Ente Rilascio" 
                    SortExpression="ente_ril" />
                <asp:BoundField DataField="punt" HeaderText="Punteggio" SortExpression="punt" />
                <asp:BoundField DataField="tipo" HeaderText="Tipo" SortExpression="tipo" />
            </Columns>
            <EmptyDataTemplate>
                Non ci sono titoli inseriti per il socio.
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:SqlDataSource ID="DS_istruzione" runat="server" 
        ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" 
        DeleteCommand="DELETE FROM tbl_istruzione WHERE id_istr = ?" 
        InsertCommand="INSERT INTO tbl_istruzione (matricola, dt_conseg, ente_ril, punt, tipo) VALUES (?, ?, ?, ?, ?)" 
        ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" 
        SelectCommand="SELECT * FROM tbl_istruzione WHERE (matricola = ?)" 
        UpdateCommand="UPDATE tbl_istruzione SET dt_conseg = ?, ente_ril = ?, punt = ?, tipo = ? WHERE id_istr = ?">
        <DeleteParameters>
            <asp:Parameter Name="id_istr" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:QueryStringParameter Name="matricola" Type="Int32" QueryStringField="matr" />
            <asp:Parameter Name="dt_conseg" Type="String" />
            <asp:Parameter Name="ente_ril" Type="String" />
            <asp:Parameter Name="punt" Type="String" />
            <asp:Parameter Name="tipo" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="matricola" QueryStringField="matr" 
                Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="dt_conseg" Type="String" />
            <asp:Parameter Name="ente_ril" Type="String" />
            <asp:Parameter Name="punt" Type="String" />
            <asp:Parameter Name="tipo" Type="String" />
            <asp:Parameter Name="id_istr" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
        
    </div>
</asp:Content>
