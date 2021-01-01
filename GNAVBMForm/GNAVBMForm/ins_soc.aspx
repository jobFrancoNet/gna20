<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="ins_soc.aspx.vb" Inherits="GNAVBMForm.ins_soc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <center><asp:Label ID="Label1" runat="server" Text="DOMANDA DI ISCRIZIONE" Font-Size="Large" Font-Bold="True" ForeColor="#0066FF"></asp:Label></center>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="DS_socio" 
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
            GridLines="None" HorizontalAlign="Center">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="id_socio" HeaderText="Matricola" />
                <asp:BoundField DataField="grado" HeaderText="Grado" />
                <asp:BoundField DataField="cogn" HeaderText="Cognome" />
                <asp:BoundField DataField="nom" HeaderText="Nome" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
           
        </asp:GridView>
        <br />
        
        <br />
        <center><asp:Label ID="Label2" runat="server" Text="COMPLETA LA REGISTRAZIONE" 
                Font-Bold="True" Font-Size="Larger" ForeColor="#0066FF"></asp:Label><br />
            <asp:Button ID="Button10" runat="server" Text="INVIO DOCUMENTI" Width="288px" />
            <br />
            <asp:Button ID="Button1" runat="server" Text="INSERISCI DECRETI" 
                Width="290px" />
            <br />
            <asp:Button ID="Button2" runat="server" Text="INSERISCI ARMI" Width="290px" />
            <br />
            <asp:Button ID="Button3" runat="server" Text="INSERISCI VEICOLO" 
                Width="290px" />
            <br />
            <asp:Button ID="Button4" runat="server" Text="INSERISCI NUCLEO FAMILIARE" Width="290px" />
            <br />
            <asp:Button ID="Button5" runat="server" Text="INSERISCI RICONOSCIMENTI" Width="290px" />
            <br />
            <asp:Button ID="Button6" runat="server" Text="INSERISCI ISTRUZIONE" Width="290px" />
            <br />
            <asp:Button ID="Button7" runat="server" Text="INSERISCI PROCEDIMENTI PENALI" Width="290px" />
            <br />
            <asp:Button ID="Button8" runat="server" Text="INSERISCI CONDANNE PENALI" Width="290px" />
            <br />
            <asp:Button ID="Button9" runat="server" Text="INSERISCI SETTORI" Width="290px" />
        </center>

        <asp:SqlDataSource ID="DS_socio" runat="server" 
            ConnectionString="<%$ ConnectionStrings:GNATEST_ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:GNATEST_ConnectionString.ProviderName %>" 
            
            SelectCommand="SELECT id_socio, grado, cogn, nom FROM tbl_socio1 WHERE (id_socio = ?)">
            <SelectParameters>
                <asp:ControlParameter ControlID="HiddenField1" Name="id_socio" 
                    PropertyName="Value" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
