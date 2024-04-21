<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManagePageUrls.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormPageUrls.ManagePageUrls" %>
<div data-rebuild="true" class="row" data-stt="1" data-1="col-xs-12">
    <div data-for-table="#table">
        <div class="form-inline row" data-search-toolbar="true">
            <%= this.InputCompany(1.5f) %>
            <%= this.InputKeyword(2, u => u.Prefix) %>
            <%= this.Select<LanguageInput>(1.5f, "LanguageId", ip => ip.DisableSearch(true)) %>
        </div>
        <web:ButtonSearch runat="server" />
    </div>

    <%= 
        Table.Key(c => c.PageUrlId).EntityName("Cấu hình Url").PermissionAdd(Permission.Add)
        .Col(c=> c.For(t => t.WebsiteId, 60))
        .Col(c=> c.For(t => t.Prefix, 100).TypeButton().Func(Edit).Permission(Permission.Edit, true))
        .Col(c=> c.For(t => t.PageQuery, 150))        
        .Col(c=> c.For(t => t.VirtualUrl, 150))
        .Col(c=> c.For(t => t.RealUrl, 150))
        .Col(c=> c.For(t => t.TemplateUrl, 100))
        .Col(c=> c.For(t => t.PageTitle, 150))
        .Col(c => c.TypeButton().Icon("fas fa-trash-alt fa-2x").Class("text-center").Func(Delete).Text("Xóa").Permission(Permission.Delete).Confirm().Style("width:70px").Order(false))
    %>
</div>
