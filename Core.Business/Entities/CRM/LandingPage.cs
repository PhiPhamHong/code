using Core.Attributes;
using Core.Attributes.Validators;
using Core.Business.Entities.Websites;
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
    [TableInfo(TableName = "[LandingPages]", Name = "Landing pages")]
    public class LandingPage : MainDb.EntityAuthor<LandingPage>, IModel<int>, ICompanyNeedValidate
    {
        [Field(IsIdentity = true, IsKey = true)] public int LandingId { get; set; }
        [Field(Name = "Công ty")] public int CompanyId { get; set; }
        [Field(Name = "Tên Page"), ValidatorRequire] public string Name { get; set; }
        [Field(Name = "Bản thiết kế"), ValidatorRequire] public string Design { get; set; }
        [Field(Name = "Khởi chạy")] public bool IsActive { get; set; }
        [Field(Name = "Sử dụng SEO")] public bool UsedSeo { get; set; }
        [Field(Name = "Thẻ Meta")] public string MetaIds { get; set; }
        [Field(Name = "Uptin Form")] public int UptinFormId { get; set; }
        [Field(Name = "Chiến dịch")] public int CampaignId { get; set; }
        [Field(Name = "Người quản lý"), ValidatorRequire] public int ManagerId { get; set; }
        [Field(Name = "Đường dẫn ảo")] public string Url { get; set; }
        [Field(Name = "Đường dẫn")] public string UrlRender { get; set; }
        [Field(Name = "Remarketing Facebook")] public string RemaFacebook { get; set; }
        [Field(Name = "Remarketing Google")] public string RemaGoogle { get; set; }
        public int Key
        {
            set { LandingId = value; }
            get { return LandingId; }
        }

        [PropertyInfo(Name = "Người quản lý")] public string ManagerName { get; set; }
        [PropertyInfo(Name = "Chiến dịch")] public string CampaignName { get; set; }
        [PropertyInfo(Name = "Stt")] public int Row { get; set; }

        public List<Meta> Metas { get; set; }
        public Seo Seo { get; set; }

        public class DataSource : DataSource<LandingPage>.Module, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public int CampaignId { get; set; }
            public string Name { get; set; }

            public override List<LandingPage> GetEntities() => Inst.ExeStoreToList("sp_LandingPages_GetData", CompanyId, CampaignId, Name, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => CurrentData.Count;
            
        }
    }
}
