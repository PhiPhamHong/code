using Core.DataBase.ADOProvider.Attributes;
using System.Collections.Generic;
using Core.Extensions;
using Core.Attributes;
namespace Core.Business.Entities
{
    [TableInfo(TableName = "UserPermissions", Name="Quyền nhân viên")]
    public class UserPermission : MainDb.Entity<UserPermission>
    {
        #region properties
        [Field] public int UserId { set; get; }
        [Field] public int PermissionId { set; get; }
        [Field] public string PermissionIds { set; get; }
        #endregion

        /// <summary>
        /// Lấy danh sách quyền của một user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<int> GetPermissionOfUser2(int userId) 
        {
            var up = SelectFirst(u => u.UserId == userId);
            if (up == null) return new List<int> { };
            if (up.PermissionIds.IsNull()) return new List<int> { };

            var p = up.PermissionIds.Decrypt().Deserialize<Store>();
            if (p.Permissions == null) return new List<int> { };
            return p.Permissions;

            //return Inst.SelectToList(up => up.UserId == userId); 
        }

        public static List<UserPermission> GetPermissionOfUser(int userId)
        {
            return Inst.SelectToList(up => up.UserId == userId); 
        }


        public static void Deletes(int userId, List<int> permissions) { Inst.ExeStoreNoneQuery("sp_UserPermissions_Delete", userId, permissions.JoinString(p => p)); }
        public static void Inserts(int userId, List<int> permissions) { Inst.ExeStoreNoneQuery("sp_UserPermissions_Insert", userId, permissions.JoinString(p => p)); }
        public static void DoSave(int userId, List<int> permissions)
        {
            var store = new Store { Permissions = permissions };
            var pers = store.SerializeToString().Encryt();
            Inst.ExeStoreNoneQuery("sp_UserPermissions_Save", userId, pers);
        }

        public class Store
        {
            [PropertyIndex(Index = 0)] public List<int> Permissions { set; get; }
        }
    }
}
