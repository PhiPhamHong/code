<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormEditLabel.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormLabels.FormEditLabel" %>
<div class="form-horizontal">  
    <%= FormGroup.For(u => u.CompanyId, 3, 8).With<CompanyInput>(ip => ip.UseDefault(false)) %>
    <%= FormGroup.For(c=> c.Lexicon, 3, 8).WithInput() %>
    <%= FormGroup.For(c=> c.Description, 3, 8).WithInput() %>
</div>

<web:FormLanguage runat="server" />