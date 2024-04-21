<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DashBoardCanUse.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.DashBoards.DashBoardCanUse" %>

<div data-rebuild="true" class="row" data-stt="1" data-1="col-xs-12">
    <%= 
        Table.Key(c => c.UrlVirtual).EntityName("Bảng tin chờ cấu hình").PermissionAdd(-1)
        .Col(c=> c.Field(t => t.Title).TypeButton().Func("ShowAddDashBoard"))
        .Col(c => c.TypeButton().Icon("fas fa-tachometer-alt").TextCenter().Func("ShowAddDashBoard").Text("Thiết lập điều khiển").Style("width:160px").Order(false))
    %>
</div>