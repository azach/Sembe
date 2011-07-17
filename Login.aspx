<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Login" %>

<asp:Content ContentPlaceHolderID="glPrimaryHeaderHolder" runat="server">
</asp:Content>

<asp:Content ContentPlaceHolderID="wsPrimaryNavigationHolder" runat="server">
</asp:Content>

<asp:Content ContentPlaceHolderID="wsPrimaryContentHolder" runat="server">
    <form id="LoginForm" runat="server" enableviewstate="True">
    <asp:Login ID="login" runat="server" DestinationPageUrl="~/Default.aspx">
    </asp:Login>
    </form>
</asp:Content>