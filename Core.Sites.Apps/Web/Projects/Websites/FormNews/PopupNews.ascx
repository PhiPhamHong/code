<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PopupNews.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormNews.PopupNews" %>


<div data-rebuild="true" class="row" data-stt="1" data-1="col-xs-12">
    <div class="frm-search form-inline row" data-for-table="true"> 
        <%= this.InputKeyword(3, u => u.Title) %> 
        <%= this.Select<CategoryInput> (2, "CatId", ip => ip.CatType(0)) %>
        <%= this.Select<LanguageInput>(1.5f, "LanguageId", ip => ip.DisableSearch(true)) %>
        <web:ButtonSearch runat="server" />
    </div>

    <%= 
        Table.Key(c => c.NewsId).EntityName("Tin tức").PermissionAdd(-1)
        .Col(c => c.Field(t => t.NewsId).TypeCheckbox().Text("Chọn tin").TextCenter().Style("width:100px").Func("Choose"))        
        .Col(c => c.Field(t => t.DatePublished).FormatDate().TextCenter().Style("width:110px"))        
        .Col(c => c.Field(t => t.Title).TypeButton().Func("DoChoose"))        
    %>
</div>