using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using Core.Web.WebBase.HtmlBuilders;
using System.Collections.Generic;

namespace Core.Business.Entities.ERP
{
    [TableInfo(TableName = "[BankAccounts]", Name = "Nguồn tiền quỹ")]
    public class BankAccount : MainDb.EntityAuthor<BankAccount>, IModel<int>, ICompanyNeedValidate, IEntityForLogShowName
    {
        [Field(IsKey = true, IsIdentity = true), DataValueField(Default = "0")] public int BankAccountId { get; set; }
        [Field(Name = "Công ty")] public int CompanyId { get; set; }
        [Field(Name = "Tên tài khoản"), ValidatorRequire] public string Name { get; set; }
        [Field(Name = "Ngân hàng"), ValidatorRequire] public int BankId { get; set; }
        [Field(Name = "Loại"), ValidatorRequire] public BankAccountType Type { get; set; }
        [Field(Name = "STK"), ValidatorRequire] public string STK { get; set; }
        [Field(Name = "Chi nhánh")] public string Branch { get; set; }
        [Field(Name = "Chủ tài khoản"), ValidatorRequire] public string Holder { get; set; }
        [Field(Name = "Ghi chú")] public string Note { get; set; }
        [Field(Name = "Khả dụng")] public bool IsActive { get; set; }
        public int Key { get => BankAccountId; set => BankAccountId = value; }
        [DataTextField(Default = "-- Nguồn tiền quỹ --")]
        public string FindName { get => Name + " - " + BankName + " - " + STK; }

        [PropertyInfo(Name = "Stt")] public int Row { get; set; }
        [PropertyInfo(Name = "Ngân hàng")] public string BankName { get; set; }
        [PropertyInfo(Name = "Loại tài khoản")] public string TypeString { get => EnumHelper<BankAccountType, FieldInfoAttribute>.Inst.GetAttribute(Type).Name; }

        public class DataSource : DataSource<BankAccount>.Module, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public string Name { get; set; }
            public BankAccountType Type { get; set; }
            public override List<BankAccount> GetEntities() => Inst.ExeStoreToList("sp_Bank_Accounts_GetData", CompanyId, Name, Type, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => CurrentData.Count;
        }
    }
    public enum BankAccountType : int
    {
        [FieldInfo(Name = "-- Loại tài khoản --")] Unknown = 0,
        [FieldInfo(Name = "Tài khoản công ty")] Company = 1,
        [FieldInfo(Name = "Tài khoản cá nhân")] Personal = 2
    }
}
