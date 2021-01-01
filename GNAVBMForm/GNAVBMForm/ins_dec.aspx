<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="ins_dec.aspx.vb" Inherits="GNAVBMForm.ins_dec" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font-size: 12pt; font-family: calibri">
        <asp:HiddenField ID="HF_matricola" runat="server" />
        <asp:FormView ID="FormView1" runat="server" 
            CellPadding="4" DefaultMode="Insert" 
            ForeColor="#333333" DataSourceID="DS_decreti" style="background-image: url('img/sfondo-logo.png'); background-attachment: fixed; background-position: center" Width="686px">
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <InsertItemTemplate>
                <table style="width:100%;">
                    
                    <tr>
                        <td>
                            Tipo Decreto</td>
                        <td>
                            <asp:DropDownList ID="dec1DropDownList" runat="server" 
                                SelectedValue='<%# Bind("dec1") %>' AutoPostBack="True" OnSelectedIndexChanged="dec1DropDownList_SelectedIndexChanged" Width="270px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Provinciale</asp:ListItem>
                                <asp:ListItem>Prefettizio</asp:ListItem>
                                <asp:ListItem>Comunale</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        
                    </tr>
                    <tr>
                        <td>
                            Numero Decreto</td>
                        <td>
                            <asp:TextBox ID="num_dec1TextBox" runat="server" Text='<%# Bind("num_dec1") %>' Width="270px"></asp:TextBox>
                        </td>
                        </tr>
                        </tr>
                    <tr>
                        <td>
                            Ente Rilascio</td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server" 
                                SelectedValue='<%# Bind("ente_dec1") %>' Width="270px">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        </tr>
                        </tr>
                    <tr>
                        <td>
                            Data Rilascioi</td>
                        <td>
                            <asp:TextBox ID="dat_ril_dec1TextBox" runat="server" Text='<%# Bind("dat_ril_dec1") %>'></asp:TextBox>
                        </td>
                        </tr>
                    </tr>
                    <tr>
                        <td>
                            Data Scadenza</td>
                        <td>
                            <asp:TextBox ID="data_scad_dec1TextBox" runat="server" Text='<%# Bind("data_scad_dec1") %>'></asp:TextBox>
                        </td>
                        </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="Btn_ins" runat="server" Text="Inserisci" CommandName="Insert" CausesValidation="True" />
                            
                        </td>
                        
                        </tr>
                </table>
            </InsertItemTemplate>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
        </asp:FormView>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id_dec" 
            DataSourceID="DS_decreti" PageSize="15">
            <Columns>
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" 
                    ShowEditButton="True" />
                <asp:BoundField DataField="id_dec" HeaderText="id_dec" SortExpression="id_dec" 
                    Visible="False" />
                <asp:BoundField DataField="matricola" HeaderText="Matricola" 
                    SortExpression="matricola" Visible="False" />
                <asp:BoundField DataField="dec1" HeaderText="Tipo Decreto" 
                    SortExpression="dec1" />
                <asp:BoundField DataField="num_dec1" HeaderText="Numero Decreto" 
                    SortExpression="num_dec1" />
                <asp:BoundField DataField="ente_dec1" HeaderText="Ente Rilascio" 
                    SortExpression="ente_dec1" />
                <asp:BoundField DataField="dat_ril_dec1" HeaderText="Data Rilascio" 
                    SortExpression="dat_ril_dec1" />
                <asp:BoundField DataField="data_scad_dec1" HeaderText="Data Scadenza" 
                    SortExpression="data_scad_dec1" />
            </Columns>
            <EmptyDataTemplate>
                Non ci sono decreti inseriti per il socio
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:SqlDataSource ID="DS_decreti" runat="server" ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" 
            DeleteCommand="DELETE FROM tbl_decreti1 WHERE id_dec = ?" 
            InsertCommand="INSERT INTO tbl_decreti1 (matricola, dec1, num_dec1, ente_dec1, dat_ril_dec1, data_scad_dec1) VALUES (@matricola, @dec1, @num_dec1, @ente_dec1, @dat_ril_dec1, @data_scad_dec1)" 
            ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" 
            SelectCommand="SELECT * FROM tbl_decreti1 WHERE matricola = ?" 
            
            UpdateCommand="UPDATE tbl_decreti1 SET dec1 = ?, num_dec1 = ?, ente_dec1 = ?, dat_ril_dec1 = ?, data_scad_dec1 = ? WHERE id_dec = ?">
            <DeleteParameters>
                <asp:Parameter Name="id_dec" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:QueryStringParameter Name="matricola" Type="Int32" QueryStringField="matr" />
                <asp:Parameter Name="dec1" Type="String" />
                <asp:Parameter Name="num_dec1" Type="String" />
                <asp:Parameter Name="ente_dec1" Type="String" />
                <asp:Parameter Name="dat_ril_dec1" Type="String" />
                <asp:Parameter Name="data_scad_dec1" Type="String" />
            </InsertParameters>
            <SelectParameters>
                
                <asp:ControlParameter ControlID="HF_matricola" Name="matricola" 
                    PropertyName="Value" Type="Int32" />
                
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="dec1" Type="String" />
                <asp:Parameter Name="num_dec1" Type="String" />
                <asp:Parameter Name="ente_dec1" Type="String" />
                <asp:Parameter Name="dat_ril_dec1" Type="String" />
                <asp:Parameter Name="data_scad_dec1" Type="String" />
                <asp:Parameter Name="id_dec" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="DS_siglaprv" runat="server" ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT sigla_prov FROM tbl_comuni ORDER BY sigla_prov"></asp:SqlDataSource>
    </div>
</asp:Content>
