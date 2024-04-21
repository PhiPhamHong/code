using Core.Business.Entities.CRM;
using Core.Caching;
using System.Collections.Generic;


namespace Core.FrontEnds.Libraries.Web.Caches.Previews
{
    public class CacheUptinForms : CacheByWebCacheFactory<List<UptinForm>, CacheUptinForms>
    {
        protected override List<UptinForm> LoadForCache()
        {
            return UptinForm.Inst.GetAllToList();
        }
    }
}
