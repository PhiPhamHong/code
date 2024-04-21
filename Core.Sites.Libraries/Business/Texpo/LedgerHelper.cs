using Core.Business.Entities.Texpo;
using Core.Extensions;
using Core.Utility;
using System;
using System.Linq;
namespace Core.Sites.Libraries.Business.Texpo
{
    public class LedgerHelper
    {
        public static string CreateBillNo(Ledger.Type type, Ledger.ModuleType moduleType, Func<int, DateTime, Ledger.Type, Ledger.ModuleType, string> getLastestBillNoByUser)
        {
            var lastestBillNo = getLastestBillNoByUser(PortalContext.CurrentUser.User.UserId, DateTime.Now, type, moduleType);
            return CreateBillNoHelper(lastestBillNo.IsNull() ? "01" : (lastestBillNo.Split('.').Last().To<int>() + 1).AddZezo(), type, moduleType);
        }

        protected static string CreateBillNoHelper(string code, Ledger.Type type, Ledger.ModuleType moduleType)
        {
            return BillNoTemplate.Frmat(
                EnumHelper<Ledger.Type, Ledger.TypeAttribute>.Inst.GetAttribute(type).Prefix +
                EnumHelper<Ledger.ModuleType, Ledger.ModuleTypeAttribute>.Inst.GetAttribute(moduleType).Prefix,
                Singleton<Random>.Inst.Next(0, 10).AddZezo(), PortalContext.CurrentUser.User.EmployeeCode, DateTime.Now.ToString("dd.MM.yy"), code);
        }
        private const string BillNoTemplate = "{0}.{1}.{2}.{3}.{4}"; // 0: Prefix, 1: Random, 2: UserCode, 3: yy, 4: số tự tăng
    }
}