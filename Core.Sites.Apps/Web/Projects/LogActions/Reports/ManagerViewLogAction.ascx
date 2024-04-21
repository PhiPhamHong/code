<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManagerViewLogAction.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.LogActions.Reports.ManagerViewLogAction" %>
<div data-rebuild="true" class="row table-small" data-stt="1" data-1="col-xs-12">

    <div data-for-table="#table">
        <div class="form-inline row" data-search-toolbar="true">
            <%= FormGroup.Col(1.5f).Input(ip => ip.Name("Keyword").PlaceHolder("Nhập từ khóa tìm kiếm")) %>
            <%= FormGroup.Col(1.25f).DatePicker(ip=> ip.Name("StartTime").PlaceHolder("Từ ngày").Value(Provider.DataSource.StartTime == DateTime.MinValue ? DateTime.Now.StartMonth() : Provider.DataSource.StartTime).Width("100%")) %>
            <%= FormGroup.Col(1.25f).DatePicker(ip=> ip.Name("EndTime").PlaceHolder("Đến ngày").Value(Provider.DataSource.EndTime == DateTime.MinValue ? DateTime.Now.EndMonth() : Provider.DataSource.EndTime).Width("100%").EndDate()) %>
            <%= FormGroup.Col(1.5f).With<CompanyInput>(ip => ip.Name("CompanyId").UseDefault(false))  %>
            <%= FormGroup.Col(1.5f).With<UserInput>(ip => ip.Name("UserId").Value(Provider.DataSource.UserId == 0 ? 0 : Provider.DataSource.UserId)) %>
        </div>
        <web:ButtonSearch runat="server" />
    </div>
    <%= 
        Table.Key(c => c.LogID).EntityName("Báo cáo chi tiết hoạt động của nhân viên").PermissionAdd(-1).DefaultSortDesc(1)
        .Col(c => c.For(t => t.Row, 50).TextCenter().Order(false))
        .Col(c => c.ForDateTime(t => t.DateInsert, 140))
        .Col(c => c.For(t => t.FullName, 140))
        .Col(c => c.For(t => t.Ip, 120).TextCenter())
        .Col(c => c.For(t => t.Ip, 190).Text("Địa chỉ").Class("ip text-center"))
        .Col(c => c.For(t => t.Description).CreatedCell("contentCreated").Order(false))
        .Col(c => c.TypeButton().Icon("fa fa-eye-slash").Text("Chi tiết").Class("text-center").Func("ShowDetail").Order(false).Style("width:60px"))
    %>
</div>
