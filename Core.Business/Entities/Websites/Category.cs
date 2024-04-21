using System.Linq;
using Core.Attributes;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility.Trees;
using Core.Web.WebBase.HtmlBuilders;
using System.Collections.Generic;
using Core.Attributes.Validators;
using Core.Utility;

namespace Core.Business.Entities.Websites
{
    public partial class Category : Category<Category>
    {
        public enum Type
        {
            Tag = 0,
            News = 2,
            Product = 1,
            Tremark = 3
        }
        public enum TypeView
        {
            [FieldInfo(Name = "Bình thường")] Normal = 0,
            [FieldInfo(Name = "Danh sách")] List = 1
        }
        [PropertyInfo(Name = "Stt")] public int Row { get; set; }
        public class DataSource : DataSource<Category>.Module, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public Type CatType { set; get; }
            public int LanguageId { set; get; }

            public override int GetTotal() => 0;
            public override List<Category> GetEntities()
            {
                var data = new Tree { CompanyId = CompanyId, CatType = CatType, IsActive = false, LanguageId = LanguageId }.GetInTreeView(0, false);
                int index = 0;
                foreach (var item in data)
                {
                    index++;
                    item.Row = index;
                }
                return data;
            }
        }


        public static List<Category> GetData(int companyId, int languageId, Type catType) => Inst.ExeStoreToList("sp_Categories_GetData", companyId, languageId, catType);
        public class Tree : Tree<Category>
        {
            public int CompanyId { get; set; }
            public Type CatType { set; get; }
            public bool IsActive { set; get; }
            public int LanguageId { set; get; }

            protected override List<Category> GetData()
            {
                var data = Category.GetData(CompanyId, LanguageId, CatType);
                return IsActive ? data.Where(c => c.IsActive).ToList() : data;
            }
        }        
        public class Fe : Category<Fe>, IAliasUrl, IPageMeta
        {
            public int LanguageId { set; get; }
            public string UrlFormat { set; get; }
            public int Total { set; get; }
            public string Title
            {
                get { return Name; }
            }
            public string Image
            {
                get { return Avatar; }
            }
            public string Class { get; set; } // dùng cho trường hợp có active class giữa các danh mục
            public string MetaKeywords { get; set; }

            public string MetaDescription { get; set; }

            public static Fe Empty = new Fe();
            public static List<Fe> Get(int companyId)
            {
                return Inst.ExeStoreToList<Fe>("fe_Categories_GetAll", companyId);
            }
        }
    }

    [TableInfo(TableName = "[Categories]")]
    public abstract partial class Category<TModel> : MainDb.Entity<TModel>, IModel<int>,ICompanyNeedValidate, ITreeItem where TModel : ModelBase, new()
    {
        #region properties
        [Field(IsKey = true, IsIdentity = true), DataValueField(Default = "0")] public int CatId { set; get; }
        [Field(Name = "Mục cha")] public int ParentId { set; get; }
        [Field(Name = "Công ty")] public int CompanyId { get; set; }
        [Field] public string Avatar { set; get; }
        [Field] public int Stt { set; get; }
        [Field] public Category.Type CatType { set; get; }
        [Field(Name = "Hiển thị")] public Category.TypeView CatTypeView { set; get; }
        [Field(Name = "Trạng thái")] public bool IsActive { set; get; }
        [Field] public string Banner { set; get; }
        [Field(Name = "Menu dọc")] public bool Vertical { set; get; }
        [Field(Name = "Menu ngang")] public bool Horizontal { set; get; }
        [Field(Name = "Hiển thị Website")] public bool IsShow { set; get; }
        [Field(Name = "Css ")] public string CssHomeFocus { set; get; }
        [Field] public string ExternalLink { set; get; }
        [Field] public string Icon { set; get; }
        #endregion

        public int Key
        {
            get { return CatId; }
            set { CatId = value; }
        }

        [DataTextField(Default = "-- Tên mục --"), PropertyInfo(Name = "Tên mục")] public string Name { set; get; }
        [PropertyInfo(Name = "Ghi chú")] public string Description { set; get; }
        [PropertyInfo(Name = "Từ khóa")] public string Keyword { set; get; }
        public string Alias { set; get; }

        #region ITreeItem
        public object TreeItemId { get { return CatId; } }
        public string TreeItemName
        {
            get { return Name; }
            set { Name = value; }
        }
        public object TreeItemParent { get { return ParentId; } }
        public int TreeLevel { set; get; }
        #endregion

        [TableInfo(TableName = "[Categories.Languages]")]
        public class Language : MainDb.Entity<Language>, IModel<int>, ILanguage<Language, int, int>, IAlias
        {
            #region properties
            [Field(IsKey = true, IsIdentity = true)] public int CatLanguageId { set; get; }
            [Field] public int CatId { set; get; }
            [Field] public int LanguageId { set; get; }
            [Field(Name = "Tên mục"), ValidatorRequire] public string Name { set; get; }
            [Field(Name = "Ghi chú")] public string Description { set; get; }
            [Field(Name = "Từ khóa")] public string Keyword { set; get; }
            [Field] public string Alias { set; get; }
            #endregion

            public int KeyLanguage
            {
                get { return CatLanguageId; }
                set { CatLanguageId = value; }
            }

            public List<Language> GetEntityLanguages(int key)
            {
                return SelectToList(cl => cl.CatId == key);
            }

            public int Key
            {
                get { return CatId; }
                set { CatId = value; }
            }

            public string NameForAlias
            {
                get { return Name; }
            }
        }
    }
}