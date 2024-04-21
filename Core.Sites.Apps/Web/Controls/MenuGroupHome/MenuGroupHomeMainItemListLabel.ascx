<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuGroupHomeMainItemListLabel.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.MenuGroupHome.MenuGroupHomeMainItemListLabel" %>
<asp:Repeater runat="server" ID="rpLabels" OnItemDataBound="rpLabels_ItemDataBound">
    <HeaderTemplate>
        <span class="menu-item-count">
    </HeaderTemplate>
    <ItemTemplate>
        <%# "<small class=\"label "+ (Eval("BgColorCss").To<string>().IsNull() ? (MenuItem.LabelCss.IsNull() ? "bg-green" : MenuItem.LabelCss): Eval("BgColorCss")) +"\">"+ Eval("Text") +"</small>" %>
    </ItemTemplate>
    <FooterTemplate>
        </span>
    </FooterTemplate>
</asp:Repeater>