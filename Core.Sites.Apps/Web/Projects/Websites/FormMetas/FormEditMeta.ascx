<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormEditMeta.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormMetas.FormEditMeta" %>
<div class="form-horizontal">
    <%= FormGroup.For(u => u.CompanyId, 3, 8).With<CompanyInput>(ip => ip.UseDefault(false)) %>
    <%= FormGroup.For(c=> c.AttributeName, 3, 8).WithInput() %>
    <%= FormGroup.For(c=> c.AttributeValue, 3, 8).WithInput() %>
    <%= FormGroup.For(c=> c.AttributeMethodContent, 3, 8).WithInput() %>
</div>

<web:FormLanguage runat="server" />