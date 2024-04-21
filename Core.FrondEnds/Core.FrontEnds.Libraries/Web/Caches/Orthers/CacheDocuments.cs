using Core.Business.Entities.Others.Documents;
using Core.Caching;
using System.Collections.Generic;

namespace Core.FrontEnds.Libraries.Web.Caches.Orthers
{
    public class CacheDocuments : CacheByWebCacheFactory<List<Document>, CacheDocuments>
    {
        protected override List<Document> LoadForCache()
        {
            var data = new Document.DataSource { }.GetAllforFe();
            data.ForEach(c =>
            {
                if (c.IsActive == true && !string.IsNullOrEmpty(c.Attachment))
                {
                    c.Attachment = Setting.ServerImage + "/" + c.Attachment;
                }
            });
            return data;
        }
    }
}
