<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageMetas.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormMetas.ManageMetas" %>
<div data-rebuild="true" class="row" data-stt="1" data-1="col-xs-12">
    <div data-for-table="#table">
        <div class="form-inline row" data-search-toolbar="true">
            <%= this.InputCompany(1.5f) %>
            <%= this.InputKeyword(2, u => u.AttributeContent) %>
            <%= this.Select<LanguageInput>(1.5f, "LanguageId", ip => ip.DisableSearch(true)) %>
        </div>
        <web:ButtonSearch runat="server" />
    </div>
    

    <%= 
        Table.Key(c => c.MetaId).EntityName("Meta").PermissionAdd(Permission.Add)
        .Col(c=> c.Field(t => t.AttributeName).TypeButton().Func(Edit).Permission(Permission.Edit, true))
        .Col(c=> c.Field(t => t.AttributeValue))        
        .Col(c=> c.Field(t => t.AttributeMethodContent))
        .Col(c=> c.Field(t => t.AttributeContent))
        .Col(c => c.TypeButton().Icon("fas fa-trash-alt fa-2x").Class("text-center").Func(Delete).Text("Xóa").Permission(Permission.Delete).Confirm().Style("width:70px").Order(false))
    %>
</div>
