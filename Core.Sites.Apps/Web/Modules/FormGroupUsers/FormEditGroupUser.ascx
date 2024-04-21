<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormEditGroupUser.ascx.cs" Inherits="Core.Sites.Apps.Web.Modules.FormGroupUsers.FormEditGroupUser" %>
<div class="row">
    <div class="col-sm-12">
        <div class="nav-tabs-custom" style="margin-bottom: 0px" data-form="tab-customer">
            <ul class="nav nav-tabs">
                <li class="active"><a href="#infoGroup" data-hot-key="f6" data-toggle="tab"><%= PortalContext.GetLabel("Thông tin nhóm") %></a></li>
                <li><a href="#infoUsers" data-toggle="tab" data-hot-key="f7" data-need-entity-exit="true" data-module="ManageUsersGroupsUsers" data-before-init="infoUsers_BeforeInit"><%= PortalContext.GetLabel("Nhân viên trong nhóm") %></a></li>
            </ul>
            <div class="tab-content" style="padding-left: 0px; padding-right: 0px; padding-bottom: 0px">
                <div class="active tab-pane" id="infoGroup" style="padding-bottom: 1px">
                    <div class="form-horizontal">
                        <%= FormGroup.For(c => c.CompanyId, 2, 10f).With<CompanyInput>(ip => ip.UseDefault(false).Enable(Entity.GroupId == 0).ControlEnable(true).DisableSearch(true)) %>
                        <%= FormGroup.For(u => u.Name, 2, 5).WithInput() %>
                        <%= FormGroup.For(u => u.GroupType, 2, 5).With<GroupUserTypeInput>() %>
                        <%= FormGroup.For(u => u.Description, 2, 10f).WithInput(ip => ip.TypeTextArea(0, 4)) %>
                    </div>
                    <div class="form-horizontal">
                        <h5 style="font-weight:bold"><%= PortalContext.GetLabel("Trưởng nhóm") %></h5>
                        <div data-form="leader" style="overflow:hidden"></div>
                    </div>
                </div>
                <div class="tab-pane" id="infoUsers" style="padding-bottom: 1px"></div>
            </div>
        </div>
    </div>
</div>