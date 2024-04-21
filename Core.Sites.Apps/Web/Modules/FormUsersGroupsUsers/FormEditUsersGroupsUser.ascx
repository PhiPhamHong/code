<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormEditUsersGroupsUser.ascx.cs" Inherits="Core.Sites.Apps.Web.Modules.FormUsersGroupsUsers.FormEditUsersGroupsUser" %>
<div class="form-horizontal">
    <%= FormGroup.For(u => u.GroupId, 3, 8).With<GroupUserInput>(ip => ip.Can().CompanyId(CompanyId).Enable(false)) %>
    <%= FormGroup.For(u => u.UserId, 3, 8).With<UserInput>(ip=> ip.CompanyId(CompanyId).TextDefault("-- Nhân viên --").Can()) %>
    <%= FormGroup.For(u => u.FromDate, 3, 4).WithDatePicker() %>
</div>