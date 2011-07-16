<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Patient.aspx.cs" Inherits="Patient" %>

<asp:Content ContentPlaceHolderID="glPrimaryHeaderHolder" runat="server">
    
    <div>
        <div>
            <asp:Label ID="FullName" runat="server" CssClass="ui-label-big"></asp:Label>
        </div>
        <div style="background-color: #fbec88; margin-top: 5px; padding-left: 2px;">
            <asp:Label ID="BasicDemographics" runat="server"></asp:Label>
        </div>
    </div>

</asp:Content>

<asp:Content ContentPlaceHolderID="wsPrimaryNavigationHolder" runat="server"></asp:Content>

<asp:Content ContentPlaceHolderID="wsPrimaryContentHolder" runat="server">
</asp:Content>