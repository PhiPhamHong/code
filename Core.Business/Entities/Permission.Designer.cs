using Core.Business.Enums;
using System.Collections.Generic;
using System.Linq;
namespace Core.Business.Entities
{
    public partial class Per
    {
        public static List<PermissionAttribute> GetPermissionOfCompany(int companyId)
        {
            var psm = PackageServiceModule.GetByCompanyId(companyId);
            return psm.Join(Per.List, psmi => psmi.PermissionId, p => p.PermissionId, (psmi, p) => p).ToList();
        }

        public static List<PermissionAttribute> Get(SessionType sessionType)
        {
            return List.Where(pa => pa.SessionType == sessionType).ToList();
        }
    }
}