<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormGotoUser.ascx.cs" Inherits="Core.Sites.Apps.Web.Modules.FormUsers.FormGotoUser" %>
<div class="row">
    <div class="col-md-12">
        <div class="form-horizontal">
            <%= FormGroup.For(u=> u.CompanyId, 3, 8).With<CompanyInput>(ip => ip.UseDefault(false).BestUser1(true).Value(CurrentCompanyId)) %>
            <%= FormGroup.For(u=> u.UserId, 3, 8).With<UserInput>(ip => ip.TextDefault("-- Người dùng --").Can().CompanyId(CurrentCompanyId).Value(PortalContext.Session.IAccountInfo.User_2())) %>
        </div>
    </div>
</div>
