<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormEditBanners.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormBanners.FormBanners.FormEditBanners" %>

<div class="form-horizontal">
        <%= FormGroup.For(c => c.CompanyId, 2.5f, 4.5f).With<CompanyInput>(ip => ip.UseDefault(false)) %>
        <%= FormGroup.For(c => c.Address, 2.5f, 9.5f).With<Core.Sites.Apps.Web.Inputs.BannerAddressInput>(ip=>ip.CompanyId(PortalContext.CurrentUser.CurrentCompanyId)) %>
        <%= FormGroup.For(c => c.RelativeCode, 2.5f, 9.5f).WithInput() %>
        <%= FormGroup.For(c => c.Screen, 2.5f, 9.5f).With<Core.Sites.Apps.Web.Inputs.ScreenInput>(ip=>ip.Multiple(true)) %>
        <%= FormGroup.For(c => c.Picture, 2.5f, 9.5f).WithFileInput(ip=>ip.ShowImages(true,50,50)) %>
</div>
<web:FormLanguage runat="server" />