namespace Core.Web.WebBase
{
    public interface IAccount
    {
        bool GetAccount(object key);

        string GetKey();

        bool Login(string userName, string password);
    }
}
