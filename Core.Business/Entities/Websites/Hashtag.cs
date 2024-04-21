using Core.Attributes;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using Core.Web.WebBase.HtmlBuilders;
using System.Collections.Generic;

namespace Core.Business.Entities.Websites
{
    [TableInfo(TableName = "[Hashtags]")]
    public class Hashtag : MainDb.EntityAuthor<Hashtag>, IModel<int>, ICompanyNeedValidate
    {
        [Field(IsKey = true, IsIdentity = true), DataValueField(Default = "0")] public int HashtagId { set; get; }
        [Field(Name = "Công ty")] public int CompanyId { set; get; }
        [Field(Name = "Trạng thái")] public bool IsActive { get; set; }
        [Field(Name = "Thứ tự")] public int DisplayOrder { get; set; }
        [FieldSearch(Name = "Màu")] public string Color { set; get; }
        [FieldSearch(Name = "Màu chữ")] public string TextColor { set; get; }
        [PropertyInfo(Name = "Stt")] public int Row { get; set; }

        [PropertyInfo(Name = "Tên hashtag"), DataTextField(Default = "-- Chọn hashtags --")] public string Name { set; get; }
        [PropertyInfo(Name = "Mô tả")] public string Description { set; get; }
        public int Key
        {
            get { return HashtagId; }
            set { HashtagId = value; }
        }

        public class DataSource : DataSource<Hashtag>.Module, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public int LanguageId { get; set; }
            public string Name { get; set; }
            public override List<Hashtag> GetEntities() => Inst.ExeStoreToList("sp_Hashtags_GetData", CompanyId, LanguageId, Name, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>("sp_Hashtags_GetData_Count", CompanyId, LanguageId, Name);

        }

        [TableInfo(TableName = "[Hashtags.Languages]")]
        public class Language : MainDb.Entity<Language>, IModel<int>, ILanguage<Language, int, int>, IAlias
        {
            [Field(IsKey = true, IsIdentity = true)] public int HashtagLanguageId { set; get; }
            [Field] public int HashtagId { set; get; }
            [Field] public int LanguageId { set; get; }
            [Field(Name = "Tiêu đề")] public string Name { get; set; }
            [Field(Name = "Mô tả")] public string Description { get; set; }
            [Field] public string Alias { get; set; }
            public string NameForAlias => Name;

            public int Key
            {
                get { return HashtagId; }
                set { HashtagId = value; }
            }
            public int KeyLanguage
            {
                get { return HashtagLanguageId; }
                set { HashtagLanguageId = value; }
            }
            public List<Language> GetEntityLanguages(int key) => SelectToList(cl => cl.HashtagId == key);
        }

    }
}
