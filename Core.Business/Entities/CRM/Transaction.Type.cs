using Core.Attributes;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using Core.Web.WebBase.HtmlBuilders;
using System.Collections.Generic;

namespace Core.Business.Entities.CRM
{
    public partial class Transaction
    {
        [TableInfo(TableName = "[CRM.Transactions.Types]", Name = "Loại chăm sóc")]
        public class Type : MainDb.EntityAuthor<Type>, IModel<int>, ICompanyNeedValidate, IEntityForLogShowName
        {
            [Field(IsKey = true, IsIdentity = true), DataValueField(Default = "0")] public int TransactionTypeId { get; set; }
            [Field(Name = "Công ty")] public int CompanyId { get; set; }
            [Field(Name = "Tên loại"), DataTextField(Default = "--Loại công việc--")] public string Name { get; set; }
            [Field(Name = "Nhóm việc")] public Kind Kind { get; set; }
            [Field(Name = "Hệ thống")] public bool IsSystem { get; set; }
            [Field(Name = "Màu")] public string Color { get; set; }
            [Field(Name = "Màu chữ")] public string ColorText { get; set; }

            [PropertyInfo(Name = "Stt")] public int Row { get; set; }
            [PropertyInfo(Name = "Nhóm việc")] public string TypeString => Kind != Kind.Unknown ? EnumHelper<Kind, FieldInfoAttribute>.Inst.GetAttribute(Kind).Name : "";

            public int Key
            {
                get => TransactionTypeId;
                set => TransactionTypeId = value;
            }

            public class DataSource : DataSource<Type>.Module, ICompanyNeedValidate
            {
                public int CompanyId { get; set; }
                public string Name { get; set; }
                public Kind Kind { get; set; }

                public override List<Type> GetEntities() => Inst.ExeStoreToList("sp_CRM_Transactions_Types_GetData", CompanyId, Kind, Name, Start, Length, FieldOrder, Dir);
                public override int GetTotal() => CurrentData.Count;
            }
        }

        public enum Kind : byte
        {
            [FieldInfo(Name = "-- Chọn nhóm việc --")] Unknown = 0,
            [FieldInfo(Name = "Chăm sóc")] Care = 1,
            [FieldInfo(Name = "Công việc")] Job = 2
        }
    }
}