<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerWithdawal.aspx.cs" Inherits="Customer_CustomerWithdawal" %>

<!DOCTYPE html>

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
            <asp:LinkButton ID="lBtnWithdraw" runat="server">Withdraw Cash</asp:LinkButton>
            </ul>
        </div>
        <p>Please select the amount you would like to withdraw from your account.</p>
        <table>
            <tr>
                <td>Currency</td>
                <td><asp:RadioButtonList ID="currencyrbl" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" Height="20px">
                <asp:ListItem>Sterling (£)</asp:ListItem>
                <asp:ListItem>Euro (€)</asp:ListItem>
                </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td>Amount</td>
                <td>
                    <asp:RadioButtonList ID="amountrbl" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="20">20</asp:ListItem>
                        <asp:ListItem Value="30">30</asp:ListItem>
                        <asp:ListItem Value="40">40</asp:ListItem>
                        <asp:ListItem Value="50">50</asp:ListItem>
                        <asp:ListItem Value="100">100</asp:ListItem>
                        <asp:ListItem Value="150">150</asp:ListItem>
                        <asp:ListItem Value="200">200</asp:ListItem>
                        <asp:ListItem Value="250">250</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            </table>
            
        <p>Enter Other Amount: <asp:TextBox ID="amounttxt" runat="server"></asp:TextBox> <asp:Label ID="amountErrorlbl" runat="server"></asp:Label> <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="amounttxt" Type="Integer" MinimumValue="0" MaximumValue="250" ErrorMessage="Amount entered must a multiple of 10 upto £250"></asp:RangeValidator></p>

        <table>
            <tr>
                <td><asp:LinkButton ID="withdrawlbtn" runat="server" OnClick="withdrawlbtn_Click">Withdraw Cash</asp:LinkButton></td>
                <td><asp:LinkButton ID="removelbtn" runat="server" Width="100px" OnClick="removelbtn_Click">Remove Card</asp:LinkButton></td>
                <td>
                    <asp:CheckBox ID="receiptChkbx" runat="server" Text="View Receipt"/></td>    
            </tr>
            <tr>
                <td><asp:Label ID="withdrawErrorlbl" runat="server"></asp:Label></td>
            </tr>
        </table>
        
        </div>
    </form>
</body>
</html>
