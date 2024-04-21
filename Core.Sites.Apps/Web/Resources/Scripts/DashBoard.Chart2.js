DashBoard.ChartBase = function ()
{
    $.extend(this, new DashBoard.ControlByOption());

    this.label = "";
    this.tooltipLabel = "";
    this.fieldData = ""; // res.Data.Summaries => this.fieldData = "Summaries"
    this.fieldKey = "";  // res.Data.Summaries[0].Month => this.fieldKey = "Month"
    // res.Data.Summaries[0].Total => this.fieldValues = [{field: "Total"}] 
    // Ngoài ra các tham số khác sẽ là api trong Chartjs: [{field: "Total", fieldBgColor: "", fill: false, backgroundColor: "", v.v.... }]
    // Dữ liệu trả về có thể có nhiều trường dữ liệu.Nếu như muốn biểu đồ cho nhiều dataset khác nhau
    this.fieldValues = [];

    this.type = ''; // bar, line

    var chart = null;
    var dataOfChart = null;

    this.bindData = function (res)
    {
        var $this = this;

        if (dataOfChart == null) dataOfChart = {};

        $this.fieldValues = typeof ($this.fieldValues) == "function" ? $this.fieldValues() : $this.fieldValues;

        dataOfChart.labels = [];
        dataOfChart.datasets = Enumerable.From($this.fieldValues).Select(function (fv) {
            var ds = { data: [], backgroundColor: [] };
            $.extend(ds, fv);
            $this.onCreateDataSet(ds, fv); return ds;
        }).ToArray();

        Enumerable
            .From(res.Data[$this.fieldData])
            .ForEach(function (item) {
                if ($this.label != "") dataOfChart.labels.push($this.label + " " + item[$this.fieldKey]);
                else dataOfChart.labels.push(item[$this.fieldKey]);
                Enumerable.From($this.fieldValues).ForEach(function (fv, index) {
                    dataOfChart.datasets[index].data.push(item[fv.field]);
                    if (fv.fieldBgColor != null && fv.fieldBgColor != "")
                        dataOfChart.datasets[index].backgroundColor.push(item[fv.fieldBgColor]);
                });
            });

        if (chart == null) {
            var ctx = this.target.main.find("canvas")[0].getContext('2d');
            var config = {};
            if (this.type != "") config.type = this.type;
            else {
                if (this.config.ChartType != null) {
                    switch (this.config.ChartType) {
                        case 0: config.type = "bar"; break;
                        case 1: config.type = "line"; break;
                        case 2: config.type = "pie"; break;
                    }
                }
                else config.type = "line";
            }
            config.data = dataOfChart;
            config.options = {};

            //if (dataOfChart.datasets.length == 1) config.options.legend = { display: false };
            this.onCreateOptions(config, res);
            
            chart = new Chart(ctx, config);
        }
        else chart.update();
    }

    this.onCreateOptions = function (op) { };
    this.onCreateDataSet = function (ds, fv) { };
}
DashBoard.Chart = function ()
{
    $.extend(this, new DashBoard.ChartBase());
    this.onCreateOptions = function (config)
    {        
        var $this = this;
        if (config.data.datasets.length == 1) config.options.legend = { display: false };
        config.options.scales = {
            yAxes: [{
                ticks: {
                    callback: function (label, index, labels) { return label.formatMoney(0); }
                },
                //scaleLabel: { display: true, labelString: '1k = 1000' }
            }]
        };
        config.options.tooltips = {
            callbacks: {
                label: function (tooltipItem, data)
                {
                    return data.datasets[tooltipItem.datasetIndex].label + ": " + tooltipItem.yLabel.formatMoney(0);                        
                },
                title: function (tooltipItems, data)
                {
                    if ($this.tooltipLabel != "") return $this.tooltipLabel + " " + tooltipItems[0].label;
                    return tooltipItems[0].label;
                }
            }
        };
    };
}

Chart.pluginService.register({
    beforeDraw: function (chart)
    {
        if (chart.config.options.elements.center)
        {
            //Get ctx from string
            var ctx = chart.chart.ctx;

            //Get options from the center object in options
            var centerConfig = chart.config.options.elements.center;
            var fontStyle = centerConfig.fontStyle || 'Arial';
            var txt = centerConfig.text;
            var color = centerConfig.color || '#000';
            var sidePadding = centerConfig.sidePadding || 20;
            var sidePaddingCalculated = (sidePadding / 100) * (chart.innerRadius * 2);
            //Start with a base font of 30px
            ctx.font = "30px " + fontStyle;

            //Get the width of the string and also the width of the element minus 10 to give it 5px side padding
            var stringWidth = ctx.measureText(txt).width;
            var elementWidth = (chart.innerRadius * 2) - sidePaddingCalculated;

            // Find out how much the font can grow in width.
            var widthRatio = elementWidth / stringWidth;
            var newFontSize = Math.floor(30 * widthRatio);
            var elementHeight = (chart.innerRadius * 2);

            // Pick a new font size so it will not be larger than the height of label.
            var fontSizeToUse = Math.min(newFontSize, elementHeight);

            //Set font settings to draw it correctly.
            ctx.textAlign = 'center';
            ctx.textBaseline = 'middle';
            var centerX = ((chart.chartArea.left + chart.chartArea.right) / 2);
            var centerY = ((chart.chartArea.top + chart.chartArea.bottom) / 2);
            ctx.font = fontSizeToUse + "px " + fontStyle;
            ctx.fillStyle = color;

            //Draw text in center
            ctx.fillText(txt, centerX, centerY);
        }
    }
});

