<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TestAutocomplete.aspx.vb" Inherits="GNAVBMForm.TestAutocomplete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css"/>
 <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
 <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script>
</head>
<script type="text/javascript">
    $(document).ready(function() {
       BindControls();
       
    });

    function BindControls() {
        //var Countries = ["ARGENTINA", "AUSTRALIA", "BRAZIL", "BELARUS", "BHUTAN", "CHILE"];

        // BIND ARRAY OF STRINGS WITH AUTOCOMPLETE FUNCTION.
       // $("#tbCountries").autocomplete({ source: Countries });

        $("#tbListOfCountries").autocomplete({
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

    }
</script>
<body>
     
    <form id="form1" runat="server">
        <div>
       <asp:TextBox value="" runat="server" id="tbListOfCountries" OnTextChanged="tbListOfCountries_TextChanged" />
            <br />
        <asp:Label ID="provincia" runat="server" Text="" />
    </div>
    </form>
</body>
</html>
