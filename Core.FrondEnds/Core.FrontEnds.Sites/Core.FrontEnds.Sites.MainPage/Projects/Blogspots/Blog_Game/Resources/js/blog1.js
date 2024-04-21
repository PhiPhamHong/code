
//<![CDATA[

/*! jQuery Migrate v1.2.1 | (c) 2005, 2013 jQuery Foundation, Inc. and other contributors | jquery.org/license */
jQuery.migrateMute === void 0 && (jQuery.migrateMute = !0), function (e, t, n) { function r(n) { var r = t.console; i[n] || (i[n] = !0, e.migrateWarnings.push(n), r && r.warn && !e.migrateMute && (r.warn("JQMIGRATE: " + n), e.migrateTrace && r.trace && r.trace())) } function a(t, a, i, o) { if (Object.defineProperty) try { return Object.defineProperty(t, a, { configurable: !0, enumerable: !0, get: function () { return r(o), i }, set: function (e) { r(o), i = e } }), n } catch (s) { } e._definePropertyBroken = !0, t[a] = i } var i = {}; e.migrateWarnings = [], !e.migrateMute && t.console && t.console.log && t.console.log("JQMIGRATE: Logging is active"), e.migrateTrace === n && (e.migrateTrace = !0), e.migrateReset = function () { i = {}, e.migrateWarnings.length = 0 }, "BackCompat" === document.compatMode && r("jQuery is not compatible with Quirks Mode"); var o = e("<input/>", { size: 1 }).attr("size") && e.attrFn, s = e.attr, u = e.attrHooks.value && e.attrHooks.value.get || function () { return null }, c = e.attrHooks.value && e.attrHooks.value.set || function () { return n }, l = /^(?:input|button)$/i, d = /^[238]$/, p = /^(?:autofocus|autoplay|async|checked|controls|defer|disabled|hidden|loop|multiple|open|readonly|required|scoped|selected)$/i, f = /^(?:checked|selected)$/i; a(e, "attrFn", o || {}, "jQuery.attrFn is deprecated"), e.attr = function (t, a, i, u) { var c = a.toLowerCase(), g = t && t.nodeType; return u && (4 > s.length && r("jQuery.fn.attr( props, pass ) is deprecated"), t && !d.test(g) && (o ? a in o : e.isFunction(e.fn[a]))) ? e(t)[a](i) : ("type" === a && i !== n && l.test(t.nodeName) && t.parentNode && r("Can't change the 'type' of an input or button in IE 6/7/8"), !e.attrHooks[c] && p.test(c) && (e.attrHooks[c] = { get: function (t, r) { var a, i = e.prop(t, r); return i === !0 || "boolean" != typeof i && (a = t.getAttributeNode(r)) && a.nodeValue !== !1 ? r.toLowerCase() : n }, set: function (t, n, r) { var a; return n === !1 ? e.removeAttr(t, r) : (a = e.propFix[r] || r, a in t && (t[a] = !0), t.setAttribute(r, r.toLowerCase())), r } }, f.test(c) && r("jQuery.fn.attr('" + c + "') may use property instead of attribute")), s.call(e, t, a, i)) }, e.attrHooks.value = { get: function (e, t) { var n = (e.nodeName || "").toLowerCase(); return "button" === n ? u.apply(this, arguments) : ("input" !== n && "option" !== n && r("jQuery.fn.attr('value') no longer gets properties"), t in e ? e.value : null) }, set: function (e, t) { var a = (e.nodeName || "").toLowerCase(); return "button" === a ? c.apply(this, arguments) : ("input" !== a && "option" !== a && r("jQuery.fn.attr('value', val) no longer sets properties"), e.value = t, n) } }; var g, h, v = e.fn.init, m = e.parseJSON, y = /^([^<]*)(<[\w\W]+>)([^>]*)$/; e.fn.init = function (t, n, a) { var i; return t && "string" == typeof t && !e.isPlainObject(n) && (i = y.exec(e.trim(t))) && i[0] && ("<" !== t.charAt(0) && r("$(html) HTML strings must start with '<' character"), i[3] && r("$(html) HTML text after last tag is ignored"), "#" === i[0].charAt(0) && (r("HTML string cannot start with a '#' character"), e.error("JQMIGRATE: Invalid selector string (XSS)")), n && n.context && (n = n.context), e.parseHTML) ? v.call(this, e.parseHTML(i[2], n, !0), n, a) : v.apply(this, arguments) }, e.fn.init.prototype = e.fn, e.parseJSON = function (e) { return e || null === e ? m.apply(this, arguments) : (r("jQuery.parseJSON requires a valid JSON string"), null) }, e.uaMatch = function (e) { e = e.toLowerCase(); var t = /(chrome)[ \/]([\w.]+)/.exec(e) || /(webkit)[ \/]([\w.]+)/.exec(e) || /(opera)(?:.*version|)[ \/]([\w.]+)/.exec(e) || /(msie) ([\w.]+)/.exec(e) || 0 > e.indexOf("compatible") && /(mozilla)(?:.*? rv:([\w.]+)|)/.exec(e) || []; return { browser: t[1] || "", version: t[2] || "0" } }, e.browser || (g = e.uaMatch(navigator.userAgent), h = {}, g.browser && (h[g.browser] = !0, h.version = g.version), h.chrome ? h.webkit = !0 : h.webkit && (h.safari = !0), e.browser = h), a(e, "browser", e.browser, "jQuery.browser is deprecated"), e.sub = function () { function t(e, n) { return new t.fn.init(e, n) } e.extend(!0, t, this), t.superclass = this, t.fn = t.prototype = this(), t.fn.constructor = t, t.sub = this.sub, t.fn.init = function (r, a) { return a && a instanceof e && !(a instanceof t) && (a = t(a)), e.fn.init.call(this, r, a, n) }, t.fn.init.prototype = t.fn; var n = t(document); return r("jQuery.sub() is deprecated"), t }, e.ajaxSetup({ converters: { "text json": e.parseJSON } }); var b = e.fn.data; e.fn.data = function (t) { var a, i, o = this[0]; return !o || "events" !== t || 1 !== arguments.length || (a = e.data(o, t), i = e._data(o, t), a !== n && a !== i || i === n) ? b.apply(this, arguments) : (r("Use of jQuery.fn.data('events') is deprecated"), i) }; var j = /\/(java|ecma)script/i, w = e.fn.andSelf || e.fn.addBack; e.fn.andSelf = function () { return r("jQuery.fn.andSelf() replaced by jQuery.fn.addBack()"), w.apply(this, arguments) }, e.clean || (e.clean = function (t, a, i, o) { a = a || document, a = !a.nodeType && a[0] || a, a = a.ownerDocument || a, r("jQuery.clean() is deprecated"); var s, u, c, l, d = []; if (e.merge(d, e.buildFragment(t, a).childNodes), i) for (c = function (e) { return !e.type || j.test(e.type) ? o ? o.push(e.parentNode ? e.parentNode.removeChild(e) : e) : i.appendChild(e) : n }, s = 0; null != (u = d[s]); s++)e.nodeName(u, "script") && c(u) || (i.appendChild(u), u.getElementsByTagName !== n && (l = e.grep(e.merge([], u.getElementsByTagName("script")), c), d.splice.apply(d, [s + 1, 0].concat(l)), s += l.length)); return d }); var Q = e.event.add, x = e.event.remove, k = e.event.trigger, N = e.fn.toggle, T = e.fn.live, M = e.fn.die, S = "ajaxStart|ajaxStop|ajaxSend|ajaxComplete|ajaxError|ajaxSuccess", C = RegExp("\\b(?:" + S + ")\\b"), H = /(?:^|\s)hover(\.\S+|)\b/, A = function (t) { return "string" != typeof t || e.event.special.hover ? t : (H.test(t) && r("'hover' pseudo-event is deprecated, use 'mouseenter mouseleave'"), t && t.replace(H, "mouseenter$1 mouseleave$1")) }; e.event.props && "attrChange" !== e.event.props[0] && e.event.props.unshift("attrChange", "attrName", "relatedNode", "srcElement"), e.event.dispatch && a(e.event, "handle", e.event.dispatch, "jQuery.event.handle is undocumented and deprecated"), e.event.add = function (e, t, n, a, i) { e !== document && C.test(t) && r("AJAX events should be attached to document: " + t), Q.call(this, e, A(t || ""), n, a, i) }, e.event.remove = function (e, t, n, r, a) { x.call(this, e, A(t) || "", n, r, a) }, e.fn.error = function () { var e = Array.prototype.slice.call(arguments, 0); return r("jQuery.fn.error() is deprecated"), e.splice(0, 0, "error"), arguments.length ? this.bind.apply(this, e) : (this.triggerHandler.apply(this, e), this) }, e.fn.toggle = function (t, n) { if (!e.isFunction(t) || !e.isFunction(n)) return N.apply(this, arguments); r("jQuery.fn.toggle(handler, handler...) is deprecated"); var a = arguments, i = t.guid || e.guid++, o = 0, s = function (n) { var r = (e._data(this, "lastToggle" + t.guid) || 0) % o; return e._data(this, "lastToggle" + t.guid, r + 1), n.preventDefault(), a[r].apply(this, arguments) || !1 }; for (s.guid = i; a.length > o;)a[o++].guid = i; return this.click(s) }, e.fn.live = function (t, n, a) { return r("jQuery.fn.live() is deprecated"), T ? T.apply(this, arguments) : (e(this.context).on(t, this.selector, n, a), this) }, e.fn.die = function (t, n) { return r("jQuery.fn.die() is deprecated"), M ? M.apply(this, arguments) : (e(this.context).off(t, this.selector || "**", n), this) }, e.event.trigger = function (e, t, n, a) { return n || C.test(e) || r("Global events are undocumented and deprecated"), k.call(this, e, t, n || document, a) }, e.each(S.split("|"), function (t, n) { e.event.special[n] = { setup: function () { var t = this; return t !== document && (e.event.add(document, n + "." + e.guid, function () { e.event.trigger(n, null, t, !0) }), e._data(this, n, e.guid++)), !1 }, teardown: function () { return this !== document && e.event.remove(document, n + "." + e._data(this, n)), !1 } } }) }(jQuery, window);

