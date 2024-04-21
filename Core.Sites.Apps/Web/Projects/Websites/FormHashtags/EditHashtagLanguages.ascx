<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditHashtagLanguages.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormHashtags.EditHashtagLanguages" %>
<div class="form-horizontal">
    <%= FormGroup.For(c=> c.Name, 2.5f, 8).WithInput() %>
    <%= FormGroup.For(c=> c.Description, 2.5f, 8).WithInput() %>
</div>