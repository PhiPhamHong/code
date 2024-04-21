using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using System.Collections.Generic;

namespace Core.Business.Entities.Websites
{
    [TableInfo(TableName = "[Seo]")]
    public partial class Seo : MainDb.Entity<Seo>, IModel<int>, ICompanyNeedValidate
    {
        #region properties
        [Field(IsKey = true, IsIdentity = true)] public int SeoId { set; get; }
        [Field(Name = "Công ty")] public int CompanyId { set; get; }
        [Field] public string GoogleAnalytics { set; get; }
        [Field(Name = "Logo")] public string SiteImage { set; get; }
        [Field] public string Favicon { set; get; }
        [Field] public string Fanpage { set; get; }
        [Field] public string Twitter { set; get; }
        [Field] public string GooglePlus { set; get; }
        [Field] public string Email { set; get; }
        [Field] public string Password { set; get; }
        [Field] public string Phone { set; get; }
        #endregion

        public int Key
        {
            get { return SeoId; }
            set { SeoId = value; }
        }

        public string PageTitle { set; get; }
        public string Keyword { set; get; }
        public string Description { set; get; }
        public string Introduction { set; get; }
        public string Copyright { set; get; }
        public string Slogan { set; get; }
        public int LanguageId { set; get; }

        [TableInfo(TableName = "[Seo.Languages]")]
        public class Language : MainDb.Entity<Language>, IModel<int>, ILanguage<Language, int, int>
        {
            #region properties
            [Field(IsKey = true, IsIdentity = true)] public int SeoLanguageId { set; get; }
            [Field] public int SeoId { set; get; }
            [Field] public int LanguageId { set; get; }
            [Field(Name = "Tiêu đề trang")] public string PageTitle { set; get; }
            [Field(Name = "Từ khóa")] public string Keyword { set; get; }
            [Field(Name = "Ghi chú")] public string Description { set; get; }
            [Field(Name = "Giới thiệu")] public string Introduction { set; get; }
            [Field(Name = "Bản quyền")] public string Copyright { set; get; }
            [Field] public string Slogan { set; get; }
            #endregion

            public int KeyLanguage
            {
                get { return SeoLanguageId; }
                set { SeoLanguageId = value; }
            }

            public List<Language> GetEntityLanguages(int key)
            {
                return SelectToList(sl => sl.SeoId == key);
            }

            public int Key
            {
                get { return SeoId; }
                set { SeoId = value; }
            }
        }

        public static List<Seo> GetAllSeo(int companyId)
        {
            return Inst.ExeStoreToList("fe_Seo_GetAll", companyId);
        }

        public static Seo Empty = new Seo();
    }
}