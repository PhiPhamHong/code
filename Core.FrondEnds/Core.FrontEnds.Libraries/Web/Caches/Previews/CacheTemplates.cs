using Core.Business.Entities.CRM;
using Core.Caching;
using System.Collections.Generic;


namespace Core.FrontEnds.Libraries.Web.Caches.Previews
{
    public class CacheTemplates : CacheByWebCacheFactory<List<Template>, CacheTemplates>
    {
        protected override List<Template> LoadForCache()
        {
            return Template.Inst.GetAllToList();
        }
    }
}
