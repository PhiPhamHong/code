using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using System;
using System.Collections.Generic;

namespace Core.Business.Entities
{
    public partial class GroupUser
    {
        [TableInfo(TableName = "[Users.Groups.Users]", Name = "Nhân viên")]
        public class User : MainDb.Entity<User>, IModel<int>, IEntityForLogShowNameByRef
        {
            #region Properties
            [Field(IsIdentity = true, IsKey = true)] public int GroupUserId { set; get; }
            [Field(Name = "Nhóm nhân viên")] public int GroupId { set; get; }
            [Field(Name = "Nhân viên", TypeRef = typeof(User)), ValidatorRequire, ValidatorDenyValue("0", Stt = 1)] public int? UserId { set; get; }
            [Field(Name = "Từ ngày"), ValidatorRequire] public DateTime? FromDate { set; get; }
            [Field(Name = "Đến ngày")] public DateTime? ToDate { set; get; }
            #endregion

            [PropertyInfo(Name = "Nhân viên")] public string UserName { set; get; }
            [PropertyInfo(Name = "Nhóm Nhân viên")] public string Name { set; get; }
            public int Key
            {
                get { return GroupUserId; }
                set { GroupUserId = value; }
            }
            public class DataSource : DataSource<User>.Module, ICompanyNeedValidate
            {
                public int GroupId { set; get; }
                public byte ViewHistory { set; get; }
                public int CompanyId { set; get; }
                public DateTime? Date { set; get; }

                public override List<User> GetEntities() => Inst.ExeStoreToList<User>("sp_Users_Groups_Users_GetData", GroupId, Date, ViewHistory, Start, Length, FieldOrder, Dir);
                public override int GetTotal() => Inst.SelectFirstValue<int>("sp_Users_Groups_Users_GetData_Count", GroupId, Date, ViewHistory);
            }
            public bool CheckConflictDate(int groupUserId, int userId, DateTime fromDate)
            {
                return SelectFirstValue<int>("sp_Users_Groups_Users_CheckConflictDate", groupUserId, userId, fromDate) == 1;
            }
            public void UpdateToDate(int userId)
            {
                ExeStoreNoneQuery("sp_Users_Groups_Users_UpdateToDate", userId);
            }

            public int NameKey => UserId ?? 0;
            public Type TypeNameKey => typeof(User);

            public static User GetDataByUserId(int userId)
            {
                return Inst.ExeStoreToFirst("sp_Users_Groups_Users_GetByUserId", userId);
            }
        }
    }
}