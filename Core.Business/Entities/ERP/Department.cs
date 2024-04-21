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
    [TableInfo(TableName = "[Departments]", Name = "Phòng ban")]
    public class Department : MainDb.EntityAuthor<Department>, ICompanyNeedValidate, IEntityForLogShowName, IModel<int>
    {
        [Field(IsIdentity = true, IsKey = true), DataValueField(Default = "0")] public int DepartmentId { get; set; }
        [Field(Name = "Tên phòng"), ValidatorRequire, ValidatorLength(Max = 200, Stt = 1)] public string Name { get; set; }
        [Field(Name = "Mã phòng"), ValidatorRequire, ValidatorLength(Max = 50, Stt = 1)] public string Code { get; set; }
        [Field(Name = "Trưởng phòng"), ValidatorRequire] public int MentorId { get; set; }
        [Field(Name = "Nhóm phòng"), ValidatorRequire] public DepartmentType TypeId { get; set; }
        [Field(Name = "Công ty"), ValidatorRequire] public int CompanyId { get; set; }
        [Field(Name = "Ghi chú")] public string Description { get; set; }

        public enum DepartmentType : int
        {
            [FieldInfo(Name = "-- Loại phòng --")] Unknown = 0,
            [FieldInfo(Name = "Kinh doanh")] Sale = 1,
            [FieldInfo(Name = "Kế hoạch")] Plan = 2,
            [FieldInfo(Name = "Kỹ thuật")] Techical = 3,
            [FieldInfo(Name = "Bộ phận kho")] Stock = 4,
            [FieldInfo(Name = "Nội dung")] Content = 5,
            [FieldInfo(Name = "Kế toán")] Account = 6,
            [FieldInfo(Name = "Nhân sự")] Emp = 7,
            [FieldInfo(Name = "Marketing")] Marketing = 8,
            [FieldInfo(Name = "Chăm sóc khách hàng")] CSKH = 9
        }
        public int Key
        {
            get { return DepartmentId; }
            set { DepartmentId = value; }
        }
        [PropertyInfo(Name = "FieldKey"), DataTextField(Default = "-- Phòng ban --")] public string NameCode => Code + "-" + Name;
        [PropertyInfo(Name = "Trưởng phòng")] public string MentorName { get; set; }
        [PropertyInfo(Name = "Stt")] public int Row { get; set; }
        [PropertyInfo(Name = "Nhóm phòng")] public string TypeString { get { return EnumHelper<DepartmentType, FieldInfoAttribute>.Inst.GetAttribute(TypeId).Name; } }
        public bool HasEmployee(int departmentId)
        {
            return Inst.SelectFirstValue<int>("sp_Department_HasEmployee", departmentId) > 0 ? true : false;
        }
        public class DataSource : DataSource<Department>.Module, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public DepartmentType TypeId { get; set; }
            public string Name { get; set; }

            public override List<Department> GetEntities() => Inst.ExeStoreToList("sp_Departments_GetData", CompanyId, TypeId, Name, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>("sp_Departments_GetData_Count", CompanyId, TypeId, Name);
        }

    }
}
