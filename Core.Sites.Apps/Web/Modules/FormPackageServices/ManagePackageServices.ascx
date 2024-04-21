<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManagePackageServices.ascx.cs" Inherits="Core.Sites.Apps.Web.Modules.FormPackageServices.ManagePackageServices" %>

<div data-rebuild="true" class="row" data-stt="1" data-1="col-xs-12">
    <%= 
        Table.Key(c => c.PackageServiceId).EntityName("Dịch vụ").PermissionAdd(12)
        .Col(c=> c.Field(t => t.Name).TypeButton().Func(Edit).Permission(13, true))
        .Col(c => c.TypeButton().Icon("fa fa-key").TextCenter().Url(UrlHelper.AssignPerPackageService).UrlParam(u => u.PackageServiceId).Text("Phân quyền").Permission(13).Style("width:100px").Order(false))
        .Col(c => c.TypeButton().Icon("fas fa-trash-alt fa-2x").TextCenter().Func(Delete).Text("Xóa").Permission(14).Confirm().Style("width:70px").Order(false))
    %>
</div>