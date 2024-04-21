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
        //public string Register(IPageSetting setting)
        //{
        //    return this.ParseParamTo<RegisterRequest>().Do(setting);
        //}

        //public class RegisterRequest : IAjax
        //{
        //    [PropertyInfo(Name = "Người giới thiệu")] public string RefName { get; set; }
        //    [PropertyInfo(Name = "Tài khoản"), ValidatorRequire, ValidatorNotMultipleWhiteSpace(Stt = 1), ValidatorNotAllowSpecialCharacter(Stt = 2), ValidatorLength(Min = 8, Max = 20)] public string UserName { set; get; }
        //    [PropertyInfo(Name = "Email"), ValidatorRequire, ValidatorEmail(Stt = 1)] public string Email { set; get; }
        //    [PropertyInfo(Name = "Mật khẩu"), ValidatorRequire, ValidatorLength(Min = 8, Max = 20, Stt = 1)] public string Password { set; get; }
        //    [PropertyInfo(Name = "Nhập lại mật khẩu"), ValidatorRequire] public string Repassword { set; get; }

        //    public string Do(IPageSetting setting)
        //    {
        //        if (Password != Repassword) throw new Exception("Mật khẩu nhập lại không trùng khớp");
        //        // Kiểm tra xem tài khoản đã tồn tại hay chưa
        //        // Kiểm tra email đã tồn tại hay chưa
        //        if (WebMember.Inst.Exists(u => u.UserName == UserName)) throw new Exception("Tài khoản bạn chọn đã được sử dụng. Vui lòng chọn tài khoản khác");
        //        if (WebMember.Inst.Exists(u => u.Email == Email)) throw new Exception("Email bạn chọn đã được sử dụng. Vui lòng chọn Email khác");
                
        //        var refn = RefName == string.Empty ? null : WebMember.GetByUserName(RefName);
        //        var member = new WebMember
        //        {
        //            RefId = refn == null ? Guid.Empty : refn.MemberId,
        //            UserName = UserName,
        //            Email = Email,
        //            //PartnerType = Business.Entities.Websites.PartnerTypeEnum.KHACHLE,
        //            Password = Password.EncryptPassword(),
        //            CreatedDate = DateTime.Now,
        //            MemberId = Guid.NewGuid()
        //        };
        //        member.Insert();

        //        // Thực hiện gửi email
        //        // Vẫn thực hiện đăng nhập. Nhưng có thông báo để người dùng vào email kích hoạt
        //        // Trong trường hợp người dùng không kích hoạt thì vẫn cho sử dụng hệ thống bình thường :D
        //        // Sau này có chức năng hay thì vẫn phải ép người dùng kích hoạt
        //        //var setting = PageSetting.Cache.GetData();

        //        var htmlContent = setting.As<IEmailTemplateRegister>().EmailTemplateRegister_Body;
        //        if (htmlContent.IsNull())
        //        {
        //            htmlContent = "<div>" + Const.M19.Translate() + "</div>";
        //            htmlContent += "<div>" + Const.M20.Translate() + " </div>";
        //            htmlContent += "<div>" + Const.M5.Translate() + "</div>";
        //            htmlContent += "<div>" + Const.M21.Translate() + "</div>";
        //            htmlContent += "<div>" + Const.M22.Translate() + "</div>";
        //            htmlContent += "<div><a href='{LinkActive}'>{LinkActive}</a></div>";
        //        }

        //        htmlContent = htmlContent.Replace("{UserName}", member.UserName)
        //                                 .Replace("{SiteName}", setting.SiteName)
        //                                 .Replace("{CodeActive}", member.CodeActive)
        //                                 .Replace("{LinkActive}", FeContext.Page.GetFullUrl(FeUrl.Get("ActiveMember") + "?active=" + member.SerializeToString()));

        //        var subject = setting.As<IEmailTemplateRegister>().EmailTemplateRegister_Subject;
        //        if (subject.IsNull()) subject = Const.M23.Translate().Replace("{SiteName}", setting.SiteName);

        //        var mailer = FeContext.NewMailer(setting.As<IMailer>());
        //        mailer.Mail.To.Add(member.Email);
        //        mailer.Mail.Body = htmlContent;
        //        mailer.Mail.Subject = subject;
        //        mailer.Send(string.Empty);

        //        // Đăng nhập luôn
        //        var account = new Account { User = member };
        //        FeContext.Session.Authen(account, true);

        //        return Const.M24.Translate();
        //    }

        //    public interface IEmailTemplateRegister : IMailer
        //    {
        //        string EmailTemplateRegister_Subject { get; }
        //        string EmailTemplateRegister_Body { get; }
        //    }
        //}
    }
}
