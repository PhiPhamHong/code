using Core.Attributes;
using Core.Attributes.Validators;
using Core.Business.Entities.Websites;
using Core.Utility;
using Core.Web.WebBase;
using System;
using Core.Extensions;
namespace Core.FrontEnds.Libraries.Web.Authenticate
{
    public partial class Member
    {
        //public string Forgot(IPageSetting setting)
        //{
        //    return this.ParseParamTo<ForgotRequest>().Do(setting);
        //}

        //public class ForgotRequest : IAjax
        //{
        //    [PropertyInfo(Name = "Email"), ValidatorRequire, ValidatorEmail(Stt = 1)] public string Email { set; get; }

        //    public string Do(IPageSetting setting)
        //    {
        //        var member = WebMember.GetByEmail(Email);
        //        if (member == null) throw new Exception(Const.M13);

        //        // Update tất cả các yêu cầu lấy mật khẩu trước đang đợi về trạng thái cancel
        //        WebMember.Forgot.UpdateState(member.MemberId, WebMember.ForgotState.Waiting, WebMember.ForgotState.Cancel);
        //        var forgot = new WebMember.Forgot
        //        {
        //            MemberId = member.MemberId,
        //            Date = DateTime.Now,
        //            Code = Keygend.RenderKeyRandom(10)
        //        };
        //        forgot.Insert();

        //        var htmlContent = setting.As<IEmailTemplateForgotAccount>().EmailTemplateForgotAccount_Body;
        //        if (htmlContent.IsNull())
        //        {
        //            htmlContent = "<div>" + Const.M9.Translate() + "</div>";
        //            htmlContent += "<div>" + Const.M10.Translate() + "</div>";
        //            htmlContent += "<div><a href='{LinkForgot}'>{LinkForgot}</a></div>";
        //        }

        //        htmlContent = htmlContent.Replace("{UserName}", member.UserName)
        //                                 .Replace("{SiteName}", setting.SiteName)
        //                                 .Replace("{LinkForgot}", FeContext.Page.GetFullUrl(FeUrl.Get("ForgotMember") + "?active=" + forgot.SerializeToString()));

        //        var subject = setting.As<IEmailTemplateForgotAccount>().EmailTemplateForgotAccount_Subject;
        //        if (subject.IsNull()) subject = Const.M11.Translate().Replace("{SiteName}", setting.SiteName);

        //        var mailer = FeContext.NewMailer(setting.As<IMailer>());
        //        mailer.Mail.To.Add(member.Email);
        //        mailer.Mail.Body = htmlContent;
        //        mailer.Mail.Subject = subject;
        //        mailer.Send(string.Empty);

        //        return Const.M12.Translate();
        //    }

        //    public interface IEmailTemplateForgotAccount
        //    {
        //        string EmailTemplateForgotAccount_Subject { get; }
        //        string EmailTemplateForgotAccount_Body { get; }
        //    }
        //}
    }
}