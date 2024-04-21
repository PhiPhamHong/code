using System.Linq;
using Core.DataBase.ADOProvider.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;
using Core.Extensions;
using Core.Business.Enums;

namespace Core.Business.Entities
{
    public partial class User
    {
        [TableInfo(TableName = "[Users.Columns]")]
        public class Column : MainDb.Entity<Column>
        {
            #region Properties
            [Field(IsKey = true, IsIdentity = true)] public int UserColumnId { set; get; }
            [Field] public int UserId { set; get; }
            [Field] public string Module { set; get; }
            [Field, JsonIgnore] public string Columns { set; get; }
            [Field] public int? FixedLeft { set; get; }
            [Field] public int? FixedRight { set; get; }
            [Field] public string SortColumn { set; get; }
            [Field] public string SortDir { set; get; }
            [Field, JsonIgnore] public string ColumnStt { set; get; }
            [Field] public SessionType SessionType { set; get; }
            #endregion

            public List<string> ViewColumns
            {
                get
                {
                    if (Columns.IsNull()) return new List<string> { };
                    return Columns.Split(',').Distinct().ToList();
                }
            }

            public List<string> RootSttColumns
            {
                get
                {
                    if (ColumnStt.IsNull()) return new List<string> { };
                    return ColumnStt.Split(',').Distinct().ToList();
                }
            }

            public static Column GetByModule(int userId, string module, SessionType sessionType)
            {
                return Inst.ExeStoreToFirst("sp_Users_Columns_GetByModule", userId, module, sessionType);
            }
        }
    }
}