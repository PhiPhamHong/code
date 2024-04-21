using Core.Attributes;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using Core.Web.WebBase.HtmlBuilders;
using System;
using System.Collections.Generic;
using static Core.Business.Entities.CRM.Customer;

namespace Core.Business.Entities.CRM
{
    [TableInfo(TableName = "[SMS_Email.Sent.Logs]", Name = "Lịch sử gửi tin")]
    public class SendLog : MainDb.Entity<SendLog>, IModel<int>, ICompanyNeedValidate
    {
        [Field(IsKey = true, IsIdentity = true), DataValueField(Default = "0")] public int LogId { get; set; }
        [Field(Name = "Công ty")] public int CompanyId { get; set; }
        [Field(Name = "Log Code"), DataTextField(Default = "-- Lịch sử gửi SMS/Email --")] public string Code { get; set; } 
        [Field(Name = "Loại hình")] public SendType Type { get; set; } //Có 2 loại là SMS và Email
        [Field(Name = "Thời gian gửi")] public DateTime? SentDate { get; set; }

        #region SMS
        [Field(Name = "Tin nhắn")] public int SmsId { get; set; }
        [Field(Name = "Phương thức")] public SMSMethodSend SMSMethod { get; set; } //SMS normal and SMS Brandname
        [Field(Name = "SDT")] public string FromPhone { get; set; }
        [Field(Name = "Nhà mạng")] public TelecomType Telco { get; set; }
        [Field(Name = "API Brandname")] public string Brandname { get; set; }
        #endregion
        #region Email
        [Field(Name = "Email")] public int EmailId { get; set; }
        [Field(Name = "Phương thức")] public EmailMethodSend EmailMethod { get; set; } // Google or SendGrid
        [Field(Name = "Email gửi")] public string FromEmail { get; set; }
        #endregion

        [Field(Name = "Tổng cần gửi")] public int TotalNeedSend { get; set; }
        [Field(Name = "Tổng đã gửi")] public int TotalSend { get; set; }
        [Field(Name = "Trạng thái")] public LogStatus Status { get; set; }
        public int Key
        {
            set { LogId = value; }
            get { return LogId; }
        }
        public string SMSContent { get; set; }
        public string MailContent { get; set; }
        [PropertyInfo(Name = "Nội dung")]  public string Content { get { return Type == SendType.Email ? MailContent : SMSContent; } }
        [PropertyInfo(Name = "Người gửi")] public string SendPerson { get { return "Hệ thống"; } }

        [PropertyInfo(Name = "Khách hàng")] public int CusId { get; set; }

        [PropertyInfo(Name = "Stt")] public int Row { get; set; }
        [PropertyInfo(Name = "Loại hình")] public string TypeString { get { return EnumHelper<SendType, FieldInfoAttribute>.Inst.GetAttribute(Type).Name; } }
        [PropertyInfo(Name = "Phương thức")] public string SMSMethodString { get { return EnumHelper<SMSMethodSend, FieldInfoAttribute>.Inst.GetAttribute(SMSMethod).Name; } }
        [PropertyInfo(Name = "Phương thức")] public string EmailMethodString { get { return EnumHelper<EmailMethodSend, FieldInfoAttribute>.Inst.GetAttribute(EmailMethod).Name; } }

        #region Method
        public class DataSource : DataSource<SendLog>.Module, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public SendType Type { get; set; }
            public DateTime? StartTime { get; set; }
            public DateTime? EndTime { get; set; }
            public override List<SendLog> GetEntities() => Inst.ExeStoreToList("sp_SMS_Email_Sent_Logs_GetData", CompanyId, Type, StartTime, EndTime, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>("sp_SMS_Email_Sent_Logs_GetData_Count", CompanyId, Type, StartTime, EndTime);
            
        }
        public static List<SendLog> GetLogByCusIds(int companyId, int customerId) => Inst.ExeStoreToList("sp_SMS_Email_Sent_Logs_GetbyCusId", companyId, customerId);
        public static SendLog GetByEmailId(int companyId, int emailId) => Inst.ExeStoreToFirst("sp_SendLogs_FindByEmailId", companyId, emailId);
        public static List<SendLog> GetToSends(int companyId) => Inst.ExeStoreToList("sp_SMS_EMail_Logs_GetToSend", companyId);
        public static void UpdateLog(int companyId, int logId, int tolalSend) => Inst.ExeStoreNoneQuery("sp_SMS_EMail_Logs_UpdateInfo", companyId, logId, tolalSend);
        #endregion


