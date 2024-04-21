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
    public class DeptMustPay : MainDb.Entity<DeptMustPay>,IReportSummary, ICompanyNeedValidate
    {
        [PropertyInfo(Name = "STT")] public int Row { get; set; }
        public int CompanyId { get; set; }
        public int PartnerId { get; set; }
        [PropertyInfo(Name = "Đại lý/khách")] public string Name { get; set; }
        [PropertyInfo(Name = "Mã đại lý")] public string Code { get; set; }
        [PropertyInfo(Name = "Tỷ giá")] public decimal ExchangeRate { get; set; } = 1;
        [PropertyInfo(Name = "Đầu kỳ")] public decimal StartResidual { get; set; }
        [PropertyInfo(Name = "Quy đổi")] public decimal StartResidualSum { get { return StartResidual * ExchangeRate; } }

        [PropertyInfo(Name = "Nợ trong kỳ")] public decimal Acctual_Dept { get; set; }
        [PropertyInfo(Name = "Quy đổi")] public decimal Acctual_DeptSum { get { return Acctual_Dept * ExchangeRate; } }

        [PropertyInfo(Name = "Trả trong kỳ")] public decimal Acctual_Payed { get; set; }
        [PropertyInfo(Name = "Quy đổi")] public decimal Acctual_PayedSum { get { return Acctual_Payed * ExchangeRate; } }

        [PropertyInfo(Name = "Cuối kỳ")] public decimal Acctual_Remain { get; set; }
        [PropertyInfo(Name = "Quy đổi")] public decimal Acctual_RemainSum { get { return Acctual_Remain * ExchangeRate; } }
        public int Total { get; set; }
        public string TitleSummary { get; set; }

        public class DataSource : DataSource<DeptMustPay>.ReportSummary<DeptMustPay>, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public override DeptMustPay GetDataSummary()
            {
                var data = CurrentData;
                var result = new DeptMustPay();
                result.TitleSummary = "Tổng ";
                result.StartResidual = CurrentData.Select(c => c.StartResidual).Sum();
                result.Acctual_Dept = CurrentData.Select(c => c.Acctual_Dept).Sum();
                result.Acctual_Payed = CurrentData.Select(c => c.Acctual_Payed).Sum();
                result.Acctual_Remain = CurrentData.Select(c => c.Acctual_Remain).Sum();
                return result;

            }

            public override List<DeptMustPay> GetEntities()
            {
                var data = Inst.ExeStoreToList("sp_Partners_GetDataForReports", CompanyId, StartTime, EndTime);
                int num = 1;
                data.ForEach(c =>
                {
                    c.Row = num;
                    num++;
                });
                return data;
            }
        }
        
    }
}
