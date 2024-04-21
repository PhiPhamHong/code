using Core.Attributes;
using Core.Attributes.Validators;
using Core.Business.Entities.Websites;
using Core.Web.WebBase;
using System;
using Core.Extensions;
namespace Core.FrontEnds.Libraries.Web.Authenticate
{
    public partial class Member
    {
        //public void ChangePassword()
        //{
        //    this.ParseParamTo<ChangePasswordRequest>().Do();
        //}

        //public class ChangePasswordRequest : IAjax
        //{
        //    [PropertyInfo(Name = "Mật khẩu cũ"), ValidatorRequire] public string OldPassword { set; get; }
        //    [PropertyInfo(Name = "Mật khẩu mới"), ValidatorRequire, ValidatorLength(Min = 8, Max = 20, Stt = 1)] public string NewPassword { set; get; }
        //    [PropertyInfo(Name = "Nhập lại mật khẩu"), ValidatorRequire] public string ReNewPassword { set; get; }

        //    public void Do()
        //    {
        //        if (NewPassword != ReNewPassword) throw new Exception("Mật khẩu nhập lại không trùng khớp");
        //        var member = new WebMember { MemberId = FeContext.CurrentMember.MemberId };
        //        member.GetByKey();

        //        if (member.Password != OldPassword.EncryptPassword())
        //            throw new Exception("Mật khẩu cũ không chính xác. Vui lòng thử lại");

        //        WebMember.UpdatePassword(member.MemberId, NewPassword.EncryptPassword());
        //    }
        //}
    }
}
