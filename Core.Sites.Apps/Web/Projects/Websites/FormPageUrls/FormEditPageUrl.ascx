<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormEditPageUrl.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormPageUrls.FormEditPageUrl" %>
<div class="form-horizontal">
    <%= FormGroup.For(u => u.CompanyId, 3, 8).With<CompanyInput>(ip => ip.UseDefault(false)) %>
    <%= FormGroup.For(c=> c.WebsiteId, 3, 3).WithInput(ip=>ip.IsNumeric()) %>
    <%= FormGroup.For(c=> c.Prefix, 3, 8).WithInput() %>
    <%= FormGroup.For(c=> c.PageQuery, 3, 8).WithInput() %>
    <%= FormGroup.For(c=> c.RealUrl, 3, 8).WithInput() %>
</div>

<web:FormLanguage runat="server" />

<div class="form-horizontal" style="margin-top: 20px">
    <%= FormGroup.For(c => c.Match, 3, 8).LabelNull()
            .WithCheckbox(cb => cb.Inline(true))
            .Checkbox(cb => cb.Name(c => c.Indirect).Inline(true)) %>
</div>