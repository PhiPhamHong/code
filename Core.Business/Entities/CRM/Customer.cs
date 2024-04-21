using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Extensions;
using Core.Utility;
using Core.Utility.Language;
using Core.Web.WebBase.HtmlBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using static Core.Business.Entities.CRM.Partner;
using Type = Core.Business.Entities.CRM.Partner.Type;

namespace Core.Business.Entities.CRM
{
    [TableInfo(TableName = "[TeleSales]", Name = "Dữ liệu Sale/Người dùng đăng ký")]
    public partial class Customer : MainDb.EntityAuthor<Customer>, IModel<int>, ICompanyNeedValidate, IEntityForLogShowName
    {
        #region Properties
        [Field(IsIdentity = true, IsKey = true), DataValueField(Default = "0")] public int TeleSaleId { set; get; }
        [Field(Name = "Công ty")] public int CompanyId { set; get; }
        [Field(Name = "Mã khách"), ValidatorRequire, ValidatorLength(Max = 50)] public string Code { set; get; }
        [Field(Name = "Khách hàng"), ValidatorRequire, ValidatorLength(Max = 500)] public string Name { set; get; }
        [Field(Name = "Điện thoại"), ValidatorRequire, ValidatorLength(Max = 11)] public string Phone { set; get; }
        [Field(Name = "Đối tác")] public int PartnerId { set; get; }
        [Field(Name = "Địa chỉ"), ValidatorRequire, ValidatorLength(Max = 500)] public string Address { set; get; }
        [Field(Name = "Hòm thư số"), ValidatorLength(Max = 500)] public string Email { set; get; }
        [Field(Name = "Đơn vị chủ quản"), ValidatorLength(Max = 500)] public string ShopName { set; get; }
        [Field(Name = "Quan tâm tới"), ValidatorRequire] public string Target { set; get; }
        [Field(Name = "Avatar")] public string Avatar { get; set; }
        [Field(Name = "Tư vấn viên")] public int UserIdCallId { set; get; }
        [Field(Name = "Kết quả")] public int ResultId { set; get; }
        [Field(Name = "Số lần gọi")] public int? TotalCall { set; get; }

        [Field(Name = "Tài khoản")] public string MemberName { get; set; }
        [Field(Name = "Mật khẩu")] public string Password { get; set; }

        [Field(Name = "Nhóm", TypeRef = typeof(Group))] public int GroupId { set; get; }
        [Field(Name = "Nguồn", TypeRef = typeof(Source))] public int SourceId { set; get; }
        [Field(Name = "Loại", TypeRef = typeof(Type))] public int TypeId { set; get; }
        [Field(Name = "Trạng thái")] public CusStatus Status { get; set; }
        [Field(Name = "Ghi chú"), ValidatorLength(Max = 2000, Stt = 1)] public string Description { set; get; }
        [Field(Name = "Mã KH trước")] public int TeleSaleIdCallback { get; set; }
        [Field(Name = "Đối soát")] public bool ControlDataStatus { get; set; }
        [Field(Name = "Nhà mạng"), ValidatorRequire, ValidatorDenyValue("0")] public TelecomType Telco { get; set; }
        [PropertyInfo(Name = "Khách hàng"), DataTextField(Default = "-- Khách hàng --")] public string CodeAndName => $"{Code} - {Name}";

        public int Key
        {
            set { TeleSaleId = value; }
            get { return TeleSaleId; }
        }

        [Field] public int Version { set; get; }

       
        #endregion

