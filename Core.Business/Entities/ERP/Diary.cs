using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using Core.Web.WebBase.HtmlBuilders;
using System;

namespace Core.Business.Entities.ERP
{
    public abstract class Diary<T> : MainDb.Entity<T>, IEntityForLogShowName, ICompanyNeedValidate where T : ModelBase, new()
    {
        [Field, DataValueField(Default = "0")] public virtual int OrderId { get; set; }
        [Field(Name = "Công ty")] public int CompanyId { get; set; }
        [Field(Name = "Mã đơn"), DataTextField(Default = "-- Đơn hàng --"), ValidatorRequire] public string Code { get; set; }
        [Field(Name = "Ngày lập"), ValidatorRequire] public DateTime? CreatedDate { get; set; } = DateTime.Now;
        [Field(Name = "Ngày duyệt"), ValidatorRequire] public DateTime? ConfirmDate { get; set; } = DateTime.Now; // ngày bán luôn
        [Field(Name = "Người duyệt"), ValidatorRequire] public int UserId { get; set; }
        [Field(Name = "Đơn hàng cho"), ValidatorRequire] public OrderUseFor UseFor { get; set; }
        [Field(Name = "Đại lý/khách")] public int PartnerId { get; set; } // trước thì bắt buộc, nhưng mà thôi giờ không bắt buộc nữa, vì có thể ngta bán cho khách vãng lai
        [Field(Name = "Khách hàng")] public int TeleSaleId { get; set; }

        #region Thông tin khách lẻ/ Đại lý (Khi chọn PartnerId/CustomerId kia thì thông tin dưới đây sẽ được load theo, nếu là khách vãng lai thì tự nhập)
        [Field(Name = "Tên khách")] public string ObjName { get; set; }
        [Field(Name = "Số điện thoại")] public string ObjPhone { get; set; }
        [Field(Name = "Email")] public string ObjEmail { get; set; }
        [Field(Name = "Địa chỉ")] public string ObjAddress { get; set; }
        #endregion

        [Field(Name = "Loại đơn"), ValidatorRequire] public OrderType Type { get; set; }
        [Field(Name = "Nguồn đơn"), ValidatorRequire] public OrderSource Source { get; set; }
        [Field(Name = "Tổng vốn"), ValidatorRequire] public decimal? Capital { get; set; }
        [Field(Name = "Tổng bán"), ValidatorRequire] public decimal? Amount { get; set; }
        [Field(Name = "Hoa hồng"), ValidatorRequire] public decimal? Com { get; set; }
        [Field(Name = "Lãi"), ValidatorRequire] public decimal? Profit { get; set; }
        [Field(Name = "Loại tiền"), ValidatorRequire] public int CurrencyId { get; set; }
        [Field(Name = "Tỷ giá")] public decimal? ExchangeRate { get; set; }
        [Field(Name = "Trạng thái"), ValidatorRequire] public OrderStatus Status { get; set; }
        [Field(Name = "Remains")] public decimal? Remain { get; set; }
        [Field(Name = "Đã khóa")] public bool IsLock { get; set; }
        public string Name
        {
            get { return "Mã " + Code; }
        }
        [PropertyInfo(Name = "Stt")] public int Row { get; set; }
        [PropertyInfo(Name = "Người duyệt")] public string ConfirmByUserName { get; set; }
        [PropertyInfo(Name = "Đại lý/khách")] public string PartnerName { get; set; }
        [PropertyInfo(Name = "Loại tiền")] public string CurrenyName { get; set; }
        [PropertyInfo(Name = "Trạng thái")] public string StatusString { get { return EnumHelper<OrderStatus, FieldInfoAttribute>.Inst.GetAttribute(Status).Name; } }
        [PropertyInfo(Name = "Nguồn đơn")] public string SourceString { get { return EnumHelper<OrderSource, FieldInfoAttribute>.Inst.GetAttribute(Source).Name; } }
        [PropertyInfo(Name = "Loại đơn")] public string TypeString { get { return EnumHelper<OrderType, FieldInfoAttribute>.Inst.GetAttribute(Type).Name; } }
    }
    public enum OrderType : int
    {
        [FieldInfo(Name = "-- Chọn loại đơn hàng --")] Unknown = 0,
        [FieldInfo(Name = "Đơn hàng bán lẻ")] SingleOut = 1,
        [FieldInfo(Name = "Phiếu nhập hàng")] In = 2,
        [FieldInfo(Name = "Phiếu xuất hàng")] Out = 3,
        [FieldInfo(Name = "Hàng xuất trả lại")] Return = 4,
        //[FieldInfo(Name = "Hóa đơn đỏ")] Red = 5
    }
    public enum OrderUseFor : int
    {
        [FieldInfo(Name = "-- Đơn hàng cho --")] Unknown = 0,
        [FieldInfo(Name = "Khách vãng lai")] Visitor = 1,
        [FieldInfo(Name = "Khách hàng hệ thống")] Customer = 2,
        [FieldInfo(Name = "Đại lý/khách")] Partner = 3
    }
    public enum OrderSource : int
    {
        [FieldInfo(Name = "-- Chọn nguồn đơn --")] Unknown = 0,
        [FieldInfo(Name = "Nội bộ")] Internal = 1,
        [FieldInfo(Name = "Đơn hàng từ Website")] Web = 2
    }
    public enum OrderStatus : int
    {
        [FieldInfo(Name = "-- Trạng thái thanh toán --")] Unknown = 0,
        [FieldInfo(Name = "Chưa thanh toán")] Unpaid = 1,
        [FieldInfo(Name = "Thanh toán một phần")] Undone = 2,
        [FieldInfo(Name = "Đã xong")] Done = 3,
        [FieldInfo(Name = "Hủy")] Reject = 4
    }
}
