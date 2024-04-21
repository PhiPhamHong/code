using Core.Attributes;
using Core.Business.Entities;
using Core.Business.Entities.CRM;
using Core.DataBase.ADOProvider;
using Core.Extensions;
using Core.FrontEnds.Libraries.Portal;
using Core.FrontEnds.Libraries.Portal.Configs;
using Core.FrontEnds.Libraries.Web;
using Core.FrontEnds.Libraries.Web.Caches;
using Core.FrontEnds.Libraries.Web.Caches.Previews;
using System.Collections.Generic;
using System.Linq;

namespace Core.FrontEnds.Libraries.UrlEngines.Landings
{
    public class UrlLandingEngine : IUrlEngine
    {
        public void FindQuery(UrlEngine.Result result, PageTag page, string urlVitural)
        {
            var urlFinder = new UrlFinder(urlVitural);
            urlFinder.AddFinder<FindDefaultKeyword>();
            urlFinder.AddFinder<FindPage>();
            urlFinder.Run();
            if (urlFinder.Ok && urlFinder.Context.Params.Count > 1)
            {
                var param = urlFinder.Context.Params;
                result.Query = GetQuery(urlFinder.Query).JoinString(s => s, "&");
                var ladiId = param.TryGet("LandingId").To<int>();
                FeContext.Url.LanguageId = 2;
                FeContext.Url.Language = CacheLanguages.GetData().FirstOrDefault(c => c.LanguageId == 2);
                FeContext.Url.Landing.Landing = CacheLandingPages.GetData().FirstOrDefault(c => c.LandingId == ladiId);
            }
        }
        private IEnumerable<string> GetQuery(string Query)
        {
            yield return "prefix=" + "Landing&" + Query;
        }
        public class FindDefaultKeyword : UrlFinder.Process
        {
            public override bool Searching()
            {
                var keyLanding = "landingpage";
                if (Context.Url.StartsWith(keyLanding))
                {
                    Context.UrlFound = keyLanding;
                    Context.Params["Type"] = "Landing";
                    Context.Params["langId"] = 2;
                    return true;
                }
                return false;
            }
        }
        public class FindPage : UrlFinder.Process
        {
            public override bool Searching()
            {
                if (!string.IsNullOrEmpty(Context.UrlFound))
                {
                    var ladis = CacheLandingPages.GetData().Where(c=>c.IsActive == true).ToList(); //Đầu tiên là check trong cache xem có bản ghi đang tìm hay k.
                    foreach (var ladi in ladis)
                    {
                        var urlhope = Context.UrlFound + ("com" + ladi.CompanyId + "-" + ladi.Url);
                        if (Context.Url.StartsWith(urlhope))
                        {
                            Context.Params["LandingId"] = ladi.LandingId;
                            Context.UrlFound = urlhope;
                            return true;
                        }
                    }
                    ladis = LandingPage.Inst.GetAllToList().Where(c => c.IsActive == true).ToList(); // nếu mà trong cache chưa có. thì phải vào database tìm.
                    foreach (var ladi in ladis)
                    {
                        var urlhope = Context.UrlFound + ("com" + ladi.CompanyId + "-" + ladi.Url);
                        if (Context.Url.StartsWith(urlhope))
                        {
                            Context.Params["LandingId"] = ladi.LandingId;
                            Context.UrlFound = urlhope;
                            CacheLandingPages.Reload(); // nếu mà tìm thấy thành công. => Cache cũ chưa có dữ liệu này. thì phải làm mới lại cache cho có dữ liệu mới thêm
                            return true;
                        }
                    }
                    return false;
                }
                else
                    return false;
            }
        }
    }
}
