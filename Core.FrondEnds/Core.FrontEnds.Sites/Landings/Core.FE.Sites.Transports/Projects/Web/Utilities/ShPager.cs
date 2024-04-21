using Core.FrontEnds.Libraries.Web;
namespace Core.FE.Sites.Transports.Projects.Web.Utilities
{
    public class ShPager : Pager.Number
    {
        protected override string BEGIN => "<div class=\"pagination\"><ul>";
        protected override string END => "</ul></div>";
        protected override string CURRENT => "<li class=\"active\"><a>{0}</a></li>";
        protected override string PREVIOUS => "<li class=\"\"><a href=\"{0}\">«</a></li>";
        protected override string NEXT => "<li><a  href=\"{0}\">»</a></li>";
        protected override string LINK => "<li><a href=\"{1}\">{0}</a></li>";
    }
}