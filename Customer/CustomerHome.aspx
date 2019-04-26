<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerHome.aspx.cs" Inherits="Customer_CustomerHome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="header">
    </div>
    <div id="content">
        <h1>Customer ATM homepage</h1>
        <p>Welcome to the City of Glasgow Bank. Please select an option below</p>
        <div id="manager-nav">
            <ul>
                <asp:LinkButton ID="lBtnViewBalance" runat="server" PostBackUrl="~/Customer/CustomerViewBalance.aspx">View Balance</asp:LinkButton>
                <asp:LinkButton ID="lBtnWithdrawal" runat="server" PostBackUrl="~/Customer/CustomerWithdawal.aspx">Withdraw Cash</asp:LinkButton>
             </ul>
         </div>
        <p>Thank you for using CoGB ATM.</p>
    </div>
    </form>
</body>
</html>