        public enum TelecomType : byte
        {
            [FieldInfo(Name = "-- Nhà mạng -- ")] Unknown = 0,
            [FieldInfo(Name = "Viettel")] Viettel = 1,
            [FieldInfo(Name = "Mobifone")] Mobifone = 2,
            [FieldInfo(Name = "VinaPhone")] VinaPhone = 3,
            [FieldInfo(Name = "Sfone")] Sfone = 4,
            [FieldInfo(Name = "VietNamMobile")] VietNamMobile = 5,
            [FieldInfo(Name = "Beeline")] Beeline = 6,
        }
        public enum CusStatus : int
        {
            [FieldInfo(Name = "-- Trạng thái --")] Unknown = 0,
            [FieldInfo(Name = "Khách hàng mới")] New = 1,
            [FieldInfo(Name = "Khách hàng tiềm năng")] Potential = 2,
            [FieldInfo(Name = "Khách hàng đăng ký lại")] Again = 3,

        }
        [PropertyInfo(Name = "Nhà mạng")] public string TelcoName => Telco == TelecomType.Unknown ? string.Empty : EnumHelper<TelecomType, FieldInfoAttribute>.Inst.GetAttribute(Telco).Name;
        public string TelcoNameImport { set; get; }
        [PropertyInfo(Name = "Chọn File Exel")] public string FileName { set; get; }
        [PropertyInfo(Name = "Stt")] public int Row { get; set; }
        [PropertyInfo(Name = "Tên đối tác")] public string PartnerName { get; set; }
        [PropertyInfo(Name = "Mã đối tác")] public string PartnerCode { get; set; }
        [PropertyInfo(Name = "Nhân viên gọi")] public string UserCallName { get; set; }
        [PropertyInfo(Name = "Kết quả")] public string StatusName { get; set; }
        [PropertyInfo(Name = "ColorBg")] public string ColorBg { get; set; }
        [PropertyInfo(Name = "ColorText")] public string ColorText { get; set; }
        [PropertyInfo(Name = "Đối soát")]

        public static List<Customer> GetCustomers(int companyId, int groupId, int sourceId, int typeId) => Inst.ExeStoreToList("sp_TeleSales_GetByInfos", companyId, groupId, sourceId, typeId);
        public static List<Customer> GetToSendByLogId(int companyId, int logId) => Inst.ExeStoreToList("", companyId, logId);
        public static Customer GetByUserName(string username, string password)
        {
            var data = Inst.GetAllToList();
            return data.FirstOrDefault(c => c.MemberName == username && c.Password == password);
        }
        public string ControlDataStatusName => ControlDataStatus ? LanguageHelper.GetLabel("Đã đối soát") : LanguageHelper.GetLabel("Chưa đối soát");

        /// <summary>
        /// Lấy ra TeleSale đang bị UserId đang nắm giữ mà chưa thực hiện xử lý
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static Customer GetTop1ForProcessWhenLocking(int companyId, int userId) => Inst.ExeStoreToFirst("sp_TeleSales_GetTop1ForProcess_WhenLocking", companyId, userId);

        /// <summary>
        /// Nhân viên TeleSale lấy ra một TeleSale cần xử lý đồng thời lock luôn TeleSale đó luôn
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static Customer GetTop1ForProcessAndLocking(int companyId, int userId, string permission) => Inst.ExeStoreToFirst("sp_TeleSales_GetTop1ForProcess_AndLocking", companyId, userId, permission);

        /// <summary>
        /// Người dùng lấy ra TeleSale cần xử lý
        /// Bước 1: lấy ra TeleSale mà người dùng đang xử lý (Bị lock bởi nhân viên sale đang login)
        /// Bước 2: nếu chưa có TeleSale nào đang bị giữ xử lý thì mới lấy ra một TeleSale đang có trong hệ thống mà chưa lock.
        /// Lấy ra đồng thời lock lại luôn
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static Customer GetTop1ForProcess(int companyId, int userId, string permission) => GetTop1ForProcessHelper(companyId, userId, permission).FirstOrDefault(ts => ts != null);
        public static IEnumerable<Customer> GetTop1ForProcessHelper(int companyId, int userId, string permission)
        {
            yield return GetTop1ForProcessWhenLocking(companyId, userId);
            yield return GetTop1ForProcessAndLocking(companyId, userId, permission);
        }
        [TableInfo(TableName = "[TeleSales.Logs]", Name = "Lịch sử cuộc gọi, chờ gọi lại")]
        public class Log : MainDb.Entity<Log>, IModel<int>
        {
            [Field(IsIdentity = true, IsKey = true)] public int LogId { get; set; }
            [Field(Name = "Công ty")] public int CompanyId { get; set; }
            [Field(Name = "Khách hàng")] public int CustomerId { get; set; }
            [Field(Name = "Lần gọi")] public int CurrentTime { get; set; }
            [Field(Name = "Thời gian gọi")] public DateTime? DateCall { get; set; }
            [Field(Name = "Tư vấn viên")] public int UserCallId { get; set; }
            [Field(Name = "Kết quả")] public int ResultId { get; set; }
            [Field(Name = "Nhà mạng")] public TelecomType Telco { get; set; }
            [Field(Name = "Số gọi đi")] public string PhoneMakeCall { get; set; }

            public int Key
            {
                set { LogId = value; }
                get { return LogId; }
            }

