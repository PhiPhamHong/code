using System.Linq;
using System.Collections.Generic;
using Core.Business.Entities;
using Core.Web.WebBase;
using Core.Extensions;
using System;
using Core.Utility;
using Core.Business.Caches;
using EUser = Core.Business.Entities.User;
using Core.Business.Enums;

namespace Core.Sites.Libraries.Business
{
    public partial class PortalContext
    {
        public static MenuDocument MenuDocumentWithPermissions
        {
            get { return Context.Get("MenuDocumentWithPermissions", () => MenuDocument.Load(Session.IAccountInfo.Permissions(), SessionType)); }
        }
        public static List<MenuItem> ListMenuItemHasDashBoard
        {
            get
            {
                return Context.Get("ListMenuItemHasDashBoard", () => MenuDocument.MenuItemHasDashBoard(MenuDocument.Load(Session.IAccountInfo.Permissions(), SessionType, false), SessionType));
            }
        }

        public static CompanyConfig Config { get { return Context.Get("Config", () => CompanyConfig.Inst.GetByCompanyIdWithDefault(CurrentUser.GetCurrentCompanyId())); } }
        public static int DefaultLanguage
        {
            get { return Context.Get<int?>("DefaultLanguage", () => LanguageId).Value; }
            set { Context.Set<int?>("DefaultLanguage", value); }
        }
        private static int LanguageId
        {
            get
            {
                var languageId = Session.IAccountInfo == null ? 0 : Session.IAccountInfo.Config.LanguageId;
                return languageId == 0 ? AppSetting.Language : languageId;
            }
        }

        public static ISiteSession Session
        {
            get
            {
                if (Domain == AppSetting.Domain) return Singleton<SiteAccountSession>.Inst;
                //else if (Domain == AppSetting.DomainPartner) return Singleton<SitePartnerSession>.Inst; //Khi build có site partner nữa thì mới cần sài tới
                else return Singleton<SiteAccountSession>.Inst;
            }
        }

        public static SessionType SessionType
        {
            get
            {
                if (Domain == AppSetting.Domain) return SessionType.Account;
                //else if (Domain == AppSetting.DomainPartner) return SessionType.Partner;
                else return SessionType.Account;
            }
        }

        public static bool HasPermission(params int[] permissions) { return Session.HasPermission(permissions); }

        public static Dictionary<string, string> CacheLabelItem
        {
            get { return Context.Get("CacheLabelItem", () => new CacheLabelItem { CompanyId = Session.IAccountInfo == null ? 1 : CurrentUser.GetCurrentCompanyId(), LanguageId = DefaultLanguage }.Get()); }
        }
        public static string GetLabel(string lexicon) { return CacheLabelItem.TryGet(lexicon, lexicon); }        

        private static Random random = new Random();
        public static string CreateCode(string lastestCode, DateTime date, string prefix = "")
        {
            if (lastestCode.IsNull()) return prefix + random.Next(0, 10) + CurrentUser.User.EmployeeCode + "/" + date.ToString("yy") + "/01";

            var next = (lastestCode.Split('/').Last().To<int>() + 1).ToString();
            if (next.Length == 1) next = "0" + next;
            return prefix + random.Next(0, 10) + CurrentUser.User.EmployeeCode + "/" + date.ToString("yy") + "/" + next;
        }

        public partial class CurrentUser
        {
            public static IUserLogin User { get { return Session.IAccountInfo.UserLogin; } }

            public static bool FullPermission { get { return User.UserId == 1; } }
            public static int GetCurrentCompanyId() { return User.CompanyId; }
            public static int CurrentCompanyId { get { return User.CompanyId; } }
            public static EUser.UserSession.ConfigRuntime Config { get { return Session.IAccountInfo.Config; } }
            public static void SaveConfig() { Session.IAccountInfo.SaveSession(); }
            public static void SaveConfig(Action<EUser.UserSession.ConfigRuntime> action)
            {
                action(Config);
                SaveConfig();
            }

            public static bool CanSignInOtherAccount { get { return HasPermission(Per.P_20902); } }
            public static bool CanViewBranchCompany { get { return HasPermission(Per.P_20903); } }

            #region Check sự hợp lệ của công ty với người dùng hiện tại
            public static bool CheckValidCompanyIdWithUserCurrent(int companyId)
            {
                var currentCompanyId = GetCurrentCompanyId();
                if (currentCompanyId == AppSetting.CompanyFullPermission) return true;
                if (currentCompanyId == companyId) return true;
                var CompanyIdsInParent = Company.Inst.GetCompanyIdInParent(GetCurrentCompanyId());
                if (CompanyIdsInParent.Any(id => id == companyId)) return true;
                return false;
            }
            public static void ThrowIfCompanyIdNotValidWithUserCurrent(int companyId, string msg = "")
            {
                if (!CheckValidCompanyIdWithUserCurrent(companyId))
                    throw new Exception(msg.IsNull() ? "Công ty không phù hợp với công ty của người dùng hiện tại" : msg);
            }
            #endregion
            #region Check sự hợp lệ của người dùng vói người dùng hiện tại
            public static bool CheckValidUserIdWithUserCurrent(int userId)
            {
                if (userId == 0) return true;
                var user = new User { UserId = userId };
                if (user.GetByKey())
                    return CheckValidCompanyIdWithUserCurrent(user.CompanyId);
                return false;
            }
            public static void ThrowIfUserIdNotValidWithUserCurrent(int userId, string msg = "")
            {
                if (!CheckValidUserIdWithUserCurrent(userId))
                    throw new Exception(msg.IsNull() ? "Người dùng không hợp lệ" : msg);
            }
            #endregion

            /// <summary>
            /// Đầu vào là công ty. Nhưng cần phải check công ty id thật sự cần lấy ra có thỏa mãn hay không
            /// Có đúng thuộc công ty cha hoặc con trở xuống hay không
            /// Tránh trường hợp ông đăng nhập vào công ty A nhưng ôn lại xem dữ liệu của công ty B thuộc một nhánh khác
            /// </summary>
            /// <param name="companyId"></param>
            /// <returns></returns>
            public static int GetCompanyId(int companyId)
            {
                if (companyId == 0) companyId = GetCurrentCompanyId();
                else if (!CheckValidCompanyIdWithUserCurrent(companyId)) companyId = GetCurrentCompanyId();
                return companyId;
            }

            /// <summary>
            /// Trường hợp companyId không giống với company hiện tại, thì có thể kiểm tra tới công ty cha
            /// </summary>
            /// <param name="companyId_"></param>
            /// <returns></returns>
            public static int GetCompanyIdAuthen(int companyId_)
            {                
                var companyId = GetCompanyId(companyId_);

                if (companyId_ != companyId) // Công ty không hợp lệ => nên sẽ khác nhau
                {
                    // 
                    if (Session.IAccountInfo != null && Session.IAccountInfo.UserLogin2 != null)
                    {
                        var companyIdsInParent = Company.Inst.GetCompanyIdInParent(Session.IAccountInfo.CompanyId_1());
                        if (companyIdsInParent.Any(c => c == companyId_))
                            return companyId_;
                    }
                }

                return companyId;
            }
            public static EUser.ModuleConfig GetConfig(string module) => EUser.ModuleConfig.Get(CurrentCompanyId, User.UserId, module) ?? new EUser.ModuleConfig
            {
                Module = module,
                CompanyId = CurrentCompanyId,
                UserId = User.UserId
            };
        }
    }
}