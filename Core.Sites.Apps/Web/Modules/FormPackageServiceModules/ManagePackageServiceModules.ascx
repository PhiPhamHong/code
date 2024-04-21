<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManagePackageServiceModules.ascx.cs" Inherits="Core.Sites.Apps.Web.Modules.FormPackageServiceModules.ManagePackageServiceModules" %>
<%@ Register Src="~/Web/Controls/Common/FormAssignPermission.ascx" TagPrefix="web" TagName="FormAssignPermission" %>

<div data-rebuild="true" class="row" data-stt="1" data-1="col-xs-12">
    <div class="frm-search form-horizontal">
        <div class="form-group">
            <%= FormGroup.Col(1, 2).NoForm().LabelText("Dịch vụ").With<PackageServiceInput>(ip => ip.Width("100%")
                                            .DisableSearch(true).UseDefault(false)
                                            .Value(PackageServiceId)
                                            .Name("PackageServiceId")
                                            .Data("func", "ChoosePagekage")
                                            .Data("url", UrlHelper.AssignPerPackageService)) %>

            <div class="col-xs-4">
                <label><input type="checkbox" name="AssignForBoss" /> Áp dụng cho Boss</label>
                <button class="btn btn-success btn-sm" data-func="ChooseAllAll"><span class="fas fa-check-double"></span> <%= PortalContext.GetLabel("Chọn tất cả") %></button>
                <button class="btn btn-danger btn-sm" data-func="UnChooseAllAll"><span class="fas fa-calendar-times"></span> <%= PortalContext.GetLabel("Bỏ chọn tất cả") %></button>
            </div>
        </div>
    </div>


    <web:FormAssignPermission runat="server" id="formAssignPermission" />

    <div class="modal-footer" style="border-top:none;padding-top:0px">
        <button type="button" class="btn btn-primary" data-func="Save"><span class="fas fa-save"></span> <%= PortalContext.GetLabel("Cập nhật") %></button>
    </div>
</div>