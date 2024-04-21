function FormEditNews_SEO()
{
    $.extend(this, new ModuleNormal());
    this.onInit = function (res)
    {
        var data = res.Data.News;

        var type = null;
        switch (res.Data.TypeModule)
        {
            case 0: type = new Type_0(); break;
            case 1: type = new Type_1(); break;
            case 2: type = new Type_2(); break;
        }

        var select = '<select data-use-default="True" name="Link" data-width="100%" data-disable-search="True" data-select-type="select2" class="select2-hidden-accessible">';
        for (var i = 0; i < data.length; i++)
        {
            select += "<option value='" + data[i].Alias + "'>" + (data[i].Title != null ? data[i].Title : data[i].Name) + "</option>";
        }
        select += "</select>";

        var frame = this.getMain().find("iframe");
        frame.height($(window).height() - 180);

        var labelLink = this.getMain().find("[data-link=news]");

        this.getMain().find("[data-select=news]").html(select).benice().find("select").change(function ()
        {
            var link = window.location.host + "/" + $(this).val() + "." + res.Data.Extension;
            link = type.getLink(link);
            labelLink.html(link);
            frame.attr("src", link);

            if (type.popup)
                Core.popup(link, null, $(window).width(), $(window).height());

        }).change();
    }

    var Type_0 = function ()
    {
        this.url = "https://sitechecker.pro/seo-report/";
        this.getLink = function (link) { return this.url + link; };
        this.popup = false;
    }
    var Type_1 = function ()
    {
        this.url = "https://developers.facebook.com/tools/debug/sharing/?q=";
        this.getLink = function (link) { return this.url + link; };
        this.popup = true;
    }
    var Type_2 = function ()
    {
        this.url = "https://www.google.com/webmasters/tools/submit-url";
        this.getLink = function (link) { return this.url; };
        this.popup = true;
    }
}