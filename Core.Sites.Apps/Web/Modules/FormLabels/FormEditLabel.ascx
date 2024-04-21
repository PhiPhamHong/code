<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormEditLabel.ascx.cs" Inherits="Core.Sites.Apps.Web.Modules.FormLabels.FormEditLabel" %>

<div class="form-horizontal">
    <%= FormGroup.For(u => u.CompanyId, 3, 8).With<CompanyInput>(ip => ip.UseDefault(false)) %>
    <%= FormGroup.For(c=> c.Lexicon, 3, 8).WithInput() %>
    <%= FormGroup.For(c=> c.Description, 3, 8).WithInput() %>
</div>

<web:FormLanguage runat="server" />

<%--<div class="form-horizontal" style="margin-top: 20px">
    <%= FormGroup.LabelCol(3).LabelNull().InputCol(8).Checkbox(cb=> cb.Name(u=> u.ForAdmin).Inline(true)) %>
</div>--%>
<% if(Entity.CompanyId == AppSetting.CompanyFullPermission || Entity.IsSystem) %>
<% { %>
<div class="form-horizontal" style="margin-top: 20px">
<%= FormGroup.For(c => c.IsSystem, 3, 8).LabelNull().WithCheckbox(ck => ck.Inline(true).Enable(Entity.CompanyId == AppSetting.CompanyFullPermission)) %>
</div>
<% } %>