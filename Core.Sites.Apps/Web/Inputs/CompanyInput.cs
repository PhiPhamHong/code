using Core.Business.Entities;
using Core.Web.WebBase.HtmlBuilders;
using Core.Extensions;
using System.Collections.Generic;
using Core.Sites.Libraries;
using Core.Sites.Libraries.Business;
using Core.Web.WebBase;
using System.Linq;
using System;

namespace Core.Sites.Apps.Web.Inputs
{
    [SelectFireField(FireField = "CompanyId")]
    public class CompanyInput : SelectModel<Company, CompanyInput>
    {
        protected bool bestUser1 = false; public CompanyInput BestUser1(bool bestUser1) { return Chain(t => t.bestUser1 = bestUser1); }

        protected override List<Company> GetData()
        {
            var tree = new Company.Tree { };
            var user = bestUser1 && PortalContext.Session.IAccountInfo != null ? PortalContext.Session.IAccountInfo.UserLogin1 : PortalContext.CurrentUser.User;
            return (user.CompanyParentId == 0 ? tree.GetInTreeView(0, false) : tree.GetInTreeView(user.CompanyId, true));
        }
        private bool controlEnable = false; public CompanyInput ControlEnable(bool controlEnable) { return Chain(t => t.controlEnable = controlEnable); }
        public override string ToString()
        {
            if (!controlEnable)
            //Enable(PortalContext.Session.AccountInfo.User.CompanyParentId == 0);
            // Chọn giá trị mặc định cho CompanyInput
            if (value == null)
                Value(PortalContext.CurrentUser.GetCurrentCompanyId());
            SetFireChange("CompanyId");

            if (bestUser1 && PortalContext.Session.IAccountInfo != null)
            {
                var config = CompanyConfig.Inst.GetByCompanyIdWithDefault(PortalContext.Session.IAccountInfo.UserLogin1.CompanyId);
                FormGroup.SetShow(config.UseBranch);
            }

            return base.ToString();
        }
        public override void StartWithParent() => FormGroup.SetShow(PortalContext.Config.UseBranch && PortalContext.CurrentUser.CanViewBranchCompany);

        public class AlwaysShow : CompanyInput
        {
            public override void StartWithParent() { }
        }

        public class SelectData : SelectDataAttribute
        {
            public SelectData() : base("CompanyId") { }
            public override bool NeedBuildValue
            {
                get { return true; }
            }
            public override object BuildValue(object value)
            {                
                return PortalContext.CurrentUser.GetCompanyIdAuthen((int)value);
            }
        }
    }
}