using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Extensions;
using Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Business.Entities.CRM
{
    [TableInfo(TableName = "[CRM.Transactions]", Name = "Lịch chăm sóc khách hàng")]
    public partial class Transaction : Transaction<Transaction>, IModel<int>, ICompanyNeedValidate
    {
        [Field(IsKey = true, IsIdentity = true)] public override int TransactionId { set; get; }
        [Field(Name = "Ngày báo trước")] public int? NotifyBeforeDays { set; get; }
        [Field(Name = "Gửi email")] public bool SendMail { set; get; }
        [Field(Name = "Gửi tin nhắn")] public bool SendSms { set; get; }
        [Field(Name = "Nội dung tin nhắn")] public string SmsContent { set; get; }
        [Field(Name = "Gửi email lỗi sau (phút)")] public int? SendEmailAgainWhenFailAfter { set; get; }
        [Field(Name = "Dừng gửi email sau (lần) gửi lỗi")] public int? StopSendEmailAgainWhenTotalFail { set; get; }
        [Field(Name = "Gửi email nếu không phản hồi sau(phút)")] public int? SendEmailAgainWhenUserNotConfirmAfter { set; get; }
        [Field(Name = "Dừng email sau không phản hồi")] public int? StopSendEmailAgainWhenTotalSendNotConfirm { set; get; }
        [Field(Name = "Cấu hình gửi")] public SendEmailWhenTimeEnum SendEmailWhenTime { set; get; }

        public int Key
        {
            get { return TransactionId; }
            set { TransactionId = value; }
        }


        public class DataSource : DataSource<Transaction>.Module,ICompanyNeedValidate
        {
            public int CompanyId { set; get; }
            public int PartnerId { set; get; }
            public int TeleSaleId { set; get; }
            public int TransactionTypeId { set; get; }
            public int TransactionStatusId { set; get; }
            public int PrioritizeId { set; get; }
            public string Name { set; get; }
            public Transaction.DateFieldSearch DateFieldSearch { set; get; }
            public DateTime? StartTime { set; get; }
            public DateTime? EndTime { set; get; }
            public int UserManageId { get; set; }
            public int UserId { get; set; }
            public int UserFind { get; set; }
            public Transaction.UserTypeEnum UserTypeEnum { set; get; }
            public string DateFieldSearchName { get; set; }
            public override List<Transaction> GetEntities() => Inst.ExeStoreToList("sp_CRM_Transactions_GetData", CompanyId, PartnerId, TeleSaleId, TransactionTypeId, TransactionStatusId, PrioritizeId, Name, StartTime, EndTime, DateFieldSearchName, true, UserTypeEnum, UserManageId, UserFind, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>("sp_CRM_Transactions_GetData_Count", CompanyId, PartnerId, TeleSaleId, TransactionTypeId, TransactionStatusId, PrioritizeId, Name, StartTime, EndTime, DateFieldSearchName, true, UserTypeEnum, UserManageId, UserFind);
        }
        public static List<Transaction> GetTransactions()
        {
            return Inst.ExeStoreToList("sp_CRM_Transactions_GetUnfinished");
        }
    }
    public abstract class Transaction<T> : MainDb.EntityAuthor<T>, IEntityForLogShowName where T : ModelBase, new()
    {
        [Field] public virtual int TransactionId { set; get; }
        [Field(Name = "Công ty")] public int CompanyId { set; get; }
        [Field(Name = "Tiêu đề"), ValidatorRequire] public string Name { set; get; }
        [Field(Name = "Nhóm"), ValidatorRequire] public TranTypeEnum TranType { get; set; } 
        [Field(Name = "Đại lý/khách")] public int PartnerId { set; get; }
        [Field(Name = "Khách hàng")] public int TeleSaleId { get; set; }
        [Field(Name = "Nội dung")] public string Description { set; get; }
        [Field(Name = "Kết quả")] public string Result { set; get; }
        [Field(Name = "Bắt đầu"), ValidatorRequire, ValidatorIsDate] public DateTime? StartTime { set; get; }
        [Field(Name = "Kết thúc"), ValidatorDateGreater("StartTime")] public DateTime? EndTime { set; get; }
        [Field(Name = "Thời gian")] public DateTime? DoneEndTime { set; get; }
        [Field(Name = "Loại", TypeRef = typeof(Transaction.Type))] public int TransactionTypeId { set; get; }
        [Field(Name = "Trạng thái", TypeRef = typeof(Transaction.Status))] public int TransactionStatusId { set; get; }
        [Field(Name = "Mức độ", TypeRef = typeof(Transaction.Prioritize))] public int PrioritizeId { set; get; }
        [Field(Name = "Người phụ trách", TypeRef = typeof(User))] public string User_PersonCharges { set; get; }
        [Field(Name = "Người thực hiện", TypeRef = typeof(User))] public string User_Workers { set; get; }
        [Field(Name = "Chia sẻ", TypeRef = typeof(User))] public string User_Shareds { set; get; }
        [Field(Name = "Chất lượng")] public string Comment { set; get; }
        [Field(Name = "Nhận xét")] public int Comment_Status { set; get; }
        [Field(Name = "Ghi chú")] public string Commnet_Des { set; get; }

        public int UserId { get; set; }
        #region Left Join
        [PropertyInfo(Name = "Khách hàng")] public string PartnerName { set; get; }
        [PropertyInfo(Name = "Loại")] public string TypeName { set; get; }
        [PropertyInfo(Name = "Trạng thái")] public string StatusName { set; get; }
        public string StatusColor { set; get; }
        public string StatusTextColor { set; get; }
        [PropertyInfo(Name = "Độ ưu tiên")] public string PrioritizeName { set; get; }
        public string PrioritizeColor { set; get; }
        public string PrioritizeTextColor { set; get; }
        [PropertyInfo(Name = "Nhận xét")] public string CommentStatusName { set; get; }

        [PropertyInfo(Name = "Người thực hiện")]
        public string User_Workers_String { get { return User.GetByUserIds(User_Workers).Select(u => u.UserName).JoinString(u => u); } }

        #endregion

        [PropertyInfo(Name = "Stt")]
        public int Row { set; get; }

        [Field(Name = "Loại công việc"), ValidatorDenyValue(0)] public WorkType TypeWork { set; get; }

        [PropertyInfo(Name = "Loại công việc")] 
        public string TypeWork_String { get { return TypeWork != WorkType.A ? EnumHelper<WorkType, FieldInfoAttribute>.Inst.GetAttribute(TypeWork).Name : ""; } }

        [Field(Name = "Khó khăn")] public string Hards { set; get; }
        [Field(Name = "Phương án")] public string Plans { set; get; }
        [Field(Name = "Người đánh giá")] public int Comment_UserId { set; get; }

        [PropertyInfo(Name = "Người đánh giá")] 
        public string Comment_UserName { get { return User.GetByUserIds(Comment_UserId.ToString()).Select(u => u.UserName).JoinString(u => u); } }

        [Field(Name = "Thời gian tiêu tốn")] public string TimeWorkHour { set; get; }

        #region Enum
        public enum WorkType : byte
        {
            [FieldInfo(Name = "-- Loại công việc --")]
            A = 0,
            [FieldInfo(Name = "Công việc")]
            B = 1,
            [FieldInfo(Name = "Đề xuất, Hỗ Trợ")]
            C = 2,
            [FieldInfo(Name = "Những lỗi gặp phải")]
            D = 3
        }
        public enum SendEmailWhenTimeEnum : byte
        {
            [FieldInfo(Name = "Gửi cảnh báo trước khi giao dịch bắt đầu")]
            SendBeforeStartTime = 0,
            [FieldInfo(Name = "Gửi cảnh báo cho đến khi giao dịch kết thúc")]
            SendBeforeEndTime = 1
        }
        
        public enum UserTypeEnum : byte
        {
            [FieldInfo(Name = "-- Trách nhiệm theo dõi --")] Unknown = 0,
            [FieldInfo(Name = "Phụ trách")] PersonCharge = 1, // Người phụ trách
            [FieldInfo(Name = "Thực hiện")] Worker = 2,       // Người thực hiện công việc
            [FieldInfo(Name = "Được chia sẻ")] Shared = 3,    // Người được chia sẻ
        }
        public enum DateFieldSearch
        {
            [FieldInfo(Name = "Tìm theo ngày tạo")] SearchByCreatedDate = 0, // CreatedDate
            [FieldInfo(Name = "Tìm theo ngày bắt đầu")] SearchByStartTime = 1, // StartTime
            [FieldInfo(Name = "Tìm theo ngày kết thúc")] SearchByEndTime = 2,       // EndTime
            [FieldInfo(Name = "Tìm theo ngày hoàn thành")] SearchByDoneEndTime = 3,    // DoneEndTime
        }
        #endregion
    }

    public enum TranTypeEnum : int
    {
        [FieldInfo(Name = "Đại lý")] Partner = 0,
        [FieldInfo(Name = "Khách hàng")] Cus = 1
    }

}