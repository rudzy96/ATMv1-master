<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerWithdrawalReceipt.aspx.cs" Inherits="Customer_CustomerWithdrawalReceipt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="header"></div>
    
    <div id="content">
        <div id="top-nav">
            <ul>
            <asp:LinkButton ID="lBtnHome" runat="server" PostBackUrl="~/Customer/CustomerHome.aspx">Home</asp:LinkButton>
            <asp:LinkButton ID="lBtnBalance" runat="server">View Balance</asp:LinkButton>
            <asp:LinkButton ID="lBtnWithdraw" runat="server" PostBackUrl="~/Customer/CustomerWithdawal.aspx">Withdraw Cash</asp:LinkButton>
            </ul>
        </div>

        <p>Thank you for your transation please find your confirmation details below.</p>

        <table>
            <tr>
                <td>Name: <asp:Label ID="customerNamelbl" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Account No: <asp:Label ID="accountNolbl" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Withdrawn: <asp:Label ID="amountlbl" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Balance: <asp:Label ID="balancelbl" runat="server"></asp:Label></td>
            </tr>
        </table>

        <p>Thank you for using City of Glasgow Bank</p>

        <div id="btn"><asp:LinkButton ID="exitbtn" runat="server" Width="80px" OnClick="exitbtn_Click" >Exit</asp:LinkButton></div>
        
    </div>
    </form>
</body>
</html>
