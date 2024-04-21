using Core.Business.Entities;
using System;
using System.Collections.Generic;
using Core.DataBase.ADOProvider.Attributes;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.DataBase.ADOProvider;
namespace Core.Sites.Apps.Web.Modules.FormCompanyPackageServices
{
    [Script(Src = "/Web/Modules/FormCompanyPackageServices/js/ManageCompanyPackageServices.js")]
    [ManageModulePermission(Add = 19, Delete = 21, Edit = 20)]
    [Module]
    public partial class ManageCompanyPackageServices : ManageModule<CompanyPackageService, ManageCompanyPackageServices.ModuleProvider, FormEditCompanyPackageService>
    {
        public class ModuleProvider : ManageModuleProvider<CompanyPackageService, int>.Source<CompanyPackageService.DataSource>
        {
            protected override void Save(CompanyPackageService t, List<LogEntity> logEntities, IDataBaseService service)
            {
                t.UserUpdated = PortalContext.CurrentUser.User.UserId;
                t.TimeUpdated = DateTime.Now;
                t.Save();

                if (t.ApplyConfigToCompany)
                {
                    var package = new PackageService { PackageServiceId = t.PackageServiceId };
                    package.GetByKey();
                }
            }
            public override CompanyPackageService GetByKey(CompanyPackageService t) => base.GetByKey(t) ?? new CompanyPackageService { ApplyConfigToCompany = true };
        }
    }    
}