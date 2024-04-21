using System.Text.RegularExpressions;
using Core.Sites.Libraries.Business;
using Core.Web.WebBase;
using Core.Extensions;
using System.Web;
namespace Core.Sites.Libraries.Utilities.Sites
{
    public class RewriteAspx : RewriteBase
    {
        public override string GetMatchingRewrite(string urlGetten, string url1)
        {
            PortalContext.CurrentPage = PortalContext.Page.GetPage(urlGetten, PortalContext.SessionType);
            if (PortalContext.CurrentPage.UrlData != null) return PortalContext.CurrentPage.UrlData.Url;

            return UrlPreviewTourProduct(urlGetten);
        }

        private static Regex rexPreviewTourProduct = new Regex("([^/]+)-([0-9]+)");
        protected string UrlPreviewTourProduct(string urlGetten)
        {
            var match = rexPreviewTourProduct.Match(urlGetten
                .Replace("http://" + HttpContext.Current.Request.Url.Authority, string.Empty)
                .Replace("." + AppSetting.Extension, string.Empty));
            if (!match.Success) return string.Empty;

            var productId = match.Groups[2].Value.To<int>();

            return "/Web/Projects/ViTravel/Modules/FormTourOrderProducts/Preview.aspx?ProductId=" + productId;
        }
    }
}
