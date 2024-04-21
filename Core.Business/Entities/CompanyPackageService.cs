using System;
using Core.Attributes;
using Core.DataBase.ADOProvider.Attributes;
using Newtonsoft.Json;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;

namespace Core.Business.Entities
{
    [TableInfo(TableName = "CompanyPackageServices", Name="Gói dịch vụ")]
    public partial class CompanyPackageService : MainDb.Entity<CompanyPackageService>, IModel<int>
    {
        #region properties
        [Field(IsKey = true, IsIdentity = true)] public int Id { set; get; }
        [Field(Name = "Công ty"), ValidatorDenyValue(0)] public int CompanyId { set; get; }
        [Field(Name = "Gói dịch vụ"), ValidatorDenyValue(0)] public int PackageServiceId { set; get; }
        [Field(Name = "Từ ngày"), ValidatorRequire, ValidatorIsDate(Stt = 1)] public DateTime? StartTime { set; get; }
        [Field(Name = "Đến ngày"), ValidatorIsDate, ValidatorDateGreater("StartTime", Stt = 1)] public DateTime? EndTime { set; get; }
        [Field] public int UserUpdated { set; get; }
        [Field, JsonIgnore] public DateTime TimeUpdated { set; get; }
        [Field(Name = "Ghi chú")] public string Description { set; get; }
        #endregion

        [PropertyInfo(Name = "Công ty")] public string CompanyName { set; get; }
        [PropertyInfo(Name = "Gói dịch vụ")] public string PackageServiceName { set; get; }

        [PropertyInfo(Name = "Áp dụng cấu hình cho công ty")] public bool ApplyConfigToCompany { set; get; }

        public override void Save()
        {
            ExeStoreNoneQuery(MainDbStore.sp_CompanyPackageServices_Save);
        }

        public int Key
        {
            get { return Id; }
            set { Id = value; }
        }
    }
}
