using Core.Business.Entities.Websites;
using Core.FrontEnds.Libraries;
using Core.FrontEnds.Libraries.Portal;
using Core.FrontEnds.Libraries.Web;
using Core.FrontEnds.Libraries.Web.Caches;
using Core.FrontEnds.Libraries.Web.Caches.News;
using Core.Web.Extensions;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace Core.FE.Sites.Transports.Projects.Web.Pages
{
    [Module]
    public partial class NewDetails : Module
    {
        protected string Target { get; set; }
        protected Core.Business.Entities.Websites.News.Fe CurrentNew = new Core.Business.Entities.Websites.News.Fe();
        protected bool IsHaveRelate { get; set; }
        protected override void BeforeInitData()
        {
            var news = CacheNews.GetData().Where(c => c.LanguageId == FeContext.Url.LanguageId).ToList();
            Category.Fe Parent = new Category.Fe();
            CurrentNew = news.FirstOrDefault(c => c.NewsId == FeContext.Url.News.NewsId);

            var cates = CacheCategories.GetData();
            var currentCate = cates.FirstOrDefault(c => c.CatId == CurrentNew.CatId && c.LanguageId == FeContext.Url.LanguageId);
            Parent = cates.FirstOrDefault(c => c.CatId == currentCate.ParentId && c.LanguageId == FeContext.Url.LanguageId);

            if(Parent != null) 
            {
                var childs = cates.Where(c => c.ParentId == Parent.CatId && c.IsShow == true && c.Vertical == true && c.LanguageId == FeContext.Url.LanguageId).ToList();
                childs.ForEach(c => {
                    if (c.CatId == currentCate.CatId)
                        c.Class = "actived";
                    else
                        c.Class = "";
                });
                Target = Parent.Title;
                childs.BindTo(rpcate);
            }
            else
            {
                var childs = cates.Where(c => c.ParentId == currentCate.CatId && c.IsShow == true && c.Vertical == true && c.LanguageId == FeContext.Url.LanguageId).ToList();
                Target = currentCate.Title;
                childs.BindTo(rpcate);
            }
            
            IsHaveRelate = CurrentNew.Relates.Count > 0 ? true : false;
            if (IsHaveRelate)
            {
                CurrentNew.Relates.BindTo(rprelate);
            }
        }
    }
}