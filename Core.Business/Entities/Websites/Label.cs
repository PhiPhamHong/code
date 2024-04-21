using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using System.Collections.Generic;
using Core.Extensions;
using Core.Utility;

namespace Core.Business.Entities.Websites
{
    [TableInfo(TableName = "[Labels]")]
    public partial class Label : MainDb.Entity<Label>, IModel<int> , ICompanyNeedValidate
    {
        #region properties
        [Field(IsKey = true, IsIdentity = true)] public int LabelId { set; get; }
        [Field(Name = "Công ty")] public int CompanyId { get; set; }
        [Field, ValidatorRequire] public string Lexicon { set; get; }
        [Field] public string Description { set; get; }
        [Field] public bool ForAdmin { set; get; }
        public int LanguageId { get; set; }
        #endregion

        public int Key
        {
            get { return LabelId; }
            set { LabelId = value; }
        }

        [PropertyInfo] public string Value { set; get; }


        public class DataSource : DataSource<Label>.Module, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public string Lexicon { set; get; }
            public int LanguageId { set; get; }
            public override List<Label> GetEntities() => Inst.ExeStoreToList("sp_Labels_GetData", CompanyId, Lexicon, LanguageId, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>("sp_Labels_GetData_Count", CompanyId, Lexicon, LanguageId);
        }

        public bool HasExist(int companyId, string lexicon)
        {
            return Inst.SelectFirstValue<int>("sp_Labels_GetExist", companyId, lexicon) == 0 ? false : true;
        }

        [TableInfo(TableName = "[Labels.Languages]")]
        public class Language : MainDb.Entity<Language>, IModel<int>, ILanguage<Language, int, int>
        {
            #region properties
            [Field(IsKey = true, IsIdentity = true)] public int LabelLanguageId { set; get; }
            [Field] public int LabelId { set; get; }
            [Field(Name = "Giá trị"), ValidatorRequire] public string Value { set; get; }
            [Field] public int LanguageId { set; get; }
            #endregion

            public int Key
            {
                get { return LabelId; }
                set { LabelId = value; }
            }

            public List<Language> GetEntityLanguages(int key)
            {
                return SelectToList(ll => ll.LabelId == key);
            }

            public int KeyLanguage
            {
                set { LabelLanguageId = value; }
                get { return LabelLanguageId; }
            }
        }

        public class Item
        {
            public int LanguageId { set; get; }
            public string Lexicon { set; get; }
            public string Value { set; get; }
            public static List<Item> Get(int companyId)
            {
                return Inst.ExeStoreToList<Item>("fe_Labels_GetAll", companyId);
            }
        }
    }
}