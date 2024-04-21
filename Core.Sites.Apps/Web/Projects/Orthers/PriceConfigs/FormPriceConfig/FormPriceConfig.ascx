<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormPriceConfig.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Orthers.PriceConfigs.FormPriceConfig.FormPriceConfig" %>
<div data-rebuild="true" class="row" data-stt="1,2" data-1="col-xs-12" data-2="box">
    <div class="box-header">
        <h3 class="box-title"><%= PortalContext.GetLabel("Thông tin cấu hình giá") %></h3>
    </div>
    <div class="box-body">
        <div class="form-horizontal">
            <div class="form-group">
                <label class="control-label col-sm-2" style="text-align: left">Điểm bốc</label>
                <label class="control-label col-sm-2" style="text-align: left">Điểm dỡ</label>
                <label class="control-label col-sm-2" style="text-align: left">Loại mặt hàng</label>
                <label class="control-label col-sm-2" style="text-align: left">Loại xe</label>
                <label class="control-label col-sm-2" style="text-align: left">Cước phí<span style="color: red"> (*)</span></label>
            </div>
        </div>
        <div class="form-horizontal">

            <div class="form-group" id="Maindata">
                <asp:Repeater runat="server" ID="rpConfigs">
                    <ItemTemplate>
                        <div class="form-group data-config">
                            <div class="col-sm-2">
                                <input autocomplete="off" id="<%# Eval("StartDirection") %>" type="text" value="<%# Eval("StartPointName") %>" class="form-control input-sm StartPointName" disabled="disabled" name="StartPointName">
                            </div>
                            <div class="col-sm-2">
                                <input autocomplete="off" id="<%# Eval("EndDirection") %>" type="text" value="<%# Eval("EndPointName") %>" class="form-control input-sm EndPointName" disabled="disabled" name="EndPointName">
                            </div>
                            <div class="col-sm-2">
                                <input autocomplete="off" id="<%# Eval("ProductType") %>" type="text" value="<%# Eval("ProductTypeName") %>" class="form-control input-sm ProductTypeName" disabled="disabled" name="ProductTypeName">
                            </div>
                            <div class="col-sm-2">
                                <input autocomplete="off" id="<%# Eval("ContainerType") %>" type="text" value="<%# Eval("TranTypeName") %>" class="form-control input-sm TranTypeName" disabled="disabled" name="TranTypeName">
                            </div>
                            <div class="col-sm-2">
                                <input autocomplete="off" type="number" min="0" max="999999999" value="<%# Eval("Price") %>" class="form-control input-sm Price" name="Price" placeholder="Giá cước">
                            </div>
                        </div>

                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>
        <div class="modal-footer" style="border-top: none; padding-top: 0px">
            <button type="button" class="btn btn-primary" data-func="Save"><span class="fas fa-save"></span><%= PortalContext.GetLabel("Cập nhật") %></button>
        </div>
    </div>
</div>
