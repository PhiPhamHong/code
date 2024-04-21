using Core.Web.WebBase;
using System.Web.UI.WebControls;
using System.Linq;
using Core.Web.Extensions;
using Core.Extensions;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
namespace Core.Sites.Apps.Web.Controls
{
    public partial class MenuLeft : PortalModule
    {
        public MenuTop MenuTop { set; get; }

        /// <summary>
        /// Quyền menu trái chưa đc check
        /// </summary>
        protected override void OnInitData()
        {
            //MenuTop = MenuTop ?? PortalContext.CurrentPage.UrlData.MenuTop;
            //var menuTop = PortalContext.MenuDocumentWithPermissions.Menus.Where(mt => mt.Title == MenuTop.Title).FirstOrDefault();
            //rpMenu.DoBind(menuTop.Groups);
        }

        protected void rpMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (!e.IsItem()) return;

            var groupMenu = e.Item.DataItem.As<GroupMenu>();
            var menu = groupMenu.MenuItems.Count == 1 ? (MenuLeftItemBase)Control<MenuLeftItem>.Create() : Control<MenuLeftGroupItem>.Create();
            menu.GroupMenu = groupMenu;
            menu.InitData();
            e.Find<PlaceHolder>("plc").Controls.Add(menu);
        }
    }

    public class MenuLeftItemBase : ControlBase
    {
        public GroupMenu GroupMenu { set; get; }
    }
}