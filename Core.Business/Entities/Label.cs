using System.Collections.Generic;
using Core.DataBase.ADOProvider.Attributes;
using Core.Attributes;
using Core.Attributes.Validators;
using Newtonsoft.Json;
using Core.DataBase.ADOProvider;
using Core.Utility;

namespace Core.Business.Entities
{
    [TableInfo(TableName = MainDbTable.Languages_Labels)]
    public partial class Label : MainDb.Entity<Label>, IModel<int>, ICompanyNeedValidate, ICommonSystem, IEntityForLogShowName
    {
        #region properties
        [Field(IsKey = true, IsIdentity = true)] public int LabelId { set; get; }
        [Field(Name = "Từ vựng"), ValidatorRequire] public string Lexicon { set; get; }
        [Field(Name = "Mô tả")] public string Description { set; get; }
        [Field] public bool ForAdmin { set; get; }
        [Field(Name = "Công ty")] public int CompanyId { set; get; }
        [Field(Name = "Hệ thống")] public bool IsSystem { set; get; }
        #endregion

        public int Key 
        { 
            get { return LabelId; }
            set { LabelId = value; }
        }
        
        [PropertyInfo(Name = "Dịch")] public string Value { set; get; }
        [PropertyInfo(Name = "Stt")] public int Row { get; set; }
        public class DataSource : DataSource<Label>.Module, ICompanyNeedValidate
        {
            public string Lexicon { set; get; }
            public int LanguageId { set; get; }
            public int CompanyId { set; get; }

            public override List<Label> GetEntities() => Inst.ExeStoreToList<Label>(MainDbStore.sp_Languages_Labels_GetData, CompanyId, Lexicon, LanguageId, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>(MainDbStore.sp_Languages_Labels_GetData_Count, CompanyId, Lexicon, LanguageId);
        }

        public bool CheckExistsLexicon(int labelId, int companyId, string lexicon)
        {
            return SelectFirstValue<int>("sp_Languages_Labels_CheckExistsLexicon", labelId, companyId, lexicon) != 0;
        }

        [JsonIgnore]
        public string Name
        {
            get { return Lexicon; }
        }
    }

    [TableInfo(TableName = MainDbTable.Languages_LabelLanguages)]
    public class LabelLanguage : MainDb.Entity<LabelLanguage>, IModel<int>, ILanguage<LabelLanguage, int, int>
    {
        #region properties
        [Field(IsKey = true, IsIdentity = true)] public int LabelLanguageId { set; get; }
        [Field] public int LabelId { set; get; }
        [Field(Name = "Giá trị")] [ValidatorRequire] public string Value { set; get; }
        [Field] public int LanguageId { set; get; }
        #endregion
        public int Key
        {
            get { return LabelId; }
            set { LabelId = value; }
        }
        public List<LabelLanguage> GetEntityLanguages(int key) => SelectToList(ll => ll.LabelId == key);

        public int KeyLanguage
        {
            set { LabelLanguageId = value; }
            get { return LabelLanguageId; }
        }
    }
}
