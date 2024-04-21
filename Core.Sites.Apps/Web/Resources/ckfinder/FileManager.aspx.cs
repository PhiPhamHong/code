using Core.Extensions;
using System.Web.UI;
namespace Core.Sites.Apps.Web.Resources.ckfinder
{
    public partial class FileManager : Page
    {
        protected string Type
        {
            get { return Request.QueryString["type"]; }
        }

        protected bool Multi
        {
            get { return Request.QueryString["multi"].To<bool>(); }
        }

        protected string With
        {
            get { return Request.QueryString["width"].WhenEmpty(() => "99%"); }
        }
    }
}