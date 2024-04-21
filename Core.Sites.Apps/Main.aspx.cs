using System;
using System.Web.UI;
using Core.Sites.Libraries;
using Core.Sites.Libraries.Business;
using Core.Business.Entities;
using Core.Web.WebBase;
using Core.Web.Extensions;
using System.Linq;
using Core.Business.Enums;
using Core.Sites.Apps.Web.Controls;
using System.Web.UI.WebControls;
using Core.Extensions;


namespace Core.Sites.Apps
{
    public partial class Main : Page, IAjax
    {
        /// <summary>
        /// Trang Main luôn được kiểm tra trạng thái đăng nhập
        /// Nếu chưa đăng nhập sẽ chuyển tới trang đăng nhập
        /// Ngược lại đã đăng nhập rồi thì gia hạn thêm thời gian cookie
        /// </summary>

        protected Language CurrentLanguage { set; get; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!PortalContext.Session.IsLoging) Response.Redirect(UrlHelper.Login, true);
            else PortalContext.Session.ExtendTimeCookie();

            menuTop.DoBind(PortalContext.MenuDocumentWithPermissions.Menus.Where(mt => mt.SessionType == SessionType.Unknown || mt.SessionType == PortalContext.Session.IAccountInfo.SessionType));
            var languages = Language.GetLanguages();
            CurrentLanguage = languages.FirstOrDefault(l => l.LanguageId == PortalContext.DefaultLanguage);
            rpLanguages.DoBind(languages);
        }
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
        public void LoadBox()
        {
            var box = ControlBase.DoLoad(Type.GetType(this.Query<string>("boxtype")));
            box.InitData();
            this.SetData("BoxContent", box.Html);
        }

        public void Logout()
        {
            PortalContext.Session.SignOut();
            ResponseMessage.SetTimeout($"window.location = '{UrlHelper.Login}'", 100);
            throw new EndException();
        }

        public void LoadMapConfig()
        {
            var userConfig = UserConfig.GetByUserId(PortalContext.CurrentUser.User.UserId);
            var companyConfig = CompanyConfig.Inst.GetByCompanyId(PortalContext.CurrentUser.CurrentCompanyId);
        }

        public void ChangeLanguage()
        {
            PortalContext.CurrentUser.SaveConfig(config => config.LanguageId = this.Query<int>("LanguageId"));
        }
    }
}