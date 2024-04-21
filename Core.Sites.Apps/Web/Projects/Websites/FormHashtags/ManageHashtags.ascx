<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageHashtags.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormHashtags.ManageHashtags" %>
<div data-rebuild="true" class="row" data-stt="1" data-1="col-xs-12">
    <div data-for-table="#table">
        <div class="form-inline row" data-search-toolbar="true">
            <%= this.InputCompany(1.5f) %>
            <%= this.InputKeyword(2, u => u.Name) %>
            <%= this.Select<LanguageInput>(1.5f, "LanguageId", ip => ip.DisableSearch(true)) %>
        </div>
        <web:ButtonSearch runat="server" />
    </div>
    

    <%= 
        Table.Key(c => c.HashtagId).EntityName("Hashtag").PermissionAdd(Permission.Add).DefaultSort(3)
        .Col(c => c.For(t => t.Row, 50).TextCenter().Order(false))
        .Col(c=> c.For(t => t.Name, 150).TypeButton().Func(Edit).Permission(Permission.Edit, true).Order(false).CreatedCell("cellColor"))
        .Col(c=> c.Field(t => t.Description).Order(false))
        .Col(c => c.ForDate(t => t.CreatedDate, 120))
        .Col(c => c.For(t => t.CreatedByUserName, 120).Order(false))
        .Col(c => c.ForDate(t => t.UpdatedDate, 120))
        .Col(c => c.For(t => t.UpdatedByUserName, 120).Order(false))


        .Col(c => c.For(u => u.IsActive, 100).TypeButton().TextCenter().Permission(Permission.Edit).WhenTrue("Bỏ kích hoạt", "fas fa-lock-open fa-2x").WhenFalse("Kích hoạt", "fas fa-lock fa-2x").Style("width:80px").Confirm().Order(false))
        .Col(c => c.TypeButton().Icon("fas fa-trash-alt fa-2x").Class("text-center").Func(Delete).Text("Xóa").Permission(Permission.Delete).Confirm().Style("width:70px").Order(false))
    %>
</div>
