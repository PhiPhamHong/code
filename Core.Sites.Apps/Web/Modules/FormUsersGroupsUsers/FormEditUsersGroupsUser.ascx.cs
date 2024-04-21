using Core.Business.Entities;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Web.WebBase;

namespace Core.Sites.Apps.Web.Modules.FormUsersGroupsUsers
{
    public partial class FormEditUsersGroupsUser : PortalModule<GroupUser.User>, IAjax
    {
        public int CompanyId
        {
            get { return this.Query<int>("CompanyId"); }
        }
    }
}