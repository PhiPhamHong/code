using Core.Attributes;
using Core.DataBase.ADOProvider.Attributes;
using Core.Web.WebBase.HtmlBuilders;
using System.Collections.Generic;

namespace Core.Business.Entities
{
    [TableInfo(TableName = MainDbTable.Languages, Name="Ngôn ngữ")]
    public partial class Language : MainDb.Entity<Language>
    {
        #region properties
        [Field(IsKey = true, IsIdentity = true)]
        [DataValueField(Default = "0")]
        [PropertyIndex(Index = 0)]
        public int LanguageId { set; get; }

        [Field]
        [PropertyIndex(Index = 1)]
        public string Flag { set; get; }

        [Field]
        [DataTextField]
        [PropertyIndex(Index = 2)]
        public string Name { set; get; }

        [Field]
        [PropertyIndex(Index = 3)]
        public int Stt { set; get; }

        [Field]
        [PropertyIndex(Index = 4)]
        public string Icon { set; get; }
        #endregion

        public static List<Language> GetLanguages()
        {
            return Inst.ExeStoreToList("sp_Languages_GetData");
        }
    }
}