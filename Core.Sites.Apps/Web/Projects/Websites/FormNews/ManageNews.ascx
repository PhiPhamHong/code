<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageNews.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormNews.ManageNews" %>

<div data-rebuild="true" class="row" data-stt="1" data-1="col-xs-12">
    <div data-for-table="#table">
        <div class="form-inline row" data-search-toolbar="true">
            <%= this.InputCompany(1.5f) %>
            <%= this.InputKeyword(2, u => u.Title) %>
            <%= this.Select<CategoryInput> (1.5f, "CatId", ip => ip.CatType(Type).CompanyId(Provider.DataSource.CompanyId)) %>
            <%= this.Select<LanguageInput>(1.5f, "LanguageId", ip => ip.DisableSearch(true)) %>
        </div>
        <web:ButtonSearch runat="server" />
    </div>

    <%= 
        Table.Key(c => c.NewsId).EntityName("Tin tức").PermissionAdd(Permission.Add).DefaultSortDesc(0)
        .Col(c => c.Field(t => t.DatePublished).FormatDate().Style("width:110px"))   
        .Col(c => c.Field(t => t.Avatar).FormatImage("30px", "20px","").Style("width:120px").TextCenter())
        .Col(c => c.Field(t => t.Title).TypeButton().Func(Edit).Permission(Permission.Edit, true))
        .Col(c => c.Field(t => t.CategoryName).FormatSpanDot(150)) 
        .Col(c => c.Field(t => t.FullNameByUser).FormatSpanDot(150))
        .Col(c => c.Field(u => u.IsHot).TypeButton().TextCenter().Permission(0).WhenTrue("Bỏ hot","fa fa-dot-circle-o fa-2x").WhenFalse("Hot","fa fa-circle-o fa-2x").Style("width:80px").Confirm().Order(false))
        .Col(c => c.Field(u => u.IsActive).TypeButton().TextCenter().Permission(0).WhenTrue("Bỏ kích hoạt","fa fa-eye fa-2x").WhenFalse("Kích hoạt","fa fa-eye-slash fa-2x").Style("width:80px").Confirm().Order(false))
        .Col(c => c.TypeButton().Icon("fas fa-trash-alt fa-2x").Class("text-center").Func(Delete).Text("Xóa").Permission(Permission.Delete).Confirm().Style("width:50px").Order(false))
    %>
</div>
