using Core.DataBase.ADOProvider.Attributes;
using System.Linq;
using Core.DataBase.ADOProvider;
namespace Core.Business.Entities
{
    [TableInfo(TableName = MainDbTable.UserConfigs, Name="Cấu hình người dùng")]
    public class UserConfig : MainDb.Entity<UserConfig>, IModel<int>
    {
        #region properties
        [Field(IsKey = true, IsIdentity = true)] public int UserConfigId { set; get; }
        [Field] public int UserId { set; get; }
        #endregion

        public override void Save() { ExeStoreNoneQuery(MainDbStore.sp_UserConfigs_Save); }
        public static UserConfig GetByUserId(int userId) { return Inst.SelectFirst(u => u.UserId == userId); }
        public static UserConfig GetByUserIdWithDefault(int userId) { return GetByUserId(userId) ?? GetByUserId(0); }

        public int Key
        {
            get { return UserConfigId; }
            set { UserConfigId = value; }
        }
    }
}