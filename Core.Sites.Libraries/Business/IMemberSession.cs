using Core.Business.Entities;
using Core.Business.Enums;
using Core.Web.WebBase;
using System.Collections.Generic;
namespace Core.Sites.Libraries.Business
{
    public interface IMemberSession : IAccount
    {
        IUserLogin UserLogin { get; }
        IUserLogin UserLogin1 { get; }
        IUserLogin UserLogin2 { get; }

        List<int> Permissions();
        User.UserSession.ConfigRuntime Config { get; }

        void Goto(int companyId, int userId);
        void UnGoto();
        void SaveSession();

        SessionType SessionType { get; }
    }

    public static class IMemberSessionExtension
    {
        public static int CompanyId_1(this IMemberSession session) { return session.UserLogin1.CompanyId; }
        public static int CompanyId_2(this IMemberSession session) { return session.UserLogin2 == null ? 0 : session.UserLogin2.CompanyId; }

        public static int User_1(this IMemberSession session) { return session.UserLogin1.UserId; }
        public static int User_2(this IMemberSession session) { return session.UserLogin2 == null ? 0 : session.UserLogin2.UserId; }
    }
}