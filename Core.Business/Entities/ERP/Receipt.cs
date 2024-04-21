using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using System;
using System.Collections.Generic;

namespace Core.Business.Entities.ERP
{
    [TableInfo(TableName = "[Receipts]", Name = "Phiếu thu")]
    public class Receipt : MainDb.Entity<Receipt>, IModel<int>, IEntityForLogShowName, ICompanyNeedValidate, IReportSummary
    {
        [Field(IsKey = true, IsIdentity = true)] public int CashId { get; set; }
        [Field(Name = "Công ty")] public int CompanyId { get; set; }
        [Field(Name = "Mã phiếu"), ValidatorRequire] public string Code { get; set; }
        [Field(Name = "Ngày lập"), ValidatorRequire] public DateTime? CreatedDate { get; set; }
        [Field(Name = "Người lập"), ValidatorRequire] public int UserId { get; set; }
        [Field(Name = "Trạng thái")] public OrderStatus Status { get; set; }
        [Field(Name = "Nguồn tiền"), ValidatorRequire] public int CashSourceId { get; set; }
        [Field(Name = "Bên thanh toán")/*, ValidatorRequire*/] public int PartnerId { get; set; } //Có thể là đại lý khách
        [Field(Name = "Khách hàng")] public int TeleSaleId { get; set; }
        [Field(Name = "Đơn hàng")] public int OrderId { get; set; } //Phiếu xuất hàng hoặc phiếu thu hoàn tiền
        [Field(Name = "Mã đơn hàng")] public string OrderCode { get; set; } //Tương tự
        [PropertyInfo(Name = "Số tiền")] public decimal? AmountTemp { get; set; }
        [Field(Name = "Số tiền")] public decimal? Amount { get; set; }
        [Field(Name = "Loại đối tượng")] public ReceiptObjectType ObjectType { get; set; } //nếu mà chọn là khách lẻ thì phải nhập tên họ, SĐT + Email để đối chiếu
        /// <summary>
        /// Thông tin cần nhập nếu là khách lẻ hoặc khoản chi khác
        /// </summary>
        [Field(Name = "Tên khách")] public string CusName { get; set; }
        [Field(Name = "Địa chỉ")] public string CusAddress { get; set; }
        [Field(Name = "Số điện thoại")] public string CusPhone { get; set; }

        [PropertyInfo(Name = "Tiền thuế")] public decimal? TaxTemp { get; set; }
        [Field(Name = "Tính vào báo cáo thuế")] public bool IsTax { set; get; }
        [Field(Name = "Báo cáo nội bộ")] public bool IsInternal { set; get; }

        [Field(Name = "Tiền thuế")] public decimal? Tax { get; set; }


        [Field(Name = "Loại tiền")] public int CurrencyId { get; set; }
        [Field(Name = "Tỷ giá")] public decimal? ExchangeRate { get; set; }
        [Field(Name = "Tài khoản"), ValidatorRequire] public int AccountId { get; set; }
        [Field(Name = "Loại phiếu"), ValidatorRequire] public ReceiptType Type { get; set; }
        [Field(Name = "Ghi chú")] public string Note { get; set; }
        public string Name { get { return Code; } }

        public string OrderIds { get; set; }

        [PropertyInfo(Name = "Người lập")] public string ConfirmByUserName { get; set; }
        [PropertyInfo(Name = "Đại lý/khách")] public string PartnerName { get; set; }
        [PropertyInfo(Name = "Loại tiền")] public string CurrenyName { get; set; }
        [PropertyInfo(Name = "Nhân viên")] public string EmpName { get; set; }

        [PropertyInfo(Name = "Stt")] public int Row { get; set; }
        [PropertyInfo(Name = "Loại phiếu")] public virtual string TypeString { get { return EnumHelper<ReceiptType, FieldInfoAttribute>.Inst.GetAttribute(Type).Name; } }
        [PropertyInfo(Name = "Loại đối tượng")] public string ObjectTypeString { get { return EnumHelper<ReceiptObjectType, FieldInfoAttribute>.Inst.GetAttribute(ObjectType).Name; } }
        [PropertyInfo(Name = "Trạng thái")] public string StatusString { get { return EnumHelper<OrderStatus, FieldInfoAttribute>.Inst.GetAttribute(Status).Name; } }

        public int Key
        {
            get { return CashId; }
            set { CashId = value; }
        }

        public int Total { get; set; }
        public string TitleSummary { get; set; }

        public class DataSource : DataSource<Receipt>.ReportSummary<Receipt>, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public int PartnerId { get; set; }
            public int TeleSaleId { get; set; }
            public string Code { get; set; }
            public int UserId { get; set; }
            public DateTime? StartTime { set; get; }
            public DateTime? EndTime { set; get; }
            public PaymentType Type { get; set; }
            public CashObjectType ObjectType { get; set; }
            public OrderStatus Status { get; set; }
            public string OrderIds { get; set; }

            public override Receipt GetDataSummary()
            {
                Receipt result = Inst.ExeStoreToFirst("sp_Receipts_GetData_Sum", CompanyId, PartnerId, TeleSaleId, Code, UserId, StartTime, EndTime, Type, ObjectType, Status, OrderIds);
                result.TitleSummary = "Tổng: ";
                return result;
            }
            public override List<Receipt> GetEntities() => Inst.ExeStoreToList("sp_Receipts_GetData", CompanyId, PartnerId, TeleSaleId, Code, UserId, StartTime, EndTime, Type, ObjectType, Status, OrderIds, Start, Length, FieldOrder, Dir);
        }
        public class DataProvider : DataSource<Receipt>.ReportSummary<Receipt>, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public int OrderId { get; set; }
            public int PartnerId { get; set; }
            public int TeleSaleId { get; set; }
            public override Receipt GetDataSummary()
            {
                Receipt result = Inst.ExeStoreToFirst("sp_Receipts_GetData_Provider_Sum", CompanyId, OrderId);
                result.TitleSummary = "Tổng: ";
                return result;
            }
            public override List<Receipt> GetEntities() => Inst.ExeStoreToList("sp_Receipts_GetData_Provider", CompanyId, OrderId, Start, Length, FieldOrder, Dir);
        }
    }
    public enum ReceiptType : int
    {
        [FieldInfo(Name = "-- Chọn loại phiếu --")] Unknown = 0,
        [FieldInfo(Name = "Phiếu thu nợ khách hàng")] Receipt = 1,
        [FieldInfo(Name = "Phiếu thu nội bộ")] InterReceipt = 2,
        [FieldInfo(Name = "Phiếu thu hoàn tiền")] Refund = 3,
        [FieldInfo(Name = "Khác...")] Other = 4
    }
}
