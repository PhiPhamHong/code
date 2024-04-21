using Core.Utility;
using Core.Utility.Xml;
using Core.Extensions;
using Core.Business.Entities.Websites;
using Core.FrontEnds.Libraries.Web.Caches;
using System.Collections.Generic;
using System.Linq;
using Core.FrontEnds.Libraries.Web.Authenticate;

namespace Core.FrontEnds.Libraries.Web
{
    public partial class FeContext
    {        
        public static Seo Seo { get { return Get(() => CacheSeo.GetData().FirstOrDefault(s => s.LanguageId == Url.LanguageId) ?? Seo.Empty, SEO); } }
        public static int SiteId { get { return GetParam<int>(SITE); } }
        public static List<Meta> Metas { get { return Get(() => CacheMeta.GetData(), META); } }

        private const string SEO = "Seo";
        private const string SITE = "site";
        private const string META = "Meta";
        private const string PAGESCONFIG = "PagesConfig";

        public static WebPagesConfig PagesConfig
        {
            get { return Get(() => CacheReadConfig<WebPagesConfig>.Load(), PAGESCONFIG); }
        }

        public static ShMailer NewMailer(IMailer config)
        {
            var mailer = new ShMailer();
            mailer.Smtp.Host = config.EmailHost.WhenEmpty("smtp.gmail.com");
            if (config.EmailSendBy.IsNotNull()) mailer.SendBy = config.EmailSendBy;

            if (config.EmailPort != 0) mailer.Smtp.Port = config.EmailPort;
            if (config.EmailCC.IsNotNull()) mailer.Mail.CC.Add(config.EmailCC);

            if (config.EmailFromId.IsNotNull()) mailer.EmailFrom = config.EmailFromId;
            if (config.EmailFromPassword.IsNotNull()) mailer.PasswordEmailFrom = config.EmailFromPassword;

            return mailer;
        }

        public static Member.Session Session
        {
            get { return Singleton<Member.Session>.Inst; }
        }


        // người dùng hiện tại ở web
        //public static WebMember CurrentMember
        //{
        //    get { return Session.AccountInfo.User; }
        //}

        public const int DefaultLanguageId = 2;
    }
}
