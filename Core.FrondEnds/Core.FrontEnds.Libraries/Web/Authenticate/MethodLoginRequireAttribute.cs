using Core.Web.WebBase;
using Core.Extensions;
namespace Core.FrontEnds.Libraries.Web.Authenticate
{
    public class MethodLoginRequireAttribute : AjaxRequestConditionAttribute
    {
        public override object[] DataFormats => null;
        public override bool Condition
        {
            get { return FeContext.Session.IsLoging; }
        }

        public override string Msg
        {
            get { return "Vui lòng đăng nhập để thực hiện chức năng này".Translate(); }
        }
    }
}
