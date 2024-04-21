using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using SWebRequest = System.Net.WebRequest;
using Core.Extensions;
namespace Core.Utility.Spiders
{
    public class WebRequest
    {
        CookieContainer cookies = new CookieContainer();
        private string content = string.Empty;
        public string Content
        {
            get { return content; }
        }
        private string Crawler(string url, Action<HttpWebRequest> withRequest = null)
        {
            var httpRequest = (HttpWebRequest)SWebRequest.Create(url);
            httpRequest.CookieContainer = cookies;
            httpRequest.KeepAlive = false;
            httpRequest.PreAuthenticate = true;
            httpRequest.ProtocolVersion = HttpVersion.Version11;
            httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.3; rv:36.0) Gecko/20100101 Firefox/36.0";

            if (withRequest != null) withRequest(httpRequest);

            using (var response = (HttpWebResponse)httpRequest.GetResponse())
            {
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    return sr.ReadToEnd();
                }
            }
        }
        public WebRequest Get(string url, Action<HttpWebRequest> withRequest = null)
        {
            content = Crawler(url, withRequest);
            spider.Html = content;
            return this;
        }
        public WebRequest NextPost(string url, Action<Dictionary<string, string>> dicData = null, Action<HttpWebRequest> withRequest = null)
        {
            return Get(url, request =>
            {
                var inputs = spider.SelectList("input,select");

                var dic = new Dictionary<string, string>();

                inputs.Where(input => input.Attributes["name"] != null && input.Attributes["name"].Value.IsNotNull() &&
                                input.Attributes["value"] != null && input.Attributes["value"].Value.IsNotNull())
                                .ForEach(input => dic[input.Attributes["name"].Value] = input.Attributes["value"].Value);

                if (dicData != null) dicData(dic);

                var postData = dic.JoinString(kv => kv.Key + "=" + kv.Value, "&");

                var data = Encoding.ASCII.GetBytes(postData);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                if (withRequest != null) withRequest(request);

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            });
        }
        private Spider spider = new Spider();
        public Spider Spider
        {
            get { return spider; }
        }

        public static WebRequest Start(string url, Action<HttpWebRequest> withRequest = null)
        {
            return new WebRequest { }.Get(url, withRequest);
        }
    }
}