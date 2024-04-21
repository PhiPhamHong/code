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
        //public string GetPassword(IPageSetting setting)
        //{
        //    return this.ParseParamTo<GetPasswordRequest>().Do(setting);
        //}

        //public class GetPasswordRequest : IAjax
        //{
        //    [PropertyInfo(Name = "Tài khoản"), ValidatorRequire] public string UserName { set; get; }
        //    [PropertyInfo(Name = "Mã xác nhận")] public string Code { set; get; }

        //    public string Do(IPageSetting setting)
        //    {
        //        var member = WebMember.GetByUserName(UserName);
        //        if (member == null) throw new Exception("Tài khoản không tồn tại. Vui lòng thực hiện lại thao tác lấy mật khẩu.");

        //        var forgot = WebMember.Forgot.GetByCode(member.MemberId, Code);
        //        if (forgot == null || forgot.State == WebMember.ForgotState.Done || forgot.State == WebMember.ForgotState.Cancel)
        //            throw new Exception("Mã xác thực không tồn tại hoặc đã được sử dụng. Vui lòng thực hiện lại thao tác lấy mật khẩu");

        //        // Đánh dấu mã xác nhận đã được sử dụng
        //        WebMember.Forgot.UpdateState(forgot.ForgotId, WebMember.ForgotState.Done);

        //        // Tạo lại mật khẩu mới
        //        var newPassword = Keygend.RenderKeyRandom(10);
        //        WebMember.UpdatePassword(member.MemberId, newPassword.EncryptPassword());

        //        // Gửi email thông báo
        //        var htmlContent = setting.As<IEmailTemplateGetPassword>().EmailTemplateGetPassword_Body;
        //        if (htmlContent.IsNull())
        //        {
        //            htmlContent = "<div>" + Const.M14.Translate() + "</div>";
        //            htmlContent += "<div>" + Const.M5.Translate() + "</div>";
        //            htmlContent += "<div>" + Const.M15.Translate() + "</div>";
        //            htmlContent += "<div>" + Const.M16.Translate() + "</div>";
        //        }

        //        htmlContent = htmlContent.Replace("{UserName}", member.UserName)
        //                                 .Replace("{SiteName}", setting.SiteName)
        //                                 .Replace("{Password}", newPassword);

        //        var subject = setting.As<IEmailTemplateGetPassword>().EmailTemplateGetPassword_Subject;
        //        if (subject.IsNull()) subject = Const.M17.Translate().Replace("{SiteName}", setting.SiteName);

        //        var mailer = FeContext.NewMailer(setting.As<IMailer>());
        //        mailer.Mail.To.Add(member.Email);
        //        mailer.Mail.Body = htmlContent;
        //        mailer.Mail.Subject = subject;
        //        mailer.Send(string.Empty);

        //        return Const.M18.Translate().Replace("{Email}", member.Email);
        //    }

        //    public interface IEmailTemplateGetPassword
        //    {
        //        string EmailTemplateGetPassword_Subject { get; }
        //        string EmailTemplateGetPassword_Body { get; }
        //    }
        //}
    }
}
