using System.Collections.Generic;
using Core.Business.Entities.Websites;
using Core.Sites.Apps.Web.Projects.Websites.FormCategories;
using Core.Web.WebBase;
using Core.Web.WebBase.HtmlBuilders;

namespace Core.Sites.Apps.Web.Inputs
{
    public class CategoryInput : SelectModel<Category, CategoryInput>
    {
        [SelectData("CatType")] protected Category.Type catType { set; get; }
        public CategoryInput CatType(Category.Type catType) { return Chain(ip => ip.catType = catType); }

        [SelectData("CompanyId")] protected int companyId { set; get; }
        public CategoryInput CompanyId(int companyId) { return Chain(ip => ip.companyId = companyId); }

        [LanguageInput.SelectData] protected int languageId { set; get; }
        public CategoryInput LanguageId(int languageId) { return Chain(ip => ip.languageId = languageId); }

        protected override List<Category> GetData()
        {
            return new Category.Tree { CompanyId = companyId, LanguageId = languageId, CatType = catType }.GetInTreeView(0, false);
        }
        
    }
}