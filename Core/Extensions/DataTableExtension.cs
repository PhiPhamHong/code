using Core.Utility;
using System.Collections.Generic;
using System.Data;
using System;
using System.Linq;
namespace Core.Extensions
{
    public static class DataTableExtension
    {
        public static List<T> ToList<T>(this DataTable table, bool ignoreCase = false, Action<T> action = null) where T : new()
        {
            return Model<T>.ParseToList(table, ignoreCase, action);
        }

        public static IEnumerable<T> Cast<T>(this DataTable table, bool ignoreCase, Action<T> action = null) where T : new()
        {
            return Model<T>.Cast(table, ignoreCase, action);
        }

        public static T GetFirstItem<T>(this DataTable table, bool ignoreCase) where T : class,new()
        {
            return table.Rows.Count == 0 ? null : Model<T>.Parse(table.Rows[0], ignoreCase);
        }
    }
}