            [PropertyInfo(Name = "Stt")] public int Row { get; set; }
            [PropertyInfo(Name = "Tên khách")] public string CustomerName { get; set; }
            [PropertyInfo(Name = "Số điện thoại")] public string CustomerPhone { get; set; }
            [PropertyInfo(Name = "Nhà mạng")] public TelecomType CustomerTelco { get; set; }
            [PropertyInfo(Name = "Nhà mạng")] public string CusTelcoName => Telco == TelecomType.Unknown ? string.Empty : EnumHelper<TelecomType, FieldInfoAttribute>.Inst.GetAttribute(CustomerTelco).Name;

            [PropertyInfo(Name = "Nhân viên gọi")] public string UserCallName { get; set; }
            [PropertyInfo(Name = "Kết quả")] public string StatusName { get; set; }
            [PropertyInfo(Name = "ColorBg")] public string ColorBg { get; set; }
            [PropertyInfo(Name = "ColorText")] public string ColorText { get; set; }
            [PropertyInfo(Name = "Nhà mạng")] public string TelcoName => Telco == TelecomType.Unknown ? string.Empty : EnumHelper<TelecomType, FieldInfoAttribute>.Inst.GetAttribute(Telco).Name;


            public class DataSource : DataSource<Log>.Module, ICompanyNeedValidate
            {
                public int CompanyId { get; set; }
                public int TeleSaleId { get; set; }
                public int ResultId { get; set; }
                public int UserCallId { get; set; }
                public Customer.TelecomType Telco { get; set; }
                public override List<Log> GetEntities() => Inst.ExeStoreToList("sp_TeleSales_Logs_GetData", CompanyId, TeleSaleId, ResultId, UserCallId, Telco, Start, Length, FieldOrder, Dir);
                public override int GetTotal() => Inst.SelectFirstValue<int>("sp_TeleSales_Logs_GetData_Count", CompanyId, TeleSaleId, ResultId, UserCallId, Telco);
            }
        }

        public class DataSource : DataSource<Customer>.Module, ICompanyNeedValidate
        {
            public string Name { set; get; }
            public int CompanyId { set; get; }
            public int ViewHistory { set; get; }
            public int PartnerId { set; get; }
            public int UserCallId { set; get; }
            public int ResultId { set; get; }
            public Customer.TelecomType Telco { set; get; }
            [PropertyInfo(Name = "Từ ngày"), ValidatorRequire, ValidatorIsDate(Stt = 1)] public DateTime? FromDate { set; get; }
            [PropertyInfo(Name = "Đến ngày"), ValidatorRequire, ValidatorIsDate(Stt = 1), ValidatorDateGreater(nameof(FromDate))] public DateTime? ToDate { set; get; }

            public override List<Customer> GetEntities() => Inst.ExeStoreToList("sp_TeleSales_GetData", CompanyId, PartnerId, Name, ViewHistory, FromDate, ToDate, UserCallId, ResultId, Telco, Start, Length, FieldOrder, Dir);

            public override int GetTotal() => Inst.SelectFirstValue<int>("sp_TeleSales_GetData_Count", CompanyId, PartnerId, Name, ViewHistory, FromDate, ToDate, UserCallId, ResultId, Telco);
        }
        public class SumByResultInRangeRate
        {
            public int ResultId { set; get; }
            public string Name { set; get; }
            public string ColorBg { set; get; }
            public string ColorText { set; get; }
            public int Total { set; get; }
            public int TotalCall { set; get; }

            public static List<SumByResultInRangeRate> Get(int companyId, DateTime fromDate, DateTime toDate, int userId)
            {
                return Inst.ExeStoreToList<SumByResultInRangeRate>("sp_TeleSales_Report_GetSumByResultInRangeRate", companyId, fromDate, toDate, userId);
            }
            public static List<SumByResultInRangeRate> Get(int companyId, int month, int year, int userId)
            {
                var fromTo = year.GetRangeDateInMonth(month);
                return Get(companyId, fromTo.From, fromTo.To, userId);
            }
            public static List<SumByResultInRangeRate> GetInDay(int companyId, int userId)
            {
                return Get(companyId, DateTime.Today, DateTime.Now, userId);
            }
        }

        public static List<ChartItem<int, int>> GetSumInMonth(int companyId, int month, int year) => Inst.ExeStoreToList<ChartItem<int, int>>("sp_TeleSales_GetSumInMonthYear", companyId, month, year).FormatMonthYear(month, year);
        public void DeleteData(int companyId) => ExeStoreNoneQuery("sp_TeleSales_DeleteData", companyId);
    }
}
