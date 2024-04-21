using Core.Utility;
using Core.Web;
using System.Web;
using Core.Extensions;
namespace Core.FrontEnds.Libraries.Web
{
    public class FeGlobal : IGlobal
    {
        public void Application_BeginRequest()
        {
            var request = HttpContext.Current.Request;

            var extension = request.CurrentExecutionFilePathExtension;
            var path = request.Path;

            foreach (var k in request.QueryString.AllKeys)
                FeContext.Set(request.QueryString[k], "qs_" + k);

            if (extension.IsNull())
            {
                if (path == "/") path = FeContext.UrlContext.GetLink("Home", FeContext.DefaultLanguageId);
                Singleton<RewriteNoneExtension>.Inst.GetHandler(HttpContext.Current, string.Empty, path, string.Empty);
            }
        }

        public void Application_Start()
        {

        }
    }
}
