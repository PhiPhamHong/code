using Core.DataBase.ADOProvider;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Web.WebBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core.Sites.Partner.Apps
{
    [ControlFolder(Folder = "Web/Core.Sites.Partner.Apps")]
    public class PartnerPortalModule<TEntity, TEntityLanguage, TKey, TKeyLanguage> : PortalModule<TEntity, TEntityLanguage, TKey, TKeyLanguage>
        where TEntity : ModelBase, IModel<TKey>, new()
        where TEntityLanguage : ModelBase, ILanguage<TEntityLanguage, TKey, TKeyLanguage>, IModel<TKey>, new()
    {

    }

    [ControlFolder(Folder = "Web/Core.Sites.Partner.Apps")]
    public class PartnerPortalModule<TEntity> : PortalModule<TEntity> where TEntity : class, new()
    {

    }

    public class PartnerPortalModule : PartnerPortalModule<Empty> { }

    [ControlFolder(Folder = "Web/Core.Sites.Partner.Apps")]
    public class PartnerDashBoardByModule<TModel, TConfig> : DashBoardByModule<TModel, TConfig>
        where TModel : class, new()
        where TConfig : class, IDashBoardConfigByModule, new()
    {
        [ControlFolder(Folder = "Web/Core.Sites.Partner.Apps")]
        public class PartnerModule : Module
        {

        }
    }
}