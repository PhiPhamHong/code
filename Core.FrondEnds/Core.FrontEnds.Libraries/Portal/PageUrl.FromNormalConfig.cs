using Core.FrontEnds.Libraries.Portal.Configs;
using Core.Utility;
using System.Text.RegularExpressions;
using Core.Extensions;
namespace Core.FrontEnds.Libraries.Portal
{
    public partial class PageUrl
    {
        public class FromNormalConfig : PageUrl
        {
            public override Pair<string, PageTag> GetPageTag()
            {
                foreach (var page in PagesConfig.Pages)
                {
                    foreach (var pageUrl in page.Urls)
                    {
                        var urlTemp = pageUrl.ViturlPath.Replace(INT, N09).Replace(VARCHAR, VC) + DOT + Extension;
                        var rex = new Regex(urlTemp, RegexOptions.IgnoreCase);

                        var match = rex.Match(Url);

                        // Nếu match thành công thì tìm ra url thật cần rewrite + pageTag config
                        if (match.Success)
                            return new Pair<string, PageTag>
                            {
                                T1 = rex.Replace(Url, MAINPAGE.Frmat(page.Master.IsNull() ? MAIN : page.Master, pageUrl.Real, page.Site)),
                                T2 = page
                            };
                    }
                }

                return null;
            }

            private const string INT = "{int}";
            private const string N09 = "([0-9]+)";
            private const string VARCHAR = "{varchar}";
            private const string VC = "([^/]+)";
            private const string DOT = ".";
        }

        private const string MAINPAGE = "/{0}.aspx?{1}&site={2}";
        private const string MAIN = "Main";
    }
}
