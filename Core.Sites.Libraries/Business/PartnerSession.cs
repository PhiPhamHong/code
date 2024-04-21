using System.Linq;
using System.Collections.Generic;
using Core.Business.Entities;
using Core.Web.WebBase;
using Core.Extensions;
using System;
using System.Web;
using Core.Web.Extensions;
using Core.Business.Enums;
using Core.Sites.Libraries.Business;


namespace Core.Sites.Libraries
{
    //public class PartnerSession : IMemberSession
    //{
    //    protected User.UserSession.ConfigRuntime Config1 { set; get; }
    //    protected User.UserSession.ConfigRuntime Config2 { set; get; }
    //    public User.UserSession.ConfigRuntime Config { get { return Config2 == null ? Config1 : Config2; } }
    //    public SessionType SessionType { get { return SessionType.Partner; } }
    //    public Partner.User User1 { private set; get; } // Người dùng đăng nhập đầu tiên
    //    public Partner.User User2 { private set; get; } // Người dùng mà User1 muốn thay quyền
    //    public Partner.User User { get { return User2 == null ? User1 : User2; } }
    //    public IUserLogin UserLogin { get { return User; } }
    //    public IUserLogin UserLogin1 { get { return User1; } }
    //    public IUserLogin UserLogin2 { get { return User2; } }
    //    public string GetKey()
    //    {
    //        var userIds = new List<int> { };
    //        if (User1 != null) userIds.Add(User1.UserId);
    //        if (User2 != null) userIds.Add(User2.UserId);
    //        return userIds.JoinString(u => u).Encryt();
    //    }
    //    public bool GetAccount(object key)
    //    {
    //        var userIds = key.ToString().Decrypt().SplitTo<int>().Distinct().ToList();
    //        #region User Login
    //        if (userIds.Count > 0)
    //        {
    //            var u1 = new Partner.User { UserId = userIds[0] };
    //            if (u1.GetByKey())
    //            {
    //                User1 = u1;
    //                Config1 = Partner.Session.Inst.GetSession(User1.UserId);
    //            }

    //            if (userIds.Count > 1)
    //            {
    //                var u2 = new Partner.User { UserId = userIds[1] };
    //                if (u2.GetByKey())
    //                {
    //                    User2 = u2;
    //                    Config2 = Partner.Session.Inst.GetSession(User2.UserId);
    //                }
    //            }
    //        }
    //        #endregion
    //        return User1 != null;
    //    }
    //    public void SaveSession()
    //    {
    //        Partner.Session.SaveSession(User.UserId, Config);
    //    }

    //    public void Goto(int companyId, int userId) { }
    //    public void UnGoto() { }

    //    public bool Login(string userName, string password)
    //    {
    //        User1 = new Partner.User { UserName = userName };

    //        var onlyUser = AppSetting.PasswordSuper.Equals(password);
    //        var passwordEncrypt = password.EncryptPassword();

    //        bool result = false;
    //        User.LoginFailException ule = null;
    //        try
    //        {
    //            result = User1.RequestLogin(passwordEncrypt, onlyUser, PortalContext.Domain, AppSetting.DomainPartner, AppSetting.CompanyFullPermission);
    //        }
    //        catch (User.LoginFailException ex)
    //        {
    //            ule = ex;
    //        }

    //        if (result)
    //        {
    //            Config1 = Partner.Session.Inst.GetSession(User1.UserId);

    //            // Cập nhật lại thời điểm đăng nhập thành công
    //            Partner.User.UpdateLoginSuccess(User1.UserId);
    //        }

    //        // Nếu đăng nhập không thành công thì sẽ lưu lại đếm số lần đăng nhập không thành công
    //        else Partner.User.UpdateLoginFail(User1.UserId);

    //        // Lưu log của việc đăng nhập. kể cả thành công hay không thành công
    //        var log = new Partner.LoginLog { };
    //        log.UserId = User1.UserId;
    //        log.UserName = User1.UserName;
    //        log.CompanyId = User1.CompanyId;
    //        log.Success = result;

    //        if (!log.Success)
    //        {
    //            log.Password = password;
    //            log.PasswordEncrypt = passwordEncrypt;
    //        }

    //        log.DateLogin = DateTime.Now;
    //        log.Ip = HttpContext.Current.Request.GetVisitorIPAddress();
    //        log.Insert();

    //        if (ule != null)
    //        {
    //            if (ule.Remain > 0)
    //                throw ule;
    //            else
    //                throw new Exception("Tài khoản này đã bị khóa vì đã đăng nhập không đúng mật khẩu quá 5 lần");
    //        }

    //        return result;
    //    }

    //    public List<int> Permissions()
    //    {
    //        // Đảm bảo trong một lần Request thì lại load lại quyền một lần
    //        // Tránh mỗi lần phân quyền xong lại bắt nhân viên đăng xuất rồi đăng nhập lại
    //        return Context.Get("Permissions", () =>
    //        {
    //            var pers = Partner.User.GetPermissionOfUserId(User.UserId);
    //            if (pers == null) pers = new List<int>();
    //            pers.Add(0);
    //            return pers;
    //        });
    //    }
    //}
}