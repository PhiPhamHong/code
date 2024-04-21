<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageUsers.ascx.cs" Inherits="Core.Sites.Apps.Web.Modules.FormUsers.ManageUsers" %>
<div data-rebuild="true" class="row table-small" data-stt="1" data-1="col-xs-12">
    <div data-for-table="#table">
        <div class="form-inline row" data-search-toolbar="true">
            <%= FormGroup.Col(3).Input(ip => ip.Name(u => u.UserName).PlaceHolder("Tìm kiếm theo: Người dùng, Họ tên và Email")) %>
            <%= this.InputCompany(2) %>
        </div>
        <web:ButtonSearch runat="server" />
    </div>
    <%= 
        Table.Key(u=> u.UserId).EntityName("Tài khoản").PermissionAdd(Permission.Add).DashBoard(true).DefaultSortDesc(1)
        .Col(c => c.For(t => t.Row, 55).TextCenter().Order(false))
        .Col(c => c.Field(u => u.UserName2).TypeButton().Func(Edit).Permission(Permission.Edit,true))
        .Col(c => c.Field(u => u.CompanyName).FormatSpanDot(150).Show(PortalContext.Config.UseBranch))
        .Col(c => c.Field(u => u.FullName).FormatSpanDot(150).CreatedCell("createdUserName").TypeButton().Func(Edit).Permission(Permission.Edit,true))
        .Col(c => c.Field(u => u.EmployeeCode).FormatSpanDot(50))
        .Col(c => c.Field(u => u.Email).FormatSpanDot(200))
        .Col(c => c.Field(u => u.Mobile).FormatSpanDot(120))

        .Col(c => c.TypeButton().Icon("fa fa-recycle").TextCenter().Func("resetLogin").Permission(20904).Text("Reset đăng nhập").Confirm().Style("width:130px").Order(false))
        .Col(c => c.TypeButton().Icon("fa fa-copy").TextCenter().Func("createDashBoard").Permission(20901).Text("Sao chép").Style("width:110px").Order(false))
        .Col(c => c.Field(u => u.IsLock).TypeButton().TextCenter().Permission(5).WhenTrue("Mở khóa","fa fa-unlock fa-2x").WhenFalse("Khóa","fa fa-lock fa-2x").Style("width:80px").Confirm().Order(false))
        .Col(c => c.TypeButton().Icon("fa fa-key fa-2x").TextCenter().Click("AssignPermission").Permission(18).Text("Phân quyền").Style("width:80px").Order(false))
        .Col(c => c.TypeButton().Icon("fas fa-trash-alt fa-2x").TextCenter().Func(Delete).Text("Xóa").Permission(Permission.Delete).Confirm().Style("width:80px").Order(false))
    %>
</div>