using Core.Attributes.Validators;
using Core.Sites.Libraries.Business;
using Core.Extensions;
namespace Core.Sites.Libraries.Utilities
{
    public class ValidateUserAttribute : ValidatorAttribute
    {
        public override bool Validate()
        {
            if (Value == null) return false;
            return PortalContext.CurrentUser.CheckValidUserIdWithUserCurrent(Value.To<int>());;
        }

        public override string GetMessage()
        {
            return PortalContext.GetLabel("{0} không hợp lệ").Frmat(FieldName);
        }
    }
}
