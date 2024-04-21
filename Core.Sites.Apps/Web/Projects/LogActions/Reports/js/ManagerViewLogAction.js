/// <reference path="../../../../Resources/Plugins/jQuery/jQuery-2.1.3.min.js" />

function ManagerViewLogAction() 
{
    var $this = this;
    $.extend(this, new ModuleGrid({ scrollX: true, scrollY: $(window).height() - 310 }));
    $this.onBeforeInitGrid(function (table) 
    {
        table.ShowDetail = function (data) 
        {
            var popup = new Popup();
            popup.dialogType = "modal-lg-super";
            //popup.fullScreen = true;
            popup.module = "FromViewLogActionDetail";
            popup.data = data;
            popup.title = Core.getLabel("Chi tiết log người dùng <span class='text-red'>{0}</span> đã thực hiện thao tác").format(data.FullName);
            popup.show();
        }
        table.contentCreated = function (td, cellData, rowData, row, col)
        {
            var content = $.parseJSON(rowData.Description);
            var html = "<div class='log-view-title' " + (content.TypeConrete == null || content.TypeConrete == "" ? "" : "data-type='" + content.TypeConrete + "'") + ">";
            html += content.Title + " <span class='name'>" + content.Name + "</span>";
            if (content.KeyConcrete == null || content.KeyConcrete == 0) 
            {
                if (content.NameConcrete != null && content.NameConcrete != "")
                    html += " <span class='cname text-green'>" + content.NameConcrete + "</span>";
            }
            else
                html += " <span class=\"ckey text-green\" data-o=\"" + content.KeyConcrete + "\" ></span>";
            html += "<span class=\"hide\">" + content.ExtendData + "</span>";
            html += "</div>";
            $(td).html(html);
        }
        table.afterDraw = function()
        {
            FromViewLogActionDetail.build(table.gridContainer);
            table.gridContainer.find("td.ip").each(function () 
            {
                var td = $(this);
                var ip = td.find("span").html();
                $.getJSON("http://ip-api.com/json/" + ip, function(data) 
                {
                    if (data.city != null && data.country != null)
                        td.find("span").html(data.city + ", " + data.country);
	            });
            });
        }
        table.topInputSearch = 5;
        table.lengthBar = "3";
    });
}