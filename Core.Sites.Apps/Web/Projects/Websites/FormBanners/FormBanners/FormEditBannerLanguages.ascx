<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormEditBannerLanguages.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormBanners.FormBanners.FormEditBannerLanguages" %>
<div class="form-horizontal">
      <%= FormGroup.For(c => c.Title, 2.5f, 9.5f).WithInput() %>
      <%= FormGroup.For(c => c.URL, 2.5f, 9.5f).WithInput() %>
</div>