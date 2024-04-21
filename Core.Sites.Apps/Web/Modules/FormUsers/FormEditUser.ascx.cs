using Core.Business.Entities;
using Core.Web.WebBase;
using Core.Sites.Libraries.Utilities.Sites;
namespace Core.Sites.Apps.Web.Modules.FormUsers
{
    public partial class FormEditUser : PortalModule<User>
    {
        protected string GetSubDomain() => Company.GetSubDomain(Entity.CompanyId);
    }
}