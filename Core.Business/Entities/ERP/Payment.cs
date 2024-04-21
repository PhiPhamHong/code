using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using System;
using System.Collections.Generic;

namespace Core.Business.Entities.ERP
{
    [TableInfo(TableName = "[Payments]", Name = "Phiếu chi")]
    public class Payment : MainDb.Entity<Payment>, IModel<int>, IEntityForLogShowName, ICompanyNeedValidate, IReportSummary
    {
        [Field(IsKey = true, IsIdentity = true)] public int CashId { get; set; }
        [Field(Name = "Công ty")] public int CompanyId { get; set; }
        [Field(Name = "Mã phiếu"), ValidatorRequire] public string Code { get; set; }
        [Field(Name = "Ngày lập"), ValidatorRequire] public DateTime? CreatedDate { get; set; }
        [Field(Name = "Người lập")] public int UserId { get; set; }
        [Field(Name = "Nguồn tiền"), ValidatorRequire] public int CashSourceId { get; set; }
        [Field(Name = "Đại lý/khách")] public int PartnerId { get; set; }
        [Field(Name = "Khách hàng")] public int TeleSaleId { get; set; }
        [Field(Name = "Nhân viên")] public int EmployeeId { get; set; }
        [Field(Name = "Tháng")] public int Month { get; set; }
        [Field(Name = "Năm")] public int Year { get; set; }
        [Field(Name = "Đơn hàng")] public int OrderId { get; set; } //Phiếu mua hàng hoặc phiếu lương
        [Field(Name = "Mã đơn hàng")] public string OrderCode { get; set; } //Tương tự
        [PropertyInfo(Name = "Số tiền")]public decimal? AmountTemp { get; set; }
        [Field(Name = "Số tiền"), ValidatorRequire] public decimal? Amount { get; set; }
        [Field(Name = "Chi cho"), ValidatorRequire] public CashObjectType ObjectType { get; set; } //nếu mà chọn là khách lẻ thì phải nhập tên họ, SĐT + Email để đối chiếu
        /// <summary>
        /// Thông tin cần nhập nếu là khách lẻ hoặc khoản chi khác
        /// </summary>
        [Field(Name = "Tên khách")] public string CusName { get; set; }
        [Field(Name = "Địa chỉ")] public string CusAddress { get; set; }
        [Field(Name = "Số điện thoại")] public string CusPhone { get; set; }


        [Field(Name = "Báo cáo thuế")] public bool IsTax { set; get; }
        [Field(Name = "Báo cáo nội bộ")] public bool IsInternal { set; get; }

        [PropertyInfo(Name = "Tiền thuế")] public decimal? TaxTemp { get; set; }
        [Field(Name = "Tiền thuế")] public decimal? Tax { get; set; }

        [Field(Name = "Loại tiền"), ValidatorRequire] public int CurrencyId { get; set; }
        [Field(Name = "Tỷ giá")] public decimal? ExchangeRate { get; set; }
        [Field(Name = "TK tham chiếu"), ValidatorRequire] public int AccountId { get; set; }
        [Field(Name = "Loại phiếu"), ValidatorRequire] public PaymentType Type { get; set; }
        [Field(Name = "Ghi chú")] public string Note { get; set; }
        public string Name { get { return Code; } }


        [PropertyInfo(Name = "Người lập")] public string ConfirmByUserName { get; set; }
        [PropertyInfo(Name = "Đại lý/khách")] public string PartnerName { get; set; }
        [PropertyInfo(Name = "Loại tiền")] public string CurrenyName { get; set; }
        [PropertyInfo(Name = "Nhân viên")] public string EmpName { get; set; }


        [PropertyInfo(Name = "Stt")] public int Row { get; set; }
        [PropertyInfo(Name = "Loại phiếu")] public virtual string TypeString { get { return EnumHelper<PaymentType, FieldInfoAttribute>.Inst.GetAttribute(Type).Name; } }
        [PropertyInfo(Name = "Chi cho")] public string ObjectTypeString { get { return EnumHelper<CashObjectType, FieldInfoAttribute>.Inst.GetAttribute(ObjectType).Name; } }

        public int Key
        {
            get { return CashId; }
            set { CashId = value; }
        }
        public int Total { get; set; }
        public string TitleSummary { get; set; }

        public class DataSource : DataSource<Payment>.ReportSummary<Payment>, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public int PartnerId { get; set; }
            public string Code { get; set; }
            public int UserId { get; set; }
            public DateTime? StartTime { set; get; }
            public DateTime? EndTime { set; get; }
            public PaymentType Type { get; set; }
            public CashObjectType ObjectType { get; set; }

            public override Payment GetDataSummary()
            {
                Payment result = Inst.ExeStoreToFirst("sp_Payments_GetData_Sum", CompanyId, PartnerId, Code, UserId, StartTime, EndTime, Type, ObjectType);
                result.TitleSummary = "Tổng: ";
                return result;
            }
            public override List<Payment> GetEntities() => Inst.ExeStoreToList("sp_Payments_GetData", CompanyId, PartnerId, Code, UserId, StartTime, EndTime, Type, ObjectType, Start, Length, FieldOrder, Dir);
        }
        public class DataProvider : DataSource<Payment>.ReportSummary<Payment>, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public int OrderId { get; set; }
            public int PartnerId { get; set; }
            public int TeleSaleId { get; set; }
            public override Payment GetDataSummary()
            {
                Payment result = Inst.ExeStoreToFirst("sp_Payments_GetData_Provider_Sum", CompanyId, OrderId);
                result.TitleSummary = "Tổng: ";
                return result;
            }
            public override List<Payment> GetEntities() => Inst.ExeStoreToList("sp_Payments_GetData_Provider", CompanyId, OrderId, Start, Length, FieldOrder, Dir);
        }
    }
    public enum PaymentType : int
    {
        [FieldInfo(Name = "-- Chọn loại phiếu --")] Unknown = 0,
        [FieldInfo(Name = "Phiếu chi nợ nhà cung cấp")] Pay = 1,
        [FieldInfo(Name = "Phiếu chi hoa hồng đại lý")] PayCom = 2,
        [FieldInfo(Name = "Phiêu chi nội bộ")] InterPay = 3,
        [FieldInfo(Name = "Phiếu chi hoàn tiền")] Refund = 4,
        [FieldInfo(Name = "Phiếu chi lương")] Salary = 5,
        [FieldInfo(Name = "Khác...")] Other = 6
    }
}
