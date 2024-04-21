<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormAssignPermission.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.Common.FormAssignPermission" %>
<div class="box-group" id="accordion">
    <asp:Repeater runat="server" ID="rpMenuTop" OnItemDataBound="rpMenuTop_ItemDataBound">
        <ItemTemplate>
            <div class="panel box box-primary" style="box-shadow:none; margin-bottom: 0px">
                <div class="box-header with-border">
                    <div class="row">
                        <div class="col-xs-10"><h4 class="box-title"><a data-toggle="collapse" data-parent="#accordion" href="#collapse_<%# Container.ItemIndex %>" class="collapsed"><%# FromMenuItem(Container.DataItem) %></a></h4></div>
                        <div class="col-xs-10">
                            <%# Eval("Permission").ToString() == "0" ? string.Empty : RenderCheckbox(Eval("Permission").To<int>()) %>
                        </div>
                    </div>
                </div>
                <div id="collapse_<%# Container.ItemIndex %>" class="panel-collapse collapse">
                <asp:Repeater runat="server" ID="rpGroups" OnItemDataBound="rpGroups_ItemDataBound">
                    <HeaderTemplate>
                        <div class="box-body">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="row">
                            <div class="col-xs-12"><b style="display: block; margin-bottom: 5px;"><%# FromGroupMenu(Container.DataItem) %></b></div>
                        </div>
                        <asp:Repeater runat="server" ID="rpMenuItems" OnItemDataBound="rpMenuItems_ItemDataBound">
                            <ItemTemplate>
                                <div class="row row-per">
                                    <div class="col-sm-2"><a class="cur" data-type="button" data-func="ChooseAll"><i class="<%# Eval("Icon") %>"></i> <%# FromMenuItem(Container.DataItem) %></a></div>
                                    <div class="col-sm-10">
                                        <div class="row">
                                            <%# Eval("Permission").To<int>() == 0 ? string.Empty : "<div class=\"col-sm-1-5\">"+ RenderCheckbox(Eval("Permission").To<int>()) +"</div>" %>                                            
                                            <asp:Repeater runat="server" ID="rpPers">
                                                <ItemTemplate>
                                                    <div class="col-sm-1-5"><%# RenderCheckbox(Container.DataItem.To<int>()) %></div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>