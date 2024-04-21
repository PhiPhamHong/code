using Core.Business.Entities;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
namespace Core.Sites.Apps.Web.Modules.FormUsers
{
    public partial class ManageUsersDashBoard : DashBoard<ManageUsersDashBoardConfig.ConfigModel>
    {
        protected override void InitDashBoard()
        {
            switch (Config.OptionReportType)
            {
                case ManageUsersDashBoardConfig.OptionReportType.AllCompany: ltrUsers.Text = new User.DataSource { CompanyId = PortalContext.CurrentUser.CurrentCompanyId }.GetTotal().ToString() + " Users"; break;
                case ManageUsersDashBoardConfig.OptionReportType.OnlyCompany: ltrUsers.Text = User.GetDataCountInCompany(PortalContext.CurrentUser.GetCurrentCompanyId()).ToString() + " Users"; break;
            }
        }
    }
}