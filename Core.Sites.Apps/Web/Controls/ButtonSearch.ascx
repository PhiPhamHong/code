<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ButtonSearch.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.ButtonSearch" %>
<div class="form-inline row">
    <div class="col-sm-1-5">
        <button type="submit" class="btn btn-primary btn-sm btn-flat" data-search-for-table="#table"><i class="fas fa-search"></i> <%= PortalContext.GetLabel("Tìm kiếm") %></button>
    </div>
</div>