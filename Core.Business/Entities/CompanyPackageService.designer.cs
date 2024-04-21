using System;
using System.Linq;
using System.Collections.Generic;
using Core.Extensions;
using Core.Utility;
using Core.DataBase.ADOProvider.Attributes;
using Core.Attributes.Validators;

namespace Core.Business.Entities
{
    public partial class CompanyPackageService
    {
        public class DataSource : DataSource<CompanyPackageService>.Module
        {
            public string CompanyName { set; get; }

            [Field(Name = "Ngày áp dụng"), ValidatorIsDate] public DateTime? StartTime { set; get; }
            [Field(Name = "Ngày hết hạn"), ValidatorIsDate, ValidatorDateGreater("StartTime")] public DateTime? EndTime { set; get; }
            public bool ShowHistory { set; get; }

            public override List<CompanyPackageService> GetEntities()
            {
                if (ShowHistory) return Inst.ExeStoreToList<CompanyPackageService>("sp_CompanyPackageServiceHistories_GetData", CompanyName, StartTime, EndTime, Start, Length, FieldOrder, Dir);
                else return Inst.ExeStoreToList("sp_CompanyPackageServices_GetData", CompanyName, StartTime, EndTime, Start, Length, FieldOrder, Dir);
            }

            public override int GetTotal()
            {
                if (ShowHistory) return Inst.ExeStore("sp_CompanyPackageServiceHistories_GetDataCount", CompanyName, StartTime, EndTime).Rows[0][0].To<int>();
                else return Inst.ExeStore("sp_CompanyPackageServices_GetData_Count", CompanyName, StartTime, EndTime).Rows[0][0].To<int>();
            }
        }
        public static CompanyPackageService GetByCompanyId(int companyId) => Inst.SelectToList(c => c.CompanyId == companyId).FirstOrDefault();
    }
}
