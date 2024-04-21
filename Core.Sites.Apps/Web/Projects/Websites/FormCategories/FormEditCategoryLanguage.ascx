<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormEditCategoryLanguage.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormCategories.FormEditCategoryLanguage" %>
<div class="form-horizontal">
    <%= FormGroup.For(c=> c.Name, 3, 8).WithInput() %>
    <%= FormGroup.For(c=> c.Keyword, 3, 8).WithInput(ip => ip.TypeTextArea(0, 2)) %>
    <%= FormGroup.For(c=> c.Description, 3, 8).WithInput(ip => ip.TypeTextArea(0, 2)) %>
</div>