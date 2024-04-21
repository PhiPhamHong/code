using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using System;
using System.Collections.Generic;

namespace Core.Business.Entities.CRM
{
    [TableInfo(TableName = "[Opportunities]", Name = "Cơ hội kinh doanh")]
    public class Opportunity : MainDb.EntityAuthor<Opportunity>, IModel<int>, ICompanyNeedValidate
    {
        [Field(IsIdentity = true, IsKey = true)] public int OpportunityId { get; set; }
        [Field(Name = "Chiến dịch"), ValidatorRequire] public int CampaignId { get; set; }
        [Field(Name = "Công ty")] public int CompanyId { get; set; }
        [Field(Name = "Tên cơ hội"), ValidatorRequire] public string Name { get; set; }
        [Field(Name = "Nội dung")] public string Note { get; set; }
        [Field(Name = "Xác xuất(%)"), ValidatorRequire] public decimal? Probability { get; set; }
        [Field(Name = "Doanh thu dự kiến"), ValidatorRequire] public decimal? ExpectedRevenue { get; set; }
        [Field(Name = "Người phụ trách"), ValidatorRequire] public int ManagerId { get; set; }
        [Field(Name = "Trạng thái"), ValidatorRequire] public int Status { get; set; }
        [Field(Name = "Ngày bắt đầu"), ValidatorRequire] public DateTime? FromDate { get; set; }
        [Field(Name = "Ngày kết thúc"), ValidatorRequire, ValidatorDateGreater("FromDate", Stt = 1)] public DateTime? ToDate { get; set; }
        [Field(Name = "Tài liệu đính kèm")] public string AttachDocuments { get; set; }
        [Field(Name = "Khách hàng"), ValidatorRequire] public int CustomerId { get; set; }
        [Field(Name = "Tên khách")] public string CustomerName { get; set; }
        [Field(Name = "Email")] public string CustomerEmail { get; set; }
        [Field(Name = "Địa chỉ")] public string CustomerAddress { get; set; }

        public int Key
        {
            set { OpportunityId = value; }
            get { return OpportunityId; }
        }


        [PropertyInfo(Name = "Chiến dịch")] public string CampaignName { get; set; }
        [PropertyInfo(Name = "Người phụ trách")] public string ManagerName { get; set; }

        public class DataSource : DataSource<Opportunity>.Module, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public int CampaignId { get; set; }
            public string Name { get; set; }
            public DateTime? StartTime { get; set; }
            public DateTime? EndTime { get; set; }

            public override List<Opportunity> GetEntities() => Inst.ExeStoreToList("sp_Opportunities_GetData", CompanyId, CampaignId, Name, StartTime, EndTime, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>("sp_Opportunities_GetData_Count", CompanyId, CampaignId, Name, StartTime, EndTime);
            
        }
    }
    public enum OppStatus : int
    {
        [FieldInfo(Name = "-- Trạng thái --")] Unknown = 0,
        [FieldInfo(Name = "Mới")] New = 1,
        [FieldInfo(Name = "Đang thực hiện")] InProcess = 2,
        [FieldInfo(Name = "Đã kết thúc")] IsEnd = 3
    }
}
