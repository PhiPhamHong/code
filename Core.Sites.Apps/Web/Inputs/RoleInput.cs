using Core.Sites.Libraries.Business;
using Core.Business.Entities;
using Core.Web.WebBase.HtmlBuilders;
namespace Core.Sites.Apps.Web.Inputs
{
    public class RoleInput : SelectModel<Role, RoleInput>
    {
        public IFormGroup FormGroupParent { set; get; }
        new public void StartWithParent()
        {
            FormGroupParent.SetShow(true);
        }
    }
}