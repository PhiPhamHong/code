using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using Core.Web.WebBase.HtmlBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Entities.ERP
{
    [TableInfo(TableName = "[Stocks]", Name = "Kho hàng")]
    public class Stock : MainDb.EntityAuthor<Stock>,IModel<int>, ICompanyNeedValidate
    {
        [Field(IsKey = true, IsIdentity = true), DataValueField(Default = "0")] public int StockId { get; set; }
        [Field(Name = "Công ty"), ValidatorRequire] public int CompanyId { get; set; }
        [Field(Name = "Tên"), ValidatorRequire] public string Name { get; set; }
        [Field(Name = "Mã"), ValidatorRequire] public string Code { get; set; }
        [Field(Name = "Quản lý"), ValidatorRequire] public int ManagerId { get; set; }
        [Field(Name = "Địa chỉ")] public string Address { get; set; }
        [Field(Name = "Sử dụng")] public bool IsActive { get; set; }
        [DataTextField(Default = "-- Chọn kho hàng --")] public string FindName { get { return Code + " - " + Name; } }
        public int Key
        {
            get { return StockId; }
            set { StockId = value; }
        }

        [PropertyInfo(Name = "STT")] public int Row { get; set; }
        [PropertyInfo(Name = "Thủ kho")] public string ManagerName { get; set; }
        
        public class DataSource : DataSource<Stock>.Module, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public int ManagerId { get; set; }
            public string Name { get; set; }

            public override List<Stock> GetEntities() => Inst.ExeStoreToList("sp_Stocks_GetData", CompanyId, ManagerId, Name, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => CurrentData.Count;
            
        }
        [TableInfo(TableName = "[Stock.Products]", Name = "Mặt hàng trong kho")]
        public class Product : MainDb.Entity<Product>, IModel<int>, ICompanyNeedValidate
        {
            [Field(IsKey = true, IsIdentity = true)] public int ProductInStockId { get; set; }
            [Field(Name = "Kho hàng")] public int StockId { get; set; }
            [Field(Name = "Công ty"), ValidatorRequire] public int CompanyId { get; set; }
            [Field(Name = "Sản phẩm")] public int ProductId { get; set; }
            [Field(Name = "Thuộc tính thêm")] public int SubProductId { get; set; }
            [Field(Name = "Số lượng")] public  int Quantity { get; set; }

            [PropertyInfo(Name = "STT")] public int Row { get; set; }
            [PropertyInfo(Name = "Kho hàng")] public string StockName { get; set; }
            [PropertyInfo(Name = "Tên sản phẩm")] public string ProductName { get; set; }
            [PropertyInfo(Name = "Mã sản phẩm")] public string ProductCode { get; set; }
            [PropertyInfo(Name = "Thuộc tính thêm")] public string SubName { get; set; }
            [PropertyInfo(Name = "Tổng mua vào")] public decimal Capital { get; set; }
            [PropertyInfo(Name = "Tổng bán ra")] public decimal Amount { get; set; }
            public int Key
            {
                get { return ProductInStockId; }
                set { ProductInStockId = value; }
            }
            
            public class DataSource: DataSource<Product>.Module, ICompanyNeedValidate
            {
                public int CompanyId { get; set; }
                public int StockId { get; set; }
                public int ProductId { get; set; }
                public int LanguageId { get; set; }

                public override List<Product> GetEntities() => Inst.ExeStoreToList("sp_StockProducts_GetData", CompanyId, StockId, ProductId, LanguageId, Start, Length, FieldOrder, Dir);
                public override int GetTotal() => CurrentData.Count;
                
            }
            public static Product CheckHasValue(int companyId , int stockid, int productId, int propertyId)
            {
                return Inst.ExeStoreToFirst("sp_Stock_Products_GetForCheckHasValue", companyId, stockid, productId, propertyId);
            }
        }
        [TableInfo(TableName = "[Stock.Histories]", Name = "Lịch sử nhập xuất kho hàng")]
        public class History : MainDb.Entity<History>, IModel<int>, ICompanyNeedValidate
        {
            [Field(IsKey = true, IsIdentity = true)] public int StockHistoryId { get; set; }
            [Field(Name = "Kho hàng")] public int StockId { get; set; }
            [Field(Name = "Đơn hàng")] public int OrderId { get; set; }
            [Field(Name = "Công ty"), ValidatorRequire] public int CompanyId { get; set; }
            [Field(Name = "Sản phẩm")] public int ProductId { get; set; }
            [Field(Name = "Thuộc tính thêm")] public int SubProductId { get; set; }
            [Field(Name = "Số lượng")] public int Quantity { get; set; }
            [Field(Name = "Đơn giá nhập")] public decimal Cost { get; set; }
            [Field(Name = "Giá bán")] public decimal Price { get; set; }
            [Field(Name = "Tổng giá nhập")] public decimal Capital { get; set; }
            [Field(Name = "Tống giá bán")] public decimal Amount { get; set; }
            [Field(Name = "Loại")] public HistoryType HType { get; set; }
            [Field(Name = "Ngày ghi")] public DateTime CreatedDate { get; set; }
            [Field(Name = "Người xuất/bán")] public int ByUserId { get; set; }
            [Field(Name = "Ghi chú")] public string Note { get; set; }
            public int Key
            {
                get { return StockHistoryId; }
                set { StockHistoryId = value; }
            }
            public enum HistoryType : int
            {
                [FieldInfo(Name = "-- Loại --")] Unknown = 0,
                [FieldInfo(Name = "Xuất hàng")] Out = 1,
                [FieldInfo(Name = "Nhập hàng")] In = 2 
            }
            [PropertyInfo(Name = "STT")] public int Row { get; set; }

            [PropertyInfo(Name = "Đơn hàng")] public string OrderCode { get; set; }
            [PropertyInfo(Name = "Mã kho")] public string StockCode { get; set; }
            [PropertyInfo(Name = "Kho hàng")] public string StockName { get; set; }
            [PropertyInfo(Name = "Tên sản phẩm")] public string ProductName { get; set; }
            [PropertyInfo(Name = "Mã sản phẩm")] public string ProductCode { get; set; }
            [PropertyInfo(Name = "Người xuất/bán")] public string ByUserName { get; set; }
            [PropertyInfo(Name = "Loại ")] public string HTypeString { get { return EnumHelper<HistoryType, FieldInfoAttribute>.Inst.GetAttribute(HType).Name; } }

            public class DataSource : DataSource<History>.Module, ICompanyNeedValidate
            {
                public int CompanyId { get; set; }
                public int StockId { get; set; }
                public int ProductId { get; set; }
                public int LanguageId { get; set; }
                public override List<History> GetEntities() => Inst.ExeStoreToList("sp_Stock_Histories_GetData", CompanyId, StockId, ProductId, LanguageId, Start, Length, FieldOrder, Dir);
                public override int GetTotal() => Inst.SelectFirstValue<int>("sp_Stock_Histories_GetData_Count", CompanyId, StockId, ProductId, LanguageId);
            }

            public static History GetByOrderId(int companyId, int orderId)
            {
                return Inst.ExeStoreToFirst("sp_Stock_Histories_GetByOrderId", companyId, orderId);
            }
            public static void UpdateStockHistory(int StockId, int OrderId, int CompanyId, int ProductId,int SubProductId, int Quantity , decimal Cost, decimal Price, decimal Capital, decimal Amount, HistoryType HType, DateTime CreatedDate, int ByUserId)
            {
                Inst.ExeStoreNoneQuery("sp_StockHistories_DoSaveAndUpdate", StockId, OrderId, CompanyId, ProductId, SubProductId, Quantity, Cost, Price, Capital, Amount, HType, CreatedDate, ByUserId);
            }
        }
    }
}
