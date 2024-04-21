using System.Linq;
using System.Collections.Generic;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Business.Entities;
using Core.Web.WebBase;
using System;
using Core.Utility;

namespace Core.Sites.Apps.Web.Controls.DashBoards
{
    [Script(Src = "/Web/Controls/DashBoards/js/ManageDashboardTabs.js")]
    [Module]
    public partial class ManageDashboardTabs : ManageModule<User.DashboardTab, ManageDashboardTabs.ModuleProvider, FormEditDashboardTab>
    {
        public class ModuleProvider : ManageModuleProvider<User.DashboardTab, int>.Source<ModuleProvider.DataSource>, IAjax
        {
            protected override void OnBeforeSave(User.DashboardTab t)
            {
                t.UserId = PortalContext.CurrentUser.User.UserId;
                t.SessionType = PortalContext.SessionType;
            }
            protected override void AfterSave(User.DashboardTab t) => this.SetData("TabId", t.DashBoardTabId);
            protected override void ValidateDeleteHelper(User.DashboardTab t)
            {
                if (MainDashBoard.LoadDashBoardConfiged(PortalContext.CurrentUser.User.UserId, PortalContext.SessionType).Count(item => item.T1.TabId == t.DashBoardTabId) > 0)
                    throw new ErrorMessageException("Bảng điều khiển này đang có dữ liệu nên không thể xóa");
            }

            new public class DataSource : DataSource<User.DashboardTab>.Module
            {
                public override List<User.DashboardTab> GetEntities() => User.DashboardTab.GetByUserId(PortalContext.CurrentUser.User.UserId, PortalContext.SessionType);
                public override int GetTotal() => 0;
            }
        }
    }
}