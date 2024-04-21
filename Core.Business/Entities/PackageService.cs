using Core.Attributes.Validators;
using Core.DataBase.ADOProvider.Attributes;
using Core.Web.WebBase.HtmlBuilders;
using Core.DataBase.ADOProvider;

namespace Core.Business.Entities
{
    [TableInfo(TableName = MainDbTable.PackageServices, Name = "Gói dịch vụ")]
    public class PackageService : MainDb.Entity<PackageService>, IModel<int>
    {
        #region properties
        [Field(IsKey = true, IsIdentity = true), DataValueField(Default = "0")] public int PackageServiceId { set; get; }
        [Field(Name = "Gói dịch vụ"), DataTextField(Default = "-- Gói dịch vụ --"), ValidatorRequire] public string Name { set; get; }
        #endregion

        public int Key
        {
            get { return PackageServiceId; }
            set { PackageServiceId = value; }
        }
    }
}