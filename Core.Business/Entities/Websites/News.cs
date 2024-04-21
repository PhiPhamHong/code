using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using Core.Web.WebBase.HtmlBuilders;
using System;
using System.Collections.Generic;
namespace Core.Business.Entities.Websites
{
    [TableInfo(TableName = "[News]")]
    public partial class News : MainDb.EntityAuthor<News>, IModel<int>, ICompanyNeedValidate
    {
        #region properties
        [Field(IsIdentity = true, IsKey = true), DataValueField(Default = "0")] public int NewsId { set; get; }
        [Field(Name = "Công ty")] public int CompanyId { set; get; }
        [Field(Name = "Ngày đăng")] public DateTime? DatePublished { set; get; }
        [Field(Name = "Tin nóng")] public bool IsHot { set; get; }
        [Field(Name = "Tin nổi bật")] public bool IsFocus { set; get; }
        [Field(Name = "Chuyên mục"), ValidatorRequire] public int CatId { set; get; }
        [Field(Name = "Ảnh đại diện")] public string Avatar { set; get; }
        [Field(Name = "Hiển thị")] public bool IsActive { set; get; }
        [Field(Name = "Tags")] public string Tags { set; get; }
        [Field(Name = "Đường dẫn Youtube")] public string YoutubeId { set; get; }       
        [Field(Name = "Ảnh bài viết")] public string Avatars { set; get; }


        //Thêm mới cho bên KX: sau xong rồi thì bỏ đi
        [Field(Name = "Tệp đính kèm")] public string Attachment { get; set; }
        [Field(Name = "Load tài liệu trong chi tiết")] public bool AllowDetail { get; set; }


        //Type Product
        [Field(Name = "Type")] public Category.Type Type { set; get; }
        #endregion

        public int Key
        {
            get { return NewsId; }
            set { NewsId = value; }
        }

        [PropertyInfo(Name = "Tiêu đề"), DataTextField(Default = "-- Chọn tin --")] public string Title { set; get; }
        [PropertyInfo(Name = "Chuyên mục")] public string CategoryName { set; get; }
        [PropertyInfo(Name = "Người đăng")] public string FullNameByUser { set; get; }

        public string Sapo { set; get; }
        public string SapoShort { set; get; }
        public string NewsContent { set; get; }
        public string Keyword { set; get; }
        public string Alias { set; get; }
        public string Address { set; get; }

        public class DataSource : DataSource<News>.Module, ICompanyNeedValidate
        {
            public Category.Type Type { set; get; }
            public int CompanyId { get; set; }
            public string Title { set; get; }
            public int CatId { set; get; }
            public int LanguageId { set; get; }
            public override List<News> GetEntities() => Inst.ExeStoreToList("sp_News_GetData", CompanyId, Type, Title, CatId, LanguageId, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>("sp_News_GetData_Count", CompanyId, Type, Title, CatId, LanguageId);
        }
        #region Fe (Mục này, dành riêng cho Fontends)
        public class Fe : News, IAliasUrl, IPageMeta
        {
            public string UrlFormat { set; get; }
            public string DateString { get { return CreatedDate.ToString("dd/MM/yyyy"); } }
            public string Day { get { return Core.Extensions.DateTimeExtension.AddZero(DatePublished.Value.Day); } }
            public string Month { get { return Core.Extensions.DateTimeExtension.AddZero(DatePublished.Value.Month); } }
            public int Year { get { return DatePublished.Value.Year; } }
            public int LanguageId { set; get; }
            public List<File> Files { get; set; }
            public List<News.Relate> Relates { get; set; }
            public string Description => Sapo;

            public string ClassImg { get { if(string.IsNullOrEmpty(Image)) return "hidden"; return ""; } } //Dùng cho KX,
            public string ClassDate { get { if (!string.IsNullOrEmpty(Image)) return "hidden"; return ""; } } //Dùng cho KX,

            public string ClassBtn { get { if (!string.IsNullOrEmpty(Attachment) && AllowDetail == true) return "btn-detail2"; return "btn-detail"; } } //Dùng cho KX,
            public string BtnText { get { if (!string.IsNullOrEmpty(Attachment) && AllowDetail == true) return ""; return ">> Chi tiết "; } } //Dùng cho KX,

            public string Image => Avatar;
            public long ReadCount { set; get; }
            public string MetaKeywords { get; set; }
            public string MetaDescription { get; set; }
            public static Fe Empty = new Fe();
            public static List<Fe> GetFes(int companyId) => Inst.ExeStoreToList<Fe>("fe_News_GetData", companyId);
            public static Fe GetByNewId(int newId) => Inst.ExeStoreToFirst<Fe>("sp_News_GetByKey", newId);
        }
        #endregion
        public class NewsIdsItem
        {
            public int NewsId { set; get; }
            public string Title { set; get; }

