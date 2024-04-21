using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Web;
using System.Web.Caching;
namespace Core.Web.Resources
{
    /// <summary>
    /// Xử lý Resource Base
    /// </summary>
    public abstract class HandlerResourceBase : IHttpHandler
    {
        private bool doGzip = true;
        /// <summary>
        /// Có thực hiện Gzip hay không
        /// </summary>
        protected bool DoGzip
        {
            set { doGzip = value; }
            get { return doGzip; }
        }

        private TimeSpan cacheDuration = TimeSpan.FromDays(30);
        /// <summary>
        /// Thời gian Cache
        /// Mặc định là 30 phút
        /// </summary>
        protected TimeSpan CacheDuration
        {
            set { cacheDuration = value; }
            get { return cacheDuration; }
        }

        private bool allowCacheDependency
        {
            get
            {
                return HttpContext.Current.Request.Params["SERVER_NAME"] != "localhost";
            }
        }

        /// <summary>
        /// Set ContentType
        /// </summary>
        public string GetType(HandlerType handlerType)
        {
            switch (handlerType)
            {
                case HandlerType.Css: return "text/css";
                case HandlerType.Js:return "text/javascript";
            }

            return string.Empty;
        }

        protected abstract HandlerType ContentType { get; }


        /// <summary>
        /// Thực hiện xử lý request
        /// </summary>
        public void ProcessRequest(HttpContext context)
        {
            // Thiết lập ContentType
            context.Response.ContentType = GetType(ContentType);

            // Kiểm tra xem có thiết lập nén và request có thể thực hiện gzip hay không
            bool isCompressed = DoGzip && CanGZip(context.Request);

            // Version
            string version = context.Request["v"];

            // Nếu nội dung từ cache để truyền xuống client không có thì thực hiện lấy lại
            if (!WriteFromCache(context, version, isCompressed))
            {
                using (var memoryStream = new MemoryStream(5000))
                {
                    using (var writer = isCompressed ? (Stream)(new GZipStream(memoryStream, CompressionMode.Compress)) : memoryStream)
                    {
                        // Nội dung file
                        var fileBytes = new UTF8Encoding(false).GetBytes(GetResource());

                        // Ghi vào stream
                        writer.Write(fileBytes, 0, fileBytes.Length);
                    }
                    // Cache and generate response
                    byte[] responseBytes = memoryStream.ToArray();

                    // Sau khi ghi được dữ liệu xuống response rồi thì kiểm tra xem có config là có thực hiện cache không
                    // Có thì lưu lại trong cache
                    if (allowCacheDependency)
                        context.Cache.Insert(GetCacheKey(version, isCompressed), responseBytes, null, Cache.NoAbsoluteExpiration, CacheDuration);

                    // Ghi vào response
                    WriteBytes(responseBytes, context, isCompressed);
                }
            }
            context.Response.Flush();
        }

        /// <summary>
        /// Phương thức để lớp con kế thừa để viết lại nội dung request
        /// </summary>
        public virtual string GetResource()
        {
            return string.Empty;
        }

        /// <summary>
        /// Kiểm xem có thể Gzip được không
        /// </summary>
        private bool CanGZip(HttpRequest request)
        {
            string acceptEncoding = request.Headers["Accept-Encoding"];
            if (!string.IsNullOrEmpty(acceptEncoding) && (acceptEncoding.Contains("gzip") || acceptEncoding.Contains("deflate")))
                return true;
            return false;
        }
        private bool WriteFromCache(HttpContext context, string version, bool isCompressed)
        {
            //return false; //bodoan nay khi release
            if (!allowCacheDependency) return false;

            // Đọc dữ liệu từ cache ra
            var responseBytes = context.Cache[GetCacheKey(version, isCompressed)] as byte[];

            // nếu không có thì trả ra false
            if (null == responseBytes) return false;

            // nếu có thì ghi xuống response và trả ra true
            WriteBytes(responseBytes, context, isCompressed);

            // return true
            return true;
        }

        private void WriteBytes(byte[] bytes, HttpContext context, bool isCompressed)
        {
            // Lấy ra response 
            var response = context.Response;

            // Gắn các Header
            response.AppendHeader("Content-Length", bytes.Length.ToString());

            // Thiết lập contentType
            response.ContentType = GetType(ContentType);

            // tạo header gzip nếu nén được
            if (isCompressed) response.AppendHeader("Content-Encoding", "gzip");

            // Thiết lập cache cho response
            response.Cache.SetCacheability(HttpCacheability.Public);
            response.Cache.SetExpires(DateTime.Now.Add(CacheDuration));
            response.Cache.SetMaxAge(CacheDuration);
            response.Cache.AppendCacheExtension("must-revalidate, proxy-revalidate");

            // Ghi vào stream response
            response.OutputStream.Write(bytes, 0, bytes.Length);
            response.Flush();
        }

        private string GetCacheKey(string version, bool isCompressed)
        {
            return "CssHandler." + version + "." + isCompressed + GetType(ContentType) + GetType().FullName + "." + HttpContext.Current.Request.QueryString["site"];
        }

        public enum HandlerType
        {
            Css = 0,
            Js = 1
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}
