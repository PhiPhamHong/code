using System.Data;

namespace Core.Web.WebBase
{
    public interface IUserLogin
    {
        int UserId { get; }
        int CompanyId { get; }
        string EmployeeCode { get; }
        int CompanyParentId { get; }
        string Avatar { get; }
        string FullName { get; }
        string Email { get; }
        string Phone { get; }
        string UserName { get; }
        bool IsAdmin { get; }
        string Password { get; }
        int TotalLoginFail { get; }
        int PartnerId { get; }
        void ParseFrom(DataRow dr);

        DataTable DoLogin(string userName, string domain);
        bool GetByKey();
    }
}