            public static List<NewsIdsItem> GetData(int companyId, string newsIds, int languageId)
            {
                return Inst.ExeStoreToList<NewsIdsItem>("sp_News_GetByNewsIds", companyId, newsIds, languageId);
            }
            //dùng cho KXuan
            public static List<NewsIdsItem> GetNewSingleLanguage(int companyId, string newsIds, int languageId)
            {
                return Inst.ExeStoreToList<NewsIdsItem>("sp_NewsContents_GetByNewsIds", companyId, newsIds, languageId);
            }
        }

        [TableInfo(TableName = "[News.Languages]")]
        public class Language : MainDb.Entity<Language>, IModel<int>, ILanguage<Language, int, int>, IAlias
        {
            #region properties
            [Field(IsIdentity = true, IsKey = true)] public int NewsLanguageId { set; get; }
            [Field] public int NewsId { set; get; }
            [Field] public int LanguageId { set; get; }
            [Field(Name = "Tiêu đề"), ValidatorRequire] public string Title { set; get; }            
            [Field(Name = "Tóm lược"), ValidatorRequire] public string Sapo { set; get; }
            [Field(Name = "Sapo")] public string SapoShort { set; get; }
            [Field(Name = "Nội dung")] public string NewsContent { set; get; }
            [Field(Name = "Từ khóa")] public string Keyword { set; get; }
            [Field] public string Alias { set; get; }
            #endregion

            public int Key
            {
                get { return NewsId; }
                set { NewsId = value; }
            }

            public int KeyLanguage
            {
                get { return NewsLanguageId; }
                set { NewsLanguageId = value; }
            }

            public List<Language> GetEntityLanguages(int key) { return SelectToList(nl => nl.NewsId == key); }

            public string NameForAlias
            {
                get { return Title; }
            }
        }


        [TableInfo(TableName = "[News.Relates]")]
        public class Relate : MainDb.Entity<Relate>
        {
            #region properties
            [Field(IsIdentity = true, IsKey = true)] public int RelateId { set; get; }
            [Field] public int NewsId { set; get; }
            [Field] public int RelateNewsId { set; get; }
            #endregion
            [PropertyInfo(Name = "Tiêu đề")] public string Title { set; get; }
            [PropertyInfo(Name = "Url")] public string Alias { get; set; }
            [PropertyInfo(Name = "Ảnh")] public string Avatar { set; get; }
            [PropertyInfo(Name = "Mô tả ngắn")] public string Sapo { get; set; }
            [PropertyInfo(Name = "ngày tạo")] public DateTime CreatedDate { set; get; }
            
            public string Urlformat { get; set; }
            public int LanguageId { get; set; }
            public class DataSource : DataSource<Relate>.Module
            {
                public int NewsId { set; get; }
                public string Title { set; get; }
                public int LanguageId { set; get; }
                public override List<Relate> GetEntities() 
                {
                    return Inst.ExeStoreToList("sp_News_Relates_GetData", NewsId, Title, LanguageId, Start, Length, FieldOrder, Dir);
                }
                public override int GetTotal()
                {
                    return Inst.SelectFirstValue<int>("sp_News_Relates_GetData_Count", NewsId, Title, LanguageId);
                }

            }
            public static void AddNews(int newsId, string newsRelates)
            {
                Inst.ExeStoreNoneQuery("sp_News_Relates_AddNews", newsId, newsRelates);
            }
            public static void DeleteNews(int newsId, string newsRelates)
            {
                Inst.ExeStoreNoneQuery("sp_News_Relates_DeleteNews", newsId, newsRelates);
            }
        }

        [TableInfo(TableName = "[New.Files]")]
        public class File : MainDb.Entity<File>, ICompanyNeedValidate, IModel<int>
        {
            [Field(IsKey = true, IsIdentity = true)] public int FileId { get; set; }
            [Field(Name = "Tin cha"), ValidatorRequire] public int NewsId { get; set; }
            [Field(Name = "Tiêu đề"), ValidatorRequire] public string Title { get; set; }
            [Field(Name = "Đường dẫn"), ValidatorRequire] public string Path { get; set; }
            [Field(Name = "Ghi chú")] public string Note { get; set; }
            [Field(Name = "Công ty")] public int CompanyId { get; set; }
            [Field(Name = "Hiển thị")] public bool IsShow { get; set; }
            [Field(Name = "Cho phép tải xuống")] public bool DownloadAllowed { get; set; }
            public int Key
            {
                get { return FileId; }
                set { FileId = value; }
            }
            public class DataSource : DataSource<File>.Module, ICompanyNeedValidate
            {
                public int CompanyId { get; set; }
                public int NewsId { set; get; }
                public override List<File> GetEntities() => Inst.ExeStoreToList("sp_New_Files_GetData", CompanyId, NewsId);
                public override int GetTotal() => CurrentData.Count;

            }
        }

    }
}