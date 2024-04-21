using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using Core.Web.WebBase.HtmlBuilders;
using System.Collections.Generic;


namespace Core.Business.Entities.Others.PriceConfigs
{
    [TableInfo(TableName = "[Directions]", Name = "Điểm đến")]
    public class Direction: MainDb.EntityAuthor<Direction>, IModel<int>
    {
        [Field(IsKey = true, IsIdentity = true), DataValueField(Default = "0")] public int DirectionId { get; set; }
        public int Key { get => DirectionId; set => DirectionId = value; }
        [Field(Name = "Điểm bốc")] public bool IsStart { get; set; }
        [Field(Name = "Điểm dỡ")] public bool IsEnd { get; set; }

        [TableInfo(TableName = "[Directions.Languages]")]
        public class Language : MainDb.Entity<Language>, IModel<int>, ILanguage<Language, int, int>, IAlias
        {
            [Field(IsIdentity = true, IsKey = true)] public int DirectionLanguageId { get; set; }
            [Field] public int LanguageId { get; set; }
            [Field] public int DirectionId { get; set; }
            [Field(Name = "Điểm bốc/dỡ"), ValidatorRequire] public string Name { get; set; }
            [Field] public string Alias { get; set; }
            public int KeyLanguage
            {
                get { return DirectionLanguageId; }
                set { DirectionLanguageId = value; }
            }

            public string NameForAlias
            {
                get { return Name; }
            }
            public int Key { get => DirectionId; set => DirectionId = value; }
            public List<Language> GetEntityLanguages(int key) { return SelectToList(t => t.DirectionId == key); }

        }
        [PropertyInfo(Name = "Tên")] public string DirectionName { set; get; }

        public class DataSource : DataSource<Direction>.Module
        {
            public int LanguageId { get; set; }
            public string DirectionName { get; set; }
            public override List<Direction> GetEntities() => Inst.ExeStoreToList("sp_Directions_GetData", LanguageId, DirectionName, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>("sp_Directions_GetData_Count", LanguageId, DirectionName);

        }
    }
}
