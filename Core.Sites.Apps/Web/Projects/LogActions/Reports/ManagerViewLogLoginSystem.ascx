<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManagerViewLogLoginSystem.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.LogActions.Reports.ManagerViewLogLoginSystem" %>
<div data-rebuild="true" class="row table-small" data-stt="1" data-1="col-xs-12">
    <div data-for-table="#table">
        <div class="form-inline row" data-search-toolbar="true">
            <%= FormGroup.Col(1.5f).DatePicker(ip=> ip.Name("StartTime").PlaceHolder("Từ ngày").Value(Provider.DataSource.StartTime == DateTime.MinValue ? DateTime.Now.StartMonth() : Provider.DataSource.StartTime).Width("100%")) %>
            <%= FormGroup.Col(1.5f).DatePicker(ip=> ip.Name("EndTime").PlaceHolder("Đến ngày").Value(Provider.DataSource.EndTime == DateTime.MinValue ? DateTime.Now.EndMonth() : Provider.DataSource.EndTime).Width("100%").EndDate()) %>
            <%= FormGroup.Col(2).With<CompanyInput>(ip => ip.Name("CompanyId").UseDefault(false))  %>
            <%= FormGroup.Col(2).With<UserInput>(ip => ip.Name("UserId").TextDefault("-- Nhân viên --").Value(Provider.DataSource.UserId == 0 ? 0 : Provider.DataSource.UserId)) %>
        </div>
        <web:ButtonSearch runat="server" />
    </div>
    <%= 
        Table.Key(c => c.UserLoginLogId).EntityName("Báo cáo Log đăng nhập hệ thống").PermissionAdd(-1).DefaultSortDesc(1)
        .Col(c => c.For(t => t.Row, 50).TextCenter().Order(false))
        .Col(c => c.ForDateTime(t => t.DateLogin, 140))
        .Col(c => c.For(t => t.UserName, 140))
        .Col(c => c.For(t => t.Ip, 120).TextCenter())
        .Col(c => c.For(t => t.Password, 190))
        .Col(c => c.For(t => t.Success_Name).Order(false).CreatedCell("cellColor"))
    %>
</div>
