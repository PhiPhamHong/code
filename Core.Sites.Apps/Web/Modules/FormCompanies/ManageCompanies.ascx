<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageCompanies.ascx.cs" Inherits="Core.Sites.Apps.Web.Modules.FormCompanies.ManageCompanies" %>
<div data-rebuild="true" class="row table-small" data-stt="1" data-1="col-xs-12">
    <div data-for-table="#table">
        <div class="form-inline row" data-search-toolbar="true">
            <%= this.InputKeyword(4, u => u.Name) %>
        </div>
        <web:ButtonSearch runat="server" />
    </div>
    <%= 
        Table.Key(c => c.CompanyId).EntityName("Công ty").PermissionAdd(Permission.Add).DefaultSort(1)
        .Col(c => c.For(t => t.Row, 55).TextCenter().Order(false))
        .Col(c => c.For(t => t.Name,300).TypeButton().Func(Edit).Permission(Permission.Edit, true))
        .Col(c => c.For(t => t.Address))
        .Col(c => c.For(t => t.Phone, 120).TextCenter())
        .Col(c => c.For(t => t.Website, 150))
        .Col(c => c.For(t => t.CompanyCode, 120).Text("Mã công ty").TextCenter())
        .Col(c => c.For(u => u.IsLock).TypeButton().Class("text-center").Permission(10).WhenTrue("Mở khóa").WhenFalse("Khóa").Style("width:80px").Confirm().Order(false))
        .Col(c => c.TypeButton().Icon("fas fa-trash-alt fa-2x").Class("text-center").Func(Delete).Text("Xóa").Permission(Permission.Delete).Confirm().Style("width:70px").Order(false))
    %>
</div>