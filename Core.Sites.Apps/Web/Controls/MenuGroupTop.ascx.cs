using System.Linq;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Web.Extensions;
using Core.Extensions;
namespace Core.Sites.Apps.Web.Controls
{
    public partial class MenuGroupTop : PortalModule
    {
        public List<GroupMenu> Groups { set; get; }

        protected override void OnInitData()
        {
            if (Groups.Count == 1) rpOne.DoBind(Groups.SelectMany(g => g.MenuItems));
            else rpMulti.DoBind(Groups);

        }

        protected void rpMulti_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (!e.IsItem()) return;
            e.Find<Repeater>("rpItem").DoBind(e.As<GroupMenu>().MenuItems);
        }

        protected string FromMenuItem(object omenu)
        {
            var menu = (Core.Sites.Libraries.Business.MenuItem)omenu;
            return PortalContext.GetLabel(PortalContext.CurrentUser.User.UserId == 1 ? (menu.Title2.IsNotNull() ? menu.Title2 : menu.Title) : menu.Title);
        }

        protected string FromGroupMenu(object ogroup)
        {
            var group = (Core.Sites.Libraries.Business.GroupMenu)ogroup;
            return PortalContext.GetLabel(PortalContext.CurrentUser.User.UserId == 1 ? (group.Name2.IsNotNull() ? group.Name2 : group.Name) : group.Name);
        }
    }
}