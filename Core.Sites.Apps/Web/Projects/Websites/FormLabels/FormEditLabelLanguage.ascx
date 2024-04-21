<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormEditLabelLanguage.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormLabels.FormEditLabelLanguage" %>
<div class="form-horizontal">
    <%= FormGroup.For(c=> c.Value, 3, 8).WithInput() %>
</div>