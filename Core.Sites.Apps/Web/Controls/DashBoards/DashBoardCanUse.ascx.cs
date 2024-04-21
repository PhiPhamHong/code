using System.Linq;
using System.Collections.Generic;
using Core.Extensions;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Utility;

namespace Core.Sites.Apps.Web.Controls.DashBoards
{
    [Script(Src = "/Web/Controls/DashBoards/js/DashBoardCanUse.js")]
    [Module]
    public partial class DashBoardCanUse : ManageModule<MenuItem, DashBoardCanUse.ManageModuleProviderMenuItem>
    {
        public class ManageModuleProviderMenuItem : ManageModuleProviderBase<MenuItem>.Source<ManageModuleProviderMenuItem.DataSource>
        {
            protected List<MenuItem> MenuItems => PortalContext.ListMenuItemHasDashBoard;

            new public class DataSource : DataSource<MenuItem>.Module
            {
                public override List<MenuItem> GetEntities()
                {
                    var data = PortalContext.ListMenuItemHasDashBoard;
                    return (Dir.ToUpper() == "DESC" ? data.OrderByDescending(t => t.Eval(FieldOrder)) : data.OrderBy(t => t.Eval(FieldOrder))).Skip(Start).Take(Length).ToList();
                }
                public override int GetTotal() => PortalContext.ListMenuItemHasDashBoard.Count;
            }
        }
    }
}