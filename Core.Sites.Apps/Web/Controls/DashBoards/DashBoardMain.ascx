<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DashBoardMain.ascx.cs" Inherits="Core.Sites.Apps.Web.Controls.DashBoards.DashBoardMain" %>
<div class="row connectedSortable">
    <asp:Repeater runat="server" ID="rpData" OnItemDataBound="rpData_ItemDataBound">
        <ItemTemplate>
            <div class="col-lg-<%# Eval("T1.Col") %>" data-dashboard-sort="true" data-col="<%# Eval("T1.Col") %>">
                <div data-main="<%# Eval("T1.Id") %>" data-main-url="<%# Eval("T1.Url") %>">
                    <asp:PlaceHolder runat="server" ID="plc"></asp:PlaceHolder>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <div class="col-lg-1"></div>
</div>