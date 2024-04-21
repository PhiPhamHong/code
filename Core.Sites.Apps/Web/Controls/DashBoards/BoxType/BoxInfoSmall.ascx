<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BoxInfoSmall.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.DashBoards.BoxType.BoxInfoSmall" %>
<div class="info-box core-box-small <%= BoxClass %>">
    <div data-box-dashboard="content"></div>
    <div class="box-tools pull-right">        
        <button class="btn" data-db-cmd="reload"><i class="fas fa-sync-alt"></i></button>
        <button class="btn" data-db-cmd="config"><i class="fas fa-wrench"></i></button>
        <button class="btn" data-db-cmd="remove"><i class="fas fa-times"></i></button>
    </div>
</div>