using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using Core.Extensions;
using System.Collections.Generic;
using System.IO;

namespace Core.Business.Entities.CRM
{
    public partial class Transaction
    {
        [TableInfo(TableName = "[CRM.Transactions.Files]", Name = "Tài liệu khách hàng")]
        public class File : MainDb.EntityAuthor<File>, IModel<int>, ICompanyNeedValidate, IEntityForLogShowName
        {
            [Field(IsKey = true, IsIdentity = true)] public int TransactionFileId { get; set; }
            [Field] public int TransactionId { get; set; }
            [Field(Name = "Công ty")] public int CompanyId { get; set; }
            [Field(Name = "Tên tệp"), ValidatorRequire] public string FileName { set; get; }
            [Field(Name = "Đường dẫn"), ValidatorRequire] public string FilePath { set; get; }
            [Field(Name = "Áp dụng")] public bool IsUse { get; set; }
            [Field(Name = " Đối tác")] public int PartnerId { get; set; }

            public class DataSource : DataSource<File>.Module, ICompanyNeedValidate
            {
                public int PartnerId { get; set; }
                public int CompanyId { set; get; }
                public string FileName { get; set; }
                public int TransactionId { get; set; }
                public override List<File> GetEntities() => Inst.ExeStoreToList("sp_CRM_Transactions_Files_GetData", CompanyId, TransactionId, PartnerId, FileName, Start, Length, FieldOrder, Dir);
                public override int GetTotal() => CurrentData.Count;

            }
            [PropertyInfo(Name = "Stt")] public int Row { get; set; }
            [PropertyInfo] public string FileExtension => FilePath.IsNull() ? string.Empty : Path.GetExtension(FilePath).TrimStart('.');

            public string Name { get; set; }

            public int Key { get { return TransactionFileId; } set { TransactionFileId = value; } }

            public static int GetCountByTransaction(int transactionid) => Inst.SelectFirstValue<int>("sp_CRM_Transaction_Files_GetByTransactionId_Count", transactionid);
        }
    }
}