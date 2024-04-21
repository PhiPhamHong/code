
using Core.Business.Entities;
using Core.Business.Entities.Websites;
using Core.Sites.Apps.Web.Controls;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Web.WebBase;
using System.Collections.Generic;

namespace Core.Sites.Apps.Web.Projects.Websites.FormCategories
{
    [Module]
    [Script(Src = "/Web/Projects/Websites/FormCategories/js/ManageCategories.js")]
    [ManageModulePermission(Add = 22701, Edit = 22702, Delete = 22703)]
    public partial class ManageCategories : ManageModule<Category, Category.Language, int, int, ManageCategories.ModuleProvider, FormEditCategory, FormEditCategoryLanguage>
    {
        public ManageCategories()
        {
            this.SetData("CatType", PortalContext.GetCurrentModuleSetting<Category.Type>("Type"));
        }

        public class ModuleProvider : ManageModuleProviderLanguage.Source<Category.DataSource>, IAjax
        {
            protected override void ValidateHelper(Category t)
            {
                new Category.Tree { IsActive = false, LanguageId = PortalContext.DefaultLanguage, CompanyId = t.CompanyId}.ThrownIfParentNotValid(t);
            }

            public override Category GetByKey(Category t)
            {
                return base.GetByKey(t) ?? new Category { CatType = t.CatType, IsActive = true , CompanyId = t.CompanyId };
            }
        }
    }
}