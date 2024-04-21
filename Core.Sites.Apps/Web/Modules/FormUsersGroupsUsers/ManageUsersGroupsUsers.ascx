<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageUsersGroupsUsers.ascx.cs" Inherits="Core.Sites.Apps.Web.Modules.FormUsersGroupsUsers.ManageUsersGroupsUsers" %>
<div data-rebuild="true" class="row table-small" data-stt="1" data-1="col-xs-12">

    <div data-for-table="#table">
        <div class="form-inline row" data-search-toolbar="true">
            <%= this.InputDate(2, "Date", "Ngày", ip => ip.Value(DateTime.Today)) %>
            <%= this.Select<ViewHistoryInput>(2, "ViewHistory") %> 
        </div>
        <web:ButtonSearch runat="server" />
    </div>
    <%= 
        Table.Key(c => c.GroupUserId).EntityName("Nhân viên").PermissionAdd(Permission.Add)
        .Col(c=> c.For(t => t.UserName).TypeButton().Func(Edit).Permission(Permission.Edit, true))
        .Col(c=> c.ForDate(t => t.FromDate, 120))
        .Col(c=> c.ForDate(t => t.ToDate, 120))
        .Col(c => c.TypeButton().Icon("fas fa-trash-alt fa-2x").Class("text-center").Func(Delete).Text("Xóa").Permission(Permission.Delete).Confirm().Style("width:70px").Order(false))
    %>
</div>