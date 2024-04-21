function CoreDefault() { }

CoreDefault.copy = function(defaultOption)
{
    var op = {};
    $.extend(op, defaultOption);
    return op;
}

//CoreDefault.loadImages = function (callback)
//{
//    var images = [];
//    for (i = 0; i <= 7; i++) images.push("/Web/Resources/Icons/clients/1/" + i + ".png");
//    for (i = 0; i <= 7; i++) images.push("/Web/Resources/Icons/clients/2/" + i + ".png");
//    $({}).imageLoader({ images: images, async: true, allcomplete: function (e, ui) { callback(); } });
//}

CoreDefault.getWithDefault = function(value, defaultValue)
{
    return value == null || value == "" ? defaultValue : value;
}

CoreDefault.pieOptions =
{
    segmentShowStroke: true,
    segmentStrokeColor: "#fff",
    segmentStrokeWidth: 1,
    percentageInnerCutout: 50, // This is 0 for Pie charts            
    animationSteps: 100,
    animationEasing: "easeOutBounce",
    animateRotate: true,
    animateScale: false,
    responsive: true,
    maintainAspectRatio: false,
    legendTemplate: "<ul class=\"<%=name.toLowerCase()%>-legend\"><% for (var i=0; i<segments.length; i++){%><li><span style=\"background-color:<%=segments[i].fillColor%>\"></span><%if(segments[i].label){%><%=segments[i].label%><%}%></li><%}%></ul>",
    //tooltipTemplate: "<%=value %> <%=label%> việc"
};

CoreDefault.barChartOptions = 
{
    scaleBeginAtZero: true,
    scaleShowGridLines: true,
    scaleGridLineColor: "rgba(0,0,0,.05)",
    scaleGridLineWidth: 1,
    scaleShowHorizontalLines: true,
    scaleShowVerticalLines: true,
    barShowStroke: true,
    barStrokeWidth: 0.1,
    barValueSpacing: 5,
    barDatasetSpacing: 1,
    legendTemplate: "<ul class=\"<%=name.toLowerCase()%>-legend\"><% for (var i=0; i<datasets.length; i++){%><li><span style=\"background-color:<%=datasets[i].fillColor%>\"></span><%if(datasets[i].label){%><%=datasets[i].label%><%}%></li><%}%></ul>",
    responsive: true,
    maintainAspectRatio: false,
    //multiTooltipTemplate: "<%= datasetLabel %> - <%= value %> VNĐ",
};

CoreDefault.dataSet =
{
    label: "Label Abc",
    fillColor: "rgba(210, 214, 222, 1)",
    strokeColor: "rgba(210, 214, 222, 1)",
    pointColor: "rgba(210, 214, 222, 1)",
    pointStrokeColor: "#c1c7d1",
    pointHighlightFill: "#fff",
    pointHighlightStroke: "rgba(220,220,220,1)",
    data: []
};