<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManagePartnerToWebs.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormPartnerToWebs.ManagePartnerToWebs" %>
<div data-rebuild="true" class="row" data-stt="1" data-1="col-xs-12">
    <div data-for-table="#table">
        <div class="form-inline row" data-search-toolbar="true">
            <%= this.InputCompany(1.5f) %>
        </div>
        <web:ButtonSearch runat="server" />
    </div>

    <%= 
        Table.Key(c => c.PnerId).EntityName("Đối tác").PermissionAdd(Permission.Add).DefaultSort(1)
        .Col(c => c.For(t => t.Logo, 60).FormatImage("30px", "30px", "").TextCenter())
        .Col(c => c.For(t => t.Name,120).TypeButton().Func(Edit).Permission(Permission.Edit))
        .Col(c => c.For(t => t.Des,150))
        .Col(c => c.For(t => t.Link,120))
        .Col(c => c.For(u => u.IsShow, 100).TypeButton().TextCenter().Permission(Permission.Edit).WhenTrue("Bỏ kích hoạt", "glyphicon glyphicon-ok gi-2x").WhenFalse("Kích hoạt", "glyphicon glyphicon-remove gi-2x").Style("width:80px").Confirm().Order(false))
        .Col(c => c.TypeButton().Icon("fas fa-trash-alt fa-2x").Class("text-center").Func(Delete).Text("Xóa").Permission(Permission.Delete).Confirm().Style("width:100px").Order(false))
    %>
</div>
