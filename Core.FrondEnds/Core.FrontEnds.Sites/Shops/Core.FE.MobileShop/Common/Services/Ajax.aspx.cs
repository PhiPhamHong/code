using Core.Web.WebBase;
using Core.Extensions;
namespace Core.FE.MobileShop.Common.Services
{
    public partial class Ajax : PageAjax
    {
        protected override string GetAssemblyOfMethod()
        {
            var n = base.GetAssemblyOfMethod();
            return n.IsNull() ? "Core.FE.MobileShop" : n;
        }
    }
}