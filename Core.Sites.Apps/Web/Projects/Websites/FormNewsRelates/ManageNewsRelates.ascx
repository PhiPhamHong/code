<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageNewsRelates.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormNewsRelates.ManageNewsRelates" %>
<div data-rebuild="true" class="row" data-stt="1" data-1="col-xs-12">
    <div data-for-table="#table">
        <div class="form-inline row" data-search-toolbar="true">
            <%= this.InputKeyword(3, u => u.Title) %>
            <%= this.Select<LanguageInput>(1.5f, "LanguageId", ip => ip.DisableSearch(true)) %>
        </div>
        <web:ButtonSearch runat="server" />
    </div>

    <%= 
        Table.Key(c => c.RelateId).EntityName("Tin tức liên quan").PermissionAdd(-1).DefaultSortDesc(0)
        .Col(c => c.Field(t => t.Title))
        .Col(c => c.TypeButton().Icon("fas fa-trash-alt fa-2x").Class("text-center").Func(Delete).Text("Xóa").Permission(0).Confirm().Style("width:50px").Order(false))
        .Bar(b => b.Icon("fa fa-plus-square").Func("AddNew").Text("Thêm mới").Permission(0))
    %>
</div>
