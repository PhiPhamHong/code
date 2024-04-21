<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageBannerAddress.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormBanners.FormBannerAddress.ManageBannerAddress" %>
<div data-rebuild="true" class="row" data-stt="1" data-1="col-xs-12">
    <div data-for-table="#table">
        <div class="form-inline row" data-search-toolbar="true">
            <%= this.InputCompany(1.5f) %>
            <%= FormGroup.Col(1.5f).Input(ip=> ip.Name("Code").PlaceHolder("Tìm kiếm!")) %>
        </div>
        <web:ButtonSearch runat="server" />
    </div>

    <%= 
        Table.Key(c => c.AddressId).EntityName("Địa chỉ đặt banner").PermissionAdd(Permission.Add).DefaultSort(0)
        .Col(c => c.For(t => t.Title,120).TypeButton().Func(Edit).Permission(Permission.Edit))
        .Col(c => c.For(t => t.Description,150))
        .Col(c => c.For(t => t.Code,120))

        .Col(c => c.TypeButton().Icon("fas fa-trash-alt fa-2x").Class("text-center").Func(Delete).Text("Xóa").Permission(Permission.Delete).Confirm().Style("width:100px").Order(false))
    %>
</div>
