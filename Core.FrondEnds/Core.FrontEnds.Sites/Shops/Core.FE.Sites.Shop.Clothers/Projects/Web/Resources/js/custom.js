
$(document).ready(function () {
    "use strict";
    // ===========Select2============
    $('select').select2();

    // ===========Popover============
    $('[data-toggle="popover"]').popover()

    // ===========Scrollspy============
    $('body').scrollspy({
        target: '#navbar-example'
    })
    $('[data-spy="scroll"]').each(function() {
        var $spy = $(this).scrollspy('refresh')
    })

    // ===========Tooltip============
    $('[data-toggle="tooltip"]').tooltip()
});



ViSon.DefaultPageLoadBase = function () {
    $.extend(this, new ViSon.DefaultPageLoad());
    this.onLoad = function () {
        var $this = this;
        var $window = $(window);
    }

}

ViSon.PageLoad = function () {
    $.extend(this, new ViSon.DefaultPageLoadBase());
    $.extend(this, new PageLoad());
}

ViSon.DefaultPageLoadInstance = function () { return new ViSon.PageLoad(); };


function PageLoad() {

    this.loadDropdown = function (element) {
        element.find('.navbar-nav li.dropdown').on('mouseenter', function () { $(this).find('.dropdown-menu').stop(true, true).delay(100).fadeIn(500); })
        element.find('.navbar-nav li.dropdown').on('mouseleave', function () { $(this).find('.dropdown-menu').stop(true, true).delay(100).fadeOut(500); });
    }
    
    this.LoadSL1 = function (element) {
        var objowlcarousel = element.find("#owl-carousel-featured1");
        objowlcarousel.owlCarousel({
            items: 5,
            lazyLoad: true,
            pagination: false,
            autoPlay: 2000,
            navigation: true,
            stopOnHover: true
        });
    }
    this.LoadSL2 = function (element) {
        var mycategorylistpage = element.find("#owl-carousel-featured2");
        mycategorylistpage.owlCarousel({
            items: 4,
            lazyLoad: true,
            pagination: false,
            navigation: true,
            autoPlay: 2000,
            stopOnHover: true
        });
    }
    this.LoadSL3 = function (element) {
        var mycategorylistpage = element.find("#owl-carousel-featured3");
        mycategorylistpage.owlCarousel({
            items: 4,
            lazyLoad: true,
            pagination: false,
            navigation: true,
            autoPlay: 2000,
            stopOnHover: true
        });
    }
    this.mainSlider = function (element) {
        element.owlCarousel({
            items: 1,
            lazyLoad: true,
            pagination: true,
            autoPlay: 4000,
            singleItem: true,
            navigation: true,
            stopOnHover: true
        });
    }
    this.innerSlider = function (element) {
        var mainslider = element.find(".owl-carousel-slider");
        mainslider.owlCarousel({
            items: 1,
            lazyLoad: true,
            pagination: true,
            autoPlay: 4000,
            singleItem: true,
            navigation: true,
            stopOnHover: true
        });
    }


    this.loadCountdown = function (element) {

        var target_date = new Date('Jun, 31, 2020').getTime();
        var countdown = element.find("#countdown");
        var x = setInterval(function () {
            var current_date = new Date().getTime();
            var distance = target_date - current_date;

            var days = Math.floor(distance / (1000 * 60 * 60 * 24));
            var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
            var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
            var seconds = Math.floor((distance % (1000 * 60)) / 1000);

            var time = '<span class="days">' + days + '<b>Days</b></span> <span class="hours">' + hours + ' <b>Hours</b></span> <span class="minutes">' + minutes + ' <b>Minutes</b></span> <span class="seconds">' + seconds + ' <b>Seconds</b></span>';
            countdown.innerHTML = time;
            if (distance < 0) {
                target_date = new Date('Dec, 31, 2020').getTime();
            }
        }, 1000);
    }

    this.detailSlider = function (element) {
        var sync1 = element.find("#sync1");
        var sync2 = element.find("#sync2");
        sync1.owlCarousel({
            singleItem: true,
            slideSpeed: 1000,
            pagination: false,
            navigation: true,
            autoPlay: 2500,
            afterAction: syncPosition,
            responsiveRefreshRate: 200,
        });
        sync2.owlCarousel({
            items: 5,
            navigation: true,
            itemsDesktop: [1199, 10],
            itemsDesktopSmall: [979, 10],
            itemsTablet: [768, 8],
            itemsMobile: [479, 4],
            pagination: false,
            responsiveRefreshRate: 100,
            afterInit: function (el) {
                el.find(".owl-item").eq(0).addClass("synced");
            }
        });
        function syncPosition() {
            var current = this.currentItem;
            sync2.find(".owl-item")
                 .removeClass("synced")
                 .eq(current)
                 .addClass("synced")
            if (sync2.data("owlCarousel") !== undefined) {
                center(current)
            }
        }
        sync2.on("click", ".owl-item", function (e) {
            e.preventDefault();
            var number = $(this).data("owlItem");
            sync1.trigger("owl.goTo", number);
        });
        function center(number) {
            var sync2visible = sync2.data("owlCarousel").owl.visibleItems;
            var num = number;
            var found = false;
            for (var i in sync2visible) {
                if (num === sync2visible[i]) {
                    var found = true;
                }
            }
            if (found === false) {
                if (num > sync2visible[sync2visible.length - 1]) {
                    sync2.trigger("owl.goTo", num - sync2visible.length + 2)
                } else {
                    if (num - 1 === -1) {
                        num = 0;
                    }
                    sync2.trigger("owl.goTo", num);
                }
            } else if (num === sync2visible[sync2visible.length - 1]) {
                sync2.trigger("owl.goTo", sync2visible[1])
            } else if (num === sync2visible[0]) {
                sync2.trigger("owl.goTo", num - 1)
            }
        }
    }
}
