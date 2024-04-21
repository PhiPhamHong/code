using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
namespace Core.Utility.WcfManager
{
    public abstract class HostUserNamePasswordValidator : UserNamePasswordValidator
    {
        sealed public override void Validate(string userName, string password)
        {
            if (!DoAuthen(userName, password))
                throw new SecurityTokenException("Không đúng tài khoản. Vui lòng kiểm tra lại!");
        }

        protected abstract bool DoAuthen(string userName, string password);
    }
}
