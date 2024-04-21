
using Core.Business.Entities.Websites;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Web.WebBase;

namespace Core.Sites.Apps.Web.Projects.Websites.FormNews
{
    [Module]
    [Script(Src = "/Web/Projects/Websites/FormNews/js/PopupNews.js")]
    public partial class PopupNews : ManageModule<News, ManageNews.ModuleProvider>, IAjax
    {
        public void GetNewsByIds()
        {
            if (PortalContext.Config.UseNewSingleLanguage)
                this.SetData("News", News.NewsIdsItem.GetNewSingleLanguage(PortalContext.CurrentUser.CurrentCompanyId, this.Query("Ids"), PortalContext.DefaultLanguage));
            else 
                this.SetData("News", News.NewsIdsItem.GetData(PortalContext.CurrentUser.CurrentCompanyId, this.Query("Ids"), PortalContext.DefaultLanguage));
        }
    }
}