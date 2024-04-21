function alertType() { }
alertType.alertDanger = { css: "alert-danger", icon: "icon fa fa-ban", type: "error" };
alertType.alertInfo = { css: "alert-info", icon: "icon fa fa-ban", type: "info" };
alertType.alertWarning = { css: "alert-warning", icon: "icon fa fa-warning", type: "warning" };
alertType.alertSuccess = { css: "alert-success", icon: "icon fa fa-check", type: "success" };

$.fn.coreAlert = function (msg, title, timeOut, type) {
    type = type == null ? alertType.alertInfo : type;
    var html = '<div class="alert ' + type.css + ' alert-dismissable alert-small fade in">';
    html += '<button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>';
    if (title != null && title != '')
        html += '<h4>	<i class="' + type.icon + '"></i> ' + Core.getLabel(title) + '!</h4>';
    html += Core.getLabel(msg);
    html += '</div>';

    this.append(html);
    var alerts = this.find('.alert').on("closed.bs.alert", function () { $(this).remove(); }).alert();

    if (timeOut == -1) return;
    setTimeout(function () { alerts.alert('close'); }, timeOut == null || timeOut == 0 ? 3000 : timeOut);
};