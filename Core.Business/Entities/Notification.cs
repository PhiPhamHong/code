using System.Linq;
using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider.Attributes;
using Core.Extensions;
using System;
using System.Collections.Generic;
using Core.DataBase.ADOProvider;
using Core.Utility;

namespace Core.Business.Entities
{
    [TableInfo(TableName = "[Notifications]", Name = "Thông báo")]
    public class Notification : MainDb.EntityAuthor<Notification>, IModel<int>
    {
        #region Properties
        [Field(IsKey = true, IsIdentity = true)] public int NotificationId { set; get; }
        [Field(Name = "Tiêu đề"), ValidatorRequire] public string Name { set; get; }
        [Field(Name = "Nội dung")] public string Content { set; get; }
        [Field(Name = "Sử dụng đơn hàng")] public string ShowOrderTypes { set; get; }
        [Field(Name = "Sử dụng tour")] public string ShowTourOrderTypes { set; get; }
        [Field(Name = "Kích hoạt")] public bool IsActive { set; get; }
        [Field(Name = "Loại bảnh báo")] public NotifyType TypeNotify { set; get; }
        [Field(Name = "Bắt buộc xem")] public bool MustView { set; get; }

        public int Key
        {
            get { return NotificationId; }
            set { NotificationId = value; }
        }
        #endregion


        public class DataSource : DataSource<Notification>.Module
        {
            public string Name { set; get; }
            public DateTime? FromDate { set; get; }
            public DateTime? ToDate { set; get; }

            public override List<Notification> GetEntities() => Inst.ExeStoreToList<Notification>("sp_Notifications_GetData", Name, FromDate, ToDate, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>("sp_Notifications_GetData_Count", Name, FromDate, ToDate);
        }

        [TableInfo(TableName = "[Notifications.Users]")]
        public class User : MainDb.Entity<User>
        {
            #region properties
            [Field(IsKey = true, IsIdentity = true)] public int NotificationUserId { set; get; }
            [Field] public int NotificationId { set; get; }
            [Field] public int CompanyId { set; get; }
            [Field] public int UserId { set; get; }
            [Field] public bool Viewed { set; get; }
            [Field] public DateTime? DateViewed { set; get; }
            [Field] public bool Known { set; get; }
            [Field] public DateTime? DateKnown { set; get; }
            #endregion

            public class Item
            {
                public int NotificationId { set; get; }
                [PropertyInfo(Name = "Tiêu đề")] public string Name { set; get; }
                [PropertyInfo(Name = "Nội dung")] public string Content { set; get; }
                [PropertyInfo(Name = "Ngày cập nhật")] public DateTime UpdatedDate { set; get; }
                [PropertyInfo(Name = "Đã biết")] public bool Known { set; get; }
                [PropertyInfo(Name = "Đã xem")] public bool Viewed { set; get; }
                public NotifyType TypeNotify { set; get; }
                public bool MustView { set; get; }
            }

            public static List<Item> LoadByUserId(int userId)
            {
                return Inst.ExeStoreToList<Item>("sp_Notifications_GetByUserId", userId);
            }
            public static void UpdateKnown(int userId)
            {
                Inst.ExeStoreNoneQuery("sp_Notifications_Users_UpdateKnown", userId);
            }
            public static void UpdateViewed(int userId, int notificationId)
            {
                Inst.ExeStoreNoneQuery("sp_Notifications_Users_UpdateViewed", userId, notificationId);
            }

            public class ItemByUser : Item
            {
                [PropertyInfo(Name = "Ngày tạo")] public DateTime? CreatedDate { set; get; }
                public class DataSource : DataSource<ItemByUser>.Module
                {
                    public int UserId { set; get; }

                    public override List<ItemByUser> GetEntities() => Inst.ExeStoreToList<ItemByUser>("sp_Notifications_GetByUserId_Paging", UserId, Start, Length);
                    public override int GetTotal() => Inst.SelectFirstValue<int>("sp_Notifications_GetByUserId_Paging_Count", UserId);
                }
            }
        }

        public enum NotifyType : byte
        {
            [FieldInfo(Name = "Thông báo")] Notify = 0,
            [FieldInfo(Name = "Cảnh báo")] Warning = 1,
            [FieldInfo(Name = "Tin tức")] News = 2
        }
    }
}