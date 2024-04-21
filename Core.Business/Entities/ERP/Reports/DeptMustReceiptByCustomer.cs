using Core.Attributes;
using Core.DataBase.ADOProvider;
using Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Business.Entities.ERP.Reports
{
    public class DeptMustReceiptByCustomer: MainDb.Entity<DeptMustReceiptByCustomer>, IReportSummary, ICompanyNeedValidate
    {
        public int CompanyId { get; set; }
        public int TeleSaleId { get; set; }
        [PropertyInfo(Name = "Mã khách")] public string CusCode { get; set; }
        [PropertyInfo(Name = "Tên khách")] public string CusName { get; set; }
        [PropertyInfo(Name = "Ngày gia nhập")] public DateTime CreatedDate { get; set; }
        [PropertyInfo(Name = "Tổng tiền nợ")] public decimal? Amount { get; set; }
        [PropertyInfo(Name = "Tổng đã trả")] public decimal? Payed { get; set; }
        [PropertyInfo(Name = "Còn nợ")] public decimal? Remain { get; set; }
        public int Total { get; set; }
        public string TitleSummary { get; set; }
        [PropertyInfo(Name = "STT")] public int Row { get; set; }
        public string OrderIds { get; set; }
        public class DataSource : DataSource<DeptMustReceiptByCustomer>.ReportSummary<DeptMustReceiptByCustomer>, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public int TeleSaleId { get; set; }

            public override DeptMustReceiptByCustomer GetDataSummary()
            {
                DeptMustReceiptByCustomer res = new DeptMustReceiptByCustomer();
                res.TitleSummary = "Tổng nợ ";
                res.Amount = CurrentData.Sum(c => c.Amount);
                res.Payed = CurrentData.Sum(c => c.Payed);
                res.Remain = CurrentData.Sum(c => c.Remain);
                return res;
            }

            public override List<DeptMustReceiptByCustomer> GetEntities() => Inst.ExeStoreToList("sp_Get_DeptMustReceiptByCustomerId", CompanyId, TeleSaleId, Start, Length, FieldOrder, Dir);
            
        }
    }
}
