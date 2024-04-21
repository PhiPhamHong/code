<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrinterConfig.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.Prints.PrinterConfig" %>
<div class="form-no-pm">
    <h5 class="text-red form-title mt-0"><%= Label("Căn lề") %></h5>
    <div class="form-horizontal">
        <div class="form-group">
            <%= FormGroup.NoForm().For(c => c.MarginTop, 2f, 1.5f).WithInput() %>
            <%= FormGroup.NoForm().For(c => c.MarginTopGallon, 0, 1.8f).InputStyle("padding-left: 1px").With<GallonInput>() %>

            <%= FormGroup.NoForm().For(c => c.MarginBottom, 2f, 1.5f).WithInput() %>
            <%= FormGroup.NoForm().For(c => c.MarginBottomGallon, 0, 1.8f).InputStyle("padding-left: 1px").With<GallonInput>() %>
        </div>

        <div class="form-group">
            <%= FormGroup.NoForm().For(c => c.MarginLeft, 2f, 1.5f).WithInput() %>
            <%= FormGroup.NoForm().For(c => c.MarginLeftGallon, 0, 1.8f).InputStyle("padding-left: 1px").With<GallonInput>() %>

            <%= FormGroup.NoForm().For(c => c.MarginRight, 2f, 1.5f).WithInput() %>
            <%= FormGroup.NoForm().For(c => c.MarginRightGallon, 0, 1.8f).InputStyle("padding-left: 1px").With<GallonInput>() %>
        </div>

        <div class="form-group">
            <%= FormGroup.NoForm().For(c => c.PaddingTop, 2f, 1.5f).WithInput() %>
            <%= FormGroup.NoForm().For(c => c.PaddingTopGallon, 0, 1.8f).InputStyle("padding-left: 1px").With<GallonInput>() %>

            <%= FormGroup.NoForm().For(c => c.PaddingBottom, 2f, 1.5f).WithInput() %>
            <%= FormGroup.NoForm().For(c => c.PaddingBottomGallon, 0, 1.8f).InputStyle("padding-left: 1px").With<GallonInput>() %>
        </div>

        <div class="form-group">
            <%= FormGroup.NoForm().For(c => c.PaddingLeft, 2f, 1.5f).WithInput() %>
            <%= FormGroup.NoForm().For(c => c.PaddingLeftGallon, 0, 1.8f).InputStyle("padding-left: 1px").With<GallonInput>() %>

            <%= FormGroup.NoForm().For(c => c.PaddingRight, 2f, 1.5f).WithInput() %>
            <%= FormGroup.NoForm().For(c => c.PaddingRightGallon, 0, 1.8f).InputStyle("padding-left: 1px").With<GallonInput>() %>
        </div>
    </div>
    <h5 class="text-red form-title mt-0"><%= Label("Khổ giấy") %></h5>
    <div class="form-horizontal">
        <div class="form-group">
            <%= FormGroup.NoForm().For(c => c.PageSize, 2f, 3.3f).With<PageSizeInput>(ip => ip.Data("option-key", "op")) %>
            <%= FormGroup.NoForm().For(c => c.PageSizeCustomer, 2f, 3.3f).LabelCss("hide op op-0").InputCss("hide op op-0").WithInput() %>
        </div>
    </div>
    <asp:PlaceHolder runat="server" ID="plcConfig"></asp:PlaceHolder>    
</div>