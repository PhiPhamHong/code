"function" != typeof Object.create && (Object.create = function (t) {
    function e() { }
    return e.prototype = t, new e
}),
    function (t, e, o) {
        var i = {
            init: function (e, o) {
                var i = this;
                i.$elem = t(o), i.options = t.extend({}, t.fn.owlCarousel.options, i.$elem.data(), e), i.userOptions = e, i.loadContent()
            },
            loadContent: function () {
                var e, o = this;
                "function" == typeof o.options.beforeInit && o.options.beforeInit.apply(this, [o.$elem]), "string" == typeof o.options.jsonPath ? (e = o.options.jsonPath, t.getJSON(e, function (t) {
                    var e, i = "";
                    if ("function" == typeof o.options.jsonSuccess) o.options.jsonSuccess.apply(this, [t]);
                    else {
                        for (e in t.owl) t.owl.hasOwnProperty(e) && (i += t.owl[e].item);
                        o.$elem.html(i)
                    }
                    o.logIn()
                })) : o.logIn()
            },
            logIn: function () {
                var t = this;
                t.$elem.data("owl-originalStyles", t.$elem.attr("style")).data("owl-originalClasses", t.$elem.attr("class")), t.$elem.css({
                    opacity: 0
                }), t.orignalItems = t.options.items, t.checkBrowser(), t.wrapperWidth = 0, t.checkVisible = null, t.setVars()
            },
            setVars: function () {
                var t = this;
                if (0 === t.$elem.children().length) return !1;
                t.baseClass(), t.eventTypes(), t.$userItems = t.$elem.children(), t.itemsAmount = t.$userItems.length, t.wrapItems(), t.$owlItems = t.$elem.find(".owl-item"), t.$owlWrapper = t.$elem.find(".owl-wrapper"), t.playDirection = "next", t.prevItem = 0, t.prevArr = [0], t.currentItem = 0, t.customEvents(), t.onStartup()
            },
            onStartup: function () {
                var t = this;
                t.updateItems(), t.calculateAll(), t.buildControls(), t.updateControls(), t.response(), t.moveEvents(), t.stopOnHover(), t.owlStatus(), !1 !== t.options.transitionStyle && t.transitionTypes(t.options.transitionStyle), !0 === t.options.autoPlay && (t.options.autoPlay = 5e3), t.play(), t.$elem.find(".owl-wrapper").css("display", "block"), t.$elem.is(":visible") ? t.$elem.css("opacity", 1) : t.watchVisibility(), t.onstartup = !1, t.eachMoveUpdate(), "function" == typeof t.options.afterInit && t.options.afterInit.apply(this, [t.$elem])
            },
            eachMoveUpdate: function () {
                var t = this;
                !0 === t.options.lazyLoad && t.lazyLoad(), !0 === t.options.autoHeight && t.autoHeight(), t.onVisibleItems(), "function" == typeof t.options.afterAction && t.options.afterAction.apply(this, [t.$elem])
            },
            updateVars: function () {
                var t = this;
                "function" == typeof t.options.beforeUpdate && t.options.beforeUpdate.apply(this, [t.$elem]), t.watchVisibility(), t.updateItems(), t.calculateAll(), t.updatePosition(), t.updateControls(), t.eachMoveUpdate(), "function" == typeof t.options.afterUpdate && t.options.afterUpdate.apply(this, [t.$elem])
            },
            reload: function () {
                var t = this;
                e.setTimeout(function () {
                    t.updateVars()
                }, 0)
            },
            watchVisibility: function () {
                var t = this;
                if (!1 !== t.$elem.is(":visible")) return !1;
                t.$elem.css({
                    opacity: 0
                }), e.clearInterval(t.autoPlayInterval), e.clearInterval(t.checkVisible), t.checkVisible = e.setInterval(function () {
                    t.$elem.is(":visible") && (t.reload(), t.$elem.animate({
                        opacity: 1
                    }, 200), e.clearInterval(t.checkVisible))
                }, 500)
            },
            wrapItems: function () {
                var t = this;
                t.$userItems.wrapAll('<div class="owl-wrapper">').wrap('<div class="owl-item"></div>'), t.$elem.find(".owl-wrapper").wrap('<div class="owl-wrapper-outer">'), t.wrapperOuter = t.$elem.find(".owl-wrapper-outer"), t.$elem.css("display", "block")
            },
            baseClass: function () {
                var t = this,
                    e = t.$elem.hasClass(t.options.baseClass),
                    o = t.$elem.hasClass(t.options.theme);
                e || t.$elem.addClass(t.options.baseClass), o || t.$elem.addClass(t.options.theme)
            },
            updateItems: function () {
                var e, o, i = this;
                if (!1 === i.options.responsive) return !1;
                if (!0 === i.options.singleItem) return i.options.items = i.orignalItems = 1, i.options.itemsCustom = !1, i.options.itemsDesktop = !1, i.options.itemsDesktopSmall = !1, i.options.itemsTablet = !1, i.options.itemsTabletSmall = !1, i.options.itemsMobile = !1, !1;
                if ((e = t(i.options.responsiveBaseWidth).width()) > (i.options.itemsDesktop[0] || i.orignalItems) && (i.options.items = i.orignalItems), !1 !== i.options.itemsCustom)
                    for (i.options.itemsCustom.sort(function (t, e) {
                        return t[0] - e[0]
                    }), o = 0; o < i.options.itemsCustom.length; o += 1) i.options.itemsCustom[o][0] <= e && (i.options.items = i.options.itemsCustom[o][1]);
                else e <= i.options.itemsDesktop[0] && !1 !== i.options.itemsDesktop && (i.options.items = i.options.itemsDesktop[1]), e <= i.options.itemsDesktopSmall[0] && !1 !== i.options.itemsDesktopSmall && (i.options.items = i.options.itemsDesktopSmall[1]), e <= i.options.itemsTablet[0] && !1 !== i.options.itemsTablet && (i.options.items = i.options.itemsTablet[1]), e <= i.options.itemsTabletSmall[0] && !1 !== i.options.itemsTabletSmall && (i.options.items = i.options.itemsTabletSmall[1]), e <= i.options.itemsMobile[0] && !1 !== i.options.itemsMobile && (i.options.items = i.options.itemsMobile[1]);
                i.options.items > i.itemsAmount && !0 === i.options.itemsScaleUp && (i.options.items = i.itemsAmount)
            },
            response: function () {
                var o, i, s = this;
                if (!0 !== s.options.responsive) return !1;
                i = t(e).width(), s.resizer = function () {
                    t(e).width() !== i && (!1 !== s.options.autoPlay && e.clearInterval(s.autoPlayInterval), e.clearTimeout(o), o = e.setTimeout(function () {
                        i = t(e).width(), s.updateVars()
                    }, s.options.responsiveRefreshRate))
                }, t(e).resize(s.resizer)
            },
            updatePosition: function () {
                var t = this;
                t.jumpTo(t.currentItem), !1 !== t.options.autoPlay && t.checkAp()
            },
            appendItemsSizes: function () {
                var e = this,
                    o = 0,
                    i = e.itemsAmount - e.options.items;
                e.$owlItems.each(function (s) {
                    var n = t(this);
                    n.css({
                        width: e.itemWidth
                    }).data("owl-item", Number(s)), s % e.options.items != 0 && s !== i || s > i || (o += 1), n.data("owl-roundPages", o)
                })
            },
            appendWrapperSizes: function () {
                var t = this,
                    e = t.$owlItems.length * t.itemWidth;
                t.$owlWrapper.css({
                    width: 2 * e,
                    left: 0
                }), t.appendItemsSizes()
            },
            calculateAll: function () {
                var t = this;
                t.calculateWidth(), t.appendWrapperSizes(), t.loops(), t.max()
            },
            calculateWidth: function () {
                var t = this;
                t.itemWidth = Math.round(t.$elem.width() / t.options.items)
            },
            max: function () {
                var t = this,
                    e = -1 * (t.itemsAmount * t.itemWidth - t.options.items * t.itemWidth);
                return t.options.items > t.itemsAmount ? (t.maximumItem = 0, e = 0, t.maximumPixels = 0) : (t.maximumItem = t.itemsAmount - t.options.items, t.maximumPixels = e), e
            },
            min: function () {
                return 0
            },
            loops: function () {
                var e, o, i = this,
                    s = 0,
                    n = 0;
                for (i.positionsInArray = [0], i.pagesInArray = [], e = 0; e < i.itemsAmount; e += 1) n += i.itemWidth, i.positionsInArray.push(-n), !0 === i.options.scrollPerPage && (o = t(i.$owlItems[e]).data("owl-roundPages")) !== s && (i.pagesInArray[s] = i.positionsInArray[e], s = o)
            },
            buildControls: function () {
            },
            buildButtons: function () {
                var e = this,
                    o = t('<div class="owl-buttons"/>');
                e.owlControls.append(o), e.buttonPrev = t("<div/>", {
                    class: "owl-prev",
                    html: e.options.navigationText[0] || ""
                }), e.buttonNext = t("<div/>", {
                    class: "owl-next",
                    html: e.options.navigationText[1] || ""
                }), o.append(e.buttonPrev).append(e.buttonNext), o.on("touchstart.owlControls mousedown.owlControls", 'div[class^="owl"]', function (t) {
                    t.preventDefault()
                }), o.on("touchend.owlControls mouseup.owlControls", 'div[class^="owl"]', function (o) {
                    o.preventDefault(), t(this).hasClass("owl-next") ? e.next() : e.prev()
                })
            },
            buildPagination: function () {
                var e = this;
                e.paginationWrapper = t('<div class="owl-pagination"/>'), e.owlControls.append(e.paginationWrapper), e.paginationWrapper.on("touchend.owlControls mouseup.owlControls", ".owl-page", function (o) {
                    o.preventDefault(), Number(t(this).data("owl-page")) !== e.currentItem && e.goTo(Number(t(this).data("owl-page")), !0)
                })
            },
            updatePagination: function () {
                var e, o, i, s, n, a, r = this;
                if (!1 === r.options.pagination) return !1;
                for (r.paginationWrapper.html(""), e = 0, o = r.itemsAmount - r.itemsAmount % r.options.items, s = 0; s < r.itemsAmount; s += 1) s % r.options.items == 0 && (e += 1, o === s && (i = r.itemsAmount - r.options.items), n = t("<div/>", {
                    class: "owl-page"
                }), a = t("<span></span>", {
                    text: !0 === r.options.paginationNumbers ? e : "",
                    class: !0 === r.options.paginationNumbers ? "owl-numbers" : ""
                }), n.append(a), n.data("owl-page", o === s ? i : s), n.data("owl-roundPages", e), r.paginationWrapper.append(n));
                r.checkPagination()
            },
            checkPagination: function () {
                var e = this;
                if (!1 === e.options.pagination) return !1;
                e.paginationWrapper.find(".owl-page").each(function () {
                    t(this).data("owl-roundPages") === t(e.$owlItems[e.currentItem]).data("owl-roundPages") && (e.paginationWrapper.find(".owl-page").removeClass("active"), t(this).addClass("active"))
                })
            },
            checkNavigation: function () {
                var t = this;
                if (!1 === t.options.navigation) return !1;
                !1 === t.options.rewindNav && (0 === t.currentItem && 0 === t.maximumItem ? (t.buttonPrev.addClass("disabled"), t.buttonNext.addClass("disabled")) : 0 === t.currentItem && 0 !== t.maximumItem ? (t.buttonPrev.addClass("disabled"), t.buttonNext.removeClass("disabled")) : t.currentItem === t.maximumItem ? (t.buttonPrev.removeClass("disabled"), t.buttonNext.addClass("disabled")) : 0 !== t.currentItem && t.currentItem !== t.maximumItem && (t.buttonPrev.removeClass("disabled"), t.buttonNext.removeClass("disabled")))
            },
            updateControls: function () {
                var t = this;
                t.updatePagination(), t.checkNavigation(), t.owlControls && (t.options.items >= t.itemsAmount ? t.owlControls.hide() : t.owlControls.show())
            },
            destroyControls: function () {
                this.owlControls && this.owlControls.remove()
            },
            next: function (t) {
                var e = this;
                if (e.isTransition) return !1;
                if (e.currentItem += !0 === e.options.scrollPerPage ? e.options.items : 1, e.currentItem > e.maximumItem + (!0 === e.options.scrollPerPage ? e.options.items - 1 : 0)) {
                    if (!0 !== e.options.rewindNav) return e.currentItem = e.maximumItem, !1;
                    e.currentItem = 0, t = "rewind"
                }
                e.goTo(e.currentItem, t)
            },
            prev: function (t) {
                var e = this;
                if (e.isTransition) return !1;
                if (!0 === e.options.scrollPerPage && e.currentItem > 0 && e.currentItem < e.options.items ? e.currentItem = 0 : e.currentItem -= !0 === e.options.scrollPerPage ? e.options.items : 1, e.currentItem < 0) {
                    if (!0 !== e.options.rewindNav) return e.currentItem = 0, !1;
                    e.currentItem = e.maximumItem, t = "rewind"
                }
                e.goTo(e.currentItem, t)
            },
            goTo: function (t, o, i) {
                var s, n = this;
                return !n.isTransition && ("function" == typeof n.options.beforeMove && n.options.beforeMove.apply(this, [n.$elem]), t >= n.maximumItem ? t = n.maximumItem : t <= 0 && (t = 0), n.currentItem = n.owl.currentItem = t, !1 !== n.options.transitionStyle && "drag" !== i && 1 === n.options.items && !0 === n.browser.support3d ? (n.swapSpeed(0), !0 === n.browser.support3d ? n.transition3d(n.positionsInArray[t]) : n.css2slide(n.positionsInArray[t], 1), n.afterGo(), n.singleItemTransition(), !1) : (s = n.positionsInArray[t], !0 === n.browser.support3d ? (n.isCss3Finish = !1, !0 === o ? (n.swapSpeed("paginationSpeed"), e.setTimeout(function () {
                    n.isCss3Finish = !0
                }, n.options.paginationSpeed)) : "rewind" === o ? (n.swapSpeed(n.options.rewindSpeed), e.setTimeout(function () {
                    n.isCss3Finish = !0
                }, n.options.rewindSpeed)) : (n.swapSpeed("slideSpeed"), e.setTimeout(function () {
                    n.isCss3Finish = !0
                }, n.options.slideSpeed)), n.transition3d(s)) : !0 === o ? n.css2slide(s, n.options.paginationSpeed) : "rewind" === o ? n.css2slide(s, n.options.rewindSpeed) : n.css2slide(s, n.options.slideSpeed), void n.afterGo()))
            },
            jumpTo: function (t) {
                var e = this;
                "function" == typeof e.options.beforeMove && e.options.beforeMove.apply(this, [e.$elem]), t >= e.maximumItem || -1 === t ? t = e.maximumItem : t <= 0 && (t = 0), e.swapSpeed(0), !0 === e.browser.support3d ? e.transition3d(e.positionsInArray[t]) : e.css2slide(e.positionsInArray[t], 1), e.currentItem = e.owl.currentItem = t, e.afterGo()
            },
            afterGo: function () {
                var t = this;
                t.prevArr.push(t.currentItem), t.prevItem = t.owl.prevItem = t.prevArr[t.prevArr.length - 2], t.prevArr.shift(0), t.prevItem !== t.currentItem && (t.checkPagination(), t.checkNavigation(), t.eachMoveUpdate(), !1 !== t.options.autoPlay && t.checkAp()), "function" == typeof t.options.afterMove && t.prevItem !== t.currentItem && t.options.afterMove.apply(this, [t.$elem])
            },
            stop: function () {
                this.apStatus = "stop", e.clearInterval(this.autoPlayInterval)
            },
            checkAp: function () {
                "stop" !== this.apStatus && this.play()
            },
            play: function () {
                var t = this;
                if (t.apStatus = "play", !1 === t.options.autoPlay) return !1;
                e.clearInterval(t.autoPlayInterval), t.autoPlayInterval = e.setInterval(function () {
                    t.next(!0)
                }, t.options.autoPlay)
            },
            swapSpeed: function (t) {
                var e = this;
                "slideSpeed" === t ? e.$owlWrapper.css(e.addCssSpeed(e.options.slideSpeed)) : "paginationSpeed" === t ? e.$owlWrapper.css(e.addCssSpeed(e.options.paginationSpeed)) : "string" != typeof t && e.$owlWrapper.css(e.addCssSpeed(t))
            },
            addCssSpeed: function (t) {
                return {
                    "-webkit-transition": "all " + t + "ms ease",
                    "-moz-transition": "all " + t + "ms ease",
                    "-o-transition": "all " + t + "ms ease",
                    transition: "all " + t + "ms ease"
                }
            },
            removeTransition: function () {
                return {
                    "-webkit-transition": "",
                    "-moz-transition": "",
                    "-o-transition": "",
                    transition: ""
                }
            },
            doTranslate: function (t) {
                return {
                    "-webkit-transform": "translate3d(" + t + "px, 0px, 0px)",
                    "-moz-transform": "translate3d(" + t + "px, 0px, 0px)",
                    "-o-transform": "translate3d(" + t + "px, 0px, 0px)",
                    "-ms-transform": "translate3d(" + t + "px, 0px, 0px)",
                    transform: "translate3d(" + t + "px, 0px,0px)"
                }
            },
            transition3d: function (t) {
                this.$owlWrapper.css(this.doTranslate(t))
            },
            css2move: function (t) {
                this.$owlWrapper.css({
                    left: t
                })
            },
            css2slide: function (t, e) {
                var o = this;
                o.isCssFinish = !1, o.$owlWrapper.stop(!0, !0).animate({
                    left: t
                }, {
                    duration: e || o.options.slideSpeed,
                    complete: function () {
                        o.isCssFinish = !0
                    }
                })
            },
            checkBrowser: function () {
                var t, i, s, n, a = "translate3d(0px, 0px, 0px)",
                    r = o.createElement("div");
                r.style.cssText = "  -moz-transform:" + a + "; -ms-transform:" + a + "; -o-transform:" + a + "; -webkit-transform:" + a + "; transform:" + a, t = /translate3d\(0px, 0px, 0px\)/g, s = null !== (i = r.style.cssText.match(t)) && 1 === i.length, n = "ontouchstart" in e || e.navigator.msMaxTouchPoints, this.browser = {
                    support3d: s,
                    isTouch: n
                }
            },
            moveEvents: function () {
                !1 === this.options.mouseDrag && !1 === this.options.touchDrag || (this.gestures(), this.disabledEvents())
            },
            eventTypes: function () {
                var t = this,
                    e = ["s", "e", "x"];
                t.ev_types = {}, !0 === t.options.mouseDrag && !0 === t.options.touchDrag ? e = ["touchstart.owl mousedown.owl", "touchmove.owl mousemove.owl", "touchend.owl touchcancel.owl mouseup.owl"] : !1 === t.options.mouseDrag && !0 === t.options.touchDrag ? e = ["touchstart.owl", "touchmove.owl", "touchend.owl touchcancel.owl"] : !0 === t.options.mouseDrag && !1 === t.options.touchDrag && (e = ["mousedown.owl", "mousemove.owl", "mouseup.owl"]), t.ev_types.start = e[0], t.ev_types.move = e[1], t.ev_types.end = e[2]
            },
            disabledEvents: function () {
                this.$elem.on("dragstart.owl", function (t) {
                    t.preventDefault()
                }), this.$elem.on("mousedown.disableTextSelect", function (e) {
                    return t(e.target).is("input, textarea, select, option")
                })
            },
            gestures: function () {
                var i = this,
                    s = {
                        offsetX: 0,
                        offsetY: 0,
                        baseElWidth: 0,
                        relativePos: 0,
                        position: null,
                        minSwipe: null,
                        maxSwipe: null,
                        sliding: null,
                        dargging: null,
                        targetElement: null
                    };

                function n(t) {
                    if (void 0 !== t.touches) return {
                        x: t.touches[0].pageX,
                        y: t.touches[0].pageY
                    };
                    if (void 0 === t.touches) {
                        if (void 0 !== t.pageX) return {
                            x: t.pageX,
                            y: t.pageY
                        };
                        if (void 0 === t.pageX) return {
                            x: t.clientX,
                            y: t.clientY
                        }
                    }
                }

                function a(e) {
                    "on" === e ? (t(o).on(i.ev_types.move, r), t(o).on(i.ev_types.end, l)) : "off" === e && (t(o).off(i.ev_types.move), t(o).off(i.ev_types.end))
                }

                function r(a) {
                    var r, l, p = a.originalEvent || a || e.event;
                    i.newPosX = n(p).x - s.offsetX, i.newPosY = n(p).y - s.offsetY, i.newRelativeX = i.newPosX - s.relativePos, "function" == typeof i.options.startDragging && !0 !== s.dragging && 0 !== i.newRelativeX && (s.dragging = !0, i.options.startDragging.apply(i, [i.$elem])), (i.newRelativeX > 8 || i.newRelativeX < -8) && !0 === i.browser.isTouch && (void 0 !== p.preventDefault ? p.preventDefault() : p.returnValue = !1, s.sliding = !0), (i.newPosY > 10 || i.newPosY < -10) && !1 === s.sliding && t(o).off("touchmove.owl"), r = function () {
                        return i.newRelativeX / 5
                    }, l = function () {
                        return i.maximumPixels + i.newRelativeX / 5
                    }, i.newPosX = Math.max(Math.min(i.newPosX, r()), l()), !0 === i.browser.support3d ? i.transition3d(i.newPosX) : i.css2move(i.newPosX)
                }

                function l(o) {
                    var n, r, l, p = o.originalEvent || o || e.event;
                    p.target = p.target || p.srcElement, s.dragging = !1, !0 !== i.browser.isTouch && i.$owlWrapper.removeClass("grabbing"), i.newRelativeX < 0 ? i.dragDirection = i.owl.dragDirection = "left" : i.dragDirection = i.owl.dragDirection = "right", 0 !== i.newRelativeX && (n = i.getNewPosition(), i.goTo(n, !1, "drag"), s.targetElement === p.target && !0 !== i.browser.isTouch && (t(p.target).on("click.disable", function (e) {
                        e.stopImmediatePropagation(), e.stopPropagation(), e.preventDefault(), t(e.target).off("click.disable")
                    }), l = (r = t._data(p.target, "events").click).pop(), r.splice(0, 0, l))), a("off")
                }
                i.isCssFinish = !0, i.$elem.on(i.ev_types.start, ".owl-wrapper", function (o) {
                    var r, l = o.originalEvent || o || e.event;
                    if (3 === l.which) return !1;
                    if (!(i.itemsAmount <= i.options.items)) {
                        if (!1 === i.isCssFinish && !i.options.dragBeforeAnimFinish) return !1;
                        if (!1 === i.isCss3Finish && !i.options.dragBeforeAnimFinish) return !1;
                        !1 !== i.options.autoPlay && e.clearInterval(i.autoPlayInterval), !0 === i.browser.isTouch || i.$owlWrapper.hasClass("grabbing") || i.$owlWrapper.addClass("grabbing"), i.newPosX = 0, i.newRelativeX = 0, t(this).css(i.removeTransition()), r = t(this).position(), s.relativePos = r.left, s.offsetX = n(l).x - r.left, s.offsetY = n(l).y - r.top, a("on"), s.sliding = !1, s.targetElement = l.target || l.srcElement
                    }
                })
            },
            getNewPosition: function () {
                var t = this,
                    e = t.closestItem();
                return e > t.maximumItem ? (t.currentItem = t.maximumItem, e = t.maximumItem) : t.newPosX >= 0 && (e = 0, t.currentItem = 0), e
            },
            closestItem: function () {
                var e = this,
                    o = !0 === e.options.scrollPerPage ? e.pagesInArray : e.positionsInArray,
                    i = e.newPosX,
                    s = null;
                return t.each(o, function (n, a) {
                    i - e.itemWidth / 20 > o[n + 1] && i - e.itemWidth / 20 < a && "left" === e.moveDirection() ? (s = a, !0 === e.options.scrollPerPage ? e.currentItem = t.inArray(s, e.positionsInArray) : e.currentItem = n) : i + e.itemWidth / 20 < a && i + e.itemWidth / 20 > (o[n + 1] || o[n] - e.itemWidth) && "right" === e.moveDirection() && (!0 === e.options.scrollPerPage ? (s = o[n + 1] || o[o.length - 1], e.currentItem = t.inArray(s, e.positionsInArray)) : (s = o[n + 1], e.currentItem = n + 1))
                }), e.currentItem
            },
            moveDirection: function () {
                var t;
                return this.newRelativeX < 0 ? (t = "right", this.playDirection = "next") : (t = "left", this.playDirection = "prev"), t
            },
            customEvents: function () {
                var t = this;
                t.$elem.on("owl.next", function () {
                    t.next()
                }), t.$elem.on("owl.prev", function () {
                    t.prev()
                }), t.$elem.on("owl.play", function (e, o) {
                    t.options.autoPlay = o, t.play(), t.hoverStatus = "play"
                }), t.$elem.on("owl.stop", function () {
                    t.stop(), t.hoverStatus = "stop"
                }), t.$elem.on("owl.goTo", function (e, o) {
                    t.goTo(o)
                }), t.$elem.on("owl.jumpTo", function (e, o) {
                    t.jumpTo(o)
                })
            },
            stopOnHover: function () {
                var t = this;
                !0 === t.options.stopOnHover && !0 !== t.browser.isTouch && !1 !== t.options.autoPlay && (t.$elem.on("mouseover", function () {
                    t.stop()
                }), t.$elem.on("mouseout", function () {
                    "stop" !== t.hoverStatus && t.play()
                }))
            },
            lazyLoad: function () {
                var e, o, i, s, n = this;
                if (!1 === n.options.lazyLoad) return !1;
                for (e = 0; e < n.itemsAmount; e += 1) "loaded" !== (o = t(n.$owlItems[e])).data("owl-loaded") && (i = o.data("owl-item"), "string" == typeof (s = o.find(".lazyOwl")).data("src") ? (void 0 === o.data("owl-loaded") && (s.hide(), o.addClass("loading").data("owl-loaded", "checked")), (!0 !== n.options.lazyFollow || i >= n.currentItem) && i < n.currentItem + n.options.items && s.length && n.lazyPreload(o, s)) : o.data("owl-loaded", "loaded"))
            },
            lazyPreload: function (t, o) {
                var i, s = this,
                    n = 0;

                function a() {
                    t.data("owl-loaded", "loaded").removeClass("loading"), o.removeAttr("data-src"), "fade" === s.options.lazyEffect ? o.fadeIn(400) : o.show(), "function" == typeof s.options.afterLazyLoad && s.options.afterLazyLoad.apply(this, [s.$elem])
                }
                "DIV" === o.prop("tagName") ? (o.css("background-image", "url(" + o.data("src") + ")"), i = !0) : o[0].src = o.data("src"),
                    function t() {
                        n += 1, s.completeImg(o.get(0)) || !0 === i ? a() : n <= 100 ? e.setTimeout(t, 100) : a()
                    }()
            },
            autoHeight: function () {
                var o, i = this,
                    s = t(i.$owlItems[i.currentItem]).find("img");

                function n() {
                    var o = t(i.$owlItems[i.currentItem]).height();
                    i.wrapperOuter.css("height", o + "px"), i.wrapperOuter.hasClass("autoHeight") || e.setTimeout(function () {
                        i.wrapperOuter.addClass("autoHeight")
                    }, 0)
                }
                void 0 !== s.get(0) ? (o = 0, function t() {
                    o += 1, i.completeImg(s.get(0)) ? n() : o <= 100 ? e.setTimeout(t, 100) : i.wrapperOuter.css("height", "")
                }()) : n()
            },
            completeImg: function (t) {
                return !!t.complete && ("undefined" === typeof t.naturalWidth || 0 !== t.naturalWidth)
            },
            onVisibleItems: function () {
                var e, o = this;
                for (!0 === o.options.addClassActive && o.$owlItems.removeClass("active"), o.visibleItems = [], e = o.currentItem; e < o.currentItem + o.options.items; e += 1) o.visibleItems.push(e), !0 === o.options.addClassActive && t(o.$owlItems[e]).addClass("active");
                o.owl.visibleItems = o.visibleItems
            },
            transitionTypes: function (t) {
                this.outClass = "owl-" + t + "-out", this.inClass = "owl-" + t + "-in"
            },
            singleItemTransition: function () {
                var t, e = this,
                    o = e.outClass,
                    i = e.inClass,
                    s = e.$owlItems.eq(e.currentItem),
                    n = e.$owlItems.eq(e.prevItem),
                    a = Math.abs(e.positionsInArray[e.currentItem]) + e.positionsInArray[e.prevItem],
                    r = Math.abs(e.positionsInArray[e.currentItem]) + e.itemWidth / 2,
                    l = "webkitAnimationEnd oAnimationEnd MSAnimationEnd animationend";
                e.isTransition = !0, e.$owlWrapper.addClass("owl-origin").css({
                    "-webkit-transform-origin": r + "px",
                    "-moz-perspective-origin": r + "px",
                    "perspective-origin": r + "px"
                }), n.css((t = a, {
                    position: "relative",
                    left: t + "px"
                })).addClass(o).on(l, function () {
                    e.endPrev = !0, n.off(l), e.clearTransStyle(n, o)
                }), s.addClass(i).on(l, function () {
                    e.endCurrent = !0, s.off(l), e.clearTransStyle(s, i)
                })
            },
            clearTransStyle: function (t, e) {
                var o = this;
                t.css({
                    position: "",
                    left: ""
                }).removeClass(e), o.endPrev && o.endCurrent && (o.$owlWrapper.removeClass("owl-origin"), o.endPrev = !1, o.endCurrent = !1, o.isTransition = !1)
            },
            owlStatus: function () {
                var t = this;
                t.owl = {
                    userOptions: t.userOptions,
                    baseElement: t.$elem,
                    userItems: t.$userItems,
                    owlItems: t.$owlItems,
                    currentItem: t.currentItem,
                    prevItem: t.prevItem,
                    visibleItems: t.visibleItems,
                    isTouch: t.browser.isTouch,
                    browser: t.browser,
                    dragDirection: t.dragDirection
                }
            },
            clearEvents: function () {
                this.$elem.off(".owl owl mousedown.disableTextSelect"), t(o).off(".owl owl"), t(e).off("resize", this.resizer)
            },
            unWrap: function () {
                var t = this;
                0 !== t.$elem.children().length && (t.$owlWrapper.unwrap(), t.$userItems.unwrap().unwrap(), t.owlControls && t.owlControls.remove()), t.clearEvents(), t.$elem.attr("style", t.$elem.data("owl-originalStyles") || "").attr("class", t.$elem.data("owl-originalClasses"))
            },
            destroy: function () {
                this.stop(), e.clearInterval(this.checkVisible), this.unWrap(), this.$elem.removeData()
            },
            reinit: function (e) {
                var o = t.extend({}, this.userOptions, e);
                this.unWrap(), this.init(o, this.$elem)
            },
            addItem: function (t, e) {
                var o, i = this;
                return !!t && (0 === i.$elem.children().length ? (i.$elem.append(t), i.setVars(), !1) : (i.unWrap(), (o = void 0 === e || -1 === e ? -1 : e) >= i.$userItems.length || -1 === o ? i.$userItems.eq(-1).after(t) : i.$userItems.eq(o).before(t), void i.setVars()))
            },
            removeItem: function (t) {
                var e;
                if (0 === this.$elem.children().length) return !1;
                e = void 0 === t || -1 === t ? -1 : t, this.unWrap(), this.$userItems.eq(e).remove(), this.setVars()
            }
        };
        t.fn.owlCarousel = function (e) {
            return this.each(function () {
                if (!0 === t(this).data("owl-init")) return !1;
                t(this).data("owl-init", !0);
                var o = Object.create(i);
                o.init(e, this), t.data(this, "owlCarousel", o)
            })
        }, t.fn.owlCarousel.options = {
            items: 5,
            itemsCustom: !1,
            itemsDesktop: [1199, 4],
            itemsDesktopSmall: [979, 3],
            itemsTablet: [768, 2],
            itemsTabletSmall: !1,
            itemsMobile: [479, 1],
            singleItem: !1,
            itemsScaleUp: !1,
            slideSpeed: 200,
            paginationSpeed: 800,
            rewindSpeed: 1e3,
            autoPlay: !1,
            stopOnHover: !1,
            navigation: !1,
            navigationText: ["prev", "next"],
            rewindNav: !0,
            scrollPerPage: !1,
            pagination: !0,
            paginationNumbers: !1,
            responsive: !0,
            responsiveRefreshRate: 200,
            responsiveBaseWidth: e,
            baseClass: "owl-carousel",
            theme: "owl-theme",
            lazyLoad: !1,
            lazyFollow: !0,
            lazyEffect: "fade",
            autoHeight: !1,
            jsonPath: !1,
            jsonSuccess: !1,
            dragBeforeAnimFinish: !0,
            mouseDrag: !0,
            touchDrag: !0,
            addClassActive: !1,
            transitionStyle: !1,
            beforeUpdate: !1,
            afterUpdate: !1,
            beforeInit: !1,
            afterInit: !1,
            beforeMove: !1,
            afterMove: !1,
            afterAction: !1,
            startDragging: !1,
            afterLazyLoad: !1
        }
    }(jQuery, window, document);