using System;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider.Attributes;
using Newtonsoft.Json;
using Core.Extensions;
using System.Collections.Generic;
using Core.Attributes;
using Core.Web.WebBase.HtmlBuilders;
using System.Data;
using Core.DataBase.ADOProvider;
using Core.Web.WebBase;
using Core.Business.Enums;

namespace Core.Business.Entities
{
    [TableInfo(TableName = MainDbTable.Users, Name="Người dùng")]
    public partial class User : MainDb.Entity<User>, IModel<int>, ICompanyNeedValidate, IEntityForLogShowName, IUserLogin
    {
        #region properties
        [Field(IsKey = true, IsIdentity = true), DataValueField(Default = "0")] public int UserId { set; get; }
        [Field(Name = "Tài khoản"), ValidatorRequire, ValidatorLength(Min = 5, Max = 50, Stt = 1), ValidatorNotMultipleWhiteSpace] public string UserName { set; get; }

        [DataTextField(Default = "-- Chọn nhân viên --")] public string FindName { get { return UserName + " - " + FullName; } }

        [Field(Name = "Mật khẩu"), JsonIgnore, ValidatorLength(Min = 8, Max = 100), ValidatorNotMultipleWhiteSpace(Stt = 1)] public string Password { set; get; }
        [Field(Name = "Họ và tên"), ValidatorRequire] public string FullName { set; get; }
        [Field(Name = "Email"), ValidatorEmail] public string Email { set; get; }
        [Field(Name = "Công ty"), ValidatorRequire] public int CompanyId { set; get; }
        [Field(Name = "Điện thoại"), ValidatorLength(Max = 20)] public string Mobile { set; get; }
        [Field(LogWhenChange = false), JsonIgnore] public DateTime CreatedDate { set; get; }
        [Field(LogWhenChange = false), JsonIgnore] public int CreatedBy { set; get; }
        [Field(Name = "Khóa")] public bool IsLock { set; get; }
        [Field, JsonIgnore] public int LockedBy { set; get; }
        [Field(Name = "Quản trị")] public bool IsAdmin { set; get; }
        [Field(Name = "Ảnh đại diện"), ValidatorLength(Max = 200)] public string Avatar { set; get; }
        [Field(Name = "Mã nhân viên"), ValidatorRequire, ValidatorLength(Max = 10, Min = 2, Stt = 2), ValidatorNotMultipleWhiteSpace(Stt = 3)]
        public string EmployeeCode { set; get; }
        [Field(Name = "Vai trò", TypeRef = typeof(Role))] public int RoleId { set; get; }
        [Field(Name = "Boss")] public bool IsBoss { set; get; }
        #endregion

        public int TotalLoginFail { set; get; }

        #region property left join
        public int EmployeeId { set; get; }
        public int CompanyParentId { set; get; }

        [PropertyInfo(Name = "Công ty")] public string CompanyName { set; get; }
        public string SubDomain { set; get; }

        [PropertyInfo(Name = "Người dùng")]
        public string UserName2
        {
            get
            {
                if (SubDomain.IsNull()) return UserName;
                return UserName + "@" + SubDomain;
            }
        }
        #endregion

      
        public bool Login()
        {
            var table = ExeStore(MainDbStore.sp_Users_Login);
            if (table.Rows.Count != 0) ParseFrom(table.Rows[0]);
            return table.Rows.Count != 0;
        }

        public bool Login2(string password, bool onlyUser)
        {
            var table = ExeStore("sp_Users_Login_2");
            if (table.Rows.Count != 0) ParseFrom(table.Rows[0]);

            return table.Rows.Count != 0 && (onlyUser || Password == password);
        }

        public class LoginFailException : Exception
        {
            public int Remain { private set; get; }

            public LoginFailException(string msg, int remain) : base(msg) { Remain = remain; }
        }

        public override bool GetByKey()
        {
            var table = ExeStore(MainDbStore.sp_Users_GetByKey, UserId);
            if (table.Rows.Count != 0) ParseFrom(table.Rows[0]);
            return table.Rows.Count != 0;
        }
        public override void Save() { UserId = SelectFirstValue<int>(MainDbStore.sp_Users_Save); }

        public void UpdateInfo()
        {
            ExeStoreNoneQuery(MainDbStore.sp_Users_UpdateInfo);
        }

        public static List<T> ModuleGetData<T>(string keySearch, string table, string fields, int start, int length, string fieldOrder, string dir) where T : new()
        {
            return Inst.ExeStoreToList<T>("sp_Modules_GetData", keySearch, table, fields, start, length, fieldOrder, dir);
        }        
        public static List<User> GetDataByCompanyIdAndPerId(int CompanyId)
        {
            var data = Inst.ExeStoreToList("sp_User_GetDataByCompanyIdandPerId", CompanyId);
            return data;
        }
        public static int ModuleGetDataCount(string keySearch, string table, string fields)
        {
            return Inst.SelectFirstValue<int>("sp_Modules_GetData_Count", keySearch, table, fields);
        }

