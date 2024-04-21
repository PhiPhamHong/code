/// <reference path="../Scripts/Popup.js" />
/// <reference path="../Plugins/linq/linq.min.js" />

function FormPopupItems() {
    $.extend(this, new Popup()); this.module = "";
    this.fieldId = "";
    // danh sách các id cần được check trên checkbox => ý là các id này đang được chọn
    this.Ids = [];

    this.title = "Danh sách";
    this.dialogType = "modal-lg";

    this.IdsAdded = [];
    this.IdsDeleted = [];

    this.currentModule = null;

    this.afterLoadControl = function (res, module) {
        var $this = this;
        $this.currentModule = module;
        module.onBeforeInitGrid(function (table) {
            // Sự kiện sau khi bind xong dữ liệu trên lưới
            table.afterDraw = function () {
                $this.bindCheckbox(table, $this.Ids, true);
                $this.bindCheckbox(table, $this.IdsAdded, true);
                $this.bindCheckbox(table, $this.IdsDeleted, false);
            }

            table.DoChoose = function (data) {
                var chk = table.table.find("[data-chk-name=" + $this.fieldId + "][value=" + data[$this.fieldId] + "]");
                chk.iCheck(!chk.is(':checked') ? "check" : "uncheck");
                table.Choose(data);
            }

            table.Choose = function (data) {
                var chk = table.table.find("[data-chk-name=" + $this.fieldId + "][value=" + data[$this.fieldId] + "]");                
                if (chk.is(':checked')) {
                    // Nếu id này nằm ở trong danh sách ban đầu khởi tạo
                    // mà lại chuyển thành được chọn, có nghĩa là khả năng trước đó bị bỏ chọn
                    // xong rùi lại chọn lại
                    // Vì vậy chỉ cần gỡ bỏ id này ở danh sách các id bị gỡ bỏ
                    if (Enumerable.From($this.Ids).Contains(data[$this.fieldId])) $this.IdsDeleted.destroy(data[$this.fieldId]);

                    // Còn ngược lại id này là chưa có ở danh sách lúc đầu khởi tạo
                    // thì nghĩa là id mới được chọn
                    else $this.IdsAdded.push(data[$this.fieldId]);
                }
                else {
                    // Nếu id này nằm ở danh sách ban đầu khởi tạo
                    // mà lại bị bỏ chọn, thì id đó sẽ được đưa vào danh sách các id cần bị gỡ bỏ
                    debugger
                    if (Enumerable.From($this.Ids).Contains(data[$this.fieldId])) $this.IdsDeleted.push(data[$this.fieldId]);

                    // Còn ngược lại id này chưa có ở danh sách khởi tạo ban đầu
                        // thì khả năng là id được chọn mà lại gỡ đi
                        
                    else $this.IdsAdded.destroy(data[$this.fieldId]);
                }
            }
        });
    }

    this.bindCheckbox = function (table, ids, checked) {
        Enumerable.From(ids).Join(table.table.find("[data-chk-name=" + this.fieldId + "]"),
            function (id) { return id + ""; },
            function (chk) { return $(chk).attr("value"); },
            function (id, chk) { $(chk).iCheck(checked ? "check" : "uncheck"); }).Count();
    }

    this.buttons.push({ value: "Chọn", cls: "btn btn-primary pull-left", func: function (element, scope) { scope.onOk(); scope.hide(); } });
    this.onOk = function () { }
}


$(document).ready(function () {
    console.log('%c Dừng lại!', 'background: #fff; color: red; font-size:85px; font-weight:900');
    console.log('%c Đây là một tính năng của trình duyệt dành cho các nhà phát triển. Nếu ai đó bảo bạn sao chép-dán nội dung nào đó vào đây để bật một tính năng của chúng tôi hoặc hack tài khoản của người khác, thì đó là hành vi lừa đảo và sẽ khiến họ có thể truy cập vào tài khoản và đánh cắp dữ liệu của bạn.', 'background: #fff; font-size:20px');
});