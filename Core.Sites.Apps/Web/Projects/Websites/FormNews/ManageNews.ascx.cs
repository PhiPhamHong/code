using Core.Caching.CacheProvider;
using System;
using System.Collections.Generic;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Sites.Libraries.Business;
using Core.Sites.Apps.Web.Controls;
using Core.Business.Entities.Websites;
using Core.Business.Entities;
using Core.Web.WebBase;
using Core.DataBase.ADOProvider;

namespace Core.Sites.Apps.Web.Projects.Websites.FormNews
{
    [Module]
    [Script(Src = "/Web/Projects/Websites/FormNews/js/ManageNews.js")]
    [ManageModulePermission(Add = 22801, Edit = 22802, Delete = 22803)]
    public partial class ManageNews : ManageModule<News, News.Language, int, int, ManageNews.ModuleProvider, FormEditNews, FormEditNewsLanguage>
    {
        public static Category.Type Type { get { return PortalContext.GetCurrentModuleSetting<Category.Type>("Type"); } }
        public ManageNews()
        {
            this.SetData("NewType", Type);
        }
        public class ModuleProvider : ManageModuleProviderLanguage.Source<News.DataSource>, IAjax
        {
            protected override void AfterSave(News t)
            {
                WebCacheProvider.ClearAll();
            }
            protected override void SaveEntity(News t, IDataBaseService service)
            {
                t.Type = Type;
                base.SaveEntity(t, service);
            }

            public override News GetByKey(News t)
            {
                return base.GetByKey(t) ?? new News { DatePublished = DateTime.Now, IsActive = true, Type = t.Type };
            }
        }
    }
}