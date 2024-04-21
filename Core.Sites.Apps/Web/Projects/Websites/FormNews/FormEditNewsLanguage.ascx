<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormEditNewsLanguage.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormNews.FormEditNewsLanguage" %>

<div class="form-horizontal">
    <div class="col-md-5">
        <%= FormGroup.For(c=> c.Title, 3f, 9f).WithInput() %>
        <%= FormGroup.For(c=> c.Sapo, 3f, 9f).WithInput(ip => ip.TypeTextArea(0, 2)) %>
        <%= FormGroup.For(c=> c.SapoShort, 3f, 9f).WithInput(ip => ip.TypeTextArea(0, 2)) %>
        <%= FormGroup.For(c=> c.Keyword, 3f, 9f).WithInput() %>
    </div>
    <div class="col-md-7">
        <%= FormGroup.LabelNull().For(c=> c.NewsContent, 0, 12).WithInput(ip => ip.TypeTextArea()) %>
    </div>
    
</div>
