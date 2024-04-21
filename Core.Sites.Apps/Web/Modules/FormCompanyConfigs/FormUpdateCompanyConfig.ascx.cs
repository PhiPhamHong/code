using Core.Business.Entities;
using System;
using Core.Web.WebBase;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;

namespace Core.Sites.Apps.Web.Modules.FormCompanyConfigs
{
    [Script(Src = "/Web/Modules/FormCompanyConfigs/js/FormUpdateCompanyConfig.js")]
    [Module]
    public partial class FormUpdateCompanyConfig : FormEdit<CompanyConfig, ManageModuleProviderCompanyConfig>
    {
        protected override CompanyConfig GetForEdit()
        {
            var companyId = this.Query<int>("CompanyId");
            companyId = PortalContext.CurrentUser.GetCompanyId(companyId);
            return CompanyConfig.Inst.GetByCompanyId(companyId);
        }

        public void ReloadByCompanyId()
        {
            var control = Control<FormUpdateCompanyConfig>.Create();
            control.InitData();
            this.SetData("Html", control.Html);
        }
    }

    public class ManageModuleProviderCompanyConfig : ManageModuleProvider<CompanyConfig, int>
    {
        protected override void ValidateHelper(CompanyConfig t)
        {
            if (t.CompanyId == 0 && PortalContext.CurrentUser.User.CompanyParentId != 0) throw new Exception("Bạn không có quyền thay đổi giá trị mặc định của hệ thống");
            PortalContext.CurrentUser.ThrowIfCompanyIdNotValidWithUserCurrent(t.CompanyId, string.Empty);
        }

        //protected override void AfterFinishTransactionSave(CompanyConfig t) // khong co server tam thoi khoa lai
        //{
        //    PortalContext.WebCenterUpdateCompayConfig(t);
        //}
    }
}