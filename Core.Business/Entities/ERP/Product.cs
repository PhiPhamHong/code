using Core.Attributes;
using Core.Attributes.Validators;
using Core.Business.Entities.Websites;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using Core.Web.WebBase.HtmlBuilders;
using System;
using System.Collections.Generic;

namespace Core.Business.Entities.ERP
{
    [TableInfo(TableName = "[Products]")]
    public class Product : MainDb.EntityAuthor<Product>, IModel<int>, ICompanyNeedValidate, IPageMeta
    {
        #region properties
        [Field(IsIdentity = true, IsKey = true), DataValueField(Default = "0")] public int ProductId { set; get; }
        [Field(Name = "Công ty")] public int CompanyId { get; set; }
        [Field(Name = "Nhà cung cấp"), ValidatorRequire] public int PartnerId { get; set; }
        [Field(Name = "Danh mục"), ValidatorRequire] public int CatId { set; get; }
        [Field(Name = "Hãng")] public int FacturerId { set; get; }
        [Field(Name = "Mã"), ValidatorRequire, ValidatorLength(Max = 100), DataTextField(Default = "-- Chọn sản phẩm --")] public string Code { set; get; }
        [Field(Name = "Phiên bản"), ValidatorLength(Max = 50)] public string ProductVersion { set; get; } = "4.0";
        [Field(Name = "Youtube"), ValidatorLength(Max = 100)] public string YoutubeCode { set; get; }
        [Field(Name = "Ảnh"), ValidatorLength(Max = 300)] public string Avatar { set; get; }
        [Field(Name = "Bộ sưu tập")] public string Images { get; set; }
        [Field(Name = "Từ khóa(Hashtag)")] public string HashtagIds { set; get; }
        [Field(Name = "Sản phẩm liên quan", Description = "Gợi ý sản phẩm có liên quan đến")] public string ProductIds { set; get; }
        [Field(Name = "Lượt xem")] public int TotalView { set; get; }
        [Field(Name = "SKU", Description = "SKU là từ viết tắt của Stock Keeping Unit(Đơn vị phân loại hàng hóa)"), ValidatorLength(Max = 100)] public string Sku { set; get; }
        [Field(Name = "GTIN", Description = "Số thương phẩm toàn cầu (GTIN). Các số nhận dạng này bao gồm UPC (ở Bắc Mỹ), EAN (ở Châu Âu), JAN (ở Nhật Bản) và ISBN (cho sách)."), ValidatorLength(Max = 100)] public string Gtin { set; get; }
        [Field(Name = "Giá bán"), ValidatorRequire] public decimal? PriceSale { set; get; }
        [Field(Name = "Giá cũ hiển thị website")] public decimal? PriceOld { set; get; }
        [Field(Name = "Giá nhập"), ValidatorRequire] public decimal? Cost { set; get; }
        [Field(Name = "Hiển thị trang chủ", Description = "Hiển thị sản phẩm này ra ngoài trang chủ website")] public bool IsHomePage { set; get; }
        [Field(Name = "Miễn thuế", Description = "Sản phẩm được xét vào diện miễn thuế")] public bool IsTaxExempt { set; get; }
        [Field(Name = "Mua tối thiểu", Description = "Số lượng đặt hàng tối thiểu")] public int MinOrder { set; get; } = 1;
        [Field(Name = "Tối đa", Description = "Số lượng đặt hàng tối đa")] public int MaxOrder { set; get; }
        [Field(Name = "Hàng mới", Description = "Đánh dấu là hàng mới")] public bool MarkAsNew { set; get; } = true;
        [Field(Name = "Từ ngày", Description = "Được cho là hàng mới từ ngày")] public DateTime? MarkAsNewFromUtc { set; get; }
        [Field(Name = "Đến ngày", Description = "Được cho là hàng mới tới ngày")] public DateTime? MarkAsNewToUtc { set; get; }
        [Field(Name = "Hiển thị số lượng trong kho", Description = "Cho phép hiển thị số lượng trong kho ra website")] public bool DisplayStockQuantity { set; get; }
        [Field(Name = "Là quà tặng")] public bool IsGift { set; get; }
        [Field(Name = "Ẩn nút mua")] public bool DisableBuyButton { set; get; }
        [Field(Name = "Hàng không trả lại")] public bool NotReturnable { set; get; }
        [Field(Name = "Liên hệ để biết giá", Description = "Ẩn giá của sản phẩm ngoài website")] public bool CallForPrice { set; get; }
        [Field(Name = "Đặt hàng trước")] public bool AvailableForPreOrder { set; get; }
        [Field(Name = "Số ngày đặt trước")] public int PreOrderAvailabilityStartDateTimeUtc { set; get; }
        [Field(Name = "Thứ tự hiển thị", Description = "Thứ tự hiển thị ngoài website")] public int DisplayOrder { set; get; } = 0;
        [Field(Name = "Ngày đăng")] public DateTime? PublishedDate { set; get; } = DateTime.Now;
        [Field(Name = "Trạng thái", Description = "Đưa sản phẩm này lên website")] public bool IsActive { set; get; } = true;
        [Field(Name = "Sản phẩm Hot")] public bool IsHot { get; set; }
        [Field(Name = "Best Seller")] public bool IsBestSeller { get; set; }
        [Field(Name = "Đang Sale")] public bool IsOnSale { get; set; }
        [Field(Name = "Được đề xuất")] public bool IsSuggest { get; set; }

