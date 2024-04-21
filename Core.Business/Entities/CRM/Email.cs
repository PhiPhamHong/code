using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using System;
using System.Collections.Generic;

namespace Core.Business.Entities.CRM
{
    [TableInfo(TableName = "[Emails]",Name = "Cấu hình Email")]
    public class Email : MainDb.EntityAuthor<Email>, IModel<int>, ICompanyNeedValidate
    {
        [Field(IsIdentity = true, IsKey = true)] public int EmailId { get; set; }
        [Field(Name = "Công ty")] public int CompanyId { get; set; }
        [Field(Name = "Loại hình"), ValidatorRequire] public SendTypeEnum SendType { get; set; } //Gồm 2 loại: là lịch cố định hoặc gửi 1 lần
        [PropertyInfo(Name = "Loại hình")] public string SendTypeString { get { return EnumHelper<SendTypeEnum, FieldInfoAttribute>.Inst.GetAttribute(SendType).Name; } }
        #region Lịch cố định
        [Field(Name = "Ngày")] public int Day { get; set; }
        [Field(Name = "Tháng")] public int Month { get; set; }
        #endregion
        #region Email gửi 1 lần
        [Field(Name = "Ngày gửi")] public DateTime DateNeedSend { get; set; }
        #endregion

        [Field(Name = "Đối tượng"), ValidatorRequire] public TargetSend TargetId { get; set; } //Gồm 2 loại : Là khách hàng mới đăng ký và chưa đối soát, KH đã được đối soát(KH đã mua hàng hoặc chắc chắn sẽ mua)
        [PropertyInfo(Name = "Đối tượng gửi")] public string TargetString { get { return EnumHelper<TargetSend, FieldInfoAttribute>.Inst.GetAttribute(TargetId).Name; } }
        #region Khách hàng đã được đối xoát
        [Field(Name = "Nguồn khách")] public int SourceId { get; set; }
        [Field(Name = "Nhóm khách")] public int GroupId { get; set; }
        [Field(Name = "Loại khách")] public int TypeId { get; set; }
        #endregion

        [Field(Name = "Quản lý"), ValidatorRequire] public int ManagerId { get; set; }
        [Field(Name = "Tiêu đề"), ValidatorRequire] public string Title { get; set; }
        [Field(Name = "Nội dung"), ValidatorRequire] public string Content { get; set; }
        public int Key
        {
            set { EmailId = value; }
            get { return EmailId; }
        }
        [PropertyInfo(Name = "Stt")] public int Row { get; set; }
        [PropertyInfo(Name = "Người phụ trách")] public string ManagerName { get; set; }
        public class DataSource : DataSource<Email>.Module, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public int ManagerId { get; set; }
            public string Title { get; set; }
            public SendTypeEnum SendType { get; set; }
            public TargetSend TargetId { get; set; }

            public override List<Email> GetEntities() => Inst.ExeStoreToList("sp_Emails_GetData", CompanyId, ManagerId, Title, SendType, TargetId, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => CurrentData.Count;
            
        }

        #region Method dùng cho Worker
        public static List<Email> GetEmails(int CompanyId) => Inst.ExeStoreToList("sp_Emails_GetNeedSend", CompanyId);
        
        #endregion
    }


    public enum TargetSend : int
    {
        [FieldInfo(Name = "-- Đối tượng gửi --")] Unknown = 0,
        [FieldInfo(Name = "Khách hàng hệ thống(Đã đối soát)")] System = 1,
        [FieldInfo(Name = "Khách mới đăng ký(Chưa đối soát)")] New = 2
    }
    public enum SendTypeEnum : int
    {
        [FieldInfo(Name = "-- Loại hình --")] Unknown = 0,
        [FieldInfo(Name = "Lịch gửi cố định")] Const = 1,
        [FieldInfo(Name = "Gửi 1 lần")] JustOne = 2
    }
}
