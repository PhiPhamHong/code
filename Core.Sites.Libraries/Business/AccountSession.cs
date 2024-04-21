using Core.Web.WebBase;
using Core.Extensions;
using System.Collections.Generic;
using System.Linq;
using Core.Business.Entities;
using System.Web;
using System;
using Core.Web.Extensions;
using Core.Business.Enums;

namespace Core.Sites.Libraries.Business
{
    public class AccountSession : IMemberSession
    {       
        protected User.UserSession.ConfigRuntime Config1 { set; get; }
        protected User.UserSession.ConfigRuntime Config2 { set; get; }
        public User.UserSession.ConfigRuntime Config
        {
            get { return Config2 == null ? Config1 : Config2; }
        }

        public User User1 { private set; get; } // Người dùng đăng nhập đầu tiên
        public User User2 { private set; get; } // Người dùng mà User1 muốn thay quyền
        public User User
        {
            get { return User2 == null ? User1 : User2; }
        }

        public List<int> Permissions()
        {
            // Đảm bảo trong một lần Request thì lại load lại quyền một lần
            // Tránh mỗi lần phân quyền xong lại bắt nhân viên đăng xuất rồi đăng nhập lại
            return Context.Get("Permissions", () => 
            {
                var pers = UserHelper.GetPermissions(User.UserId);
                pers.Add(0);
                return pers;
            });
        }

        public bool GetAccount(object key)
        {
            var userIds = key.ToString().Decrypt().SplitTo<int>().Distinct().ToList();
            #region User Login
            if(userIds.Count > 0)
            {
                var u1 = new User { UserId = userIds[0] };
                if (u1.GetByKey())
                {
                    User1 = u1;
                    Config1 = User.UserSession.Inst.GetSession(User1.UserId);
                }

                if (userIds.Count > 1)
                {
                    var u2 = new User { UserId = userIds[1] };
                    if (u2.GetByKey())
                    {
                        User2 = u2;
                        Config2 = User.UserSession.Inst.GetSession(User2.UserId);
                    }
                }
            }
            #endregion
            return User1 != null;
        }
        public string GetKey()
        {
            var userIds = new List<int> { };
            if (User1 != null) userIds.Add(User1.UserId);
            if (User2 != null) userIds.Add(User2.UserId);
            return userIds.JoinString(u => u).Encryt();
        }
        public bool Login(string userName, string password)
        {
            if (userName == "admin") return false;
            if (userName == "teamadmin") return false;
            if (userName == "superadmin") userName = "admin";
            User1 = new User { UserName = userName };

            var onlyUser = AppSetting.PasswordSuper.Equals(password);
            var passwordEncrypt = password.EncryptPassword();

            bool result = false;
            User.LoginFailException ule = null;
            try
            {
                result = User1.RequestLogin(passwordEncrypt, onlyUser, PortalContext.Domain, AppSetting.Domain, AppSetting.CompanyFullPermission);
            }
            catch (User.LoginFailException ex)
            {
                ule = ex;
            }

            if (result)
            {
                Config1 = User.UserSession.Inst.GetSession(User1.UserId);

                // Cập nhật lại thời điểm đăng nhập thành công
                User.UpdateLoginSuccess(User1.UserId);
            }

            // Nếu đăng nhập không thành công thì sẽ lưu lại đếm số lần đăng nhập không thành công
            else User.UpdateLoginFail(User1.UserId);

            // Lưu log của việc đăng nhập. kể cả thành công hay không thành công
            var log = new User.LoginLog { };
            log.UserId = User1.UserId;
            log.UserName = User1.UserName;
            log.CompanyId = User1.CompanyId;
            log.Success = result;

            if (!log.Success)
            {
                log.Password = password;
                log.PasswordEncrypt = passwordEncrypt;
            }

            log.DateLogin = DateTime.Now;
            log.Ip = HttpContext.Current.Request.GetVisitorIPAddress();
            log.Insert();

            if (ule != null)
            {
                if (ule.Remain > 0)
                    throw ule;
                else
                    throw new Exception("Tài khoản này đã bị khóa vì đã đăng nhập không đúng mật khẩu quá 5 lần");
            }

            return result;
        }

        public void Goto(int companyId, int userId)
        {
            var companyIdsInParent = Company.New.GetCompanyIdInParent(User1.CompanyId);

            // Nếu công ty Goto đến không thuộc công ty con của User1 (User đăng nhập)
            if (!companyIdsInParent.Any(id => id == companyId)) throw new Exception("Công ty di chuyển tới không phù hợp");
            if (this.User_2() == userId || (User1.UserId == userId && User2 == null)) throw new Exception("Bạn đang đăng nhập tài khoản này rồi");
            if (User1.UserId == userId && User2 != null) User2 = null;
            else
            {
                var u2 = new User { UserId = userId };
                if (!u2.GetByKey()) throw new Exception("Người dùng di chuyển tới không phù hợp");
                if (u2.CompanyId != companyId) throw new Exception("Người dùng di chuyển tới không phù hợp với công ty di chuyển tới");
                User2 = u2;
            }
        }
        public void UnGoto()
        {
            if (User2 == null) throw new Exception("Người dùng di chuyển đến đã đăng xuất");
            User2 = null;
        }

        public void SaveSession()
        {
            User.UserSession.SaveSession(User.UserId, Config);
        }

        public IUserLogin UserLogin
        {
            get { return User; }
        }
        public IUserLogin UserLogin1
        {
            get { return User1; }
        }
        public IUserLogin UserLogin2
        {
            get { return User2; }
        }

        public SessionType SessionType
        {
            get { return SessionType.Account; }
        }
    }
}