        public class Item
        {
            [JsonProperty("id")] public int UserId { set; get; }
            [JsonProperty("text")] public string UserName { set; get; }
        }

        public static List<Item> GetItems()
        {
            return Inst.GetAllToList<Item>();
        }
        public DataTable DoLogin(string userName, string domain)
        {
            return ExeStore("sp_Users_Login_3", userName, domain);
        }

        public int Key
        {
            get { return UserId; }
            set { UserId = value; }
        }

        [JsonIgnore]
        public string Name { get { return UserName; } }
        public int PartnerId { get { return 0; } }
        public string Phone { set; get; }
        [PropertyInfo(Name = "Stt")] public int Row { get; set; }
    }

    public partial class User
    {
        [TableInfo(TableName = "[Users.DashboardTabs]", Name="Menu Dashboard")]
        public class DashboardTab : MainDb.Entity<DashboardTab>, IModel<int>
        {
            #region Properties
            [Field(IsIdentity = true, IsKey = true), DataValueField(Default = "0")] public int DashBoardTabId { set; get; }
            [Field] public int UserId { set; get; }
            [Field(Name = "Bảng điều khiển"), DataTextField(Default = "-- Bảng điều khiển --"), ValidatorRequire, ValidatorLength(Max = 300)] public string TabName { set; get; }
            [Field(Name = "Thứ tự")] public int Stt { set; get; }
            [Field] public SessionType SessionType { set; get; }
            #endregion
            [PropertyInfo(Name = "Stt")] public int Row { get; set; }
            public static List<DashboardTab> GetByUserId(int userId, SessionType sessionType)
            {
                return Inst.ExeStoreToList("sp_Users_DashboardTabs_GetByUserId", userId, sessionType);
            }

            public static void DeleteByUserId(int userId, SessionType sessionType)
            {
                Inst.ExeStoreNoneQuery("sp_Users_DashboardTabs_DeleteByUserId", userId, sessionType);
            }

            public int Key
            {
                get { return DashBoardTabId; }
                set { DashBoardTabId = value; }
            }
        }
    }

    public static class IUserLoginExtension
    {
        public static bool RequestLogin(this IUserLogin user, string password, bool onlyUser, string domain, string domainRoot, int companyFullPermission)
        {
            var us = user.UserName.Split('@');
            DataTable table = null;

            // Nếu có cấu hình domain chung
            // Mà domain đang chạy đúng là domain chung thì khi đăng nhập bắt buộc phải có @
            if (domainRoot.IsNotNull() && domain == domainRoot && us.Length != 2) return false;

            if (us.Length == 2)
            {
                if (us[0] == "admin") return false;
                if (us[0] == "teamadmin") us[0] = "admin";
                table = user.DoLogin(us[0], us[1]); //ExeStore("sp_Users_Login_3", us[0], us[1]);
            }
            else
            {
                var subdomain = Company.GetSubDomain(domain);
                if (subdomain.IsNotNull())
                {
                    table = user.DoLogin(user.UserName, subdomain); //ExeStore("sp_Users_Login_3", UserName, subdomain);
                }
                else
                {
                    table = user.DoLogin(user.UserName, string.Empty); //ExeStore("sp_Users_Login_3", UserName, string.Empty);

                    // Nếu đăng nhập không có @ và không đúng Domain thì chỉ có tài khoản của app mới được
                    if (table.Rows.Count != 0)
                    {
                        if (table.Rows[0]["CompanyId"].To<int>() != companyFullPermission) return false;
                    }
                }
            }

            if (table.Rows.Count != 0) user.ParseFrom(table.Rows[0]);
            if (user.UserId != 0)
            {
                if (user.TotalLoginFail >= 5) throw new Exception("Tài khoản này đã bị khóa vì đã đăng nhập không đúng mật khẩu quá 5 lần");
                else
                {
                    if (!onlyUser && password != user.Password)
                    {
                        var remain = 4 - user.TotalLoginFail;
                        throw new User.LoginFailException("Tài khoản không hợp lệ. Bạn còn {0} lần đăng nhập".Frmat(remain), remain);
                    }
                }
            }

            return table.Rows.Count != 0 && (onlyUser || user.Password == password);
        }
    }
    public class UserForLogin
    {
        [PropertyInfo(Name = "Tài khoản"), ValidatorRequire, ValidatorLength(Min = 5, Max = 30, Stt = 1), ValidatorNotMultipleWhiteSpace] public string UserName { set; get; }
        [PropertyInfo(Name = "Mật khẩu"), JsonIgnore, ValidatorLength(Min = 8, Max = 100), ValidatorNotMultipleWhiteSpace(Stt = 1)] public string Password { set; get; }
    }
    public class UserForLoginQRCode
    {
        [PropertyInfo(Name = "QR Code"), ValidatorRequire] public string QRCode { set; get; }
    }
}