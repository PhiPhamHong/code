using System;
using System.Linq;
using Core.Business.Entities;
using Core.Web.WebBase;
using Core.Extensions;
using Core.Sites.Libraries;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Sites.Apps.Web.Modules.FormUserPermissions;
using Core.Business.Enums;

namespace Core.Sites.Apps.Web.Modules.FormPackageServiceModules
{
    [Script(Src="/Web/Modules/FormPackageServiceModules/js/ManagePackageServiceModules.js")]
    [Module]
    public partial class ManagePackageServiceModules : PortalModule<PackageServiceModule>
    {
        protected override void OnInitData()
        {
            formAssignPermission.Permissions = PackageServiceModule.GetPermissions(PackageServiceId);
            formAssignPermission.MenuDocument = MenuDocument.LoadForAssignPermission(PortalContext.PermissionOfSystems(SessionType.Account).Select(p => p.PermissionId).ToList(), SessionType.Account);
        }
        public int PackageServiceId { set; get; }
        public void SavePermission()
        {
            PackageServiceId = this.Query<int>("PackageServiceId");
            if (PackageServiceId == 0) throw new Exception("Vui lòng chọn dịch vụ cần gán quyền");

            var permissions = PackageServiceModule.GetPermissions(PackageServiceId);
            var news = this.Query<string>("PermissionId").Split(',').Where(p => p.IsNotNull()).Select(p => p.To<int>()).Where(p => p != 0).ToList();

            var deleted = permissions.FindNewItems(news, p => p, n => n).ToList();
            var inserted = news.FindNewItems(permissions, n => n, p => p).ToList();

            PackageServiceModule.Inserts(PackageServiceId, inserted);
            PackageServiceModule.Deletes(PackageServiceId, deleted);
            if (this.Query<bool>("AssignForBoss"))
            {
                new CompanyPackageService.DataSource { FieldOrder = nameof(CompanyPackageService.CompanyName) }
                    .GetEntities()
                    .Where(c => c.EndTime == null || c.EndTime >= DateTime.Today).ForEach(c =>
                {
                    var userBoss = User.Inst.SelectToList(u => u.CompanyId == c.CompanyId);
                    userBoss.Where(u => u.IsBoss).ForEach(u =>
                    {
                        var permissionOfUsers = UserPermission.Inst.GetPermissionOfUser2(u.UserId);
                        permissionOfUsers.AddRange(inserted);
                        deleted.ForEach(p => permissionOfUsers.Remove(p));
                        permissionOfUsers = permissionOfUsers.Distinct().ToList();

                        UserPermission.DoSave(u.UserId, permissionOfUsers);
                    });
                });
            }
        }
    }
}