DashBoard.CharPie = function ()
{
    $.extend(this, new DashBoard.ChartBase());
    this.type = "pie"; // doughnut

    // Ngoài ra các tham số khác sẽ là api trong Chartjs: [{field: "Total", fieldBgColor: "", fill: false, backgroundColor: "", v.v.... }]
    // Dữ liệu trả về có thể có nhiều trường dữ liệu.Nếu như muốn biểu đồ cho nhiều dataset khác nhau
    // this.fieldValues = [];
    // Ở chart pie thì biểu fieldValues mở rộng thêm : {fieldId: "", fieldName: "" } => Để hiển thị ở progessBar

    this.baseBindData = this.bindData;
    this.bindData = function (res)
    {
        var $this = this;

        this.baseBindData.bind(this)(res);

        // Thực hiện Bind html progress

        // Kiểm tra xem đã đủ progressBar chưa.
        // Nếu chưa đủ thì tiến hành thêm
        var progressArea = this.target.main.find(".progress-area");
        var progressLines = progressArea.find(".progress-group");
        var fieldValue = this.fieldValues[0];

        // Những trạng thái cần thêm mới
        var newStates = Enumerable.From(res.Data[$this.fieldData])
            .GroupJoin(progressLines,
                function (item) { return item[fieldValue.fieldId] + ""; },
                function (pl) { return $(pl).attr("data-state"); },
                function (item, pls) { return { item: item, pls: pls.ToArray() }; })
            .Where(function (r) { return r.pls.length == 0; })
            .ToArray();

        Enumerable.From(newStates).ForEach(function (r)
        {
            var progressGroup = $this.target.main.find(".progress-template").find(".progress-group").clone();
            progressArea.append(progressGroup);
            
            progressGroup.attr("data-state", r.item[fieldValue.fieldId]);
            progressGroup.find(".progress-text").html(r.item[fieldValue.fieldName]);
        });

        // Những trạng thái cần thực hiện xóa
        var removeStates = Enumerable.From(progressLines)
            .GroupJoin(res.Data[$this.fieldData],
                function (pl) { return $(pl).attr("data-state"); },
                function (item) { return item[fieldValue.fieldId] + ""; },
                function (pl, items) { return { pl: pl, items: items.ToArray() }; })
            .Where(function (r) { return r.items.length == 0; })
            .ToArray();

        Enumerable.From(removeStates).ForEach(function (r) { $(r.pl).remove(); });

        var showTotal = progressArea.attr("data-show-total") == "True";
        var total = Enumerable.From(res.Data[$this.fieldData]).Sum(function (item) { return item[fieldValue.field]; });

        // Update % progress bar
        Enumerable.From(progressArea.find(".progress-group"))
            .Join(res.Data[$this.fieldData],
                function (pl) { return $(pl).attr("data-state"); },
                function (item) { return item[fieldValue.fieldId] + ""; },
                function (pl, item)
                {                    
                    $(pl).find(".progress-number").find("b").html(item[fieldValue.field].formatMoney(0));
                    if (showTotal)
                        $(pl).find(".progress-number").find("span").html("/" + total.formatMoney(0));
                    $(pl).find(".progress-bar").css("background-color", item[fieldValue.fieldBgColor]).width(((item[fieldValue.field] / total) * 100) + "%");
                }).Count();
    }

    this.onCreateOptions = function (config, res)
    {
        var $this = this;
        config.options.maintainAspectRatio = false;
        config.options.tooltips = {
            callbacks: {
                label: function (tooltipItem, data)
                {                    
                    return data.datasets[tooltipItem.datasetIndex].label + ": " + data.datasets[tooltipItem.datasetIndex].data[tooltipItem.datasetIndex].formatMoney(0);
                },
                title: function (tooltipItems, data)
                {
                    if ($this.tooltipLabel != "") return $this.tooltipLabel + " " + tooltipItems[0].label;
                    return tooltipItems[0].label;
                }
            }
        };
    };
}

DashBoard.CharDoughnut = function ()
{
    $.extend(this, new DashBoard.CharPie());
    this.type = "doughnut";

    this.baseOnCreateOptions = this.onCreateOptions;
    this.onCreateOptions = function (config, res)
    {
        this.baseOnCreateOptions.bind(this)(config, res);
        var total = this.getTotal(res);
        if (total != null)
            config.options.elements = {
                center: {
                    text: total,
                    color: '#FF6384', // Default is #000000
                    fontStyle: 'Arial', // Default is Arial
                    sidePadding: 20 // Defualt is 20 (as a percentage)
                }
            };
    }

    this.getTotal = function (res)
    {
        var $this = this;
        var fieldValue = this.fieldValues[0];
        return Enumerable.From(res.Data[$this.fieldData]).Sum(function (item) { return item[fieldValue.field]; }).formatMoney(0);        
    }
}