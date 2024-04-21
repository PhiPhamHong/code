<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormUserUpdateConfigRuntime.ascx.cs" Inherits="Core.Sites.Apps.Web.Modules.FormUsers.FormUserUpdateConfigRuntime" %>
<div class="form-horizontal">
    <%= FormGroup.For(u => u.TimeForLabelMenuItem, 3, 8).With<TimeForLabelMenuItemInput>() %>
    <%= FormGroup.For(u => u.ColorMenuGroup, 3, 8).With<ColorSystemInput>() %>
    <%= FormGroup.For(u => u.ColorMenuGroupCustom, 3, 4).WithColorPicker() %>
    <%= FormGroup.For(u => u.UseMenuDropdown, 3, 8).LabelNull().WithCheckbox(ip => ip.Style("margin-top:6px")) %>
</div>
<% if (PortalContext.CurrentUser.FullPermission) %>
<% { %>
<h6 style="border-bottom: solid 2px #cecece; padding-bottom: 5px">Truyền hình trực tiếp</h6>
<div class="form-horizontal">
    <%= FormGroup.For(u => u.Broadcasting_To_CompanyId, 3, 8).With<CompanyInput>(ip => ip.BestUser1(true).Value(PortalContext.CurrentUser.Config.Broadcasting_To_CompanyId)) %>
    <%= FormGroup.For(u => u.Broadcasting_To_UserId, 3, 8).With<UserInput>(ip => ip.TextDefault("-- Người dùng --").CompanyId(PortalContext.CurrentUser.Config.Broadcasting_To_CompanyId).Value(PortalContext.CurrentUser.Config.Broadcasting_To_UserId)) %>
</div>
<% } %>