using Core.Web.WebBase;
namespace Core.Sites.Libraries.Utilities.Sites.Reports.GridBinderProviders
{
    public class FindColumnMoneyConfigChain : FindColumnConfigChain
    {
        protected override ColumnConfig DoFind(string field, string format)
        {
            if (format == "money") return new ColumnMoneyConfig { };
            return null;
        }
    }
}