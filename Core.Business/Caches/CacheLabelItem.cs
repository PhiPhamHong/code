using System.Collections.Generic;
using Core.Business.Entities;
using Core.Utility;
using System.Linq;
using Core.Extensions;
using Core.Caching;
namespace Core.Business.Caches
{
    public class CacheLabelItem : CacheByWebCacheFactory<Dictionary<string, string>>
    {
        [PropertyCacheOptional("CompanyId")] public int CompanyId { set; get; }
        [PropertyCacheOptional("LanguageId")] public int LanguageId { set; get; }

        protected override Dictionary<string, string> LoadForCache()
        {
            var data = new Dictionary<string, string> { };
            Label.GetAllLabelItems(1, LanguageId).ForEach(l => data[l.Lexicon] = l.Value);

            if (CompanyId != 0 && CompanyId != 1)
                Label.GetAllLabelItems(CompanyId, LanguageId).ForEach(l => data[l.Lexicon] = l.Value);

            return data;
        }

        public static string GetLabel(int companyId, string lexicon, int languageId)
        {
            return new CacheLabelItem { CompanyId = companyId, LanguageId = languageId }.Get().TryGet(lexicon, lexicon);
        }
    }
}