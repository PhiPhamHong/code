using Core.Attributes;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Entities.CRM
{
    public partial class Facebook
    {
        [TableInfo(TableName = "[Facebook.PostLinks]", Name = "Đường dẫn bài viết")]
        public class PostLink : MainDb.EntityAuthor<PostLink>, IModel<int>, ICompanyNeedValidate
        {
            [Field(IsKey = true, IsIdentity = true)] public int PostLinkId { get; set; }
            [Field(Name = "Công ty")] public int CompanyId { get; set; }
            [Field(Name = "Quản lý")] public int ManagerId { get; set; }
            [Field(Name = "Tiêu đề")] public string Title { get; set; }
            [Field(Name = "Đường dẫn")] public string UrlLink { get; set; }
            [Field(Name = "Ghi chú")] public string Note { get; set; }

            public int Key
            {
                set { PostLinkId = value; }
                get { return PostLinkId; }
            }
            [PropertyInfo(Name = "Quản lý")] public string ManagerName { get; set; }
            public class DataSource : DataSource<PostLink>.Module, ICompanyNeedValidate
            {
                public int CompanyId { get; set; }
                public string UrlLink { get; set; }
                public int ManagerId { get; set; }

                public override List<PostLink> GetEntities() => Inst.ExeStoreToList("", CompanyId, ManagerId, UrlLink, Start, Length, FieldOrder, Dir);

                public override int GetTotal() => Inst.SelectFirstValue<int>("", CompanyId, ManagerId, UrlLink);
                
            }
        }
    }
}
