<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuGroupHomeMainItemLabel.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.MenuGroupHome.MenuGroupHomeMainItemLabel" %>
<span class="menu-item-count">
    <%= "<small class=\"label "+ (MenuItem.LabelCss.IsNull() ? "bg-green": MenuItem.LabelCss) +"\">"+ MenuItem.LabelText +"</small>" %>
</span>