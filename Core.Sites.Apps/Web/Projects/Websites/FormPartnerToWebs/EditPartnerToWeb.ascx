<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditPartnerToWeb.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormPartnerToWebs.EditPartnerToWeb" %>
<div class="row">
    <div class="col-md-12">
        <div class="form-horizontal" style="margin-top: 15px">
            <%= FormGroup.For(u => u.CompanyId, 2.5f, 5f).With<CompanyInput>(ip => ip.UseDefault(false)) %>
            <div class="form-group">
                <%= FormGroup.NoForm().For(c => c.Logo, 2.5f, 5f).WithFileInput(ip=>ip.ShowImages(true,40,40)) %>
                <%= FormGroup.NoForm().For(c => c.IsShow, 1, 3).WithCheckbox().LabelNull() %>
            </div>
            
            <%= FormGroup.For(c => c.Name, 2.5f, 8.5f).WithInput() %>
            <%= FormGroup.For(c => c.Link, 2.5f, 8.5f).WithInput() %>

            <%= FormGroup.For(c => c.Des, 2.5f, 8.5f).WithInput(ip=>ip.TypeTextArea(0,2)) %>
        </div>
    </div>
</div>
