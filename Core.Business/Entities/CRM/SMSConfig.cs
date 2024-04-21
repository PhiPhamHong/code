using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using Core.Web.WebBase.HtmlBuilders;
using System;
using System.Collections.Generic;

namespace Core.Business.Entities.CRM
{
    [TableInfo(TableName = "[SMS.Configs]", Name = "Cấu hình SMS")]
    public class SMSConfig : MainDb.EntityAuthor<SMSConfig>, IModel<int>, ICompanyNeedValidate
    {
        [Field(IsIdentity = true, IsKey=true), DataValueField(Default = "0")] public int ConfigId { get; set; }
        [Field(Name = "Công ty")] public int CompanyId { get; set; }
        [Field(Name = "Loại tin"), ValidatorRequire] public SMSType Type { get; set; }
        [PropertyInfo(Name = "Loại tin")] public string TypeString { get { return EnumHelper<SMSType, FieldInfoAttribute>.Inst.GetAttribute(Type).Name; } }
        [Field(Name = "Code"), ValidatorRequire, DataTextField(Default = "-- Cấu hình gửi --")] public string Code { get; set; }
        [Field(Name = "Thời gian áp dụng từ "), ValidatorRequire] public DateTime? FromDate { get; set; }
        [Field(Name = "Đến"), ValidatorRequire, ValidatorDateGreater("FromDate",Stt = 2)] public DateTime? ToDate { get; set; }
        [Field(Name = "(Max)SMS/Ngày"), ValidatorRequire] public int MaxInday { get; set; }
        [Field(Name = "Loại hình"), ValidatorRequire] public SendTypeEnum SendType { get; set; }
        [Field(Name = "Khung giờ"), ValidatorRequire] public TimeSpanEnum TimeSpan { get; set; }
        #region Lịch cố định
        [Field(Name = "Thứ 2")] public bool Monday { get; set; }
        [Field(Name = "Thứ 3")] public bool Tuesday { get; set; }
        [Field(Name = "Thứ 4")] public bool Wednesday { get; set; }
        [Field(Name = "Thứ 5")] public bool Thursday { get; set; }
        [Field(Name = "Thứ 6")] public bool Friday { get; set; }
        [Field(Name = "Thứ 7")] public bool Saturday { get; set; }
        [Field(Name = "Chủ nhật")] public bool Sunday { get; set; }
        #endregion
        #region Tin gửi 1 lần
        [Field(Name = "Thời gian gửi")] public DateTime DateNeedSend { get; set; }
        #endregion
        [Field(Name = "Đối tượng gửi"), ValidatorRequire] public TargetSend TargetId { get; set; } //Gồm 2 loại : Là khách hàng mới đăng ký và chưa đối soát, KH đã được đối soát(KH đã mua hàng hoặc chắc chắn sẽ mua)
        #region Khách hàng đã được đối xoát
        [Field(Name = "Nguồn khách")] public int SourceId { get; set; }
        [Field(Name = "Nhóm khách")] public int GroupId { get; set; }
        [Field(Name = "Loại khách")] public int TypeId { get; set; }
        #endregion
        [Field(Name = "Quản lý"), ValidatorRequire] public int ManagerId { get; set; }
        [PropertyInfo(Name = "Đối tượng gửi")] public string TargetString { get { return EnumHelper<TargetSend, FieldInfoAttribute>.Inst.GetAttribute(TargetId).Name; } }
        [PropertyInfo(Name = "Loại hình")] public string SendTypeString { get { return EnumHelper<SendTypeEnum, FieldInfoAttribute>.Inst.GetAttribute(SendType).Name; } }
        [PropertyInfo(Name = "Khung giờ")] public string TimeSpanString { get { return EnumHelper<TimeSpanEnum, FieldInfoAttribute>.Inst.GetAttribute(TimeSpan).Name; } }
        public int Key
        {
            set { ConfigId = value; }
            get { return ConfigId; }
        }
        [PropertyInfo(Name = "Stt")] public int Row { get; set; }
        [PropertyInfo(Name = "Người phụ trách")] public string ManagerName { get; set; }
        public class DataSource : DataSource<SMSConfig>.Module, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public int ManagerId { get; set; }
            public SendTypeEnum SendType { get; set; }
            public TimeSpanEnum TimeSpan { get; set; }
            public TargetSend TargetId { get; set; }
            public override List<SMSConfig> GetEntities() => Inst.ExeStoreToList("sp_SMSConfigs_GetData", CompanyId, ManagerId, SendType, TimeSpan, TargetId, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => CurrentData.Count;
        }
    }
    public enum TimeSpanEnum : int
    {
        [FieldInfo(Name = "-- Khung giờ gửi --")] Unknown = 0,
        [FieldInfo(Name = "Cả ngày (8h - 22h)")] Both = 1,
        [FieldInfo(Name = "Sáng(8h- 12h)")] Morning = 2,
        [FieldInfo(Name = "Chiều(12h - 17h)")] Afternoon = 3,
        [FieldInfo(Name = "Tối(17h - 22h)")] Evening = 4
    }
    public enum SMSType : int
    {
        [FieldInfo(Name = "-- Loại tin --")] Unknown = 0,
        [FieldInfo(Name = "Quảng cáo")] QC = 1,
        [FieldInfo(Name = "Thông báo")] TB = 2,
        [FieldInfo(Name = "Khuyến mại")] KM = 3,
        [FieldInfo(Name = "Cảnh báo")] CB = 4
    }
}
