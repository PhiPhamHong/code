using System.Collections.Generic;
using System.Linq;
using Core.Extensions;
using Core.Sites.Libraries;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Utility;

namespace Core.Sites.Apps.Web.Controls.DashBoards
{
    [Script(Src = "/Web/Controls/DashBoards/js/DashBoardUsing.js")]
    [Module]
    public partial class DashBoardUsing : ManageModule<DashBoardItem, DashBoardUsing.ManageModuleProviderDashBoardItem>
    {
        public class ManageModuleProviderDashBoardItem : ManageModuleProviderBase<DashBoardItem>.Source<ManageModuleProviderDashBoardItem.DataSource>
        {
            new public class DataSource : DataSource<DashBoardItem>.Module
            {
                protected List<DashBoardItem> DashBoards => MainDashBoard.LoadDashBoardConfiged(PortalContext.CurrentUser.User.UserId, PortalContext.SessionType).Select(pr => pr.T1).ToList();
                public override List<DashBoardItem> GetEntities()
                {
                    var data = DashBoards;
                    return (Dir.ToUpper() == "DESC" ? data.OrderByDescending(t => t.Eval(FieldOrder)) : data.OrderBy(t => t.Eval(FieldOrder))).Skip(Start).Take(Length).ToList();
                }
                public override int GetTotal() => DashBoards.Count;
            }
        }
    }
}