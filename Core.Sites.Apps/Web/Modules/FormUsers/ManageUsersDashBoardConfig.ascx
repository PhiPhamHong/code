<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageUsersDashBoardConfig.ascx.cs" Inherits="Core.Sites.Apps.Web.Modules.FormUsers.ManageUsersDashBoardConfig" %>

<div class="form-horizontal">
    <%= FormGroup.LabelCol(3).InputCol(8).Field(u=> u.OptionReportType).With<OptionReportTypeInput>() %>
</div>

<div class="callout callout-info no-margin bring-up">
    <%= PortalContext.GetLabel("Chú ý: Chọn loại khung là Box nhỏ là phù hợp. Độ rộng nên là 3 cột") %>
</div>