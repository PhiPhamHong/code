/// <reference path="../../../../../Resources/Plugins/linq/linq.js" />

function PilotSchedule() {
    $.extend(this, new ModuleNormal());

    this.formSearch = null;

    this.onInit = function (res) {
        var $this = this;
        this.formSearch = this.getMain().find("[data-form=search]").benice();
        this.beforeStartDayPilot();
        this.startDayPilot(res);

        this.formSearch.find("[data-form-button]").click(function () { $this[$(this).attr("data-form-button")](); });
        //this.formSearch.find("[data-form-button=search]").click();
        this.search(true);
    };

    this.beforeStartDayPilot = function () { }

    this.dp = null;
    this.dataSearch = {};
    this.startDayPilot = function (res) {
        var $this = this;
        var dataSearch = this.formSearch.getValues();

        this.dp = new DayPilot.Scheduler(this.getMain().find("#dp")[0]); // https://api.daypilot.org/daypilot-scheduler-properties/ 

        var startTime = this.formatDateFromInput(dataSearch["StartTime"]);
        startTime = Core.getDate(startTime);

        var endTime = this.formatDateFromInput(dataSearch["EndTime"]);
        endTime = Core.getDate(endTime);

        // view
        this.dp.startDate = new DayPilot.Date(startTime);
        this.dp.cellGroupBy = "Month";
        this.dp.scale = "Day";
        this.dp.crosshairType = "Full";
        this.dp.useEventBoxes = "Never";

        this.dp.days = Core.subDate(endTime, startTime).days + 1; // dp.startDate.daysInMonth();
        this.dp.cellDuration = 30; // one day
        this.dp.moveBy = 'None';

        //this.dp.resources = res.Data.Resources;
        this.dp.allowMultiRange = true;
        this.dp.multiSelectRectangle = "Free";
        this.dp.treeEnabled = true;
        this.dp.treePreventParentUsage = true;
        this.dp.eventHoverHandling = "Bubble";

        // this.dp.rowHeaderWidthAutoFit = true;

        this.dp.onBeforeCellRender = function (args) {
            // if (args.cell.start.getDayOfWeek() === 6) args.cell.backColor = "#dddddd"; 
        }; // TODO unify the API: css/cssClass, html/innerHTML, etc. // S

        // this.dp.rowHeaderScrolling = true;
        this.dp.eventClickHandling = "JavaScript";
        this.beforeInitDayPilot();
        this.dp.heightSpec = "Max";

        this.dp.bubble.zIndex = 999999; //https://api.daypilot.org/daypilot-scheduler-bubble/

        // Lưu trữ các máy được chọn theo khoảng thời gian
        this.dp.onTimeRangeSelected = function (args) {
            $this.currentMultiRange = Enumerable.From(args.multirange).Select(function (item) {
                return {
                    ResourceId: item.resource,
                    FromDate: $this.convertToDate(item.start.value),
                    ToDate: $this.convertToDate(item.end.value)
                };
            }).ToArray();
        };

        this.dp.init();
    }

    // 2019-09-09T03:00:00
    this.convertToDate = function (date) {
        var date = date.split('T');
        var date0 = date[0].split('-');
        return date0[2] + "/" + date0[1] + "/" + date0[0] + " " + date[1];
    }

    // 20-10-2020 17:59
    this.formatDateFromInput = function (date) {
        var date = date.split(' ');
        if (date.length == 1) return Core.getYearMonthDay(date[0]).replace("/", "-").replace("/", "-") + "T00:00:00";
        else return Core.getYearMonthDay(date[0]).replace("/", "-").replace("/", "-") + "T" + date[1] + ":00";
    }

    this.currentMultiRange = null;
    this.hasTimeRanged = function () {
        return this.find(".scheduler_default_shadow_inner").length != 0 && this.currentMultiRange != null && this.currentMultiRange.length != 0;
    }

    this.search = function (scrollTo) {
        if (scrollTo == null) scrollTo = true;

        var $this = this;
        var dataSearch = this.dataSearch = this.formSearch.getValues();
        $.extend(dataSearch, this.extendDataSearch())

        var startTime = this.formatDateFromInput(dataSearch["StartTime"]);
        startTime = Core.getDate(startTime);

        var endTime = this.formatDateFromInput(dataSearch["EndTime"]);
        endTime = Core.getDate(endTime);

        this.dp.startDate = new DayPilot.Date(startTime);
        this.dp.days = Core.subDate(endTime, startTime).days + 1;
        this.post("GetEvent", dataSearch, function (res) {
            $this.dp.events.list = [];
            $this.dp.resources = Enumerable.From(res.Data.Resources).Select(function (resource) {
                $this.buildResource(resource);
                return resource;
            }).ToArray();
            $this.onloadEvents(res);

            var minEvent = null;

            Enumerable.From(res.Data.Events).ForEach(function (data, index) {
                var event = { start: new DayPilot.Date(data.FromDateString), end: new DayPilot.Date(data.ToDateString) };
                event.id = data.id;
                event.resource = data.resource;
                event.text = data.text;
                event.item = data;

                $this.buildEvent(event, data);
                $this.dp.events.add(new DayPilot.Event(event));

                if (minEvent == null || event.start.ticks < minEvent.start.ticks) minEvent = event;
            });
            $this.dp.update();

            if (scrollTo) {
                if (minEvent != null) {
                    $this.dp.scrollTo(minEvent.start);
                    $this.dp.scrollToResource(minEvent.resource);
                }
                else $this.dp.scrollTo(new DayPilot.Date(startTime));
            }
        });
    }

    this.extendDataSearch = function () { return {}; };

    this.onloadEvents = function (res) { };

    this.buildEvent = function (event, data) { } // https://api.daypilot.org/daypilot-event-data/
    this.buildResource = function (resource) { } // https://api.daypilot.org/daypilot-scheduler-resources/

    this.beforeInitDayPilot = function () { }

    this.previousMonth = function () { this.changeDate(false); };
    this.nextMonth = function () { this.changeDate(true); };

    this.changeDate = function (up) {
        var $this = this;
        var data = this.formSearch.getValues();
        data.Up = up;
        data.TimeRange = this.find("#dp").attr("data-time");
        this.post("ChangeDate", data, function (res) {
            $this.formSearch.fillForm(res.Data.Search);
            $this.search(false);
        });
    }

    this.getTimeLabel = function (time) {
        if (time == "12 AM") return Core.getLabel("0 giờ đêm");
        else if (time.indexOf("AM") >= 0) return time.replace("AM", "") + " " + Core.getLabel("giờ sáng");
        else if (time.indexOf("PM") >= 0) return time.replace("PM", "") + " " + Core.getLabel("giờ chiều");
        else return time;
    }
}