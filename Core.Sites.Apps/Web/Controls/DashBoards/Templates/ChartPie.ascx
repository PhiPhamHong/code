<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChartPie.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.DashBoards.Templates.ChartPie" %>
<% switch (DashBoard.DashBoardItem.DbBoxType()) %>
<% { %>
<%  case DbBoxType.Small1: %>
<%  case DbBoxType.Small2: %>
<%  case DbBoxType.Small3: %>
<%= PortalContext.GetLabel("Vui lòng chọn loại box nhỏ") %>
<%  break; %>
<%  case DbBoxType.Large1: %>
<div class="col-md-<%= UseProgressBar ? "8":"12" %>">
    <p class="text-center"><strong><%= Title %></strong></p>
    <div class="chart-responsive">
        <canvas height="150"></canvas>
    </div>
</div>

<% if (UseProgressBar) %>
<% { %>
    <div class="col-md-4">
        <p class="text-center"><strong><%= Title2 %></strong></p>
        <div class="progress-area" data-show-total="<%= ShowTotal %>"></div>
    
        <div class="progress-template hide">
            <div class="progress-group" data-state="">
                <span class="progress-text"></span>
                <span class="progress-number"><b>0</b><span></span></span>
                <div class="progress sm">
                    <div class="progress-bar" style="width: 0%"></div>
                </div>
            </div>
        </div>
    </div>
<% } %>
<%  break; %>
<% } %>