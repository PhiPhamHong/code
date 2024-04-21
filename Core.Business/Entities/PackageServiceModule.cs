using Core.DataBase.ADOProvider.Attributes;
using Core.Extensions;
using System.Collections.Generic;
using System.Linq;
namespace Core.Business.Entities
{
    [TableInfo(TableName = MainDbTable.PackageServiceModules)]
    public class PackageServiceModule : MainDb.Entity<PackageServiceModule>
    {
        [Field(IsKey = true, IsIdentity = true)] public int Id { set; get; }
        [Field] public int PackageServiceId { set; get; }
        [Field] public int PermissionId { set; get; }

        public static List<int> GetPermissions(int packageServiceId)
        {
            return PackageServiceModule.Inst.SelectToList(s => s.PackageServiceId == packageServiceId).Select(s => s.PermissionId).ToList();
        }

        public static void Inserts(int packageServiceId, List<int> permissions)
        {
            PackageServiceModule.Inst.ExeStoreNoneQuery(MainDbStore.sp_PackageServiceModules_Insert, packageServiceId, permissions.JoinString(p => p, ","));
        }

        public static void Deletes(int packageServiceId, List<int> permissions)
        {
            PackageServiceModule.Inst.ExeStoreNoneQuery(MainDbStore.sp_PackageServiceModules_Delete, packageServiceId, permissions.JoinString(p => p, ","));
        }

        public static List<PackageServiceModule> GetByCompanyId(int companyId)
        {
            return Inst.ExeStoreToList("sp_PackageServiceModules_GetByCompanyId", companyId);
        }
    }
}
