using Core.Attributes;

namespace Core.Business.Entities.ERP
{
    public enum CashObjectType : int
    {
        [FieldInfo(Name = "-- Chi cho --")] Unknown = 0,
        [FieldInfo(Name = "Nhà cung cấp")] Supplier = 1,
        [FieldInfo(Name = "Khách hàng hệ thống")] Internal = 3,
        [FieldInfo(Name = "Khách hàng lẻ")] Customer = 2,
        [FieldInfo(Name = "Nhân viên")] Employ = 4,
        [FieldInfo(Name = "Khác...")] Other = 5,
    }
    public enum ReceiptObjectType : int
    {
        [FieldInfo(Name = "-- Nguồn tiền --")] Unknown = 0,
        [FieldInfo(Name = "Nhà cung cấp")] Supplier = 1,
        [FieldInfo(Name = "Khách hàng hệ thống")] Internal = 3,

        [FieldInfo(Name = "Khách hàng lẻ")] Customer = 2,
        
        [FieldInfo(Name = "Khác...")] Other = 4
    }
}
