using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Serialization;

using Core.Utility;
using Core.Utility.Xml;
using Core.Extensions;
using Core.Sites.Libraries.Utilities;
using Core.Business.Enums;

namespace Core.Sites.Libraries.Business
{
    [Serializable]
    [XmlRoot("root")]
    public class MainDashBoard : ConfigBase
    {
        public int UserId { set; get; }
        public SessionType SessionType { set; get; }

        [XmlElement("dashboard")] public List<DashBoardItem> Items { set; get; }

        public List<DashBoardItem> GetItems()
        {
            if (Items == null) Items = new List<DashBoardItem>();
            return Items;
        }

        public override string GetPath()
        {
            switch(SessionType)
            {
                case SessionType.Partner: return HttpContext.Current.Server.MapPath("~/Settings/Projects/" + AppSetting.Project + "/DashBoard/Partners/User_" + UserId + ".config");
                default: return HttpContext.Current.Server.MapPath("~/Settings/Projects/" + AppSetting.Project + "/DashBoard/User_" + UserId + ".config");
            }
        }

        public static MainDashBoard Load(int userId, SessionType sessionType)
        {
            return ReadConfig<MainDashBoard>.Load(t => 
            {
                t.UserId = userId;
                t.SessionType = sessionType;
            });
        }

        public static int GetNextStt(int userId, SessionType sessionType)
        {
            var mdb = Load(userId, sessionType);
            if (mdb.Items == null || mdb.Items.Count == 0) return 1;
            return mdb.Items.Max(item => item.Stt) + 1;
        }

        public static DashBoardItem LoadConfig(int userId, Guid id, SessionType sessionType)
        {
            return Load(userId, sessionType).GetItems().FirstOrDefault(item => item.Id == id) ?? new DashBoardItem { Id = Guid.NewGuid() };
        }

        public static DashBoardItem LoadConfig(int userId, string id, SessionType sessionType) => LoadConfig(userId, id.ToGuid(), sessionType);

        private static void LoadAndSave(int userId, SessionType sessionType, Action<MainDashBoard> action)
        {
            var mdb = Load(userId, sessionType);
            action(mdb);

            mdb.UserId = userId;
            mdb.SessionType = sessionType;
            ReadConfig<MainDashBoard>.Save(mdb);
        }

        public static void Save(int userId, SessionType sessionType, MainDashBoard mdb)
        {
            mdb.UserId = userId;
            mdb.SessionType = sessionType;
            ReadConfig<MainDashBoard>.Save(mdb);
        }

        public static void Save(int userId, SessionType sessionType, DashBoardItem newItem)
        {
            LoadAndSave(userId, sessionType, mdb =>
            {
                var oldItem = mdb.GetItems().FirstOrDefault(item => item.Id == newItem.Id);
                if (oldItem != null) mdb.GetItems().Remove(oldItem);
                mdb.GetItems().Add(newItem);
            });
        }

        public static void Delete(int userId, SessionType sessionType, string id)
        {
            LoadAndSave(userId, sessionType, mdb =>
            {
                var oldItem = mdb.GetItems().FirstOrDefault(item => item.Id == id.ToGuid());
                if (oldItem != null) mdb.GetItems().Remove(oldItem);
            });
        }

        public static void SwithPosition(int userId, SessionType sessionType, string id1, string id2)
        {
            LoadAndSave(userId, sessionType, mdb =>
            {
                var db1 = mdb.GetItems().FirstOrDefault(item => item.Id == id1.ToGuid());
                var db2 = mdb.GetItems().FirstOrDefault(item => item.Id == id2.ToGuid());
                if (db1 != null && db2 != null)
                {
                    var stt1 = db1.Stt;
                    db1.Stt = db2.Stt;
                    db2.Stt = stt1;
                }
            });
        }

        public static void Save(int userId, SessionType sessionType, Guid id, Action<DashBoardItem> actionItem)
        {
            LoadAndSave(userId, sessionType, mdb =>
            {
                var oldItem = mdb.GetItems().FirstOrDefault(item => item.Id == id);
                if (oldItem != null) actionItem(oldItem);
            });
        }

        public static List<Pair<DashBoardItem, CacheUrl.CacheUrlData>> LoadDashBoardConfiged(int userId, SessionType sessionType)
        {
            var dashBoardConfig = Load(PortalContext.CurrentUser.User.UserId, sessionType);
            if (dashBoardConfig.Items == null) return new List<Pair<DashBoardItem, CacheUrl.CacheUrlData>>();

            return dashBoardConfig.Items.Select(dbi => new Pair<DashBoardItem, CacheUrl.CacheUrlData> { T1 = dbi, T2 = dbi.GetCacheDataUrl(sessionType) })
                .OrderBy(pr => pr.T1.Stt)
                .ToList();
        }
    }
}
