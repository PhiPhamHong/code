<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormEditSeoLanguage.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormSeo.FormEditSeoLanguage" %>
<div class="form-horizontal">
    <%= FormGroup.For(c=> c.PageTitle, 2, 8).WithInput() %>
    <%= FormGroup.For(c=> c.Slogan, 2, 8).WithInput() %>
    <%= FormGroup.For(c=> c.Keyword, 2, 8).WithInput(ip => ip.TypeTextArea(0,2)) %>
    <%= FormGroup.For(c=> c.Description, 2, 8).WithInput(ip => ip.TypeTextArea(0,2)) %>
    <div class="col-md-6">
        <%= FormGroup.For(c=> c.Introduction, 0, 12).WithInput(ip => ip.TypeEditor(0, 10)) %>
    </div>
    <div class="col-md-6">
        <%= FormGroup.For(c=> c.Copyright, 0, 12).WithInput(ip => ip.TypeEditor(0, 10)) %>
    </div>
    
</div>