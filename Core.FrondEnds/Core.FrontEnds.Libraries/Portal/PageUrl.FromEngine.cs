using Core.FrontEnds.Libraries.Portal.Configs;
using Core.Utility;
using System.Web;
using Core.FrontEnds.Libraries.Extensions;
using Core.Extensions;
namespace Core.FrontEnds.Libraries.Portal
{
    public partial class PageUrl
    {
        public class FromEngine : PageUrl
        {
            protected virtual Pair<string, string> GetPath()
            {
                return HttpContext.Current.Request.GetCurrentUrlNotPaging(Url, Extension, true);
            }

            public override Pair<string, PageTag> GetPageTag()
            {
                var urlInfo = GetPath();

                if (urlInfo.T1 == null) { urlInfo.T1 = "/home-en"; urlInfo.T2 = ""; }

                var path = urlInfo.T1.TrimStart('/');

                // Trường hợp không tìm được Page nào thì chuyển xuống engine tìm url, các engine được config ngay tại các PageTag nếu có            
                foreach (var p in PagesConfig.Pages)
                {
                    var query = UrlEngine.FindQuery(p, path);
                    if (query.IsNotNull())
                    {
                        return new Pair<string, PageTag>
                        {
                            //T1 = "/" + (p.Master.IsNull() ? "Main" : p.Master) + ".aspx?" + query + "&site=" + p.Site + urlInfo.T2.TrimStart('?'),
                            T1 = MAINPAGE.Frmat(p.Master.IsNull() ? MAIN : p.Master, query, p.Site + urlInfo.T2.TrimStart('?')),
                            T2 = p
                        };
                    }
                }

                return null;
            }
        }
    }
}
