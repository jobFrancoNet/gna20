<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="Accet.aspx.vb" Inherits="GNAVBMForm.Accet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    ACCETTAZIONE NUOVO SOCIO
        <asp:FormView ID="FormView1" runat="server" CellPadding="4" 
            DataSourceID="SqlDataSource1" ForeColor="#333333" DataKeyNames="id" 
            DefaultMode="Edit">
            <EditItemTemplate>
                matricola:
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("matricola") %>'></asp:Label>
                <br />
                <table style="width:100%;">
                    <tr>
                        <td>
                            Sede</td>
                        <td>
                            <asp:CheckBox ID="sedeCheckBox" runat="server" Checked='<%# Bind("sede") %>' Enabled="False" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Provincia</td>
                        <td>
                            <asp:CheckBox ID="provCheckBox" runat="server" Checked='<%# Bind("prov") %>' Enabled="False" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Regione</td>
                        <td>
                            <asp:CheckBox ID="regCheckBox" runat="server" Checked='<%# Bind("reg") %>' Enabled="False" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nazionale</td>
                        <td>
                            <asp:CheckBox ID="nazCheckBox" runat="server" Checked='<%# Bind("naz") %>' Enabled="False" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Presidenza</td>
                        <td>
                            <asp:CheckBox ID="presCheckBox" runat="server" Checked='<%# Bind("pres") %>' Enabled="False" />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Button ID="Button1" runat="server" CommandName="Update" 
                     Text="Aggiorna" onclick="Button1_Click" />
            </EditItemTemplate>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <InsertItemTemplate>
                matricola:
                <asp:TextBox ID="matricolaTextBox" runat="server" 
                    Text='<%# Bind("matricola") %>' />
                <br />
                sede:
                <asp:CheckBox ID="sedeCheckBox" runat="server" Checked='<%# Bind("sede") %>' />
                <br />
                com:
                <asp:CheckBox ID="comCheckBox" runat="server" Checked='<%# Bind("com") %>' />
                <br />
                prov:
                <asp:CheckBox ID="provCheckBox" runat="server" Checked='<%# Bind("prov") %>' />
                <br />
                reg:
                <asp:CheckBox ID="regCheckBox" runat="server" Checked='<%# Bind("reg") %>' />
                <br />
                naz:
                <asp:CheckBox ID="nazCheckBox" runat="server" Checked='<%# Bind("naz") %>' />
                <br />
                pres:
                <asp:CheckBox ID="presCheckBox" runat="server" Checked='<%# Bind("pres") %>' />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                    CommandName="Insert" Text="Inserisci" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                    CausesValidation="False" CommandName="Cancel" Text="Annulla" />
            </InsertItemTemplate>
            <ItemTemplate>
                id:
                <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
                <br />
                matricola:
                <asp:Label ID="matricolaLabel" runat="server" Text='<%# Bind("matricola") %>' />
                <br />
                sede:
                <asp:CheckBox ID="sedeCheckBox" runat="server" Checked='<%# Bind("sede") %>' 
                    Enabled="false" />
                <br />
                com:
                <asp:CheckBox ID="comCheckBox" runat="server" Checked='<%# Bind("com") %>' 
                    Enabled="false" />
                <br />
                prov:
                <asp:CheckBox ID="provCheckBox" runat="server" Checked='<%# Bind("prov") %>' 
                    Enabled="false" />
                <br />
                reg:
                <asp:CheckBox ID="regCheckBox" runat="server" Checked='<%# Bind("reg") %>' 
                    Enabled="false" />
                <br />
                naz:
                <asp:CheckBox ID="nazCheckBox" runat="server" Checked='<%# Bind("naz") %>' 
                    Enabled="false" />
                <br />
                pres:
                <asp:CheckBox ID="presCheckBox" runat="server" Checked='<%# Bind("pres") %>' 
                    Enabled="false" />
                <br />
            </ItemTemplate>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
        </asp:FormView>
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" 
            SelectCommand="SELECT * FROM tbl_accettazione1 WHERE (matricola = ?)" 
            UpdateCommand="UPDATE tbl_accettazione1 SET sede = ?, prov = ?, reg = ?, naz = ?, pres = ? WHERE id = ?">
            <SelectParameters>
                <asp:QueryStringParameter Name="matricola" QueryStringField="matr" 
                    Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="sede" Type="Object" />
                <asp:Parameter Name="prov" Type="Object" />
                <asp:Parameter Name="reg" Type="Object" />
                <asp:Parameter Name="naz" Type="Object" />
                <asp:Parameter Name="pres" Type="Object" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    
    </div>
</asp:Content>

