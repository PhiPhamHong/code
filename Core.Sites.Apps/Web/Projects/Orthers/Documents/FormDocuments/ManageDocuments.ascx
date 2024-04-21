<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageDocuments.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Orthers.Documents.FormDocuments.ManageDocuments" %>
<div data-rebuild="true" class="row" data-stt="1" data-1="col-xs-12">
    <div data-for-table="#table">
        <div class="form-inline row" data-search-toolbar="true">
            <%= this.InputKeyword(2, u => u.DocumentTitle) %>
            <%= this.Select<LanguageInput>(1.5f, "LanguageId", ip => ip.DisableSearch(true)) %>
        </div>
        <web:ButtonSearch runat="server" />
    </div>

    <%= 
        Table.Key(c => c.DocumentId).EntityName("Tài liệu").PermissionAdd(Permission.Add).DefaultSort(2)
        .Col(c => c.For(t => t.DocumentTitle,250).TypeButton().Func(Edit).Permission(Permission.Edit, true).Order(false))
        
        .Col(c => c.Field(u => u.IsActive).TypeButton().TextCenter().Permission(Permission.Edit, true).WhenTrue("Bỏ hiển thị","glyphicon glyphicon-ok gi-2x").WhenFalse("Hiển thị","glyphicon glyphicon-remove gi-2x").Style("width:80px").Confirm().Order(false))

        .Col(c => c.ForDateTime(t => t.CreatedDate, 130))
        .Col(c => c.For(t => t.CreatedByUserName, 150).Order(false))
        .Col(c => c.ForDateTime(t => t.UpdatedDate, 130))
        .Col(c => c.For(t => t.UpdatedByUserName, 150).Order(false))
        
        .Col(c => c.TypeButton().Icon("fas fa-trash-alt fa-2x").Class("text-center").Func(Delete).Text("Xóa").Permission(Permission.Delete).Confirm().Style("width:50px").Order(false))
    %>
</div>
