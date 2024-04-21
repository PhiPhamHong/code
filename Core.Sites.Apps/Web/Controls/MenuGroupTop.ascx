<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuGroupTop.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.MenuGroupTop" %>
<asp:Repeater runat="server" ID="rpMulti" OnItemDataBound="rpMulti_ItemDataBound">
    <HeaderTemplate>
        <div class="bg-white py-2 collapse-inner rounded">
    </HeaderTemplate>
    <ItemTemplate>
        <h6 class="collapse-header"> <i class="<%# Eval("Icon").IsNull() ? "fa fa-circle-o" : Eval("Icon") %>"></i> <span><%# FromGroupMenu(Container.DataItem) %></span> </h6>
            <asp:Repeater runat="server" ID="rpItem">
                <ItemTemplate>
                    <a class="collapse-item" href="<%# Eval("Url") %>"> <i class="<%# Eval("Icon").IsNull() ? "fa fa-circle-o" : Eval("Icon") %>"></i> <span><%# FromMenuItem(Container.DataItem) %> </span> </a>
                </ItemTemplate>
            </asp:Repeater>
    </ItemTemplate>
    <FooterTemplate>
        </div>
    </FooterTemplate>
</asp:Repeater>

<asp:Repeater runat="server" ID="rpOne">
    <HeaderTemplate>
        <div class="bg-white py-2 collapse-inner rounded">
    </HeaderTemplate>
    <ItemTemplate>
        <a class="collapse-item" href="<%# Eval("Url") %>"> <i class="<%# Eval("Icon").IsNull() ? "fa fa-circle-o" : Eval("Icon") %>"></i> <span><%# FromMenuItem(Container.DataItem) %> </span> </a>
    </ItemTemplate>
    <FooterTemplate>
        </div>
    </FooterTemplate>
</asp:Repeater>