<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuGroupHomeMain.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.MenuGroupHome.MenuGroupHomeMain" %>

<div data-rebuild="true" class="row" data-stt="1" data-1="col-xs-12">
    <div class="row row-menu" style="margin-bottom: 15px">
    <asp:Repeater runat="server" ID="rpRow" OnItemDataBound="rpRow_ItemDataBound">
        <ItemTemplate>
            <asp:Repeater runat="server" ID="rpGroup" OnItemDataBound="rpGroup_ItemDataBound">
                    <ItemTemplate>
                        <div class="col-md-3">
                            <div class="row">
                                <div class="col-xs-12"><h4 class="btn-social btn btn-block btn-flat <%# CssBgColorGroupMenu((GroupMenu)Container.DataItem) %>" style="<%# StyleBgColorGroupMenu((GroupMenu)Container.DataItem) %>"><i style="font-size: 13px !important" class="<%# Eval("Icon") %>"></i> <%# PortalContext.GetLabel(Eval("Name").ToString()) %></h4></div>
                            </div>
                            <asp:Repeater runat="server" ID="rpMenuItem" OnItemDataBound="rpMenuItem_ItemDataBound">
                                <ItemTemplate></ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
        </ItemTemplate>
    </asp:Repeater>
    </div>
</div>