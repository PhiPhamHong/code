using Core.Business.Entities.CRM;
using Core.Business.Entities.ERP;
using Core.Business.Entities.Websites;
using Core.FrontEnds.Libraries.UrlEngines.Previews;
using Core.FrontEnds.Libraries.Web.Caches;
using Core.Utility.Trees;
using System.Collections.Generic;
using System.Linq;
namespace Core.FrontEnds.Libraries.Web
{
    public partial class FeContext
    {
        public partial class UrlContext
        {
            private CategoryContext category = null;
            public CategoryContext Category
            {
                get
                {
                    if (category == null) category = new CategoryContext();
                    return category;
                }
            }

            public class CategoryContext
            {
                public Category.Type CatType { set; get; }
                public int CatId { set; get; }
                public Category.Fe Entity { set; get; }

               

                private List<Category.Fe> breadcrumbs = null;
                public List<Category.Fe> Breadcrumbs
                {
                    get
                    {
                        if (breadcrumbs == null)
                        {
                            var c = Entity;
                            if (c == null) return new List<Category.Fe>();
                            var categories = CacheCategories.GetData().Where(cc => cc.LanguageId == Url.LanguageId).ToList();
                            breadcrumbs = Tree<Category.Fe>.DoFindParent(c, categories).Reverse().ToList();
                            breadcrumbs.Add(Entity);
                        }
                        return breadcrumbs;
                    }
                }
            }


            private PreviewContext pre = null;
            public PreviewContext Preview
            {
                get
                {
                    if (pre == null) pre = new PreviewContext();
                    return pre;
                }
            }

            private PreviewContext land = null;
            public PreviewContext Landing
            {
                get
                {
                    if (land == null) land = new PreviewContext();
                    return land;
                }
            }

            public class PreviewContext
            {
                public LinkType Type { get; set; }
                public LandingPage Landing { get; set; }
                public Template Template { get; set; }
            }



            //Sản phẩm
            public class ProductContext
            {
                public int LanguageId { get; set; }
                public Product Entity { get; set; }
            }
            private ProductContext product = null;
            public ProductContext Product
            {
                get
                {
                    if (product == null) product = new ProductContext();
                    return product;
                }
            }

            //SearchType
            public class SearchType
            {
                public int Type { get; set; }
                public string Content { get; set; }
                public List<Product.ManuFacturer> Facturers { get; set; }
            }
            private SearchType searchType = null;
            public SearchType Search
            {
                get
                {
                    if (searchType == null) searchType = new SearchType();
                    return searchType;
                          
                }
            }
        }
    }
}