using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using Core.Web.WebBase.HtmlBuilders;
using System;
using System.Collections.Generic;

namespace Core.Business.Entities.CRM
{
    [TableInfo(TableName = "[Campaigns]", Name = "Chiến dịch marketing")]
    public class Campaign : MainDb.EntityAuthor<Campaign>, IModel<int>, ICompanyNeedValidate, IEntityForLogShowName
    {
        [TableInfo(TableName = "[Campaign.Approachs]", Name = "Tiến trình thực hiện chiến dịch")]
        public class Approach : MainDb.EntityAuthor<Approach>, IModel<int>, ICompanyNeedValidate
        {
            [Field(IsIdentity = true, IsKey = true), DataValueField(Default = "0")] public int ApproachId { get; set; }
            [Field(Name = "Công ty")] public int CompanyId { get; set; }
            [Field(Name = "Tên"), ValidatorRequire] public string Name { get; set; }
            [Field(Name = "Hình nền")] public string Avatar { get; set; }
            public int Key
            {
                set { ApproachId = value; }
                get { return ApproachId; }
            }
            [Field(Name = "Thứ tự"), ValidatorRequire] public int Stt { get; set; }
            [Field(Name = "Mô tả")] public string Description { get; set; }
            [Field(Name = "Áp dụng")] public bool IsActive { get; set; }

            [DataTextField(Default = "-- Tiến trình --")]
            public string FindName
            {
                get
                {
                    return "Bước " + Stt + " - " + Name;
                }
            }
            public class DataSource : DataSource<Approach>.Module, ICompanyNeedValidate
            {
                public int CompanyId { get; set; }
                public string Name { get; set; }
                public override List<Approach> GetEntities() => Inst.ExeStoreToList("sp_Campaign_Approachs_GetData", CompanyId, Name, Start, Length, FieldOrder, Dir);
                public override int GetTotal() => CurrentData.Count;
            }
        }
        [Field(IsIdentity = true, IsKey = true), DataValueField(Default = "0")] public int CampaignId { get; set; }
        [Field(Name = "Công ty")] public int CompanyId { get; set; }
        [Field(Name = "Tên chiến dịch"), ValidatorRequire, DataTextField(Default = "-- Chiến dịch --")] public string Name { get; set; }
        [Field(Name = "Kích hoạt")] public bool IsActive { get; set; }
        public int Key
        {
            set { CampaignId = value; }
            get { return CampaignId; }
        }

        //Thông tin phương pháp bán hàng
        [Field(Name = "Người quản lý"), ValidatorRequire] public int ManagerId { get; set; }
        [Field(Name = "Đối tượng"), ValidatorRequire] public TargetJoin Target { get; set; }
        [Field(Name = "Người bán")] public string SaleIds { get; set; }
        [Field(Name = "Phòng ban")] public string DepartmentIds { get; set; }
        [Field(Name = "Cách tiếp cận")] public string ApproachIds { get; set; }

        //Thông tin khách hàng hướng tới(mục tiêu)
        [Field(Name = "Nhóm khách")] public int GroupId { get; set; }
        [Field(Name = "Nguồn khách")] public int SourceId { set; get; }
        [Field(Name = "Loại khách")] public int TypeId { set; get; }
        [Field(Name = "Dành riêng")] public string CustomerIds { get; set; }

        //Cấu hình chi tiết
        [Field(Name = "Áp dụng từ"), ValidatorRequire] public DateTime? FromDate { get; set; }
        [Field(Name = "Đến"), ValidatorRequire, ValidatorDateGreater("FromDate", Stt = 1)] public DateTime? ToDate { get; set; }
        [Field(Name = "Cho phép trùng cơ hội")] public bool IsAllowDoulicate { get; set; }
        [Field(Name = "Time limit"), ValidatorRequire] public int Limit { get; set; }
        [Field(Name = "Ẩn thông tin cơ hội")] public bool IsHideOpportunityInfo { get; set; }
        [Field(Name = "Tự động phân chia cơ hội")] public bool IsAutoDivisionOpportunities { get; set; }

        //Chiến dịch thất bại thì:
        [Field(Name = "Tạo cơ hội cho chiến dịch mới")] public bool UseFornextCampaignWhenFalse { get; set; }
        [Field(Name = "Chỉ dùng lần này")] public bool OnlyThisTimeWhenFalse { get; set; }
        //Thành công thì:
        [Field(Name = "Tạo cơ hội cho chiến dịch mới")] public bool UseFornextCampaignWhenSuccess { get; set; }
        [Field(Name = "Chỉ dùng lần này")] public bool OnlyThisTimeWhenSuccess { get; set; }


        [PropertyInfo(Name = "Stt")] public string Row { get; set; }
        [PropertyInfo(Name = "Đối tượng tham gia")] public string TargetString { get { return EnumHelper<TargetJoin, FieldInfoAttribute>.Inst.GetAttribute(Target).Name; } }
        [PropertyInfo(Name = "Người quản lý")] public string ManagerName { get; set; }
        public class DataSource : DataSource<Campaign>.Module, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public int ManagerId { get; set; }
            public string Name { get; set; }
            public DateTime? StartTime { get; set; }
            public DateTime? EndTime { get; set; }
            public override List<Campaign> GetEntities() => Inst.ExeStoreToList("sp_Campaigns_GetData", CompanyId, ManagerId, Name, StartTime, EndTime, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>("sp_Campaigns_GetData_Count", CompanyId, ManagerId, Name, StartTime, EndTime);
            
        }

        public static List<Campaign> GetForInput(int companyId)
        {
            return Inst.ExeStoreToList("sp_Campaigns_GetForInput", companyId);
        }
    }
    public enum TargetJoin : int
    {
        [FieldInfo(Name = "-- Đối tượng tham gia --")] Unknown = 0,
        [FieldInfo(Name = "Tất cả")] All = 1,
        [FieldInfo(Name = "Theo phòng ban")] ByDepartment = 2,
        [FieldInfo(Name = "Nhóm/Cá nhân chỉ định")] ToChoose = 3
    }
}
