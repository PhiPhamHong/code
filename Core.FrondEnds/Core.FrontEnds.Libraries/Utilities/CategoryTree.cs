using Core.Business.Entities.Websites;
using Core.FrontEnds.Libraries.Web.Caches;
using Core.Utility.Trees;
using System.Collections.Generic;

namespace Core.FrontEnds.Libraries.Utilities
{
    public class CategoryTree : Tree<Category.Fe>
    {
        protected override List<Category.Fe> GetData()
        {
            return CacheCategories.GetData();
        }
    }
}
