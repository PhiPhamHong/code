<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormEditNews_SEO.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormNews.FormEditNews_SEO" %>
<div class="form-horizontal">
    <div class="form-group">
        <label class="control-label col-sm-1-5"><%= PortalContext.GetLabel("Chọn đường dẫn") %></label>
        <div class="col-sm-10-5" data-select="news"></div>
    </div>
    <div class="form-group" data-link="news"></div>
    <div class="form-group">
        <iframe style="width: 100%;border:none"></iframe>
    </div>
</div>