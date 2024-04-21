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
        [TableInfo(TableName = "[CRM.Transactions.Prioritizes]", Name = "Độ ưu tiên")]
        public class Prioritize : MainDb.EntityAuthor<Prioritize>, IModel<int>, ICompanyNeedValidate, IEntityForLogShowName
        {
            [Field(IsKey = true, IsIdentity = true), DataValueField(Default = "0")] public int PrioritizeId { get; set; }
            [Field(Name = "Công ty")] public int CompanyId { get; set; }
            [Field(Name = "Tên mức độ"), DataTextField(Default = "-- Độ ưu tiên --")] public string Name { get; set; }
            [Field(Name = "STT")] public int Stt { get; set; }
            [Field(Name = "Hệ thống")] public bool IsSystem { get; set; }
            [Field(Name = "Màu")] public string Color { get; set; }
            [Field(Name = "Màu chữ")] public string ColorText { get; set; }
            [PropertyInfo(Name = "Stt")] public int Row { get; set; }

            public int Key
            {
                get => PrioritizeId;
                set => PrioritizeId = value;
            }

            public class DataSource : DataSource<Prioritize>.Module, ICompanyNeedValidate
            {
                public int CompanyId { set; get; }
                public string Name { get; set; }
                public override List<Prioritize> GetEntities() => Inst.ExeStoreToList("sp_CRM_Transactions_Prioritizes_GetData", CompanyId, Name, Start, Length, FieldOrder, Dir);
                public override int GetTotal() => CurrentData.Count;

            }
        }
    }
}
