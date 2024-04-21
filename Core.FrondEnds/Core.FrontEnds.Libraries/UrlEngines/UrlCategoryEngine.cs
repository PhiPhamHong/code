using Core.Business.Entities.Websites;
using Core.FrontEnds.Libraries.Portal;
using Core.FrontEnds.Libraries.Portal.Configs;
using Core.FrontEnds.Libraries.Web;
using Core.FrontEnds.Libraries.Web.Caches;
using Core.Extensions;
using System.Collections.Generic;
using System.Linq;
namespace Core.FrontEnds.Libraries.UrlEngines
{
    public class UrlCategoryEngine : IUrlEngine
    {
        public Category.Type CatType { set; get; }

        public void FindQuery(UrlEngine.Result result, PageTag page, string urlVitural) // urlVitural = cam-nang-du-lich => Tiếng Việt, manual-travel => Tiếng Anh
        {
            var category = CacheCategories.GetData().FirstOrDefault(c => c.Alias == urlVitural);
            if (category == null) return;

            result.Meta = category;
            FeContext.Url.LanguageId = category.LanguageId;
            FeContext.Url.Language = CacheLanguages.GetData().FirstOrDefault(l => l.LanguageId == category.LanguageId);

            //FeContext.Url.Category.CatType = CatType;
            FeContext.Url.Category.CatId = category.CatId;
            FeContext.Url.Category.Entity = category;

            result.Query = GetQuery(category).JoinString(q => q, "&");
        }

        private IEnumerable<string> GetQuery(Category.Fe category)
        {
            yield return "link=3";
            yield return "catid=" + category.CatId;
            //yield return "cattype=" + (int)CatType;
            yield return "lang=" + category.LanguageId;
            yield return "catroot=" + FeContext.Url.Category.Breadcrumbs.First().CatId;
        }
    }
}
