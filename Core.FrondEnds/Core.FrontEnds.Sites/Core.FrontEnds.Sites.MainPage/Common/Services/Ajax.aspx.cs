using Core.Web.WebBase;
using Core.Extensions;
namespace Core.FrontEnds.Sites.MainPage.Common.Services
{
    public partial class Ajax : PageAjax
    {
        protected override string GetAssemblyOfMethod()
        {
            var n = base.GetAssemblyOfMethod();
            return n.IsNull() ? "Core.FrontEnds.Sites.MainPage" : n;
        }
    }
}