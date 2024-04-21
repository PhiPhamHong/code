using Core.Sites.Libraries.Business;
using Core.Web.WebBase;

namespace Core.Sites.Libraries.Utilities
{
    public class AjaxRequireHasPermissionAttribute : AjaxRequestConditionAttribute
    {
        private int[] permissions = null;
        public override object[] DataFormats => null;
        public AjaxRequireHasPermissionAttribute(params int[] permissions)
        {
            this.permissions = permissions;
        }

        public override bool Condition
        {
            get { return PortalContext.Session.IsLoging && PortalContext.Session.HasPermission(permissions); }
        }

        public override string Msg
        {
            get { return "Bạn không có quyền thực hiện chức năng này"; }
        }
    }
}
