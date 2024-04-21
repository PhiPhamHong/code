<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Documents.ascx.cs" Inherits="Core.FE.Sites.Transports.Projects.Web.Pages.Documents" %>
<%@ Register Src="~/Projects/Web/Controls/Header.ascx" TagPrefix="uc1" TagName="Header" %>

<uc1:Header runat="server" ID="Header" />
<div class="main">
    <div class="container">
        <div class="sidebar col-md-4">
            <h2><%= Target %></h2>
        </div>
        <div class="content col-md-8" style="display: ruby;">
            <div class="head">

                <div class="search">
                    <div id="form-search">
                        <input id="keyword" type="text" placeholder="<%= Label("Nhập từ khóa") %>">
                        <button onclick="SearchDoc(this)" style="font-size: 14px; color: white;">
                            <%= Label("Tìm kiếm") %>
                        </button>
                    </div>
            </div>
        </div>
        <div class="list-new" style="padding-top: 25px;">
            <div class="row">
                <asp:Repeater runat="server" ID="rpdocs">
                    <ItemTemplate>
                        <div class="col-md-11 data-doc" data-id="<%# Eval("DocumentId") %>">
                            <div class="new-body">
                                <div class="new-title">
                                    <p style="color: #262626;"><%# Eval("DocumentTitle") %></p>
                                </div>
                                <div class="new-date">
                                    <h4 style="color: #696868;"><%# Eval("CreatedDate") %> </h4>
                                </div>

                            </div>
                        </div>
                        <div class="col-md-1 data-doc" data-id="<%# Eval("DocumentId") %>">
                            <div style="padding-bottom: 1em;">
                                <a href="<%# Eval("Attachment") %>" target="_blank">
                                    <button style="background: white;">
                                        <div style="font-size: 14px; color: black;">
                                            <svg xmlns="http://www.w3.org/2000/svg" width="42" height="42" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" stroke="currentColor">
                                                <path d="M4.483 13.105c-.43 0-.645.545-.34.863l7.516 6.884a.466.466 0 0 0 .682 0l7.517-6.884c.304-.318.088-.863-.341-.863H15.68a.495.495 0 0 1-.483-.506V3.506A.494.494 0 0 0 14.716 3H9.284a.494.494 0 0 0-.482.506v9.093c0 .28-.216.506-.483.506z" />
                                            </svg>
                                        </div>
                                    </button>
                                </a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="pager"><%= pager.RenderPager() %></div>
    </div>
</div>

</div>
