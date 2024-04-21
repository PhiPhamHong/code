using Core.Attributes.Validators;
using Core.Attributes;
using Core.DataBase.ADOProvider.Attributes;
using Core.DataBase.ADOProvider;
using Core.Utility;
using System.Collections.Generic;
using Core.Business.Entities.Others.PriceConfigs;


namespace Core.Business.Entities.Others.Documents
{
    [TableInfo(TableName = "[Documents]", Name = "Tài liệu")]
    public class Document : MainDb.EntityAuthor<Document>, IModel<int>
    {
        [Field(IsKey = true, IsIdentity = true)] public int DocumentId { get; set; }
        public int Key { get => DocumentId; set => DocumentId = value; }
        [Field(Name = "Attachment"), ValidatorRequire] public string Attachment { get; set; }
        [Field(Name = "Hiển thị")] public bool IsActive { set; get; }

        [TableInfo(TableName = "[Documents.Languages]")]
        public class Language : MainDb.Entity<Language>, IModel<int>, ILanguage<Language, int, int>, IAlias
        {
            [Field(IsIdentity = true, IsKey = true)] public int DocumentLanguageId { get; set; }
            [Field] public int LanguageId { get; set; }
            [Field] public int DocumentId { get; set; }
            [Field(Name = "Tiêu đề"), ValidatorRequire] public string Title { get; set; }
            [Field] public string Alias { get; set; }
            public int KeyLanguage
            {
                get { return DocumentLanguageId; }
                set { DocumentLanguageId = value; }
            }

            public string NameForAlias
            {
                get { return Title; }
            }
            public int Key { get => DocumentId; set => DocumentId = value; }
            public List<Language> GetEntityLanguages(int key) { return SelectToList(t => t.DocumentId == key); }

        }
        [PropertyInfo(Name = "Tiêu đề")] public string DocumentTitle { set; get; }
        [PropertyInfo(Name = "Lang")] public int LanguageId { set; get; }

        public class DataSource : DataSource<Document>.Module
        {
            public int LanguageId { get; set; }
            public string DocumentTitle { get; set; }
            public override List<Document> GetEntities() => Inst.ExeStoreToList("sp_Documents_GetData", LanguageId, DocumentTitle, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>("sp_Documents_GetData_Count", LanguageId, DocumentTitle);
            public List<Document> GetAllforFe() => Inst.ExeStoreToList("sp_Documents_GetData_Fe");
        }
    }
}
