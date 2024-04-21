<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditDocument.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Orthers.Documents.FormDocuments.EditDocument" %>

<div class="row">
    <div class="col-sm-12">
        <web:FormLanguage runat="server" />
        <div class="form-horizontal">
            <div class="form-group">
                <%= FormGroup.For(c => c.Attachment, 2.5f, 9f).WithFileInput(ip => ip.TypeFile("Files")) %>
               
            </div>
            <div class="form-group">
                <%= FormGroup.For(c => c.IsActive, 2.5f, 4f).WithCheckbox().LabelNull() %>
            </div>
        </div>

    </div>
</div>
