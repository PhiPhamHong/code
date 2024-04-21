<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BoxLarge.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.DashBoards.BoxType.BoxLarge" %>
<div class="box <%= BoxClass %>">
    <div class="box-header <%= WithBorder ? "with-border" : "" %>">
        <i class="<%= UrlData.MenuItem.IconShow %>"></i>
        <h3 class="box-title"><%= DashBoardItem.Title %></h3>
        <div class="box-tools pull-right">
            <%--<button class="btn <%= ButtonClass %>" data-db-cmd="minus"><i class="fa fa-minus"></i></button>--%>
            <button class="btn <%= ButtonClass %>" data-db-cmd="reload"><i class="fas fa-sync-alt"></i></button>
            <button class="btn <%= ButtonClass %>" data-db-cmd="config"><i class="fa fa-wrench"></i></button>            
            <button class="btn <%= ButtonClass %>" data-db-cmd="remove"><i class="fa fa-times"></i></button>
        </div>
    </div>
    <div class="box-body" data-box-dashboard="content"></div>
</div>