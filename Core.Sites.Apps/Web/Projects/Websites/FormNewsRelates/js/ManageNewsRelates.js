function ManageNewsRelates()
{
    $.extend(this, new ModuleGrid());

    this.onBeforeInitGrid(function (table)
    {
        table.lengthBar = "4";

        table.AddNew = function (target, button)
        {
            
            table.post("LoadNewsIds", table.extendDataSearch(), function (res)
            {
                debugger;
                var form = new FormPopupNews();
                form.Ids = res.Data.NewsIds; //danh sách tin tức ban đầu khi load lên sẽ được tick chọn ở các checkbox                
                form.onOk = function () {
                    var dataUpdate =
                    {
                        added: Enumerable.From(form.IdsAdded).ToString(","),     // form.IdsDeleted; danh sách tin tức cần được gỡ bỏ
                        deleted: Enumerable.From(form.IdsDeleted).ToString(",")  // form.IdsAdded  ; danh sách tin tức cần được thêm mới
                    };
                    $.extend(dataUpdate, table.extendDataSearch());
                    table.post("SaveNewsRelate", dataUpdate, function () { table.bindData(0); });
                };
                form.show();
            });
        }
    });
};

function FormPopupNews() {
    $.extend(this, new FormPopupItems());

    this.module = "PopupNews";
    this.title = "Danh sách tin tức";
    this.fieldId = "NewsId";

    this.getNews = function (action) {
        this.currentModule.table.post("GetNewsByIds", { Ids: Enumerable.From(this.IdsAdded).ToString(",") }, function (res) {
            action(res.Data.News);
        });
    }
}