using System;
using System.Collections.Generic;
using Core.Attributes;
using Core.Business.Mappers;
using Core.Extensions;
using Core.Utility;

namespace Core.Business.Entities
{
    public partial class User
    {
        public static User ApiLogin(string username, string password, int companyCode) { return Inst.ExeStoreToFirst("api_Users_Login", username, password.EncryptPassword(), companyCode); }
        public class DataSource : DataSource<User>.Module, ICompanyNeedValidate
        {
            [PropertyInfo(Name = "Tài khoản")] public string UserName { set; get; }
            [CompanyMapper(Name = "Công ty")] public int CompanyId { set; get; }

            public override List<User> GetEntities() => Inst.ExeStoreToList("sp_Users_GetData", UserName, CompanyId, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>("sp_Users_GetDataCount", UserName, CompanyId);
        }


        public int GetTotalUserActive(int companyId) { return SelectFirstValue<int>("sp_Users_GetTotalUserActive", companyId); }
        public int GetTotalUserByCompany(int companyId) { return SelectFirstValue<int>("sp_Users_GetTotalUserActiveByCompany", companyId); }

        public static int GetDataCountInCompany(int companyId) { return Inst.SelectFirstValue<int>("sp_Users_GetDataCountInCompany", companyId); }
        public bool CheckingExistsUserName(int userId, int companyId, string userName) { return SelectFirstValue<int>("sp_Users_CheckingExistsUserName", userId, companyId, userName) != 0; }
        public bool CheckCompanyHasUserAdmin(int userId, int companyId) { return SelectFirstValue<int>("sp_Users_CheckCompanyHasUserAdmin", companyId, userId) != 0; }
        public bool CheckExistEmployeeCode(int userId, int companyId, string employeecode) { return SelectFirstValue<int>("sp_Users_CheckExistEmployeeCode", userId, companyId, employeecode) != 0; }

        public static List<User> GetByGroupId(int groupId, DateTime date)
        {
            return Inst.ExeStoreToList("sp_Users_GetByGroupId", groupId, date);
        }

        public static List<User> GetAllByCompanyIds(string companyIds)
        {
            if (companyIds.IsNull()) return new List<User>();
            return Inst.ExeStoreToList("sp_Users_GetAllByCompanyIds", companyIds);
        }
        public static List<User> GetByUserIds(string userIds)
        {
            return Inst.ExeStoreToList("sp_Users_GetByIds", userIds);
        }
        public static List<User> GetDataByUserGroupId(int companyId, int userId) { return Inst.ExeStoreToList("sp_Users_GetDataByUserGroupId", companyId, userId); }
        public static int UpdateLoginSuccess(int userId)
        {
            return Inst.ExeStoreNoneQuery("sp_Users_UpdateLoginSuccess", userId);
        }
        public static int UpdateLoginFail(int userId)
        {
            return Inst.ExeStoreNoneQuery("sp_Users_UpdateLoginFail", userId);
        }
        public static void UpdateResetTotalLoginFail(int userId)
        {
            Inst.ExeStoreNoneQuery("sp_Users_UpdateResetTotalLoginFail", userId);
        }
    }
}