using Core.Business.Entities.Websites;
using Core.Caching;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Core.FrontEnds.Libraries.Web.Caches
{
    public class CachePageUrls : CacheByWebCacheFactory<List<PageUrl.Fe>, CachePageUrls>
    {
        [PropertyCacheOptional("CompanyId")] public int CompanyId { get { return FeContext.Url.CompanyId; } }
        protected override List<PageUrl.Fe> LoadForCache()
        {
            var data = PageUrl.Fe.GetAllPages(CompanyId);
            data.ForEach(page =>
            {
                page.VirtualUrl = page.VirtualUrl.Replace("{int}", "([0-9]+)").Replace("{varchar}", "([^/]+)");
                page.Rex = new Regex(page.VirtualUrl, RegexOptions.IgnoreCase);
                if (page.Match)
                    page.TemplateUrls = page.TemplateUrl.Split('@');
            });
            return data;
        }

        public static PageUrl.Fe Get(string prefix, int languageId)
        {
            return GetData().FirstOrDefault(c => c.Prefix == prefix && c.LanguageId == languageId);
        }
        public static PageUrl.Fe Get(string prefix)
        {
            return Get(prefix, FeContext.Url.LanguageId);
        }
        public static List<PageUrl.Fe> Gets(string prefix)
        {
            return GetData().Where(c => c.Prefix == prefix).ToList();
        }

        public static IEnumerable<PageUrl.Fe> Gets(int languageId, string likePrefix)
        {
            return GetData()
                    .Where(p => p.LanguageId == languageId)
                    .Where(p => p.Prefix.StartsWith(likePrefix));
        }

        public const string PREFIX_SORT_SERVICE = "SortService_";
    }
}
