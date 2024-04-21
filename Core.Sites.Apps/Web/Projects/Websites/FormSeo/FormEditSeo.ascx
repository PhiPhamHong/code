<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormEditSeo.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormSeo.FormEditSeo" %>
<div data-rebuild="true" class="row" data-stt="1,2" data-1="col-xs-12" data-2="box">
    <div class="box-header">
        <h3 class="box-title"><%= PortalContext.GetLabel("Thông tin Seo") %></h3>
    </div>
    <div class="box-body">
        <div class="form-horizontal">  
            <input type="hidden" name="SeoId" />
            <%= FormGroup.For(u => u.CompanyId, 2, 5f).With<CompanyInput>(ip => ip.UseDefault(false)) %>
            <%= FormGroup.For(c=> c.GoogleAnalytics, 2, 8).WithInput(ip => ip.TypeTextArea(0,2)) %>
            <%= FormGroup.For(c=> c.SiteImage, 2, 8).WithFileInput() %>
            <%= FormGroup.For(c=> c.Favicon, 2, 8).WithFileInput() %>
        </div>
        <web:FormLanguage runat="server" />
    </div>
    <div class="box-footer data-main-footer" style="text-align:center"></div>
</div>