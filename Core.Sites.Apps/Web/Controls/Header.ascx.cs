using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core.Sites.Libraries.Business;
using Core.Web.Extensions;
using Core.Web.WebBase;
using Core.Extensions;
using Core.Business.Entities;
using Core.Business.Enums;

namespace Core.Sites.Apps.Web.Controls
{
    public partial class Header : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // menuTop.DoBind(PortalContext.MenuDocumentWithPermissions.Menus.Where(m => m.Groups.Count != 0).ToList());
            menuTop.DoBind(PortalContext.MenuDocumentWithPermissions.Menus.Where(mt => mt.SessionType == SessionType.Unknown || mt.SessionType == PortalContext.Session.IAccountInfo.SessionType));
            menuLeft.InitData();

            var languages = Language.GetLanguages();
            CurrentLanguage = languages.FirstOrDefault(l => l.LanguageId == PortalContext.DefaultLanguage);
            rpLanguages.DoBind(languages);
        }

        protected Language CurrentLanguage { set; get; }

        protected void menuTop_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (!e.IsItem()) return;
            var mgt = Control<MenuGroupTop>.Create();
            mgt.Groups = e.As<MenuTop>().Groups;
            mgt.InitData();
            e.Find<PlaceHolder>("plcGroup").Controls.Add(mgt);
        }

        protected string FromMenuItem(object omenu)
        {
            var menu = (Libraries.Business.MenuItem)omenu;
            return PortalContext.GetLabel(PortalContext.CurrentUser.User.UserId == 1 ? (menu.Title2.IsNotNull() ? menu.Title2 : menu.Title) : menu.Title);
        }
    }
}