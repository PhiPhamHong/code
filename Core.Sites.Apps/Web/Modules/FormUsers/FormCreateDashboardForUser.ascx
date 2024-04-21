<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormCreateDashboardForUser.ascx.cs" Inherits="Core.Sites.Apps.Web.Modules.FormUsers.FormCreateDashboardForUser" %>

<div class="form-horizontal form-no-pm">
    <%= FormGroup.For(u=> u.CompanyId, 3.5f, 7.5f).With<CompanyInput>(ip => ip.UseDefault(false)) %>
    <%= FormGroup.For(u=> u.UserId, 3.5f, 7.5f).With<UserInput>(ip => ip.UseDefault(false).TextDefault("-- Chọn người dùng --").Can()) %>
</div>