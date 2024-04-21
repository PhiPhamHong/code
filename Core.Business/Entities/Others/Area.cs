using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using Core.Utility.Trees;
using Core.Web.WebBase.HtmlBuilders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Core.Business.Entities.Others
{
    [TableInfo(TableName = "[Areas]", Name = "Khu vực")]
    public class Area : MainDb.EntityAuthor<Area>, IModel<int>, ITreeItem
    {
        [Field(IsKey = true, IsIdentity = true), DataValueField(Default = "0")] public int AreaId { get; set; }
        [Field(Name = "Quốc gia"), ValidatorRequire] public int NationId { get; set; }
        [Field(Name = "Hiển thị")] public bool IsShow { get; set; }
        [Field(Name = "Thuộc khu vực")] public int ParentId { get; set; }
        public int Key { get => AreaId; set => AreaId = value; }
        [PropertyInfo(Name = "Stt")] public int Row { get; set; }
        [PropertyInfo(Name = "Khu vực"), DataTextField(Default = "-- Khu vực --")] public string Name { set; get; }
        [PropertyInfo(Name = "Quốc gia")] public string NationName { set; get; }
        [PropertyInfo(Name = "Mô tả")] public string Note { set; get; }

        [JsonIgnore]
        public int NameKey
        {
            get { return ParentId; }
        }

        [JsonIgnore]
        public Type TypeNameKey
        {
            get { return typeof(Area); }
        }
        #region ITreeItem
        public object TreeItemId
        {
            get { return AreaId; }
        }
        public string TreeItemName
        {
            get { return Name; }
            set { Name = value; }
        }
        public object TreeItemParent
        {
            get { return ParentId; }
        }
        public int TreeLevel { set; get; }
        #endregion

        public class Tree : Tree<Area>
        {
            public int LanguageId { set; get; }
            public int NationId { get; set; }
            protected override List<Area> GetData()
            {
                return Area.GetData(LanguageId, NationId);
            }
        }
        public static List<Area> GetData(int languageId, int nationId) => Inst.ExeStoreToList("sp_Areas_GetData", nationId, languageId);
        [TableInfo(TableName = "[Areas.Languages]")]
        public class Language : MainDb.Entity<Language>, IModel<int>, ILanguage<Language, int, int>, IAlias
        {
            [Field(IsIdentity = true, IsKey = true)] public int AreaLanguageId { get; set; }
            [Field] public int LanguageId { get; set; }
            [Field] public int AreaId { get; set; }
            [Field(Name = "Tên"), ValidatorRequire] public string Name { get; set; }
            [Field(Name = "Mô tả")] public string Note { get; set; }
            [Field] public string Alias { get; set; }
            public int KeyLanguage
            {
                get { return AreaLanguageId; }
                set { AreaLanguageId = value; }
            }

            public string NameForAlias
            {
                get { return Name; }
            }
            public int Key { get => AreaId; set => AreaId = value; }
            public List<Language> GetEntityLanguages(int key) { return SelectToList(t => t.AreaId == key); }

        }


        public class DataSource : DataSource<Area>.Module
        {
            public int LanguageId { get; set; }
            public int NationId { get; set; }
            public override List<Area> GetEntities() => new Tree { LanguageId = LanguageId, NationId = NationId }.GetInTreeView(0, false);
            public override int GetTotal() => 0;

        }

    }
}
