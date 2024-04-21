using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Extensions;
using Core.Utility;
using Core.Web.WebBase.HtmlBuilders;
using System.Collections.Generic;
using System.Linq;

namespace Core.Business.Entities.ERP
{
    [TableInfo(TableName = "[Salaries]", Name = "Lương")]
    public class Salary : MainDb.EntityAuthor<Salary>, IModel<int>, IReportSummary, ICompanyNeedValidate, IEmpty
    {
        [Field(IsIdentity = true, IsKey = true)] public int SalaryId { get; set; }
        [Field(Name = "Công ty")] public int CompanyId { get; set; }
        [Field(Name = "Nhân viên")] public int EmployeeId { get; set; }
        [Field(Name = "Tháng")] public int Month { get; set; }
        [Field(Name = "Năm")] public int Year { get; set; }
        [Field(Name = "Mức lương")] public decimal? Wage { get; set; }
        [Field(Name = "Ngày công đủ")] public int? PublicLimitDate { set; get; }
        [Field(Name = "Số công thực/tháng")] public decimal? ActualDays { set; get; }
        [Field(Name = "Lương/Ngày")] public decimal? SalaryOnDay { set; get; }
        [Field(Name = "Thành tiền")] public decimal? BillSalary { set; get; }
        [Field(Name = "Ghi chú")] public string Description { set; get; }
        [Field(Name = "Cấu hình")] public int ConfigId { get; set; }
        public int Key
        {
            get { return SalaryId; }
            set { SalaryId = value; }
        }
        [PropertyInfo(Name = "Stt")] public int Row { get; set; }
        [PropertyInfo(Name = "Truy thu/tạm ứng")] public decimal? BillMinus { get; set; }
        [PropertyInfo(Name = "Tổng lương(gross)")] public decimal? BillPlus { get; set; }
        [PropertyInfo(Name = "Mã nhân viên")] public string Code { get; set; }
        [PropertyInfo(Name = "Tên nhân viên")] public string EmpName { get; set; }
        [PropertyInfo(Name = "Phòng ban")] public string DepartmentName { get; set; }
        [PropertyInfo(Name = "Diễn giải")] public string Name { get; set; }
        public int Total { get; set; }
        public string TitleSummary { get; set; }
        public int Type { get; set; }
        public decimal Plus { set; get; }

        public decimal Minus { set; get; }

        public decimal ToTalSalary { set; get; }

        public bool IsEmpty => (ConfigId == 0);

        public class DataSource : DataSource<Salary>.ReportSummary<Salary>, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public int EmployeeId { set; get; }
            public int Month { get; set; }
            public int Year { get; set; }
            public override Salary GetDataSummary()
            {
                var data = CurrentData;
                Salary result = new Salary();
                result.TitleSummary = "Tổng: ";
                result.BillMinus = data.Sum(c => c.BillMinus);
                result.BillPlus = data.Sum(c => c.BillPlus);
                result.BillSalary = data.Sum(c => c.BillSalary);
                return result;
            }
            public override List<Salary> GetEntities()
            {
                List<Salary> Results = new List<Salary>();
                var configs = new Salary.Config.DataSource { CompanyId = CompanyId, FieldOrder = "DisplayOrder" }.GetEntities();
                var lplus = configs.Where(c => c.Type == Config.Calculation.Plus).Select(c => c.ConfigId).ToList();
                var lminus = configs.Where(c => c.Type == Config.Calculation.Minus).Select(c => c.ConfigId).ToList();
                var datas = Inst.ExeStoreToList("sp_Salaries_GetData", CompanyId, EmployeeId, Month, Year, Start, Length, FieldOrder, Dir);
                var empIds = datas.Select(c => c.EmployeeId).Distinct();
                empIds.ForEach(emp =>
                {
                    var plus = datas.Where(c => c.EmployeeId == emp && lplus.Any(p => p == c.ConfigId)).Sum(c => c.BillSalary);
                    var minus = datas.Where(c => c.EmployeeId == emp && lminus.Any(m => m == c.ConfigId)).Sum(c => c.BillSalary);
                    var remain = plus - minus;

                    var res = datas.FirstOrDefault(c => c.EmployeeId == emp);
                    res.BillMinus = minus;
                    res.BillPlus = plus;
                    res.BillSalary = remain;
                    Results.Add(res);
                });
                return Results;
            } 
        }
        public static List<Salary> Getdetails(int companyId, int empId, int month, int year) => Inst.ExeStoreToList("sp_Salaries_GetDetails", companyId, empId, month, year);
        public static List<Salary> CheckValidData(int companyId, int empId, int month,int year)
        {
            return Inst.ExeStoreToList("sp_Salaries_CheckValidData", companyId, empId, month, year);
        }

