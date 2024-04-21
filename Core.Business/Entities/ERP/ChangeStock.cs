using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Entities.ERP
{
    [TableInfo(TableName = "[ChangeStocks]", Name ="Phiếu chuyển kho")]
    public class ChangeStock : MainDb.EntityAuthor<ChangeStock>, IModel<int>, ICompanyNeedValidate
    {
        [Field(IsIdentity = true, IsKey = true)] public int ChangeStockId { get; set; }
        [Field(Name = "Công ty"), ValidatorRequire] public int CompanyId { get; set; }
        [Field(Name = "Mã phiếu"), ValidatorRequire] public string Code { get; set; }
        [Field(Name = "Kho xuất"), ValidatorRequire] public int OutStockId { get; set; }
        [Field(Name = "Kho nhập"), ValidatorRequire] public int InStockId { get; set; }
        [Field(Name = "Người xuất"), ValidatorRequire] public int OutUserId { get; set; }
        [Field(Name = "Người nhận"), ValidatorRequire] public int InUserId { get; set; }
        [Field(Name = "Trạng thái"), ValidatorRequire] public ChangeStockStatus Status { get; set; }
        [Field(Name = "Ngày xuất"), ValidatorRequire] public DateTime OutDate { get; set; }
        [Field(Name = "Số chứng từ")] public string LicKey { get; set; }
        [Field(Name = "Chứng từ đính kèm")] public string LicFile { get; set; }
        [Field(Name = "Ghi chú")] public string Note { get; set; }
        public int Key
        {
            get { return ChangeStockId; }
            set { ChangeStockId = value; }
        }
        public string OutStockCode { get; set; }
        public string OutStockName { get; set; }

        public string InStockCode { get; set; }
        public string InStockName { get; set; }

        [PropertyInfo(Name = "STT")] public int Row { get; set; }
        [PropertyInfo(Name = "Kho xuất")] public string OutStockShowName { get { return OutStockCode + " - " + OutStockName; } }
        [PropertyInfo(Name = "Kho nhập")] public string InStockShowName { get { return InStockCode + " - " + InStockName; } }
        [PropertyInfo(Name = "Người xuất")] public string OutUserName { get; set; }
        [PropertyInfo(Name = "Người nhập")] public string InUserName { get; set; }
        [PropertyInfo(Name = "Trạng thái")] public string StatusName { get { return EnumHelper<ChangeStockStatus, FieldInfoAttribute>.Inst.GetAttribute(Status).Name; } }
        public class DataSource : DataSource<ChangeStock>.Module, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }

            public override List<ChangeStock> GetEntities() => Inst.ExeStoreToList("sp_ChangeStocks_GetData", CompanyId, StartTime, EndTime, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>("sp_ChangeStocks_GetData_Count", CompanyId, StartTime, EndTime);
            
        }

        public static void UpdateStockHistoryWhenChange(int CompanyId, int OutStockId, int InStockId, int ProductId, int SubProductId, int Quantity, decimal Cost, decimal Price, decimal Capital, decimal Amount, int ByUserId)
        {
            Inst.ExeStoreNoneQuery("sp_Stock_Product_Update_WhenChangeStock", CompanyId, OutStockId, InStockId, ProductId, SubProductId, Quantity, Cost, Price, Capital, Amount, ByUserId);
        }

        [TableInfo(TableName = "[ChangeStock.Details]", Name = "Chi tiết phiếu chuyển kho")]
        public class Detail : MainDb.Entity<Detail>, IModel<int>, IEmpty, IModelForeign<int>
        {
            [Field(IsIdentity = true, IsKey = true)] public int DetailId { get; set; }
            [Field(Name = "Phiếu chuyển kho")] public int ChangeStockId { get; set; }
            [Field(Name = "Sản phẩm")] public int ProductId { get; set; }
            [Field(Name = "Thuộc tính thêm")] public int SubProductId { get; set; }
            [Field(Name = "Giá bán cộng thêm")] public decimal? SubPrice { get; set; }
            [Field(Name = "Tổng cộng thêm")] public decimal? TotalSubPrice { get; set; }
            [Field(Name = "Giá nhập cộng thêm")] public decimal? SubCost { get; set; }
            [Field(Name = "Tổng cộng thêm")] public decimal? TotalSubCost { get; set; }

            [Field(Name = "Số lượng")] public int Quantity { get; set; }
            [Field(Name = "Nhà cung cấp")] public int PartnerId { get; set; }
            [Field(Name = "Đơn giá vốn")] public decimal? Cost { get; set; }
            [Field(Name = "Đơn giá bán")] public decimal? Price { get; set; }
            [Field(Name = "Tổng vốn")] public decimal? Capital { get; set; }
            [Field(Name = "Tổng bán")] public decimal? Amount { get; set; }
            public int Key
            {
                get { return DetailId; }
                set { DetailId = value; }
            }
            public string PartnerName { get; set; }
            public string ProductName { get; set; }
            public string PropertyName { get; set; }
            public bool IsEmpty => ProductId == 0 || Quantity == 0;
            public int KeyForeign
            {
                get { return ChangeStockId; }
                set { ChangeStockId = value; }
            }
            public int Stt { get; set; }
            public bool Editted { get; set; }

            public static List<Detail> GetByChangeStockId(int changeStockId, int languageid) => Inst.ExeStoreToList("sp_ChangeStocks_Detail_GetByChangeId", changeStockId, languageid);
        }
    }
    public enum ChangeStockStatus : int
    {
        [FieldInfo(Name = "-- Trạng thái --")] Unknown = 0,
        [FieldInfo(Name = "Dự toán")] Planning = 1,
        [FieldInfo(Name = "Đã hoàn thành")] Done = 2
    }
}
