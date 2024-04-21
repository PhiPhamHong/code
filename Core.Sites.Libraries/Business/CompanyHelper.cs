using System.Collections.Generic;
using Core.Business.Entities;
using Core.DataBase.ADOProvider;
using Core.Business.Enums;

namespace Core.Sites.Libraries.Business
{
    public class CompanyHelper
    {
        /// <summary>
        /// Lấy ra danh sách tập quyền của công ty
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public static List<PermissionAttribute> GetPermissionOfCompany(int companyId)
        {
            // Công ty tổng thì full quyền
            if (companyId == AppSetting.CompanyFullPermission) return Per.Get(SessionType.Account);

            // Ngược lại lấy theo dịch vụ mà công ty đang dùng xem có tập quyền gì
            
            return Per.GetPermissionOfCompany(companyId);
        }
    }
}