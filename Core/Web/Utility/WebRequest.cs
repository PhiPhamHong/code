using System.IO;
using System.IO.Compression;
using System.Net;
using System.Web;
using WebRequestNet = System.Net.WebRequest;
namespace Core.Web.Utility
{
    public class WebRequest
    {
        public static string Download(string fileNeedDownload, string folder)
        {
            var file = fileNeedDownload.Replace("http://", string.Empty).Replace("https://", string.Empty);
            file = folder.TrimEnd('/') + "/" + file.TrimStart('/');

            var fileRoot = HttpContext.Current.Server.MapPath(file);
            if (File.Exists(fileRoot)) return file;

            folder = Path.GetDirectoryName(fileRoot);
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            var httpRequest = (HttpWebRequest)WebRequestNet.Create(fileNeedDownload);
            httpRequest.KeepAlive = false;
            httpRequest.ProtocolVersion = HttpVersion.Version10;
            httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.3; rv:36.0) Gecko/20100101 Firefox/36.0";

            using (var output = File.OpenWrite(fileRoot))
            {
                using (var response = (HttpWebResponse)httpRequest.GetResponse())
                {
                    using (var responseStream = httpRequest.GetResponse().GetResponseStream())
                    {
                        if (response.ContentEncoding.ToLower().Contains("gzip"))
                        {
                            var responseStreamGZip = new GZipStream(responseStream, CompressionMode.Decompress);
                            responseStreamGZip.CopyTo(output);
                        }
                        else
                            responseStream.CopyTo(output);
                    }
                }
            }

            return file;
        }
    }
}
