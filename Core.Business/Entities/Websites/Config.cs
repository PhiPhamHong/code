using Core.DataBase.ADOProvider.Attributes;
using System.Collections.Generic;
using System.Linq;
namespace Core.Business.Entities.Websites
{
    [TableInfo(TableName = "[Configs]", Name = "Cấu hình")]
    public class Config : MainDb.Entity<Config>
    {
        #region Properties
        [Field(IsKey = true, IsIdentity = true)] public int ConfigId { set; get; }
        [Field] public string KeyConfig { set; get; }
        [Field] public string Value { set; get; }
        #endregion

        public static Dictionary<string, object> GetConfigs()
        {
            return Inst.GetAllCastToList().ToDictionary(c => c.KeyConfig, c => (object)c.Value);
        }
    }
}
