<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BoxSearch.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.BoxSearch" %>
<div class="row" style="margin-bottom: 10px">
    <div class="col-md-12">
        <div class="input-group adv-search" data-for-table="#table">
            <input type="text" class="form-control" name="<%= NameKey %>" data-text-search="main" placeholder="<%= PlaceHolder %>" />
            <div class="input-group-btn">
                <div class="btn-group" role="group">
                    <% if(ContentTemplate != null) %>
                    <% { %>
                    <div class="dropdown dropdown-lg">
                        <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><span class="caret"></span></button>
                        <div class="dropdown-menu dropdown-menu-right" role="menu">
                            <form class="form-horizontal" role="form" autocomplete="off" style="float:left; width:100%">
                                <div class="form-group "><label class="control-label"><%= PortalContext.GetLabel("Từ khóa") %></label><div><input class="form-control input-sm" name="<%= NameKey %>" placeholder="<%= PlaceHolder %>" type="text"></div></div>
                                <asp:PlaceHolder runat="server" ID="pclContent"></asp:PlaceHolder>
                                <button type="button" class="btn btn-primary" data-search-for-table="#table" style="float:right; border-bottom-left-radius: 4px; border-top-left-radius: 4px"><span class="glyphicon glyphicon-search" aria-hidden="true"></span></button>
                            </form>
                        </div>
                    </div>
                    <% } %>
                    <button type="button" class="btn btn-primary" data-search-for-table="#table"><span class="glyphicon glyphicon-search" aria-hidden="true"></span></button>
                </div>
            </div>
        </div>
    </div>
</div>
