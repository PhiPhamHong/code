using Core.Attributes;
using Core.Attributes.Validators;
using Core.Business.Enums;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using System;
using System.Collections.Generic;


namespace Core.Business.Entities.CRM
{
    public partial class Partner
    {
        [TableInfo(TableName = "[Partners.Contacts]", Name = "Liên hệ")]
        public class Contact : MainDb.EntityAuthor<Contact>, IModel<int>, ICompanyNeedValidate, IEntityForLogShowName
        {
            #region Properties
            [Field(IsKey = true, IsIdentity = true)] public int ContactId { set; get; }
            [Field(Name = "Công ty")] public int CompanyId { set; get; }
            [Field(Name = "Đối tác", TypeRef = typeof(Partner))] public int PartnerId { set; get; }
            [Field(Name = "Họ và tên"), ValidatorRequire, ValidatorLength(Max = 300, Stt = 1)] public string FullName { set; get; }
            [Field(Name = "Giới tính")] public Gender Gender { set; get; }
            [Field(Name = "Hotline"), ValidatorLength(Max = 50, Stt = 1), ValidatorPhoneNumber] public string Phone1 { set; get; }
            [Field(Name = "Điện thoại"), ValidatorLength(Max = 30, Stt = 1), ValidatorPhoneNumber] public string Phone2 { set; get; }
            [Field(Name = "Điện thoại"), ValidatorLength(Max = 30, Stt = 1), ValidatorPhoneNumber] public string Phone3 { set; get; }
            [Field(Name = "Email"), ValidatorLength(Max = 100, Stt = 1), ValidatorEmail] public string Email { set; get; }
            [Field(Name = "Facebook"), ValidatorLength(Max = 100, Stt = 1)] public string Facebook { set; get; }
            [Field(Name = "Skype"), ValidatorLength(Max = 50, Stt = 1)] public string Skype { set; get; }
            [Field(Name = "Ngày sinh")] public DateTime? Birthday { set; get; }
            [Field(Name = "Xưng hô")] public Salutation Salutation { set; get; }
            public int Key
            {
                set { ContactId = value; }
                get { return ContactId; }
            }

            public string Name => FullName;
            #endregion

            [PropertyInfo(Name = "Đối tác")] public string PartnerName { get; set; }
            [PropertyInfo(Name = "Giới tính")] public string GenderName => EnumHelper<Gender, FieldInfoAttribute>.Inst.GetAttribute(Gender).Name;
            [PropertyInfo(Name = "Danh xưng")] public string SalutationName => EnumHelper<Salutation, FieldInfoAttribute>.Inst.GetAttribute(Salutation).Name;
            [PropertyInfo(Name = "Stt")] public int Row { get; set; }
            [Field] public int Version { set; get; }

            public class DataSource : DataSource<Contact>.Module, ICompanyNeedValidate
            {
                public int CompanyId { set; get; }
                public int PartnerId { get; set; }
                public string Name { get; set; }
                
                public override List<Contact> GetEntities() => Inst.ExeStoreToList("sp_Partners_Contacts_GetData", CompanyId, PartnerId, Name, Start, Length, FieldOrder, Dir);
                public override int GetTotal() => Inst.SelectFirstValue<int>("sp_Partners_Contacts_GetData_Count", CompanyId, PartnerId, Name);

            } 
        }
    }
}
