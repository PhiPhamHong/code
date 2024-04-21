using Core.Attributes;
using Core.Attributes.Validators;
using Core.Business.Entities.Websites;
using Core.Web.WebBase;
using System;
using Core.Extensions;
using Core.Utility;

namespace Core.FrontEnds.Libraries.Web.Authenticate
{
    public partial class Member
    {
        //public string Active(IPageSetting setting) //Case Active tài khoản
        //{
        //    return this.ParseParamTo<ActiveRequest>().Do(setting);
        //}

        //public class ActiveRequest : IAjax
        //{
        //    [PropertyInfo(Name = "Tài khoản"), ValidatorRequire] public string UserName { set; get; }
        //    [PropertyInfo(Name = "Mã xác nhận")] public string Code { set; get; }

        //    public string Do(IPageSetting setting)
        //    {
        //        var member = WebMember.GetByUserName(UserName);
        //        if (member == null) throw new Exception(Const.M1);
        //        if (member.CodeActive != Code) throw new Exception(Const.M2);
        //        if (member.CodeActive == Code && member.IsActive) throw new Exception(Const.M3);

        //        WebMember.UpdateIsActive(member.MemberId, true);

        //        var htmlContent = setting.As<IEmailTemplateActive>().EmailTemplateActive_Body;
        //        if (htmlContent.IsNull())
        //        {
        //            htmlContent = "<div>" + Const.M4.Translate() + "</div>";
        //            htmlContent += "<div>" + Const.M5.Translate() + "</div>";
        //            htmlContent += "<div>" + Const.M6.Translate() + "</div>";
        //        }

        //        htmlContent = htmlContent.Replace("{UserName}", member.UserName)
        //                                 .Replace("{SiteName}", setting.SiteName);

        //        var subject = setting.As<IEmailTemplateActive>().EmailTemplateActive_Subject;
        //        if (subject.IsNull()) subject = Const.M7.Translate().Replace("{SiteName}", setting.SiteName);

        //        var mailer = FeContext.NewMailer(setting.As<IMailer>());
        //        mailer.Mail.To.Add(member.Email);
        //        mailer.Mail.Body = htmlContent;
        //        mailer.Mail.Subject = subject;
        //        mailer.Send(string.Empty);

        //        return Const.M8.Translate().Replace("{Email}", member.Email);
        //    }

        //    public interface IEmailTemplateActive
        //    {
        //        string EmailTemplateActive_Subject { get; }
        //        string EmailTemplateActive_Body { get; }
        //    }
        //}
    }
}
