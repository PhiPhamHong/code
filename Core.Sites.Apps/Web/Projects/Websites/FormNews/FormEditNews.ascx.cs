using Core.Business.Entities.Websites;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;

namespace Core.Sites.Apps.Web.Projects.Websites.FormNews
{
    public partial class FormEditNews : PortalModule<News, News.Language, int, int>
    {
        public Category.Type Type { get { return PortalContext.GetCurrentModuleSetting<Category.Type>("Type"); } }
    }
}