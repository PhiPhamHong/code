<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormEditCompanyPackageService.ascx.cs" Inherits="Core.Sites.Apps.Web.Modules.FormCompanyPackageServices.FormEditCompanyPackageService" %>

<div class="form-horizontal">
    <%= FormGroup.For(u=> u.CompanyId, 3, 8).With<CompanyInput>() %>
    <%= FormGroup.For(u=> u.PackageServiceId, 3, 8).With<PackageServiceInput>(ip => ip.Can().DisableSearch(true)) %>
    <%= FormGroup.For(u=> u.StartTime, 3, 4).WithDatePicker() %>
    <%= FormGroup.For(u=> u.EndTime, 3, 4).WithDatePicker() %>
    <%= FormGroup.For(c=> c.Description, 3, 8).WithInput(ip=> ip.TypeTextArea()) %>
    <%= FormGroup.Col(3, 8).LabelNull()
        .Checkbox(cb => cb.Name(u => u.ApplyConfigToCompany).Inline(true)) %>
</div>