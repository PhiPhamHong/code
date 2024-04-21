using Core.DataBase.ADOProvider;
using Core.Extensions;
using Core.Web.Extensions;
using System.Web;
using System.Linq;
using System;

namespace Core.FrontEnds.Libraries.Web
{
    public partial class FeContext
    {
        private static string js = "<script async type=\"text/javascript\" src=\"{0}/Projects/{1}/Resources/js/min.js?&v={2}&site={3}&sites={4}\"></script>";
        private static string css = "<link type=\"text/css\" rel=\"Stylesheet\" href=\"{0}/Projects/{1}/Resources/css/min.css?&v={2}&site={3}&sites={4}\" />";

        /// <summary>
        /// Tạo link js, css 
        /// </summary>
        public static string CreateLinkJs(object site)
        {
            return js.Frmat(Setting.StaticDomain, Setting.Project, Setting.Version, site, string.Empty); //+ CreateLinkCss(site, "all");                   
        }
        public static string CreateLinkCss(object site, string media)
        {
            return css.Frmat(Setting.StaticDomain, Setting.Project, Setting.Version, site, string.Empty);
        }
        public static string GetResourceImage(string path)
        {
            return "/Projects/" + Setting.Project + "/Resources/images/" + path;
        }

        /// <summary>
        /// Get set to Context
        /// </summary>
        public static T Get<T>(Func<T> func, string key) where T : class
        {
            T t = Get<T>(key);
            if (t == null) Set(t = func(), key);
            return t;
        }
        public static T Get<T>(string key) where T : class { return HttpContext.Current.Items[key] as T; }
        public static void Set<T>(T value, string key) { HttpContext.Current.Items[key] = value; }
        public static T GetParam<T>(string key, T @default) { return HttpContext.Current.Request.Query(key, @default); }
        public static T GetParam<T>(string key) { return HttpContext.Current.Request.Query(key, default(T)); }
        public static string GetParam(string key) { return GetParam<string>(key); }
        public class Image
        {
            public static string Logo = GetResourceImage("logo.png");
            public static string NoAvatar = GetResourceImage("noavatar.png");
            public static string NoImage = GetResourceImage("noimage.png");
        }
        public class Page
        {
            public static void SetKeyword(string keyword) { HttpContext.Current.Items[Linkit_PageKeyword] = keyword; }
            public static void SetDescription(string description) { HttpContext.Current.Items[Linkit_PageDescription] = description; }
            public static void SetMetaImage(string image) { HttpContext.Current.Items[Linkit_MetaImage] = image; }
            public static void SetTitle(string title) { HttpContext.Current.Items[Linkit_PageTitle] = title; }
            public static void SetCanonical(string url) { HttpContext.Current.Items[Linkit_Canonical] = url; }
            public static void SetPublishedTime(DateTime date) { HttpContext.Current.Items[Linkit_PublishedTime] = date; }
            public static void SetMetaTags(string tags) { HttpContext.Current.Items[Linkit_Tags] = tags; }
            public static void SetMetaSeeAlso(string seeAlso) { HttpContext.Current.Items[Linkit_SeeAlso] = seeAlso; }

            public const string Linkit_PageTitle = "Linkit_PageTitle";
            public const string Linkit_Canonical = "Linkit_Canonical";
            public const string Linkit_PageKeyword = "Linkit_PageKeyword";
            public const string Linkit_PublishedTime = "Linkit_PublishedTime";
            public const string Linkit_SeeAlso = "Linkit_SeeAlso";
            public const string Linkit_Tags = "Linkit_Tags";
            public const string Linkit_PageDescription = "Linkit_PageDescription";
            public const string Linkit_MetaImage = "Linkit_MetaImage";
            public const string Link_Template = "{0}://{1}{2}";

            public static void SetPageMeta(IPageMeta meta)
            {
                if (meta == null) return;
                SetTitle(meta.Title);
                SetKeyword(meta.MetaKeywords);
                SetDescription(meta.MetaDescription);
                SetMetaImage(meta.Image);
            }
            public static void SetPageMeta(params IPageMeta[] metas)
            {
                SetTitle(metas.Where(m => m.Title.IsNotNull()).JoinString(s => s, "-"));
                SetKeyword(metas.Where(m => m.MetaKeywords.IsNotNull()).JoinString(s => s, "-"));
                SetDescription(metas.Where(m => m.MetaDescription.IsNotNull()).JoinString(s => s, "-"));
                SetMetaImage(metas.Where(m => m.Image.IsNotNull()).Select(m => m.Image).FirstOrDefault());
            }

            public static string CurrentUrl() { return GetFullUrl(HttpContext.Current.Request.RawUrl); }
            public static string GetFullUrl(string url)
            {
                var uri = HttpContext.Current.Request.Url;
                return Link_Template.Frmat(uri.Scheme, uri.Authority, url);
            }
        }
    }
}
