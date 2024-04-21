using Core.Business.Enums;
using System;
using System.Linq;
using System.Collections.Generic;
using Core.Business.Entities.CRM;
using Core.Business.Entities.ERP;
using Core.Business.Entities.Websites;
using Core.Business.Entities.Others;
using Core.Business.Entities.ERP.Reports;
using Core.Business.Entities.Others.Documents;


namespace Core.Business.Entities
{
    public partial class Per
    {
        protected static List<PermissionAttribute> GetPermissions()
        {            
            return typeof(Per).GetFields().Select(f =>
            {
                var attrs = f.GetCustomAttributes(true);
                if (attrs.Length == 0) return null;

                var pa = attrs[0] as PermissionAttribute;
                pa.PermissionId = Convert.ToInt32(f.GetValue(null));
                return pa;
            }).Where(pa => pa != null).ToList();
        }
        public static List<PermissionAttribute> List = GetPermissions();


        //Hệ thống
        #region Người dùng
        [Permission(Name = "Xem", Description = "Người dùng", SessionType = SessionType.Account)] public const int P_1 = 1;
        [Permission(Name = "Thêm", Description = "Người dùng", SessionType = SessionType.Account)] public const int P_2 = 2;
        [Permission(Name = "Sửa", Description = "Người dùng", SessionType = SessionType.Account)] public const int P_3 = 3;
        [Permission(Name = "Xóa", Description = "Người dùng", SessionType = SessionType.Account)] public const int P_4 = 4;
        [Permission(Name = "Khóa", Description = "Người dùng", SessionType = SessionType.Account)] public const int P_5 = 5;
        [Permission(Name = "Gán quyền", Description = "Người dùng", SessionType = SessionType.Account)] public const int P_18 = 18;
        [Permission(Name = "Tự sửa mật khẩu", Description = "Người dùng", SessionType = SessionType.Account)] public const int P_14500 = 14500;
        [Permission(Name = "Sao chép", Description = "Người dùng", SessionType = SessionType.Account)] public const int P_20901 = 20901;
        [Permission(Name = "Thay thế", Description = "Người dùng", SessionType = SessionType.Account)] public const int P_20902 = 20902;
        [Permission(Name = "Xem chi nhánh", Description = "Người dùng", SessionType = SessionType.Account)] public const int P_20903 = 20903;
        [Permission(Name = "Reset đăng nhập", Description = "Người dùng", SessionType = SessionType.Account)] public const int P_20904 = 20904;
        [Permission(Name = "Quản lý tất cả", Description = "Người dùng", SessionType = SessionType.Account)] public const int P_20905 = 20905;
        
        #endregion
        #region Công ty
        [Permission(Name = "Xem", Description = "Công ty", SessionType = SessionType.Account)] public const int P_6 = 6;
        [Permission(Name = "Thêm", Description = "Công ty", SessionType = SessionType.Account)] public const int P_7 = 7;
        [Permission(Name = "Sửa", Description = "Công ty", SessionType = SessionType.Account)] public const int P_8 = 8;
        [Permission(Name = "Xóa", Description = "Công ty", SessionType = SessionType.Account)] public const int P_9 = 9;
        [Permission(Name = "Khóa", Description = "Công ty", SessionType = SessionType.Account)] public const int P_10 = 10;
        #endregion
        #region Gói dịch vụ
        [Permission(Name = "Xem", Description = "Dịch vụ", SessionType = SessionType.Account)] public const int P_11 = 11;
        [Permission(Name = "Thêm", Description = "Dịch vụ", SessionType = SessionType.Account)] public const int P_12 = 12;
        [Permission(Name = "Sửa", Description = "Dịch vụg", SessionType = SessionType.Account)] public const int P_13 = 13;
        [Permission(Name = "Xóa", Description = "Dịch vụ", SessionType = SessionType.Account)] public const int P_14 = 14;
        [Permission(Name = "Gán quyền", Description = "Dịch vụ", SessionType = SessionType.Account)] public const int P_16 = 16;
        #endregion
        #region Công ty sử dụng dịch vụ
        [Permission(Name = "Xem", Description = "Công ty dùng dịch vụ", SessionType = SessionType.Account)] public const int P_17 = 17;
        [Permission(Name = "Thêm", Description = "Công ty dùng dịch vụ", SessionType = SessionType.Account)] public const int P_19 = 19;
        [Permission(Name = "Sửa", Description = "Công ty dùng dịch vụ", SessionType = SessionType.Account)] public const int P_20 = 20;
        [Permission(Name = "Xóa", Description = "Công ty dùng dịch vụ", SessionType = SessionType.Account)] public const int P_21 = 21;
        #endregion
        #region Từ vựng
        [Permission(Name = "Xem", Description = "Từ vựng ", SessionType = SessionType.Account)] public const int P_2800 = 2800;
        [Permission(Name = "Thêm", Description = "Từ vựng ", SessionType = SessionType.Account)] public const int P_2801 = 2801;
        [Permission(Name = "Sửa", Description = "Từ vựng ", SessionType = SessionType.Account)] public const int P_2802 = 2802;
        [Permission(Name = "Xóa", Description = "Từ vựng ", SessionType = SessionType.Account)] public const int P_2803 = 2803;
        #endregion
        #region Cấu hình
        [Permission(Name = "Sửa", Description = "Cấu hình công ty", SessionType = SessionType.Account)] public const int P_11400 = 11400;
        [Permission(Name = "Cập nhật", Description = "Cấu hình chung", SessionType = SessionType.Account)] public const int P_21200 = 21200;
        [Permission(Name = "Theo dõi nhân viên", Description = "Theo dõi nhân viên", SessionType = SessionType.Account)] public const int P_21000 = 21000;
        #endregion
        #region Báo cáo log đăng nhập, hoạt động
        [Permission(Name = "Xem", Description = "Báo cáo log tác động", SessionType = SessionType.Account)] public const int P_21800 = 21800;
        [Permission(Name = "Xem", Description = "Báo cáo đăng nhập hệ thống", SessionType = SessionType.Account)] public const int P_21801 = 21801;
        #endregion
        #region Thông báo
        [Permission(Name = "Xem", Description = "Thông báo", SessionType = SessionType.Account)] public const int P_22600 = 22600;
        [Permission(Name = "Thêm", Description = "Thông báo", SessionType = SessionType.Account)] public const int P_22601 = 22601;
        [Permission(Name = "Sửa", Description = "Thông báo", SessionType = SessionType.Account)] public const int P_22602 = 22602;
        [Permission(Name = "Xóa", Description = "Thông báo", SessionType = SessionType.Account)] public const int P_22603 = 22603;
        #endregion

