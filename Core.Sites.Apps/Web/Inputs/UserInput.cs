using Core.Business.Entities;
using Core.Web.WebBase.HtmlBuilders;
using System.Linq;
using System.Collections.Generic;
using Core.Sites.Libraries.Business;
using Core.Extensions;
using Core.Web.WebBase;
using Core.Sites.Apps.Web.Modules.FormUsers;
using System;

namespace Core.Sites.Apps.Web.Inputs
{
    public class UserInput : SelectModel<User, UserInput>
    {
        private int _excludeUser = 1; [SelectData("ExcludeUser")]
        protected int excludeUser
        {
            set { _excludeUser = 1; }
            get { return _excludeUser; }
        }
        public UserInput ExcludeUser(int excludeUser) { return Chain(t => t.excludeUser = excludeUser); }

        [CompanyInput.SelectData] protected int companyId { set; get; }
        public UserInput CompanyId(int companyId) { return Chain(t => t.companyId = companyId); }

        #region Lấy người dùng theo nhóm 
        [SelectData("ByGroup")] protected bool byGroup { set; get; }
        public UserInput ByGroup(bool byGroup) { return Chain(t => t.byGroup = byGroup); }

        [GroupUserInput.SelectData] protected int groupId { set; get; }
        public UserInput GroupId(int groupId) { return Chain(t => t.groupId = groupId); }

        [SelectData("Date")] protected DateTime? date { set; get; }
        public UserInput Date(DateTime? date) { return Chain(t => t.date = date); }
        #endregion

        // [SelectData("FixUserId")]
        protected int fixUserId { set; get; }
        public UserInput FixUserId(int fixUserId) { return Chain(t => t.fixUserId = fixUserId); }

        protected override List<User> GetData()
        {
            var data = byGroup ? User.GetByGroupId(groupId, date == null ? DateTime.Now : date.Value) :
                                 User.Inst.SelectToList(u => u.CompanyId == companyId);

            if (fixUserId > 0)
            {
                var findUser = data.FirstOrDefault(u => u.UserId == fixUserId);
                if (findUser == null)
                {
                    findUser = new User { UserId = fixUserId };
                    findUser.GetByKey();
                    data.Insert(0, findUser);
                }
            }

            if (excludeUser != 0) data = data.Where(u => u.UserId != excludeUser).ToList();
            return data;
        }

        protected override IManageModulePermission GetManageModule()
        {
            return new ManageUsers();
        }

        public override string ToString()
        {
            if (PortalContext.HasPermission(Per.P_18)) AddMenuItem("Phân quyền", "assignPermission", "fa fa-key", "text-aqua");            
            if (PortalContext.HasPermission(Per.P_20901)) AddMenuItem("Sao chép", "createDashBoard", "fa fa-copy", "text-navy");
            if (PortalContext.HasPermission(Per.P_20904)) AddMenuItem("Reset đăng nhập", "resetLogin", "fa fa-recycle", "text-purple");

            return base.ToString();
        }
    }
}