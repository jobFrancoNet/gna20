<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="ins_arm.aspx.vb" Inherits="GNAVBMForm.ins_arm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:FormView ID="FormView1" runat="server" DataSourceID="DS_armi" 
            DefaultMode="Insert" CellPadding="4" ForeColor="#333333">
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <InsertItemTemplate>
                <table style="width:100%;">
                    <tr>
                        <td>
                            Marca Arma</td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("marca_arma") %>'></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Modello Arma</td>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("mod_arma") %>'></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Calibro</td>
                        <td>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("calibro") %>'></asp:TextBox>
                        </td>
                    </tr>
                    </tr>
                    <tr>
                        <td>
                            Colpi</td>
                        <td>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("colpi") %>'></asp:TextBox>
                        </td>
                    </tr>
                    </tr>
                    <tr>
                        <td>
                            Matricola Arma</td>
                        <td>
                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("matricola_arma") %>'></asp:TextBox>
                        </td>
                    </tr>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btn_ins" runat="server" CommandName="Insert" 
                                Text="Inserisci" CausesValidation="true" />
                        </td>
                    </tr>
                </table>
            </InsertItemTemplate>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
        </asp:FormView>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
            BorderWidth="1px" CellPadding="4" DataSourceID="DS_armi" 
            AutoGenerateColumns="False" DataKeyNames="id_arma">
            <Columns>
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" 
                    ShowEditButton="True" />
                <asp:BoundField DataField="id_arma" HeaderText="id_arma" InsertVisible="False" 
                    ReadOnly="True" SortExpression="id_arma" Visible="False" />
                <asp:BoundField DataField="matricola" HeaderText="Matricola" 
                    SortExpression="matricola" Visible="False" />
                <asp:BoundField DataField="marca_arma" HeaderText="Marca Arma" 
                    SortExpression="marca_arma" />
                <asp:BoundField DataField="mod_arma" HeaderText="Modello  Arma" 
                    SortExpression="mod_arma" />
                <asp:BoundField DataField="calibro" HeaderText="Calibro" 
                    SortExpression="calibro" />
                <asp:BoundField DataField="colpi" HeaderText="Colpi" SortExpression="colpi" />
                <asp:BoundField DataField="matricola_arma" HeaderText="Matricola Arma" 
                    SortExpression="matricola_arma" />
            </Columns>
            <EmptyDataTemplate>
                Non ci sono armi inserite per questo socio
            </EmptyDataTemplate>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
        <asp:SqlDataSource ID="DS_armi" runat="server" 
            ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" 
            DeleteCommand="DELETE FROM tbl_armi1 WHERE id_arma = ?" 
            InsertCommand="INSERT INTO tbl_armi1 (matricola, marca_arma, mod_arma, calibro, colpi, matricola_arma) VALUES (?, ?, ?, ?, ?, ?)" 
            ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" 
            SelectCommand="SELECT * FROM tbl_armi1 WHERE (matricola = ?)" 
            UpdateCommand="UPDATE tbl_armi1 SET marca_arma = ?, mod_arma = ?, calibro = ?, colpi = ?, matricola_arma = ? WHERE id_arma = ?">
            <DeleteParameters>
                <asp:Parameter Name="id_arma" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:QueryStringParameter Name="matricola" Type="Int32" QueryStringField="matr" />
                <asp:Parameter Name="marca_arma" Type="String" />
                <asp:Parameter Name="mod_arma" Type="String" />
                <asp:Parameter Name="calibro" Type="String" />
                <asp:Parameter Name="colpi" Type="Int32" />
                <asp:Parameter Name="matricola_arma" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="matricola" QueryStringField="matr" 
                    Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="marca_arma" Type="String" />
                <asp:Parameter Name="mod_arma" Type="String" />
                <asp:Parameter Name="calibro" Type="String" />
                <asp:Parameter Name="colpi" Type="Int32" />
                <asp:Parameter Name="matricola_arma" Type="String" />
                <asp:Parameter Name="id_arma" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
