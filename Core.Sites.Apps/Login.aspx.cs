using System;
using System.Web.UI;
using Core.Attributes.Validators;
using Core.Sites.Libraries;
using Core.Sites.Libraries.Business;
using Core.Business.Entities;
using Core.Web.WebBase;
using Core.Web.Extensions;
using System.Linq;

namespace Core.Sites.Apps
{
    public partial class Login : Page, IAjax
    {
        private const string LoginSuccessMessage = "Đăng nhập thành công. Đang tới trang quản trị ...";
        private const string LoginFailMessage = "Tài khoản hoặc mật khẩu không chính xác!";
        protected void Page_Load(object sender, EventArgs e)
        {
            fvc_Login.Href = AppSetting.BrandFavicon;
            if (PortalContext.Session.IsLoging)
            {
                Response.Redirect(UrlHelper.Home);
                return;
            }

            var languages = Language.GetLanguages();
            if (languages.Any())
            {

                dllLanguage.DataSource = languages;
                dllLanguage.DataBind();
                dllLanguage.SelectedValue = (dllLanguage.SelectedValue == "0" || dllLanguage.SelectedValue == string.Empty) ? languages.OrderBy(l => l.Stt).Select(l => l.LanguageId).FirstOrDefault().ToString() : dllLanguage.SelectedValue;
            }

            UserName = Request.QueryString["UserName"];
            Password = Request.QueryString["Password"];

            PortalContext.DefaultLanguage = Convert.ToInt32(dllLanguage.SelectedValue);
        }


        protected string UserName { set; get; } = string.Empty;
        protected string Password { set; get; } = string.Empty;
        protected void DoLogin(object sender, EventArgs e)
        {
            try
            {
                var user = Request.ParseWithValidate<UserForLogin>(true);
                if(user.Password == string.Empty || user.Password == "")
                {
                    ResponseMessage.Current.JavaScript = $"Core.notify('{LoginFailMessage}', null,'danger');";
                }
                var isValid = PortalContext.Session.Authen(user.UserName, user.Password);
                if (isValid)
                {
                    PortalContext.CurrentUser.SaveConfig(config => config.LanguageId = Convert.ToInt32(dllLanguage.SelectedValue));
                    ResponseMessage.Current.JavaScript = $"Core.notify('{LoginSuccessMessage}');";
                    ResponseMessage.SetTimeout($"window.location.href = '" + UrlHelper.Home + "'", 0);
                }
                else
                {
                    ResponseMessage.Current.JavaScript = $"Core.notify('{LoginFailMessage}', null,'danger');";
                }
            }
            catch(Exception ex)
            {
                ResponseMessage.Current.JavaScript = $"Core.notify('{ex.Message}', null,'danger');";
            }
        }

        [AjaxRequestConditionNotNeedLogin]
        public void LoadNotification()
        {
        }
    }
}