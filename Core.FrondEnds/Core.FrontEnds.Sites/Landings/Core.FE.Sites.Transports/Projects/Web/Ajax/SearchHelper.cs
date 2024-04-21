using Core.Business.Entities.Websites;
using Core.Extensions;
using Core.FE.Sites.Transports.Projects.Web.Pages;
using Core.FrontEnds.Libraries.Web;
using Core.FrontEnds.Libraries.Web.Caches;
using Core.FrontEnds.Libraries.Web.Caches.News;
using Core.FrontEnds.Libraries.Web.Caches.Orthers;
using Core.Web.WebBase;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;


namespace Core.FE.Sites.Transports.Projects.Web.Ajax
{
    public class SearchHelper : IAjax
    {
        public void Search(string keyword, int searchType, int languageId, int catId)
        {
            switch (searchType)
            {
                case 1:
                    {
                        var documents = CacheDocuments.GetData();
                        documents = documents.Where(c => c.DocumentTitle.ToLower().Contains(keyword.ToLower()) && c.LanguageId == languageId).ToList();
                        List<int> result = new List<int>();
                        documents.ForEach(c => result.Add(c.DocumentId));
                        this.SetData("ShowIds", result);
                        break;
                    }
                case 2:
                    {
                        var news = new List<Core.Business.Entities.Websites.News.Fe>();
                        var cates = CacheCategories.GetData();
                        var current = cates.FirstOrDefault(c => c.CatId == catId);
                        if (current != null)
                        {
                            if (current.ParentId != 0) //nó có cha không? nếu có cha
                            {
                                news = CacheNews.GetData().Where(c => c.CatId == current.CatId && c.LanguageId == languageId).ToList(); // lấy tin tức của nó
                            }

                            else
                            {
                                var childs = cates.Where(c => c.ParentId == current.CatId && c.IsShow == true && c.Vertical == true).ToList(); // tìm hết con của nó
                                var listIds = new List<int>();
                                listIds.Add(current.CatId);
                                childs.ForEach(c =>
                                {
                                    listIds.Add(c.CatId);
                                });
                                news = CacheNews.GetData().Where(c => listIds.Contains(c.CatId) && c.LanguageId == languageId).ToList(); // lấy tin tức của nó và tất cả con của nó.
                            }
                        }
                        news = news.Where(c => c.Title.ToLower().Contains(keyword.ToLower())).ToList() ;
                        List<int> result = new List<int>();
                        news.ForEach(c => result.Add(c.NewsId));
                        this.SetData("ShowIds", result);
                        break;
                    }
            }
        }
    }
}