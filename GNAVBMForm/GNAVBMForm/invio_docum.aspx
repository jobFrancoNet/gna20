<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="invio_docum.aspx.vb" Inherits="GNAVBMForm.invio_docum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    
        <h1 class="auto-style4">INVIO DOCUMENTAZIONE</h1>
        <p class="auto-style3">Attenzione: devono essere caricati soltanto documenti digitalizzati in formato PDF. Detta documentazione è elemento imprescindibile per la convalida dell&#39;anagrafica e per il rilascio della tessera di servizio.</p>
        <p class="auto-style3">
            <table style="width: 450px;">
                <tr>
                    <td>TIPO DOCUMENTO</td>
                    <td>&nbsp;DOCUMENTO PDF</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Domanda Iscrizione</asp:ListItem>
                <asp:ListItem>Codice Fiscale</asp:ListItem>
                <asp:ListItem>Documento Identità</asp:ListItem>
            </asp:DropDownList></td>
                    <td><asp:FileUpload ID="FileUpload1" runat="server" /></td>
                    <td><asp:Button ID="Button1" runat="server" Text="INVIO" /></td>
                </tr>
                <tr>
                    <td colspan="3">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Tipo Documento obbligatorio" ForeColor="Red" ControlToValidate="DropDownList1"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Documento PDF obbligatorio" ControlToValidate="FileUpload1" ForeColor="Red"></asp:RequiredFieldValidator></td>
                </tr>
            </table>
            <% If (ConfigurationManager.AppSettings("DB").Equals("PRODUZIONE")) Then %>
&nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" 
    SelectCommand="SELECT * FROM tbl_documentazione WHERE (matricola = ?)" 
    DeleteCommand="DELETE FROM tbl_documentazione WHERE id_docum = ?" 
    InsertCommand="INSERT INTO tbl_documentazione (id_docum, matricola, url_docum, tipo_docum) VALUES (?, ?, ?, ?)" 
    UpdateCommand="UPDATE tbl_documentazione SET matricola = ?, url_docum = ?, tipo_docum = ? WHERE id_docum = ?">
                <DeleteParameters>
                    <asp:Parameter Name="id_docum" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="id_docum" Type="Int32" />
                    <asp:Parameter Name="matricola" Type="Int32" />
                    <asp:Parameter Name="url_docum" Type="String" />
                    <asp:Parameter Name="tipo_docum" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:QueryStringParameter Name="matricola" QueryStringField="matr" Type="Int32" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="matricola" Type="Int32" />
                    <asp:Parameter Name="url_docum" Type="String" />
                    <asp:Parameter Name="tipo_docum" Type="String" />
                    <asp:Parameter Name="id_docum" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
    <%End If  %>

        <% If (ConfigurationManager.AppSettings("DB").Equals("TEST")) Then %>
&nbsp;<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GNATEST_ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:GNATEST_ConnectionString.ProviderName %>" 
    SelectCommand="SELECT * FROM tbl_documentazione WHERE (matricola = ?)" 
    DeleteCommand="DELETE FROM tbl_documentazione WHERE id_docum = ?" 
    InsertCommand="INSERT INTO tbl_documentazione (id_docum, matricola, url_docum, tipo_docum) VALUES (?, ?, ?, ?)" 
    UpdateCommand="UPDATE tbl_documentazione SET matricola = ?, url_docum = ?, tipo_docum = ? WHERE id_docum = ?">
                <DeleteParameters>
                    <asp:Parameter Name="id_docum" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="id_docum" Type="Int32" />
                    <asp:Parameter Name="matricola" Type="Int32" />
                    <asp:Parameter Name="url_docum" Type="String" />
                    <asp:Parameter Name="tipo_docum" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:QueryStringParameter Name="matricola" QueryStringField="matr" Type="Int32" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="matricola" Type="Int32" />
                    <asp:Parameter Name="url_docum" Type="String" />
                    <asp:Parameter Name="tipo_docum" Type="String" />
                    <asp:Parameter Name="id_docum" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
    <%End If  %>

            <% If (ConfigurationManager.AppSettings("DB").Equals("PRODUZIONE")) Then %>
            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="id_docum">
                <Columns>
                    <asp:BoundField DataField="id_docum" HeaderText="id_docum" InsertVisible="False" ReadOnly="True" SortExpression="id_docum" Visible="False" />
                    <asp:BoundField DataField="matricola" HeaderText="Matricola" SortExpression="matricola" />
                    <asp:TemplateField HeaderText="Documento" SortExpression="url_docum">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("url_docum") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# strFile + Eval("url_docum")%>' Target="_blank" Text='<%# Eval("url_docum") %>'></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="tipo_docum" HeaderText="Tipo Documento" SortExpression="tipo_docum" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <%End IF %>
             <% If (ConfigurationManager.AppSettings("DB").Equals("TEST")) Then %>
            <asp:GridView ID="GridView2" runat="server" AllowSorting="True" DataSourceID="SqlDataSource2" AutoGenerateColumns="False" DataKeyNames="id_docum">
                <Columns>
                    <asp:BoundField DataField="id_docum" HeaderText="id_docum" InsertVisible="False" ReadOnly="True" SortExpression="id_docum" Visible="False" />
                    <asp:BoundField DataField="matricola" HeaderText="Matricola" SortExpression="matricola" />
                    <asp:TemplateField HeaderText="Documento" SortExpression="url_docum">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("url_docum") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# strFile + Eval("url_docum")%>' Target="_blank" Text='<%# Eval("url_docum") %>'></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="tipo_docum" HeaderText="Tipo Documento" SortExpression="tipo_docum" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <%End IF %>
            <br />
        </p>
    
    </div>
</asp:Content>
