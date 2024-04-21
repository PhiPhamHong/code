<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageDashboardTabs.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.DashBoards.ManageDashboardTabs" %>
<div data-rebuild="true" class="row" data-stt="1" data-1="col-xs-12">
    <%= 
        Table.Key(u=> u.DashBoardTabId).EntityName("Bảng tin").PermissionAdd(0)
        .Col(c => c.For(t => t.Row, 60).TextCenter().Order(false))
        .Col(c => c.Field(u => u.TabName).TypeButton().Func(Edit).Permission(0, true))
        .Col(c => c.Field(u => u.Stt).TypeTextEdit().Style("width:100px"))
        .Col(c => c.TypeButton().Icon("fas fa-trash-alt fa-1x5").TextCenter().Func(Delete).Text("Xóa").Permission(0).Confirm().Style("width:60px").Order(false))
    %>
</div>