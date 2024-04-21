using Core.DataBase.ADOProvider;
using Core.Extensions;
using Core.FrontEnds.Libraries.Web;

namespace Core.FrontEnds.Libraries
{
    public class FeUrl
    {
        public static string Extension = Setting.Extension.IsNull() ? string.Empty : ("." + Setting.Extension);

        public static string SourceUrl(string path)
        {
            return Setting.ServerImage + "/" + path;
        }
        public static string GetUrl(IAliasUrl item, int id) { return GetUrl(item.Alias + "-" + id); }
        public static string GetUrl(IAliasUrl item) { return GetUrl(item.Alias); }
        public static string GetUrl(IAliasUrl item, int pageIndex, string keyword) { return GetUrl(item.Alias, pageIndex, keyword); }

        public static string GetUrl(string alias) { return "/" + alias + Extension; }
        public static string GetUrl(string alias, int pageIndex, string keyword)
        {
            var url = $"/{alias}";
            if (pageIndex > 1) url += $"/page-{pageIndex}";
            url += Extension;
            if (keyword.IsNotNull()) url += $"?q={keyword}";
            return url;
        }

        public static string Get(string prefix)
        {
            return FeContext.UrlContext.GetLink(prefix);
        }
    }
}
