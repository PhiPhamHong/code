using Core.Web.WebBase;

namespace Core.Sites.Libraries.Utilities.Sites.Reports.GridBinderProviders
{
    public class FindColumnTimeConfigChain : FindColumnConfigChain
    {
        protected override ColumnConfig DoFind(string field, string format)
        {
            if (format == "time") return new ColumnTimeConfig { };
            return null;
        }
    }
}
