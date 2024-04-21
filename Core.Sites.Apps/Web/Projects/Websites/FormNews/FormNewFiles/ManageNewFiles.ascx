<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageNewFiles.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormNews.FormNewFiles.ManageNewFiles" %>
<div data-rebuild="true" class="row" data-stt="1" data-1="col-xs-12">
    <div data-for-table="#table">
        <div class="form-inline row" data-search-toolbar="true">
            <%= this.InputCompany(1.5f) %>
        </div>
        <web:ButtonSearch runat="server" />
    </div>
    <%= 
        Table.Key(c => c.FileId).EntityName("tài liệu đính kèm").PermissionAdd(Permission.Add).DefaultSort(1)
        .Col(c => c.For(t => t.Title, 150).TypeButton().Func(Edit).Permission(Permission.Edit, true))
        .Col(c => c.For(t => t.Path, 200))
        .Col(c => c.For(t => t.Note, 250))

        .Col(c => c.For(u => u.IsShow, 100).TypeButton().TextCenter().Permission(Permission.Edit).WhenTrue("Bỏ kích hoạt", "glyphicon glyphicon-ok gi-2x").WhenFalse("Kích hoạt", "glyphicon glyphicon-remove gi-2x").Style("width:80px").Confirm().Order(false))
        .Col(c => c.For(u => u.DownloadAllowed, 100).TypeButton().TextCenter().Permission(Permission.Edit).WhenTrue("Bỏ kích hoạt", "glyphicon glyphicon-ok gi-2x").WhenFalse("Kích hoạt", "glyphicon glyphicon-remove gi-2x").Style("width:80px").Confirm().Order(false))

        .Col(c=> c.For(t => t.Path,150).Text("Tải tệp").Class("file-download text-center").Style("width:90px").Order(false))

        .Col(c => c.TypeButton().Icon("fas fa-trash-alt fa-2x").Class("text-center")
        .Func(Delete).Text("Xóa").Permission(Permission.Delete).Confirm().Style("width:60px").Order(false))
    %>
</div>