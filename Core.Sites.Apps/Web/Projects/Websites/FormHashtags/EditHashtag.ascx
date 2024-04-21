<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditHashtag.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormHashtags.EditHashtag" %>
<div class="row">
    <div class="col-sm-12">
        
        <div class="form-horizontal" style="margin-top: 15px">
            <%= FormGroup.For(u => u.CompanyId, 2.5f, 8).With<CompanyInput>(ip => ip.UseDefault(false)) %>
            <%= FormGroup.For(c => c.Color, 2.5f, 3).WithColorPicker() %>
            <%= FormGroup.For(c => c.TextColor, 2.5f, 3).WithColorPicker() %>
            <div class="form-group">
                <%= FormGroup.NoForm().For(c => c.DisplayOrder, 2.5f, 2.5f).WithNumericInput(ip => ip.MaxLength(10)) %>
                <%= FormGroup.NoForm().For(c => c.IsActive, 2.5f, 3f).WithCheckbox().LabelNull() %>
            </div>
        </div>
        <web:FormLanguage runat="server" />

    </div>
</div>
