<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageNotifications.ascx.cs" Inherits="Core.Sites.Apps.Web.Modules.FormNotification.ManageNotifications" %>
<div data-rebuild="true" class="row table-small" data-stt="1" data-1="col-xs-12">
    <div data-for-table="#table">
        <div class="form-inline row" data-search-toolbar="true">
            <%= FormGroup.Col(2).Input(ip => ip.Name(u => u.Name).PlaceHolder("Nhập từ khóa tìm kiếm")) %>
            <%= FormGroup.Col(1.5f).DatePicker(ip=> ip.Name("FromDate").Width("100%").PlaceHolder("Từ ngày")) %>
            <%= FormGroup.Col(1.5f).DatePicker(ip=> ip.Name("ToDate").Width("100%").EndDate().PlaceHolder("Đến ngày")) %>
        </div>
        <web:ButtonSearch runat="server" />
    </div>
    <%= 
        Table.Key(c => c.NotificationId).EntityName("Thông báo").PermissionAdd(Permission.Add)
        .Col(c => c.For(t => t.Name).TypeButton().Func(Edit).Permission(Permission.Edit, true))        
        .Col(c => c.ForDateTime(t => t.CreatedDate, 120))
        .Col(c => c.For(t => t.CreatedByUserName, 120))
        .Col(c => c.ForDateTime(t => t.UpdatedDate, 120))
        .Col(c => c.For(t => t.UpdatedByUserName, 120))
        .Col(c => c.TypeButton().Icon("fas fa-trash-alt fa-2x").Class("text-center").Func(Delete).Text("Xóa").Permission(Permission.Delete).Confirm().Style("width:70px").Order(false))
    %>
</div>