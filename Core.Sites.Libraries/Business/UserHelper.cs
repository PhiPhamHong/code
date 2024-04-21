using System.Linq;
using System.Collections.Generic;
using Core.Business.Entities;
using Core.Utility;
using Core.Extensions;
using Core.Web.WebBase;
using System;

namespace Core.Sites.Libraries.Business
{
    public class UserHelper : IAjax
    {
        /// <summary>
        /// Lấy ra tập quyền của user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static List<int> GetPermissions(int userId)
        {
            // Nếu là quản trị tổng của tổng thì full quyền toàn hệ thống
            if (userId == 4) return Per.List.Select(p => p.PermissionId).ToList();

            else
            {
                var user = new User { UserId = userId };
                user.GetByKey();

                // Nếu là admin của công ty thì full quyền của công ty
                var permissionOfCompanies = CompanyHelper.GetPermissionOfCompany(user.CompanyId);
                if (user.IsAdmin) return permissionOfCompanies.Select(pc => pc.PermissionId).ToList();

                //// Còn lại thì quyền là tập con của quyền công ty
                //var permissionOfUsers = UserPermission.GetPermissionOfUser(userId);
                //return permissionOfUsers.Join(permissionOfCompanies, pu => pu.PermissionId, pc => pc.PermissionId, (pu, pc) => pu).Select(pu => pu.PermissionId).ToList();

                // Còn lại thì quyền là tập con của quyền công ty
                var permissionOfUsers = UserPermission.Inst.GetPermissionOfUser2(userId);
                return permissionOfUsers.Join(permissionOfCompanies, pu => pu, pc => pc.PermissionId, (pu, pc) => pu).Select(pu => pu).ToList();
            }
        }

        /// <summary>
        /// Xem User hiện tại có thể cập nhật thông tin của UserId này hay không
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static Pair<bool, string> CanEditUserId(int userId)
        {
            if (userId == 0 || PortalContext.CurrentUser.User.UserId == 1) return new Pair<bool, string> { T1 = true };
            if (userId == PortalContext.CurrentUser.User.UserId && userId != 1) return new Pair<bool, string> { T1 = false, T2 = "Bạn không thể cập nhật thông tin của chính mình" };

            var user = new User { UserId = userId };
            user.GetByKey();

            PortalContext.CurrentUser.ThrowIfCompanyIdNotValidWithUserCurrent(user.CompanyId, string.Empty);

            //// có phải là công ty con hay không
            //var isCompanyChild = new Company.Tree().FindChild(AccountInfo.User.CompanyId).Any(c => c.CompanyId == user.CompanyId);

            // Nếu là admin, nhưng bị tài khoản của công ty cha sửa thì vẫn được.
            // if (user.IsAdmin && isCompanyChild && (AccountInfo.User.CompanyId != user.CompanyId)) return new Pair<bool, string> { T1 = false, T2 = "Bạn không thể cập nhật thông tin của quản trị" };
            if (user.IsAdmin && PortalContext.CurrentUser.User.CompanyId == user.CompanyId && user.CompanyId != AppSetting.CompanyFullPermission) return new Pair<bool, string> { T1 = false, T2 = "Bạn không thể cập nhật thông tin của quản trị" };
            if (user.IsBoss && PortalContext.CurrentUser.User.CompanyId == user.CompanyId && user.CompanyId != AppSetting.CompanyFullPermission) return new Pair<bool, string> { T1 = false, T2 = "Bạn không thể cập nhật thông tin của Boss" };

            //// Nếu user cần sửa thuộc công ty con của người đang sửa mới thực hiện được
            //if (!isCompanyChild)
            //    return new Pair<bool, string> { T1 = false, T2 = "Bạn không thể cập nhật tài khoản của công ty khác" };

            return new Pair<bool, string> { T1 = true };
        }

        public void GetColumnConfigOfGridCanEdit()
        {
            var column = GetConfigOfCurrentUser(this.Query<string>("columnKeyConfig"));
            this.SetData("ColumnConfig", column);
        }

        public User.Column GetConfigOfCurrentUser(string module)
        {
            var column = User.Column.GetByModule(PortalContext.CurrentUser.User.UserId, module, PortalContext.SessionType);
            if (column == null)
                column = new User.Column { UserId = PortalContext.CurrentUser.User.UserId };
            return column;
        }

        public void SaveUserColumn()
        {
            var column = this.ParseParamTo<User.Column>(true);
            column.SessionType = PortalContext.SessionType;
            column.Save();
            this.SetData("UserColumnId", column.UserColumnId);
        }

        public static GroupUser GetGroupOfUserCurrent(GroupUser.EType type)
        {
            return GetGroupOfUserCurrent(PortalContext.CurrentUser.User.UserId, type);            
        }

        public static GroupUser GetGroupOfUserCurrent(int userId, GroupUser.EType type)
        {
            return GroupUser.GetByUserId(userId, type, DateTime.Now).FirstOrDefault();
        }
    }

    public class GroupSearchOption
    {
        public int UserId { set; get; }
        private int GroupId { set; get; }        

        public string GroupIds { set; get; }

        public static GroupSearchOption Get(int? groupId, int? userId, bool canViewAll)
        {
            var gsp = new GroupSearchOption { };

            if (canViewAll)
            {
                gsp.GroupId = groupId ?? 0;
                gsp.UserId = userId ?? 0;
                
                if (gsp.GroupId == 0)
                {
                    // Có quyền xem tất nhưng chỉ xem được các phòng mà ông ấy đang nằm trong
                    // => Chỉ lấy ra các phòng mà ông này đang có quyền trưởng nhóm
                    // 
                    var groups = GroupUser.GetByUserId(PortalContext.CurrentUser.User.UserId, GroupUser.EType.Unknown, DateTime.Now);

                    // Lọc theo đống Groups này này.
                    gsp.GroupIds = groups.JoinString(g => g.GroupId);
                }
                else gsp.GroupIds = gsp.GroupId.ToString();
            }
            else
            {
                gsp.UserId = PortalContext.CurrentUser.User.UserId; 
            }
            return gsp;
        }
    }
}