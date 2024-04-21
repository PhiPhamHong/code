using System;
using System.Linq;
using System.Web.UI;
using Core.Sites.Libraries;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Web.WebBase;
namespace Core.Sites.Apps.Web.Controls
{
    public partial class Content : UserControl, IAjax
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Kiểm tra quyền => Nếu có quyền thì load ko thì lượn về trang Login
            var checkPermission = PortalContext.CurrentPage.UrlData.MenuItem == null || !PortalContext.Session.HasPermission(PortalContext.CurrentPage.UrlData.MenuItem.Pers);
            if (checkPermission)
            {
                PortalContext.Session.SignOut();
                Response.Redirect(UrlHelper.Login, true);
                return;
            }

            // Load module sau khi đã check phân quyền hết tất cả
            plc.Controls.Add(CreateModule(string.Empty));

            // Khởi động UrlState => maintain trang khi chuyển link không load lại trang
            ResponseMessage.Current.JavaScript = "$(function(){ Hub.app = new AppHub(); new UrlState().start(res); })";
        }

        public void LoadModule()
        {
            if (PortalContext.CurrentPage.UrlData == null) return;
            CreateModule(PortalContext.CurrentPage.PathAndQuery.T2);
        }

        public PortalModule CreateModule(string query) { return (PortalModule)AppSetting.License.CreateModule_App(query); }
        public void LoadModuleByControl() { AppSetting.License.LoadModuleByControl_App(); }
        public void LoadScriptByModule() { AppSetting.License.LoadScriptByModule_App(); }

        public void LoadMenuLeft()
        {
            //var module = Control<MenuLeft>.Create();
            //module.MenuTop =  PortalContext.MenuDocument.Menus.FirstOrDefault(m => m.UrlVirtual == this.Query<string>("menu"));
            //module.InitData();
            //this.SetData("ModuleMenu", module.Html);
            this.SetData("ModuleMenu", string.Empty);
        }
    }
}