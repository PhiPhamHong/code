using Core.Business.Entities;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Web.WebBase;

namespace Core.Sites.Apps.Web.Modules.FormCompanyPackageServices
{
    public partial class FormEditCompanyPackageService : PortalModule<CompanyPackageService>
    {
        protected override void OnInitData()
        {
            if (Entity.Id == -1) throw new ErrorMessageException("Bạn không thể cập nhật bản tin lịch sử");
        }
    }
}