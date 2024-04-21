<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BoxInfo2Small.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.DashBoards.BoxType.BoxInfo2Small" %>
<div class="info-box core-box-small <%= BoxClass %>">
    <div data-box-dashboard="content"></div>
    <div class="box-tools pull-right">        
        <button class="btn <%= ButtonClass %>" data-db-cmd="reload"><i class="fas fa-sync-alt"></i></button>
        <button class="btn <%= ButtonClass %>" data-db-cmd="config"><i class="fa fa-wrench"></i></button>
        <button class="btn <%= ButtonClass %>" data-db-cmd="remove"><i class="fa fa-times"></i></button>
    </div>
</div>