using Core.Business.Entities.Websites;
using Core.FE.Sites.Transports.Projects.Web.Utilities;
using Core.FrontEnds.Libraries.Portal;
using Core.FrontEnds.Libraries.Web;
using Core.FrontEnds.Libraries.Web.Caches;
using Core.FrontEnds.Libraries.Web.Caches.News;
using Core.Web.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core.FE.Sites.Transports.Projects.Web.Pages
{
    [Module]
    public partial class News : Module
    {
        protected string Target { get; set; }
        protected int CurrentCatId { get; set; }
        protected bool IsNot { get; set; }
        protected string ActiveCateName { get; set; }
        protected bool Show { get; set; }
        protected override void BeforeInitData()
        {
            var cates = CacheCategories.GetData().Where(c => c.LanguageId == FeContext.Url.LanguageId).ToList();
            Category.Fe Parent = new Category.Fe();
            //Kiểm tra xem link này trỏ tới cate Parent hay cate Child

            var currentCate = cates.FirstOrDefault(c => c.CatId == FeContext.Url.Category.CatId); //trỏ tới cái cate hiện tại
            if (currentCate.ParentId != 0) //nó có cha không? nếu có cha
            {
                Parent = cates.FirstOrDefault(c => c.CatId == currentCate.ParentId); // thì lấy cha của nó đặt lên top
                var childs = cates.Where(c => c.ParentId == Parent.CatId && c.IsShow == true && c.Vertical == true).ToList(); // tìm hết con của thằng top
                childs.ForEach(c => {
                    if (c.CatId == currentCate.CatId)
                        c.Class = "actived"; // sau đó active thằng có catId = currentCate
                    else
                        c.Class = "";
                });
                childs.BindTo(rpcate);
                ActiveCateName = currentCate.Title;
                CurrentCatId = currentCate.CatId;
                var news = CacheNews.GetData().Where(c => c.CatId == currentCate.CatId && c.LanguageId == FeContext.Url.LanguageId).ToList(); // lấy tin tức của nó
                if (news.Count != 0)
                    IsNot = false;
                else
                    IsNot = true;
                pager.TotalRow = news.Count;
                news = news.Skip((pager.PageIndex - 1) * pager.PageSize).Take(pager.PageSize).ToList();
                news.BindTo(rpnews);
            }
                
            else
            {
                Parent = currentCate; // nếu không thì nó chính là mục cao nhất. => đưa lên top
                var childs = cates.Where(c => c.ParentId == currentCate.CatId && c.IsShow == true && c.Vertical == true).ToList(); // tìm hết con của nó
                childs.BindTo(rpcate);
                var listIds = new List<int>();
                listIds.Add(currentCate.CatId);
                childs.ForEach(c =>
                {
                    listIds.Add(c.CatId);
                });
                var news = CacheNews.GetData().Where(c => listIds.Contains(c.CatId) && c.LanguageId == FeContext.Url.LanguageId).ToList(); // lấy tin tức của nó và tất cả con của nó.
                if (news.Count != 0)
                    IsNot = false;
                else
                    IsNot = true;
                pager.TotalRow = news.Count;
                news = news.Skip((pager.PageIndex - 1) * pager.PageSize).Take(pager.PageSize).ToList();
                news.BindTo(rpnews);
            }

            Target = Parent.Title;
            CurrentCatId = Parent.CatId;
            Show = (Parent == cates.FirstOrDefault(c => c.Horizontal == true && c.ParentId == 0 && c.LanguageId == FeContext.Url.LanguageId && c.Stt == 0));
        }

        protected ShPager pager = new ShPager { PageSize = 4000 };
    }
}