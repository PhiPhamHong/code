<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormEditNews.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormNews.FormEditNews" %>


<div class="row">
    <div class="col-sm-12">
        <div class="nav-tabs-custom" data-form="tab-news">
            <ul class="nav nav-tabs" data-form="tab-of-news">
                <li class="active"><a href="#infoProperties" data-toggle="tab"><i class="fas fa-cogs"></i><%= PortalContext.GetLabel("Cấu hình chung") %></a></li>
                <li><a href="#infoNewsRelate" data-toggle="tab" data-need-entity-exit="true" data-module="ManageNewsRelates" data-customer-data="infoNewsRelate_CustomerData" data-before-init="infoNewsRelate_BeforeInit"><i class="fas fa-hashtag"></i><%= PortalContext.GetLabel("Bài viết liên quan") %></a></li>
                <%--<li><a href="#infoFiles" data-toggle="tab" data-need-entity-exit="true" data-reload-when-click="true" data-module="ManageNewFiles" data-before-init="infoFiles_BeforeInit"> <i class="fas fa-file-word"></i> <%= PortalContext.GetLabel("Tài liệu đính kèm") %> </a></li>--%>
                <%--<li><a href="#infoFaceBookTool" data-toggle="tab" data-need-entity-exit="true" data-module="FormEditNews_SEO" data-customer-data="infoFaceBookTool_CustomerData"><i class="fab fa-facebook-square"></i><%= PortalContext.GetLabel("SEO Tool(Facebook)") %></a></li>
                <li><a href="#infoGoogleTool" data-toggle="tab" data-need-entity-exit="true" data-module="FormEditNews_SEO" data-customer-data="infoGoogleTool_CustomerData"><i class="fab fa-google-plus-square"></i><%= PortalContext.GetLabel("SEO Tool(Google +)") %></a></li>--%>
            </ul>
            <div class="tab-content" style="padding: 0px">
                <div class="active tab-pane" id="infoProperties">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <%= FormGroup.NoForm().For(u => u.CompanyId, 2f, 3).With<CompanyInput>(ip => ip.UseDefault(false)) %>
                            <%= FormGroup.NoForm().For(c => c.CatId, 2f, 4f).With<CategoryInput>(ip => ip.CatType(Type).CompanyId(Entity.CompanyId)) %>
                        </div>
                        <div class="form-group">
                            <%= FormGroup.NoForm().For(c => c.Avatar, 2f, 4f).WithFileInput() %>
                        </div>
                        <div class="form-group">
                            
                            <%= FormGroup.For(c => c.IsActive, 2f, 4f).WithCheckbox().LabelNull() %>
                        </div>
                        <%--<div class="form-group">
                            <%= FormGroup.NoForm().For(c => c.Attachment, 2f, 4f).WithFileInput(ip => ip.TypeFile("Files")) %>
                            <%= FormGroup.NoForm().For(c => c.AllowDetail, 2f, 3f).WithCheckbox().LabelNull().Checkbox(cb => cb.Name(u => u.IsActive).Inline(true)) %>
                        </div>--%>

                        <web:FormLanguage runat="server" />
                    </div>
                </div>
                <div class="tab-pane" id="infoNewsRelate"></div>
            </div>
        </div>
    </div>
</div>
