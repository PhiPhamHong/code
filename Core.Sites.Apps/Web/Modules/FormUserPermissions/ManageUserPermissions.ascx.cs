using Core.Business.Entities;
using Core.Web.WebBase;
using Core.Extensions;
using System.Linq;
using System;
using Core.Sites.Libraries;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using System.Collections.Generic;

namespace Core.Sites.Apps.Web.Modules.FormUserPermissions
{
    [Script(Src = "/Web/Modules/FormUserPermissions/js/ManageUserPermissions.js")]
    [Module]
    public partial class ManageUserPermissions : PortalModule<UserPermission>
    {
        protected override void OnInitData()
        {
            User = new User { UserId = UserId };
            User.GetByKey();

            // Kiểm tra xem công ty của User này có phù hợp hay không
            PortalContext.CurrentUser.ThrowIfCompanyIdNotValidWithUserCurrent(User.CompanyId);

            var canEdit = UserHelper.CanEditUserId(UserId);
            if (canEdit.T1)
            {
                formAssignPermission.Permissions = UserHelper.GetPermissions(UserId);
                formAssignPermission.CanPermissions = PortalContext.Session.GetPermissionsCanAssignForCompany(User.CompanyId);
                formAssignPermission.CanPermissions.Add(0);
            }
            else
            {
                this.SetData("ManageUserPermissionsError", canEdit.T2);
                throw new Exception(canEdit.T2);
            }

            this.SetData("UserId", UserId);
            this.SetData("UserName", User.UserName);
        }

        protected User User { set; get; }
        public int UserId { set; get; }
        public void SavePermission()
        {
            UserId = this.Query<int>("UserId");
            if (UserId == 0) throw new Exception("Không tìm thấy người được phân quyền");
            var canEdit = UserHelper.CanEditUserId(UserId);
            if (!canEdit.T1) throw new Exception(canEdit.T2);
            User = new User { UserId = UserId };
            User.GetByKey();
            // Kiểm tra xem công ty của User này có phù hợp hay không
            PortalContext.CurrentUser.ThrowIfCompanyIdNotValidWithUserCurrent(User.CompanyId);

            if (User.IsAdmin && (PortalContext.CurrentUser.GetCurrentCompanyId() != AppSetting.CompanyFullPermission || PortalContext.CurrentUser.FullPermission)) throw new Exception("Không thể phân quyền cho quản trị");

            SavePermissionOfUser(this.Query<string>("PermissionId").Split(',').Select(p => p.To<int>()).ToList(), User.UserId, User.CompanyId);
        }

        public static void SavePermissionOfUser(List<int> assigned, int userId, int companyId)
        {
            UserPermission.DoSave(userId, assigned);
        }

        public static void SavePermissionOfUser(List<int> added, List<int> deleted, int userId)
        {
            var permissions = UserHelper.GetPermissions(userId);
            permissions.AddRange(added);                  // Các quyền cần thêm            
            deleted.ForEach(p => permissions.Remove(p));  // Các quyền cần bỏ đi
            permissions = permissions.Distinct().ToList();// Tránh bị các quyền trùng nhau

            UserPermission.DoSave(userId, permissions);
        }
    }
}