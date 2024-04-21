
using System.Linq;
using Core.Web.WebBase;
using System.Collections.Generic;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Business.Entities.Websites;

namespace Core.Sites.Apps.Web.Projects.Websites.FormNewsRelates
{

    [Script(Src = "/Web/Resources/Modules/AllPopup.js")]
    [Script(Src = "/Web/Projects/Websites/FormNewsRelates/js/ManageNewsRelates.js", Index = 2)]
    [Module]
    public partial class ManageNewsRelates : ManageModule<News.Relate, ManageNewsRelates.ModuleProvider>, IAjax
    {
        public void LoadNewsIds()
        {
            this.SetData("NewsIds", new News.Relate.DataSource { NewsId = this.Query<int>("NewsId"), LanguageId = PortalContext.DefaultLanguage }.GetEntities().Select(c => c.RelateNewsId).ToList());
        }
        public void SaveNewsRelate()
        {
            var newsId = this.Query<int>("NewsId");
            News.Relate.AddNews(newsId, this.Query<string>("added"));
            News.Relate.DeleteNews(newsId, this.Query<string>("deleted"));
        }
        
        public class ModuleProvider : ManageModuleProvider<News.Relate>.Source<News.Relate.DataSource> { }
    }
}