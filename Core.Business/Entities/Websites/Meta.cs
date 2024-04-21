using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using Core.Web.WebBase.HtmlBuilders;
using System.Collections.Generic;

namespace Core.Business.Entities.Websites
{
    [TableInfo(TableName = "[Metas]")]
    public partial class Meta : MainDb.Entity<Meta>, IModel<int>, ICompanyNeedValidate
    {
        #region properties
        [Field(IsKey = true, IsIdentity = true), DataValueField(Default = "0")] public int MetaId { set; get; }
        [Field(Name = "Công ty")] public int CompanyId { set; get; }
        [FieldSearch(Name = "Tên thuộc tính"), ValidatorRequire] public string AttributeName { set; get; }
        [FieldSearch(Name = "Giá trị")] public string AttributeValue { set; get; }
        [FieldSearch(Name = "Phương thức")] public string AttributeMethodContent { set; get; }
        [Field] public int Stt { set; get; }
        #endregion

        [PropertyInfo(Name = "Nội dung")] public string AttributeContent { set; get; }
        [DataTextField(Default = "-- Thẻ meta --")] public string FindName { get { return AttributeName + " - " + AttributeValue; } }
        public int Key
        {
            get { return MetaId; }
            set { MetaId = value; }
        }

        public class DataSource : DataSource<Meta>.Module, ICompanyNeedValidate
        {
            public string AttributeContent { set; get; }
            public int LanguageId { set; get; }
            public int CompanyId { get; set; }
            public override List<Meta> GetEntities() => Inst.ExeStoreToList("sp_Metas_GetData", AttributeContent, CompanyId, LanguageId, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>("sp_Metas_GetData_Count", AttributeContent, CompanyId, LanguageId);
        }
        public static List<Meta> Get(int companyId ,int languageId)
        {
            return Inst.ExeStoreToList("fe_Metas_Get", companyId, languageId);
        }
        public bool HasExist(int CompanyId, string AttributeName, string attributeValue)
        {
            return Inst.SelectFirstValue<int>("sp_Metas_GetExist", CompanyId, AttributeName, attributeValue) == 0 ? false : true;
        }

        [TableInfo(TableName = "[Metas.Languages]")]
        public class Language : MainDb.Entity<Language>, IModel<int>, ILanguage<Language, int, int>
        {
            #region properties
            [Field(IsKey = true, IsIdentity = true)] public int MetaLanguageId { set; get; }
            [Field] public int MetaId { set; get; }
            [Field] public int LanguageId { set; get; }
            [Language(Name = "Nội dung")] public string AttributeContent { set; get; }
            #endregion

            public int Key
            {
                get { return MetaId; }
                set { MetaId = value; }
            }

            public int KeyLanguage
            {
                get { return MetaLanguageId; }
                set { MetaLanguageId = value; }
            }

            public List<Language> GetEntityLanguages(int key)
            {
                return SelectToList(ml => ml.MetaId == key);
            }
        }
    }
}