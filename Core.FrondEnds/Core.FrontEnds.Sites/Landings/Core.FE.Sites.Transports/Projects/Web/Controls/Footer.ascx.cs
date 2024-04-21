using Core.FrontEnds.Libraries;
using Core.FrontEnds.Libraries.Portal;
using Core.FrontEnds.Libraries.Web.Caches;
using Core.Web.Extensions;
using System.Linq;

namespace Core.FE.Sites.Transports.Projects.Web.Controls
{
    public partial class Footer : Module
    {
        protected override void BeforeInitData()
        {
            var partners = CachePartners.GetData().Where(c=>c.IsShow == true).ToList();
            foreach (var item in partners)
            {
                if (!item.Logo.StartsWith(Setting.ServerImage))
                    //item.Logo = Setting.ServerImage + "/" + item.Logo;
                    item.Logo = "/Projects/Web/Resources/img/Partnerlogo/1.5 Tiep van Hoa Phat.png";
            }
            partners.BindTo(rpPartner);
        }
    }
}