//]]>


//<![CDATA[

/**
 * jQuery Mobile Menu 
 * Turn unordered list menu into dropdown select menu
 * version 1.0(31-OCT-2011)
 * 
 * Built on top of the jQuery library
 *   http://jquery.com
 * 
 * Documentation
 * 	 http://github.com/mambows/mobilemenu
 */
(function ($) {
	$.fn.mobileMenu = function (options) {

		var defaults = {
			defaultText: 'Navigate to...',
			className: 'select-menu',
			containerClass: 'select-menu-container',
			subMenuClass: 'sub-menu',
			subMenuDash: '&ndash;'
		},
			settings = $.extend(defaults, options),
			el = $(this);

		this.each(function () {
			// ad class to submenu list
			el.find('ul').addClass(settings.subMenuClass);

			// Create base menu
			$('<div />', {
				'class': settings.containerClass
			}).insertAfter(el);

			// Create base menu
			$('<select />', {
				'class': settings.className
			}).appendTo('.' + settings.containerClass);

			// Create default option
			$('<option />', {
				"value": '#',
				"text": settings.defaultText
			}).appendTo('.' + settings.className);

			// Create select option from menu
			el.find('a').each(function () {
				var $this = $(this),
					optText = '&nbsp;' + $this.text(),
					optSub = $this.parents('.' + settings.subMenuClass),
					len = optSub.length,
					dash;

				// if menu has sub menu
				if ($this.parents('ul').hasClass(settings.subMenuClass)) {
					dash = Array(len + 1).join(settings.subMenuDash);
					optText = dash + optText;
				}

				// Now build menu and append it
				$('<option />', {
					"value": this.href,
					"html": optText,
					"selected": (this.href == window.location.href)
				}).appendTo('.' + settings.className);

			}); // End el.find('a').each

			// Change event on select element
			$('.' + settings.className).change(function () {
				var locations = $(this).val();
				if (locations !== '#') {
					window.location.href = $(this).val();
				};
			});

		}); // End this.each

		return this;

	};
})(jQuery);

