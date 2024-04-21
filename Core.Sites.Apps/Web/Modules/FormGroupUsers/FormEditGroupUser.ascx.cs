using Core.Business.Entities;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Web.WebBase;

namespace Core.Sites.Apps.Web.Modules.FormGroupUsers
{
    public partial class FormEditGroupUser : PortalModule<GroupUser>, IAjax
    {
        protected override void OnInitData()
        {
            this.SetData("Leaders", new GroupUser.Leader { }.GetDetails(Entity.GroupId));
        }
    }
}