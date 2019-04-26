<%@ Page Language="C#" MasterPageFile="~/Manager.master" AutoEventWireup="true" CodeFile="ManagerHome.aspx.cs" Inherits="Manager_ManagerHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHContent" Runat="Server">
    <div id="content">
        <h1>Manager ATM homepage</h1>
        <p>Please select an option below</p>
        <div id="manager-nav">
            <ul>
                <asp:LinkButton ID="lBtnStartup" runat="server" PostBackUrl="~/Index.aspx">System Startup</asp:LinkButton>
                <asp:LinkButton ID="lBtnMaintenance" runat="server" PostBackUrl="~/Manager/ManagerMaintenance.aspx">Maintenance</asp:LinkButton>
                <asp:LinkButton ID="lBtnShutdown" runat="server" PostBackUrl="~/Manager/ManagerSystemShutdown.aspx">System Shutdown</asp:LinkButton>
             </ul>
         </div>
        <p>The manager must startup the system before users can access the ATM. When the system is in maintenance mode or shutdown the users can no longer access the ATM.</p>
     </div>
</asp:Content>

