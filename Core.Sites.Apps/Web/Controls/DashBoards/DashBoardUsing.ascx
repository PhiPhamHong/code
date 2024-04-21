<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DashBoardUsing.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.DashBoards.DashBoardUsing" %>

<div data-rebuild="true" class="row" data-stt="1" data-1="col-xs-12">
    <%= 
        Table.Key(c => c.Id).EntityName("Bảng tin đang cấu hình").PermissionAdd(-1)
        .Col(c=> c.Field(t => t.Stt).Style("width:70px").TextCenter())
        .Col(c=> c.Field(t => t.Title).TypeButton().Func("EditDashBoard"))
        .Col(c => c.TypeButton().Icon("fas fa-trash-alt").Class("text-center").Func(Delete).Text("Xóa").Permission(0).Confirm().Style("width:70px").Order(false))
    %>
</div>