//]]>




//<![CDATA[

(function ($) {
	/* hoverIntent by Brian Cherne */
	$.fn.hoverIntent = function (f, g) {
		// default configuration options
		var cfg = {
			sensitivity: 7,
			interval: 100,
			timeout: 0
		};
		// override configuration options with user supplied object
		cfg = $.extend(cfg, g ? { over: f, out: g } : f);

		// instantiate variables
		// cX, cY = current X and Y position of mouse, updated by mousemove event
		// pX, pY = previous X and Y position of mouse, set by mouseover and polling interval
		var cX, cY, pX, pY;

		// A private function for getting mouse position
		var track = function (ev) {
			cX = ev.pageX;
			cY = ev.pageY;
		};

		// A private function for comparing current and previous mouse position
		var compare = function (ev, ob) {
			ob.hoverIntent_t = clearTimeout(ob.hoverIntent_t);
			// compare mouse positions to see if they've crossed the threshold
			if ((Math.abs(pX - cX) + Math.abs(pY - cY)) < cfg.sensitivity) {
				$(ob).unbind("mousemove", track);
				// set hoverIntent state to true (so mouseOut can be called)
				ob.hoverIntent_s = 1;
				return cfg.over.apply(ob, [ev]);
			} else {
				// set previous coordinates for next time
				pX = cX; pY = cY;
				// use self-calling timeout, guarantees intervals are spaced out properly (avoids JavaScript timer bugs)
				ob.hoverIntent_t = setTimeout(function () { compare(ev, ob); }, cfg.interval);
			}
		};

		// A private function for delaying the mouseOut function
		var delay = function (ev, ob) {
			ob.hoverIntent_t = clearTimeout(ob.hoverIntent_t);
			ob.hoverIntent_s = 0;
			return cfg.out.apply(ob, [ev]);
		};

		// A private function for handling mouse 'hovering'
		var handleHover = function (e) {
			// next three lines copied from jQuery.hover, ignore children onMouseOver/onMouseOut
			var p = (e.type == "mouseover" ? e.fromElement : e.toElement) || e.relatedTarget;
			while (p && p != this) { try { p = p.parentNode; } catch (e) { p = this; } }
			if (p == this) { return false; }

			// copy objects to be passed into t (required for event object to be passed in IE)
			var ev = jQuery.extend({}, e);
			var ob = this;

			// cancel hoverIntent timer if it exists
			if (ob.hoverIntent_t) { ob.hoverIntent_t = clearTimeout(ob.hoverIntent_t); }

			// else e.type == "onmouseover"
			if (e.type == "mouseover") {
				// set "previous" X and Y position based on initial entry point
				pX = ev.pageX; pY = ev.pageY;
				// update "current" X and Y position based on mousemove
				$(ob).bind("mousemove", track);
				// start polling interval (self-calling timeout) to compare mouse coordinates over time
				if (ob.hoverIntent_s != 1) { ob.hoverIntent_t = setTimeout(function () { compare(ev, ob); }, cfg.interval); }

				// else e.type == "onmouseout"
			} else {
				// unbind expensive mousemove event
				$(ob).unbind("mousemove", track);
				// if hoverIntent state is true, then call the mouseOut function after the specified delay
				if (ob.hoverIntent_s == 1) { ob.hoverIntent_t = setTimeout(function () { delay(ev, ob); }, cfg.timeout); }
			}
		};

		// bind the function to the two event listeners
		return this.mouseover(handleHover).mouseout(handleHover);
	};

})(jQuery);

