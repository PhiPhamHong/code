<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditNewFiles.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormNews.FormNewFiles.EditNewFiles" %>
<div class="row">
    <div class="col-md-12">
        <div class="form-horizontal">
            <%= FormGroup.For(u => u.CompanyId, 3, 8).With<CompanyInput>(ip => ip.UseDefault(false)) %>

            <%= FormGroup.Col(3, 8).Field(c => c.NewsId).With<Core.Sites.Apps.Web.Projects.Websites.Inputs.NewInput>(ip=>ip.CompanyId(PortalContext.CurrentUser.CurrentCompanyId)) %>
            <%= FormGroup.Col(3, 8).Field(c => c.Title).WithInput() %>
            <%= FormGroup.Col(3, 8).Field(c => c.Path).WithFileInput(ip => ip.TypeFile("Files")) %>
            <div class="form-group">
                <%= FormGroup.NoForm().Col(3, 3).Field(c => c.IsShow).WithCheckbox().LabelNull() %>
                <%= FormGroup.NoForm().Col(0, 5).Field(c => c.DownloadAllowed).WithCheckbox().LabelNull() %>
            </div>
            <%= FormGroup.Col(3, 8).Field(c => c.Note).WithInput(ip=>ip.TypeTextArea(0,2)) %>
        </div>

    </div>
</div>
