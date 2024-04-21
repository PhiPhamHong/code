<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditDirection.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Orthers.PriceConfigs.FormDirections.EditDirection" %>

<div class="row">
    <div class="col-sm-12">
        <web:FormLanguage runat="server" />
        <div class="form-horizontal">
            <div class="form-group">
                <%= FormGroup.NoForm().For(c => c.IsStart, 2.5f, 2.5f).WithCheckbox().LabelNull() %>
                <%= FormGroup.NoForm().For(c => c.IsEnd, 2.5f, 3f).WithCheckbox().LabelNull() %>
            </div>
        </div>
        
    </div>
</div>