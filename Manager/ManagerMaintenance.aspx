<%@ Page Title="" Language="C#" MasterPageFile="~/Manager.master" AutoEventWireup="true" CodeFile="ManagerMaintenance.aspx.cs" Inherits="Manager_ManagerMaintenance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHContent" Runat="Server">
    <div id="content">
        <div id="manager-main-nav">
            <ul>
                <asp:LinkButton ID="lBtnManagerHome" runat="server" PostBackUrl="~/Manager/ManagerHome.aspx">Maintenance</asp:LinkButton>
                <asp:LinkButton ID="lBtnStartup" runat="server">System Startup</asp:LinkButton>
                <asp:LinkButton ID="lBtnShutdown" runat="server" PostBackUrl="~/Manager/ManagerSystemShutdown.aspx">System Shutdown</asp:LinkButton>
             </ul>
         </div>
        <h1>Manager ATM Maintenance mode</h1>
        <div id="manager-maint-main">
            Exchange Rate <asp:TextBox ID="exchangeRateLbl" runat="server"></asp:TextBox> <asp:Button ID="setRateBtn" runat="server" Text="Set Rate" OnClick="setRateBtn_Click" /> <asp:Label ID="errorLbl" runat="server"></asp:Label>
         </div>
        <div id="manager-maint-main">
            Times Used: <asp:Label ID="timesUsedLbl" runat="server"></asp:Label>
        </div>
        <div id="manager-maint-main">
            Withdrawals <asp:Label ID="withdrawalsLbl" runat="server"></asp:Label>
        </div>
        <div id="manager-maint-main">
            Total Balance <asp:Label ID="totalBalanceLbl" runat="server"></asp:Label>
        </div>
        <div id="manager-maint-main">
            Failed Logins <asp:Label ID="failedLoginsLbl" runat="server"></asp:Label>
        </div>
        <div id="manager-maint-main">
            Cards Retained <asp:Label ID="cardsRetainedLbl" runat="server"></asp:Label>
        </div>
        <div id="manager-maint-main">

        </div>
    </div>
</asp:Content>

