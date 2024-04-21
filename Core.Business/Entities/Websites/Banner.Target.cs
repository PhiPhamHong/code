using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using Core.Web.WebBase.HtmlBuilders;

using System.Collections.Generic;


namespace Core.Business.Entities.Websites
{
    public partial class Banner
    {
        [TableInfo(TableName = "[Banners.Target]", Name = "Địa chỉ banners")]
        public class Target : MainDb.Entity<Target>, ICompanyNeedValidate
        {
            [Field(Name = "ID", IsIdentity = true, IsKey = true)] public int AddressId { get; set; }
            [Field(Name = "Công ty")] public int CompanyId { get; set; }
            [Field(Name = "Code"), DataValueField(Default = ""), ValidatorRequire] public string Code { get; set; }
            [Field(Name = "Tiêu đề"), DataTextField(Default = "-- Chọn --"), ValidatorRequire] public string Title { get; set; }
            [Field(Name = "Mô tả")] public string Description { get; set; }
            public class DataSource : DataSource<Target>.Module, ICompanyNeedValidate
            {
                public int CompanyId { set; get; }
                public string Code { get; set; }
                public override List<Target> GetEntities() => Inst.ExeStoreToList("sp_Banners_Target_GetData", CompanyId, Code, Start, Length, FieldOrder, Dir);
                public override int GetTotal() => CurrentData.Count;

            }
        }
    }
}
