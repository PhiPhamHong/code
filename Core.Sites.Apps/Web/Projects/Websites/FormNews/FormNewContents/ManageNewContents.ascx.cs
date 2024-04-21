using Core.Business.Entities;
using Core.Business.Entities.Websites;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Extensions;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using System.Collections.Generic;

namespace Core.Sites.Apps.Web.Projects.Websites.FormNews.FormNewContents
{
    [Module]
    [Script(Src = "/Web/Projects/Websites/FormNews/FormNewContents/js/ManageNewContents.js")]
    [ManageModulePermission(Add = Per.P_76001, Edit = Per.P_76002, Delete = Per.P_76003)]
    public partial class ManageNewContents : ManageModule<New.Content, ManageNewContents.ModuleProvider, EditNewContent>
    {
        public class ModuleProvider : ManageModuleProvider<New.Content, int>.Source<New.Content.DataSource> 
        {
            protected override void Save(New.Content t, List<LogEntity> logEntities, IDataBaseService service)
            {
                t.Alias = t.Title.UnicodeFormat();
                base.Save(t, logEntities, service);
            }
        }
    }
}