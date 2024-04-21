/// <reference path="../Plugins/linq/linq.min.js" />
function ShChart() { }
ShChart.ChartBase = function()
{
    //$.extend(this, new DashBoard.ControlByOption());
    this.typeAction = "";                    // Type chứa phương thức gọi load dữ liệu
    this.method = "InitData";                       // Tên phương thức của trên Server của DashBoard để load dữ liệu
    this.dataKey = "Summary";                              // Dữ liệu DataSource chứa danh sách các item cần báo cáo => res.Data[dataKey]
    this.keyLabel = "";                             // Tên biến chứa dữ liệu trên 1 item res.Data[dataKey][0][keyLabel]
    this.ajax = null;

    this.fillWhenInit = true;

    this.beforeBind = function(res) 
    {
        var $this = this;
        debugger;
        $this.target.main.fillForm(res.Data);
        $this.target.main.find("select[name]").change(function () { $this.onInputChange(); });
        $this.target.main.attr("data-has-be-nice", false);
        $this.target.main.benice();
    }

    this.onInputChange = function () { this.reload(); };

    this.init = function (res)
    {
        this.ajax = new CoreAjax(); 
        this.ajax.userOverlay = false;
        this.ajax.alertWhenFail = false;
        this.ajax.typeAction = res.Data.DashBoardModule; // this.typeAction;
        this.ajax.assembly = res.Data.DashBoardModuleProject;
        this.beforeBind(res);
        if (this.fillWhenInit) this.fillChart(res);
    }

    this.fillChart = function(res) { }

    this.reload = function () 
    { 
        var $this = this; 
        var data = $this.config; if (data == null) data = {};
        $.extend(data, $this.target.main.getValues());
        $this.ajax.post($this.method, data, function (res) { $this.fillChart(res); }); 
    };

    this.buildLabelData = function() { }
}
ShChart.ChartColumn = function ()
{
    $.extend(this, new ShChart.ChartBase());
    
    this.keyLabelText = ""                          // Tên của cột
    labelData = []; // { label : "Doanh thu", key : "data", color : "rgba(210, 214, 222, 1)"}
    this.chartType = "ChartType";


    this.tooltipTemplate = "<%= label %>: <%= value.formatMoney(0) %>";
    this.multiTooltipTemplate = "<%= datasetLabel %>: - <%= value.formatMoney(0) %> ";

    var currentChart = null;
    var formatChart = function (res, chart) 
    {
        var $this = this;
        chart.labels = Enumerable.From(res.Data[$this.dataKey]).Select(function (item) { return $this.keyLabelText + "" + item[$this.keyLabel]; }).ToArray();

        labelData = $this.buildLabelData();
        chart.data = Enumerable.From(labelData).Select(function (labelItem) 
        {
            return { label : labelItem.label, data: Enumerable.From(res.Data[$this.dataKey]).Select(function (item) { return item[labelItem.key]; }).ToArray() };
        }).ToArray();

        var $color = [];
        Enumerable.From(labelData).ForEach(function (item, i) 
        { 
            var $thisColor = {};
            $thisColor.color1 = item.color;
            $thisColor.color2 = item.color1;
            $color.push($thisColor);
        });
        chart.colors = $color;

        chart.setOption = function (barChartOptions) 
        {
            barChartOptions.tooltipTemplate = $this.tooltipTemplate;
            barChartOptions.multiTooltipTemplate = $this.multiTooltipTemplate;
        };
    };
    this.fillChart = function (res) 
    {
        if (currentChart != null) currentChart.destroy();

        var chart = this.createChart();
        chart.element = this.target.main.find("canvas");
        formatChart.bind(this)(res, chart);
        currentChart = chart.init();
    }
    this.createChart = function () 
    {
        if (this.chartType == null || this.chartType == "") return new CoreChart_1();
        var chart = this.config[this.chartType];
        if (chart == null || chart == "" || chart == 0) return new CoreChart_1();

        switch(chart)
        {
            case 1: return new CoreChart_1();
            case 2: return new CoreChart_2();
            case 3: return new CoreChart_3();
        }
        return new CoreChart_1(); 
    };
    this.end = function () { if (currentChart != null) currentChart.destroy(); };
}
ShChart.ChartBar = function()
{
    $.extend(this, new ShChart.ChartBase());

    this.keyLabelText = " "                         // Tên của cột

    this.fillChart = function(res) 
    {
        var $this = this;
        this.target.main.find(".chart").html("");

        var labelData = $this.buildLabelData();

        var ykeys = Enumerable.From(labelData).Select(function (item) { return item.key; }).ToArray();
        var labels = Enumerable.From(labelData).Select(function (item) { return item.label; }).ToArray();
        var colors = Enumerable.From(labelData).Select(function (item) { return item.color; }).ToArray();

        Morris.Bar(
        {
            element: $this.target.main.find(".chart")[0],
            data: Enumerable.From(res.Data[$this.dataKey]).Select(function (item) { item[$this.keyLabel] = $this.keyLabelText + item[$this.keyLabel]; return item; }).ToArray(),
            xkey: $this.keyLabel,
            ykeys: ykeys,
            labels: labels,
            barColors: colors,
            stacked: true
        });
    }
}
ShChart.CharPie = function()
{
    $.extend(this, new ShChart.ChartBase());

    var progressGroups = null;  // Danh sách các thẻ div, mỗi một div là một progess bar hiển thị % của một trạng thái    
    this.keyValue = "";         // trường của đối tượng chứa giá trị

    var baseInit = this.init;
    this.init = function(res)
    {
        debugger;
        var _settings = this.buildLabelData(); if (_settings != null) settings = _settings;
        progressGroups = this.target.main.find(".progress-group");

        // Thiết lập Css màu cho các progess bar
        Enumerable.From(settings).Join(progressGroups,
            function (s) { return s.state + ""; },
            function (p) { return $(p).attr("data-state"); },
            function (s, p) { $(p).find(".progress-bar").addClass(s.barCss); }).Count();
        oldData = getDataInForm();

        baseInit.bind(this)(res);
        var $this = this;

        var data = $this.config; if (data == null) data = {};
        this.ajax.doPostTimer($this.method, data, 3600000, function (res) { $this.fillChart(res); });
    }

    var settings = [
        { state : 1, color : "#00c0ef", highlight : "#00c0ef", barCss : "progress-bar-aqua" },
        { state : 2, color : "#dd4b39", highlight : "#dd4b39", barCss : "progress-bar-red" },
        { state : 3, color : "#f39c12", highlight : "#f39c12", barCss : "progress-bar-yellow" },
        { state : 4, color : "#00a65a", highlight : "#00a65a", barCss : "progress-bar-green" },
        //{ state : 5, color : "#00a65a", highlight : "#00a65a", barCss : "progress-bar-green" },
        //{ state : 6, color : "#00a65a", highlight : "#00a65a", barCss : "progress-bar-green" } 
        ];

    this.end = function () { this.ajax.clearThreadPOST(this.method); };

    var chart = null;
    this.fillChart = function(res)
    {
        var newData = getNewData.bind(this)(res);       // Dữ liệu mới
        if (!isDifferent(oldData, newData)) return;     // Nếu dữ liệu nó thay đổi thì mới vẽ lại Chart

        var total = Enumerable.From(newData).Sum(function (n) { return n.value; }); // Tổng số
        Enumerable.From(newData).Join(progressGroups,
                function (n) { return n.state; },
                function (p) { return parseInt($(p).attr("data-state")); },
                function (n, p) 
                {
                    $(p).find(".progress-number b").html(n.value);
                    $(p).find(".progress-number span").html(total);
                    $(p).find(".progress-bar").css("width", ((n.value / total ) * 100) + "%");
                }).Count();

        
        if (chart != null) chart.destroy();
        this.target.main.find("canvas").remove();
        this.target.main.find(".chart-responsive").append($("<canvas height='150'>"));
        var canvas = this.target.main.find("canvas").removeAttr("width").removeAttr("style").attr("height", "150").get(0).getContext("2d");

        var pieChart = new Chart(canvas);
        var pieData = Enumerable.From(newData).Join(settings,
            function (n) { return n.state; },
            function (s) { return s.state; },
            function (n, s) { return { value: n.value, label: n.label, color: s.color, highlight: s.highlight }; }
            ).ToArray();

        var pieOptions = CoreDefault.copy(CoreDefault.pieOptions);
        pieOptions.tooltipTemplate = "<%=value %> <%=label%>";

        chart = pieChart.Doughnut(pieData, pieOptions);

        oldData = newData;
    }

    var getNewData = function(res)
    {
        var $this = this;
        var newData = Enumerable.From(res.Data[this.dataKey]).Select(function (item) { return { state: item[$this.keyLabel], value: item[$this.keyValue] }; }).ToArray();
        var current = getDataInForm();

        Enumerable.From(current).Join(newData,
            function (c) { return c.state; },
            function (n) { return n.state; },
            function (c, n) { c.value = n.value; }).Count();

        return current;
    }

    var getDataInForm = function()
    {
        return Enumerable.From(progressGroups).Select(function (p) { return { state: parseInt($(p).attr("data-state")), label: $(p).find(".progress-text").html(), value: parseInt($(p).find(".progress-number b").html()) }; }).ToArray();
    }

    var isDifferent = function(old, $new)
    {
        return Enumerable.From(old).Join($new,
            function (o) { return o.state + "." + o.value; },
            function (n) { return n.state + "." + n.value; },
            function (o, n) { }).Count() != old.length;
    }

    var oldData = null; // Dữ liệu cũ
}