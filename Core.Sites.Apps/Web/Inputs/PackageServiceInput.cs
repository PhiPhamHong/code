using Core.Sites.Apps.Web.Modules.FormPackageServices;
using Core.Business.Entities;
using Core.Web.WebBase;
using Core.Web.WebBase.HtmlBuilders;

namespace Core.Sites.Apps.Web.Inputs
{
    public class PackageServiceInput : SelectModel<PackageService, PackageServiceInput>
    {
        protected override IManageModulePermission GetManageModule()
        {
            return new ManagePackageServices();
        }
    }
}