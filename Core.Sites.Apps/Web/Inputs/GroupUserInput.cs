using Core.Business.Entities;
using Core.Sites.Apps.Web.Modules.FormGroupUsers;
using Core.Web.WebBase;
using Core.Web.WebBase.HtmlBuilders;
using Core.Extensions;
using System;
using System.Linq;
using System.Collections.Generic;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries;

namespace Core.Sites.Apps.Web.Inputs
{
    public class GroupUserInput : SelectModel<GroupUser, GroupUserInput>, IAjax
    {
        [CompanyInput.SelectData] protected int companyId { set; get; }
        public GroupUserInput CompanyId(int companyId) { return Chain(t => t.companyId = companyId); }

        [SelectDataAttribute("GroupType")] protected GroupUser.EType groupType { set; get; }
        public GroupUserInput GroupType(GroupUser.EType groupType) { return Chain(t => t.groupType = groupType); }

        #region Các thuộc tính dùng cho việc lấy nhóm theo người dùng
        [SelectDataAttribute("ByUser")] protected bool byUser { set; get; }
        public GroupUserInput ByUser(bool byUser) { return Chain(t => t.byUser = byUser); }

        [SelectDataAttribute("UserId")] protected int userId { set; get; }
        public GroupUserInput UserId(int userId) { return Chain(t => t.userId = userId); }

        [SelectDataAttribute("Date")] protected DateTime? date { set; get; }
        public GroupUserInput Date(DateTime? date) { return Chain(t => t.date = date); }
        #endregion

        // [SelectDataAttribute("FixGroupId")]
        protected int fixGroupId { set; get; }
        public GroupUserInput FixGroupId(int fixGroupId) { return Chain(t => t.fixGroupId = fixGroupId); }

        protected override List<GroupUser> GetData()
        {
            if (userId == 0) userId = PortalContext.CurrentUser.User.UserId;

            var data = !byUser || userId == AppSetting.UserIdAdmin ?
                GroupUser.GetData(companyId, Query, groupType, 0, int.MaxValue, "Name", string.Empty) :
                GroupUser.GetByUserId(userId, groupType, date == null ? DateTime.Now : date.Value);

            if(fixGroupId > 0)
            {
                var findGroup = data.FirstOrDefault(g => g.GroupId == fixGroupId);
                if(findGroup == null)
                {
                    findGroup = new GroupUser { GroupId = fixGroupId };
                    findGroup.GetByKey();
                    data.Insert(0, findGroup);
                }
            }

            return data;
        }

        protected override IManageModulePermission GetManageModule()
        {
            return new ManageGroupUsers();
        }

        protected string fireField { set; get; }
        public GroupUserInput FireField(string fireField) => Chain(t => t.fireField = fireField);

        public override string ToString()
        {
            SetFireChange(fireField.IsNull() ? "GroupId" : fireField);
            return base.ToString();
        }

        public class SelectData : SelectDataAttribute
        {
            public SelectData() : base("GroupId") { }
        }
    }
}