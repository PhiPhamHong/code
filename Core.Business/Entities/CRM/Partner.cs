using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using Core.Utility.Language;
using Core.Web.WebBase.HtmlBuilders;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Core.Business.Entities.CRM
{
    [TableInfo(TableName = "[Partners]", Name = "Đối tác")]
    public partial class Partner : MainDb.EntityAuthor<Partner>, IModel<int>, ICompanyNeedValidate, IEntityForLogShowName
    {
        #region Properties
        [Field(IsKey = true, IsIdentity = true), DataValueField(Default = "0")] public int PartnerId { set; get; }
        [Field(Name = "Công ty")] public int CompanyId { set; get; }
        [Field(Name = "Đối tác"), ValidatorRequire, ValidatorLength(Max = 300, Stt = 1)] public string Name { set; get; }
        [Field(Name = "Mã đối tác"), ValidatorRequire, ValidatorLength(Max = 50, Stt = 1)] public string Code { set; get; }
        [Field(Name = "Khách hàng")] public bool IsCustomer { set; get; }
        [Field(Name = "Nhà cung cấp")] public bool IsSupplier { set; get; }
        [Field(Name = "Địa chỉ"), ValidatorLength(Max = 300, Stt = 1)] public string Address { set; get; }
        [Field(Name = "Điện thoại"), ValidatorLength(Max = 30, Stt = 1), ValidatorPhoneNumber] public string Phone { set; get; }
        [Field(Name = "Email"), ValidatorEmail, ValidatorLength(Max = 500, Stt = 1)] public string Email { set; get; }
        [Field(Name = "Mã số thuế"), ValidatorLength(Max = 20, Stt = 1)] public string TaxCode { set; get; }
        [Field(Name = "Tên công ty"), ValidatorLength(Max = 100, Stt = 1)] public string CompanyName { set; get; }
        [Field(Name = "Người liên hệ"), ValidatorLength(Max = 100, Stt = 1)] public string ContactName { set; get; }
        [Field(Name = "Ghi chú"), ValidatorLength(Max = 2000, Stt = 1)] public string Description { set; get; }
        [Field(Name = "Quản lý"), ValidatorLength(Max = 500, Stt = 1)] public string ManageUserIds { set; get; }
        [Field(Name = "Công nợ"), ValidatorLength(Max = 500, Stt = 1)] public string DebtUserIds { set; get; }
        [Field(Name = "Marketing"), ValidatorLength(Max = 500, Stt = 1)] public string FoundByUserIds { set; get; }
        [Field(Name = "Nhóm", TypeRef = typeof(Group))] public int GroupId { set; get; }
        [Field(Name = "Nguồn", TypeRef = typeof(Source))] public int SourceId { set; get; }
        [Field(Name = "Loại", TypeRef = typeof(Type))] public int TypeId { set; get; }
        [Field(Name = "Người đại diện"), ValidatorLength(Max = 300)] public string Deputy { set; get; }
        [Field(Name = "Ngày thành lập")] public DateTime? Anniversary { set; get; }
        [Field(Name = "Hiển thị")] public bool IsShow { get; set; }
        [Field(Name = "Logo")] public string Logo { get; set; }
        [Field(Name = "Đường dẫn")] public string Alias { get; set; } // giờ méo cần.
        [Field(Name = "Dư nợ đầu")] public decimal Residual { get; set; }
        [Field(Name = "Loại tiền")] public int ResCurrencyId { get; set; }
        [Field(Name = "Tỷ giá")] public decimal ResExchangeRate { get; set; }
        public int Key
        {
            set { PartnerId = value; }
            get { return PartnerId; }
        }
        #endregion

        [PropertyInfo(Name = "Khách hàng"), DataTextField(Default = "-- Đại lý/khách --")] public string CodeAndName => $"{Code} - {Name}";
        [PropertyInfo(Name = "Stt")] public int Row { get; set; }
        [PropertyInfo(Name = "Nguồn")] public string SourcetName { get; set; }
        [PropertyInfo(Name = "Nhóm")] public string GrouptName { get; set; }
        [PropertyInfo(Name = "Loại")] public string TypeName { get; set; }

        public class DataSource : DataSource<Partner>.Module, ICompanyNeedValidate
        {
            public int CompanyId { set; get; }
            public string Name { get; set; }
            public Partner.TypeView TypeView { set; get; }
            public Partner.User.Type UserType { set; get; }
            public int? UserId { set; get; }
            public int SourceId { set; get; }
            public int GroupId { set; get; }
            public int TypeId { set; get; }
            public int UserIdForFind { get; set; }
            public override List<Partner> GetEntities() => Inst.ExeStoreToList("sp_Partners_GetData", CompanyId, Name, UserId, UserIdForFind, TypeView, UserType, SourceId, GroupId, TypeId, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>("sp_Partners_GetData_Count", CompanyId, Name, UserId, UserIdForFind, TypeView, UserType, SourceId, GroupId, TypeId);

        }
        public static Partner GetByPartnerId(int partnerId)
        {
            var partner = new Partner { PartnerId = partnerId };
            partner.GetByKey();
            return partner;
        }

        public static List<Partner> GetByCompanyId(int companyId) => Inst.ExeStoreToList("sp_Partners_GetByCompanyId", companyId);

        [PropertyInfo(Name = "Khách hàng")] public string IsCustomerName => IsCustomer == false ? string.Empty : LanguageHelper.GetLabel("Khách hàng");
        [PropertyInfo(Name = "Nhà cung cấp")] public string IsSupplierName => IsSupplier == false ? string.Empty : LanguageHelper.GetLabel("Nhà cung cấp");

        [Field] public int Version { set; get; }

        public enum TypeView : byte
        {
            [FieldInfo(Name = "-- Loại đối tác --")] All = 0,
            [FieldInfo(Name = "Khách hàng")] Customer = 1,
            [FieldInfo(Name = "Nhà cung cấp")] Supplier = 2
        }

        public class IdAndName
        {
            public int PartnerId { set; get; }
            public string Name { set; get; }
        }
    }
}
