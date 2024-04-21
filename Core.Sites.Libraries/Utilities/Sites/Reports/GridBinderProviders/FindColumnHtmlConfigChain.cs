namespace Core.Sites.Libraries.Utilities.Sites.Reports.GridBinderProviders
{
    public class FindColumnHtmlConfigChain : FindColumnConfigChain
    {
        protected override ColumnConfig DoFind(string field, string format)
        {
            return format == "html" ? new ColumnHtmlConfig { } : null;
        }
    }
}