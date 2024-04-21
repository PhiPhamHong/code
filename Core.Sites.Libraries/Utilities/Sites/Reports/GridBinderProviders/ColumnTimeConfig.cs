using System;
using Core.Extensions;

namespace Core.Sites.Libraries.Utilities.Sites.Reports.GridBinderProviders
{
    public class ColumnTimeConfig : ColumnDateConfig
    {
        protected override object Format(object value)
        {
            if (value == null) return null;
            if (value.Is<DateTime>()) return "{0:HH:mm}".Frmat(value);
            if (value.Is<TimeSpan>()) return value.As<TimeSpan>().ToString(@"hh\:mm");
            return value;
        }
    }
}
