namespace Core.Sites.Libraries.Utilities.Sites.Reports.GridBinderProviders
{
    public class FindColumnDateConfigChain : FindColumnConfigChain
    {
        protected override ColumnConfig DoFind(string field, string format)
        {
            if (format == "date") return new ColumnDateConfig { };
            return null;
        }
    }

    public class FindColumnDateTimeConfigChain : FindColumnConfigChain
    {
        protected override ColumnConfig DoFind(string field, string format)
        {
            if (format == "date-time") return new ColumnDateTimeConfig { };
            return null;
        }
    }
}
