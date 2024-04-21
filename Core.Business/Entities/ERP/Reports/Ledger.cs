using Core.Attributes;
using Core.DataBase.ADOProvider;
using Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Entities.ERP.Reports
{
    public class Ledger : MainDb.Entity<Ledger>, ICompanyNeedValidate
    {
        public int CompanyId { get; set; }
        public int CashId { get; set; }
        public LedType Type { get; set; }
        [PropertyInfo(Name = "Phiếu")] public string TypeString { get { return EnumHelper<LedType, FieldInfoAttribute>.Inst.GetAttribute(Type).Name; } }
        [PropertyInfo(Name = "Mã phiếu")] public string Code { get; set; }
        [PropertyInfo(Name = "Ngày lập phiếu")] public DateTime CreatedDate { get; set; }
        [PropertyInfo(Name = "Ghi chú")] public string Note { get; set; }
        public int CashSourceId { get; set; }
        [PropertyInfo(Name = "Nguồn  tiền quỹ")] public string CashSourceName { get; set; }
        public int AccountId { get; set; }
        [PropertyInfo(Name = "Tài khoản kế toán")] public string AccountName { get; set; } 
        public int PartnerId { get; set; }
        public string PartnerName { get; set; }
        public string CusName { get; set; }
        [PropertyInfo(Name = "Đại lý/khách")] public string ShowName { get { return PartnerId == 0 ? CusName : PartnerName; } }
        [PropertyInfo(Name = "Tổng tiền")] public decimal? Amount { get; set; }
        public OrderStatus Status { get; set; }
        public OrderStatus UsedStatus { get { return Status == OrderStatus.Unknown ? OrderStatus.Done : Status; } }
        [PropertyInfo(Name = "Trạng thái")] public string StatusName { get { return EnumHelper<OrderStatus, FieldInfoAttribute>.Inst.GetAttribute(UsedStatus).Name; } }

        public int CreatedByUserId { get; set; }
        [PropertyInfo(Name = "Nguời lập phiếu")] public string CreatedByUserName { get; set; }

        public class DataSource : DataSource<Ledger>.Module, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public string Code { get; set; }
            public LedType Type { get; set; }
            public DateTime FromDate { get; set; }
            public DateTime ToDate { get; set; }
            public override List<Ledger> GetEntities() => Inst.ExeStoreToList("sp_Get_Ledgers_GetData", CompanyId, Code, Type, FromDate, ToDate, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>("sp_Get_Ledgers_GetData_Count", CompanyId, Code, Type, FromDate, ToDate);
            
        }


        public static List<ChartItem<int, decimal>> GetSumInMonth(int companyId, int month, int year, LedType ledgerType) => Inst.ExeStoreToList<ChartItem<int, decimal>>("sp_Ledgers_GetSumInMonthYear", companyId, month, year, ledgerType).FormatMonthYear(month, year);
        public static List<ChartItem<int, decimal>> GetSumInYear(int companyId, int year, LedType ledgerType) => Inst.ExeStoreToList<ChartItem<int, decimal>>("sp_Ledgers_GetSumInYear", companyId, year, ledgerType).FormatYear();
    }
    public enum LedType : int
    {
        [FieldInfo(Name = "-- Loại phiếu --")] Unknown = 0,
        [FieldInfo(Name = "Phiếu thu")] Receipt = 1,
        [FieldInfo(Name = "Phiếu chi")] Payment = 2
    }
}
