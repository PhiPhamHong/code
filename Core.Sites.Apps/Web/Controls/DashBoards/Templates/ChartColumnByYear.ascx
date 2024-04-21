<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChartColumnByYear.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.DashBoards.Templates.ChartColumnByYear" %>
<% switch (DashBoard.DashBoardItem.DbBoxType()) %>
<% { %>
<%  case DbBoxType.Small1: %>
<%  case DbBoxType.Small2: %>
<%  case DbBoxType.Small3: %>
<%= PortalContext.GetLabel("Vui lòng chọn loại box lớn hơn") %>
<%  break; %>
<%  case DbBoxType.Large1: %>
<div class="row">
    <div class="col-md-12">
        <div class="frm-search hide">
            <div class="row">
                <div class="col-md-12">
                    <%= Build<YearInput>().Name("Year").Width("100px") %>
                </div>
            </div>
        </div>
        <div class="chart"><canvas height="186"></canvas></div>
    </div>
</div>
<%  break; %>
<% } %>