//]]>



//<![CDATA[

/*
 * Superfish v1.4.8 - jQuery menu widget
 * Copyright (c) 2008 Joel Birch
 *
 * Dual licensed under the MIT and GPL licenses:
 * 	http://www.opensource.org/licenses/mit-license.php
 * 	http://www.gnu.org/licenses/gpl.html
 *
 * CHANGELOG: http://users.tpg.com.au/j_birch/plugins/superfish/changelog.txt
 */

; (function ($) {
	$.fn.superfish = function (op) {

		var sf = $.fn.superfish,
			c = sf.c,
			$arrow = $(['<span class="', c.arrowClass, '"> &#187;</span>'].join('')),
			over = function () {
				var $$ = $(this), menu = getMenu($$);
				clearTimeout(menu.sfTimer);
				$$.showSuperfishUl().siblings().hideSuperfishUl();
			},
			out = function () {
				var $$ = $(this), menu = getMenu($$), o = sf.op;
				clearTimeout(menu.sfTimer);
				menu.sfTimer = setTimeout(function () {
					o.retainPath = ($.inArray($$[0], o.$path) > -1);
					$$.hideSuperfishUl();
					if (o.$path.length && $$.parents(['li.', o.hoverClass].join('')).length < 1) { over.call(o.$path); }
				}, o.delay);
			},
			getMenu = function ($menu) {
				var menu = $menu.parents(['ul.', c.menuClass, ':first'].join(''))[0];
				sf.op = sf.o[menu.serial];
				return menu;
			},
			addArrow = function ($a) { $a.addClass(c.anchorClass).append($arrow.clone()); };

		return this.each(function () {
			var s = this.serial = sf.o.length;
			var o = $.extend({}, sf.defaults, op);
			o.$path = $('li.' + o.pathClass, this).slice(0, o.pathLevels).each(function () {
				$(this).addClass([o.hoverClass, c.bcClass].join(' '))
					.filter('li:has(ul)').removeClass(o.pathClass);
			});
			sf.o[s] = sf.op = o;

			$('li:has(ul)', this)[($.fn.hoverIntent && !o.disableHI) ? 'hoverIntent' : 'hover'](over, out).each(function () {
				if (o.autoArrows) addArrow($('>a:first-child', this));
			})
				.not('.' + c.bcClass)
				.hideSuperfishUl();

			var $a = $('a', this);
			$a.each(function (i) {
				var $li = $a.eq(i).parents('li');
				$a.eq(i).focus(function () { over.call($li); }).blur(function () { out.call($li); });
			});
			o.onInit.call(this);

		}).each(function () {
			var menuClasses = [c.menuClass];
			if (sf.op.dropShadows && !($.browser.msie && $.browser.version < 7)) menuClasses.push(c.shadowClass);
			$(this).addClass(menuClasses.join(' '));
		});
	};

	var sf = $.fn.superfish;
	sf.o = [];
	sf.op = {};
	sf.IE7fix = function () {
		var o = sf.op;
		if ($.browser.msie && $.browser.version > 6 && o.dropShadows && o.animation.opacity != undefined)
			this.toggleClass(sf.c.shadowClass + '-off');
	};
	sf.c = {
		bcClass: 'sf-breadcrumb',
		menuClass: 'sf-js-enabled',
		anchorClass: 'sf-with-ul',
		arrowClass: 'sf-sub-indicator',
		shadowClass: 'sf-shadow'
	};
	sf.defaults = {
		hoverClass: 'sfHover',
		pathClass: 'overideThisToUse',
		pathLevels: 1,
		delay: 800,
		animation: { opacity: 'show' },
		speed: 'normal',
		autoArrows: true,
		dropShadows: true,
		disableHI: false,		// true disables hoverIntent detection
		onInit: function () { }, // callback functions
		onBeforeShow: function () { },
		onShow: function () { },
		onHide: function () { }
	};
	$.fn.extend({
		hideSuperfishUl: function () {
			var o = sf.op,
				not = (o.retainPath === true) ? o.$path : '';
			o.retainPath = false;
			var $ul = $(['li.', o.hoverClass].join(''), this).add(this).not(not).removeClass(o.hoverClass)
				.find('>ul').hide().css('visibility', 'hidden');
			o.onHide.call($ul);
			return this;
		},
		showSuperfishUl: function () {
			var o = sf.op,
				sh = sf.c.shadowClass + '-off',
				$ul = this.addClass(o.hoverClass)
					.find('>ul:hidden').css('visibility', 'visible');
			sf.IE7fix.call($ul);
			o.onBeforeShow.call($ul);
			$ul.animate(o.animation, o.speed, function () { sf.IE7fix.call($ul); o.onShow.call($ul); });
			return this;
		}
	});

})(jQuery);



