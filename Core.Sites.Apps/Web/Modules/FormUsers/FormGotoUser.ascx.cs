using Core.Attributes;
using Core.Attributes.Validators;
using Core.Sites.Libraries;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Web.WebBase;

namespace Core.Sites.Apps.Web.Modules.FormUsers
{
    [Script(Src = "/Web/Modules/FormUsers/js/FormGotoUser.js")]
    [Module]
    public partial class FormGotoUser : PortalModule<FormGotoUser.GotoInfo>, IAjax
    {
        protected override void OnInitData()
        {
            this.SetData("InOtherUser", PortalContext.Session.IAccountInfo.User_2() != 0);
        }

        protected int CurrentCompanyId
        {
            get
            {
                var companyId = PortalContext.Session.IAccountInfo.CompanyId_2();
                if (companyId == 0)
                    companyId = PortalContext.Session.IAccountInfo.CompanyId_1();
                return companyId;
            }
        }

        public void Goto()
        {
            this.ParseParamTo<GotoInfo>(true).Goto();
            PortalContext.Session.ExtendTimeCookie();
            ResponseMessage.SetTimeout("window.location.href = '" + UrlHelper.Home + "'", 1000);
        }

        public void UnGoto()
        {
            PortalContext.Session.IAccountInfo.UnGoto();
            PortalContext.Session.ExtendTimeCookie();
            ResponseMessage.SetTimeout("window.location.href = '" + UrlHelper.Home + "'", 1000);
        }

        public class GotoInfo
        {
            [PropertyInfo(Name = "Công ty"), ValidatorDenyValue(0)] public int CompanyId { set; get; }
            [PropertyInfo(Name = "Người dùng"), ValidatorDenyValue(0)] public int UserId { set; get; }

            public void Goto()
            {
                PortalContext.Session.IAccountInfo.Goto(CompanyId, UserId);
            }
        }
    }
}