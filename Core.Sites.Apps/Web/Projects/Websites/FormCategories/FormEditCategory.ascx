<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormEditCategory.ascx.cs" Inherits="Core.Sites.Apps.Web.Projects.Websites.FormCategories.FormEditCategory" %>

<web:FormLanguage runat="server" />

<div class="form-horizontal" style="margin-top: 20px">
    <div class="nav-tabs-custom" style="margin-bottom:0px">
        <ul class="nav nav-tabs">
            <li class="active"><a href="#mainCategoryInfo" data-toggle="tab"><%= PortalContext.GetLabel("Thông tin") %></a></li>            
            <li><a href="#mainCategoryHomeFocus" data-toggle="tab"><%= PortalContext.GetLabel("Cấu hình hiển thị") %></a></li> 
            <li><a href="#mainCategoryImage" data-toggle="tab"><%= PortalContext.GetLabel("Ảnh") %></a></li>
        </ul>
        <div class="tab-content">
            <div class='tab-pane active' id="mainCategoryInfo" style="position: relative;">
                <%= FormGroup.For(u => u.CompanyId, 3, 8).With<CompanyInput>(ip => ip.UseDefault(false)) %>
                <%= FormGroup.For(c=> c.ParentId, 3, 8).With<CategoryInput>(ip => ip.CatType(Entity.CatType).CompanyId(Entity.CompanyId)) %>
                <%= FormGroup.For(c => c.CatTypeView, 3, 8).With<CategoryTypeViewInput>() %>
                <div class="form-group ">
                    <%= FormGroup.NoForm().For(c=> c.Stt, 3, 3).WithInput(ip=> ip.IsNumeric()) %>
                    <%= FormGroup.NoForm().For(c=> c.IsActive, 0, 6).WithCheckbox(cb => cb.Inline(true).Style("margin-top:5px")) %>                    
                </div>
            </div>
 
            <div class='tab-pane' id="mainCategoryHomeFocus" style="position: relative;">                
                <div class="form-group ">
                    <%= FormGroup.NoForm().InputCol(12).Checkbox(cb => cb.Name(u => u.IsShow).Inline(true))
                            .Checkbox(cb => cb.Name(u => u.Vertical).Inline(true))
                            .Checkbox(cb => cb.Name(u => u.Horizontal).Inline(true)) %>
                </div>
            </div>

            <div class='tab-pane' id="mainCategoryImage" style="position: relative;">
                <%= FormGroup.For(c=> c.Avatar, 3, 8).WithFileInput() %>
                <%= FormGroup.For(c=> c.Banner, 3, 8).WithFileInput() %>
            </div>
        </div>
    </div>
</div>