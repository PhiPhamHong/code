<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PilotScheduleControl.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.DayPilots.PilotScheduleControl" %>
<div class="frm-search form-inline row" data-form="search">
    
    <%= FormGroup.Col(2).Css(ShowCompany ? "" :"hide").With<CompanyInput>(ip => ip.Name("CompanyId").UseDefault(false)) %>
    <% if (UseTime) %>
    <% { %>
    <%= FormGroup.Col(ColDate).ColStyle("width:180px").DatePicker(ip => ip.Name("StartTime").HasTime(UseTime).PlaceHolder("Từ ngày").Value(GetFromDate()).WidthTime(54).Width("100%")) %>
    <%= FormGroup.Col(ColDate).ColStyle("width:180px").DatePicker(ip => ip.Name("EndTime").HasTime(UseTime).PlaceHolder("Đến ngày").Value(GetToDate()).WidthTime(54).Width("100%")) %>
    <% } %>
    <% else %>
    <% { %>
    <%= FormGroup.Col(ColDate).ColStyle("width:128px").DatePicker(ip => ip.Name("StartTime").PlaceHolder("Từ ngày").Value(GetFromDate()).Width("100%")) %>
    <%= FormGroup.Col(ColDate).ColStyle("width:128px").DatePicker(ip => ip.Name("EndTime").PlaceHolder("Đến ngày").Value(GetToDate()).Width("100%").EndDate()) %>
    <% } %>
    <asp:PlaceHolder runat="server" ID="plcInputs"></asp:PlaceHolder>

    <div class="col-sm-6-5" data-form-pilot="button">
        <button type="button" class="btn btn-primary btn-sm btn-flat" data-hot-key="Ctrl_f" data-form-button="search"><%= PortalContext.GetLabel(PortalContext.GetLabel("Tìm kiếm")) %></button>
        <button type="button" class="btn bg-orange btn-sm btn-flat" data-hot-key="Ctrl_m" data-form-button="previousMonth"><span class="fa fa-backward"></span> <%= TimeLabel.Previous %></button>
        <button type="button" class="btn bg-red btn-sm btn-flat" data-hot-key="Ctrl_p" data-form-button="nextMonth"><span class="fa fa-forward"></span> <%= TimeLabel.Next %></button>
        <asp:PlaceHolder runat="server" ID="plcButtons"></asp:PlaceHolder>
    </div>
</div>

<style>.scheduler_default_corner div:nth-of-type(4) { display:none !important }</style>
<div id="dp" data-time="<%= (byte)TimeRange %>"></div>