using Core.Business.Entities.Texpo;
using Core.Extensions;
using Core.Utility;
using System;
using System.Linq;
namespace Core.Sites.Libraries.Business.Texpo
{
    public class OrderHelper
    {
        public static string CreateOrderCode(Order.Type type, Func<int, DateTime, Order.Type, string> getLastestOrderCodeByUser)
        {
            var lastestBillNo = getLastestOrderCodeByUser(PortalContext.CurrentUser.User.UserId, DateTime.Now, type);
            return CreateOrderCodeHelper(lastestBillNo.IsNull() ? "01" : (lastestBillNo.Split('.').Last().To<int>() + 1).AddZezo(), type);
        }

        protected static string CreateOrderCodeHelper(string code, Order.Type type)
        {
            return OrderCodeTemplate.Frmat(
                EnumHelper<Order.Type, Order.TypeAttribute>.Inst.GetAttribute(type).Prefix,                
                Singleton<Random>.Inst.Next(0, 10).AddZezo(), PortalContext.CurrentUser.User.EmployeeCode, DateTime.Now.ToString("dd.MM.yy"), code);
        }
        private const string OrderCodeTemplate = "{0}.{1}.{2}.{3}.{4}"; // 0: Prefix, 1: Random, 2: UserCode, 3: yy, 4: số tự tăng
    }
}