using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using SHttpClient = System.Net.Http.HttpClient;
using Core.Extensions;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
namespace Core.Utility.Spiders
{
    public class HttpClient
    {
        SHttpClient client = null;
        public SHttpClient Client
        {
            get { return client; }
        }
        CookieContainer Cookies = new CookieContainer();

        public HttpClient()
        {
            client = NewClient();
        }
        private SHttpClient NewClient()
        {
            var handler = new WebRequestHandler
            {
                AllowAutoRedirect = true,
                UseCookies = true,
                CookieContainer = Cookies,
            };

            handler.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            var client = new SHttpClient(handler);
            client.DefaultRequestHeaders.ExpectContinue = false;
            ServicePointManager.SecurityProtocol= (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072 | (SecurityProtocolType)SecurityProtocolType.Ssl3 | (SecurityProtocolType)SecurityProtocolType.Tls;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
            //ServicePointManager.CheckCertificateRevocationList = false;

            client.Timeout = new TimeSpan(0, 3, 0);

            ////set Accept headers
            //client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml,application/json");
            ////set User agent
            //client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; EN; rv:11.0) like Gecko");
            //client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");
            return client;
        }

        private Spider spider = new Spider();
        public Spider Spider
        {
            get { return spider; }
            set { spider = value; }
        }

        public void GetString(string url)
        {
            var task = client.GetAsync(url);
            task.Wait(client.Timeout);
            var response = task.Result;

            var task2 = response.Content.ReadAsStringAsync();
            task2.Wait(client.Timeout);
            spider.Html = task2.Result;
        }

        //private ConfiguredTaskAwaitable<HttpResponseMessage> PostHelper(string url, Dictionary<string, string> dic)
        //{
        //    //return client.SendAsync(new HttpRequestMessage 
        //    //{
        //    //    Content = new FormUrlEncodedContent(dic),
        //    //    Method = HttpMethod.Post,
                
        //    //}).ConfigureAwait(false);

        //    return client.PostAsync(url, new FormUrlEncodedContent(dic)).ConfigureAwait(false);
        //}

        public void Post(string url, Action<Dictionary<string, string>> aDic = null)
        {
            var dic = new Dictionary<string, string>();
            if (aDic != null) aDic(dic);

            //var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            //var task = client.PostAsync(url, new FormUrlEncodedContent(dic), cts.Token);
            var task = client.PostAsync(url, new FormUrlEncodedContent(dic));
            // task.Wait(client.Timeout);

            //Task.WhenAll(task);

            //task.RunSynchronously();
            
            var response = task.Result;

            //var res = PostHelper(url, dic);

            var task2 = response.Content.ReadAsStringAsync();
            task2.Wait(client.Timeout);
            spider.Html = task2.Result;
        }
        public void PostBack(string url, Action<Dictionary<string, string>> aDic = null)
        {
            Post(url, dic => 
            {
                spider.SelectList("input")
                      .Where(input => input.Attributes["name"] != null && input.Attributes["name"].Value.IsNotNull())
                      .ForEach(input => 
                      {
                          var value = input.Attributes["value"] == null ? null : input.Attributes["value"].Value;
                          dic[input.Attributes["name"].Value] = value;
                      });

                spider.SelectList("select")
                    .Where(input => input.Attributes["name"] != null && input.Attributes["name"].Value.IsNotNull())
                    .ForEach(select => 
                    {
                        var option = spider.SelectList(select, "option[selected]").FirstOrDefault();
                        if (option != null && option.Attributes["name"] != null && option.Attributes["name"].Value.IsNotNull())
                        {
                            var value = option.Attributes["value"] == null ? null : option.Attributes["value"].Value;
                            dic[select.Attributes["name"].Value] = value.IsNull() ? string.Empty : value;
                        }
                    });

                if (aDic != null) aDic(dic);
            });
        }

        public static HttpClient Start(string url)
        {
            var http = new HttpClient();
            http.GetString(url);
            return http;
        }
    }
}