using System.Web;
using System.Web.SessionState;
using Core.Extensions;
using System.Web.UI;
using System;
namespace Core.Web.WebBase
{
    /// <summary>
    /// Class Rewrite Url Base
    /// </summary>
    public class RewriteBase : IHttpHandlerFactory, IRequiresSessionState
    {
        /// <summary>
        /// Lấy ra đường link đang thực hiện request
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetUrl(HttpContext context)
        {
            if (context.Request.Url.Query != string.Empty)
                if (context.Request.Url.Query.Length > 0)
                {
                    context.Items["VirtualUrl"] = context.Request.Path + context.Request.Url.Query;
                    context.Items["VirtualQuery"] = context.Request.Url.Query;
                    context.Items["VirtualPath"] = context.Request.Path;
                }

            if (context.Items["VirtualUrl"] == null)
            {
                context.Items["VirtualUrl"] = context.Request.Path;
                context.Items["VirtualPath"] = context.Request.Path;
            }

            // var url = context.Request.Url.AbsolutePath;
            var url = context.Request.RawUrl;

            while (url.EndsWith("/") && !url.IsNull())
                url = url.Substring(0, url.Length - 1);

            url = "http://" + HttpContext.Current.Request.Url.Authority + url;

            return url;
        }

        /// <summary>
        /// Thực hiện Request
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requestType"></param>
        /// <param name="url1"></param>
        /// <param name="pathTranslated"></param>
        /// <returns></returns>
        public IHttpHandler GetHandler(HttpContext context, string requestType, string url1, string pathTranslated)
        {
            // Lấy ra Url đang thực hiện request
            var url = GetUrl(context);

            // Map lấy ra url thật
            // var rewrite = GetMatchingRewrite(url, context.Request.Path);
            var rewrite = GetMatchingRewrite(url, url1);

            // Nếu không lấy được thì trả url có nội dung rỗng
            if (rewrite.IsNull())
                rewrite = "/Services/Empty.aspx";

            // Lấy các QueryString
            var newFilePath = rewrite.IndexOf("?") > 0 ? rewrite.Substring(0, rewrite.IndexOf("?")) : rewrite;

            foreach (var k in context.Request.QueryString.AllKeys)
                rewrite += "&{0}={1}".Frmat(k, context.Request.QueryString[k]);

            // Rewrite lại đường link
            context.RewritePath(rewrite);

            var html = HttpRuntime.Cache[context.Request.RawUrl];
            if(html != null)
            {
                context.Response.Write(html);
                newFilePath = "/Services/Empty.aspx";
            }

            // 
            return PageParser.GetCompiledPageInstance(newFilePath, context.Server.MapPath(newFilePath), context);
        }

        /// <summary>
        /// Mở ra phương thức lấy đường link thật từ đường link ảo
        /// </summary>
        /// <param name="urlGetten"></param>
        /// <returns></returns>
        public virtual string GetMatchingRewrite(string urlGetten, string url1)
        {
            throw new Exception("Chưa viết lại hàm GetMatchingRewrite khi kế thừa RewriteBase");
        }

        public void ReleaseHandler(IHttpHandler handler)
        {

        }
    }

    //public class UrlTest : IHttpModule
    //{
    //    void IHttpModule.Dispose()
    //    {
            
    //    }

    //    void IHttpModule.Init(HttpApplication context)
    //    {
    //        context.BeginRequest -= BeginRequest;
    //        context.BeginRequest += BeginRequest;
    //    }

    //    /// <summary>
    //    /// Event handler for the "BeginRequest" event.
    //    /// </summary>
    //    /// <param name="sender">The sender object</param>
    //    /// <param name="args">Event args</param>
    //    private static void BeginRequest(object sender, EventArgs args)
    //    {
    //        // Add our PoweredBy header
    //        // HttpContext.Current.Response.AddHeader(Constants.HeaderXPoweredBy, Configuration.XPoweredBy);    
    //        //HttpContext.Current.RewritePath("/Services/Empty.aspx");
    //    } 
    //}
}
