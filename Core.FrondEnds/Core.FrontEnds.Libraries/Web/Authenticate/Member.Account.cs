using Core.Business.Entities.Websites;
using Core.Web.WebBase;
using System;
using Core.Extensions;
namespace Core.FrontEnds.Libraries.Web.Authenticate
{
    public partial class Member
    {
        public class Account : IAccount
        {
            //public WebMember User { set; get; } //Khai báo biến user bên web vô đây
            //public bool GetAccount(object key)
            //{
            //    User = new WebMember { MemberId = key.ToString().Decrypt().To<Guid>() };
            //    return User.GetByKey();
            //}
            //public string GetKey()
            //{
            //    return User.MemberId.ToString().Encryt();
            //}
            //public bool Login(string userName, string password)
            //{
            //    User = WebMember.Login(userName);
            //    if (User == null || User.Password != password.EncryptPassword()) throw new Exception("Thông tin đăng nhập không chính xác. Vui lòng thử lại");
            //    return true;
            //}
            public bool GetAccount(object key)
            {
                throw new NotImplementedException();
            }

            public string GetKey()
            {
                throw new NotImplementedException();
            }

            public bool Login(string userName, string password)
            {
                throw new NotImplementedException();
            }
        }
    }
}