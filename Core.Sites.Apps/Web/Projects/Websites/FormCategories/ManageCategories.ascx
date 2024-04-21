<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageCategories.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormCategories.ManageCategories" %>
<div data-rebuild="true" class="row" data-stt="1" data-1="col-xs-12">
    <div data-for-table="#table">
        <div class="form-inline row" data-search-toolbar="true">
            <%= this.InputCompany(1.5f) %>
            <%= this.InputKeyword(1.5f, u => u.Name) %>
            <%= this.Select<LanguageInput>(1.5f, "LanguageId", ip => ip.DisableSearch(true)) %>
        </div>
        <web:ButtonSearch runat="server" />
    </div>


    <%= 
        Table.Key(c => c.CatId).EntityName("Chuyên mục").PermissionAdd(Permission.Add)   
        .Col(c => c.Field(t => t.Stt).TypeTextEdit().Style("width: 70px"))
        .Col(c => c.Field(t => t.Avatar).FormatImage("80px","40px","").Style("width:82px").TextCenter())
        .Col(c => c.For(t => t.Name, 300).TypeButton().Func(Edit).Permission(Permission.Edit, true))
        .Col(c => c.For(t => t.Keyword, 300).TypeButton().Func(Edit).Permission(Permission.Edit, true))
        .Col(c => c.Field(t => t.Description).TypeButton().Func(Edit).Permission(Permission.Edit, true))
        
        .Col(c => c.Field(u => u.IsActive).TypeButton().TextCenter().Permission(0).WhenTrue("Bỏ kích hoạt","fa fa-eye fa-2x").WhenFalse("Kích hoạt","fa fa-eye-slash fa-2x").Style("width:80px").Confirm().Order(false))
        .Col(c => c.TypeButton().Icon("fas fa-trash-alt fa-2x").Class("text-center").Func(Delete).Text("Xóa").Permission(Permission.Delete).Confirm().Style("width:70px").Order(false))
    %>
</div>
