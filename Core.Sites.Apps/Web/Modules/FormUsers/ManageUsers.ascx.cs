using System.Collections.Generic;
using Core.Business.Entities;
using Core.Extensions;
using Core.Web.WebBase;
using System;
using Core.Attributes;
using Core.Sites.Apps.Web.InputMappers;
using Core.Sites.Libraries.Utilities;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Sites.Libraries.Utilities.Sites.Reports;
using Core.DataBase.ADOProvider.Attributes;
using Core.DataBase.ADOProvider;

namespace Core.Sites.Apps.Web.Modules.FormUsers
{
    [Script(Src = "/Web/Modules/FormUsers/js/ManageUsers.js")]
    [ManageModulePermission(Add = 2, Edit = 3, Delete = 4)]
    [ReportInfo(Title = "Danh sách người dùng", BinderType = ExcelBinderType.Grid)]
    [Module(HasDashBoard = true)]
    public partial class ManageUsers : ManageModule<User, ManageModuleProviderUser, FormEditUser>, IAjax
    {
        private const string UserOverContract = "Số lượng người dùng đã vượt quá hợp đồng. Vui lòng liên hệ với nhà cung cấp";

        [AjaxRequireHasPermission(5)]
        public override void UpdateField()
        {
            var t = ParseEntity();
            Provider.CanEditUser(t);
            t.LockedBy = PortalContext.CurrentUser.User.UserId;

            var old = new User { UserId = t.UserId };
            old.GetByKey();

            if(old.IsLock && !t.IsLock)
            {
                var company = new Company { CompanyId = t.CompanyId };
                company.GetByKey();

                if (company.MaxUser > 0)
                {
                    var totalUser = t.GetTotalUserByCompany(t.CompanyId);
                    if (totalUser >= company.MaxUser) throw new Exception(UserOverContract);
                }
            }

            t.Update("LockedBy", "IsLock");
        }

        [AjaxRequireHasPermission(20904)]
        public void ResetLogin()
        {
            var t = ParseEntity();
            User.UpdateResetTotalLoginFail(t.UserId);
        }

        public void GetSubDomain()
        {
            this.SetData("SubDomain", Company.GetSubDomain(this.Query<int>("CompanyId")));
        }
    }

    public class ManageModuleProviderUser : ManageModuleProvider<User, int>.Source<User.DataSource>, ICompanyNeedValidate
    {
        public int CompanyId { set; get; }
        public int GetTotalUserActive() => User.New.GetTotalUserActive(CompanyId);

        #region Cập nhật
        protected override void Save(User t, List<LogEntity> logEntities, IDataBaseService service)
        {
            t.CreatedBy = PortalContext.CurrentUser.User.UserId;
            if (t.Password.IsNotNull()) t.Password = t.Password.EncryptPassword();
            t.Save();

            // Kiểm tra tiếp là có quyền khóa tài khoản không. Nếu có quyền khóa tài khoản thì mới thực hiện cập nhật trường IsLocked
            if (PortalContext.HasPermission(5) && Module.HasParam("IsLock") && t.UserId != 1)
            {
                t.LockedBy = t.CreatedBy;
                t.Update("IsLock", "LockedBy");
            }
        }
        protected override void ValidateHelper(User t)
        {
            if (t.UserName.ToLower() == "admin" || t.UserName.ToLower() == "superadmin" || t.UserName.ToLower() == "teamadmin") throw new Exception("Bạn không thể tạo tài khoản với tên Admin, TeamAdmin hoặc SuperAdmin");

            if(t.CheckExistEmployeeCode(t.UserId, t.CompanyId, t.EmployeeCode)) new Exception("Mã nhân viên đã tồn tại");
            if (t.CheckingExistsUserName(t.UserId, t.CompanyId, t.UserName)) throw new Exception("Tài khoản đăng nhập đã tồn tại"); // "UserName",
            if (t.UserId == 0 && t.Password.IsNull()) throw new Exception("Mật khẩu không được để trống"); // "Password", 
            if (t.CheckCompanyHasUserAdmin(t.UserId, t.CompanyId) && t.IsAdmin) throw new Exception("Công ty này đã có quản trị"); // "IsAdmin",
            
            if (t.UserId == 0 || (OldEntity != null && OldEntity.IsLock && !t.IsLock))
            {
                var company = new Company { CompanyId = t.CompanyId };
                company.GetByKey();

                if (company.MaxUser > 0)
                {
                    var totalUser = t.GetTotalUserByCompany(t.CompanyId);
                    if (totalUser >= company.MaxUser)
                        throw new Exception("Số lượng người dùng đã vượt quá hợp đồng. Vui lòng liên hệ với nhà cung cấp");
                }
            }
            CanEditUser(t);
        }

        protected override void ValidateDeleteHelper(User t)
        {
            CanEditUser(t);
        }

        public override void UpdateField(User t, string field)
        {
            CanEditUser(t);
            base.UpdateField(t, field);
        }
        public void CanEditUser(User t)
        {
            var can = UserHelper.CanEditUserId(t.UserId);
            if (!can.T1) throw new Exception( can.T2);
        }
        #endregion
    }

    /// <summary>
    /// Label menu người dùng => đếm số người dùng
    /// </summary>
    public class ManageUsersMenuLabel : IMenuLabel<MenuItem>
    {
        public string GetText(MenuItem t) => new User.DataSource { CompanyId = PortalContext.CurrentUser.GetCurrentCompanyId() }.GetTotal().ToString();
    }
}