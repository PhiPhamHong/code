using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;

using Core.Utility;
using Core.Web.Extensions;
using Core.Web.WebBase;

using Core.Sites.Libraries.Utilities;
using Core.Business.Entities;
using Core.Extensions;
using Core.Reflectors;
using Core.DataBase.ADOProvider;
using Core.Business.Enums;
using Core.DataBase.ADOProvider.Attributes;
using SendGrid;

namespace Core.Sites.Libraries.Business
{
    public partial class PortalContext
    {
        #region Core
        public static MenuDocument MenuDocument { get { return Context.Get("MenuDocument", () => MenuDocument.Load(SessionType)); } }
        public static GlobalConfig GlobalConfig { get { return Context.Get("GlobalConfig", () => GlobalConfig.GetByCompanyId(Config.CompanyId) ?? GlobalConfig.Empty); } }

        public static bool IsAjax
        {
            get { return Context.Get<string>("IsAjax") == "true"; }
            set { Context.Set("IsAjax", value ? "true" : "false"); }
        }
        public static Page CurrentPage
        {
            set { Context.Set("CurrentPage", value); }
            get { return Context.Get<Page>("CurrentPage"); }
        }
        public static TValue GetCurrentModuleSetting<TValue>(string name) { return CurrentPage.UrlData.MenuItem.GetSetting<TValue>(name); }

        public static string PageTitle { set { ResponseMessage.Current.Data["PageTitle"] = value; } }
        public static List<PermissionAttribute> PermissionOfSystems(SessionType sessionType)
        {
            return Context.Get("PermissionOfSystems_" + sessionType, () => Per.Get(sessionType));
        }
        public class Page
        {
            public CacheUrl.CacheUrlData UrlData { set; get; }
            public Pair<string, string> PathAndQuery { set; get; }
            public NameValueCollection Query { get { return IsAjax ? queryAjax : HttpContext.Current.Request.Params; } }
            private NameValueCollection queryAjax = null;
            public static Page GetPage(string url, SessionType sessionType)
            {
                url = url.Replace("http://" + HttpContext.Current.Request.Url.Authority, string.Empty);
                var page = new Page();
                page.PathAndQuery = HttpContext.Current.Request.SplitUrl(url, AppSetting.Extension);
                page.UrlData = CacheUrl.GetData(page.PathAndQuery.T1, sessionType);
                page.queryAjax = HttpUtility.ParseQueryString(page.PathAndQuery.T2);
                return page;
            }
        }

        public static T SetAuthor<T, TKey>(T model) where T : IAuthor, IModel<TKey>
        {
            if (model.Key.Equals(default(TKey)))
            {
                model.UpdatedByUserId = model.CreatedByUserId = CurrentUser.User.UserId;
                model.UpdatedDate = model.CreatedDate = DateTime.Now;
            }
            else
            {
                model.UpdatedByUserId = CurrentUser.User.UserId;
                model.UpdatedDate = DateTime.Now;
            }

            return model;
        }
        #endregion

        public static string Domain
        {
            get { return HttpContext.Current.Request.Url.Authority; }
        }

        public static ModelListSave<T> SplitItems<T, TKey>(string prefix, Func<List<T>> oldItems, Func<bool> needDelete, bool needValidate, bool validateFullProperties)
            where T : IEmpty, IModel<TKey>, new()
        {
            return IAjaxExtension.GetObjectsHelper<T>(prefix, needValidate, validateFullProperties).SplitItems<T, TKey>(oldItems, needDelete);
        }

        public static ShMailer NewMailer()
        {
            return NewMailer(Config);
        }
        public static ShMailer NewMailer(CompanyConfig config)
        {
            var mailer = new ShMailer();
            mailer.Smtp.Host = config.EmailHost.WhenEmpty("smtp.gmail.com");
            if (config.EmailSendBy.IsNotNull()) mailer.SendBy = config.EmailSendBy;

            if (config.EmailPort.IsNotNull()) mailer.Smtp.Port = config.EmailPort.Value;
            if (config.EmailCC.IsNotNull()) mailer.Mail.CC.Add(config.EmailCC);

            if (config.EmailFromId.IsNotNull()) mailer.EmailFrom = config.EmailFromId;
            if (config.EmailFromPassword.IsNotNull()) mailer.PasswordEmailFrom = config.EmailFromPassword;

            return mailer;
        }
        public static SendGridProvider SendGridProvider(CompanyConfig config, Action<SendGridProvider> ac)
        {
            var sendGridClient = new SendGridClient(config.SendGrid_API);
            var sgp = new SendGridProvider { SendGridClient = sendGridClient };
            sgp.SendGridMessage.SetFrom(config.SendGrid_API_Email, config.SendGrid_API_Name);
            ac(sgp);
            return sgp;
        }
        public static WebCenter WebCenter { set; get; }
        public static void WebCenterUpdateCompayConfig(CompanyConfig config)
        {
            WebCenter.UpdateCompayConfig(config);
        }
        private static List<PathItem> LoadPathImageForMenuConfig()
        {
            var assemblies = AppSetting.Assemblies;
            if (assemblies == null) return new List<PathItem>();
            return assemblies.SelectMany(a => ReflectAssemblyClassInfoAttribute<ModuleAttribute>.Inst[a].Select<ModuleAttribute, PathItem>(m => m)).ToList();            
        }
        public static List<PathItem> PathImageForMenuConfig = LoadPathImageForMenuConfig();
    }

    public static class IModelExtension
    {
        public static ModelListSave<TEntityForeign> SplitItems<TKey, TEntityForeign>(this IModel<TKey> t, string prefix, bool needValidate = true)
            where TEntityForeign: IModelForeign<TKey, TEntityForeign>, IEmpty, IModel<TKey>, new()
        {
            return IAjaxExtension.GetObjectsHelper<TEntityForeign>(prefix, needValidate , true)
                .Select(item => 
                {
                    if (item.Is<IModelForeignValidate>()) item.As<IModelForeignValidate>().ValidateDetail();
                    return item;
                })
                .SplitItems<TEntityForeign, TKey>(() => new TEntityForeign().GetDetails(t.Key), () => !Equals(t.Key, default(TKey)));
        }

        public static string JoinToStringGetNames<TEntity, TKey>(this IEnumerable<TEntity> entites, string ids)
            where TEntity : IModel<TKey>, IEntityForLogShowName
        {
            return entites.Join(ids.SplitTo<TKey>(), e => e.Key, key => key, (e, key) => e.Name).JoinString(n => n);
        }
    }
}