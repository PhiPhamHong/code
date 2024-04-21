<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DashBoardMainTabs.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.DashBoards.DashBoardMainTabs" %>

<div class="nav-tabs-custom" style="margin-bottom:0px;box-shadow:none;background:none">
    <ul class="nav nav-tabs" data-tabs="db-tabs" style="border-bottom:none">
        <asp:Repeater runat="server" ID="rpTabs">
            <ItemTemplate>
                <li><a href="#tab_<%# Eval("DashBoardTabId") %>_<%= random %>" data-db-tab-id="<%# Eval("DashBoardTabId") %>" data-toggle="tab" data-module="DashBoardMain" data-customer-data="tab_CustomerData" data-before-init="tab_BeforeInit"><%# Eval("TabName") %></a></li> 
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    <div class="tab-content" style="background:none; padding-left: 0px; padding-right: 0px">
        <asp:Repeater runat="server" ID="rpContents">
            <ItemTemplate>
                <div class='tab-pane' id="tab_<%# Eval("DashBoardTabId") %>_<%= random %>" style="position: relative;">
                    <asp:PlaceHolder runat="server" ID="plc"></asp:PlaceHolder>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>