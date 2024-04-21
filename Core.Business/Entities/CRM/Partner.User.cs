using Core.Attributes;
using Core.DataBase.ADOProvider.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Entities.CRM
{
    public partial class Partner
    {
        [TableInfo(TableName = "[Partners.Users]")]
        public class User : MainDb.Entity<User>
        {
            #region Properties
            [Field(IsIdentity = true, IsKey = true)] public int PartnerUserId { set; get; }
            [Field] public int PartnerId { set; get; }
            [Field] public int UserId { set; get; }
            [Field] public Type PartnerUserType { set; get; }
            #endregion

            public static List<User> GetByPartnerId(int partnerId) => Inst.SelectToList(pu => pu.PartnerId == partnerId);

            public enum Type : int
            {
                [FieldInfo(Name = "-- Phụ trách --")] All = 0,
                [FieldInfo(Name = "Phụ trách quản lý")] Manage = 1,
                [FieldInfo(Name = "Phụ trách công nợ")] Debt = 2,
                [FieldInfo(Name = "Marketing")] Found = 3
            }
        }
    }
}
