<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageNewContents.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormNews.FormNewContents.ManageNewContents" %>
<div data-rebuild="true" class="row" data-stt="1" data-1="col-xs-12">
    <div data-for-table="#table">
        <div class="form-inline row" data-search-toolbar="true">
            <%= this.InputCompany(1.5f) %>
            <%= this.InputKeyword(2, u => u.Title) %>
            <%= this.Select<CategoryInput> (1.5f, "CatId", ip => ip.CatType(Core.Business.Entities.Websites.Category.Type.News).CompanyId(Provider.DataSource.CompanyId)) %>
            <%= this.Select<LanguageInput>(1.5f, "LanguageId", ip => ip.DisableSearch(true)) %>
        </div>
        <web:ButtonSearch runat="server" />
    </div>

    <%= 
        Table.Key(c => c.NewsId).EntityName("Tin tức").PermissionAdd(Permission.Add).DefaultSort(4)
        .Col(c => c.For(t => t.Row,60).Order(false))   
        .Col(c => c.For(t => t.Title,250).TypeButton().Func(Edit).Permission(Permission.Edit, true))

        .Col(c => c.For(t => t.Sapo,200)) 
        .Col(c => c.For(t => t.Keyword,200)) 

        .Col(c => c.ForDateTime(t => t.CreatedDate, 130))
        .Col(c => c.For(t => t.CreatedByUserName, 150).Order(false))
        .Col(c => c.ForDateTime(t => t.UpdatedDate, 130))
        .Col(c => c.For(t => t.UpdatedByUserName, 150).Order(false))
        
        .Col(c => c.TypeButton().Icon("fas fa-trash-alt fa-2x").Class("text-center").Func(Delete).Text("Xóa").Permission(Permission.Delete).Confirm().Style("width:50px").Order(false))
    %>
</div>
