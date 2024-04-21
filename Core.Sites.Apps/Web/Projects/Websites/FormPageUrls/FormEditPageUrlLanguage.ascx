<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormEditPageUrlLanguage.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormPageUrls.FormEditPageUrlLanguage" %>
<div class="form-horizontal">
    <%= FormGroup.For(c=> c.VirtualUrl, 3, 8).WithInput() %>
    <%= FormGroup.For(c=> c.TemplateUrl, 3, 8).WithInput() %>
    <%= FormGroup.For(c=> c.PageTitle, 3, 8).WithInput() %>
    <%= FormGroup.For(c=> c.Keyword, 3, 8).WithInput(ip => ip.TypeTextArea(0, 2)) %>
    <%= FormGroup.For(c=> c.Description, 3, 8).WithInput(ip => ip.TypeTextArea(0, 2)) %>
</div>