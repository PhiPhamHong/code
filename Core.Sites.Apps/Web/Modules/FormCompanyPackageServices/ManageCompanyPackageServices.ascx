<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageCompanyPackageServices.ascx.cs" Inherits="Core.Sites.Apps.Web.Modules.FormCompanyPackageServices.ManageCompanyPackageServices" %>
<div data-rebuild="true" class="row table-small" data-stt="1" data-1="col-xs-12">
    <div data-for-table="#table">
        <div class="form-inline row" data-search-toolbar="true">
            <%= this.InputKeyword(3, u => u.CompanyName) %>
            <%= this.InputFromDate(1.5f, ip => ip.PlaceHolder("Ngày áp dụng")) %>
            <%= this.InputToDate(1.5f, ip => ip.PlaceHolder("Ngày hết hạn")) %>

            <%= FormGroup.Col(1).Checkbox(ip => ip.Name("ShowHistory").PlaceHolder("Lịch sử").Style("margin-top:5px")) %>
        </div>
        <web:ButtonSearch runat="server" />
    </div>
    <%= 
        Table.Key(c => c.Id).EntityName("Thông tin dịch vụ").PermissionAdd(Permission.Add)
        .Col(c=> c.Field(t => t.CompanyName).TypeButton().Func(Edit).Permission(Permission.Edit, true))
        .Col(c=> c.Field(t => t.PackageServiceName))
        .Col(c=> c.Field(t => t.StartTime).FormatDate().Style("width:120px"))
        .Col(c=> c.Field(t => t.EndTime).FormatDate().Style("width:120px"))
        .Col(c => c.TypeButton().Icon("fa fa-trash-o").Class("text-center").Func(Delete).Text("Xóa").Permission(Permission.Delete).Confirm().Style("width:70px").Order(false))
    %>
</div>