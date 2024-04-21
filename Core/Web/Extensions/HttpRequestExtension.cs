using System.Text.RegularExpressions;
using System.Web;
using System.Linq;
using Core.Extensions;
using Core.Utility;
using System.Net;
namespace Core.Web.Extensions
{
    public static class HttpRequestExtension
    {
        public static bool HasParam(this HttpRequest request, string param) { return request.Params.AllKeys.Contains(param); }
        public static T Query<T>(this HttpRequest request, string key, T @default = default(T)) { return request.Params[key].To(@default); }
        public static T Get<T>(this HttpRequest request, bool ignoreCase) where T : new() { return Model<T>.Parse(request.Params, ignoreCase); }
        public static void ParseTo(this HttpRequest request, object obj, bool ignoreCase) { obj.Parse(request.Params, ignoreCase); }
        public static T ParseWithValidate<T>(this HttpRequest request, bool validateFullProperties) where T : new() => Model<T>.ParseWithValidate(request.Params, validateFullProperties);
        public static T Parse<T>(this HttpRequest request) where T : new() { return Model<T>.Parse(request.Params, false); }
        public static string GetCurrentUrl(this HttpRequest request) { return HttpContext.Current.Items["VirtualUrl"].To<string>(); }
        public static string GetCurrentPath(this HttpRequest request) { return HttpContext.Current.Items["VirtualPath"].To<string>(); }
        public static Pair<string, string> SplitUrl(this HttpRequest request, string extension) { return request.SplitUrl(request.GetCurrentUrl(), extension); }
        public static Pair<string, string> SplitUrl(this HttpRequest request, string url, string extension)
        {
            if (url.IsNull()) return new Pair<string, string> { };

            var query = string.Empty;
            var rg = new Regex("(.*)." + extension + "?(.*)");
            var match = rg.Match(url);

            if (match.Success)
            {
                url = match.Groups[1].Value;
                query = match.Groups[2].Value;
            }
            else
            {   
                rg = new Regex("(.*)." + extension);
                match = rg.Match(url);
                if (match.Success)
                    url = match.Groups[1].Value;
            }

            // T1 là url không chứa page, T2 là query
            return new Pair<string, string> { T1 = "http://" + HttpContext.Current.Request.Url.Authority + url + "." + extension, T2 = query };
        }

        public static string GetVisitorIPAddress(this HttpRequest request, bool GetLan = false)
        {
            string visitorIPAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(visitorIPAddress))
                visitorIPAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            if (string.IsNullOrEmpty(visitorIPAddress))
                visitorIPAddress = HttpContext.Current.Request.UserHostAddress;

            if (string.IsNullOrEmpty(visitorIPAddress) || visitorIPAddress.Trim() == "::1")
            {
                GetLan = true;
                visitorIPAddress = string.Empty;
            }

            //string visitorIPAddress = string.Empty;

            if (GetLan)
            {
                if (string.IsNullOrEmpty(visitorIPAddress))
                {   
                    var stringHostName = Dns.GetHostName();
                    var ipHostEntries = Dns.GetHostEntry(stringHostName);
                    var arrIpAddress = ipHostEntries.AddressList;

                    try
                    {
                        visitorIPAddress = arrIpAddress[arrIpAddress.Length - 1].ToString();
                    }
                    catch
                    {
                        try
                        {
                            visitorIPAddress = arrIpAddress[1].ToString();
                        }
                        catch
                        {
                            try
                            {
                                arrIpAddress = Dns.GetHostAddresses(stringHostName);
                                visitorIPAddress = arrIpAddress[1].ToString();
                            }
                            catch
                            {
                                visitorIPAddress = "127.0.0.1";
                            }
                        }
                    }
                }
            }
            return visitorIPAddress;
        }
    }
}