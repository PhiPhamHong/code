using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using Core.Web.WebBase.HtmlBuilders;
using System.Collections.Generic;

namespace Core.Business.Entities.ERP
{
    [TableInfo(Name = "Ngân hàng", TableName = "[Banks]")]
    public class Bank : MainDb.EntityAuthor<Bank>, ICompanyNeedValidate, IModel<int>
    {
        [Field(IsKey = true, IsIdentity = true), DataValueField(Default = "0")] public int BankId { get; set; }
        [Field(Name = "Công ty")] public int CompanyId { get; set; }
        [Field(Name = "Tên"), ValidatorRequire] public string Name { get; set; }
        [Field(Name = "Mã"), ValidatorRequire] public string Code { get; set; }
        [Field(Name = "Logo")] public string Logo { get; set; }
        [DataTextField(Default = "-- Chọn ngân hàng --")]
        public string FindName { get { return Code + " - " + Name; } }
        [PropertyInfo(Name = "Stt")] public int Row { get; set; }
        public int Key { get => BankId; set => BankId = value; }
        public class DataSource : DataSource<Bank>.Module, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public string Code { get; set; }
            public override List<Bank> GetEntities() => Inst.ExeStoreToList("sp_Banks_GetData", CompanyId, Code, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => CurrentData.Count;
        }
    }
}
