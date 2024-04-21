<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageGroupUsers.ascx.cs" Inherits="Core.Sites.Apps.Web.Modules.FormGroupUsers.ManageGroupUsers" %>
<div data-rebuild="true" class="row table-small" data-stt="1" data-1="col-xs-12">
    <div data-for-table="#table">
        <div class="form-inline row" data-search-toolbar="true">
            <%= this.InputKeyword(4, u => u.Name) %>
            <%= this.Select<GroupUserTypeInput>(1.5f, "GroupType") %>
            <%= this.InputCompany(2, ip => ip.Value(Provider.CompanyId)) %>
        </div>
        <web:ButtonSearch runat="server" />
    </div>
    <%= 
        Table.Key(c => c.GroupId).EntityName("Nhóm nhân viên").PermissionAdd(Permission.Add)
        .Col(c=> c.For(t => t.Name, 300).TypeButton().Func(Edit).Permission(Permission.Edit, true))
        .Col(c=> c.For(t => t.GroupTypeName, 150))
        .Col(c=> c.For(t => t.Description))

        .Col(c => c.ForDateTime(t => t.CreatedDate, 130))
        .Col(c => c.For(t => t.CreatedByUserName, 120))
        .Col(c => c.ForDateTime(t => t.UpdatedDate, 130))
        .Col(c => c.For(t => t.UpdatedByUserName, 120))
        .Col(c => c.TypeButton().Icon("fas fa-trash-alt fa-2x").Class("text-center").Func(Delete).Text("Xóa").Permission(Permission.Delete).Confirm().Style("width:70px").Order(false))
    %>
</div>