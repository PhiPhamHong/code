
using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using System;
using System.Collections.Generic;
using static Core.Business.Entities.CRM.Customer;

namespace Core.Business.Entities.CRM
{
    [TableInfo(TableName = "[SMS]", Name = "Tin nhắn")]
    public class SMS : MainDb.EntityAuthor<SMS>, IModel<int>, ICompanyNeedValidate
    {
        [Field(IsKey = true, IsIdentity = true)] public int SmsId { get; set; }
        [Field(Name = "Công ty")] public int CompanyId { get; set; }
        [Field(Name = "Nội dung"), ValidatorRequire] public string Content { get; set; }
        [Field(Name = "Ghi chú")] public string Note { get; set; }
        [Field(Name = "Cấu hình gửi"), ValidatorRequire] public int ConfigId { get; set; }
        [Field(Name = "Kích hoạt")] public bool IsActive { get; set; }
        [Field(Name = "Trạng thái")] public SMSStatus Status { get; set; }
        public int Key
        {
            set { SmsId = value; }
            get { return SmsId; }
        }
        [PropertyInfo(Name = "Stt")] public int Row { get; set; }
        [PropertyInfo(Name = "Cấu hình gửi")] public string ConfigName { get; set; }
        [PropertyInfo(Name = "Trạng thái")] public string StatusString { get { return EnumHelper<SMSStatus, FieldInfoAttribute>.Inst.GetAttribute(Status).Name; } }
        public class DataSource : DataSource<SMS>.Module, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public int ConfigId { get; set; }
            public SendStatus Status { get; set; }

            public override List<SMS> GetEntities() => Inst.ExeStoreToList("sp_SMS_GetData", CompanyId, ConfigId, Status, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>("sp_SMS_GetData_Count", CompanyId, ConfigId, Status);
            
        }
    }
    public enum SMSStatus : int
    {
        [FieldInfo(Name = "-- Trạng thái --")] Unknown = 0,
        [FieldInfo(Name = "Đã xong")] Done = 1,
        [FieldInfo(Name = "Tạo mới")] New = 2
    }
}
