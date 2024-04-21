using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using Core.Web.WebBase.HtmlBuilders;
using System.Collections.Generic;

namespace Core.Business.Entities.Others.PriceConfigs
{
    [TableInfo(TableName = "[ProductTypes]", Name = "Loại mặt hàng")]
    public class ProductType : MainDb.EntityAuthor<ProductType>, IModel<int>
    {
        [Field(IsKey = true, IsIdentity = true), DataValueField(Default = "0")] public int TypeId { get; set; }
        public int Key { get => TypeId; set => TypeId = value; }
        [TableInfo(TableName = "[ProductTypes.Languages]")]
        public class Language : MainDb.Entity<Language>, IModel<int>, ILanguage<Language, int, int>, IAlias
        {
            [Field(IsIdentity = true, IsKey = true)] public int TypeLanguageId { get; set; }
            [Field] public int LanguageId { get; set; }
            [Field] public int TypeId { get; set; }
            [Field(Name = "Loại mặt hàng"), ValidatorRequire] public string Name { get; set; }
            [Field] public string Alias { get; set; }
            public int KeyLanguage
            {
                get { return TypeLanguageId; }
                set { TypeLanguageId = value; }
            }

            public string NameForAlias
            {
                get { return Name; }
            }
            public int Key { get => TypeId; set => TypeId = value; }
            public List<Language> GetEntityLanguages(int key) { return SelectToList(t => t.TypeId == key); }

        }
        [PropertyInfo(Name = "Loại sản phẩm")] public string ProductTypeName { set; get; }
        public class DataSource : DataSource<ProductType>.Module
        {
            public int LanguageId { get; set; }
            public string ProductTypeName { get; set; }
            public override List<ProductType> GetEntities() => Inst.ExeStoreToList("sp_ProductTypes_GetData", LanguageId, ProductTypeName, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>("sp_ProductTypes_GetData_Count", LanguageId, ProductTypeName);

        }
    }
}
