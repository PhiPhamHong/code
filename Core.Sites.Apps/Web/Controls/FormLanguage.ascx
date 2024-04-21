<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormLanguage.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.FormLanguage" %>

<div class="nav-tabs-custom" style="margin-bottom:0px; box-shadow:none" data-form="languages">
    <ul class="nav nav-tabs">
        <asp:Repeater runat="server" ID="rpTabs">
            <ItemTemplate>
                <li<%# Container.ItemIndex == 0 ? " class=\"active\"" : "" %>><a href="#<%# Eval("Flag") %>_<%= random %>" data-toggle="tab"><%# Eval("Name") %></a></li> 
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    <div class="tab-content" style="padding-bottom:0px">
        <asp:Repeater runat="server" ID="rpContents" OnItemDataBound="rpContents_ItemDataBound">
            <ItemTemplate>
                <div data-form="entity-language-<%# Eval("LanguageId") %>" class='tab-pane<%# Container.ItemIndex == 0 ? " active" : "" %>' id="<%# Eval("Flag") %>_<%= random %>" style="position: relative;">
                    <asp:PlaceHolder runat="server" ID="plc"></asp:PlaceHolder>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>