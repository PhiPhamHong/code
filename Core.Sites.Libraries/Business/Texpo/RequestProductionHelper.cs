using System;
using System.Linq;
using Core.Extensions;
using Core.Utility;

namespace Core.Sites.Libraries.Business.Texpo
{
    public class RequestProductionHelper
    {
        public static string CreateRequestCode(Func<int, DateTime, string> getLastestRequestCodeByUser)
        {
            var lastestBillNo = getLastestRequestCodeByUser(PortalContext.CurrentUser.User.UserId, DateTime.Now);
            return CreateRequestCodeHelper(lastestBillNo.IsNull() ? "01" : (lastestBillNo.Split('.').Last().To<int>() + 1).AddZezo());
        }

        protected static string CreateRequestCodeHelper(string code)
        {
            return RequestCodeTemplate.Frmat(Prefix,
                Singleton<Random>.Inst.Next(0, 10).AddZezo(),
                PortalContext.CurrentUser.User.EmployeeCode,
                DateTime.Now.ToString("dd.MM.yy"), code);
        }

        private const string Prefix = "RP";
        private const string RequestCodeTemplate = "{0}.{1}.{2}.{3}.{4}"; // 0: Prefix, 1: Random, 2: UserCode, 3: yy, 4: số tự tăng
    }
}
