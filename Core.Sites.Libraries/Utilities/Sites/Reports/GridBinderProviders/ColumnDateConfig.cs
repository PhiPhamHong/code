using Core.Extensions;

namespace Core.Sites.Libraries.Utilities.Sites.Reports.GridBinderProviders
{
    public class ColumnDateConfig : ColumnConfig
    {
        protected override object Format(object value)
        {
            return "{0:dd/MM/yyyy}".Frmat(value);
        }
    }

    public class ColumnDateTimeConfig : ColumnConfig
    {
        protected override object Format(object value)
        {
            return "{0:dd/MM/yyyy hh:mm:ss}".Frmat(value);
        }
    }
}
