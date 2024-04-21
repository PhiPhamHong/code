<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageUserPermissions.ascx.cs" Inherits="Core.Sites.Apps.Web.Modules.FormUserPermissions.ManageUserPermissions" %>
<%@ Register Src="~/Web/Controls/Common/FormAssignPermission.ascx" TagPrefix="web" TagName="FormAssignPermission" %>

<div class="row">
    <div class="col-xs-12">
        <web:FormAssignPermission runat="server" ID="formAssignPermission" UseModuleTypeAction="false" />
    </div>
</div>