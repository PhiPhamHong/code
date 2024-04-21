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
    [TableInfo(TableName = "[Works]", Name = "Quản lý công việc")]
    public class Work : MainDb.EntityAuthor<Work>, IModel<int>, ICompanyNeedValidate, IEntityForLogShowName
    {
        [Field(IsKey = true, IsIdentity = true), DataValueField(Default = "0")] public int WorkId { get; set; }
        [Field(Name = "Công ty")] public int CompanyId { get; set; }
        [Field(Name = "Phòng ban"), ValidatorRequire] public int DepartmentId { get; set; }
        [Field(Name = "Công việc"), ValidatorRequire, DataTextField(Default = "-- Công việc --")] public string Name { get; set; }
        [Field(Name = "Mô tả ")] public string Description { get; set; }
        [Field(Name = "Người quản lý"), ValidatorRequire] public int ManagerId { get; set; }
        [Field(Name = "Người thực hiện"), ValidatorRequire] public string UserDoIds { get; set; }
        [Field(Name = "Độ ưu tiên"), ValidatorRequire] public int PrioritizeId { get; set; }
        [Field(Name = "Trạng thái"), ValidatorRequire] public WorkStatus Status { get; set; }
        [Field(Name = "Ngày thực hiện"), ValidatorRequire] public DateTime? FromDate { get; set; }
        [Field(Name = "Estimate"), ValidatorRequire] public int WorkDay { get; set; }
        [Field(Name = "Giao việc")] public bool IsActive { get; set; }
        public int Key
        {
            get { return WorkId; }
            set { WorkId = value; }
        }
        [PropertyInfo(Name = "Stt")] public int Row { get; set; }
        [PropertyInfo(Name = "Phòng ban")] public string DepartmentName { get; set; }
        [PropertyInfo(Name = "Người quản lý")] public string ManagerName { get; set; }
        [PropertyInfo(Name = "Độ ưu tiên")] public string PrioritizeName { get; set; }
        [PropertyInfo(Name = "Trạng thái")] public string StatusString { get { return EnumHelper<WorkStatus, FieldInfoAttribute>.Inst.GetAttribute(Status).Name; } }
        public class DataSource : DataSource<Work>.Module, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public int DepartmentId { get; set; }
            public int ManagerId { get; set; }
            public int UserDoId { get; set; }
            public int PrioritizeId { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public WorkStatus Status { get; set; }
            public override List<Work> GetEntities() => Inst.ExeStoreToList("sp_Works_GetData", CompanyId, DepartmentId, ManagerId, UserDoId, PrioritizeId, StartDate, EndDate, Status, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>("sp_Works_GetData_Count", CompanyId, DepartmentId, ManagerId, UserDoId, PrioritizeId, StartDate, EndDate, Status);
            
        }

        public static List<Work> GetForInput(int companyId, int userDoId)
        {
            return Inst.ExeStoreToList("sp_Works_GetForInput", companyId, userDoId);
        }

        [TableInfo(TableName = "[Work.Modules]", Name = "Quản lý đầu việc")]
        public class Module : MainDb.EntityAuthor<Module>, IModel<int>, ICompanyNeedValidate, IEntityForLogShowName
        {
            [Field(IsKey = true, IsIdentity = true), DataValueField(Default = "0")] public int ModuleId { get; set; }
            [Field(Name = "Công ty")] public int CompanyId { get; set; }
            [Field(Name = "Công việc"), ValidatorRequire] public int WorkId { get; set; }
            [Field(Name = "Đầu việc"), DataTextField(Default = "-- Đầu việc --"), ValidatorRequire] public string Name { get; set; }
            [Field(Name = "Người thực hiện"), ValidatorRequire] public int UserDoId { get; set; }
            [Field(Name = "Ngày bắt đầu"), ValidatorRequire] public DateTime? StartAt { get; set; }
            [Field(Name = "Estimate"), ValidatorRequire] public int WorkDay { get; set; }
            [Field(Name = "Trạng thái"), ValidatorRequire] public WorkStatus Status { get; set; }
            [Field(Name = "Ghi chú")] public string Note { get; set; }
            [Field(Name = "Confirm")] public WorkStatus MConfirm { get; set; }
            [Field(Name = "Ghi chú")] public int MNote { get; set; }
            [PropertyInfo(Name = "Người thực hiện")] public string WorkerName { get; set; }
            [PropertyInfo(Name = "Trạng thái")] public string StatusString { get { return EnumHelper<WorkStatus, FieldInfoAttribute>.Inst.GetAttribute(Status).Name; } }
            [PropertyInfo(Name = "Stt")] public int Row { get; set; }
            public int Key
            {
                get { return ModuleId; }
                set { ModuleId = value; }
            }
            public class DataSource : DataSource<Module>.Module, ICompanyNeedValidate
            {
                public int CompanyId { get; set; }
                public int WorkId { get; set; }
                public int UserDoId { get; set; }
                public DateTime? StartDate { get; set; }
                public DateTime? EndDate { get; set; }
                public WorkStatus Status { get; set; }
                public override List<Work.Module> GetEntities() => Inst.ExeStoreToList("sp_Work_Modules_GetData", CompanyId, WorkId, UserDoId, StartDate, EndDate, Status, Start, Length, FieldOrder, Dir);
                public override int GetTotal() => Inst.SelectFirstValue<int>("sp_Work_Modules_GetData_Count", CompanyId, WorkId, UserDoId, StartDate, EndDate, Status);
                
            }
            public static List<Module> GetUnDone (int companyId,int userdoId)
            {
                return Inst.ExeStoreToList("", companyId, userdoId);
            }

            [TableInfo(TableName = "[Work.Module.Process]", Name = "Báo cáo tiến độ công việc")]
            public class Process : MainDb.EntityAuthor<Process>, IModel<int>, ICompanyNeedValidate
            {
                [Field(IsKey = true, IsIdentity = true)] public int ProcessId { get; set; }
                [Field(Name = "Công ty")] public int CompanyId { get; set; }
                [Field(Name = "Đầu việc"), ValidatorRequire] public int ModuleId { get; set; }
                [Field(Name = "Ghi chú")] public string Note { get; set; }
                public int Key
                {
                    get { return ProcessId; }
                    set { ProcessId = value; }
                }
                [Field(Name = "Người thực hiện"), ValidatorRequire] public int UserDoId { get; set; }
                [Field(Name = "Tiến độ(%)"), ValidatorRequire] public int InPercent { get; set; }

                [PropertyInfo(Name = "Người thực hiện")] public string WorkerName { get; set; }
                [PropertyInfo(Name = "Đầu việc")] public string ModuleName { get; set; }
                [PropertyInfo(Name = "Stt")] public int Row { get; set; }
                public class DataSource : DataSource<Process>.Module, ICompanyNeedValidate
                {
                    public int CompanyId { get; set; }
                    public int ModuleId { get; set; }
                    public int UserDoId { get; set; }

                    public override List<Process> GetEntities() => Inst.ExeStoreToList("sp_Work_Module_Process_GetData", CompanyId, ModuleId, UserDoId, Start, Length, FieldOrder, Dir);
                    public override int GetTotal() => Inst.SelectFirstValue<int>("sp_Work_Module_Process_GetData_Count", CompanyId, ModuleId, UserDoId);
                    
                }
            }
        }
    }
    public enum WorkStatus : int
    {
        [FieldInfo(Name = "Tạo mới")] New = 0,
        [FieldInfo(Name = "Đang thực hiện")] InProcess = 1,
        [FieldInfo(Name = "Đã xong")] Done = 2,
        [FieldInfo(Name = "Thất bại")] UnDone = 3
    }
}
