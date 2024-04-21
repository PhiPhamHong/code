using System.Linq;
using Core.Attributes;
using Core.Attributes.Validators;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Web.WebBase;
using Core.Extensions;
using Core.Business.Entities;
using Core.Business.Enums;

namespace Core.Sites.Apps.Web.Modules.FormUsers
{
    [Module]
    [Script(Src = "/Web/Modules/FormUsers/js/FormCreateDashboardForUser.js")]
    public partial class FormCreateDashboardForUser : PortalModule<FormCreateDashboardForUser.Option>, IAjax
    {
        public class Option
        {
            [PropertyInfo(Name = "Công ty"), ValidatorDenyValue(0), ValidateCompany(Stt = 1)] public int CompanyId { set; get; }
            [PropertyInfo(Name = "Sao chép của"), ValidatorDenyValue(0), ValidateUser(Stt = 1)] public int UserId { set; get; }
            [PropertyInfo(Name = "Người dùng nhận sao chép"), ValidatorDenyValue(0), ValidateUser(Stt = 1)] public int UserIdNeedCopyTo { set; get; }
        }

        public void CopyDashboard()
        {
            var option = this.ParseParamTo<Option>(true);
            var dbs = MainDashBoard.Load(option.UserId, PortalContext.SessionType); // Bảng tin của người cần copy đi
            var tabs = User.DashboardTab.GetByUserId(option.UserId, PortalContext.SessionType);      // Các tab của người cần copy đi
            User.DashboardTab.DeleteByUserId(option.UserIdNeedCopyTo, PortalContext.SessionType); // Xóa tab của người cần tạo bảng tin

            var user = new User { UserId = option.UserIdNeedCopyTo };
            if (!user.GetByKey()) return;

            dbs.Items.GroupBy(item => item.TabId).ForEach(g => 
            {
                var tab = tabs.FirstOrDefault(t => t.DashBoardTabId == g.Key);
                if (tab == null)
                {
                    g.ForEach(item => item.TabId = 0);
                }
                else
                {
                    tab.UserId = option.UserIdNeedCopyTo;
                    tab.DashBoardTabId = 0;
                    tab.Save();

                    g.ForEach(item => 
                    {
                        item.TabId = tab.DashBoardTabId;

                        item.Settings.ForEach(setting => 
                        {
                            if (setting.Name == "CompanyId")
                                setting.Value = user.CompanyId.ToString();
                        });
                    });
                }
            });

            MainDashBoard.Save(option.UserIdNeedCopyTo, PortalContext.SessionType, dbs);
        }

        public void CopyPermission()
        {
            var option = this.ParseParamTo<Option>(true);
            var permissions = UserHelper.GetPermissions(option.UserId); // Tập quyền cần sao chép

            var user = new User { UserId = option.UserIdNeedCopyTo };
            user.GetByKey();
            var permissionOfCompanies = CompanyHelper.GetPermissionOfCompany(user.CompanyId); // Tập quyền của công ty người nhận tập quyền sao chép

            // Sao chép chỉ trong giới hạn quyền thuộc công ty
            permissions = permissionOfCompanies.Join(permissions, pc => pc.PermissionId, p => p, (pc, p) => p).ToList();

            UserPermission.DoSave(option.UserIdNeedCopyTo, permissions);
        }
    }
}