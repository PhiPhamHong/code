using Core.Business.Entities.CRM;
using Core.Caching;
using System.Collections.Generic;
using static Core.Business.Entities.CRM.Partner;

namespace Core.Sites.Libraries.Cache
{
    public class CachePartners : CacheByWebCacheFactory<List<Partner>>
    {
        [PropertyCacheOptional("CompanyId")] public int CompanyId { set; get; }
        protected override List<Partner> LoadForCache() => new Partner.DataSource { CompanyId = CompanyId, TypeView = TypeView.All, UserType = User.Type.All }.GetEntities();
    }
}