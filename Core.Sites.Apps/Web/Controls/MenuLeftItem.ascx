<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuLeftItem.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.MenuLeftItem" %>

<li data-menu-url="<%= MenuItem.UrlVirtual %>">
    <a href="<%= MenuItem.Url %>" data-state="true" title="<%= MenuItem.Title %>"><i class="<%= MenuItem.Icon %>"></i> <span><%= PortalContext.GetLabel(MenuItem.Title) %></span> 
        <% if(MenuItem.LabelText != "") %><% { %> <small class="label <%= MenuItem.LabelCss.IsNull() ? "bg-green" : MenuItem.LabelCss %> pull-right"><%= MenuItem.LabelText %></small> <% } %>
    </a>
</li>