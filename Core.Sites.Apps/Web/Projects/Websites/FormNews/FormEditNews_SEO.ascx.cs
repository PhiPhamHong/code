
using Core.Business.Entities.Websites;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Web.WebBase;
using System.Configuration;

namespace Core.Sites.Apps.Web.Projects.Websites.FormNews
{
    [Module]
    [Script(Src = "/Web/Projects/Websites/FormNews/js/FormEditNews_SEO.js")]
    public partial class FormEditNews_SEO : PortalModule<News>, IAjax
    {
        public int NewsId { set; get; }
        public int TypeModule { set; get; }

        protected override void OnInitData()
        {
            if (NewsId != 0) this.SetData("News", News.Fe.GetByNewId(NewsId));
            this.SetData("Extension", ConfigurationManager.AppSettings["FeExtension"]);
            this.SetData("TypeModule", TypeModule);
        }
    }
}