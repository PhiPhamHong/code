<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuLeft.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.MenuLeft" %>

<ul class="sidebar-menu">
    <%--<li class="header">Chức năng</li>--%>
    <asp:Repeater runat="server" ID="rpMenu" OnItemDataBound="rpMenu_ItemDataBound">
        <ItemTemplate>
            <asp:PlaceHolder runat="server" ID="plc"></asp:PlaceHolder>
        </ItemTemplate>
    </asp:Repeater>
</ul>