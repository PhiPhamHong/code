/*
Template Name: Osahan Mobile - Bootstrap 4 E-Commerce Template
Author: Askbootstrap
Author URI: 
Version: 1.0
*/
$(document).ready(function() {
    "use strict";

    // ===========Featured Owl Carousel============
    var objowlcarousel = $(".owl-carousel-featured");
    if (objowlcarousel.length > 0) {
        objowlcarousel.owlCarousel({
            items: 5,
            lazyLoad: true,
            pagination: false,
            autoPlay: 2000,
            navigation: true,
            stopOnHover: true
        });
    }
	
	// ===========Brands Owl Carousel============
    var objowlcarousel = $(".owl-carousel-brands");
    if (objowlcarousel.length > 0) {
        objowlcarousel.owlCarousel({
            items: 10,
            lazyLoad: true,
            pagination: false,
            autoPlay: 2000,
            navigation: true,
            stopOnHover: true
        });
    }
	
	// ===========Hover Nav============	
	$('.navbar-nav li.dropdown').on('mouseenter', function(){ $(this).find('.dropdown-menu').stop(true, true).delay(100).fadeIn(500); })
	$('.navbar-nav li.dropdown').on('mouseleave', function(){ $(this).find('.dropdown-menu').stop(true, true).delay(100).fadeOut(500); });

    // ===========Categories List Page============
    var mycategorylistpage = $(".categories-list-page");
    if (mycategorylistpage.length > 0) {
        mycategorylistpage.owlCarousel({
            items: 5,
            lazyLoad: true,
            pagination: false,
            navigation: true,
            autoPlay: false,
            stopOnHover: true
        });
    }

    // ===========Slider============
    var mainslider = $(".owl-carousel-slider");
    if (mainslider.length > 0) {
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

    // ===========Countdown============
    var target_date = new Date('Jan, 31, 2019').getTime();
    var days, hours, minutes, seconds;
    var countdown = document.getElementById('countdown');

    // ===========Single Items Slider============	
    var sync1 = $("#sync1");
    var sync2 = $("#sync2");
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
        afterInit: function(el) {
            el.find(".owl-item").eq(0).addClass("synced");
        }
    });
    function syncPosition(el) {
        var current = this.currentItem;
        $("#sync2")
            .find(".owl-item")
            .removeClass("synced")
            .eq(current)
            .addClass("synced")
        if ($("#sync2").data("owlCarousel") !== undefined) {
            center(current)
        }
    }
    $("#sync2").on("click", ".owl-item", function(e) {
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

});


function openNav() {
    document.getElementById("nav-sidenav").style.width = "250px";
    document.getElementById("main").style.marginLeft = "0px";
	document.getElementById("main").classList.add("background-blur");
}
function closeNav() {
    document.getElementById("nav-sidenav").style.width = "0";
    document.getElementById("main").style.marginLeft = "0";
	document.getElementById("main").classList.remove("background-blur");
}