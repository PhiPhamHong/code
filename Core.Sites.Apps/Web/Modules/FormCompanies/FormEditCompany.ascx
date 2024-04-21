<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormEditCompany.ascx.cs" Inherits="Core.Sites.Apps.Web.Modules.FormCompanies.FormEditCompany" %>

<div class="form-horizontal form-no-pm">
    <%= FormGroup.For(c=> c.Name, 2.5f, 9).WithInput() %>
    <%= FormGroup.For(c=> c.CompanyCode, 2.5f, 9).WithInput() %>
    <%= FormGroup.For(c=> c.Address, 2.5f, 9).WithInput() %>
    <%= FormGroup.For(c=> c.Email, 2.5f, 9).WithInput() %>
    <div class="form-group">
        <%= FormGroup.NoForm().For(c=> c.Phone, 2.5f, 3).WithInput() %>
        <%= FormGroup.NoForm().For(c=> c.Website, 1.5f, 4.5f).WithInput() %>
    </div>

    <%= FormGroup.For(u => u.ParentCompanyId, 2.5f, 9).With<CompanyInput.AlwaysShow>(ip => ip.Name(u => u.ParentCompanyId)) %>
    <%= FormGroup.For(c=> c.Description, 2.5f, 9).WithInput(ip=> ip.TypeTextArea(0,4)) %>
    <%= FormGroup.For(c=> c.SubDomain, 2.5f, 9).WithInput() %>
    <%= FormGroup.For(c=> c.DomainUsed, 2.5f, 9).Css(PortalContext.CurrentUser.GetCurrentCompanyId() == AppSetting.CompanyFullPermission ? "": "hide").WithInput() %>
    
    <div class="form-group">
        <%= FormGroup.NoForm().For(c=> c.MaxUser, 2.5f, 3).Css(PortalContext.CurrentUser.GetCurrentCompanyId() == AppSetting.CompanyFullPermission ? "": "hide").WithInput(ip => ip.IsNumeric()) %>
        
        <%= FormGroup.NoForm().Col(0, 2).LabelNull().Checkbox(cb=> cb.Style("margin-top:6px").Name(u=> u.IsLock).Enable(PortalContext.HasPermission(0))) %>
    </div> 
</div>