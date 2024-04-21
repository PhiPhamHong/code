using Core.Sites.Libraries;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Utility;
using System;
using System.IO;
using System.Web;
using System.Web.UI;
namespace Core.Sites.Apps.Services
{
    public partial class Error404 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var extension = Path.GetExtension(Request.RawUrl).TrimStart('.');
            
            if (extension == AppSetting.Extension)
            {
                Singleton<RewriteAspx>.Inst.GetHandler(HttpContext.Current, string.Empty, Request.RawUrl, string.Empty);
            }
        }
    }
}