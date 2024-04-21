using System.Collections.Generic;
using Core.Business.Entities;
using Core.Web.WebBase;
using Core.Utility.Trees;
using Core.Sites.Libraries;
using Core.Sites.Libraries.Utilities;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;
using Core.Sites.Apps.Web.Modules.FormCompanyConfigs;
using Core.DataBase.ADOProvider.Attributes;
using Core.DataBase.ADOProvider;

namespace Core.Sites.Apps.Web.Modules.FormCompanies
{
    [Script(Src = "/Web/Modules/FormCompanies/js/ManageCompanies.js")]
    [ManageModulePermission(Add = 7, Delete = 9, Edit = 8)]
    [Module]
    public partial class ManageCompanies : ManageModule<Company, ModuleProvider, FormEditCompany>
    {
        [AjaxRequireHasPermission(10)]
        public override void UpdateField()
        {
            var entity = ParseEntity();
            entity.UserLock = PortalContext.CurrentUser.User.UserId;
            entity.Update("UserLock", "IsLock");
        }
    }

    public class ModuleProvider : ManageModuleProvider<Company, int>.Source<Company.DataSource>
    {
        protected override void Save(Company t, List<LogEntity> logEntities, IDataBaseService service)
        {
            t.CreatedBy = PortalContext.CurrentUser.User.UserId;

            if (OldEntity != null)
            {
                if (PortalContext.CurrentUser.GetCurrentCompanyId() != AppSetting.CompanyFullPermission)
                {
                    t.MaxUser = OldEntity.MaxUser;
                    t.DomainUsed = OldEntity.DomainUsed;
                }
            }
            else
            {
                if (PortalContext.CurrentUser.GetCurrentCompanyId() != AppSetting.CompanyFullPermission)
                {
                    t.MaxUser = null;
                    t.DomainUsed = string.Empty;
                }
            }

            t.Save();

            if (true && Module.HasParam("IsLock")) // Thiếu kiểm tra có quyền khóa User
            {
                t.UserLock = t.CreatedBy;
                t.Update("IsLock", "UserLock");
            }

            var config = CompanyConfig.Inst.GetByCompanyId(t.CompanyId);
            if (config == null)
            {
                config = CompanyConfig.Inst.GetByCompanyId(1);
                config.ConfigId = 0;
                config.CompanyId = t.CompanyId;
                config.UseBranch = false;
                config.Save();
            }
        }
        public override Company GetByKey(Company t) => base.GetByKey(t) ?? new Company { };
        protected override void ValidateHelper(Company t)
        {
            if (t.CompanyId != 1) t.ThrowIfNotSelectParent();
            t.ThrowIfExists(c => c.CompanyId, c => c.SubDomain);
            new Company.Tree { }.ThrownIfParentNotValid(t);
            PortalContext.CurrentUser.ThrowIfCompanyIdNotValidWithUserCurrent(t.CompanyId, string.Empty);
        }
        protected override void ValidateDeleteHelper(Company t) { }
    }

    /// <summary>
    /// Label menu công ty => hiển thị số công ty đang có
    /// </summary>
    public class ManageCompaniesMenuLabel : IMenuLabel<MenuItem>
    {
        public string GetText(MenuItem t) => new Company.DataSource { CompanyId = PortalContext.CurrentUser.GetCurrentCompanyId() }.GetTotal().ToString();
    }
}