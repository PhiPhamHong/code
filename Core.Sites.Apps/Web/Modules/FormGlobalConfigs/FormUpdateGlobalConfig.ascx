<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormUpdateGlobalConfig.ascx.cs" Inherits="Core.Sites.Apps.Web.Modules.FormGlobalConfigs.FormUpdateGlobalConfig" %>
<div data-rebuild="true" class="row" data-stt="1,2" data-1="col-xs-12" data-2="box">
    <div class="box-body">
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-8">
                <div class="form-horizontal" data-form="config-body">
                    <%= FormGroup.For(c => c.CompanyId, 2, 9).With<CompanyInput>(ip => ip.UseDefault(false)) %>
                    <%= FormGroup.For(u => u.GoogleMapKey, 2, 9).WithInput() %>
                    <%= FormGroup.For(u => u.NationalityId_Of_VN, 2, 9).WithInput(c=>c.IsNumeric()) %>
                    <%= FormGroup.For(u => u.GlobalConfigId, 2, 0).WithInput().Css("hide") %>
                    <%= FormGroup.For(u => u.Facebook, 2, 9).WithInput() %>
                    <%= FormGroup.For(u => u.Instagram, 2, 9).WithInput() %>
                    <%= FormGroup.For(u => u.Youtube, 2, 9).WithInput() %>
                    <%= FormGroup.For(u => u.Email, 2, 9).WithInput() %>
                    <%= FormGroup.For(u => u.Phone, 2, 9).WithInput() %>
                    <%= FormGroup.For(u => u.LinkWebsite, 2, 9).WithInput() %>
                    <%= FormGroup.For(u => u.Viettel_Prefix, 2, 9).WithInput() %>
                    <%= FormGroup.For(u => u.VinaPhone_Prefix, 2, 9).WithInput() %>
                    <%= FormGroup.For(u => u.Mobifone_Prefix, 2, 9).WithInput() %>
                    <%= FormGroup.For(u => u.SFONE_Prefix, 2, 9).WithInput() %>
                    <%= FormGroup.For(u => u.VietNamMobile_Prefix, 2, 9).WithInput() %>
                    <%= FormGroup.For(u => u.Beeline_Prefix, 2, 9).WithInput() %>
                    <%= FormGroup.For(u => u.TimkeeperBaseUrl, 2, 9).WithInput() %>
                    <%= FormGroup.For(u => u.ServerApiBaseUrl, 2, 9).WithInput() %>
                </div>
            </div>
        </div>
    </div>
    <div class="box-footer data-main-footer" style="text-align: center"></div>
</div>
