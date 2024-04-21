<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContentSmall.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.DashBoards.Templates.ContentSmall" %>

<% switch (DashBoard.DashBoardItem.DbBoxType()) %>
<% { %>
<%  case DbBoxType.Small1:  %>
        <div class="inner">
            <h3 data-form="content"></h3>
            <p><%= DashBoard.DashBoardItem.Title %></p>
        </div>
        <div class="icon">
            <i class="<%= Icon1 %>"></i>
        </div>
        <% if(UseLinkModule) %>
        <% { %>
        <a href="<%= UrlHelper.GetUrl(DashBoard.DashBoardItem.Url) %>" data-state="true" class="small-box-footer">Xem chi tiết <i class="fas fa-arrow-circle-right"></i></a>
        <% } %>
        <% else %>
        <% { %>
        <a class="small-box-footer"><i class="fas fa-arrow-circle-right"></i></a>
        <% } %>        
<%  break; %>
<%  case DbBoxType.Small2: %>
        <span class="info-box-icon"><i class="<%= Icon2 %>"></i></span>
        <div class="info-box-content">
            <span class="info-box-text"><%= DashBoard.DashBoardItem.Title %></span>
            <span class="info-box-number" data-form="content"></span>
        </div>
<%  break; %>

<% case DbBoxType.Small3: %>
        <span class="info-box-icon"><i class="<%= Icon3 %>"></i></span>
        <div class="info-box-content">
            <span class="info-box-text"><%= DashBoard.DashBoardItem.Title %></span>
            <span class="info-box-number" data-form="content"></span>
            <div class="progress"><div class="progress-bar" style="width: 100%"></div></div>
            <span class="progress-description"></span>
        </div>
<% break; %>

<%  default: %>
<%= PortalContext.GetLabel("Vui lòng chọn loại box nhỏ") %>
<%  break; %>
<% } %>