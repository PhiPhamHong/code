
using System.Linq;

using Core.DataBase.ADOProvider.Attributes;

using Core.DataBase.ADOProvider;
using Core.Attributes.Validators;
using Core.Business.Entities.CRM;

namespace Core.Business.Entities
{
    [TableInfo(TableName = MainDbTable.CompanyConfigs, Name = "Cấu hình công ty")]
    public class CompanyConfig : MainDb.Entity<CompanyConfig>, IModel<int>
    {
        #region Cấu hình chung
        [Field(IsKey = true, IsIdentity = true)] public int ConfigId { set; get; }
        [Field(Name = "Công ty")] public int CompanyId { set; get; }
        [Field(Name = "Tên đầy đủ"), ValidatorRequire] public string FullName { set; get; }
        [Field(Name = "Logo"), ValidatorRequire] public string Logo { set; get; }
        [Field(Name = "Tên ngắn"), ValidatorRequire] public string ShortName { set; get; }
        [Field(Name = "Domain")] public string DomainName { set; get; }
        [Field(Name = "Hướng dẫn sử dụng")] public string Documents { set; get; }
        [Field(Name = "Sử dụng chi nhánh")] public bool UseBranch { set; get; }
        [Field(Name = "Sử dụng tin chia lẻ ngôn ngữ")] public bool UseNewSingleLanguage { set; get; }
        #endregion

        #region Cấu hình Email
        [Field(Name = "Phương thức")] public EmailMethodSend EmailMethod { get; set; }
        [Field(Name = "EmailHost")] public string EmailHost { set; get; }
        [Field(Name = "Tên người gửi")] public string EmailSendBy { set; get; }
        [Field(Name = "EmailPort(Cổng kết nối)")] public int? EmailPort { set; get; }
        [Field(Name = "Tài khoản gửi")] public string EmailFromId { set; get; }
        [Field(Name = "EmailFromPassword")] public string EmailFromPassword { set; get; }
        [Field(Name = "Email CC(Ghim người nhận)")] public string EmailCC { set; get; }


        [Field(Name = "SendGrid Api")] public string SendGrid_API { set; get; }
        [Field(Name = "SendGrid Email(TK Gửi)")] public string SendGrid_API_Email { set; get; }
        [Field(Name = "SendGrid Name(Người gửi)")] public string SendGrid_API_Name { set; get; }
        [Field(Name = "SendGrid ReplyEmail(TK Trả lời)")] public string SendGrid_API_ReplyEmail { set; get; }
        [Field(Name = "SendGrid ReplyEmailName(Người trả lời)")] public string SendGrid_API_ReplyEmailName { set; get; }


        [Field(Name = "Dừng gửi Email sau:")] public int WhenNeedStopSending { get; set; }
        #endregion

        #region Cấu hình phiếu in
        [Field(Name = "Logo in phiếu")] public string LogoPrint { set; get; }
        [Field(Name = "Động rộng logo in phiếu")] public int LogoPrintWidth { set; get; }
        [Field(Name = "Ảnh nền in phiếu")] public string LogoBackground { set; get; }
        [Field(Name = "Header in phiếu")] public string HeaderPrint { set; get; }
        #endregion
        #region Cấu hình Import Excel
        [Field(Name = "Mẫu Excel")] public string TemplateExcel { get; set; }
        #endregion
        #region Cấu hình kho mặc định
        [Field(Name = "Kho mặc định")] public int DefaultStockId { get; set; }
        #endregion
        #region Tiền lưu hành mặc định
        [Field(Name = "Loại tiền")] public int DefaultCurrencyId { get; set; }
        [Field(Name = "Tỷ giá")] public decimal DefaultExchangeRate { get; set; }
        #endregion
        #region Cấu hình messager
        [Field(Name = "Messager Url")] public string UriMessengerID { get; set; }
        #endregion
        public object GetByCompanyId() { return CompanyId; }
        protected void Format()
        {

        }
        

        public CompanyConfig GetByCompanyId(int companyId)
        {
            var config = SelectToList(rc => rc.CompanyId == companyId).FirstOrDefault();
            if (config != null) config.Format();
            return config;
        }
        public CompanyConfig GetByCompanyIdWithDefault(int companyId)
        {
            var rc = GetByCompanyId(companyId);
            rc = rc ?? GetByCompanyId(0);
            rc.CompanyId = companyId;
            return rc;
        }

        public int Key
        {
            get { return ConfigId; }
            set { ConfigId = value; }
        }
    }
}