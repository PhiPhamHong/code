<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuGroupHomeMainItem.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.MenuGroupHome.MenuGroupHomeMainItem" %>
<div class="row" style="padding:2px 0px">
    <div class="col-xs-12">
        <a style="font-size:12px;padding-top: 7px" class="btn btn-block btn-social-vi bg-gray btn-flat" href="<%= MenuItem.Url %>" data-state="true">
            <i style="font-size:14px !important; line-height: 30px !important" class="<%= MenuItem.Icon %> <%= MenuItem.IconCssColor.IsNull() ? "text-icon-color-default": MenuItem.IconCssColor %>"></i> <%= PortalContext.GetLabel(MenuItem.Title) %>

            <asp:PlaceHolder runat="server" ID="plc"></asp:PlaceHolder>
        </a>
    </div>
</div>