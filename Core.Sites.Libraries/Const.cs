using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Sites.Libraries
{
    public class Const
    {
        #region OrderBy
        public const string ASC = "ASC";
        public const string DESC = "DESC";
        #endregion

        #region Message
        public const string M1 = "ConflictForeignKey_CannotDelete_{0}";    // {0} đã được sử dụng. Không thể xóa.
        public const string M2 = "AlreadyCloseBook{0}{1}";                 // Đã chốt sổ {0:Month}/{1:Year} rồi? Không thể cập nhật. Vui lòng thử lại
        public const string M3 = "PleaseEnterBankAccountReceipt";          // Vui lòng nhập tài khoản quỹ cần thu tiền
        public const string M4 = "PleaseEnterBankAccountPayment";          // Vui lòng nhập tài khoản quỹ cần chi tiền
        public const string M7 = "CantEnterAccountNoLikeCo";               // Vui lòng không nhập tài khoản nợ và có trùng nhau
        public const string M8 = "CantEnterBankAccountNoLikeCo";           // Vui lòng không nhập quỹ thu và chi trùng nhau
        public const string M9 = "CantEnterPartnerNoLikeCo";               // Vui lòng không nhập đối tác nợ và có trùng nhau
        public const string M10 = "CantEnterStockNoLikeCo";                // Vui lòng không nhập kho nhập và kho xuất trùng nhau
        public const string M11 = "CantEnterStockPositionNoLikeCo";        // Vui lòng không nhập vị trí kho nhập và xuất trùng nhau
        public const string M12 = "PleaseEnterPartnerToPay";               // Vui lòng nhập đối tác cần chi tiền
        public const string M13 = "PleaseEnterPartnerToReceipt";           // Vui lòng nhập đối tác cần thu tiền
        public const string M14 = "PleaseEnterDetailVoucher";              // Vui lòng nhập chi tiết phiếu
        public const string M15 = "PleaseEnterQuantityInGrid";             // Vui lòng nhập số lượng trên lưới phiếu
        public const string M16 = "PleaseEnterUnitInGrid";                 // Vui lòng nhập đơn vị trên lưới phiếu
        public const string M17 = "PleaseEnterStoreImport";                // Vui lòng nhập kho nhập hàng
        public const string M18 = "PleaseEnterProductInGrid";              // Vui lòng nhập sản phẩm trên lưới
        public const string M19 = "PleaseEnterPartnerBuyProduct";          // Vui lòng nhập khách hàng mua sản phẩm
        public const string M20 = "PleaseEnterPartnerSaleProduct";         // Vui lòng nhập nhà cung cấp muốn trả hàng
        public const string M21 = "PleaseEnterStoreExport";                // Vui lòng nhập kho xuất hàng
        public const string M22 = "CantTransferProductInSameStock";        // Không thể vận chuyển sản phẩm trong cùng một kho
        public const string M23 = "CantTransferProductInSamePosition_{0}"; // Không thể vận chuyển sản phẩm trong cùng một vị trí

        public const string M24 = "CantDeleteStore{0}";                    // Không thể xóa kho {0} vì đã được sử dụng. Vui lòng thử lại.
        public const string M25 = "CantDeleteProductGroup{0}";             // Không thể xóa nhóm sản phẩm {0} vì đã được sử dụng. Vui lòng thử lại.
        public const string M26 = "CantDeleteProductCategory{0}";          // Không thể xóa loại sản phẩm {0} vì đã được sử dụng. Vui lòng thử lại.
        public const string M27 = "CantDeleteAccount{0}";                  // Không thể xóa tài khoản {0} vì đã phát sinh công nợ. Vui lòng thử lại.
        public const string M28 = "CantDeleteBankAccount{0}";              // Không thể xóa tài khoản ngân hàng {0} vì đã phát sinh công nợ. Vui lòng thử lại.
        public const string M29 = "CantDeleteLedgerPurpose{0}";            // Không thể xóa mục đích {0} vì đã được sử dụng. Vui lòng thử lại.
        public const string M30 = "CantUpdateProductMenthodPrice{0}";      // Phương thức tính toán '{0}' đã được sử dụng. Không thể sửa. Vui lòng thử lại.
        

        public const string M31 = "CantDeleteProductUnits{0}";             // Đơn vị cơ bản '{0}' đã được sử dụng. Không thể xóa. Vui lòng thử lại.
        public const string M32 = "CantDeleteProductMenthodPrice{0}";      // Phương thức tính toán '{0}' đã được sử dụng.Không thể xóa. Vui lòng thử lại

        public const string M33 = "CantDeleteProductUnit{0}";              // Đơn vị tính toán '{0}' đã được sử dụng. Không thể sửa. Vui lòng thử lại.
        public const string M34 = "CantUpdateAccount{0}";                  // Không thể sửa tài khoản {0} vì đã phát sinh công nợ. Vui lòng thử lại.
        public const string M35 = "CantDeleteProduct{0}";                  // Không thể xóa sản phẩm {0} vì đã được sử dụng trong đơn hàng. Vui lòng thử lại.

        public const string M36 = "AccountingCodeHasExists";               // Mã tài khoản đã tồn tại
        public const string M37 = "CantDeleteAccountingOfSystem";          // Không thể xóa tài khoản của hệ thống

        public const string M38 = "Machine{0}HasFormulaProduct{1}";        // Máy {0} đã tồn tại công thức sản xuất ra sản phẩm {1} rồi

        public const string M39 = "CantEditStoreVoucher";                  // Không thể cập nhật phiếu kho
        public const string M40 = "PleaseEnterOrderDetail";                // Vui lòng nhập chi tiết thông tin đơn hàng
        public const string M41 = "PleaseEnterProductInOrderDetail";       // Vui lòng nhập đầy đủ sản phẩm cho đơn hàng
        public const string M42 = "PleaseEnterQuantityInOrderDetail";      // Vui lòng nhập số lượng trên lưới đơn hàng
        public const string M43 = "PleaseEnterUnitInOrderDetail";          // Vui lòng nhập đơn vị trên lưới đơn hàng

        public const string M44 = "CantDoThisActionIfNotIsSaler";          // Bạn không thể thực hiện chức năng này nếu như không phải là kinh doanh
        public const string M45 = "CantDoThisActionIfNotIsPlaner";         // Bạn không thể thực hiện chức năng này nếu như không phải là nhân viên kế hoạch

        public const string M46 = "CantDoThisActionBecauseOrderNotCreatedOrSend"; // Đơn hàng chưa được tạo, gửi thì không thể hoàn thành được

        public const string M47 = "M47"; // Bạn không thể hoàn thành đơn hàng được ấn định theo kế hoạch của người khác
        public const string M48 = "M48"; // Bạn không thể thay đổi người bán hàng ở đơn hàng đã hoàn thành

        public const string M49 = "M49"; // Không thể hoàn thành đơn hàng khi đang ở trạng thái lưu tạm
        public const string M50 = "M50"; // Không thể hoàn thành đơn hàng khi đang ở trạng thái gửi điều hành
        public const string M51 = "M51"; // Không thể hoàn thành đơn hàng khi đang ở trạng thái từ chối

        public const string M52 = "M52"; // Bạn không thể nhận đơn hàng khi kinh doanh chưa gửi
        public const string M53 = "M53"; // Bạn không thể thay đổi nhân viên bán hàng
        public const string M54 = "M54"; // Không thể nhận đơn hàng khi đang còn ở trạng thái lưu tạm

        public const string M55 = "M55"; // Không thể nhận đơn hàng khi đang ở trạng thái từ chối từ phòng kế hoạch
        public const string M56 = "M56"; // Đơn hàng đã thành không, không thể tiếp tục nhận

        public const string M57 = "M57"; // Không thể từ chối đơn hàng khi đơn hàng chưa được tạo
        public const string M58 = "M58"; // Không thể từ chối đơn hàng khi đang ở trạng thái lưu tạm
        public const string M59 = "M59"; // Đã từ chối đơn hàng rồi thì không thể từ chối thêm
        public const string M60 = "M60"; // Đơn hàng đã hoàn thành không thể từ chối

        public const string M61 = "M61"; // Bạn không thể gửi đơn hàng hộ người khác
        public const string M62 = "M62"; // Bạn không thể lấy đơn hàng của người khác mà gửi đi được

        public const string M63 = "M63"; // Phòng kế hoạch đã nhận không thể gửi tiếp
        public const string M64 = "M64"; // Phòng kế hoạch đã hoàn thành không thể gửi tiếp
        public const string M65 = "M65"; // Bạn không thể gửi đơn hàng tới chính mình

        public const string M66 = "M66"; // Phòng kế hoạch đã nhận, không thể lưu tạm
        public const string M67 = "M67"; // Phòng kế hoạch đã hoàn thành, không thể lưu tạm
        public const string M68 = "M68"; // Bạn không thể lưu tạm đơn hàng của người khác

        public const string M69 = "M69"; // Vui lòng nhập đơn vị cho sản phẩm
        public const string M70 = "M70"; // Chỉ có đơn hàng ở trạng thái lưu tạm mới có thể xóa được
        public const string M71 = "M71"; // Chỉ có kế hoạch ở trạng thái lưu tạm mới có thể xóa được

        public const string M72 = "M72"; // Vui lòng chọn người gửi
        public const string M73 = "M73"; // Sản phẩm này đã được lên kế hoạch cho đơn hàng.

        public const string M74 = "UserName{0}AleardyLeaderOfGroupUser{1}"; // Tài khoản này đã là trưởng nhóm ở nhóm {1}
        public const string M75 = "CanntAddNewOrderIfNotSalerOfRoomSaler"; // Bạn không thể thêm đơn hàng nếu không phải nhân viên phòng kinh doanh
        public const string M76 = "M76"; // Vui lòng chọn người nhận


        public const string M77 = "PleaseEnterStockRequestDetail";                // Vui lòng nhập chi tiết thông tin phiếu yêu cầu
        public const string M78 = "PleaseEnterProductInStockRequestDetail";       // Vui lòng nhập đầy đủ sản phẩm cho phiếu yêu cầu
        public const string M79 = "PleaseEnterQuantityInStockRequestDetail";      // Vui lòng nhập số lượng trên lưới phiếu yêu cầu
        public const string M80 = "PleaseEnterUnitInStockRequestDetail";          // Vui lòng nhập đơn vị trên lưới phiếu yêu cầu
        public const string M81 = "M81"; // Phiếu đang thực hiện không thể từ chối
        public const string M82 = "M82"; // Không thể thực hiện thao tác nhận phiếu khi đang ở trạng thái đang thực hiện
        public const string M83 = "M83"; // Phiếu yêu cầu đã xác nhận hoàn thành. Không thể xóa phiếu kho được nữa.
        public const string M84 = "M84"; // Chỉ có phiếu yêu cầu sản xuất ở trạng thái lưu tạm mới có thể xóa được
        public const string M85 = "M85"; // Chỉ có phiếu yêu cầu kho ở trạng thái lưu tạm mới có thể xóa được
        public const string M86 = "M86{0}"; // Tên này đã tồn tại. Vui lòng nhập một tên khác
        #endregion




        protected static Dictionary<string, LabelAttribute> GetLabelsHelper() => typeof(Const).GetFields().Select(f =>
        {
            var attrs = f.GetCustomAttributes(true);
            if (attrs.Length == 0) return null;

            var la = attrs[0] as LabelAttribute;

            return new { f, la };
        })
        .Where(fla => fla != null)
        .ToDictionary(fla => fla.f.GetValue(null).ToString(), fla => fla.la);
        public static Dictionary<string, LabelAttribute> Data = GetLabelsHelper();
        public class LabelAttribute : Attribute
        {
            public string Value { set; get; }
        }
    }
}