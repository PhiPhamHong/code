using Core.FrontEnds.Libraries.Portal;
using Core.Extensions;
namespace Core.FrontEnds.Libraries.Web.Authenticate
{
    public class ModuleLoginRequireAttribute : Module.ConditionAttribute
    {
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