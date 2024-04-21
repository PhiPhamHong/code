<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormEditDashboardTab.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.DashBoards.FormEditDashboardTab" %>
<div class="form-horizontal form-no-pm">
    <%= FormGroup.For(u=> u.TabName, 3,8).WithInput() %>
    <%= FormGroup.For(u=> u.Stt, 3,4).WithInput(ip => ip.IsNumeric()) %>
</div>