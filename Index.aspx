<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Welcome.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="header"></div>

    <div id="content">
        <p>Welcome to your CoGB ATM. Please enter your username and PIN to enter.</p>
        <div id="login-area">
        <asp:RadioButtonList ID="rblChoose" runat="server"  RepeatDirection="Horizontal" 
            Font-Bold="True" Font-Size="1em" ForeColor="#80388D" AutoPostBack="True" 
            onselectedindexchanged="rblChoose_SelectedIndexChanged">
           <%-- <asp:ListItem>Customer</asp:ListItem>--%>
            <asp:ListItem>Manager</asp:ListItem>
            <asp:ListItem>Customer</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Login ID="Login1" runat="server" Font-Names="Verdana" Font-Size="1em" BackColor="#B9B8B8" Height="150px" 
            Width="360px" onauthenticate="Login1_Authenticate" PasswordLabelText="PIN">
        </asp:Login>
            </div>
       
    </div>
    </form>
</body>
</html>
