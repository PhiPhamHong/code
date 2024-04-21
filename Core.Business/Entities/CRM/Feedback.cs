using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;

using System.Collections.Generic;

namespace Core.Business.Entities.CRM
{
    [TableInfo(TableName = "[CRM.Feedbacks]", Name = "Trao đổi/Phản hồi")]
    public class Feedback : MainDb.EntityAuthor<Feedback>, IModel<int>, ICompanyNeedValidate
    {
        [Field(IsKey = true, IsIdentity = true)] public int FeedbackId { get; set; }
        [Field(Name = "Công ty")] public int CompanyId { get; set; }
        [Field(Name = "Khách hàng")] public int CustomerId { get; set; }
        [Field(Name = "Nội dung")] public string Content { get; set; }
        [Field(Name = "Nhóm"), ValidatorRequire] public CommentGroup CmtGroup { get; set; }
        public string ByClass { get { return CmtGroup == CommentGroup.Rep ? " is-me" : " is-you"; } }
        public string SendDate { get { return CreatedDate.ToString("dd/MM/yyyy hh:mm"); } }
        public int Key
        {
            set { FeedbackId = value; }
            get { return FeedbackId; }
        }
        public static List<Feedback> GetFeedbacks(int companyId, int customerId) => Inst.ExeStoreToList("sp_CRM_Feedbacks_GetData", companyId, customerId);
        public string CusName { get; set; }
        public string SendPerson
        {
            get { return CmtGroup == CommentGroup.Rep ? CreatedByUserName : CusName; }
        }
    }
    public enum CommentGroup: int
    {
        [FieldInfo(Name = "Trao đổi nội bộ")] Rep = 0,
        [FieldInfo(Name = "KH phản hồi")] Feedback = 1
    }
}