        //website
        #region Chuyên mục tin tức
        [Permission(Name = "Xem", Description = "Chuyên mục tin tức", SessionType = SessionType.Account)] public const int P_22700 = 22700;
        [Permission(Name = "Thêm", Description = "Chuyên mục tin tức", SessionType = SessionType.Account)] public const int P_22701 = 22701;
        [Permission(Name = "Sửa", Description = "Chuyên mục tin tức", SessionType = SessionType.Account)] public const int P_22702 = 22702;
        [Permission(Name = "Xóa", Description = "Chuyên mục tin tức", SessionType = SessionType.Account)] public const int P_22703 = 22703;
        #endregion
        #region Tin tức
        [Permission(Name = "Xem", Description = "Tin tức", SessionType = SessionType.Account)] public const int P_22800 = 22800;
        [Permission(Name = "Thêm", Description = "Tin tức", SessionType = SessionType.Account)] public const int P_22801 = 22801;
        [Permission(Name = "Sửa", Description = "Tin tức", SessionType = SessionType.Account)] public const int P_22802 = 22802;
        [Permission(Name = "Xóa", Description = "Tin tức", SessionType = SessionType.Account)] public const int P_22803 = 22803;
        #endregion
        #region Từ vựng chuyển đổi
        [Permission(Name = "Xem", Description = "Từ vựng chuyển đổi", SessionType = SessionType.Account)] public const int P_22900 = 22900;
        [Permission(Name = "Thêm", Description = "Từ vựng chuyển đổi", SessionType = SessionType.Account)] public const int P_22901 = 22901;
        [Permission(Name = "Sửa", Description = "Từ vựng chuyển đổi", SessionType = SessionType.Account)] public const int P_22902 = 22902;
        [Permission(Name = "Xóa", Description = "Từ vựng chuyển đổi", SessionType = SessionType.Account)] public const int P_22903 = 22903;
        #endregion
        #region Thông tin SEO
        [Permission(Name = "Xem", Description = "Thông tin SEO", SessionType = SessionType.Account)] public const int P_23000 = 23000;
        #endregion
        #region Thẻ meta
        [Permission(Name = "Xem", Description = "Thẻ meta", SessionType = SessionType.Account)] public const int P_23100 = 23100;
        [Permission(Name = "Thêm", Description = "Thẻ meta", SessionType = SessionType.Account)] public const int P_23101 = 23101;
        [Permission(Name = "Sửa", Description = "Thẻ meta", SessionType = SessionType.Account)] public const int P_23102 = 23102;
        [Permission(Name = "Xóa", Description = "Thẻ meta", SessionType = SessionType.Account)] public const int P_23103 = 23103;
        #endregion
        #region Đường dẫn trang
        [Permission(Name = "Xem", Description = "Đường dẫn trang", SessionType = SessionType.Account)] public const int P_23200 = 23200;
        [Permission(Name = "Thêm", Description = "Đường dẫn trang", SessionType = SessionType.Account)] public const int P_23201 = 23201;
        [Permission(Name = "Sửa", Description = "Đường dẫn trang", SessionType = SessionType.Account)] public const int P_23202 = 23202;
        [Permission(Name = "Xóa", Description = "Đường dẫn trang", SessionType = SessionType.Account)] public const int P_23203 = 23203;
        #endregion
        #region Đối tác hiển thị
        [Permission(Name = "Xem", Description = "Đối tác show website", SessionType = SessionType.Account)] public const int P_52000 = 52000;
        [Permission(Name = "Thêm", Description = "Đối tác show website", SessionType = SessionType.Account)] public const int P_52001 = 52001;
        [Permission(Name = "Sửa", Description = "Đối tác show website", SessionType = SessionType.Account)] public const int P_52002 = 52002;
        [Permission(Name = "Xóa", Description = "Đối tác show website", SessionType = SessionType.Account)] public const int P_52003 = 52003;
        #endregion
        #region Địa chỉ banner
        [Permission(Name = "Xem", Description = "Địa chỉ banner", SessionType = SessionType.Account)] public const int P_23300 = 23300;
        [Permission(Name = "Thêm", Description = "Địa chỉ banner", SessionType = SessionType.Account)] public const int P_23301 = 23301;
        [Permission(Name = "Sửa", Description = "Địa chỉ banner", SessionType = SessionType.Account)] public const int P_23302 = 23302;
        [Permission(Name = "Xóa", Description = "Địa chỉ banner", SessionType = SessionType.Account)] public const int P_23303 = 23303;
        #endregion
        #region Banner quảng cáo
        [Permission(Name = "Xem", Description = "Banner quảng cáo", SessionType = SessionType.Account)] public const int P_23400 = 23400;
        [Permission(Name = "Thêm", Description = "Banner quảng cáo", SessionType = SessionType.Account)] public const int P_23401 = 23401;
        [Permission(Name = "Sửa", Description = "Banner quảng cáo", SessionType = SessionType.Account)] public const int P_23402 = 23402;
        [Permission(Name = "Xóa", Description = "Banner quảng cáo", SessionType = SessionType.Account)] public const int P_23403 = 23403;
        #endregion
        #region Hashtag
        [Permission(Name = "Xem", Description = nameof(Hashtag), SessionType = SessionType.Account)] public const int P_36000 = 36000;
        [Permission(Name = "Thêm", Description = nameof(Hashtag), SessionType = SessionType.Account)] public const int P_36001 = 36001;
        [Permission(Name = "Sửa", Description = nameof(Hashtag), SessionType = SessionType.Account)] public const int P_36002 = 36002;
        [Permission(Name = "Xóa", Description = nameof(Hashtag), SessionType = SessionType.Account)] public const int P_36003 = 36003;
        #endregion

