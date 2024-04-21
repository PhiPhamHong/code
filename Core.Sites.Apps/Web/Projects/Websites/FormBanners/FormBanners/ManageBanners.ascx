<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageBanners.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormBanners.FormBanners.ManageBanners" %>
<div data-rebuild="true" class="row" data-stt="1" data-1="col-xs-12">
    <div data-for-table="#table">
        <div class="form-inline row" data-search-toolbar="true">
            <%= FormGroup.Col(1.5f).Input(ip=> ip.Name("Keyword").PlaceHolder("Nhập từ khóa tìm kiếm")) %>
            <%= this.InputCompany(1.5f) %>
            <%= FormGroup.Col(1.5f).With<LanguageInput>(ip => ip.Name("LanguageId").Value(PortalContext.DefaultLanguage).DisableSearch(true)) %>
        </div>
        <web:ButtonSearch runat="server" />
    </div>

    <%= 
        Table.Key(c => c.BannerId).EntityName("Banner quảng cáo").PermissionAdd(Permission.Add).DefaultSort(2)
        .Col(c => c.For(t => t.Row,50).TextCenter().Order(false))
        .Col(c => c.For(t => t.Picture, 50).FormatImage("40","40","").TextCenter().Order(false))
        .Col(c => c.For(t => t.Title, 250).TypeButton().Func(Edit).Permission(Permission.Edit, true))
        .Col(c => c.For(t => t.Address, 120))
        .Col(c => c.For(t => t.ScreenString).Order(false))
        .Col(c => c.For(t => t.URL, 300))
        .Col(c => c.For(t => t.RelativeCode, 150))
        .Col(c => c.TypeButton().Icon("fas fa-trash-alt fa-2x").Class("text-center").Func(Delete).Text("Xóa").Permission(Permission.Delete).Confirm().Style("width:70px").Order(false))
    %>
</div>
