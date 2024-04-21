using Core.FrontEnds.Libraries.Images;
using Core.Utility;
using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Linq;
namespace Core.FrontEnds.Libraries.Web
{
    public class Page404 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var path = Request.RawUrl.Split('?').FirstOrDefault();
            var extension = Path.GetExtension(path);
            switch (extension)
            {
                case ".jpg":
                case ".png": Singleton<ImageHandler>.Inst.ProcessRequest(HttpContext.Current); break;
                case ".js":
                    if (path == "/Projects/" + Setting.Project + "/Resources/js/min.js") Singleton<Resource.Js>.Inst.ProcessRequest(HttpContext.Current);
                    break;
                case ".css":
                    if (path == "/Projects/" + Setting.Project + "/Resources/css/min.css") Singleton<Resource.Css>.Inst.ProcessRequest(HttpContext.Current);
                    break;
            }
        }
    }
}