        //Others
     
        #region Chi phí vận tải
        [Permission(Name = "Xem", Description = nameof(TransportCost), SessionType = SessionType.Account)] public const int P_51000 = 51000;
        [Permission(Name = "Thêm", Description = nameof(TransportCost), SessionType = SessionType.Account)] public const int P_51001 = 51001;
        [Permission(Name = "Sửa", Description = nameof(TransportCost), SessionType = SessionType.Account)] public const int P_51002 = 51002;
        [Permission(Name = "Xóa", Description = nameof(TransportCost), SessionType = SessionType.Account)] public const int P_51003 = 51003;
        #endregion

        #region Quản lý tài liệu
        [Permission(Name = "Xem", Description = nameof(Document), SessionType = SessionType.Account)] public const int P_53000 = 53000;
        [Permission(Name = "Thêm", Description = nameof(Document), SessionType = SessionType.Account)] public const int P_53001 = 53001;
        [Permission(Name = "Sửa", Description = nameof(Document), SessionType = SessionType.Account)] public const int P_53002 = 53002;
        [Permission(Name = "Xóa", Description = nameof(Document), SessionType = SessionType.Account)] public const int P_53003 = 53003;
        #endregion

        #region Tin tức(chia lẻ ngôn ngữ)
        [Permission(Name = "Xem", Description = nameof(New.Content), SessionType = SessionType.Account)] public const int P_76000 = 76000;
        [Permission(Name = "Thêm", Description = nameof(New.Content), SessionType = SessionType.Account)] public const int P_76001 = 76001;
        [Permission(Name = "Sửa", Description = nameof(New.Content), SessionType = SessionType.Account)] public const int P_76002 = 76002;
        [Permission(Name = "Xóa", Description = nameof(New.Content), SessionType = SessionType.Account)] public const int P_76003 = 76003;
        #endregion
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class PermissionAttribute : Attribute
    {
        public int PermissionId { set; get; }
        public SessionType SessionType { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
    }
}
