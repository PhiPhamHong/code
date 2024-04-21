<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditBannerAddress.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormBanners.FormBannerAddress.EditBannerAddress" %>
<div class="form-horizontal" style="margin-top: 15px">
        <%= FormGroup.For(u => u.CompanyId, 2.5f, 5).With<CompanyInput>(ip => ip.UseDefault(false)) %>
        <%= FormGroup.For(c => c.Title, 2.5f, 9.5f).WithInput() %>
        <%= FormGroup.For(c => c.Description, 2.5f, 9.5f).WithInput(ip=>ip.TypeTextArea(3,4)) %>
        <%= FormGroup.For(c => c.Code, 2.5f, 9.5f).WithInput(ip=>ip.Enable(Entity == null || Entity.AddressId == 0)) %>

</div>