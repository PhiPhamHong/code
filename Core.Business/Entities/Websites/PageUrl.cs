using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace Core.Business.Entities.Websites
{
    [TableInfo(TableName = "[PageUrls]")]
    public partial class PageUrl : MainDb.Entity<PageUrl>, IModel<int>, ICompanyNeedValidate
    {
        #region properties
        [Field(IsKey = true, IsIdentity = true)] public int PageUrlId { set; get; }
        [Field(Name = "Công ty")] public int CompanyId { get; set; }
        [Field(Name = "Tiền tố")] public string Prefix { set; get; }
        [Field(Name = "Truy vấn")] public string PageQuery { set; get; }
        [Field(Name = "Biểu ngữ")] public bool Match { set; get; }
        [Field(Name = "Dùng gián tiếp")] public bool Indirect { set; get; }
        [Field(Name = "Đường dẫn thật")] public string RealUrl { set; get; }
        [Field(Name = "Ảnh đại diện")] public string Avatar { set; get; }
        [Field(Name = "Web(ID)")] public int WebsiteId { get; set; }
        #endregion

        [PropertyInfo(Name = "Đường dẫn ảo")] public string VirtualUrl { set; get; }
        [PropertyInfo(Name = "Mẫu đường dẫn")] public string TemplateUrl { set; get; }
        [PropertyInfo(Name = "Tiêu đề")] public string PageTitle { set; get; }
        [PropertyInfo(Name = "Từ khóa")] public string Keyword { set; get; }
        [PropertyInfo(Name = "Nội dung")] public string Description { set; get; }

        public int Key
        {
            get { return PageUrlId; }
            set { PageUrlId = value; }
        }

        public class Fe : PageUrl, IPageMeta
        {

            public int LanguageId { set; get; }
            public string Flag { set; get; }
            public Regex Rex { set; get; }
            public string[] TemplateUrls { set; get; }

            public static List<Fe> GetAllPages(int companyId)
            {
                return Inst.ExeStoreToList<Fe>("fe_PageUrls_GetAll", companyId);
            }

            public string Title
            {
                get { return PageTitle; }
            }

            public string Image
            {
                get { return Avatar; }
            }

            public string MetaKeywords { get; set; }

            public string MetaDescription { set; get; }
        }

        public class DataSource : DataSource<PageUrl>.Module, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public string Prefix { set; get; }
            public int LanguageId { set; get; }
            public override List<PageUrl> GetEntities() => Inst.ExeStoreToList("sp_PageUrls_GetData", CompanyId, Prefix, LanguageId, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>("sp_PageUrls_GetData_Count", CompanyId, Prefix, LanguageId);
        }
        [TableInfo(TableName = "[PageUrls.Languages]")]
        public class Language : MainDb.Entity<Language>, IModel<int>, ILanguage<Language, int, int>
        {
            #region properties
            [Field(IsIdentity = true, IsKey = true)] public int PageUrlLanguageId { set; get; }
            [Field] public int PageUrlId { set; get; }
            [Field] public int LanguageId { set; get; }
            [Field(Name = "Đường dẫn ảo"), ValidatorRequire] public string VirtualUrl { set; get; }
            [Field(Name = "Mẫu đường dẫn")] public string TemplateUrl { set; get; }
            [Field(Name = "Tiêu đề")] public string PageTitle { set; get; }
            [Field(Name = "Từ khóa")] public string Keyword { set; get; }
            [Field(Name = "Nội dung")] public string Description { set; get; }
            #endregion

            public int Key
            {
                get { return PageUrlId; }
                set { PageUrlId = value; }
            }
            public int KeyLanguage
            {
                get { return PageUrlLanguageId; }
                set { PageUrlLanguageId = value; }
            }
            public List<Language> GetEntityLanguages(int key)
            {
                return SelectToList(p => p.PageUrlId == key);
            }
        }
    }
}