using System.Linq;
using System.Web.UI.WebControls;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Web.Extensions;
using Core.Extensions;
using Core.Web.WebBase;
using Core.Business.Enums;
using Core.Utility;

namespace Core.Sites.Apps.Web.Controls.MenuGroupHome
{
    [Script(Src = "/Web/Controls/MenuGroupHome/js/MenuGroupHomeMain.js")]
    [Module]
    public partial class MenuGroupHomeMain : PortalModule
    {
        protected override void OnInitData()
        {
            var menuTop = PortalContext.MenuDocumentWithPermissions.Menus.Where(mt => mt.Title == PortalContext.CurrentPage.UrlData.MenuTop.Title).FirstOrDefault();
            rpRow.DoBind(menuTop.Groups.Select((g, i) => new { g, row = i / 3 }).GroupBy(gi => gi.row).Select(gii => new { groups = gii.Select(giii => giii.g).ToList() }).ToList());
        }
        protected void rpGroup_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (!e.IsItem()) return;
            e.Find<Repeater>("rpMenuItem").DoBind(e.As<GroupMenu>().MenuItems);
        }
        protected void rpRow_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (!e.IsItem()) return;
            e.Find<Repeater>("rpGroup").DoBind(e.Item.DataItem.Eval("groups"));
        }
        protected void rpMenuItem_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (!e.IsItem()) return;
            var item = Control<MenuGroupHomeMainItem>.Create();
            item.MenuItem = e.As<Libraries.Business.MenuItem>();
            item.InitData();
            e.Item.Controls.Add(item);
        }

        protected string CssBgColorGroupMenu(GroupMenu gm)
        {
            if (PortalContext.CurrentUser.Config.ColorMenuGroupCustom.IsNotNull()) return string.Empty;
            if (PortalContext.CurrentUser.Config.ColorMenuGroup != ColorSystem.Unknown)
                return "bg-" + EnumHelper<ColorSystem, ColorSystemAttribute>.Inst.GetAttribute(PortalContext.CurrentUser.Config.ColorMenuGroup).Css;
            return gm.BgColor.IsNull() ? "bg-green" : gm.BgColor;
        }
        protected string StyleBgColorGroupMenu(GroupMenu gm)
        {
            if (PortalContext.CurrentUser.Config.ColorMenuGroupCustom.IsNotNull()) return "background-color:" + PortalContext.CurrentUser.Config.ColorMenuGroupCustom;
            return string.Empty;
        }
    }
}