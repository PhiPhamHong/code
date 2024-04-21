using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Extensions;
using Core.Utility;
using Core.Utility.Trees;
using Core.Web.WebBase.HtmlBuilders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Business.Entities.ERP
{
    [TableInfo(TableName = "[Accounts]", Name = "Tài khoản kế toán")]
    public class Account : MainDb.EntityAuthor<Account>, IModel<int>, IEntityForLogShowName, ITreeItem, ICompanyNeedValidate
    {
        [Field(IsKey = true, IsIdentity = true), DataValueField(Default = "0")] public int AccountId { set; get; }
        [Field(Name = "Công ty")] public int CompanyId { set; get; }
        [Field(Name = "Tên tài khoản"), ValidatorRequire] public string Name { set; get; }
        [Field(Name = "Mã tài khoản"), ValidatorRequire] public string Code { set; get; }
        [Field(Name = "Ngày chốt")] public DateTime? ClosingDate { get; set; }
        [Field(Name = "Tài khoản cha")] public int ParentId { get; set; }
        [Field(Name = "Mô tả")] public string Description { set; get; }
        [Field(Name = "Tính chi phí")] public bool IsCost { set; get; }
        [Field(Name = "Mã gợi nhớ")] public string Alias { set; get; }
        [Field(Name = "Hệ thống")] public bool IsSystem { set; get; }
        [Field(Name = "Thông tư")] public AccountType AccountType { set; get; }
        [Field(Name = "Nợ đầu kỳ")] public decimal? Begin_Debt { get; set; } //Số nợ còn lại từ lần chốt số gần nhất ( > 0 nếu lỗ) = 0 khi tạo mới
        [Field(Name = "Số dư đầu kỳ")] public decimal? Begin_Residual { get; set; } //Số tiền lãi dư ra tính từ lần chốt số gần nhất ( > 0 nếu có dư) = 0 khi tạo mới
        [Field(Name = "Phát sinh")] public decimal? Acctual_Debt { get; set; } //Nợ phát sinh tính từ lần chốt sổ gần nhất sẽ tăng dần khi mà có phiếu chi lập lên (Khi chốt sổ được set lại về 0)
        [Field(Name = "Phát sinh")] public decimal? Acctual_Residual { get; set; } // Số dư cộng lên tính từ lần chốt sổ gần nhất sẽ tăng dần khi mà có phiếu thu lập lên (Khi chốt sổ được set lại về 0)

        [PropertyInfo(Name = "Stt")] public int Row { get; set; }
        [PropertyInfo(Name = "Thông tư")] public string AccountTypeString { get { return EnumHelper<AccountType, FieldInfoAttribute>.Inst.GetAttribute(AccountType).Name; } }
        [PropertyInfo(Name = "Tài khoản cha")] public string ParentName { get; set; }
        public int Key
        {
            get { return AccountId; }
            set { AccountId = value; }
        }
        public object TreeItemId { get { return AccountId; } }

        [DataTextField(Default = "-- Chọn tài khoản --")]
        public string TreeItemName
        {
            get { return NodeName.IsNull() ? (Code + " - " + Name) : NodeName; }
            set { NodeName = value; }
        }
        protected string NodeName { set; get; }
        public object TreeItemParent { get { return ParentId; } }
        public int TreeLevel { set; get; }

        public class Tree : Tree<Account>
        {
            public AccountType AccountType { set; get; }
            public int CompanyId { set; get; }
            public string Keyword { get; set; }
            public int start { get; set; }
            public int length { get; set; }
            public string fieldOrder { get; set; }
            public string dir { get; set; }
            protected override List<Account> GetData()
            {
                return (Service == null ? Inst : new Account { }.InService(Service))
                    .ExeStoreToList("sp_Accounts_GetData", CompanyId, AccountType, Keyword, start, length, fieldOrder, dir);
            }

            public int GetCount()
            {
                return Inst.SelectFirstValue<int>("sp_Accounts_GetData_Count", CompanyId, AccountType, Keyword);
            }

            public Account FindByCode(string code)
            {
                return Data.FirstOrDefault(a => a.Code == code);
            }
        }
        [JsonIgnore]
        string IEntityForLogShowName.Name
        {
            get { return Code; }
        }
        public class DataSource : DataSource<Account>.Module, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public AccountType AccountType { set; get; }
            public string Code { get; set; }
            public override int GetTotal() => new Tree { CompanyId = CompanyId, AccountType = AccountType, Keyword = Code }.GetCount();
            public override List<Account> GetEntities() => new Tree { CompanyId = CompanyId, AccountType = AccountType, Keyword = Code, start = Start, length = Length, fieldOrder = FieldOrder, dir = Dir }.GetInTreeView(0, false);
        }

        [TableInfo(TableName = "[Account.Diaries]", Name = "Nhật ký nguồn tiền quỹ")]
        public class Diary : MainDb.Entity<Diary>, IModel<int>, ICompanyNeedValidate
        {
            [Field(IsIdentity = true, IsKey = true)] public int DiaryId { get; set; }
            [Field(Name = "Công ty")] public int CompanyId { get; set; }
            [Field(Name = "Tài khoản")] public int AccountId { get; set; }
            [Field(Name = "Ngày vào sổ")] public DateTime? InDate { get; set; }
            [Field(Name = "Phiếu")] public int CashId { get; set; }
            [Field(Name = "Mã phiếu")] public string CashCode { get; set; }
            [Field(Name = "Loại phiếu")] public CashType Type { get; set; }
            [Field(Name = "Số tiền")] public decimal? Amount { get; set; }
            public int Key
            {
                get { return DiaryId; }
                set { DiaryId = value; }
            }
        }
    }
    public enum AccountType : byte
    {
        [FieldInfo(Name = "Thông tư chung")] Type_0 = 0,
        [FieldInfo(Name = "Thông tư 200")] Type_200 = 1,
        [FieldInfo(Name = "Thông tư 133")] Type_133 = 2
    }
    public enum CashType : int
    {
        [FieldInfo(Name = "-- Chọn loại phiếu --")] Unknown = 0,
        [FieldInfo(Name = "Phiếu thu")] Receipt = 1,
        [FieldInfo(Name = "Phiếu chi")] Payment = 2
    }
}
