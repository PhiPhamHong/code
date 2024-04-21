using Core.Extensions;
using Core.Web.Api;
using System;
using System.Net.Http;
using System.Net.Http.Headers;


namespace Core.Sites.Libraries.Api
{
    public class ApiBase
    {
        private string baseUrl = string.Empty;
        public string BaseUrl
        {
            set
            {
                if ((baseUrl = value).IsNotNull())
                    Client.BaseAddress = new Uri(baseUrl);
            }
            get => baseUrl;
        }

        protected HttpClient Client { set; get; } = CreateClient();

        protected static HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        protected TResponse Call<TRequest, TResponse>(string api, TRequest request)
            where TResponse : ResponseBase
        {
            TResponse response = null;
            var responseMessage = Client.PostAsJsonAsync(api, request).GetAwaiter().GetResult();
            if (responseMessage.IsSuccessStatusCode)
                response = responseMessage.Content.ReadAsAsync<TResponse>().GetAwaiter().GetResult();
            return response;
        }
    }
}
