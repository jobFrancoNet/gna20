<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="ins_ric.aspx.vb" Inherits="GNAVBMForm.ins_ric" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font-family: Calibri">
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="id_ricon" 
            DataSourceID="DS_riconoscimenti" DefaultMode="Insert" CellPadding="4" 
            ForeColor="#333333" Width="680px">
            <EditItemTemplate>
                id_ricon:
                <asp:Label ID="id_riconLabel1" runat="server" Text='<%# Eval("id_ricon") %>' />
                <br />
                matricola:
                <asp:TextBox ID="matricolaTextBox" runat="server" 
                    Text='<%# Bind("matricola") %>' />
                <br />
                data_ric:
                <asp:TextBox ID="data_ricTextBox" runat="server" 
                    Text='<%# Bind("data_ric") %>' />
                <br />
                ente_ric:
                <asp:TextBox ID="ente_ricTextBox" runat="server" 
                    Text='<%# Bind("ente_ric") %>' />
                <br />
                tipo_ric:
                <asp:TextBox ID="tipo_ricTextBox" runat="server" 
                    Text='<%# Bind("tipo_ric") %>' />
                <br />
                ric:
                <asp:TextBox ID="ricTextBox" runat="server" Text='<%# Bind("ric") %>' />
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
                            Data Riconoscimento</td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("data_ric") %>' Height="22px" Width="180px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Ente</td>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ente_ric") %>' Height="22px" Width="180px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Tipo Riconoscimento</td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server" 
                                SelectedValue='<%# Bind("tipo_ric") %>' Height="22px" Width="180px">
                                <asp:ListItem Selected="True"></asp:ListItem>
                                <asp:ListItem>Encomio</asp:ListItem>
                                <asp:ListItem>Lode</asp:ListItem>
                                <asp:ListItem>Grado</asp:ListItem>
                                <asp:ListItem>Qualifica</asp:ListItem>
                                <asp:ListItem>Attestato</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Riconoscimento</td>
                        <td>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("ric") %>' Height="22px" Width="179px"></asp:TextBox>
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
                id_ricon:
                <asp:Label ID="id_riconLabel" runat="server" Text='<%# Eval("id_ricon") %>' />
                <br />
                matricola:
                <asp:Label ID="matricolaLabel" runat="server" Text='<%# Bind("matricola") %>' />
                <br />
                data_ric:
                <asp:Label ID="data_ricLabel" runat="server" Text='<%# Bind("data_ric") %>' />
                <br />
                ente_ric:
                <asp:Label ID="ente_ricLabel" runat="server" Text='<%# Bind("ente_ric") %>' />
                <br />
                tipo_ric:
                <asp:Label ID="tipo_ricLabel" runat="server" Text='<%# Bind("tipo_ric") %>' />
                <br />
                ric:
                <asp:Label ID="ricLabel" runat="server" Text='<%# Bind("ric") %>' />
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
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id_ricon" 
            DataSourceID="DS_riconoscimenti">
            <Columns>
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" 
                    ShowEditButton="True" />
                <asp:BoundField DataField="id_ricon" HeaderText="id_ricon" 
                    InsertVisible="False" ReadOnly="True" SortExpression="id_ricon" 
                    Visible="False" />
                <asp:BoundField DataField="matricola" HeaderText="matricola" 
                    SortExpression="matricola" Visible="False" />
                <asp:BoundField DataField="data_ric" HeaderText="Data Riconoscimento" 
                    SortExpression="data_ric" />
                <asp:BoundField DataField="ente_ric" HeaderText="Ente Riconoscimento" 
                    SortExpression="ente_ric" />
                <asp:BoundField DataField="tipo_ric" HeaderText="Tipo Riconoscimento" 
                    SortExpression="tipo_ric" />
                <asp:BoundField DataField="ric" HeaderText="Riconoscimento" 
                    SortExpression="ric" />
            </Columns>
            <EmptyDataTemplate>
                Non ci sono riconoscimenti inseriti per il socio
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:SqlDataSource ID="DS_riconoscimenti" runat="server" 
            ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" 
            DeleteCommand="DELETE FROM tbl_riconoscimenti1 WHERE id_ricon = ?" 
            InsertCommand="INSERT INTO tbl_riconoscimenti1 (matricola, data_ric, ente_ric, tipo_ric, ric) VALUES (?, ?, ?, ?, ?)" 
            ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" 
            SelectCommand="SELECT * FROM tbl_riconoscimenti1 WHERE (matricola = ?)" 
            UpdateCommand="UPDATE tbl_riconoscimenti1 SET data_ric = ?, ente_ric = ?, tipo_ric = ?, ric = ? WHERE id_ricon = ?">
            <DeleteParameters>
                <asp:Parameter Name="id_ricon" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:QueryStringParameter Name="matricola" Type="Int32" QueryStringField="matr" />
                <asp:Parameter Name="data_ric" Type="String" />
                <asp:Parameter Name="ente_ric" Type="String" />
                <asp:Parameter Name="tipo_ric" Type="String" />
                <asp:Parameter Name="ric" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="matricola" QueryStringField="matr" 
                    Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="data_ric" Type="String" />
                <asp:Parameter Name="ente_ric" Type="String" />
                <asp:Parameter Name="tipo_ric" Type="String" />
                <asp:Parameter Name="ric" Type="String" />
                <asp:Parameter Name="id_ricon" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
