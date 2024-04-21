using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using System;
using System.Collections.Generic;
using Core.Extensions;
using System.Linq;
namespace Core.Business.Entities.Websites
{
    
    [TableInfo(TableName = "[Banners]", Name = "Banner quảng cáo")]
    public partial class Banner : MainDb.EntityAuthor<Banner>, IModel<int>, ICompanyNeedValidate
    {
        [Field(IsIdentity = true, IsKey = true)] public int BannerId { get; set; }
        [Field(Name = "Vị trí"), ValidatorRequire(), ValidatorLength(Min = 1, Max = 1000, Stt = 1)] public string Address { get; set; }
        [Field(Name = "Ảnh")] public string Picture { get; set; }
        [Field(Name = "Mã nhúng")] public string RelativeCode { get; set; }
        [Field(Name = "Màn hình"), ValidatorRequire()] public string Screen { get; set; }
        [PropertyInfo(Name = "Stt")] public int Row { get; set; }
        [Field(Name = "Công ty")] public int CompanyId { get; set; }

        [PropertyInfo(Name = "Màn hình")]
        public string ScreenString
        {
            get
            {
                if(Screen != null)
                return Screen.SplitTo<int>().Select(t => EnumHelper<ScreenEnum, FieldInfoAttribute>.Inst.GetAttribute((ScreenEnum)t).Name).JoinString(t => t);
                return "";
            }
        }       
        public int Key
        {
            get { return BannerId; }
            set { BannerId = value; }
        }
        [PropertyInfo(Name = "Tiêu đề")] public string Title { get; set; }
        [PropertyInfo(Name = "Đường dẫn")] public string URL { get; set; }
        [PropertyInfo(Name = "Mô tả")] public string Description { get; set; }

        [TableInfo(TableName = "[Banners.Languages]")]
        public class Language : MainDb.Entity<Language>, IModel<int>, ILanguage<Language, int, int>
        {
            [Field(IsIdentity = true,IsKey = true)] public int BannerLanguageId { get; set; }
            [Field(Name = "")] public int BannerId { get; set; }
            [Field(Name = "")] public int LanguageId { get; set; }
            [Field(Name = "Tiêu đề"), ValidatorRequire(), ValidatorLength(Min = 5, Max = 1000, Stt = 1)] public string Title { get; set; }
            [Field(Name = "Đường dẫn"), ValidatorRequire(), ValidatorLength(Min = 1, Max = 1000, Stt = 1)] public string URL { get; set; }
            [Field(Name = "Mô tả")] public string Description { get; set; }
            public int Key
            {
                get { return BannerId; }
                set { BannerId = value; }
            }

            public int KeyLanguage
            {
                get { return BannerLanguageId; }
                set { BannerLanguageId = value; }
            }
            public List<Language> GetEntityLanguages(int key) { return SelectToList(t => t.BannerId == key); }
        }

        public class DataSource : DataSource<Banner>.Module, ICompanyNeedValidate
        {
            public string Keyword { get; set; }
            public int LanguageId { get; set; }
            public int CompanyId { get; set; }
            public override List<Banner> GetEntities() => Inst.ExeStoreToList("sp_Banners_GetData", Keyword, LanguageId, CompanyId, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>("sp_Banners_GetCount", Keyword, LanguageId, CompanyId);

        }
        public enum ScreenEnum : byte
        {
            [FieldInfo(Name = "Màn hình siêu nhỏ ")] xsm = 1,
            [FieldInfo(Name = "Màn hình nhỏ")] sm = 2,
            [FieldInfo(Name = "Màn hình vừa")] md = 3,
            [FieldInfo(Name = "Màn hình lớn")] lg = 4,
            [FieldInfo(Name = "Màn hình rất lớn")] xl = 5
        }

        public class Fe
        {
            public string Address { set; get; }
            public string Picture { set; get; }
            public string Screen { set; get; }
            public string RelativeCode { set; get; }
            public string Title { set; get; }
            public string URL { set; get; }
            public string Description { set; get; }

            public static List<Fe> Get(int companyId ,int languageId)
            {
                return Inst.ExeStoreToList<Fe>("fe_Banners_GetData", companyId, languageId);
            }
        }
    }
}
