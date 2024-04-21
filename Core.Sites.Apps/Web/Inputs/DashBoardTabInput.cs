using System.Collections.Generic;
using Core.Sites.Libraries.Business;
using Core.Business.Entities;
using Core.Web.WebBase;
using Core.Web.WebBase.HtmlBuilders;
using Core.Sites.Apps.Web.Controls.DashBoards;

namespace Core.Sites.Apps.Web.Inputs
{
    public class DashBoardTabInput : SelectModel<User.DashboardTab, DashBoardTabInput>
    {
        protected override List<User.DashboardTab> GetData()
        {
            return User.DashboardTab.GetByUserId(PortalContext.CurrentUser.User.UserId, PortalContext.Session.IAccountInfo.SessionType);
        }

        protected override IManageModulePermission GetManageModule()
        {
            return new ManageDashboardTabs();
        }
    }
}