        [TableInfo(TableName = "[Salary.Configs]", Name = "Cấu hình lương")]
        public class Config : MainDb.EntityAuthor<Config>, IModel<int>, ICompanyNeedValidate, IEntityForLogShowName
        {
            [Field(IsIdentity = true,IsKey = true), DataValueField(Default = "0")] public int ConfigId { get; set; }
            [Field(Name = "Công ty")] public int CompanyId { get; set; }
            [Field(Name = "Tên cấu hình"), ValidatorRequire, ValidatorLength(Max = 300, Stt = 1), DataTextField(Default = "-- Diễn giải --")] public string Name { get; set; }
            [Field(Name = "Phòng ban")] public string DepartmentIds { get; set; }
            [Field(Name = "Cách tính")] public Calculation Type { get; set; }
            [PropertyInfo(Name = "Cách tính")] public string TypeString { get { return EnumHelper<Calculation, FieldInfoAttribute>.Inst.GetAttribute(Type).Name; } }
            [Field(Name = "Áp dụng cho"), ValidatorRequire] public UsedFor UseFor { get; set; }
            [PropertyInfo(Name = "Áp dụng cho")] public string UseForString { get { return EnumHelper<UsedFor, FieldInfoAttribute>.Inst.GetAttribute(UseFor).Name; } }
            [Field(Name = "Áp dụng công thức")] public bool Status { get; set; }
            [PropertyInfo(Name = "Tình trạng")] public string StatusString { get { return Status == true ? "Đang áp dụng": "Đã tắt"; } }
            [Field(Name = "Hình thức"), ValidatorRequire] public Formal Formality { get; set; }
            [PropertyInfo(Name = "Hình thức")] public string FormalString { get { return EnumHelper<Formal, FieldInfoAttribute>.Inst.GetAttribute(Formality).Name; } }
            [Field(Name = "Số tiền")] public decimal? FMoney { get; set; }
            [Field(Name = "Mô tả")] public string Description { get; set; }
            [Field(Name = "Thứ tự")] public int DisplayOrder { get; set; }
            [Field(Name = "Ngày công đủ(Mặc định)")] public int FullDate { get; set; }
            [PropertyInfo(Name = "Stt")] public int Row { get; set; }
            public int Key
            {
                get { return ConfigId; }
                set { ConfigId = value; }
            }

            public class DataSource : DataSource<Salary.Config>.Module, ICompanyNeedValidate
            {
                public int CompanyId { get; set; }
                public UsedFor UseFor { get; set; }
                public override List<Salary.Config> GetEntities() => Inst.ExeStoreToList("sp_Salary_Configs_GetData", CompanyId, UseFor, Start, Length, FieldOrder, Dir);

                public override int GetTotal() => CurrentData.Count;
            }
            public enum Calculation : int
            {
                [FieldInfo(Name = "Cộng (Tăng, Thưởng)")] Plus = 0,
                [FieldInfo(Name = "Trừ (Giảm, Phạt)")] Minus = 1
            }
            public enum UsedFor : int
            {
                [FieldInfo(Name = "-- Chọn đối tượng áp dụng --")] Unknown = 0,
                [FieldInfo(Name = "Toàn bộ công ty")] All = 1,
                [FieldInfo(Name = "Riêng phòng ban")] Curr = 2
            }
            public enum Formal : int
            {
                [FieldInfo(Name = "Linh hoạt")] Flex = 0,
                [FieldInfo(Name = "Cố định")] Const = 1
            }
        }
    }

    
}