        [TableInfo(TableName = "[SMS_Email.Sent.Log.Details]", Name = "Chi tiết lịch sử gửi tin")]
        public class Detail : MainDb.Entity<Detail>,IModel<int>, ICompanyNeedValidate
        {
            [Field(IsKey = true, IsIdentity = true)] public int DetailId { get; set; }
            [Field(Name = "Công ty")] public int CompanyId { get; set; }
            [Field(Name = "Lịch sử")] public int LogId { get; set; }
            [Field(Name = "Gửi đến")] public int CustomerId { get; set; }
            [Field(Name = "Thời gian gửi")] public DateTime? SentTime { get; set; }
            [Field(Name = "Trạng thái")] public SendStatus Status { get; set; }
            [Field(Name = "Error")] public string MsgError { get; set; }
            [Field(Name = "Tổng đã gửi")] public int TotalSend { get; set; }
            [Field(Name = "Thời gian ghi log")] public DateTime? LogTime { get; set; }
            public int Key
            {
                set { DetailId = value; }
                get { return DetailId; }
            }
            public class DataSource : DataSource<Detail>.Module, ICompanyNeedValidate
            {
                public int CompanyId { get; set; }
                public int LogId { get; set; }
                public int TeleSaleId { get; set; }
                public override List<Detail> GetEntities() => Inst.ExeStoreToList("sp_SMS_Email_Sent_Log_Detail_GetData", CompanyId, LogId, TeleSaleId, Start, Length, FieldOrder, Dir);
                public override int GetTotal() => Inst.SelectFirstValue<int>("sp_SMS_Email_Sent_Log_Detail_GetData_Count", CompanyId, LogId, TeleSaleId);
            }
            [PropertyInfo(Name = "Stt")] public int Row { get; set; }
            [PropertyInfo(Name = "Log Code")] public string Code { get; set; }
            [PropertyInfo(Name = "Gửi đến khách")] public string CusName { get; set; }
            [PropertyInfo(Name = "Email nhận")] public string CusMail { get; set; }
            [PropertyInfo(Name = "Trạng thái")] public string StatusString { get { return EnumHelper<SendStatus, FieldInfoAttribute>.Inst.GetAttribute(Status).Name; } }


            public static List<Detail> GetByLogId(int companyId, int logId) => Inst.ExeStoreToList("sp_SMS_EMail_Log_Details_GetToSendByLogId", companyId, logId);
            public static void UpdateLogDetail(int detailId, SendStatus status, int totalsend, string error) => Inst.ExeStoreNoneQuery("sp_SMS_EMail_Log_Details_UpdateInfo", detailId, status, totalsend, error);
        }
    }
    public enum SendType : int
    {
        [FieldInfo(Name = "-- Loại hình --")] Unknown = 0,
        [FieldInfo(Name = "Gửi Email")] Email = 1,
        [FieldInfo(Name = "Gửi SMS")] SMS = 2
    }
    public enum SMSMethodSend : int
    {
        [FieldInfo(Name = "-- Phương thức --")] Unknown = 0,
        [FieldInfo(Name = "Gửi qua SIM")] SIM = 1,
        [FieldInfo(Name = "Gửi qua SMS Brandname")] BRANDNAME = 2
    }
    public enum EmailMethodSend : int
    {
        [FieldInfo(Name = "-- Phương thức --")] Unknown = 0,
        [FieldInfo(Name = "Gửi qua Google Mail")] GGMail = 1,
        [FieldInfo(Name = "Gửi qua SendGrid")] SendGrid = 2
    }
    public enum SendStatus : int
    {
        [FieldInfo(Name = "-- Trạng thái --")] Unknown = 0,
        [FieldInfo(Name = "Thành công")] Success = 1,
        [FieldInfo(Name = "Thất bại")] Fail = 2
    }
    public enum LogStatus : int
    {
        [FieldInfo(Name = "-- Trạng thái --")] Unknown = 0,
        [FieldInfo(Name = "Tạo mới")] New = 1,
        [FieldInfo(Name = "Đang gửi")] InProcess = 2,
        [FieldInfo(Name = "Đã xong")] Done = 3,
    }
    
}
