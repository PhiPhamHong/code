<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormEditUser.ascx.cs" Inherits="Core.Sites.Apps.Web.Modules.FormUsers.FormEditUser" %>

<div class="form-horizontal">
    <%= FormGroup.For(u=> u.CompanyId, 3, 8).With<CompanyInput>(ip => ip.Enable(Entity.UserId == 0).UseDefault(false).ControlEnable(true)) %>

    <div class="form-group">
        <%= FormGroup.NoForm().For(u=> u.UserName, 3, 4).WithInput() %>
        <label class="control-label col-sm-3" style="text-align:left; padding-left: 0px">@<span class="sub-domain"><%= GetSubDomain() %></span></label>
    </div>
    <%= FormGroup.For(u=> u.Password, 3, 8).WithInput(iu=> iu.TypePassword().PlaceHolder("******")) %>
    <%= FormGroup.For(u=> u.FullName, 3, 8).WithInput(ip => ip.MaxLength(50)) %>
    <%= FormGroup.For(u=> u.Email, 3, 8).WithInput() %>
    <%= FormGroup.For(u=> u.Mobile, 3, 4).WithInput(ip => ip.MaxLength(15)) %>
    <%= FormGroup.For(u=> u.Avatar, 3, 8).WithFileInput() %>
    <%= FormGroup.For(u=> u.EmployeeCode, 3, 8).WithInput(ip => ip.MaxLength(10)) %>
    <%= FormGroup.For(u=> u.RoleId, 3, 8).With<RoleInput>() %>
    <%= FormGroup.Col(3, 9).LabelNull()
        .Checkbox(cb=> cb.Name(u=> u.IsAdmin).Inline(true))
        .Checkbox(cb=> cb.Name(u=> u.IsBoss).Inline(true).Enable(PortalContext.CurrentUser.CurrentCompanyId == AppSetting.CompanyFullPermission))
        .Checkbox(cb=> cb.Name(u=> u.IsLock).Inline(true).Enable(PortalContext.HasPermission(5))) %>
</div>
