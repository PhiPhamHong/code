using System;
using System.Collections.Generic;
using System.Web.Http;
using Core.Attributes;
using Core.Extensions;
using Core.Utility.IO;
using Newtonsoft.Json;

namespace Core.Web.Api
{
    public abstract class CoreApiController<TRequest, TResponse> : ApiController
        where TRequest : class, new()
        where TResponse : CoreApiController<TRequest, TResponse>.ResponseBase, new()
    {
        public string Do([FromBody] Message info)
        {
            var response = new TResponse();
            try
            {
                FileHelper.WriteLog(this.GetType().FullName, info.Param, "ApiLog", this.GetType().FullName, true);

                var request = info.Param.Deserialize<TRequest>();
                FillResponse(request, response);
                response.Ok = true;
            }
            catch(Exception ex)
            {
                response.Ok = false;
                response.Msg = ex.Message;
            }

            return response.SerializeToString();
        }

        protected abstract void FillResponse(TRequest request, TResponse response);

        public class Message
        {
            public string Param { set; get; }
        }

        public class ResponseBase
        {
            [PropertyIndex(Index = -2)]
            public bool Ok { set; get; }

            [PropertyIndex(Index = -1)]
            public string Msg { set; get; }
        }
    }

    public abstract class CoreApiController2<TRequest, TResponse> : ApiController
        where TRequest : class, new()
        where TResponse : CoreApiController2<TRequest, TResponse>.ResponseBase, new()
    {
        public string Do([FromBody] Message info)
        {
            var response = new TResponse();
            try
            {
                var request = info.Param.JsonToObject<TRequest>();

                FillResponse(request, response);
            }
            catch (Exception ex)
            {
                response.Ok = false;
                response.Msg = ex.Message;
            }
            return JsonConvert.SerializeObject(response);
        }

        protected abstract void FillResponse(TRequest request, TResponse response);

        public class Message
        {
            [JsonProperty("p")]
            public string Param { set; get; }
        }

        public class ResponseBase
        {
            [PropertyIndex(Index = -2)]
            public bool Ok { set; get; }

            [PropertyIndex(Index = -1)]
            public string Msg { set; get; }
        }
    }

    public class ResponseBase
    {
        [PropertyIndex(Index = -2)]
        public bool Ok { set; get; }

        [PropertyIndex(Index = -1)]
        public string MessageError { set; get; }

        public Dictionary<string, object> Data { set; get; } = new Dictionary<string, object> { };
    }
}