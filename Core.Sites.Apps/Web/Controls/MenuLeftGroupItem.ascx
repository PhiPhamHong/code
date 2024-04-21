<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuLeftGroupItem.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.MenuLeftGroupItem" %>

<li class="treeview">
    <a href="javascript:void(0)"><i class="<%= GroupMenu.Icon.IsNull() ? "fa fa-files-o" : GroupMenu.Icon %>"></i> <span><%= PortalContext.GetLabel(GroupMenu.Name) %></span>
        <% if(GroupMenu.LabelText != "") %>
        <% { %>
        <span class="label <%= GroupMenu.LabelCss.IsNull() ? "label-primary" : GroupMenu.LabelCss %> pull-right"><%= GroupMenu.LabelText %></span>
        <% } %>
        <% else %>
        <% { %>
        <i class="fa fa-angle-left pull-right"></i>
        <% } %>
    </a>
    <ul class="treeview-menu">
        <asp:Repeater runat="server" ID="rpItem">
            <ItemTemplate>
                <li data-menu-url="<%# Eval("UrlVirtual") %>">
                    <a href="<%# Eval("Url") %>" title="<%# PortalContext.GetLabel(Eval("Title").ToString()) %>" data-state="true"><i class="<%# Eval("Icon").IsNull() ? "fa fa-circle-o" : Eval("Icon") %>"></i> <%# PortalContext.GetLabel(Eval("Title").ToString()) %> 
                        <%# Eval("LabelText").ToString() != "none" ? "<span class='label " + (Eval("LabelCss").IsNull() ? "label-primary" : Eval("LabelCss")) + " pull-right'>" + Eval("LabelText") + "</span>" : "" %>
                    </a>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</li>