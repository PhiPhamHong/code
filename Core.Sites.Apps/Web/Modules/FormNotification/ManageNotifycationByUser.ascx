<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageNotifycationByUser.ascx.cs" Inherits="Core.Sites.Apps.Web.Modules.FormNotification.ManageNotifycationByUser" %>
<div data-rebuild="true" class="row" data-stt="1" data-1="col-xs-12">
    <%= 
        Table.Key(c => c.NotificationId).EntityName("Thông báo").PermissionAdd(-1).ExportExcel(false)
        .Col(c => c.For(t => t.Name).TypeButton().Func("ViewNotification").Order(false))        

        .Col(c => c.For(t => t.Known, 120).CreatedCell("knownCell").Order(false).TextCenter())
        .Col(c => c.For(t => t.Viewed, 120).CreatedCell("viewedCell").Order(false).TextCenter())

        .Col(c => c.ForDateTime(t => t.CreatedDate, 120).Order(false))
        .Col(c => c.ForDateTime(t => t.UpdatedDate, 120).Order(false))        
    %>
</div>