using System;
using System.Linq;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Business.Entities;
using Core.Utility;
using Core.Web.Extensions;
namespace Core.Sites.Apps.Web.Controls.DashBoards
{
    [Script(Src = "/Web/Controls/DashBoards/js/DashBoardMainTabs.js")]
    [Module]
    public partial class DashBoardMainTabs : PortalModule<User.DashboardTab>
    {
        protected int random = Singleton<Random>.Inst.Next(1, 10000);
        protected override void OnInitData()
        {
            User.DashboardTab.GetByUserId(PortalContext.CurrentUser.User.UserId, PortalContext.SessionType).BindTo(rpTabs, rpContents);
        }
    }
}