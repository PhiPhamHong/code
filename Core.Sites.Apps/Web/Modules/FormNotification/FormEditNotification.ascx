<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormEditNotification.ascx.cs" Inherits="Core.Sites.Apps.Web.Modules.FormNotification.FormEditNotification" %>

<div class="form-horizontal">
    <div class="form-group">
        <%= FormGroup.NoForm().For(c => c.Name, 1.5f, 5.5f).WithInput() %>
        <%= FormGroup.NoForm().For(c => c.TypeNotify, 2, 3f).With<NotifyTypeInput>() %>
    </div>
    
    <%= FormGroup.For(c => c.Content, 1.5f, 10.5f).WithInput(ip => ip.TypeEditor(0, 10)) %>
    <%= FormGroup.For(u => u.IsActive, 2.5f, 9.5f)
            .LabelNull()
            .WithCheckbox(ck => ck.Inline(true).LabelCss("margin-top-6px"))
            .Checkbox(ck => ck.Name(c => c.MustView).Inline(true).LabelCss("margin-top-6px")) %>
</div>