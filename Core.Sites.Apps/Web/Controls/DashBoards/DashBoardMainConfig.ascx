<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DashBoardMainConfig.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.DashBoards.DashBoardMainConfig" %>
<%@ Import Namespace="Core.Sites.Apps.Web.Controls.DashBoards.BoxType" %>
<div class="form-no-pm">
    <div class="form-horizontal">
        <%= FormGroup.For(c => c.Title, 3, 8).WithInput() %>
        <%= FormGroup.For(c => c.Stt, 3, 8).WithInput(ip=> ip.Enable(false)) %>
        <div class="form-group">
            <%= FormGroup.NoForm().For(c => c.Col, 3, 2).With<ColInput>() %>
            <%= FormGroup.For(c => c.TypeBox, 1.5f, 4.5f).NoForm().With<BoxTypeInput>() %>
        </div>
        <%= FormGroup.For(c => c.TabId, 3, 8).With<DashBoardTabInput>(ip => ip.Can()) %>
    </div>
    <asp:PlaceHolder runat="server" ID="plc"></asp:PlaceHolder>
</div>