//]]>




//<![CDATA[

/*
 * jQuery Cycle Plugin (with Transition Definitions)
 * Examples and documentation at: http://jquery.malsup.com/cycle/
 * Copyright (c) 2007-2010 M. Alsup
 * Version: 2.88 (08-JUN-2010)
 * Dual licensed under the MIT and GPL licenses.
 * http://jquery.malsup.com/license.html
 * Requires: jQuery v1.2.6 or later
 */
(function ($) {
	var ver = "2.88"; if ($.support == undefined) { $.support = { opacity: !($.browser.msie) }; } function debug(s) { if ($.fn.cycle.debug) { log(s); } } function log() { if (window.console && window.console.log) { window.console.log("[cycle] " + Array.prototype.join.call(arguments, " ")); } } $.fn.cycle = function (options, arg2) { var o = { s: this.selector, c: this.context }; if (this.length === 0 && options != "stop") { if (!$.isReady && o.s) { log("DOM not ready, queuing slideshow"); $(function () { $(o.s, o.c).cycle(options, arg2); }); return this; } log("terminating; zero elements found by selector" + ($.isReady ? "" : " (DOM not ready)")); return this; } return this.each(function () { var opts = handleArguments(this, options, arg2); if (opts === false) { return; } opts.updateActivePagerLink = opts.updateActivePagerLink || $.fn.cycle.updateActivePagerLink; if (this.cycleTimeout) { clearTimeout(this.cycleTimeout); } this.cycleTimeout = this.cyclePause = 0; var $cont = $(this); var $slides = opts.slideExpr ? $(opts.slideExpr, this) : $cont.children(); var els = $slides.get(); if (els.length < 2) { log("terminating; too few slides: " + els.length); return; } var opts2 = buildOptions($cont, $slides, els, opts, o); if (opts2 === false) { return; } var startTime = opts2.continuous ? 10 : getTimeout(els[opts2.currSlide], els[opts2.nextSlide], opts2, !opts2.rev); if (startTime) { startTime += (opts2.delay || 0); if (startTime < 10) { startTime = 10; } debug("first timeout: " + startTime); this.cycleTimeout = setTimeout(function () { go(els, opts2, 0, (!opts2.rev && !opts.backwards)); }, startTime); } }); }; function handleArguments(cont, options, arg2) { if (cont.cycleStop == undefined) { cont.cycleStop = 0; } if (options === undefined || options === null) { options = {}; } if (options.constructor == String) { switch (options) { case "destroy": case "stop": var opts = $(cont).data("cycle.opts"); if (!opts) { return false; } cont.cycleStop++; if (cont.cycleTimeout) { clearTimeout(cont.cycleTimeout); } cont.cycleTimeout = 0; $(cont).removeData("cycle.opts"); if (options == "destroy") { destroy(opts); } return false; case "toggle": cont.cyclePause = (cont.cyclePause === 1) ? 0 : 1; checkInstantResume(cont.cyclePause, arg2, cont); return false; case "pause": cont.cyclePause = 1; return false; case "resume": cont.cyclePause = 0; checkInstantResume(false, arg2, cont); return false; case "prev": case "next": var opts = $(cont).data("cycle.opts"); if (!opts) { log('options not found, "prev/next" ignored'); return false; } $.fn.cycle[options](opts); return false; default: options = { fx: options }; }return options; } else { if (options.constructor == Number) { var num = options; options = $(cont).data("cycle.opts"); if (!options) { log("options not found, can not advance slide"); return false; } if (num < 0 || num >= options.elements.length) { log("invalid slide index: " + num); return false; } options.nextSlide = num; if (cont.cycleTimeout) { clearTimeout(cont.cycleTimeout); cont.cycleTimeout = 0; } if (typeof arg2 == "string") { options.oneTimeFx = arg2; } go(options.elements, options, 1, num >= options.currSlide); return false; } } return options; function checkInstantResume(isPaused, arg2, cont) { if (!isPaused && arg2 === true) { var options = $(cont).data("cycle.opts"); if (!options) { log("options not found, can not resume"); return false; } if (cont.cycleTimeout) { clearTimeout(cont.cycleTimeout); cont.cycleTimeout = 0; } go(options.elements, options, 1, (!opts.rev && !opts.backwards)); } } } function removeFilter(el, opts) { if (!$.support.opacity && opts.cleartype && el.style.filter) { try { el.style.removeAttribute("filter"); } catch (smother) { } } } function destroy(opts) { if (opts.next) { $(opts.next).unbind(opts.prevNextEvent); } if (opts.prev) { $(opts.prev).unbind(opts.prevNextEvent); } if (opts.pager || opts.pagerAnchorBuilder) { $.each(opts.pagerAnchors || [], function () { this.unbind().remove(); }); } opts.pagerAnchors = null; if (opts.destroy) { opts.destroy(opts); } } function buildOptions($cont, $slides, els, options, o) { var opts = $.extend({}, $.fn.cycle.defaults, options || {}, $.metadata ? $cont.metadata() : $.meta ? $cont.data() : {}); if (opts.autostop) { opts.countdown = opts.autostopCount || els.length; } var cont = $cont[0]; $cont.data("cycle.opts", opts); opts.$cont = $cont; opts.stopCount = cont.cycleStop; opts.elements = els; opts.before = opts.before ? [opts.before] : []; opts.after = opts.after ? [opts.after] : []; opts.after.unshift(function () { opts.busy = 0; }); if (!$.support.opacity && opts.cleartype) { opts.after.push(function () { removeFilter(this, opts); }); } if (opts.continuous) { opts.after.push(function () { go(els, opts, 0, (!opts.rev && !opts.backwards)); }); } saveOriginalOpts(opts); if (!$.support.opacity && opts.cleartype && !opts.cleartypeNoBg) { clearTypeFix($slides); } if ($cont.css("position") == "static") { $cont.css("position", "relative"); } if (opts.width) { $cont.width(opts.width); } if (opts.height && opts.height != "auto") { $cont.height(opts.height); } if (opts.startingSlide) { opts.startingSlide = parseInt(opts.startingSlide); } else { if (opts.backwards) { opts.startingSlide = els.length - 1; } } if (opts.random) { opts.randomMap = []; for (var i = 0; i < els.length; i++) { opts.randomMap.push(i); } opts.randomMap.sort(function (a, b) { return Math.random() - 0.5; }); opts.randomIndex = 1; opts.startingSlide = opts.randomMap[1]; } else { if (opts.startingSlide >= els.length) { opts.startingSlide = 0; } } opts.currSlide = opts.startingSlide || 0; var first = opts.startingSlide; $slides.css({ position: "absolute", top: 0, left: 0 }).hide().each(function (i) { var z; if (opts.backwards) { z = first ? i <= first ? els.length + (i - first) : first - i : els.length - i; } else { z = first ? i >= first ? els.length - (i - first) : first - i : els.length - i; } $(this).css("z-index", z); }); $(els[first]).css("opacity", 1).show(); removeFilter(els[first], opts); if (opts.fit && opts.width) { $slides.width(opts.width); } if (opts.fit && opts.height && opts.height != "auto") { $slides.height(opts.height); } var reshape = opts.containerResize && !$cont.innerHeight(); if (reshape) { var maxw = 0, maxh = 0; for (var j = 0; j < els.length; j++) { var $e = $(els[j]), e = $e[0], w = $e.outerWidth(), h = $e.outerHeight(); if (!w) { w = e.offsetWidth || e.width || $e.attr("width"); } if (!h) { h = e.offsetHeight || e.height || $e.attr("height"); } maxw = w > maxw ? w : maxw; maxh = h > maxh ? h : maxh; } if (maxw > 0 && maxh > 0) { $cont.css({ width: maxw + "px", height: maxh + "px" }); } } if (opts.pause) { $cont.hover(function () { this.cyclePause++; }, function () { this.cyclePause--; }); } if (supportMultiTransitions(opts) === false) { return false; } var requeue = false; options.requeueAttempts = options.requeueAttempts || 0; $slides.each(function () { var $el = $(this); this.cycleH = (opts.fit && opts.height) ? opts.height : ($el.height() || this.offsetHeight || this.height || $el.attr("height") || 0); this.cycleW = (opts.fit && opts.width) ? opts.width : ($el.width() || this.offsetWidth || this.width || $el.attr("width") || 0); if ($el.is("img")) { var loadingIE = ($.browser.msie && this.cycleW == 28 && this.cycleH == 30 && !this.complete); var loadingFF = ($.browser.mozilla && this.cycleW == 34 && this.cycleH == 19 && !this.complete); var loadingOp = ($.browser.opera && ((this.cycleW == 42 && this.cycleH == 19) || (this.cycleW == 37 && this.cycleH == 17)) && !this.complete); var loadingOther = (this.cycleH == 0 && this.cycleW == 0 && !this.complete); if (loadingIE || loadingFF || loadingOp || loadingOther) { if (o.s && opts.requeueOnImageNotLoaded && ++options.requeueAttempts < 100) { log(options.requeueAttempts, " - img slide not loaded, requeuing slideshow: ", this.src, this.cycleW, this.cycleH); setTimeout(function () { $(o.s, o.c).cycle(options); }, opts.requeueTimeout); requeue = true; return false; } else { log("could not determine size of image: " + this.src, this.cycleW, this.cycleH); } } } return true; }); if (requeue) { return false; } opts.cssBefore = opts.cssBefore || {}; opts.animIn = opts.animIn || {}; opts.animOut = opts.animOut || {}; $slides.not(":eq(" + first + ")").css(opts.cssBefore); if (opts.cssFirst) { $($slides[first]).css(opts.cssFirst); } if (opts.timeout) { opts.timeout = parseInt(opts.timeout); if (opts.speed.constructor == String) { opts.speed = $.fx.speeds[opts.speed] || parseInt(opts.speed); } if (!opts.sync) { opts.speed = opts.speed / 2; } var buffer = opts.fx == "shuffle" ? 500 : 250; while ((opts.timeout - opts.speed) < buffer) { opts.timeout += opts.speed; } } if (opts.easing) { opts.easeIn = opts.easeOut = opts.easing; } if (!opts.speedIn) { opts.speedIn = opts.speed; } if (!opts.speedOut) { opts.speedOut = opts.speed; } opts.slideCount = els.length; opts.currSlide = opts.lastSlide = first; if (opts.random) { if (++opts.randomIndex == els.length) { opts.randomIndex = 0; } opts.nextSlide = opts.randomMap[opts.randomIndex]; } else { if (opts.backwards) { opts.nextSlide = opts.startingSlide == 0 ? (els.length - 1) : opts.startingSlide - 1; } else { opts.nextSlide = opts.startingSlide >= (els.length - 1) ? 0 : opts.startingSlide + 1; } } if (!opts.multiFx) { var init = $.fn.cycle.transitions[opts.fx]; if ($.isFunction(init)) { init($cont, $slides, opts); } else { if (opts.fx != "custom" && !opts.multiFx) { log("unknown transition: " + opts.fx, "; slideshow terminating"); return false; } } } var e0 = $slides[first]; if (opts.before.length) { opts.before[0].apply(e0, [e0, e0, opts, true]); } if (opts.after.length > 1) { opts.after[1].apply(e0, [e0, e0, opts, true]); } if (opts.next) { $(opts.next).bind(opts.prevNextEvent, function () { return advance(opts, opts.rev ? -1 : 1); }); } if (opts.prev) { $(opts.prev).bind(opts.prevNextEvent, function () { return advance(opts, opts.rev ? 1 : -1); }); } if (opts.pager || opts.pagerAnchorBuilder) { buildPager(els, opts); } exposeAddSlide(opts, els); return opts; } function saveOriginalOpts(opts) { opts.original = { before: [], after: [] }; opts.original.cssBefore = $.extend({}, opts.cssBefore); opts.original.cssAfter = $.extend({}, opts.cssAfter); opts.original.animIn = $.extend({}, opts.animIn); opts.original.animOut = $.extend({}, opts.animOut); $.each(opts.before, function () { opts.original.before.push(this); }); $.each(opts.after, function () { opts.original.after.push(this); }); } function supportMultiTransitions(opts) {
		var i, tx, txs = $.fn.cycle.transitions; if (opts.fx.indexOf(",") > 0) { opts.multiFx = true; opts.fxs = opts.fx.replace(/\s*/g, "").split(","); for (i = 0; i < opts.fxs.length; i++) { var fx = opts.fxs[i]; tx = txs[fx]; if (!tx || !txs.hasOwnProperty(fx) || !$.isFunction(tx)) { log("discarding unknown transition: ", fx); opts.fxs.splice(i, 1); i--; } } if (!opts.fxs.length) { log("No valid transitions named; slideshow terminating."); return false; } } else {
			if (opts.fx == "all…



//<![CDATA[
jQuery.noConflict();
			jQuery(function () {
				jQuery('ul.menu-primary').superfish({
					animation: {
						opacity: 'show'
					},
					autoArrows: true,
					dropShadows: false,
					speed: 200,
					delay: 800
				});
			});

			jQuery(document).ready(function () {
				jQuery('.menu-primary-container').mobileMenu({
					defaultText: 'Menu',
					className: 'menu-primary-responsive',
					containerClass: 'menu-primary-responsive-container',
					subMenuDash: '&ndash;'
				});
			});

			jQuery(document).ready(function () {
				var blloc = window.location.href;
				jQuery("#pagelistmenusblogul li a").each(function () {
					var blloc2 = jQuery(this).attr('href');
					if (blloc2 == blloc) {
						jQuery(this).parent('li').addClass('current-cat');
					}
				});
			});

			jQuery(function () {
				jQuery('ul.menu-secondary').superfish({
					animation: {
						opacity: 'show'
					},
					autoArrows: true,
					dropShadows: false,
					speed: 200,
					delay: 800
				});
			});

			jQuery(document).ready(function () {
				jQuery('.menu-secondary-container').mobileMenu({
					defaultText: 'Navigation',
					className: 'menu-secondary-responsive',
					containerClass: 'menu-secondary-responsive-container',
					subMenuDash: '&ndash;'
				});
			});

			jQuery(document).ready(function () {
				jQuery('.fp-slides').cycle({
					fx: 'scrollHorz',
					timeout: 4000,
					delay: 0,
					speed: 400,
					next: '.fp-next',
					prev: '.fp-prev',
					pager: '.fp-pager',
					continuous: 0,
					sync: 1,
					pause: 1,
					pauseOnPagerHover: 1,
					cleartype: true,
					cleartypeNoBg: true
				});
			});

			//]]>




			//<![CDATA[

			function showrecentcomments(json) { for (var i = 0; i < a_rc; i++) { var b_rc = json.feed.entry[i]; var c_rc; if (i == json.feed.entry.length) break; for (var k = 0; k < b_rc.link.length; k++) { if (b_rc.link[k].rel == 'alternate') { c_rc = b_rc.link[k].href; break; } } c_rc = c_rc.replace("#", "#comment-"); var d_rc = c_rc.split("#"); d_rc = d_rc[0]; var e_rc = d_rc.split("/"); e_rc = e_rc[5]; e_rc = e_rc.split(".html"); e_rc = e_rc[0]; var f_rc = e_rc.replace(/-/g, " "); f_rc = f_rc.link(d_rc); var g_rc = b_rc.published.$t; var h_rc = g_rc.substring(0, 4); var i_rc = g_rc.substring(5, 7); var j_rc = g_rc.substring(8, 10); var k_rc = new Array(); k_rc[1] = "Jan"; k_rc[2] = "Feb"; k_rc[3] = "Mar"; k_rc[4] = "Apr"; k_rc[5] = "May"; k_rc[6] = "Jun"; k_rc[7] = "Jul"; k_rc[8] = "Aug"; k_rc[9] = "Sep"; k_rc[10] = "Oct"; k_rc[11] = "Nov"; k_rc[12] = "Dec"; if ("content" in b_rc) { var l_rc = b_rc.content.$t; } else if ("summary" in b_rc) { var l_rc = b_rc.summary.$t; } else var l_rc = ""; var re = /<\S[^>]*>/g; l_rc = l_rc.replace(re, ""); if (m_rc == true) document.write('On ' + k_rc[parseInt(i_rc, 10)] + ' ' + j_rc + ' '); document.write('<a href="' + c_rc + '">' + b_rc.author[0].name.$t + '</a> commented'); if (n_rc == true) document.write(' on ' + f_rc); document.write(': '); if (l_rc.length < o_rc) { document.write('<i>&#8220;'); document.write(l_rc); document.write('&#8221;</i><br/><br/>'); } else { document.write('<i>&#8220;'); l_rc = l_rc.substring(0, o_rc); var p_rc = l_rc.lastIndexOf(" "); l_rc = l_rc.substring(0, p_rc); document.write(l_rc + '&hellip;&#8221;</i>'); document.write('<br/><br/>'); } } }

			function rp(json) { document.write('<ul>'); for (var i = 0; i < numposts; i++) { document.write('<li>'); var entry = json.feed.entry[i]; var posttitle = entry.title.$t; var posturl; if (i == json.feed.entry.length) break; for (var k = 0; k < entry.link.length; k++) { if (entry.link[k].rel == 'alternate') { posturl = entry.link[k].href; break } } posttitle = posttitle.link(posturl); var readmorelink = "(more)"; readmorelink = readmorelink.link(posturl); var postdate = entry.published.$t; var cdyear = postdate.substring(0, 4); var cdmonth = postdate.substring(5, 7); var cdday = postdate.substring(8, 10); var monthnames = new Array(); monthnames[1] = "Jan"; monthnames[2] = "Feb"; monthnames[3] = "Mar"; monthnames[4] = "Apr"; monthnames[5] = "May"; monthnames[6] = "Jun"; monthnames[7] = "Jul"; monthnames[8] = "Aug"; monthnames[9] = "Sep"; monthnames[10] = "Oct"; monthnames[11] = "Nov"; monthnames[12] = "Dec"; if ("content" in entry) { var postcontent = entry.content.$t } else if ("summary" in entry) { var postcontent = entry.summary.$t } else var postcontent = ""; var re = /<\S[^>]*>/g; postcontent = postcontent.replace(re, ""); document.write(posttitle); if (showpostdate == true) document.write(' - ' + monthnames[parseInt(cdmonth, 10)] + ' ' + cdday); if (showpostsummary == true) { if (postcontent.length < numchars) { document.write(postcontent) } else { postcontent = postcontent.substring(0, numchars); var quoteEnd = postcontent.lastIndexOf(" "); postcontent = postcontent.substring(0, quoteEnd); document.write(postcontent + '...' + readmorelink) } } document.write('</li>') } document.write('</ul>') }

//]]>


			summary_noimg = 550;
			summary_img = 450;
			img_thumb_height = 150;
			img_thumb_width = 200; 



			//<![CDATA[

			function removeHtmlTag(strx, chop) {
				if (strx.indexOf("<") != -1) {
					var s = strx.split("<");
					for (var i = 0; i < s.length; i++) {
						if (s[i].indexOf(">") != -1) {
							s[i] = s[i].substring(s[i].indexOf(">") + 1, s[i].length);
						}
					}
					strx = s.join("");
				}
				chop = (chop < strx.length - 1) ? chop : strx.length - 2;
				while (strx.charAt(chop - 1) != ' ' && strx.indexOf(' ', chop) != -1) chop++;
				strx = strx.substring(0, chop - 1);
				return strx + '...';
			}

			function createSummaryAndThumb(pID) {
				var div = document.getElementById(pID);
				var imgtag = "";
				var img = div.getElementsByTagName("img");
				var summ = summary_noimg;
				if (img.length >= 1) {
					imgtag = '<img src="' + img[0].src + '" class="pbtthumbimg"/>';
					summ = summary_img;
				}

				var summary = imgtag + '<div>' + removeHtmlTag(div.innerHTML, summ) + '</div>';
				div.innerHTML = summary;
			}

//]]>




