<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="matricole_old.aspx.vb" Inherits="GNAVBMForm.matricole_old" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <asp:Panel ID="Panel1" runat="server">
        <table style="width:800px;">
            <tr>
                <td style="text-align: center">
                    <asp:Button ID="Button3" runat="server" Text="Riassegna Matricola" OnClientClick = "Confirm()" Visible="False" />
                </td>
                <td style="text-align: center">
                    <asp:Button ID="Button4" runat="server" Text="Visualizza Socio" Visible="False" />
                </td>
                <td style="text-align: center">
                    <asp:Button ID="Button1" runat="server" Text="Visualizza Nuovo" Visible="False" />
                </td>
                <td style="text-align: center">
                    <asp:Button ID="Button2" runat="server" Text="Visualizza Vecchio" Visible="False" />
                </td>
            </tr>
            <tr>
                <td style="text-align: center" colspan="2">MATRICOLE DA RIASSEGNARE</td>
                <td colspan="2" style="text-align: center">MATRICOLE RIASSEGNATE</td>
            </tr>
            <tr>
                <td style="text-align: center; vertical-align: top;" colspan="2">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="DS_matr_da_sc" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="matricola">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="matricola" HeaderText="Matricola" InsertVisible="False" ReadOnly="True" SortExpression="matricola" />
                            <asp:BoundField DataField="cogn" HeaderText="Cognome" SortExpression="cogn" />
                            <asp:BoundField DataField="nom" HeaderText="Nome" SortExpression="nom" />
                        </Columns>
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
                    <br />
                    <asp:SqlDataSource ID="DS_matr_da_sc" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" 
                        SelectCommand="SELECT tbl_socio1.id_socio AS matricola, tbl_socio1.grado, tbl_socio1.com_app, tbl_socio1.prov_app, tbl_socio1.dat_iscr, tbl_socio1.Regione, tbl_socio1.cogn, tbl_socio1.nom, tbl_socio1.citt_res, tbl_socio1.via, tbl_socio1.num, tbl_socio1.cap, tbl_socio1.prov_res, tbl_socio1.cf, tbl_foto1.foto, tbl_socio1.dat_dim_g, tbl_socio1.dat_dim_s, tbl_socio1.data_espul, tbl_socio1.motivo_espul, tbl_telefono1.tel_c1, tbl_telefono1.tel_c2, tbl_telefono1.cell1, tbl_telefono1.cell2, tbl_telefono1.cell3, tbl_telefono1.tel_uff1, tbl_telefono1.tel_uff2, tbl_telefono1.fax1, tbl_telefono1.fax2 FROM tbl_socio1 INNER JOIN tbl_telefono1 ON tbl_socio1.id_tel = tbl_telefono1.id_tel INNER JOIN tbl_foto1 ON tbl_socio1.foto = tbl_foto1.id_fot WHERE reciclabile='True'">
                        
                    </asp:SqlDataSource>
                </td>
                <td colspan="2" style="text-align: center; vertical-align: top;">
                    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="DS_matr_scamb" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="matricola_old">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="matricola_old" HeaderText="Matricola" SortExpression="matricola_old" />
                            <asp:BoundField DataField="cogn" HeaderText="Vecchio Cognome" SortExpression="cogn" />
                            <asp:BoundField DataField="nom" HeaderText="Vecchio Nome" SortExpression="nom" />
                        </Columns>
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
                    <br />
                    <asp:SqlDataSource ID="DS_matr_scamb" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:GNA_ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:GNA_ConnectionString.ProviderName %>" 
                        SelectCommand="SELECT * FROM tbl_matricole_old ORDER BY matricola_old ASC"></asp:SqlDataSource>
                </td>
            </tr>
        </table>
    </asp:Panel>
    </div>
</asp:Content>
