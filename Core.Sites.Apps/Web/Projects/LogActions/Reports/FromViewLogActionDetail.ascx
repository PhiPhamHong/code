<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FromViewLogActionDetail.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.LogActions.Reports.FromViewLogActionDetail" %>

<div data-form="main-log" style="max-height:300px">
    <asp:Repeater runat="server" ID="rpnote" OnItemDataBound="rpnote_ItemDataBound">
        <ItemTemplate>
            <div class="log-view-title"<%# Convert.ToString(Eval("TypeConrete")).IsNull() ? string.Empty: " data-type='" + Eval("TypeConrete") + "'" %>>
                <%# Eval("Title") + " <span class='name'>" + PortalContext.GetLabel(Eval("Name").ToString()).FirstCharToLower() + "</span>" %>
                <%# Eval("KeyConcrete").To<int>() == 0 ? 
                    (Convert.ToString(Eval("NameConcrete")).Equals(string.Empty) ? "" : "<span class=\"cname text-green\">" + Eval("NameConcrete") + "</span>") : 
                    "<span class=\"ckey text-green\" data-o=\"" + Eval("KeyConcrete") + "\" ></span>" %>
                <span class="hide"><%# Eval("ExtendData") %></span>
            </div>
            <asp:Repeater runat="server" ID="rpDetail">
                <HeaderTemplate>
                    <table style="width: 100%;" class="handsontable table-core-sh dataTable no-footer" role="grid" data-has-be-nice="true">
                        <tr data-column-real="true" role="row">
                            <%--<th class="text-center sorting_disabled"><%= PortalContext.GetLabel("Tên trường") %></th>--%>
                            <th style="width: 150px;" class="text-center sorting_disabled"><%= PortalContext.GetLabel("Mô tả") %></th>
                            <th class="text-center sorting_disabled"><%= PortalContext.GetLabel("Giá trị cũ") %></th>
                            <th class="text-center sorting_disabled"><%= PortalContext.GetLabel("Giá trị mới") %></th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr role="row" class="odd"<%# Convert.ToString(Eval("TypeRef")).IsNull() ? string.Empty: " data-type='" + Eval("TypeRef") + "'" %>>
                        <%--<td><%# Eval("Field") %></td>--%>
                        <td><%# PortalContext.GetLabel(Eval("Name").ToString()) %></td>
                        <td data-o="<%# Eval("OldValue") %>" data-v="old"><%# Eval("OldValue") %></td>
                        <td data-o="<%# Eval("NewValue") %>" data-v="new"><%# Eval("NewValue") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:Repeater>
</div>