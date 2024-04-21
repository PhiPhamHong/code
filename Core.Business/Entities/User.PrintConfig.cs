using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataBase.ADOProvider.Attributes;
namespace Core.Business.Entities
{
    public partial class User
    {
        [TableInfo(TableName = "[Users.PrintConfigs]")]
        public class ModuleConfig : MainDb.Entity<ModuleConfig>
        {
            #region Properties
            [Field(IsIdentity = true, IsKey = true)] public int PrintConfigId { set; get; }
            [Field] public int CompanyId { set; get; }
            [Field] public int UserId { set; get; }
            [Field] public string Module { set; get; }
            [Field] public string Config { set; get; }
            #endregion

            public static ModuleConfig Get(int companyId, int userId, string module)
            {
                return Inst.SelectFirst(pc => pc.CompanyId == companyId && pc.UserId == userId && pc.Module == module);
            }
        }
    }
}
