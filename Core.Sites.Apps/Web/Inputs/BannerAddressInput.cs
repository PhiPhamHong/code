using Core.Business.Entities.Websites;
using Core.Web.WebBase.HtmlBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core.Sites.Apps.Web.Inputs
{
    public class BannerAddressInput : SelectModel<Banner.Target,BannerAddressInput> 
    {
        [SelectData("CompanyId")] protected int companyId { set; get; }
        public BannerAddressInput CompanyId(int companyId) { return Chain(ip => ip.companyId = companyId); }

        protected override List<Banner.Target> GetData() => new Banner.Target.DataSource { CompanyId = companyId, FieldOrder = "AddressId" }.GetEntities();
        
    }
}