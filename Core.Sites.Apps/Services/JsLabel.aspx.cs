using System;
using System.Linq;
using System.Web.UI;
using Core.Business.Entities;
using Core.Web.WebBase;
using Core.Extensions;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries;
using System.Collections.Generic;
namespace Core.Sites.Apps.Services
{
    public partial class JsLabel : Page, IAjax
    {
        public void Page_Load(object sender, EventArgs e)
        {
            var langId = this.Query<int>("lang");
            var data = new Dictionary<string, string> { };
            Label.GetAllLabelItems(1, langId).ForEach(l => data[l.Lexicon] = l.Value);
            try
            {
                var companyId = PortalContext.CurrentUser.GetCurrentCompanyId();
                if (companyId != 1)
                    Label.GetAllLabelItems(companyId, langId).ForEach(l => data[l.Lexicon] = l.Value);
            }
            catch { }

            if (PortalContext.Session.IAccountInfo != null && PortalContext.Session.IAccountInfo.UserLogin != null)
            {
                Response.Write("var currentUser = " + PortalContext.Session.IAccountInfo.UserLogin.UserId + ";\n");
                Response.Write("var SessionType = " + (byte)PortalContext.SessionType + ";\n");
            }

            Response.Write("var HubServer = '" + AppSetting.HubServer + "';\n");
            Response.Write("var LangId = " + langId + ";\n");
            Response.Write("var Langs = " + data.ToJson2() + ";\n");
            Response.Write("var VerJs = " + AppSetting.VerJs + ";\n");

            try
            {
                Response.Write("var UserMenuDropDown = " + PortalContext.CurrentUser.Config.UseMenuDropdown.ToJson2() + ";");
                Response.Write("function Config() { };");
                Response.Write("Config.Data = " + PortalContext.CurrentUser.Config.ToJson2());
            }
            catch { }
        }
    }
}