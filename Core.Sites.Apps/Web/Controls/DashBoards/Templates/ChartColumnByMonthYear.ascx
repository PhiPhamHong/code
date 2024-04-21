<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChartColumnByMonthYear.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.DashBoards.Templates.ChartColumnByMonthYear" %>
<% switch (DashBoard.DashBoardItem.DbBoxType()) %>
<% { %>
<%  case DbBoxType.Small1: %>
<%  case DbBoxType.Small2: %>
<%  case DbBoxType.Small3: %>
<%= PortalContext.GetLabel("Vui lòng chọn loại box lớn hơn") %>
<%  break; %>
<%  case DbBoxType.Large1: %>
<div class="row">
    <div class="col-sm-12">
        <div class="frm-search hide">
            <div class="row">
                <div class="col-sm-6 select-inline">
                    <%= Build<MonthInput>().Name("Month").Width("100px") %>
                    <%= Build<YearInput>().Name("Year").Width("100px") %>
                </div>
            </div>
        </div>
        <div class="chart"><canvas height="200"></canvas></div>
    </div>
</div>
<%  break; %>
<% } %>