<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageLabels.ascx.cs" Inherits="Core.Sites.Apps.Web.Modules.FormLabels.ManageLabels" %>
<div data-rebuild="true" class="row table-small" data-stt="1" data-1="col-xs-12">
    <div data-for-table="#table">
        <div class="form-inline row" data-search-toolbar="true">
            <%= this.InputKeyword(1.5f, u => u.Lexicon) %>
            <%= this.InputCompany(2) %>
            <%= this.Select<LanguageInput>(1.5f, "LanguageId", ip => ip.Value(PortalContext.DefaultLanguage).DisableSearch(true)) %>
        </div>
        <web:ButtonSearch runat="server" />
    </div>
    <%= 
        Table.Key(c => c.LabelId).EntityName("Từ vựng").PermissionAdd(Permission.Add).DefaultSort(1)
        .Col(c => c.For(t => t.Row, 55).TextCenter().Order(false))
        .Col(c=> c.Field(t => t.Lexicon).CreatedCell("createdCell").TypeButton().Func(Edit).Permission(Permission.Edit, true))
        .Col(c=> c.Field(t => t.Description)) 
        .Col(c=> c.Field(t => t.Value))
        .Col(c => c.TypeButton().Icon("fas fa-trash-alt fa-2x").Class("text-center")
        .Func(Delete).Text("Xóa").Permission(Permission.Delete).Confirm().Style("width:70px").Order(false))
    %>
</div>