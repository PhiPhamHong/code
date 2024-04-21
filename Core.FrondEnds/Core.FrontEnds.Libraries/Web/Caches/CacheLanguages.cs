using Core.Caching;
using System.Collections.Generic;
using Core.Business.Entities;
namespace Core.FrontEnds.Libraries.Web.Caches
{
    public class CacheLanguages : CacheByWebCacheFactory<List<Language>, CacheLanguages>
    {
        protected override List<Language> LoadForCache()
        {
            return Language.Inst.GetAllToList();
        }
    }
}