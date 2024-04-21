using Core.Business.Entities.Websites;
using Core.Caching;
using Core.FrontEnds.Libraries.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Core.FrontEnds.Libraries.Web.Caches.News
{
    public class CacheNews : CacheByWebCacheFactory<List<Core.Business.Entities.Websites.News.Fe>, CacheNews>
    {
        [PropertyCacheOptional("CompanyId")] public int CompanyId { get { return FeContext.Url.CompanyId; } }
        protected override List<Core.Business.Entities.Websites.News.Fe> LoadForCache()
        {
            var data = Core.Business.Entities.Websites.News.Fe.GetFes(CompanyId);
            data.ForEach(c =>
            {
                if (c.AllowDetail == true && !string.IsNullOrEmpty(c.Attachment))
                {
                    c.Attachment = Setting.ServerImage + "/" + c.Attachment;
                }
                c.FormatContent();
                c.UrlFormat = FeUrl.GetUrl(c.Alias);
                c.Files = new Core.Business.Entities.Websites.News.File.DataSource { CompanyId = CompanyId, NewsId = c.NewsId, FieldOrder = "NewsId" }.GetEntities();
                c.Files.ForEach(f =>
                {
                    f.Path = FeUrl.SourceUrl(f.Path.Split(',').FirstOrDefault());
                });
                c.Relates = new Core.Business.Entities.Websites.News.Relate.DataSource { NewsId = c.NewsId, LanguageId = c.LanguageId, FieldOrder = "NewsId", Start = 0, Length = int.MaxValue, Dir = "ASC" }.GetEntities();
                c.Relates.ForEach(r =>
                {
                    r.Urlformat = FeUrl.GetUrl(r.Alias);
                });
            });
            return data;
        }
    }
}
