using Core.DataBase.ADOProvider.Attributes;
using Core.DataBase.ADOProvider;
namespace Core.Business.Entities
{
    [TableInfo(TableName = "[GlobalConfigs]", Name = "Cấu hình chung")]
    public class GlobalConfig : MainDb.Entity<GlobalConfig>, IModel<int>, ICompanyNeedValidate
    {
        #region Properties
        [Field(IsKey = true, IsIdentity = true)] public int GlobalConfigId { set; get; }
        [Field(Name = "Công ty")] public int CompanyId { get; set; }
        [Field(Name = "Google map key")] public string GoogleMapKey { set; get; }
        [Field(Name = "Loại tiền mặc định")] public int VND_CurrencyId { set; get; }
        [Field(Name = "Mã vùng mặc định")] public int NationalityId_Of_VN { get; set; }
        [Field(Name = "Facebook")] public string Facebook { set; get; }
        [Field(Name = "Instagram")] public string Instagram { set; get; }
        [Field(Name = "Youtube")] public string Youtube { set; get; }
        [Field(Name = "Email")] public string Email { set; get; }
        [Field(Name = "Điện thoại")] public string Phone { set; get; }
        [Field(Name = "Link website")] public string LinkWebsite { set; get; }
        [Field(Name = "Đầu số Viettel")] public string Viettel_Prefix { set; get; }
        [Field(Name = "Đầu số VinaPhone")] public string VinaPhone_Prefix { set; get; }
        [Field(Name = "Đầu số Mobifone")] public string Mobifone_Prefix { set; get; }
        [Field(Name = "Đầu số SFONE")] public string SFONE_Prefix { set; get; }
        [Field(Name = "Đầu số VietNamMobile")] public string VietNamMobile_Prefix { set; get; }
        [Field(Name = "Đầu số Beeline")] public string Beeline_Prefix { set; get; }
        [Field(Name = "Plc Api Url")] public string TimkeeperBaseUrl { set; get; }
        [Field(Name = "Server Api Url")] public string ServerApiBaseUrl { set; get; }
        #endregion

        public static GlobalConfig Empty = new GlobalConfig();

        public int Key
        {
            get { return GlobalConfigId; }
            set { GlobalConfigId = value; }
        }
        public static GlobalConfig GetByCompanyId(int companyId) => Inst.SelectFirst(c => c.CompanyId == companyId);
    }
}