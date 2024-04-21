using Core.Sites.Libraries.Business;
using Core.Business.Enums;

namespace Core.Sites.Libraries
{
    public class UrlHelper
    {
        private static readonly string extension = $".{AppSetting.Extension}";
        public static string Home { get { return $"/bang-dieu-khien{extension}"; } }
        public static string AssignPer { get { return $"/phan-quyen{extension}"; } }
        public static string AssignPerPackageService { get { return $"/phan-quyen-dich-vu{extension}"; } }
        public static string UpdateInfoUser
        {
            get
            {
                switch(PortalContext.SessionType)
                {
                    case SessionType.Partner: return $"/thong-tin-tai-khoan-dai-ly{extension}";
                    default: return $"/thong-tin-ca-nhan{extension}";
                }
            }
        }
        
        public static string Login { get { return "/Login.aspx"; } }
        public static string GetUrl(string url) { return $"/{url}{extension}"; }
        public static string ConfirmTransaction { get { return $"/confirm-giao-dich-khach-hang{extension}"; } }
    }
}