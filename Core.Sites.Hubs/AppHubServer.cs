using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Core.Extensions;
namespace Core.Sites.Hubs
{
    public class AppHubServer
    {
        private ConcurrentDictionary<int, AppHub.Company> Companies = new ConcurrentDictionary<int, AppHub.Company>();

        public AppHub.UserState RemoveByConnectionId(string connectionId)
        {
            return Companies.RemoveByConnectionId(connectionId);
        }
        public AppHub.UserState NewConnectionId(string connectionId, int companyId, AppHub.UserState u)
        {
            return Companies.GetOrNew(companyId, c => c.CompanyId = companyId).NewConnectionId(connectionId, u);
        }
        public AppHub.UserState GetByConnectionId(string connectionId) { return Companies.FindByConnectionId(connectionId); }
        public AppHub.UserState UpdateByConnectionId(string connectionId, Action<AppHub.UserState> action)
        {
            var u = Companies.FindByConnectionId(connectionId);
            if (u != null) action(u);
            return u;
        }

        public IEnumerable<AppHub.UserState> GetByCompany(int companyId)
        {
            var company = Companies.TryGet(companyId);
            if (company != null)
            {
                foreach (var kv in company.Users)
                    yield return kv.Value;
            }
        }
    }
}