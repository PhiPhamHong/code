<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormEditPackageService.ascx.cs" Inherits="Core.Sites.Apps.Web.Modules.FormPackageServices.FormEditPackageService" %>
<div class="form-horizontal form-no-pm">
    <%= FormGroup.For(c=> c.Name, 2.5f, 9).WithInput() %>

</div>