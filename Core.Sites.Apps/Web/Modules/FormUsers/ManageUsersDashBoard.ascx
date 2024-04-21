<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageUsersDashBoard.ascx.cs" Inherits="Core.Sites.Apps.Web.Modules.FormUsers.ManageUsersDashBoard" %>

<div class="inner">
    <h3><asp:Literal runat="server" ID="ltrUsers"></asp:Literal></h3>
    <p><%= DashBoardItem.Title %></p>
</div>
<div class="icon">
    <i class="fas fa-user-check"></i>
</div>
<a href="<%= UrlHelper.GetUrl(DashBoardItem.Url) %>" data-state="true" class="small-box-footer"><%= PortalContext.GetLabel("Xem chi tiết") %> <i class="fas fa-arrow-circle-right"></i></a>