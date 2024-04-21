using Core.FE.Sites.Transports.Projects.Web.Utilities;
using Core.FrontEnds.Libraries.Portal;
using Core.FrontEnds.Libraries.Web;
using Core.FrontEnds.Libraries.Web.Caches;
using Core.FrontEnds.Libraries.Web.Caches.Orthers;
using Core.Web.Extensions;
using System.Linq;

namespace Core.FE.Sites.Transports.Projects.Web.Pages
{
    [Module]
    public partial class Documents : Module
    {
        protected string Target { get; set; }
        protected bool IsNot { get; set; }
        protected override void BeforeInitData()
        {
            var page = CachePageUrls.GetData().FirstOrDefault(c => "/" + c.VirtualUrl == FeContext.Url.Current);
            Target = page != null ? page.Title : FeContext.Url.PageTitle;
            var documents = CacheDocuments.GetData().Where(c => c.IsActive && c.LanguageId == FeContext.Url.LanguageId).ToList();
            if (documents.Count != 0)
                IsNot = false;
            else
                IsNot = true;
            documents = documents.Skip((pager.PageIndex - 1) * pager.PageSize).Take(pager.PageSize).ToList();
            documents.BindTo(rpdocs);
        }

        protected ShPager pager = new ShPager { PageSize = 4000 };
    }
}