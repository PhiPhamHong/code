<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebManageLabels.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormLabels.WebManageLabels" %>
<div data-rebuild="true" class="row" data-stt="1" data-1="col-xs-12">
    <div data-for-table="#table">
        <div class="form-inline row" data-search-toolbar="true">
            <%= this.InputCompany(1.5f) %>
            <%= this.InputKeyword(1.5f, u => u.Lexicon) %>
            <%= this.Select<LanguageInput>(1.5f, "LanguageId", ip => ip.DisableSearch(true)) %>
            
        </div>
        <web:ButtonSearch runat="server" />
    </div>
    <div class="frm-search form-inline row" data-for-table="#table">
    </div>

    <%= 
        Table.Key(c => c.LabelId).EntityName("Từ vựng").PermissionAdd(Permission.Add)
        .Col(c=> c.For(t => t.Lexicon, 200).TypeButton().Func(Edit).Permission(Permission.Edit, true))
        .Col(c=> c.For(t => t.Description, 200)) 
        .Col(c=> c.For(t => t.Value, 500))
        .Col(c => c.TypeButton().Icon("fas fa-trash-alt fa-2x").Class("text-center").Func(Delete).Text("Xóa").Permission(Permission.Delete).Confirm().Style("width:70px").Order(false))
    %>
</div>
