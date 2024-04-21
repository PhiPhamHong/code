using Core.Attributes;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using Core.Web.WebBase.HtmlBuilders;
using System;
using System.Collections.Generic;

namespace Core.Business.Entities.ERP
{
    [TableInfo(TableName = "[Orders]", Name = "Đơn hàng")]
    public partial class Order : Diary<Order>, IModel<int>
    {
        [Field(IsIdentity = true, IsKey = true), DataValueField(Default = "0")] public override int OrderId { get; set; }
        public int Key
        {
            get { return OrderId; }
            set { OrderId = value; }
        }
        public class DataSource : DataSource<Order>.Module, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public int PartnerId { get; set; }
            public int TeleSaleId { get; set; }
            public string Code { get; set; }
            public int UserId { get; set; }
            public DateTime? StartTime { set; get; }
            public DateTime? EndTime { set; get; }
            public OrderStatus Status { get; set; }
            public OrderSource Source { get; set; }
            public OrderType Type { get; set; }
            public override List<Order> GetEntities() => Inst.ExeStoreToList("sp_Orders_GetData", CompanyId, PartnerId, TeleSaleId, Code, UserId, StartTime, EndTime, Status, Source, Type, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>("sp_Orders_GetData_Count", CompanyId, PartnerId, TeleSaleId, Code, UserId, StartTime, EndTime, Status, Source, Type);
        }

        public class ReportPie
        {
            public OrderSource OrderSource { get; set; }
            public string SourceName { get { return EnumHelper<OrderSource, FieldInfoAttribute>.Inst.GetAttribute(OrderSource).Name; } }

            public string BgColor { get { return OrderSource == OrderSource.Internal ? "#13ca4b" : OrderSource == OrderSource.Web ? "#00c0ef" : "#e5e5e5"; } }
            public int Total { get; set; }
            public decimal Amount { get; set; }
            public decimal Dept { get; set; }
        }
        public static List<ReportPie> GetPies(int companyId, DateTime start, DateTime end)
        {
            return Inst.ExeStoreToList<ReportPie>("sp_Orders_GetForChartPie", companyId, start, end);
        }
        public static List<ChartItem<int, int>> GetSumInMonth(int companyId, int month, int year) => Inst.ExeStoreToList<ChartItem<int, int>>("sp_Orders_GetSumInMonthYear", companyId, month, year).FormatMonthYear(month, year);

        [TableInfo(TableName = "[Order.Details]", Name = "Chi tiết đơn hàng")]
        public class Detail : MainDb.Entity<Detail>, IModel<int>, IEmpty , IModelForeign<int>
        {
            [Field(IsIdentity = true, IsKey = true)] public int DetailId { get; set; }
            [Field] public int OrderId { get; set; }
            [Field] public int ProductId { get; set; }
            [Field] public int StockId { get; set; }
            [Field] public int PartnerId { get; set; } //Nhà cung cấp nào?
            [Field] public int PropertyId { get; set; }//Đơn hàng extend sản phẩm (ví dụ mua điện thoại màu hường giá sẽ khác màu xanh)
            [Field] public int Quantity { get; set; } = 1; // mặc định = 1
            [Field(Name = "Giá bán cộng thêm")] public decimal? SubPrice { get; set; }
            [Field(Name = "Tổng cộng thêm")] public decimal? TotalSubPrice { get; set; }
            [Field(Name = "Giá nhập cộng thêm")] public decimal? SubCost { get; set; }
            [Field(Name = "Tổng cộng thêm")] public decimal? TotalSubCost { get; set; }

            [Field(Name = "Đơn giá vốn")] public decimal? Cost { get; set; }
            [Field(Name = "Đơn giá bán")] public decimal? Price { get; set; }
            [Field(Name = "Tổng vốn")] public decimal? Capital { get; set; }
            [Field(Name = "Tổng bán")] public decimal? Amount { get; set; }
            [Field(Name = "Hoa hồng")] public decimal? Com { get; set; }
            [Field(Name = "Lãi")] public decimal? Profit { get; set; }

            public string OrderCode { get; set; }
            public string PartnerName { get; set; }
            public string ProductName { get; set; }
            public string StockCode { get; set; }
            public string StockName { get; set; }
            public string StockShowName { get { return StockCode + " - " + StockName; } }
            public string PropertyName { get; set; }//Tên của thuộc tính cộng thêm
            public bool IsEmpty => ProductId == 0 || Quantity == 0;
            public int Key
            {
                get { return DetailId; }
                set { DetailId = value; }
            }

            public int KeyForeign
            {
                get { return OrderId; }
                set { OrderId = value; }
            }
            public int Stt { get; set; }
            public bool Editted { get; set; }

            public class DataSource : DataSource<Detail>.Module
            {
                public int CompanyId { get; set; }
                public int OrderId { get; set; }
                public int PartnerId { get; set; }
                public int LanguageId { get; set; }
                public override List<Detail> GetEntities() => Inst.ExeStoreToList("sp_Order_Details_GetData", CompanyId, OrderId, PartnerId, LanguageId, Start, Length, FieldOrder, Dir);
                public override int GetTotal() => Inst.SelectFirstValue<int>("sp_Order_Details_GetData_Count", CompanyId, OrderId, PartnerId, LanguageId);
            }

        }
    }
}
