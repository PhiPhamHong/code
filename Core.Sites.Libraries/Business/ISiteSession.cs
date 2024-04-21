using Core.Web.WebBase;
using System.Collections.Generic;
using System.Linq;
namespace Core.Sites.Libraries.Business
{
    public interface ISiteSession
    {
        IMemberSession IAccountInfo { get; }
        List<int> GetPermissionsCanAssignForCompany(int companyId);
        bool HasPermission(params int[] permissions);
        bool IsLoging { get; }
        bool Authen(string userName, string password);
        void ExtendTimeCookie();
        void SignOut();
    }

    public class SiteSession<TMemberSession> : AccountSession<TMemberSession>, ISiteSession where TMemberSession : class, IMemberSession, new()
    {
        public IMemberSession IAccountInfo
        {
            get { return AccountInfo; }
        }

        public List<int> GetPermissionsCanAssignForCompany(int companyId)
        {
            return CompanyHelper.GetPermissionOfCompany(companyId)
                                .Join(AccountInfo.Permissions(), cp => cp.PermissionId, p => p, (cp, p) => p).ToList();
        }

        public bool HasPermission(params int[] permissions)
        {
            return AccountInfo.Permissions().Join(permissions, p => p, p => p, (p1, p2) => true).Any();
        }
    }
}