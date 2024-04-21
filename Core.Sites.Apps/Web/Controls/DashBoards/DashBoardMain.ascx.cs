using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.Web.Compilation;
using System.Web.UI.WebControls;

using Core.Utility;
using Core.Web.Extensions;
using Core.Web.WebBase;
using Core.Sites.Libraries;
using Core.Sites.Libraries.Utilities;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Sites.Apps.Web.Controls.DashBoards.BoxType;
using Core.Business.Enums;

namespace Core.Sites.Apps.Web.Controls.DashBoards
{
    [Script(Src = "/Web/Controls/DashBoards/js/DashBoardMain.js")]
    [Module]
    public partial class DashBoardMain : PortalModule
    {
        public int TabId { set; get; }

        private readonly List<ScriptItem> scripts = new List<ScriptItem>();

        protected override void OnInitData()
        {
            MainDashBoard.LoadDashBoardConfiged(PortalContext.CurrentUser.User.UserId, PortalContext.SessionType)
                .Where(item => item.T1.TabId == TabId)
                .BindTo(rpData);
            this.SetData("DashBoardScripts", scripts);
        }

        protected void rpData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (!e.IsItem()) return;

            // LoadBoxType
            var dbi = e.As<Pair<DashBoardItem, CacheUrl.CacheUrlData>>().T1;
            var dataUrl = e.As<Pair<DashBoardItem, CacheUrl.CacheUrlData>>().T2;
            var dashboard = LoadDashBoardBoxType(dbi, PortalContext.SessionType);

            // Lấy tập scripts của dashboard
            scripts.AddRange(ReflectTypeListScriptAttribute.Inst[BuildManager.GetCompiledType(dataUrl.MenuItem.ModulePath.GetDrashBoard())].GetScriptItems());

            e.Find<PlaceHolder>("plc").Controls.Add(dashboard);
        }

        /// <summary>
        /// Thực hiện Load mỗi cái BoxType thui
        /// </summary>
        public void LoadBoxDashBoard()
        {
            var dbi = MainDashBoard.LoadConfig(PortalContext.CurrentUser.User.UserId, this.Query<string>("db"), PortalContext.SessionType);
            var dashboard = LoadDashBoardBoxType(dbi, PortalContext.SessionType);
            this.SetData("BoxTypeHtml", dashboard.Html);
            this.SetData("DashBoardItem", dbi);
        }

        public void DeleteDashBoard()
        {
            MainDashBoard.Delete(PortalContext.CurrentUser.User.UserId, PortalContext.SessionType, this.Query<string>("db"));
        }

        public void SwithDashBoard()
        {
            MainDashBoard.SwithPosition(PortalContext.CurrentUser.User.UserId, PortalContext.SessionType, this.Query<string>("db1"), this.Query<string>("db2"));
        }

        public void LoadDashBoard()
        {
            var dbi = MainDashBoard.LoadConfig(PortalContext.CurrentUser.User.UserId, GetParam<string>("db"), PortalContext.SessionType);
            var cacheDataUrl = dbi.GetCacheDataUrl(PortalContext.SessionType);
            var dashboard = LoadControl(cacheDataUrl.MenuItem.ModulePath.GetDrashBoard()) as IDashBoard;
            dashboard.LoadItem(dbi);
            dashboard.UrlData = cacheDataUrl;
            (dashboard as ControlBase).InitData();
            this.SetData("DashBoardItem", dbi);
            this.SetData("Html", (dashboard as ControlBase).Html);
            this.SetData("DashBoardMain", dashboard.GetType().BaseType.Name);
        }

        private DashBoardBoxType LoadDashBoardBoxType(DashBoardItem dbi, SessionType sessionType)
        {
            var bif = EnumHelper<BoxTypeInput.BoxType, BoxTypeInput.BoxTypeInfoAttribute>.Inst.GetAttribute((BoxTypeInput.BoxType)dbi.TypeBox);
            var dashboard = (DoLoad(bif.Type) as DashBoardBoxType);
            dashboard.DashBoardItem = dbi;
            dashboard.UrlData = dbi.GetCacheDataUrl(PortalContext.SessionType);
            dashboard.InitData();
            return dashboard;
        }
    }
}