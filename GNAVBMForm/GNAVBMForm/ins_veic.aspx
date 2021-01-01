<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="ins_veic.aspx.vb" Inherits="GNAVBMForm.ins_veic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font-family: Calibri">
        <asp:FormView ID="FormView1" runat="server" CellPadding="4" 
            DataKeyNames="id_veic" DataSourceID="DS_veicolo" DefaultMode="Insert" 
            ForeColor="#333333" Width="758px">
            <EditItemTemplate>
                id_veic:
                <asp:Label ID="id_veicLabel1" runat="server" Text='<%# Eval("id_veic") %>' />
                <br />
                matricola:
                <asp:TextBox ID="matricolaTextBox" runat="server" 
                    Text='<%# Bind("matricola") %>' />
                <br />
                veic1:
                <asp:TextBox ID="veic1TextBox" runat="server" Text='<%# Bind("veic1") %>' />
                <br />
                mar_veic1:
                <asp:TextBox ID="mar_veic1TextBox" runat="server" 
                    Text='<%# Bind("mar_veic1") %>' />
                <br />
                mod_veic1:
                <asp:TextBox ID="mod_veic1TextBox" runat="server" 
                    Text='<%# Bind("mod_veic1") %>' />
                <br />
                targ_veic1:
                <asp:TextBox ID="targ_veic1TextBox" runat="server" 
                    Text='<%# Bind("targ_veic1") %>' />
                <br />
                npos_veic1:
                <asp:TextBox ID="npos_veic1TextBox" runat="server" 
                    Text='<%# Bind("npos_veic1") %>' />
                <br />
                col_veic1:
                <asp:TextBox ID="col_veic1TextBox" runat="server" 
                    Text='<%# Bind("col_veic1") %>' />
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
                <table class="auto-style3">
                    <tr>
                        <td class="auto-style9">
                            Veicolo</td>
                        <td class="auto-style9">
                            <asp:DropDownList ID="DropDownList1" runat="server" 
                                SelectedValue='<%# Bind("veic1") %>' Height="22px" Width="180px">
                                <asp:ListItem Selected="True"></asp:ListItem>
                                <asp:ListItem>Motoveicolo</asp:ListItem>
                                <asp:ListItem>Autoveicolo</asp:ListItem>
                                <asp:ListItem>Autocarro</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style9">
                            Marca </td>
                        <td class="auto-style9">
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("mar_veic1") %>' Width="180px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style9">
                            Modello</td>
                        <td class="auto-style9">
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("mod_veic1") %>' Width="180px"></asp:TextBox>
                        </td>
                    </tr>
                    </tr>
                    </tr>
                    <td class="auto-style9">Targa</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("targ_veic1") %>' Width="180px"></asp:TextBox>
                    </td>
                    </tr>
                    <td class="auto-style9">N. posti</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="TextBox4" runat="server" Height="22px" Text='<%# Bind("npos_veic1") %>' Width="180px"></asp:TextBox>
                    </td>
                    </tr>
                    <td class="auto-style9">Colore</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="TextBox5" runat="server" Height="22px" Text='<%# Bind("col_veic1") %>' Width="180px"></asp:TextBox>
                    </td>
                    </tr>
                    
                    </tr>
                    <td class="auto-style9" colspan="2">
                        <asp:Button ID="Btn_ins" runat="server" CausesValidation="true" CommandName="Insert" Text="Inserisci" />
                    </td>
                </table>
            </InsertItemTemplate>
            <ItemTemplate>
                id_veic:
                <asp:Label ID="id_veicLabel" runat="server" Text='<%# Eval("id_veic") %>' />
                <br />
                matricola:
                <asp:Label ID="matricolaLabel" runat="server" Text='<%# Bind("matricola") %>' />
                <br />
                veic1:
                <asp:Label ID="veic1Label" runat="server" Text='<%# Bind("veic1") %>' />
                <br />
                mar_veic1:
                <asp:Label ID="mar_veic1Label" runat="server" Text='<%# Bind("mar_veic1") %>' />
                <br />
                mod_veic1:
                <asp:Label ID="mod_veic1Label" runat="server" Text='<%# Bind("mod_veic1") %>' />
                <br />
                targ_veic1:
                <asp:Label ID="targ_veic1Label" runat="server" 
                    Text='<%# Bind("targ_veic1") %>' />
                <br />
                npos_veic1:
                <asp:Label ID="npos_veic1Label" runat="server" 
                    Text='<%# Bind("npos_veic1") %>' />
                <br />
                col_veic1:
                <asp:Label ID="col_veic1Label" runat="server" Text='<%# Bind("col_veic1") %>' />
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
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id_veic" 
            DataSourceID="DS_veicolo">
            <Columns>
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" 
                    ShowEditButton="True" />
                <asp:BoundField DataField="id_veic" HeaderText="id_veic" InsertVisible="False" 
                    ReadOnly="True" SortExpression="id_veic" Visible="False" />
                <asp:BoundField DataField="matricola" HeaderText="Matricola" 
                    SortExpression="matricola" Visible="False" />
                <asp:BoundField DataField="veic1" HeaderText="Tipo Veicolo" 
                    SortExpression="veic1" />
                <asp:BoundField DataField="mar_veic1" HeaderText="Marca Veicolo" 
                    SortExpression="mar_veic1" />
                <asp:BoundField DataField="mod_veic1" HeaderText="Modello Veicolo" 
                    SortExpression="mod_veic1" />
                <asp:BoundField DataField="targ_veic1" HeaderText="Targa Veicolo" 
                    SortExpression="targ_veic1" />
                <asp:BoundField DataField="npos_veic1" HeaderText="Numero Posti" 
                    SortExpression="npos_veic1" />
                <asp:BoundField DataField="col_veic1" HeaderText="Colore Veicolo" 
                    SortExpression="col_veic1" />
            </Columns>
            <EmptyDataTemplate>
                Non ci sono veicoli inseriti per il socio
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:SqlDataSource ID="DS_veicolo" runat="server" 
            ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" 
            DeleteCommand="DELETE FROM tbl_veicolo1 WHERE id_veic = ?" 
            InsertCommand="INSERT INTO tbl_veicolo1 (matricola, veic1, mar_veic1, mod_veic1, targ_veic1, npos_veic1, col_veic1) VALUES (?, ?, ?, ?, ?, ?, ?)" 
            ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" 
            SelectCommand="SELECT * FROM tbl_veicolo1 WHERE (matricola = ?)" 
            UpdateCommand="UPDATE tbl_veicolo1 SET veic1 = ?, mar_veic1 = ?, mod_veic1 = ?, targ_veic1 = ?, npos_veic1 = ?, col_veic1 = ? WHERE id_veic = ?">
            <DeleteParameters>
                <asp:Parameter Name="id_veic" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:QueryStringParameter Name="matricola" Type="Int32" QueryStringField="matr" />
                <asp:Parameter Name="veic1" Type="String" />
                <asp:Parameter Name="mar_veic1" Type="String" />
                <asp:Parameter Name="mod_veic1" Type="String" />
                <asp:Parameter Name="targ_veic1" Type="String" />
                <asp:Parameter Name="npos_veic1" Type="Object" />
                <asp:Parameter Name="col_veic1" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="matricola" QueryStringField="matr" 
                    Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="veic1" Type="String" />
                <asp:Parameter Name="mar_veic1" Type="String" />
                <asp:Parameter Name="mod_veic1" Type="String" />
                <asp:Parameter Name="targ_veic1" Type="String" />
                <asp:Parameter Name="npos_veic1" Type="Object" />
                <asp:Parameter Name="col_veic1" Type="String" />
                <asp:Parameter Name="id_veic" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
