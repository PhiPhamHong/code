using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using Core.Web.WebBase.HtmlBuilders;
using System.Collections.Generic;


namespace Core.Business.Entities.ERP
{
    [TableInfo(TableName = "[Currencies]", Name = "Loại tiền tệ")]
    public class Currency : MainDb.EntityAuthor<Currency>, IModel<int>, IEntityForLogShowName
    {
        [Field(IsIdentity = true, IsKey = true), DataValueField(Default = "0")] public int CurrencyId { get; set; }
        [Field(Name = "Tên loại"), ValidatorRequire] public string Name { get; set; }
        [Field(Name = "Mã tiền"), ValidatorRequire] public string Code { get; set; }
        [Field(Name = "Tỷ giá hiện hành(VNĐ)"), ValidatorRequire] public decimal? ExchangeRate { get; set; }
        [Field(Name = "Mô tả"), ValidatorRequire] public string Description { get; set; }
        [Field(Name = "Icon")] public string Icon { get; set; }
        [Field(Name = "Thay thế icon mặc định")] public bool IsDefault { get; set; }
        [Field(Name = "Áp dụng")] public bool IsActive { get; set; }

        [DataTextField(Default = "--Loại tiền--")]
        public string SelectKey
        {
            get { return Code + " - " + Name; }
        }
        public int Key
        {
            get { return CurrencyId; }
            set { CurrencyId = value; }
        }
        [PropertyInfo(Name = "Stt")] public int Row { get; set; }

        public class DataSource : DataSource<Currency>.Module
        {
            public string Name { get; set; }
            public override List<Currency> GetEntities() => Inst.ExeStoreToList("sp_Currencies_GetData", Name, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => CurrentData.Count;
        }
    }
}
