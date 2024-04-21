using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using Core.Web.WebBase.HtmlBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Entities.CRM
{
    [TableInfo(TableName = "[UptinForms]", Name = "Form nhúng đăng ký")]
    public class UptinForm : MainDb.EntityAuthor<UptinForm>, IModel<int>, ICompanyNeedValidate
    {
        [Field(IsIdentity = true, IsKey = true), DataValueField(Default = "0")] public int UptinFormId { get; set; }
        [Field(Name = "Công ty")] public int CompanyId { get; set; }
        [Field(Name = "Tiêu đề"), ValidatorRequire, DataTextField(Default = "-- Chọn Uptin Form --")] public string Title { get; set; }
        [Field(Name = "Ghi chú")] public string Note { get; set; }
        [Field(Name = "Thông điệp khi thành công"), ValidatorRequire] public string MessageWhenSuccess { get; set; }
        [Field(Name = "Thông điệp khi thất bại"), ValidatorRequire] public string MessageWhenFail { get; set; }
        [Field(Name = "Text nút đăng ký"), ValidatorRequire] public string TextInSubmitButton { get; set; }
        [Field(Name = "Định dạng"), ValidatorRequire] public FormatField Format { get; set; }
        [Field(Name = "Css"), ValidatorRequire] public string Css { get; set; }
        [Field(Name = "Mã nhúng")] public string EmbedCode { get; set; }
        [Field(Name = "Design")] public string Design { get; set; }
        [Field(Name = "Người quản lý"), ValidatorRequire] public int ManagerId { get; set; }
        [Field(Name = "Cho phép giới thiệu")] public bool AllowMultipleIntro { get; set; }
        [Field(Name = "Mã giới thiệu")] public string IntroCode { get; set; }
        [Field(Name = "Trường dữ liệu"), ValidatorRequire] public string Fields { get; set; }
        [Field(Name = "ProductKey")] public string ProductKey { get; set; }
        [Field(Name = "Lưu trữ"), ValidatorRequire] public SaveAtEnum SaveAt { get; set; }
        [Field(Name = "Google Sheets(exe) ")] public string UrlDocs { get; set; }
        [Field(Name = "Domain sử dụng"), ValidatorRequire] public string Domains { get; set; }
        public int Key
        {
            set { UptinFormId = value; }
            get { return UptinFormId; }
        }
        

        [TableInfo(TableName = "[UptinForm.Fields]", Name = "Trường dữ liệu")]
        public class UptinField : MainDb.EntityAuthor<UptinField>, IModel<int>
        {
            [Field(IsKey = true, IsIdentity = true), DataValueField(Default = "0")] public int FieldId { get; set; }
            [Field(Name = "Tên trường"), ValidatorRequire] public string Name { get; set; }
            [Field(Name = "Kiểu dữ liệu"), ValidatorRequire] public TypeOfField TypeOf { get; set; }
            [Field(Name = "Dữ liệu chọn")] public string NameForSelect { get; set; }
            [Field(Name = "Field(Google)"), ValidatorRequire] public string FieldClass { get; set; }
            [Field(Name = "Lỗi trống")] public string TextNull { get; set; }
            [Field(Name = "Cho phép để trống")] public bool AllowNull { get; set; }
            [Field(Name = "Placeholder")] public string Placeholder { get; set; }
            [Field(Name = "Áp dụng")] public bool IsActive { get; set; }
            public int Key
            {
                set { FieldId = value; }
                get { return FieldId; }
            }
            [PropertyInfo(Name = "Stt")] public int Row { get { return FieldId; } }
            [PropertyInfo(Name = "Kiểu dữ liệu")] public string TypeOfString { get { return EnumHelper<TypeOfField, FieldInfoAttribute>.Inst.GetAttribute(TypeOf).Name; } }
            [DataTextField(Default = "-- Trường dữ liệu --")] public string FindName { get { return Name + " - " + TypeOfString; } }
            public class DataSource : DataSource<UptinField>.Module
            {
                public override List<UptinField> GetEntities() => Inst.GetAllToList();
                public override int GetTotal() => CurrentData.Count;
                
            }
        }

        [PropertyInfo(Name = "Stt")] public int Row { get; set; }
        [PropertyInfo(Name = "Người quản lý")] public string ManagerName { get; set; }
        [PropertyInfo(Name = "Định dạng")] public string FormatString { get { return EnumHelper<FormatField, FieldInfoAttribute>.Inst.GetAttribute(Format).Name; } }
        public class DataSource : DataSource<UptinForm>.Module, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public int ManagerId { get; set; }
            public string Title { get; set; }
            public override List<UptinForm> GetEntities() => Inst.ExeStoreToList("sp_UptinForms_GetData", CompanyId, ManagerId, Title, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>("sp_UptinForms_GetData_Count", CompanyId, ManagerId, Title);
            
        }
    }

    public enum TypeOfField : int
    {
        [FieldInfo(Name = "-- Kiểu dữ liệu --")] Unknown = 0,
        [FieldInfo(Name = "Kiểu chữ(Text)")] Text = 1,
        [FieldInfo(Name = "Kiểu số(Number)")] Number = 2,
        [FieldInfo(Name = "Tích chọn(Checkbox)")] Checkbox = 3,
        [FieldInfo(Name = "Chọn giá trị(Selection)")] Select = 4,
    }
    public enum  FormatField : int
    {
        [FieldInfo(Name = "-- Chọn định dạng UptinForm của bạn --")] Unknown = 0,
        [FieldInfo(Name = "Căn trái (Left)")] Left = 1,
        [FieldInfo(Name = "Căn giữa (Center)")] Center = 2,
        [FieldInfo(Name = "Căn phải (Right)")] Right = 3,
        [FieldInfo(Name = "Năm ngang (Horizontal)")] Horizontal = 4
    }
    public enum SaveAtEnum: int
    {
        [FieldInfo(Name = "Trên hệ thống")] SSERP = 0,
        [FieldInfo(Name = "Google sheets")] GoogleSheet = 1,
        [FieldInfo(Name = "Lưu trên tất cả các nguồn")] Both = 2
    }
}
