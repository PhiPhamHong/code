using Core.Attributes;
using Core.DataBase.ADOProvider;
using Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Core.Business.Entities.ERP.Reports
{
    public class SumRevenueBySale : MainDb.Entity<SumRevenueBySale>, IReportSummary, ICompanyNeedValidate
    {
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        [PropertyInfo(Name = "Mã")] public string SaleUserCode { get; set; }
        [PropertyInfo(Name = "Nhân viên")] public string SaleUserName { get; set; }
        [PropertyInfo(Name = "Ngày gia nhập")] public DateTime CreatedDate { get; set; }
        [PropertyInfo(Name = "Doanh thu")] public decimal? Amount { get; set; }
        public int Total { get; set; }
        public string TitleSummary { get; set; }
        [PropertyInfo(Name = "STT")] public int Row { get; set; }
        public class DataSource : DataSource<SumRevenueBySale>.ReportSummary<SumRevenueBySale>, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public int UserId { get; set; }
            public DateTime? FromDate { get; set; }
            public DateTime? ToDate { get; set; }
            public override SumRevenueBySale GetDataSummary()
            {
                SumRevenueBySale result = new SumRevenueBySale();
                result.TitleSummary = "Tổng doanh thu";
                result.Total = CurrentData.Sum(c => c.Total);
                return result;
            }

            public override List<SumRevenueBySale> GetEntities() => Inst.ExeStoreToList("sp_GetSumRevenueBySaleId", CompanyId, UserId, FromDate, ToDate, Start, Length, FieldOrder, Dir);
        }
    }
}
