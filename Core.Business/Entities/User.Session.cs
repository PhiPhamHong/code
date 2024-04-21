using Core.Attributes;
using Core.Business.Enums;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Extensions;


namespace Core.Business.Entities
{
    public partial class User
    {
        [TableInfo(TableName = "[Users.Sessions]", Name = "Phiên người dùng")]
        public class UserSession : UserSession<UserSession>
        {
            public override void Save()
            {
                ExeStoreNoneQuery("sp_Users_Sessions_Save");
            }

            public class ConfigRuntime
            {
                [PropertyIndex(Index = 0)] public int LanguageId { set; get; }
                [PropertyIndex(Index = 1), PropertyInfo(Name = "Trên menu theo")] public ETimeForLabelMenuItem TimeForLabelMenuItem { set; get; }
                [PropertyIndex(Index = 2), PropertyInfo(Name = "Màu nền menu")] public ColorSystem ColorMenuGroup { set; get; }
                [PropertyIndex(Index = 3), PropertyInfo(Name = "Tự chọn")] public string ColorMenuGroupCustom { set; get; }
                [PropertyIndex(Index = 4), PropertyInfo(Name = "Sử dụng menu sổ xuống")] public bool UseMenuDropdown { set; get; }
                [PropertyIndex(Index = 5), PropertyInfo(Name = "Công ty")] public int Broadcasting_To_CompanyId { set; get; }
                [PropertyIndex(Index = 5), PropertyInfo(Name = "Người dùng")] public int Broadcasting_To_UserId { set; get; }
            }

            public enum ETimeForLabelMenuItem : byte
            {
                [FieldInfo(Name = "Thống kê trong tháng")] Month = 0,
                [FieldInfo(Name = "Thống kê trong tuần")] Week = 1
            }
        }

        public class UserSession<TUserSession> : MainDb.Entity<TUserSession>, IUserSession where TUserSession : ModelBase, IUserSession, new()
        {
            #region Properties
            [Field(IsKey = true)] public int UserId { set; get; }
            [Field] public string Session { set; get; }
            #endregion

            public static void SaveSession(int userId, UserSession.ConfigRuntime configRuntime) 
            {
                var userSession = new TUserSession { UserId = userId, Session = configRuntime.SerializeToString() };
                userSession.Save();
            }
            public UserSession.ConfigRuntime GetSession(int userId)
            {                
                var us = SelectFirst(u => u.UserId == userId);
                if (us == null) return new UserSession.ConfigRuntime();
                return us.Session.Deserialize<UserSession.ConfigRuntime>();
            }
        }

        public interface IUserSession
        {
            int UserId { set; get; }
            string Session { set; get; }
        }
    }
}