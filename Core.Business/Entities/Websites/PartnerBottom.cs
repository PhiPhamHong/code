using Core.Attributes.Validators;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;

using System.Collections.Generic;


namespace Core.Business.Entities.Websites
{
    [TableInfo(TableName = "[PartnerToWebs]", Name = "Đối tác hiển thị Website")]
    public class PartnerBottom : MainDb.Entity<PartnerBottom>, ICompanyNeedValidate
    {
        [Field(IsKey = true, IsIdentity = true)] public int PnerId { get; set; }
        [Field(Name = "Công ty")] public int CompanyId { get; set; }
        [Field(Name = "Tên đối tác"), ValidatorRequire] public string Name { get; set; }
        [Field(Name = "Mô tả")] public string Des { get; set; }
        [Field(Name = "Logo"), ValidatorRequire] public string Logo { get; set; }
        [Field(Name = "Đường dẫn")] public string Link { get; set; }
        [Field(Name = "Hiển thị")] public bool IsShow { get; set; }

        public class DataSource : DataSource<PartnerBottom>.Module, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public override List<PartnerBottom> GetEntities() => Inst.ExeStoreToList("sp_PartnerToWebs_GetData", CompanyId);
            public override int GetTotal() => CurrentData.Count;
            
        }
    }
}
