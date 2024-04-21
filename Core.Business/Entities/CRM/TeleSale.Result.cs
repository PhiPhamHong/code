using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using Core.Utility.Language;
using Core.Web.WebBase.HtmlBuilders;
using System.Collections.Generic;


namespace Core.Business.Entities.CRM
{
    public partial class Customer
    {
        [TableInfo(TableName = "[TeleSales.Results]", Name = "Trạng thái cuộc gọi")]
        public class Result : MainDb.EntityAuthor<Result>, IModel<int>, ICompanyNeedValidate, IEntityForLogShowName
        {
            #region Properties
            [Field(IsIdentity = true, IsKey = true), DataValueField(Default = "0")] public int ResultId { set; get; }
            [Field(Name = "Công ty")] public int CompanyId { set; get; }
            [Field(Name = "Tên trạng thái"), DataTextField(Default = "-- Kết quả cuộc gọi --"), ValidatorRequire, ValidatorLength(Max = 500, Stt = 1)] public string Name { set; get; }
            [Field(Name = "Ghi chú"), ValidatorLength(Max = 2000, Stt = 1)] public string Description { set; get; }
            [Field(Name = "Màu nền"), ValidatorLength(Max = 20)] public string ColorBg { set; get; }
            [Field(Name = "Màu chữ"), ValidatorLength(Max = 20)] public string ColorText { set; get; }
            [Field] public int Version { set; get; }
            [Field(Name = "Thứ tự")] public int Stt { set; get; }
            [Field(Name = "Gọi lại")] public bool CallBackStatus { set; get; }
            [PropertyInfo(Name = "Stt")] public int Row { get; set; }
            #endregion
            public int Key
            {
                set { ResultId = value; }
                get { return ResultId; }
            }

            [PropertyInfo(Name = "Gọi lại")] public string CallBackStatusName => CallBackStatus ? LanguageHelper.GetLabel("Có") : LanguageHelper.GetLabel("Không");

            public class DataSource : DataSource<Result>.Module, ICompanyNeedValidate
            {
                public string Name { set; get; }
                public int CompanyId { set; get; }
                public override List<Result> GetEntities() => Inst.ExeStoreToList("sp_TeleSales_Results_GetData", CompanyId, Name, Start, Length, FieldOrder, Dir);
                public override int GetTotal() => Inst.SelectFirstValue<int>("sp_TeleSales_Results_GetData_Count", CompanyId, Name);
            }
        }
    }
}
