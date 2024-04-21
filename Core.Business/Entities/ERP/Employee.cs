using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using Core.Web.WebBase.HtmlBuilders;
using System;
using System.Collections.Generic;

namespace Core.Business.Entities.ERP
{
    [TableInfo(TableName = "[Employees]", Name = "Nhân viên")]
    public class Employee : MainDb.EntityAuthor<Employee>, ICompanyNeedValidate, IEntityForLogShowName, IModel<int>
    {
        [Field(IsIdentity = true, IsKey = true), DataValueField(Default = "0")] public int EmployeeId { get; set; }
        [Field(Name = "Họ và tên"), ValidatorRequire, ValidatorLength(Max = 100, Stt = 1)] public string Name { get; set; }
        [Field(Name = "Mã nhân viên"), ValidatorRequire, ValidatorLength(Max = 20, Stt = 1)] public string Code { get; set; }
        [Field(Name = "Địa chỉ"), ValidatorLength(Max = 500)] public string Address { get; set; }
        [Field(Name = "Số điện thoại"), ValidatorLength(Max = 20), ValidatorPhoneNumber] public string Phone { get; set; }
        [Field(Name = "Email"), ValidatorLength(Max = 100), ValidatorEmail] public string Email { get; set; }
        [Field(Name = "Ảnh"), ValidatorLength(Max = 500)] public string Avatar { get; set; }
        [Field(Name = "Ngày sinh")] public DateTime? BirthDay { get; set; }
        [Field(Name = "CMT/ Hộ chiếu"), ValidatorLength(Max = 20)] public string CardNo { get; set; }
        [Field(Name = "Ngày gia nhập")] public DateTime? JoinDate { get; set; }
        [Field(Name = "Công ty")] public int CompanyId { get; set; }
        [Field(Name = "Tài khoản"), ValidatorRequire] public int UserId { set; get; }
        [Field(Name = "Phòng ban")] public int DepartmentId { set; get; }
        [Field(Name = "Từ ngày")] public DateTime? FromDate { set; get; }


        [PropertyInfo(Name = "Tên tài khoản")] public string UserName { get; set; }
        [PropertyInfo(Name = "Phòng ban")] public string DepartmentName { set; get; }
        
        public static Employee GetByUserId(int userId)
        {
            return Inst.ExeStoreToFirst("sp_Employees_GetByUserId", userId);
        }

        public int Key
        {
            get { return EmployeeId; }
            set { EmployeeId = value; }
        }
        [PropertyInfo(Name = "FieldKey"), DataTextField(Default = "-- Nhân viên --")] public string NameCode => Code + "-" + Name;
        [PropertyInfo(Name = "Stt")] public int Row { get; set; }

        public class DataSource : DataSource<Employee>.Module, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public int DepartmentId { set; get; }
            public string Name { get; set; }

            public override List<Employee> GetEntities() => Inst.ExeStoreToList("sp_Employees_GetData", CompanyId, DepartmentId, Name, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>("sp_Employees_GetData_Count", CompanyId, DepartmentId, Name);
        }
    }
}
