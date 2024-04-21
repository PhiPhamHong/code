using Core.Business.Entities.Websites;
using Core.Caching;
using System.Collections.Generic;
using System.Linq;
using Core.Extensions;
namespace Core.FrontEnds.Libraries.Web.Caches
{
    public class CacheLabels : CacheByWebCacheFactory<List<Label.Item>, CacheLabels>
    {
        [PropertyCacheOptional("CompanyId")] public int CompanyId 
        {
            get { return FeContext.Url.CompanyId; }
        }
        protected override List<Label.Item> LoadForCache()
        {
            return Label.Item.Get(CompanyId);
        }

        public static Dictionary<string, string> Get(int languageId)
        {
            var dic = new Dictionary<string, string> { };
            GetData().Where(c => c.LanguageId == languageId).ForEach(item => dic[item.Lexicon] = item.Value);
            return dic;
        }

        public static List<Label.Item> Get(string lexicon)
        {
            return GetData().Where(l => l.Lexicon == lexicon).ToList();
        }
    }
}
