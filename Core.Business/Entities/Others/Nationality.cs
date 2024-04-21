

using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using Core.Web.WebBase.HtmlBuilders;
using System.Collections.Generic;

namespace Core.Business.Entities.Others
{
    [TableInfo(TableName = "[Nationalities]", Name = "Quốc gia")]
    public class Nationality : MainDb.EntityAuthor<Nationality>, IModel<int>
    {
        [Field(IsKey = true, IsIdentity = true), DataValueField(Default = "0")] public int NationId { get; set; }
        [Field(Name = "Hiển thị")] public bool IsShow { get; set; }
        [PropertyInfo(Name = "Stt")] public int Row { get; set; }
        [PropertyInfo(Name = "Tên"), DataTextField(Default = "-- Quốc gia --")] public string Name { set; get; }
        [PropertyInfo(Name = "Mô tả")] public string Note { set; get; }
        public int Key { get => NationId; set => NationId = value; }

        [TableInfo(TableName = "[Nationalities.Languages]")]
        public class Language : MainDb.Entity<Language>, IModel<int>, ILanguage<Language, int, int>, IAlias
        {
            [Field(IsIdentity = true, IsKey = true)] public int NationLanguageId { get; set; }
            [Field] public int LanguageId { get; set; }
            [Field] public int NationId { get; set; }
            [Field(Name = "Tên"), ValidatorRequire] public string Name { get; set; }
            [Field(Name = "Mô tả")] public string Note { get; set; }
            [Field] public string Alias { get; set; }
            public int KeyLanguage
            {
                get { return NationLanguageId; }
                set { NationLanguageId = value; }
            }

            public string NameForAlias
            {
                get { return Name; }
            }
            public int Key { get => NationId; set => NationId = value; }
            public List<Language> GetEntityLanguages(int key) { return SelectToList(t => t.NationId == key); }
            
        }

        public class DataSource : DataSource<Nationality>.Module
        {
            public int LanguageId { get; set; }
            public string Name { get; set; }
            public override List<Nationality> GetEntities() => Inst.ExeStoreToList("sp_Nationalities_GetData", LanguageId, Name, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>("sp_Nationalities_GetData_Count", LanguageId, Name);

        }
    }
}