        #endregion
        public int Key
        {
            get { return ProductId; }
            set { ProductId = value; }
        }
        [PropertyInfo(Name = "Nhà cung cấp")] public string PartnerName { set; get; }
        [PropertyInfo(Name = "Tên sản phẩm")] public string Name { set; get; }
        [PropertyInfo(Name = "Danh mục")] public string CategoryName { set; get; }
        [PropertyInfo(Name = "Stt")] public int Row { get; set; }
        [PropertyInfo] public string MetaKeywords { set; get; }
        [PropertyInfo] public string MetaDescription { set; get; }
        public string Sapo { set; get; }
        public string Description { get; set; }
        public string Alias { set; get; }
        public string UrlFormat { get; set; }
        public int LanguageId { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public class DataSource : DataSource<Product>.Module, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public string Name { set; get; }
            public int CatId { set; get; }
            public int LanguageId { set; get; }
            public int PartnerId { set; get; }
            public DateTime? StartTime { set; get; }
            public DateTime? EndTime { set; get; }

            public override List<Product> GetEntities() => Inst.ExeStoreToList("sp_Product_GetData", CompanyId, PartnerId, CatId, LanguageId, Name, StartTime, EndTime, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>("sp_Product_GetData_Count", CompanyId, PartnerId, CatId, LanguageId, Name, StartTime, EndTime);
        }

        #region Dành cho fontends(Nhưng chưa build xong)

        public class PopupModel : Product, IAliasUrl, IPageMeta
        {
            public int LanguageId { get; set; }
            public string UrlFormat { set; get; }
            public string Title => Name;
            public string Image => Avatar;
            public Category Category { get; set; }
            public static List<PopupModel> GetByProductId(int productId)
            {
                return Inst.ExeStoreToList<PopupModel>("sp_Products_GetPopupModelById", productId);
            }
        }
        #endregion

        [TableInfo(TableName = "[Product.ExtendProperties]")]
        public class Extend : MainDb.EntityAuthor<Extend>, IModel<int>, ICompanyNeedValidate
        {
            #region Properties
            [Field(IsIdentity = true, IsKey = true), DataValueField(Default = "0")] public int PropertyId { set; get; }
            [Field(Name = "Công ty")] public int CompanyId { get; set; }
            [Field(Name = "Sản phẩm"), ValidatorRequire] public int ProductId { get; set; }
            [Field(Name = "Chiều rộng(cm)")] public decimal Width { get; set; }
            [Field(Name = "Chiều cao(cm)")] public decimal Height { get; set; }
            [Field(Name = "Cân nặng(kg)")] public decimal Weight { get; set; }
            [Field(Name = "Trạng thái")] public bool IsActive { get; set; }
            [Field(Name = "Thứ tự")] public int DisplayOrder { get; set; }
            [Field(Name = "Nhóm"), ValidatorRequire] public ExtendType Type { get; set; }
            [Field(Name = "Hình ảnh")] public string PathImage { get; set; }
            [Field(Name = "Màu nền")] public string Color { get; set; }
            [Field(Name = "Màu content")] public string TextColor { get; set; }
            [Field(Name = "Giá cộng thêm")] public decimal? SubPrice { get; set; }
            [Field(Name = "Giá nhập")] public decimal? SubCost { get; set; }
            #endregion

            [PropertyInfo(Name = "Stt")] public int Row { get; set; }
            [PropertyInfo(Name = "Tên"), DataTextField(Default = "-- Chọn thuộc tính --")] public string Name { set; get; }
            [PropertyInfo(Name = "Mô tả")] public string Description { get; set; }
            [PropertyInfo(Name = "Nhóm")] public string TypeString
            {
                get
                {
                    return EnumHelper<ExtendType, FieldInfoAttribute>.Inst.GetAttribute(Type).Name;
                }
            }
            public int Key
            {
                get { return PropertyId; }
                set { PropertyId = value; }
            }

            public class DataSource : DataSource<Extend>.Module, ICompanyNeedValidate
            {
                public int CompanyId { get; set; }
                public int ProductId { get; set; }
                public int LanguageId { get; set; }
                public ExtendType Type { get; set; }
                public override List<Extend> GetEntities() => Inst.ExeStoreToList("sp_Product_ExtendProperties_GetData", CompanyId, ProductId, LanguageId, Type, Start, Length, FieldOrder, Dir);
                public override int GetTotal() => Inst.SelectFirstValue<int>("sp_Product_ExtendProperties_GetData_Count", CompanyId, ProductId, LanguageId, Type);

            }

            [TableInfo(TableName = "[Product.ExtendProperties.Languages]")]
            public class Language : MainDb.Entity<Language>, IModel<int>, ILanguage<Language, int, int>, IAlias
            {
                #region properties
                [Field(IsIdentity = true, IsKey = true)] public int PropertyLanguageId { set; get; }
                [Field] public int PropertyId { set; get; }
                [Field] public int LanguageId { set; get; }
                [Field(Name = "Tên"), ValidatorRequire, ValidatorLength(Max = 300)] public string Name { set; get; }
                [Field(Name = "Mô tả ngắn"), ValidatorLength(Max = 500)] public string Description { set; get; }
                [Field] public string Alias { set; get; }
                #endregion
                public int Key
                {
                    get { return PropertyId; }
                    set { PropertyId = value; }
                }

                public int KeyLanguage
                {
                    get { return PropertyLanguageId; }
                    set { PropertyLanguageId = value; }
                }

                public List<Language> GetEntityLanguages(int key) => SelectToList(nl => nl.PropertyId == key);

                public string NameForAlias => Name;
            }
        }

        [TableInfo(TableName = "[Product.ManuFacturers]")]
        public class ManuFacturer : MainDb.EntityAuthor<ManuFacturer>, IModel<int>, ICompanyNeedValidate
        {
            [Field(IsIdentity = true, IsKey = true), DataValueField(Default = "0")] public int FacturerId { get; set; }
            [Field(Name = "Công ty")] public int CompanyId { get; set; }
            [Field(Name = "Tên hãng")] public string Name { get; set; }
            [Field(Name = "Mã") , DataTextField(Default = "-- Chọn hãng --")] public string Code { get; set; }
            [Field(Name = "Trụ sở")] public string Address { get; set; }
            [Field(Name = "Logo")] public string Logo { get; set; }
            [Field(Name = "Trạng thái")] public bool IsActive { get; set; }
            [Field(Name = "Thứ tự")] public int DisplayOrder { get; set; }

            public int Key
            {
                get { return FacturerId; }
                set { FacturerId = value; }
            }

            [PropertyInfo(Name = "Stt")] public int Row { get; set; }
            public class DataSource : DataSource<ManuFacturer>.Module, ICompanyNeedValidate
            {
                public int CompanyId { get; set; }
                public string Name { get; set; }
                public override List<ManuFacturer> GetEntities() => Inst.ExeStoreToList("sp_Product_ManuFacturers_GetData", CompanyId, Name, Start, Length, FieldOrder, Dir);
                public override int GetTotal() => CurrentData.Count;

            }
        }
        public enum ExtendType : int
        {
            [FieldInfo(Name = "-- Chọn loại --")] Unknown = 0,
            [FieldInfo(Name = "Màu sắc")] Color = 1,
            [FieldInfo(Name = "Kích cỡ")] Size = 2
        }

        [TableInfo(TableName = "[Products.Languages]")]
        public class Language : MainDb.Entity<Language>, IModel<int>, ILanguage<Language, int, int>, IAlias
        {
            #region properties
            [Field(IsIdentity = true, IsKey = true)] public int ProductLanguageId { set; get; }
            [Field] public int ProductId { set; get; }
            [Field] public int LanguageId { set; get; }
            [Field(Name = "Tên"), ValidatorRequire, ValidatorLength(Max = 300)] public string Name { set; get; }
            [Field(Name = "Mô tả ngắn"), ValidatorLength(Max = 500)] public string Sapo { set; get; }
            [Field(Name = "Mô tả chi tiết")] public string Description { set; get; }
            [Field(Name = "Meta Keywords"), ValidatorLength(Max = 250)] public string MetaKeywords { set; get; }
            [Field(Name = "Meta Description"), ValidatorLength(Max = 250)] public string MetaDescription { set; get; }
            [Field] public string Alias { set; get; }
            #endregion

            public int Key
            {
                get { return ProductId; }
                set { ProductId = value; }
            }
            public int KeyLanguage
            {
                get { return ProductLanguageId; }
                set { ProductLanguageId = value; }
            }

            public List<Language> GetEntityLanguages(int key) => SelectToList(nl => nl.ProductId == key);
            public string NameForAlias => Name;
        }
    }
}
