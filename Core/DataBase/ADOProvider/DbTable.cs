using System.Data;
using Core.Utility;
using System.Collections.Generic;
using System;
using Core.Extensions;
namespace Core.DataBase.ADOProvider
{
    public class DbTable<T> where T : ModelBase, new()
    {
        public static List<T> GetAllToList(Action<T> afterParse = null)
        {
            // Select All
            var table = GetAll();

            // Trả ra dữ liệu
            return table.IsNull() ? new List<T>() : Model<T>.ParseToList(table, false, afterParse);

        }

        public static DataTable GetAll()
        {
            return Singleton<T>.Inst.GetAll();
        }
    }
}
