<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="CustomerViewBalance.aspx.cs" Inherits="Customer_CustomerViewBalance" %>

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
        <div id="top-nav">
            <ul>
            <asp:LinkButton ID="lBtnHome" runat="server" PostBackUrl="~/Customer/CustomerHome.aspx">Home</asp:LinkButton>
            <asp:LinkButton ID="lBtnBalance" runat="server" PostBackUrl="~/Customer/CustomerViewBalance.aspx">View Balance</asp:LinkButton>
            <asp:LinkButton ID="lBtnWithdraw" runat="server" PostBackUrl="~/Customer/CustomerWithdawal.aspx">Withdraw Cash</asp:LinkButton>
            </ul>
        </div>
        <ul>
            <li><asp:Label ID="customerNameLbl" runat="server"></asp:Label></li>
            <li><asp:Label ID="customerAccountLbl" runat="server"></asp:Label></li>
            <li><asp:Label ID="customerBalanceLbl" runat="server"></asp:Label></li>
        </ul>
        <table>
            <td><asp:LinkButton ID="removelbtn" runat="server" Width="100px" OnClick="removelbtn_Click">Remove Card</asp:LinkButton></td>
        </table>
    </div>
    </form>
</body>
</html>



