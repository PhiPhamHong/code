/// <reference path="../../Plugins/jQuery/jQuery-2.1.3.min.js" />
/// <reference path="../../Plugins/linq/linq.min.js" />

$.fn.rebuilddiv = function ()
{
    this.find("[data-rebuild=true]").each(function ()
    {
        var divParent = $(this);
        var stt = divParent.attr("data-stt").split(',');
        var child = divParent.children();

        var divP = divParent;
        Enumerable.From(stt).ForEach(function (item)
        {
            var div = $("<div class='" + divParent.attr("data-" + item) + "'></div>");
            divP.append(div);
            divP = div;
        });

        divP.append(child);
    });
}

$.fn.coreFocus = function(parent)
{
    //parent.scrollTop(parent.scrollTop() + this.position().top - parent.height() / 2 + this.height() / 2);
    parent.animate({ scrollTop: parent.scrollTop() + this.position().top - parent.height() / 2 + this.height() / 2 }, 100);
    return this;
}