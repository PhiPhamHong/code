using System.Linq;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using Core.Extensions;
using Core.Web.Extensions;
using Core.Web.WebBase.HtmlBuilders;

using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Business.Entities;
using CoreMenuItem = Core.Sites.Libraries.Business.MenuItem;
using Core.Business.Enums;

namespace Core.Sites.Apps.Web.Controls.Common
{
    public partial class FormAssignPermission : PortalModule, IFormAssignPermission
    {
        protected override void OnInitData()
        {
            SystemPermissions = CanPermissions == null ? PortalContext.PermissionOfSystems(SessionType) : PortalContext.PermissionOfSystems(SessionType).Join(CanPermissions, pos => pos.PermissionId, cp => cp, (pos, cp) => pos).ToList();

            if (MenuDocument == null)
                MenuDocument = MenuDocument.LoadForAssignPermission(CanPermissions, SessionType);

            if (Permissions == null) Permissions = new List<int>();

            rpMenuTop.DoBind(MenuDocument.Menus.Where(mt => mt.SessionType == SessionType.Unknown || mt.SessionType == SessionType));
        }

        public List<int> Permissions { set; get; }                 // Tập quyền đã được gán
        public MenuDocument MenuDocument { set; get; }             // MenuDocument cung cấp giao diện phân quyền
        public List<int> CanPermissions { set; get; }              // Tập quyền có thể gán
        protected List<PermissionAttribute> SystemPermissions { set; get; } // Quyền trong hệ thống
        public SessionType SessionType { set; get; }               // Phân quyền cho hệ thống nào?

        protected void rpMenuTop_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (!e.IsItem()) return;
            var groups = e.As<MenuTop>().Groups;
            if (groups.Count != 0)
                e.Find<Repeater>("rpGroups").DoBind(groups);
        }
        protected void rpGroups_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (!e.IsItem()) return;
            e.Find<Repeater>("rpMenuItems").DoBind(e.As<GroupMenu>().MenuItems.Where(mi=> !mi.HideAssignPermission).ToList());
        }
        protected void rpMenuItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (!e.IsItem()) return;
            var pers = e.As<CoreMenuItem>().Permissions ?? string.Empty;
            if (pers.IsNotNull())
            {
                var listPers = pers.Split(',').Select(p => p.To<int>());
                listPers = CanPermissions == null ? listPers : CanPermissions.Join(listPers, cp => cp, p => p, (cp, p) => cp).OrderBy(cp => cp).ToList();
                e.Find<Repeater>("rpPers").DoBind(listPers);
            }
        }
        protected string RenderCheckbox(int permission)
        {
            var pm = SystemPermissions.FirstOrDefault(p => p.PermissionId == permission);
            var chk = Build<Checkbox<UserPermission>>().Name(up => up.PermissionId).Data("group", true).Value(permission);
            if (pm != null)
            {
                chk.PlaceHolder(pm.Name);
                chk.Checked(Permissions.Any(p => p == permission));
            }
            chk.LabelCss("ip-per-label");
            return chk.ToString();
        }

        protected bool IsAdmin1
        {
            get { return PortalContext.CurrentUser.User.UserId == 1 && PortalContext.SessionType == SessionType.Account; }
        }
        protected string FromMenuItem(object oitem)
        {
            var item = (CoreMenuItem)oitem;
            return PortalContext.GetLabel(IsAdmin1 ? (item.Title2.IsNotNull() ? item.Title2 : item.Title) : item.Title);
        }
        protected string FromGroupMenu(object ogroup)
        {
            var group = (GroupMenu)ogroup;
            return PortalContext.GetLabel(IsAdmin1 ? (group.Name2.IsNotNull() ? group.Name2 : group.Name) : group.Name);
        }
    }

    public interface IFormAssignPermission
    {
        List<int> Permissions { set; get; }                 // Tập quyền đã được gán
        SessionType SessionType { set; get; }               // Phân quyền cho hệ thống nào?
        List<int> CanPermissions { set; get; }              // Tập quyền có thể gán
    }
}