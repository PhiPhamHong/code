using Core.Attributes;
using Core.Utility;
using System;
using System.Collections.Generic;

namespace Core.Business.Entities.CRM.Reports
{
    public class CallHistory : MainDb.Entity<CallHistory>, ICompanyNeedValidate
    {
        public int UserCallId { get; set; }
        [PropertyInfo(Name = "Nhân viên gọi")] public string UserName { get; set; }
        [PropertyInfo(Name = "Ngày gia nhập")] public DateTime JoinDate { get; set; }
        [PropertyInfo(Name = "Tổng cuộc gọi")] public int TotalCall { get; set; }
        public int CompanyId { get; set; }
        [PropertyInfo(Name = "STT")] public int Row { get; set; }
        public class DataSource : DataSource<CallHistory>.Module, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public int UserCallId { get; set; }
            public DateTime FromDate { get; set; }
            public DateTime ToDate { get; set; }
            public override List<CallHistory> GetEntities() => Inst.ExeStoreToList("sp_TeleSale_CallHistories_GetReport", CompanyId, UserCallId, FromDate, ToDate, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>("sp_TeleSale_CallHistories_GetReport_Count", CompanyId, UserCallId, FromDate, ToDate);
            
        }
    }
}
