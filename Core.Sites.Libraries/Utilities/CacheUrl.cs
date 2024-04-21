using System.Web;
using System.Text.RegularExpressions;

using Core.Caching;
using Core.Extensions;
using Core.Sites.Libraries.Business;
using Core.Web.Extensions;
using Core.Business.Enums;

namespace Core.Sites.Libraries.Utilities
{
    [CacheFactory(TypeFactory = typeof(PortalContextCacheFactory))]
    public class CacheUrl : CacheEntry<CacheUrl.CacheUrlData>
    {
        public class CacheUrlData
        {
            public string Url { set; get; }
            public MenuTop MenuTop { set; get; }
            public MenuItem MenuItem { set; get; }
        }

        [PropertyCacheOptional("Url")] public string Url { set; get; }
        [PropertyCacheOptional("SessionType")] public SessionType SessionType { set; get; }

        [PropertyCacheOptional("Extension")] public string Extension
        {
            get { return AppSetting.Extension; }
        }

        public static CacheUrlData GetData(string url, SessionType sessionType)
        {
            return new CacheUrl { Url = url, SessionType = sessionType }.Get();
        }

        protected override CacheUrlData LoadForCache()
        {
            var menus = PortalContext.MenuDocument.Menus;

            for (int i = 0; i < menus.Count; i++)
            {
                var menu = menus[i];

                if (menu.SessionType == SessionType.Unknown || menu.SessionType == SessionType)
                {
                    // Tìm Url thật của thằng menu top
                    var urlReal = GetUrlReal(Url, menu); // menus[i]

                    // có thì bắn luôn
                    if (urlReal.IsNotNull()) return new CacheUrlData { Url = urlReal, MenuItem = menu, MenuTop = menu };

                    // nếu không có thì tìm ở con trong từng group
                    for (int j = 0; j < menu.Groups.Count; j++)
                    {
                        for (int z = 0; z < menu.Groups[j].MenuItems.Count; z++)
                        {
                            // Tìm Url thật ở thằng menu con
                            urlReal = GetUrlReal(Url, menu.Groups[j].MenuItems[z]); // menus[i]

                            // có thì bắn
                            if (urlReal.IsNotNull()) return new CacheUrlData { Url = urlReal, MenuItem = menu.Groups[j].MenuItems[z], MenuTop = menu };
                        }
                    }
                }
            }

            // Trong trường hợp url hiện tại không tìm được page thỏa mãn thì trả ra empty
            return null;
        }

        private string GetUrlReal(string urlGetten, MenuItem menuItem)
        {
            var urlTemp = menuItem.UrlVirtual.Replace("{int}", "([0-9]+)").Replace("{varchar}", "([^/]+)") + "." + Extension;
            var rex = new Regex("http://" + HttpContext.Current.Request.Url.Authority + "/" + urlTemp, RegexOptions.IgnoreCase);
            var match = rex.Match(urlGetten);

            //
            if (match.Success)
            {
                var urlReal = "/Main.aspx";
                return rex.Replace(urlGetten, urlReal);
            }

            return null;
        }

        public static CacheUrlData GetDataNoneExtension(string url, SessionType sessionType)
        {
            var moduleUrl = "/" + url + "." + AppSetting.Extension;
            var pathAndQuery = HttpContext.Current.Request.SplitUrl(moduleUrl, AppSetting.Extension);
            return GetData(pathAndQuery.T1, sessionType);
        }
    }
}
