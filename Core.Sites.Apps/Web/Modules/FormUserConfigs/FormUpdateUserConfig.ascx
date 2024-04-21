<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormUpdateUserConfig.ascx.cs" Inherits="Core.Sites.Apps.Web.Modules.FormUserConfigs.FormUpdateUserConfig" %>

<div data-rebuild="true" class="row" data-stt="1,2" data-1="col-xs-12" data-2="box">
    <div class="box-header">
        <h3 class="box-title"><%= PortalContext.GetLabel("Cấu hình bản đồ mặc định") %></h3>
    </div>
    <div class="box-body">
        <div class="form-horizontal">
            <%= FormGroup.Col(2, 4).LabelText("Tọa độ mặc định").LatLngInput(ip=> ip.Lat(u => u.MapCenterLat).Lng(u => u.MapCenterLng)) %>
            <%= FormGroup.For(u=> u.MapTypeId, 2, 4).With<MapTypeInput>() %>
            <%= FormGroup.For(u=> u.MapZoom, 2, 4).With<MapZoomInput>() %>
        </div>
    </div>
    <div class="box-footer data-main-footer" style="text-align:center"></div>
</div>