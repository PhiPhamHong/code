using Core.Extensions;
using Core.Web.WebBase;
using System.Web;

namespace Core.FrontEnds.Libraries.Portal
{
    public abstract class RewritePortal : RewriteBase
    {
        public abstract string Extension { get; }

        /// <summary>
        /// Convert đường link ảo ra đường link thật
        /// </summary>
        /// <param name="urlGetten"></param>
        /// <returns></returns>
        public override string GetMatchingRewrite(string urlGetten, string url1)
        {
            // Thiết lập Url để lấy Url Real từ Cache
            var cacheUrl = GetType().GetAttribute<TargetCacheUrlAttribute>().GetCacheUrl();
            cacheUrl.Extension = Extension;
            cacheUrl.Url = url1;

            // return Url thực từ cache
            var cacheEntry = cacheUrl.Get();
            if (cacheEntry != null)
            {
                HttpContext.Current.Items["PageTag"] = cacheEntry.T2;
                return cacheEntry.T1;
            }

            return null;
        }
    }
}
