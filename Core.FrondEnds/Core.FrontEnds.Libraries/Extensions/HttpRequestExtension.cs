using Core.Utility;
using System.Web;
using Core.Extensions;
using Core.Utility.Patterns;
using System.Text.RegularExpressions;

namespace Core.FrontEnds.Libraries.Extensions
{
    public static class HttpRequestExtension
    {
        public static string GetCurrentPath(this HttpRequest request) { return HttpContext.Current.Items["VirtualPath"].To<string>(); }

        public static Pair<string, string> GetCurrentUrlNotPaging(this HttpRequest request, string extension, bool queryInCludePage = false)
        {
            return request.GetCurrentUrlNotPaging(request.GetCurrentPath(), extension, queryInCludePage);
        }
        public static Pair<string, string> GetCurrentUrlNotPaging(this HttpRequest request, string url, string extension, bool queryInCludePage = false)
        {
            if (url.IsNull()) return new Pair<string, string> { };
            if (extension.IsNull()) return FindUrlChain.InstNoExtension.Find(url, extension, queryInCludePage);
            return FindUrlChain.Inst.Find(url, extension, queryInCludePage);
        }
    }

    public abstract class FindUrlChain : Chain<FindUrlChain>
    {
        protected abstract Pair<string, string> Match(string url, string extension, bool queryInCludePage);
        public Pair<string, string> Find(string url, string extension, bool queryInCludePage)
        {
            var result = Match(url, extension, queryInCludePage);
            if (result == null && Handler != null)
                result = Handler.Find(url, extension, queryInCludePage);
            return result;
        }
        public abstract class RegexChain : FindUrlChain
        {
            protected abstract string GetStringRegex(string extension);
            protected abstract Pair<string, string> GetResult(Match match, bool queryInCludePage);
            sealed protected override Pair<string, string> Match(string url, string extension, bool queryInCludePage)
            {
                var regex = new Regex(GetStringRegex(extension));
                var match = regex.Match(url);
                if (!match.Success) return null;
                return GetResult(match, queryInCludePage);
            }

            public class Page1Chain : RegexChain
            {
                protected override string GetStringRegex(string extension)
                {
                    return "(.*)/page-([0-9]+)." + extension + "?(.*)";
                }
                protected override Pair<string, string> GetResult(Match match, bool queryInCludePage)
                {
                    var url = match.Groups[1].Value;
                    var query = match.Groups[3].Value + (queryInCludePage ? "&page=" + match.Groups[2].Value : string.Empty);
                    return new Pair<string, string> { T1 = url, T2 = query };
                }
            }
            public class Page1NoExtensionChain : RegexChain
            {
                protected override string GetStringRegex(string extension)
                {
                    return "(.*)/page-([0-9]+)?(.*)";
                }
                protected override Pair<string, string> GetResult(Match match, bool queryInCludePage)
                {
                    var url = match.Groups[1].Value;
                    var query = match.Groups[3].Value + (queryInCludePage ? "&page=" + match.Groups[2].Value : string.Empty);
                    return new Pair<string, string> { T1 = url, T2 = query };
                }
            }

            public class Page2Chain : RegexChain
            {
                protected override string GetStringRegex(string extension)
                {
                    return "(.*)/page-([0-9]+)." + extension;
                }
                protected override Pair<string, string> GetResult(Match match, bool queryInCludePage)
                {
                    var url = match.Groups[1].Value;
                    return new Pair<string, string> { T1 = url, T2 = queryInCludePage ? "page=" + match.Groups[2].Value : string.Empty };
                }
            }
            public class Page2NoExtensionChain : RegexChain
            {
                protected override string GetStringRegex(string extension)
                {
                    return "(.*)/page-([0-9]+)";
                }
                protected override Pair<string, string> GetResult(Match match, bool queryInCludePage)
                {
                    var url = match.Groups[1].Value;
                    return new Pair<string, string> { T1 = url, T2 = queryInCludePage ? "page=" + match.Groups[2].Value : string.Empty };
                }
            }

            public class QueryChain : RegexChain
            {
                protected override string GetStringRegex(string extension)
                {
                    return "(.*)." + extension + "?(.*)";
                }
                protected override Pair<string, string> GetResult(Match match, bool queryInCludePage)
                {
                    return new Pair<string, string> { T1 = match.Groups[1].Value, T2 = match.Groups[2].Value };
                }
            }
            public class QueryNoExtensionChain : RegexChain
            {
                protected override string GetStringRegex(string extension)
                {
                    return "(.*)?(.*)";
                }
                protected override Pair<string, string> GetResult(Match match, bool queryInCludePage)
                {
                    return new Pair<string, string> { T1 = match.Groups[1].Value, T2 = match.Groups[2].Value };
                }
            }

            public class Normal : RegexChain
            {
                protected override string GetStringRegex(string extension)
                {
                    return "(.*)." + extension;
                }

                protected override Pair<string, string> GetResult(Match match, bool queryInCludePage)
                {
                    return new Pair<string, string> { T1 = match.Groups[1].Value };
                }
            }
            public class NormalNoExtension : RegexChain
            {
                protected override string GetStringRegex(string extension)
                {
                    return "(.*)";
                }

                protected override Pair<string, string> GetResult(Match match, bool queryInCludePage)
                {
                    return new Pair<string, string> { T1 = match.Groups[1].Value };
                }
            }
        }

        private static FindUrlChain inst = null;
        public static FindUrlChain Inst
        {
            get
            {
                if (inst == null)
                {

                    inst = new RegexChain.Page1Chain();
                    inst.SetHandler<RegexChain.Page2Chain>();
                    inst.SetHandler<RegexChain.QueryChain>();
                    inst.SetHandler<RegexChain.Normal>();
                }
                return inst;
            }
        }

        private static FindUrlChain instNoExtension = null;
        public static FindUrlChain InstNoExtension
        {
            get
            {
                if (instNoExtension == null)
                {
                    instNoExtension = new RegexChain.Page1NoExtensionChain();
                    instNoExtension.SetHandler<RegexChain.Page2NoExtensionChain>();
                    instNoExtension.SetHandler<RegexChain.QueryNoExtensionChain>();
                    instNoExtension.SetHandler<RegexChain.NormalNoExtension>();
                }
                return instNoExtension;
            }
        }
    }
}
