/// <reference path="../Plugins/linq/linq.min.js" />

function CoreChart_1()
{    
    this.element = null;
    this.labels = [];
    this.data = []; // { label,data }
    this.colors = []; // { color1, color2 }
    this.lineColor = null;

    this.setOption = function(barChartOptions) { }

    this.init = function ()
    {
        var barChartCanvas = this.element.get(0).getContext("2d");
        var barChart = new Chart(barChartCanvas);

        var label = this.labels;
        
        var dataset = Enumerable.From(this.data).Select(function (dataItem)
        {
            var ds = CoreDefault.copy(CoreDefault.dataSet);
            ds.label = dataItem.label;
            ds.data = dataItem.data;
            return ds;
        }).ToArray();

        var barChartData = { labels: label, datasets: dataset };

        this.format(barChartData);

        var barChartOptions = CoreDefault.copy(CoreDefault.barChartOptions);
        barChartOptions.scaleGridLineColor = CoreDefault.getWithDefault(this.lineColor, "rgba(0,0,0,.05)");

        this.setOption(barChartOptions);
        //barChartOptions.multiTooltipTemplate = "<%= datasetLabel %> - <%= value %> VNĐ";
        return this.createChart(barChart, barChartData, barChartOptions)
    }
    this.createChart = function (barChart, barChartData, barChartOptions)
    {
        barChartOptions.datasetFill = false;
        return barChart.Bar(barChartData, barChartOptions);
    }
    this.format = function (barChartData)
    {
        var dsi = Enumerable.From(barChartData.datasets).Select(function (ds, i) { return { ds: ds, i: i }; });
        var colori = Enumerable.From(this.colors).Select(function (color, i) { return { color: color, i: i }; });

        var $this = this;

        dsi.Join(colori, function (dsiItem) { return dsiItem.i; }, function (coloriItem) { return coloriItem.i }, function (dsiItem, coloriItem)
        {            
            $this.formatDataSet(dsiItem.ds, coloriItem.color);
        }).Count();
    }
    this.formatDataSet = function (ds, c)
    {
        ds.fillColor = CoreDefault.getWithDefault(c.color1, c.color2);
    }
}
function CoreChart_2()
{
    $.extend(this, new CoreChart_1());

    this.createChart = function (barChart, barChartData, barChartOptions)
    {
        barChartOptions.datasetFill = false;
        return barChart.Line(barChartData, barChartOptions);
    }
    this.formatDataSet = function (ds, c)
    {
        ds.pointColor = ds.pointStrokeColor = ds.strokeColor = CoreDefault.getWithDefault(c.color1, c.color2);
        var rc = Core.getRGBA(c.color1, "0.3");
        ds.pointHighlightFill = ds.fillColor = CoreDefault.getWithDefault(rc, c.color2);
    }
}
function CoreChart_3()
{
    $.extend(this, new CoreChart_2());
    this.createChart = function (barChart, barChartData, barChartOptions)
    {
        barChartOptions.datasetFill = true;
        return barChart.Line(barChartData, barChartOptions);
    }
}