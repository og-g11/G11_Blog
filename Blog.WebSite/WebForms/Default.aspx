<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/MainMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Blog.WebSite.WebForms.Default" %>
<%@ MasterType VirtualPath="~/Templates/MainMaster.Master" %>

<asp:Content ContentPlaceHolderID="contentMain" runat="server">
    Hello World
	
	<asp:Panel ID="pnlBlogList" Style="margin-left:30px; margin-right:30px; margin-top:20px" runat="server">
        <!-- blog list -->
    </asp:Panel>
</asp:Content>