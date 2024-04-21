<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BoxSmall.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.DashBoards.BoxType.BoxSmall" %>
<div class="core-box-small">
    <div data-box-dashboard="content" class="small-box <%= BoxClass %>"></div>
    <div class="box-tools pull-right">
        <button class="btn <%= ButtonClass %>" data-db-cmd="reload"><i class="fas fa-sync-alt"></i></button>
        <button class="btn <%= ButtonClass %>" data-db-cmd="config"><i class="fas fa-wrench"></i></button>
        <button class="btn <%= ButtonClass %>" data-db-cmd="remove"><i class="fas fa-times"></i></button>
    </div>
</div>