<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageDirections.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Orthers.PriceConfigs.FormDirections.ManageDirections" %>
<div data-rebuild="true" class="row" data-stt="1" data-1="col-xs-12">
    <div data-for-table="#table">
        <div class="form-inline row" data-search-toolbar="true">
            <%= this.InputKeyword(2, u => u.DirectionName) %>
            <%= this.Select<LanguageInput>(1.5f, "LanguageId", ip => ip.DisableSearch(true)) %>
        </div>
        <web:ButtonSearch runat="server" />
    </div>

    <%= 
        Table.Key(c => c.DirectionId).EntityName("Điểm bốc/dỡ").PermissionAdd(Permission.Add).DefaultSort(3)
        .Col(c => c.For(t => t.DirectionName,250).TypeButton().Func(Edit).Permission(Permission.Edit, true).Order(false))
        .Col(c => c.Field(u => u.IsStart).TypeButton().TextCenter().Permission(Permission.Edit, true).WhenTrue("Bỏ áp dụng","glyphicon glyphicon-ok gi-2x").WhenFalse("Áp dụng điểm bốc","glyphicon glyphicon-remove gi-2x").Style("width:80px").Confirm().Order(false))
        .Col(c => c.Field(u => u.IsEnd).TypeButton().TextCenter().Permission(Permission.Edit, true).WhenTrue("Bỏ áp dụng","glyphicon glyphicon-ok gi-2x").WhenFalse("Áp dụng điểm dỡ","glyphicon glyphicon-remove gi-2x").Style("width:80px").Confirm().Order(false))

        .Col(c => c.ForDateTime(t => t.CreatedDate, 130))
        .Col(c => c.For(t => t.CreatedByUserName, 150).Order(false))
        .Col(c => c.ForDateTime(t => t.UpdatedDate, 130))
        .Col(c => c.For(t => t.UpdatedByUserName, 150).Order(false))
        
        .Col(c => c.TypeButton().Icon("fas fa-trash-alt fa-2x").Class("text-center").Func(Delete).Text("Xóa").Permission(Permission.Delete).Confirm().Style("width:50px").Order(false))
    %>
</div>
