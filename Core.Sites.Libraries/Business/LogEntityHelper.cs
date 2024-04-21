using Core.Business.Entities.Log;
using Core.DataBase.ADOProvider.Attributes;
using Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Web.Extensions;
namespace Core.Sites.Libraries.Business
{
    public class LogEntityHelper
    {
        public static void Save(List<LogEntity> logEntities, bool checkWhenOneLog)
        {
            if (logEntities.Count == 0) return;
            if (checkWhenOneLog && logEntities.Count == 1 && logEntities[0].Details.Count == 0) return;

            var log = Log.New;
            log.DateInsert = DateTime.Now;

            log.UserId = PortalContext.Session.IAccountInfo.UserLogin1.UserId;
            log.CompanyId = PortalContext.Session.IAccountInfo.UserLogin1.CompanyId;

            log.Description = logEntities.First().ToJson2();
            log.Content = logEntities.ToJson2();
            log.Ip = HttpContext.Current.Request.GetVisitorIPAddress();
            log.Insert();
        }
    }
}
