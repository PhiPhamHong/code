<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditNewContent.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormNews.FormNewContents.EditNewContent" %>


<div class="row">
    <div class="col-sm-12">
        <div class="nav-tabs-custom" data-form="tab-news">
            <ul class="nav nav-tabs" data-form="tab-of-news">
                <li class="active"><a href="#infoProperties" data-toggle="tab"><i class="fas fa-cogs"></i><%= PortalContext.GetLabel("Cấu hình chung") %></a></li>
                <li><a href="#infoNewsRelate" data-toggle="tab" data-need-entity-exit="true" data-module="ManageNewsRelates" data-customer-data="infoNewsRelate_CustomerData" data-before-init="infoNewsRelate_BeforeInit"><i class="fas fa-hashtag"></i><%= PortalContext.GetLabel("Bài viết liên quan") %></a></li>
                <li><a href="#infoFiles" data-toggle="tab" data-need-entity-exit="true" data-reload-when-click="true" data-module="ManageNewFiles" data-before-init="infoFiles_BeforeInit"><i class="fas fa-file-word"></i><%= PortalContext.GetLabel("Tài liệu đính kèm") %> </a></li>
            </ul>
            <div class="tab-content" style="padding: 0px">
                <div class="active tab-pane" id="infoProperties">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <%= FormGroup.NoForm().For(u => u.CompanyId, 2f, 4).With<CompanyInput>(ip => ip.UseDefault(false)) %>
                            <%= FormGroup.NoForm().For(u => u.LanguageId, 2f, 4).With<LanguageInput>(ip => ip.UseDefault(true)) %>
                            
                        </div>
                        <%= FormGroup.For(c => c.CatId, 2f, 4).With<CategoryInput>(ip => ip.CatType(Core.Business.Entities.Websites.Category.Type.News).CompanyId(Entity.CompanyId)) %>
                        <div class="form-group">
                            <%= FormGroup.NoForm().For(c => c.YoutubeId, 2f, 4f).WithInput() %>
                            <%= FormGroup.NoForm().For(c => c.Avatar, 2f, 3f).WithFileInput() %>
                        </div>
                        <div class="form-group">
                            <%= FormGroup.NoForm().For(c => c.Attachment, 2f, 4f).WithFileInput(ip => ip.TypeFile("Files")) %>
                            <%= FormGroup.NoForm().For(c => c.AllowDetail, 2f, 3f).WithCheckbox().LabelNull() %>
                        </div>

                        <%= FormGroup.For(c => c.Avatars, 2f, 9f).WithFileInput(ip => ip.ShowImages(true,30,30).Multi()) %>
                        <%= FormGroup.For(c=> c.Tags, 2f, 9f).With<Core.Sites.Apps.Web.Projects.ERP.Inputs.HashtagInput>(ip => ip.CompanyId(Entity.CompanyId).Multiple()) %>
                        <div class="form-group">
                            <%= FormGroup.NoForm().For(c => c.DatePublished, 2f, 3).WithDatePicker(ip => ip.HasTime()) %>
                            <%= FormGroup.NoForm().Col(4, 2).HalfCol(true, true).LabelNull()
                                            .Checkbox(cb => cb.Name(u => u.IsActive).Inline(true)) %>
                        </div>

                    </div>

                    <div class="form-horizontal" style="padding-top:30px">
                        <div class="col-md-5">

                            <%= FormGroup.For(c=> c.Title, 3f, 9f).WithInput() %>
                            <%= FormGroup.For(c=> c.Keyword, 3f, 9f).WithInput() %>
                            <%= FormGroup.For(c=> c.Sapo, 3f, 9f).WithInput(ip => ip.TypeTextArea(0, 3)) %>
                        </div>
                        <div class="col-md-7">
                            <%= FormGroup.LabelNull().For(c=> c.NewsContent, 0, 12).WithInput(ip => ip.TypeTextArea()) %>
                        </div>

                    </div>


                </div>
                <div class="tab-pane" id="infoNewsRelate"></div>
                <div class="tab-pane" id="infoFiles"></div>
            </div>
        </div>
    </div>
</div>
