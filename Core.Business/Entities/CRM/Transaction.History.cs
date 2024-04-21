using Core.Attributes;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Extensions;
using Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Entities.CRM
{
    public partial class Transaction
    {
        [TableInfo(TableName = "[CRM.Transactions.Histories]", Name = "Lịch sử chăm sóc khách hàng")]
        public class History : Transaction<History>, IModel<int>
        {
            [Field(IsKey = true, IsIdentity = true)] public int TransactionHistoryId { set; get; }
            [Field] public bool AddNew { set; get; }

            public class DataSource : DataSource<History>.Module
            {
                public int TransactionId { set; get; }
                public int PartnerId { set; get; }
                public int TransactionTypeId { set; get; }
                public int TransactionStatusId { set; get; }
                public int PrioritizeId { set; get; }
                public string Name { set; get; }
                public Transaction.DateFieldSearch DateFieldSearch { set; get; }
                public DateTime? StartTime { set; get; }
                public DateTime? EndTime { set; get; }
                public int UserManageId { get; set; }
                public int UserId { get; set; }
                public int UserFind { get; set; }
                public Transaction.UserTypeEnum UserTypeEnum { set; get; }
                public string DateFieldSearchName { get; set; }
                public override List<History> GetEntities() => Inst.ExeStoreToList("sp_CRM_Transactions_Histories_GetData", TransactionId, PartnerId, TransactionTypeId, TransactionStatusId, PrioritizeId, Name, StartTime, EndTime, DateFieldSearchName, true, UserTypeEnum, UserManageId, UserFind, Start, Length, FieldOrder, Dir);
                public override int GetTotal() => Inst.SelectFirstValue<int>("sp_CRM_Transactions_Histories_GetData_Count", TransactionId, PartnerId, TransactionTypeId, TransactionStatusId, PrioritizeId, Name, StartTime, EndTime, DateFieldSearchName, true, UserTypeEnum, UserManageId, UserFind);
            }
            public static int GetCountByTransactionId(int transactionId)
            {
                return Inst.SelectFirstValue<int>("sp_CRM_Transactions_Histories_GetCountByTransactionId", transactionId);
            }


            public int Key
            {
                get { return TransactionHistoryId; }
                set { TransactionHistoryId = value; }
            }
        }
    }
}
