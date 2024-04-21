<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormUpdateUser.ascx.cs" Inherits="Core.Sites.Apps.Web.Modules.FormUsers.FormUpdateUser" %>

<div data-rebuild="true" class="row" data-stt="1,2" data-1="col-xs-12" data-2="box">
    <div class="box-header">
        <h3 class="box-title"><%= PortalContext.GetLabel("Thông tin cá nhân") %></h3>
    </div>
    <div class="box-body">
        <div class="form-horizontal">
            <%= FormGroup.For(u=> u.CompanyId, 2, 3).With<CompanyInput>(ip => ip.Enable(false).UseDefault(false).ControlEnable(true)) %>
            <%= FormGroup.For(u => u.FullName, 2, 6).WithInput() %>
            <%= FormGroup.For(u => u.EmployeeCode, 2, 3).WithInput(ip=>ip.Enable(false)) %>
            <%= FormGroup.For(u => u.Email, 2, 6).WithInput() %>
            <%= FormGroup.For(u => u.Mobile, 2, 6).WithInput() %>
            <%= FormGroup.For(u => u.Avatar, 2, 6).WithFileInput() %>
        </div>
    </div>
    <div class="box-header">
        <h3 class="box-title"><%= PortalContext.GetLabel("Thông tin đăng nhập") %></h3>
    </div>
    <div class="box-body">
        <div class="form-horizontal">
            <%= FormGroup.For(u=> u.UserName, 2, 6).WithInput(ip => ip.Enable(false)) %>
            <% if (PortalContext.HasPermission(14500)) %>
            <% { %>
            <%= FormGroup.For(u=> u.Password, 2, 6).WithInput(ip => ip.TypePassword()) %>
            <% } %>
        </div>
    </div>

    <div class="box-footer data-main-footer" style="text-align:center"></div>
</div>