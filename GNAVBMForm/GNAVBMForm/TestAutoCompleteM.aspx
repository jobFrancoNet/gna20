<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="TestAutoCompleteM.aspx.vb" Inherits="GNAVBMForm.TestAutoCompleteM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title>02 - Control IDs with Master Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<script type="text/javascript">
		$(document).ready(function () {
			//$('#txtBirthDate').datepicker();

			$('<%=String.Format("#{0}", txtFirstName.ClientID) %>').autocomplete({
            source: function(request, response) {
                $.ajax({
                    url: "WebLoadComune.asmx/LoadComuniFromJson",
                    data: "{ 'pattern': '" + request.term + "' }",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataFilter: function(data) { return data; },
                    success: function(data) {
                        response($.map(data.d, function(item) {
                            return { value: item }
                        }))
                    },
                    error: function(XMLHttpRequest, textStatus, errorThrown) {
                        alert(textStatus);
                    }
                });
            },
            minLength: 1    // MINIMUM 1 CHARACTER TO START WITH.
        });
		});
	</script>
	<p>
		With a Master Page, the control IDs are munged so the ASP.NET processor can walk
		the hierarchy.&nbsp; One method to work around this is to reference the ControlName.ClientId
		in an inline block of server code.&nbsp; This should work in every version since
		1.1.</p>
	<asp:Table ID="Table1" runat="server">
		<asp:TableRow>
			<asp:TableCell>
				<asp:Label runat="server" ID="lblFirstName" Text="First Name" />
			</asp:TableCell><asp:TableCell>
				<asp:TextBox ID="txtFirstName" runat="server">
				</asp:TextBox>
			</asp:TableCell></asp:TableRow><asp:TableRow>
			<asp:TableCell>
				<asp:Label runat="server" ID="lblLastName" Text="Last Name" />
			</asp:TableCell><asp:TableCell>
				<asp:TextBox ID="txtLastName" runat="server">
				</asp:TextBox>
			</asp:TableCell></asp:TableRow><asp:TableRow>
			<asp:TableCell>
				<asp:Label runat="server" ID="lblBirthDate" Text="Birth Date" />
			</asp:TableCell><asp:TableCell>
				<asp:TextBox ID="txtBirthDate" runat="server">
				</asp:TextBox>
			</asp:TableCell></asp:TableRow><asp:TableRow>
			<asp:TableCell>
				<asp:Label runat="server" ID="lblPhoneNumber" Text="Phone Number" />
			</asp:TableCell><asp:TableCell>
				<asp:TextBox ID="txtPhoneNumber" runat="server">
				</asp:TextBox>
			</asp:TableCell></asp:TableRow></asp:Table></asp:Content>