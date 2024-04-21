function FormPriceConfig()
{
    $.extend(this, new ModuleBase());
    $.extend(this, new CoreAjax());

    this.typeAction = "Web.Projects.Orthers.PriceConfigs.FormPriceConfig.FormPriceConfig";
    this.init = function () {
        this.getMain().benice();
        this.getMain().bindfunc(this);
    }
    class Config {
        StartDirection;
        EndDirection;
        ProductType;
        ContainerType;
        Price;
    }
    this.Save = function (value, target) {
        var body = $("#Maindata")
        var listConfigs = body.find(".data-config");
        var resData = new Array();
        for (let i = 0; i < listConfigs.length; i++) {
            var cfig = $(listConfigs[i]);
            var data = new Config();
            data.StartDirection = $(cfig).find(".StartPointName")[0].id;
            data.EndDirection = $(cfig).find(".EndPointName")[0].id;
            data.ProductType = $(cfig).find(".ProductTypeName")[0].id;
            data.ContainerType = $(cfig).find(".TranTypeName")[0].id;
            data.Price = $(cfig).find(".Price")[0].value;
            resData.push(data);
        }

        var ajax = new CoreAjax();
        ajax.typeAction = "Web.Projects.Orthers.PriceConfigs.FormPriceConfig.FormPriceConfig";
        ajax.post2("SaveAllData", { resData }, function (res) {
            Core.alert("Cập nhật thành công");
        });
    }
}