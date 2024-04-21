using Core.Utility;
using System.Web;
using System;
using Core.Extensions;
using System.Web.Security;
namespace Core.Web.WebBase
{
    /// <summary>
    /// T Ở đây là thông tin của một Account
    /// </summary>
    /// <typeparam name="TAccountSession"></typeparam>
    public class AccountSession<TAccountSession> : Singleton<AccountSession<TAccountSession>> where TAccountSession : class, IAccount, new()
    {
        private string keySession = string.Empty;
        /// <summary>
        /// Key lưu session và cookies của account login
        /// </summary>
        protected string KeySession
        {
            get
            {
                // Tên Session
                if (keySession.IsNull()) keySession = typeof(TAccountSession).FullName;
                return keySession;
            }
        }

        /// <summary>
        /// Đối tượng chứa thông tin Account được lưu tong session
        /// </summary>
        private TAccountSession Info
        {
            get { return HttpContext.Current.Session[KeySession] as TAccountSession; }
            set { HttpContext.Current.Session[KeySession] = value; }
        }

        /// <summary>
        /// Kiểm tra xem đã được đăng nhập hay chưa
        /// </summary>
        public bool IsLoging { get { return Refresh(); } }

        private bool Refresh()
        {
            // Khai báo biến để kiểm ra account đang đăng nhập hay chưa
            var isLogin = false;

            // Kiểm tra trong session có dữ liệu hay không
            // Không có nghĩa là chưa đănng nhập
            isLogin = Info != null;

            // Nếu trong session không có dữ liệu thì kiểu tra trong cookies
            if (!isLogin)
            {
                // Lấy ra cookie
                var cookie = HttpContext.Current.Request.Cookies[KeySession];

                // Kiểm tra xem cookie có rỗng hay không
                // Rỗng thì là chưa đăng nhập
                isLogin = cookie == null || string.IsNullOrEmpty(cookie.Value) ? false : true;

                // Nếu cookie có dữ liệu thì lấy ra thông tin người dùng và lại đưa vào session
                if (isLogin)
                {
                    // Khởi tạo thông tin Account
                    var t = new TAccountSession();

                    // Truy vấn lấy thông tin. Nếu như tồn tại Member thì thiết lập vào Session
                    if (isLogin = t.GetAccount(cookie.Value))
                    {
                        Authen(t, false);
                    }
                }
            }

            return isLogin;
        }

        /// <summary>
        /// Session lưu trữ thông tin về Acccount
        /// </summary>
        public TAccountSession AccountInfo
        {
            get
            {
                if (Info == null) Refresh();
                return Info;
            }
        }

        public void Authen(TAccountSession model, bool setTimeCookie = true)
        {
            Info = model;  // Đưa vào Session
            if (setTimeCookie)
                ExtendTimeCookieHelper();
        }

        /// <summary>
        /// Thực hiện thoát ra khỏi hệ thống
        /// </summary>
        public void SignOut()
        {
            // Đưa cookie về giá trị Empty
            var cookie = new HttpCookie(KeySession);
            cookie.Value = string.Empty;
            cookie.Expires = DateTime.Now.AddHours(-1);
            FormsAuthentication.SetAuthCookie(cookie.Value, true);
            HttpContext.Current.Response.Cookies.Add(cookie);
            HttpContext.Current.Request.Cookies.Clear();

            // Hủy session
            Info = null;
        }

        /// <summary>
        /// Gia hạn thêm cho cookie về thông tin account đăng nhập
        /// </summary>
        public void ExtendTimeCookie()
        {
            if (IsLoging)
                ExtendTimeCookieHelper();            
        }

        protected void ExtendTimeCookieHelper()
        {
            // Tạo đối tượng Cookie lưu xuống client
            var cookie = new HttpCookie(KeySession);

            // Gán giá trị cookie cần lưu xuống client
            cookie.Value = Info.GetKey();

            // Thiết lập bảo mật
            // cookie.Secure = true;

            // Tăng thời gian hủy cookie lên 1 ngày
            //cookie.Expires = DateTime.Now.AddDays(1);
            //cookie.Expires = DateTime.Now.AddMinutes(30);
            cookie.Expires = DateTime.Now.AddHours(4);

            // SetAuthCookie
            FormsAuthentication.SetAuthCookie(cookie.Value, true);

            // Đưa cookie xuống client
            // this.Page.Response.Cookies.Add(cookie);
            HttpContext.Current.Response.Cookies.Set(cookie);
        }

        public bool Authen(string userName, string password)
        {
            var t = new TAccountSession();
            if (t.Login(userName, password)) { Authen(t); return true; }
            return false;
        }
    }

    public class NotAuthenException : Exception 
    {
        public NotAuthenException() : base("Hết phiên làm việc") { }
    }

    public class EndException : Exception { }
}
