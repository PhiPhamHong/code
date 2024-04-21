<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContentLarge.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.DashBoards.Templates.ContentLarge" %>
<% switch (DashBoard.DashBoardItem.DbBoxType()) %>
<% { %>
<%  case DbBoxType.Small1: %>
<%  case DbBoxType.Small2: %>
<%  case DbBoxType.Small3: %>
<%= PortalContext.GetLabel("Vui lòng chọn loại box lớn") %>
<%  break; %>
<%  case DbBoxType.Large1: %>
<div data-form="content"></div>
<%  break; %>
<% } %>