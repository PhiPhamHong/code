<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormUpdateCompanyConfig.ascx.cs" Inherits="Core.Sites.Apps.Web.Modules.FormCompanyConfigs.FormUpdateCompanyConfig" %>
<div data-rebuild="true" class="row" data-stt="1,2" data-1="col-xs-12" data-2="box">
    <div class="box-body">
        <div class="row">
            <div class="col-md-12">
                <div class="box-header with-border" style="margin-bottom: 20px;">
                    <h4 class="box-title">
                        <a><i class="fas fa-cog"></i>&nbsp;<%= PortalContext.GetLabel("Thông tin chung") %></a>
                    </h4>
                </div>
                <div class="col-md-12">
                    <div class="form-horizontal">
                        <%= FormGroup.For(u => u.CompanyId, 2.5f, 8).With<CompanyInput>(ip=> ip.Value(PortalContext.CurrentUser.User.CompanyId).UseDefault(false)) %>
                        <%= FormGroup.For(u => u.ConfigId, 2.5f, 5).WithInput().Css("hide") %>
                    </div>
                    <div class="form-horizontal" data-form="config-body">
                        <%= FormGroup.For(u => u.ShortName, 2.5f, 8).WithInput(ip => ip.Enable(PortalContext.CurrentUser.User.IsAdmin)) %>
                        <%= FormGroup.For(u => u.FullName, 2.5f, 8).WithInput(ip => ip.Enable(PortalContext.CurrentUser.User.IsAdmin)) %>
                        <%= FormGroup.For(u => u.DomainName, 2.5f, 8).WithInput(ip => ip.Enable(PortalContext.CurrentUser.User.IsAdmin)) %>
                        <%= FormGroup.For(u => u.Logo, 2.5f, 8).WithFileInput(ip => ip.Enable(PortalContext.CurrentUser.User.IsAdmin)) %>
                        <%= FormGroup.For(u => u.Documents, 2.5f, 8).WithFileInput(ip=>ip.TypeFile("Files").Enable(PortalContext.CurrentUser.User.IsAdmin)).Show(PortalContext.CurrentUser.CurrentCompanyId == AppSetting.CompanyFullPermission) %>
                        <%= FormGroup.For(u => u.UseBranch, 2.5f, 8).LabelNull().WithCheckbox().Show(PortalContext.CurrentUser.CurrentCompanyId == AppSetting.CompanyFullPermission) %>
                        <%= FormGroup.For(u => u.UseNewSingleLanguage, 2.5f, 8).LabelNull().WithCheckbox().Show(PortalContext.CurrentUser.CurrentCompanyId == AppSetting.CompanyFullPermission) %>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="box-header with-border" style="margin-bottom: 20px;">
                    <h4 class="box-title">
                        <a><i class="fab fa-facebook"></i>&nbsp;<%= PortalContext.GetLabel("Cấu hình Facebook messenger") %></a>
                    </h4>
                </div>
                <div class="col-md-12">
                    <div class="form-horizontal" data-form="config-body">
                        <%= FormGroup.Col(2.5f, 8).Field(u => u.UriMessengerID).WithInput() %>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="box-header with-border" style="margin-bottom: 20px;">
                    <h4 class="box-title">
                        <a><i class="fas fa-envelope"></i>&nbsp;<%= PortalContext.GetLabel("Cấu hình Email") %></a>
                    </h4>
                </div>
                <div class="col-md-12">
                    <div class="form-horizontal" data-form="config-body">
                        
                        <div class="form-group">
                            <%= FormGroup.NoForm().Col(2.5f, 3).Field(u => u.EmailHost).WithInput() %>
                            <%= FormGroup.NoForm().Col(2, 1).Field(u => u.EmailPort).WithInput(ip => ip.IsNumeric()) %>
                        </div>
                        <%= FormGroup.Col(2.5f, 6).Field(u => u.EmailSendBy).WithInput() %>
                        <%= FormGroup.Col(2.5f, 6).Field(u => u.EmailFromId).WithInput() %>
                        <%= FormGroup.Col(2.5f, 6).Field(u => u.EmailFromPassword).WithInput(ip => ip.TypePassword()) %>
                        <%= FormGroup.Col(2.5f, 6).Field(u => u.EmailCC).WithInput() %>


                        <%= FormGroup.Col(2.5f, 6).Field(u => u.SendGrid_API).WithInput() %>
                        <%= FormGroup.Col(2.5f, 6).Field(u => u.SendGrid_API_Email).WithInput() %>
                        <%= FormGroup.Col(2.5f, 6).Field(u => u.SendGrid_API_Name).WithInput() %>
                        <%= FormGroup.Col(2.5f, 6).Field(u => u.SendGrid_API_ReplyEmail).WithInput() %>
                        <%= FormGroup.Col(2.5f, 6).Field(u => u.SendGrid_API_ReplyEmailName).WithInput() %>

                        <div class="form-group">
                            <%= FormGroup.Col(2.5f, 2).NoForm().Field(u => u.WhenNeedStopSending).WithNumericInput(ip=>ip.Suffix(" lần")) %>
                            <label class="control-label col-sm-1" style="text-align: left"><%= PortalContext.GetLabel("Lỗi") %></label>
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="box-header with-border" style="margin-bottom: 20px;">
                    <h4 class="box-title">
                        <a><i class="fas fa-print"></i>&nbsp;<%= PortalContext.GetLabel("Cấu hình phiếu In") %></a>
                    </h4>
                </div>
                <div class="col-md-12">
                    <div class="form-horizontal" data-form="config-body">
                        <div class="form-group">
                            <%= FormGroup.NoForm().Col(2.5f, 5).Field(u => u.LogoPrint).WithFileInput() %>
                            <%= FormGroup.NoForm().Col(2, 1).Field(u => u.LogoPrintWidth).WithNumericInput(ip=>ip.Suffix(" px")) %>
                        </div>

                        <%= FormGroup.Col(2.5f, 5).Field(u => u.LogoBackground).WithFileInput() %>
                        <%= FormGroup.Col(2.5f, 8).Field(u => u.HeaderPrint).WithInput(ip=>ip.TypeEditor()) %>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="box-header with-border" style="margin-bottom: 20px;">
                    <h4 class="box-title">
                        <a><i class="fas fa-file-excel"></i>&nbsp;<%= PortalContext.GetLabel("Cấu hình Import Excel") %></a>
                    </h4>
                </div>
                <div class="col-md-12">
                    <div class="form-horizontal" data-form="config-body">
                        <%= FormGroup.Col(2.5f, 8).Field(u => u.TemplateExcel).WithFileInput(ip => ip.TypeFile("Files")) %>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="box-footer data-main-footer" style="text-align: center"></div>
</div>
