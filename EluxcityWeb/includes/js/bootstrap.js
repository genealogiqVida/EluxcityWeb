/*!
 * Bootstrap v3.3.2 (http://getbootstrap.com)
 * Copyright 2011-2015 Twitter, Inc.
 * Licensed under MIT (https://github.com/twbs/bootstrap/blob/master/LICENSE)
 */

if (typeof jQuery === 'undefined') {
  throw new Error('Bootstrap\'s JavaScript requires jQuery')
}

+function ($j) {
  'use strict';
  var version = $j.fn.jquery.split(' ')[0].split('.')
  if ((version[0] < 2 && version[1] < 9) || (version[0] == 1 && version[1] == 9 && version[2] < 1)) {
    throw new Error('Bootstrap\'s JavaScript requires jQuery version 1.9.1 or higher')
  }
}(jQuery);

/* ========================================================================
 * Bootstrap: transition.js v3.3.2
 * http://getbootstrap.com/javascript/#transitions
 * ========================================================================
 * Copyright 2011-2015 Twitter, Inc.
 * Licensed under MIT (https://github.com/twbs/bootstrap/blob/master/LICENSE)
 * ======================================================================== */


+function ($j) {
  'use strict';

  // CSS TRANSITION SUPPORT (Shoutout: http://www.modernizr.com/)
  // ============================================================

  function transitionEnd() {
    var el = document.createElement('bootstrap')

    var transEndEventNames = {
      WebkitTransition : 'webkitTransitionEnd',
      MozTransition    : 'transitionend',
      OTransition      : 'oTransitionEnd otransitionend',
      transition       : 'transitionend'
    }

    for (var name in transEndEventNames) {
      if (el.style[name] !== undefined) {
        return { end: transEndEventNames[name] }
      }
    }

    return false // explicit for ie8 (  ._.)
  }

  // http://blog.alexmaccaw.com/css-transitions
  $j.fn.emulateTransitionEnd = function (duration) {
    var called = false
    var $jel = this
    $j(this).one('bsTransitionEnd', function () { called = true })
    var callback = function () { if (!called) $j($jel).trigger($j.support.transition.end) }
    setTimeout(callback, duration)
    return this
  }

  $j(function () {
    $j.support.transition = transitionEnd()

    if (!$j.support.transition) return

    $j.event.special.bsTransitionEnd = {
      bindType: $j.support.transition.end,
      delegateType: $j.support.transition.end,
      handle: function (e) {
        if ($j(e.target).is(this)) return e.handleObj.handler.apply(this, arguments)
      }
    }
  })

}(jQuery);

/* ========================================================================
 * Bootstrap: alert.js v3.3.2
 * http://getbootstrap.com/javascript/#alerts
 * ========================================================================
 * Copyright 2011-2015 Twitter, Inc.
 * Licensed under MIT (https://github.com/twbs/bootstrap/blob/master/LICENSE)
 * ======================================================================== */


+function ($j) {
  'use strict';

  // ALERT CLASS DEFINITION
  // ======================

  var dismiss = '[data-dismiss="alert"]'
  var Alert   = function (el) {
    $j(el).on('click', dismiss, this.close)
  }

  Alert.VERSION = '3.3.2'

  Alert.TRANSITION_DURATION = 150

  Alert.prototype.close = function (e) {
    var $jthis    = $j(this)
    var selector = $jthis.attr('data-target')

    if (!selector) {
      selector = $jthis.attr('href')
      selector = selector && selector.replace(/.*(?=#[^\s]*$j)/, '') // strip for ie7
    }

    var $jparent = $j(selector)

    if (e) e.preventDefault()

    if (!$jparent.length) {
      $jparent = $jthis.closest('.alert')
    }

    $jparent.trigger(e = $j.Event('close.bs.alert'))

    if (e.isDefaultPrevented()) return

    $jparent.removeClass('in')

    function removeElement() {
      // detach from parent, fire event then clean up data
      $jparent.detach().trigger('closed.bs.alert').remove()
    }

    $j.support.transition && $jparent.hasClass('fade') ?
      $jparent
        .one('bsTransitionEnd', removeElement)
        .emulateTransitionEnd(Alert.TRANSITION_DURATION) :
      removeElement()
  }


  // ALERT PLUGIN DEFINITION
  // =======================

  function Plugin(option) {
    return this.each(function () {
      var $jthis = $j(this)
      var data  = $jthis.data('bs.alert')

      if (!data) $jthis.data('bs.alert', (data = new Alert(this)))
      if (typeof option == 'string') data[option].call($jthis)
    })
  }

  var old = $j.fn.alert

  $j.fn.alert             = Plugin
  $j.fn.alert.Constructor = Alert


  // ALERT NO CONFLICT
  // =================

  $j.fn.alert.noConflict = function () {
    $j.fn.alert = old
    return this
  }


  // ALERT DATA-API
  // ==============

  $j(document).on('click.bs.alert.data-api', dismiss, Alert.prototype.close)

}(jQuery);

/* ========================================================================
 * Bootstrap: button.js v3.3.2
 * http://getbootstrap.com/javascript/#buttons
 * ========================================================================
 * Copyright 2011-2015 Twitter, Inc.
 * Licensed under MIT (https://github.com/twbs/bootstrap/blob/master/LICENSE)
 * ======================================================================== */


+function ($j) {
  'use strict';

  // BUTTON PUBLIC CLASS DEFINITION
  // ==============================

  var Button = function (element, options) {
    this.$jelement  = $j(element)
    this.options   = $j.extend({}, Button.DEFAULTS, options)
    this.isLoading = false
  }

  Button.VERSION  = '3.3.2'

  Button.DEFAULTS = {
    loadingText: 'loading...'
  }

  Button.prototype.setState = function (state) {
    var d    = 'disabled'
    var $jel  = this.$jelement
    var val  = $jel.is('input') ? 'val' : 'html'
    var data = $jel.data()

    state = state + 'Text'

    if (data.resetText == null) $jel.data('resetText', $jel[val]())

    // push to event loop to allow forms to submit
    setTimeout($j.proxy(function () {
      $jel[val](data[state] == null ? this.options[state] : data[state])

      if (state == 'loadingText') {
        this.isLoading = true
        $jel.addClass(d).attr(d, d)
      } else if (this.isLoading) {
        this.isLoading = false
        $jel.removeClass(d).removeAttr(d)
      }
    }, this), 0)
  }

  Button.prototype.toggle = function () {
    var changed = true
    var $jparent = this.$jelement.closest('[data-toggle="buttons"]')

    if ($jparent.length) {
      var $jinput = this.$jelement.find('input')
      if ($jinput.prop('type') == 'radio') {
        if ($jinput.prop('checked') && this.$jelement.hasClass('active')) changed = false
        else $jparent.find('.active').removeClass('active')
      }
      if (changed) $jinput.prop('checked', !this.$jelement.hasClass('active')).trigger('change')
    } else {
      this.$jelement.attr('aria-pressed', !this.$jelement.hasClass('active'))
    }

    if (changed) this.$jelement.toggleClass('active')
  }


  // BUTTON PLUGIN DEFINITION
  // ========================

  function Plugin(option) {
    return this.each(function () {
      var $jthis   = $j(this)
      var data    = $jthis.data('bs.button')
      var options = typeof option == 'object' && option

      if (!data) $jthis.data('bs.button', (data = new Button(this, options)))

      if (option == 'toggle') data.toggle()
      else if (option) data.setState(option)
    })
  }

  var old = $j.fn.button

  $j.fn.button             = Plugin
  $j.fn.button.Constructor = Button


  // BUTTON NO CONFLICT
  // ==================

  $j.fn.button.noConflict = function () {
    $j.fn.button = old
    return this
  }


  // BUTTON DATA-API
  // ===============

  $j(document)
    .on('click.bs.button.data-api', '[data-toggle^="button"]', function (e) {
      var $jbtn = $j(e.target)
      if (!$jbtn.hasClass('btn')) $jbtn = $jbtn.closest('.btn')
      Plugin.call($jbtn, 'toggle')
      e.preventDefault()
    })
    .on('focus.bs.button.data-api blur.bs.button.data-api', '[data-toggle^="button"]', function (e) {
      $j(e.target).closest('.btn').toggleClass('focus', /^focus(in)?$j/.test(e.type))
    })

}(jQuery);

/* ========================================================================
 * Bootstrap: carousel.js v3.3.2
 * http://getbootstrap.com/javascript/#carousel
 * ========================================================================
 * Copyright 2011-2015 Twitter, Inc.
 * Licensed under MIT (https://github.com/twbs/bootstrap/blob/master/LICENSE)
 * ======================================================================== */


+function ($j) {
  'use strict';

  // CAROUSEL CLASS DEFINITION
  // =========================

  var Carousel = function (element, options) {
    this.$jelement    = $j(element)
    this.$jindicators = this.$jelement.find('.carousel-indicators')
    this.options     = options
    this.paused      =
    this.sliding     =
    this.interval    =
    this.$jactive     =
    this.$jitems      = null

    this.options.keyboard && this.$jelement.on('keydown.bs.carousel', $j.proxy(this.keydown, this))

    this.options.pause == 'hover' && !('ontouchstart' in document.documentElement) && this.$jelement
      .on('mouseenter.bs.carousel', $j.proxy(this.pause, this))
      .on('mouseleave.bs.carousel', $j.proxy(this.cycle, this))
  }

  Carousel.VERSION  = '3.3.2'

  Carousel.TRANSITION_DURATION = 600

  Carousel.DEFAULTS = {
    interval: 5000,
    pause: 'hover',
    wrap: true,
    keyboard: true
  }

  Carousel.prototype.keydown = function (e) {
    if (/input|textarea/i.test(e.target.tagName)) return
    switch (e.which) {
      case 37: this.prev(); break
      case 39: this.next(); break
      default: return
    }

    e.preventDefault()
  }

  Carousel.prototype.cycle = function (e) {
    e || (this.paused = false)

    this.interval && clearInterval(this.interval)

    this.options.interval
      && !this.paused
      && (this.interval = setInterval($j.proxy(this.next, this), this.options.interval))

    return this
  }

  Carousel.prototype.getItemIndex = function (item) {
    this.$jitems = item.parent().children('.item')
    return this.$jitems.index(item || this.$jactive)
  }

  Carousel.prototype.getItemForDirection = function (direction, active) {
    var activeIndex = this.getItemIndex(active)
    var willWrap = (direction == 'prev' && activeIndex === 0)
                || (direction == 'next' && activeIndex == (this.$jitems.length - 1))
    if (willWrap && !this.options.wrap) return active
    var delta = direction == 'prev' ? -1 : 1
    var itemIndex = (activeIndex + delta) % this.$jitems.length
    return this.$jitems.eq(itemIndex)
  }

  Carousel.prototype.to = function (pos) {
    var that        = this
    var activeIndex = this.getItemIndex(this.$jactive = this.$jelement.find('.item.active'))

    if (pos > (this.$jitems.length - 1) || pos < 0) return

    if (this.sliding)       return this.$jelement.one('slid.bs.carousel', function () { that.to(pos) }) // yes, "slid"
    if (activeIndex == pos) return this.pause().cycle()

    return this.slide(pos > activeIndex ? 'next' : 'prev', this.$jitems.eq(pos))
  }

  Carousel.prototype.pause = function (e) {
    e || (this.paused = true)

    if (this.$jelement.find('.next, .prev').length && $j.support.transition) {
      this.$jelement.trigger($j.support.transition.end)
      this.cycle(true)
    }

    this.interval = clearInterval(this.interval)

    return this
  }

  Carousel.prototype.next = function () {
    if (this.sliding) return
    return this.slide('next')
  }

  Carousel.prototype.prev = function () {
    if (this.sliding) return
    return this.slide('prev')
  }

  Carousel.prototype.slide = function (type, next) {
    var $jactive   = this.$jelement.find('.item.active')
    var $jnext     = next || this.getItemForDirection(type, $jactive)
    var isCycling = this.interval
    var direction = type == 'next' ? 'left' : 'right'
    var that      = this

    if ($jnext.hasClass('active')) return (this.sliding = false)

    var relatedTarget = $jnext[0]
    var slideEvent = $j.Event('slide.bs.carousel', {
      relatedTarget: relatedTarget,
      direction: direction
    })
    this.$jelement.trigger(slideEvent)
    if (slideEvent.isDefaultPrevented()) return

    this.sliding = true

    isCycling && this.pause()

    if (this.$jindicators.length) {
      this.$jindicators.find('.active').removeClass('active')
      var $jnextIndicator = $j(this.$jindicators.children()[this.getItemIndex($jnext)])
      $jnextIndicator && $jnextIndicator.addClass('active')
    }

    var slidEvent = $j.Event('slid.bs.carousel', { relatedTarget: relatedTarget, direction: direction }) // yes, "slid"
    if ($j.support.transition && this.$jelement.hasClass('slide')) {
      $jnext.addClass(type)
      $jnext[0].offsetWidth // force reflow
      $jactive.addClass(direction)
      $jnext.addClass(direction)
      $jactive
        .one('bsTransitionEnd', function () {
          $jnext.removeClass([type, direction].join(' ')).addClass('active')
          $jactive.removeClass(['active', direction].join(' '))
          that.sliding = false
          setTimeout(function () {
            that.$jelement.trigger(slidEvent)
          }, 0)
        })
        .emulateTransitionEnd(Carousel.TRANSITION_DURATION)
    } else {
      $jactive.removeClass('active')
      $jnext.addClass('active')
      this.sliding = false
      this.$jelement.trigger(slidEvent)
    }

    isCycling && this.cycle()

    return this
  }


  // CAROUSEL PLUGIN DEFINITION
  // ==========================

  function Plugin(option) {
    return this.each(function () {
      var $jthis   = $j(this)
      var data    = $jthis.data('bs.carousel')
      var options = $j.extend({}, Carousel.DEFAULTS, $jthis.data(), typeof option == 'object' && option)
      var action  = typeof option == 'string' ? option : options.slide

      if (!data) $jthis.data('bs.carousel', (data = new Carousel(this, options)))
      if (typeof option == 'number') data.to(option)
      else if (action) data[action]()
      else if (options.interval) data.pause().cycle()
    })
  }

  var old = $j.fn.carousel

  $j.fn.carousel             = Plugin
  $j.fn.carousel.Constructor = Carousel


  // CAROUSEL NO CONFLICT
  // ====================

  $j.fn.carousel.noConflict = function () {
    $j.fn.carousel = old
    return this
  }


  // CAROUSEL DATA-API
  // =================

  var clickHandler = function (e) {
    var href
    var $jthis   = $j(this)
    var $jtarget = $j($jthis.attr('data-target') || (href = $jthis.attr('href')) && href.replace(/.*(?=#[^\s]+$j)/, '')) // strip for ie7
    if (!$jtarget.hasClass('carousel')) return
    var options = $j.extend({}, $jtarget.data(), $jthis.data())
    var slideIndex = $jthis.attr('data-slide-to')
    if (slideIndex) options.interval = false

    Plugin.call($jtarget, options)

    if (slideIndex) {
      $jtarget.data('bs.carousel').to(slideIndex)
    }

    e.preventDefault()
  }

  $j(document)
    .on('click.bs.carousel.data-api', '[data-slide]', clickHandler)
    .on('click.bs.carousel.data-api', '[data-slide-to]', clickHandler)

  $j(window).on('load', function () {
    $j('[data-ride="carousel"]').each(function () {
      var $jcarousel = $j(this)
      Plugin.call($jcarousel, $jcarousel.data())
    })
  })

}(jQuery);

/* ========================================================================
 * Bootstrap: collapse.js v3.3.2
 * http://getbootstrap.com/javascript/#collapse
 * ========================================================================
 * Copyright 2011-2015 Twitter, Inc.
 * Licensed under MIT (https://github.com/twbs/bootstrap/blob/master/LICENSE)
 * ======================================================================== */


+function ($j) {
  'use strict';

  // COLLAPSE PUBLIC CLASS DEFINITION
  // ================================

  var Collapse = function (element, options) {
    this.$jelement      = $j(element)
    this.options       = $j.extend({}, Collapse.DEFAULTS, options)
    this.$jtrigger      = $j(this.options.trigger).filter('[href="#' + element.id + '"], [data-target="#' + element.id + '"]')
    this.transitioning = null

    if (this.options.parent) {
      this.$jparent = this.getParent()
    } else {
      this.addAriaAndCollapsedClass(this.$jelement, this.$jtrigger)
    }

    if (this.options.toggle) this.toggle()
  }

  Collapse.VERSION  = '3.3.2'

  Collapse.TRANSITION_DURATION = 350

  Collapse.DEFAULTS = {
    toggle: true,
    trigger: '[data-toggle="collapse"]'
  }

  Collapse.prototype.dimension = function () {
    var hasWidth = this.$jelement.hasClass('width')
    return hasWidth ? 'width' : 'height'
  }

  Collapse.prototype.show = function () {
    if (this.transitioning || this.$jelement.hasClass('in')) return

    var activesData
    var actives = this.$jparent && this.$jparent.children('.panel').children('.in, .collapsing')

    if (actives && actives.length) {
      activesData = actives.data('bs.collapse')
      if (activesData && activesData.transitioning) return
    }

    var startEvent = $j.Event('show.bs.collapse')
    this.$jelement.trigger(startEvent)
    if (startEvent.isDefaultPrevented()) return

    if (actives && actives.length) {
      Plugin.call(actives, 'hide')
      activesData || actives.data('bs.collapse', null)
    }

    var dimension = this.dimension()

    this.$jelement
      .removeClass('collapse')
      .addClass('collapsing')[dimension](0)
      .attr('aria-expanded', true)

    this.$jtrigger
      .removeClass('collapsed')
      .attr('aria-expanded', true)

    this.transitioning = 1

    var complete = function () {
      this.$jelement
        .removeClass('collapsing')
        .addClass('collapse in')[dimension]('')
      this.transitioning = 0
      this.$jelement
        .trigger('shown.bs.collapse')
    }

    if (!$j.support.transition) return complete.call(this)

    var scrollSize = $j.camelCase(['scroll', dimension].join('-'))

    this.$jelement
      .one('bsTransitionEnd', $j.proxy(complete, this))
      .emulateTransitionEnd(Collapse.TRANSITION_DURATION)[dimension](this.$jelement[0][scrollSize])
  }

  Collapse.prototype.hide = function () {
    if (this.transitioning || !this.$jelement.hasClass('in')) return

    var startEvent = $j.Event('hide.bs.collapse')
    this.$jelement.trigger(startEvent)
    if (startEvent.isDefaultPrevented()) return

    var dimension = this.dimension()

    this.$jelement[dimension](this.$jelement[dimension]())[0].offsetHeight

    this.$jelement
      .addClass('collapsing')
      .removeClass('collapse in')
      .attr('aria-expanded', false)

    this.$jtrigger
      .addClass('collapsed')
      .attr('aria-expanded', false)

    this.transitioning = 1

    var complete = function () {
      this.transitioning = 0
      this.$jelement
        .removeClass('collapsing')
        .addClass('collapse')
        .trigger('hidden.bs.collapse')
    }

    if (!$j.support.transition) return complete.call(this)

    this.$jelement
      [dimension](0)
      .one('bsTransitionEnd', $j.proxy(complete, this))
      .emulateTransitionEnd(Collapse.TRANSITION_DURATION)
  }

  Collapse.prototype.toggle = function () {
    this[this.$jelement.hasClass('in') ? 'hide' : 'show']()
  }

  Collapse.prototype.getParent = function () {
    return $j(this.options.parent)
      .find('[data-toggle="collapse"][data-parent="' + this.options.parent + '"]')
      .each($j.proxy(function (i, element) {
        var $jelement = $j(element)
        this.addAriaAndCollapsedClass(getTargetFromTrigger($jelement), $jelement)
      }, this))
      .end()
  }

  Collapse.prototype.addAriaAndCollapsedClass = function ($jelement, $jtrigger) {
    var isOpen = $jelement.hasClass('in')

    $jelement.attr('aria-expanded', isOpen)
    $jtrigger
      .toggleClass('collapsed', !isOpen)
      .attr('aria-expanded', isOpen)
  }

  function getTargetFromTrigger($jtrigger) {
    var href
    var target = $jtrigger.attr('data-target')
      || (href = $jtrigger.attr('href')) && href.replace(/.*(?=#[^\s]+$j)/, '') // strip for ie7

    return $j(target)
  }


  // COLLAPSE PLUGIN DEFINITION
  // ==========================

  function Plugin(option) {
    return this.each(function () {
      var $jthis   = $j(this)
      var data    = $jthis.data('bs.collapse')
      var options = $j.extend({}, Collapse.DEFAULTS, $jthis.data(), typeof option == 'object' && option)

      if (!data && options.toggle && option == 'show') options.toggle = false
      if (!data) $jthis.data('bs.collapse', (data = new Collapse(this, options)))
      if (typeof option == 'string') data[option]()
    })
  }

  var old = $j.fn.collapse

  $j.fn.collapse             = Plugin
  $j.fn.collapse.Constructor = Collapse


  // COLLAPSE NO CONFLICT
  // ====================

  $j.fn.collapse.noConflict = function () {
    $j.fn.collapse = old
    return this
  }


  // COLLAPSE DATA-API
  // =================

  $j(document).on('click.bs.collapse.data-api', '[data-toggle="collapse"]', function (e) {
    var $jthis   = $j(this)

    if (!$jthis.attr('data-target')) e.preventDefault()

    var $jtarget = getTargetFromTrigger($jthis)
    var data    = $jtarget.data('bs.collapse')
    var option  = data ? 'toggle' : $j.extend({}, $jthis.data(), { trigger: this })

    Plugin.call($jtarget, option)
  })

}(jQuery);

/* ========================================================================
 * Bootstrap: dropdown.js v3.3.2
 * http://getbootstrap.com/javascript/#dropdowns
 * ========================================================================
 * Copyright 2011-2015 Twitter, Inc.
 * Licensed under MIT (https://github.com/twbs/bootstrap/blob/master/LICENSE)
 * ======================================================================== */


+function ($j) {
  'use strict';

  // DROPDOWN CLASS DEFINITION
  // =========================

  var backdrop = '.dropdown-backdrop'
  var toggle   = '[data-toggle="dropdown"]'
  var Dropdown = function (element) {
    $j(element).on('click.bs.dropdown', this.toggle)
  }

  Dropdown.VERSION = '3.3.2'

  Dropdown.prototype.toggle = function (e) {
    var $jthis = $j(this)

    if ($jthis.is('.disabled, :disabled')) return

    var $jparent  = getParent($jthis)
    var isActive = $jparent.hasClass('open')

    clearMenus()

    if (!isActive) {
      if ('ontouchstart' in document.documentElement && !$jparent.closest('.navbar-nav').length) {
        // if mobile we use a backdrop because click events don't delegate
        $j('<div class="dropdown-backdrop"/>').insertAfter($j(this)).on('click', clearMenus)
      }

      var relatedTarget = { relatedTarget: this }
      $jparent.trigger(e = $j.Event('show.bs.dropdown', relatedTarget))

      if (e.isDefaultPrevented()) return

      $jthis
        .trigger('focus')
        .attr('aria-expanded', 'true')

      $jparent
        .toggleClass('open')
        .trigger('shown.bs.dropdown', relatedTarget)
    }

    return false
  }

  Dropdown.prototype.keydown = function (e) {
    if (!/(38|40|27|32)/.test(e.which) || /input|textarea/i.test(e.target.tagName)) return

    var $jthis = $j(this)

    e.preventDefault()
    e.stopPropagation()

    if ($jthis.is('.disabled, :disabled')) return

    var $jparent  = getParent($jthis)
    var isActive = $jparent.hasClass('open')

    if ((!isActive && e.which != 27) || (isActive && e.which == 27)) {
      if (e.which == 27) $jparent.find(toggle).trigger('focus')
      return $jthis.trigger('click')
    }

    var desc = ' li:not(.divider):visible a'
    var $jitems = $jparent.find('[role="menu"]' + desc + ', [role="listbox"]' + desc)

    if (!$jitems.length) return

    var index = $jitems.index(e.target)

    if (e.which == 38 && index > 0)                 index--                        // up
    if (e.which == 40 && index < $jitems.length - 1) index++                        // down
    if (!~index)                                      index = 0

    $jitems.eq(index).trigger('focus')
  }

  function clearMenus(e) {
    if (e && e.which === 3) return
    $j(backdrop).remove()
    $j(toggle).each(function () {
      var $jthis         = $j(this)
      var $jparent       = getParent($jthis)
      var relatedTarget = { relatedTarget: this }

      if (!$jparent.hasClass('open')) return

      $jparent.trigger(e = $j.Event('hide.bs.dropdown', relatedTarget))

      if (e.isDefaultPrevented()) return

      $jthis.attr('aria-expanded', 'false')
      $jparent.removeClass('open').trigger('hidden.bs.dropdown', relatedTarget)
    })
  }

  function getParent($jthis) {
    var selector = $jthis.attr('data-target')

    if (!selector) {
      selector = $jthis.attr('href')
      selector = selector && /#[A-Za-z]/.test(selector) && selector.replace(/.*(?=#[^\s]*$j)/, '') // strip for ie7
    }

    var $jparent = selector && $j(selector)

    return $jparent && $jparent.length ? $jparent : $jthis.parent()
  }


  // DROPDOWN PLUGIN DEFINITION
  // ==========================

  function Plugin(option) {
    return this.each(function () {
      var $jthis = $j(this)
      var data  = $jthis.data('bs.dropdown')

      if (!data) $jthis.data('bs.dropdown', (data = new Dropdown(this)))
      if (typeof option == 'string') data[option].call($jthis)
    })
  }

  var old = $j.fn.dropdown

  $j.fn.dropdown             = Plugin
  $j.fn.dropdown.Constructor = Dropdown


  // DROPDOWN NO CONFLICT
  // ====================

  $j.fn.dropdown.noConflict = function () {
    $j.fn.dropdown = old
    return this
  }


  // APPLY TO STANDARD DROPDOWN ELEMENTS
  // ===================================

  $j(document)
    .on('click.bs.dropdown.data-api', clearMenus)
    .on('click.bs.dropdown.data-api', '.dropdown form', function (e) { e.stopPropagation() })
    .on('click.bs.dropdown.data-api', toggle, Dropdown.prototype.toggle)
    .on('keydown.bs.dropdown.data-api', toggle, Dropdown.prototype.keydown)
    .on('keydown.bs.dropdown.data-api', '[role="menu"]', Dropdown.prototype.keydown)
    .on('keydown.bs.dropdown.data-api', '[role="listbox"]', Dropdown.prototype.keydown)

}(jQuery);

/* ========================================================================
 * Bootstrap: modal.js v3.3.2
 * http://getbootstrap.com/javascript/#modals
 * ========================================================================
 * Copyright 2011-2015 Twitter, Inc.
 * Licensed under MIT (https://github.com/twbs/bootstrap/blob/master/LICENSE)
 * ======================================================================== */


+function ($j) {
  'use strict';

  // MODAL CLASS DEFINITION
  // ======================

  var Modal = function (element, options) {
    this.options        = options
    this.$jbody          = $j(document.body)
    this.$jelement       = $j(element)
    this.$jbackdrop      =
    this.isShown        = null
    this.scrollbarWidth = 0

    if (this.options.remote) {
      this.$jelement
        .find('.modal-content')
        .load(this.options.remote, $j.proxy(function () {
          this.$jelement.trigger('loaded.bs.modal')
        }, this))
    }
  }

  Modal.VERSION  = '3.3.2'

  Modal.TRANSITION_DURATION = 300
  Modal.BACKDROP_TRANSITION_DURATION = 150

  Modal.DEFAULTS = {
    backdrop: true,
    keyboard: true,
    show: true
  }

  Modal.prototype.toggle = function (_relatedTarget) {
    return this.isShown ? this.hide() : this.show(_relatedTarget)
  }

  Modal.prototype.show = function (_relatedTarget) {
    var that = this
    var e    = $j.Event('show.bs.modal', { relatedTarget: _relatedTarget })

    this.$jelement.trigger(e)

    if (this.isShown || e.isDefaultPrevented()) return

    this.isShown = true

    this.checkScrollbar()
    this.setScrollbar()
    this.$jbody.addClass('modal-open')

    this.escape()
    this.resize()

    this.$jelement.on('click.dismiss.bs.modal', '[data-dismiss="modal"]', $j.proxy(this.hide, this))

    this.backdrop(function () {
      var transition = $j.support.transition && that.$jelement.hasClass('fade')

      if (!that.$jelement.parent().length) {
        that.$jelement.appendTo(that.$jbody) // don't move modals dom position
      }

      that.$jelement
        .show()
        .scrollTop(0)

      if (that.options.backdrop) that.adjustBackdrop()
      that.adjustDialog()

      if (transition) {
        that.$jelement[0].offsetWidth // force reflow
      }

      that.$jelement
        .addClass('in')
        .attr('aria-hidden', false)

      that.enforceFocus()

      var e = $j.Event('shown.bs.modal', { relatedTarget: _relatedTarget })

      transition ?
        that.$jelement.find('.modal-dialog') // wait for modal to slide in
          .one('bsTransitionEnd', function () {
            that.$jelement.trigger('focus').trigger(e)
          })
          .emulateTransitionEnd(Modal.TRANSITION_DURATION) :
        that.$jelement.trigger('focus').trigger(e)
    })
  }

  Modal.prototype.hide = function (e) {
    if (e) e.preventDefault()

    e = $j.Event('hide.bs.modal')

    this.$jelement.trigger(e)

    if (!this.isShown || e.isDefaultPrevented()) return

    this.isShown = false

    this.escape()
    this.resize()

    $j(document).off('focusin.bs.modal')

    this.$jelement
      .removeClass('in')
      .attr('aria-hidden', true)
      .off('click.dismiss.bs.modal')

    $j.support.transition && this.$jelement.hasClass('fade') ?
      this.$jelement
        .one('bsTransitionEnd', $j.proxy(this.hideModal, this))
        .emulateTransitionEnd(Modal.TRANSITION_DURATION) :
      this.hideModal()
  }

  Modal.prototype.enforceFocus = function () {
    $j(document)
      .off('focusin.bs.modal') // guard against infinite focus loop
      .on('focusin.bs.modal', $j.proxy(function (e) {
        if (this.$jelement[0] !== e.target && !this.$jelement.has(e.target).length) {
          this.$jelement.trigger('focus')
        }
      }, this))
  }

  Modal.prototype.escape = function () {
    if (this.isShown && this.options.keyboard) {
      this.$jelement.on('keydown.dismiss.bs.modal', $j.proxy(function (e) {
        e.which == 27 && this.hide()
      }, this))
    } else if (!this.isShown) {
      this.$jelement.off('keydown.dismiss.bs.modal')
    }
  }

  Modal.prototype.resize = function () {
    if (this.isShown) {
      $j(window).on('resize.bs.modal', $j.proxy(this.handleUpdate, this))
    } else {
      $j(window).off('resize.bs.modal')
    }
  }

  Modal.prototype.hideModal = function () {
    var that = this
    this.$jelement.hide()
    this.backdrop(function () {
      that.$jbody.removeClass('modal-open')
      that.resetAdjustments()
      that.resetScrollbar()
      that.$jelement.trigger('hidden.bs.modal')
    })
  }

  Modal.prototype.removeBackdrop = function () {
    this.$jbackdrop && this.$jbackdrop.remove()
    this.$jbackdrop = null
  }

  Modal.prototype.backdrop = function (callback) {
    var that = this
    var animate = this.$jelement.hasClass('fade') ? 'fade' : ''

    if (this.isShown && this.options.backdrop) {
      var doAnimate = $j.support.transition && animate

      this.$jbackdrop = $j('<div class="modal-backdrop ' + animate + '" />')
        .prependTo(this.$jelement)
        .on('click.dismiss.bs.modal', $j.proxy(function (e) {
          if (e.target !== e.currentTarget) return
          this.options.backdrop == 'static'
            ? this.$jelement[0].focus.call(this.$jelement[0])
            : this.hide.call(this)
        }, this))

      if (doAnimate) this.$jbackdrop[0].offsetWidth // force reflow

      this.$jbackdrop.addClass('in')

      if (!callback) return

      doAnimate ?
        this.$jbackdrop
          .one('bsTransitionEnd', callback)
          .emulateTransitionEnd(Modal.BACKDROP_TRANSITION_DURATION) :
        callback()

    } else if (!this.isShown && this.$jbackdrop) {
      this.$jbackdrop.removeClass('in')

      var callbackRemove = function () {
        that.removeBackdrop()
        callback && callback()
      }
      $j.support.transition && this.$jelement.hasClass('fade') ?
        this.$jbackdrop
          .one('bsTransitionEnd', callbackRemove)
          .emulateTransitionEnd(Modal.BACKDROP_TRANSITION_DURATION) :
        callbackRemove()

    } else if (callback) {
      callback()
    }
  }

  // these following methods are used to handle overflowing modals

  Modal.prototype.handleUpdate = function () {
    if (this.options.backdrop) this.adjustBackdrop()
    this.adjustDialog()
  }

  Modal.prototype.adjustBackdrop = function () {
    this.$jbackdrop
      .css('height', 0)
      .css('height', this.$jelement[0].scrollHeight)
  }

  Modal.prototype.adjustDialog = function () {
    var modalIsOverflowing = this.$jelement[0].scrollHeight > document.documentElement.clientHeight

    this.$jelement.css({
      paddingLeft:  !this.bodyIsOverflowing && modalIsOverflowing ? this.scrollbarWidth : '',
      paddingRight: this.bodyIsOverflowing && !modalIsOverflowing ? this.scrollbarWidth : ''
    })
  }

  Modal.prototype.resetAdjustments = function () {
    this.$jelement.css({
      paddingLeft: '',
      paddingRight: ''
    })
  }

  Modal.prototype.checkScrollbar = function () {
    this.bodyIsOverflowing = document.body.scrollHeight > document.documentElement.clientHeight
    this.scrollbarWidth = this.measureScrollbar()
  }

  Modal.prototype.setScrollbar = function () {
    var bodyPad = parseInt((this.$jbody.css('padding-right') || 0), 10)
    if (this.bodyIsOverflowing) this.$jbody.css('padding-right', bodyPad + this.scrollbarWidth)
  }

  Modal.prototype.resetScrollbar = function () {
    this.$jbody.css('padding-right', '')
  }

  Modal.prototype.measureScrollbar = function () { // thx walsh
    var scrollDiv = document.createElement('div')
    scrollDiv.className = 'modal-scrollbar-measure'
    this.$jbody.append(scrollDiv)
    var scrollbarWidth = scrollDiv.offsetWidth - scrollDiv.clientWidth
    this.$jbody[0].removeChild(scrollDiv)
    return scrollbarWidth
  }


  // MODAL PLUGIN DEFINITION
  // =======================

  function Plugin(option, _relatedTarget) {
    return this.each(function () {
      var $jthis   = $j(this)
      var data    = $jthis.data('bs.modal')
      var options = $j.extend({}, Modal.DEFAULTS, $jthis.data(), typeof option == 'object' && option)

      if (!data) $jthis.data('bs.modal', (data = new Modal(this, options)))
      if (typeof option == 'string') data[option](_relatedTarget)
      else if (options.show) data.show(_relatedTarget)
    })
  }

  var old = $j.fn.modal

  $j.fn.modal             = Plugin
  $j.fn.modal.Constructor = Modal


  // MODAL NO CONFLICT
  // =================

  $j.fn.modal.noConflict = function () {
    $j.fn.modal = old
    return this
  }


  // MODAL DATA-API
  // ==============

  $j(document).on('click.bs.modal.data-api', '[data-toggle="modal"]', function (e) {
    var $jthis   = $j(this)
    var href    = $jthis.attr('href')
    var $jtarget = $j($jthis.attr('data-target') || (href && href.replace(/.*(?=#[^\s]+$j)/, ''))) // strip for ie7
    var option  = $jtarget.data('bs.modal') ? 'toggle' : $j.extend({ remote: !/#/.test(href) && href }, $jtarget.data(), $jthis.data())

    if ($jthis.is('a')) e.preventDefault()

    $jtarget.one('show.bs.modal', function (showEvent) {
      if (showEvent.isDefaultPrevented()) return // only register focus restorer if modal will actually get shown
      $jtarget.one('hidden.bs.modal', function () {
        $jthis.is(':visible') && $jthis.trigger('focus')
      })
    })
    Plugin.call($jtarget, option, this)
  })

}(jQuery);

/* ========================================================================
 * Bootstrap: tooltip.js v3.3.2
 * http://getbootstrap.com/javascript/#tooltip
 * Inspired by the original jQuery.tipsy by Jason Frame
 * ========================================================================
 * Copyright 2011-2015 Twitter, Inc.
 * Licensed under MIT (https://github.com/twbs/bootstrap/blob/master/LICENSE)
 * ======================================================================== */


+function ($j) {
  'use strict';

  // TOOLTIP PUBLIC CLASS DEFINITION
  // ===============================

  var Tooltip = function (element, options) {
    this.type       =
    this.options    =
    this.enabled    =
    this.timeout    =
    this.hoverState =
    this.$jelement   = null

    this.init('tooltip', element, options)
  }

  Tooltip.VERSION  = '3.3.2'

  Tooltip.TRANSITION_DURATION = 150

  Tooltip.DEFAULTS = {
    animation: true,
    placement: 'top',
    selector: false,
    template: '<div class="tooltip" role="tooltip"><div class="tooltip-arrow"></div><div class="tooltip-inner"></div></div>',
    trigger: 'hover focus',
    title: '',
    delay: 0,
    html: false,
    container: false,
    viewport: {
      selector: 'body',
      padding: 0
    }
  }

  Tooltip.prototype.init = function (type, element, options) {
    this.enabled   = true
    this.type      = type
    this.$jelement  = $j(element)
    this.options   = this.getOptions(options)
    this.$jviewport = this.options.viewport && $j(this.options.viewport.selector || this.options.viewport)

    var triggers = this.options.trigger.split(' ')

    for (var i = triggers.length; i--;) {
      var trigger = triggers[i]

      if (trigger == 'click') {
        this.$jelement.on('click.' + this.type, this.options.selector, $j.proxy(this.toggle, this))
      } else if (trigger != 'manual') {
        var eventIn  = trigger == 'hover' ? 'mouseenter' : 'focusin'
        var eventOut = trigger == 'hover' ? 'mouseleave' : 'focusout'

        this.$jelement.on(eventIn  + '.' + this.type, this.options.selector, $j.proxy(this.enter, this))
        this.$jelement.on(eventOut + '.' + this.type, this.options.selector, $j.proxy(this.leave, this))
      }
    }

    this.options.selector ?
      (this._options = $j.extend({}, this.options, { trigger: 'manual', selector: '' })) :
      this.fixTitle()
  }

  Tooltip.prototype.getDefaults = function () {
    return Tooltip.DEFAULTS
  }

  Tooltip.prototype.getOptions = function (options) {
    options = $j.extend({}, this.getDefaults(), this.$jelement.data(), options)

    if (options.delay && typeof options.delay == 'number') {
      options.delay = {
        show: options.delay,
        hide: options.delay
      }
    }

    return options
  }

  Tooltip.prototype.getDelegateOptions = function () {
    var options  = {}
    var defaults = this.getDefaults()

    this._options && $j.each(this._options, function (key, value) {
      if (defaults[key] != value) options[key] = value
    })

    return options
  }

  Tooltip.prototype.enter = function (obj) {
    var self = obj instanceof this.constructor ?
      obj : $j(obj.currentTarget).data('bs.' + this.type)

    if (self && self.$jtip && self.$jtip.is(':visible')) {
      self.hoverState = 'in'
      return
    }

    if (!self) {
      self = new this.constructor(obj.currentTarget, this.getDelegateOptions())
      $j(obj.currentTarget).data('bs.' + this.type, self)
    }

    clearTimeout(self.timeout)

    self.hoverState = 'in'

    if (!self.options.delay || !self.options.delay.show) return self.show()

    self.timeout = setTimeout(function () {
      if (self.hoverState == 'in') self.show()
    }, self.options.delay.show)
  }

  Tooltip.prototype.leave = function (obj) {
    var self = obj instanceof this.constructor ?
      obj : $j(obj.currentTarget).data('bs.' + this.type)

    if (!self) {
      self = new this.constructor(obj.currentTarget, this.getDelegateOptions())
      $j(obj.currentTarget).data('bs.' + this.type, self)
    }

    clearTimeout(self.timeout)

    self.hoverState = 'out'

    if (!self.options.delay || !self.options.delay.hide) return self.hide()

    self.timeout = setTimeout(function () {
      if (self.hoverState == 'out') self.hide()
    }, self.options.delay.hide)
  }

  Tooltip.prototype.show = function () {
    var e = $j.Event('show.bs.' + this.type)

    if (this.hasContent() && this.enabled) {
      this.$jelement.trigger(e)

      var inDom = $j.contains(this.$jelement[0].ownerDocument.documentElement, this.$jelement[0])
      if (e.isDefaultPrevented() || !inDom) return
      var that = this

      var $jtip = this.tip()

      var tipId = this.getUID(this.type)

      this.setContent()
      $jtip.attr('id', tipId)
      this.$jelement.attr('aria-describedby', tipId)

      if (this.options.animation) $jtip.addClass('fade')

      var placement = typeof this.options.placement == 'function' ?
        this.options.placement.call(this, $jtip[0], this.$jelement[0]) :
        this.options.placement

      var autoToken = /\s?auto?\s?/i
      var autoPlace = autoToken.test(placement)
      if (autoPlace) placement = placement.replace(autoToken, '') || 'top'

      $jtip
        .detach()
        .css({ top: 0, left: 0, display: 'block' })
        .addClass(placement)
        .data('bs.' + this.type, this)

      this.options.container ? $jtip.appendTo(this.options.container) : $jtip.insertAfter(this.$jelement)

      var pos          = this.getPosition()
      var actualWidth  = $jtip[0].offsetWidth
      var actualHeight = $jtip[0].offsetHeight

      if (autoPlace) {
        var orgPlacement = placement
        var $jcontainer   = this.options.container ? $j(this.options.container) : this.$jelement.parent()
        var containerDim = this.getPosition($jcontainer)

        placement = placement == 'bottom' && pos.bottom + actualHeight > containerDim.bottom ? 'top'    :
                    placement == 'top'    && pos.top    - actualHeight < containerDim.top    ? 'bottom' :
                    placement == 'right'  && pos.right  + actualWidth  > containerDim.width  ? 'left'   :
                    placement == 'left'   && pos.left   - actualWidth  < containerDim.left   ? 'right'  :
                    placement

        $jtip
          .removeClass(orgPlacement)
          .addClass(placement)
      }

      var calculatedOffset = this.getCalculatedOffset(placement, pos, actualWidth, actualHeight)

      this.applyPlacement(calculatedOffset, placement)

      var complete = function () {
        var prevHoverState = that.hoverState
        that.$jelement.trigger('shown.bs.' + that.type)
        that.hoverState = null

        if (prevHoverState == 'out') that.leave(that)
      }

      $j.support.transition && this.$jtip.hasClass('fade') ?
        $jtip
          .one('bsTransitionEnd', complete)
          .emulateTransitionEnd(Tooltip.TRANSITION_DURATION) :
        complete()
    }
  }

  Tooltip.prototype.applyPlacement = function (offset, placement) {
    var $jtip   = this.tip()
    var width  = $jtip[0].offsetWidth
    var height = $jtip[0].offsetHeight

    // manually read margins because getBoundingClientRect includes difference
    var marginTop = parseInt($jtip.css('margin-top'), 10)
    var marginLeft = parseInt($jtip.css('margin-left'), 10)

    // we must check for NaN for ie 8/9
    if (isNaN(marginTop))  marginTop  = 0
    if (isNaN(marginLeft)) marginLeft = 0

    offset.top  = offset.top  + marginTop
    offset.left = offset.left + marginLeft

    // $j.fn.offset doesn't round pixel values
    // so we use setOffset directly with our own function B-0
    $j.offset.setOffset($jtip[0], $j.extend({
      using: function (props) {
        $jtip.css({
          top: Math.round(props.top),
          left: Math.round(props.left)
        })
      }
    }, offset), 0)

    $jtip.addClass('in')

    // check to see if placing tip in new offset caused the tip to resize itself
    var actualWidth  = $jtip[0].offsetWidth
    var actualHeight = $jtip[0].offsetHeight

    if (placement == 'top' && actualHeight != height) {
      offset.top = offset.top + height - actualHeight
    }

    var delta = this.getViewportAdjustedDelta(placement, offset, actualWidth, actualHeight)

    if (delta.left) offset.left += delta.left
    else offset.top += delta.top

    var isVertical          = /top|bottom/.test(placement)
    var arrowDelta          = isVertical ? delta.left * 2 - width + actualWidth : delta.top * 2 - height + actualHeight
    var arrowOffsetPosition = isVertical ? 'offsetWidth' : 'offsetHeight'

    $jtip.offset(offset)
    this.replaceArrow(arrowDelta, $jtip[0][arrowOffsetPosition], isVertical)
  }

  Tooltip.prototype.replaceArrow = function (delta, dimension, isHorizontal) {
    this.arrow()
      .css(isHorizontal ? 'left' : 'top', 50 * (1 - delta / dimension) + '%')
      .css(isHorizontal ? 'top' : 'left', '')
  }

  Tooltip.prototype.setContent = function () {
    var $jtip  = this.tip()
    var title = this.getTitle()

    $jtip.find('.tooltip-inner')[this.options.html ? 'html' : 'text'](title)
    $jtip.removeClass('fade in top bottom left right')
  }

  Tooltip.prototype.hide = function (callback) {
    var that = this
    var $jtip = this.tip()
    var e    = $j.Event('hide.bs.' + this.type)

    function complete() {
      if (that.hoverState != 'in') $jtip.detach()
      that.$jelement
        .removeAttr('aria-describedby')
        .trigger('hidden.bs.' + that.type)
      callback && callback()
    }

    this.$jelement.trigger(e)

    if (e.isDefaultPrevented()) return

    $jtip.removeClass('in')

    $j.support.transition && this.$jtip.hasClass('fade') ?
      $jtip
        .one('bsTransitionEnd', complete)
        .emulateTransitionEnd(Tooltip.TRANSITION_DURATION) :
      complete()

    this.hoverState = null

    return this
  }

  Tooltip.prototype.fixTitle = function () {
    var $je = this.$jelement
    if ($je.attr('title') || typeof ($je.attr('data-original-title')) != 'string') {
      $je.attr('data-original-title', $je.attr('title') || '').attr('title', '')
    }
  }

  Tooltip.prototype.hasContent = function () {
    return this.getTitle()
  }

  Tooltip.prototype.getPosition = function ($jelement) {
    $jelement   = $jelement || this.$jelement

    var el     = $jelement[0]
    var isBody = el.tagName == 'BODY'

    var elRect    = el.getBoundingClientRect()
    if (elRect.width == null) {
      // width and height are missing in IE8, so compute them manually; see https://github.com/twbs/bootstrap/issues/14093
      elRect = $j.extend({}, elRect, { width: elRect.right - elRect.left, height: elRect.bottom - elRect.top })
    }
    var elOffset  = isBody ? { top: 0, left: 0 } : $jelement.offset()
    var scroll    = { scroll: isBody ? document.documentElement.scrollTop || document.body.scrollTop : $jelement.scrollTop() }
    var outerDims = isBody ? { width: $j(window).width(), height: $j(window).height() } : null

    return $j.extend({}, elRect, scroll, outerDims, elOffset)
  }

  Tooltip.prototype.getCalculatedOffset = function (placement, pos, actualWidth, actualHeight) {
    return placement == 'bottom' ? { top: pos.top + pos.height,   left: pos.left + pos.width / 2 - actualWidth / 2 } :
           placement == 'top'    ? { top: pos.top - actualHeight, left: pos.left + pos.width / 2 - actualWidth / 2 } :
           placement == 'left'   ? { top: pos.top + pos.height / 2 - actualHeight / 2, left: pos.left - actualWidth } :
        /* placement == 'right' */ { top: pos.top + pos.height / 2 - actualHeight / 2, left: pos.left + pos.width }

  }

  Tooltip.prototype.getViewportAdjustedDelta = function (placement, pos, actualWidth, actualHeight) {
    var delta = { top: 0, left: 0 }
    if (!this.$jviewport) return delta

    var viewportPadding = this.options.viewport && this.options.viewport.padding || 0
    var viewportDimensions = this.getPosition(this.$jviewport)

    if (/right|left/.test(placement)) {
      var topEdgeOffset    = pos.top - viewportPadding - viewportDimensions.scroll
      var bottomEdgeOffset = pos.top + viewportPadding - viewportDimensions.scroll + actualHeight
      if (topEdgeOffset < viewportDimensions.top) { // top overflow
        delta.top = viewportDimensions.top - topEdgeOffset
      } else if (bottomEdgeOffset > viewportDimensions.top + viewportDimensions.height) { // bottom overflow
        delta.top = viewportDimensions.top + viewportDimensions.height - bottomEdgeOffset
      }
    } else {
      var leftEdgeOffset  = pos.left - viewportPadding
      var rightEdgeOffset = pos.left + viewportPadding + actualWidth
      if (leftEdgeOffset < viewportDimensions.left) { // left overflow
        delta.left = viewportDimensions.left - leftEdgeOffset
      } else if (rightEdgeOffset > viewportDimensions.width) { // right overflow
        delta.left = viewportDimensions.left + viewportDimensions.width - rightEdgeOffset
      }
    }

    return delta
  }

  Tooltip.prototype.getTitle = function () {
    var title
    var $je = this.$jelement
    var o  = this.options

    title = $je.attr('data-original-title')
      || (typeof o.title == 'function' ? o.title.call($je[0]) :  o.title)

    return title
  }

  Tooltip.prototype.getUID = function (prefix) {
    do prefix += ~~(Math.random() * 1000000)
    while (document.getElementById(prefix))
    return prefix
  }

  Tooltip.prototype.tip = function () {
    return (this.$jtip = this.$jtip || $j(this.options.template))
  }

  Tooltip.prototype.arrow = function () {
    return (this.$jarrow = this.$jarrow || this.tip().find('.tooltip-arrow'))
  }

  Tooltip.prototype.enable = function () {
    this.enabled = true
  }

  Tooltip.prototype.disable = function () {
    this.enabled = false
  }

  Tooltip.prototype.toggleEnabled = function () {
    this.enabled = !this.enabled
  }

  Tooltip.prototype.toggle = function (e) {
    var self = this
    if (e) {
      self = $j(e.currentTarget).data('bs.' + this.type)
      if (!self) {
        self = new this.constructor(e.currentTarget, this.getDelegateOptions())
        $j(e.currentTarget).data('bs.' + this.type, self)
      }
    }

    self.tip().hasClass('in') ? self.leave(self) : self.enter(self)
  }

  Tooltip.prototype.destroy = function () {
    var that = this
    clearTimeout(this.timeout)
    this.hide(function () {
      that.$jelement.off('.' + that.type).removeData('bs.' + that.type)
    })
  }


  // TOOLTIP PLUGIN DEFINITION
  // =========================

  function Plugin(option) {
    return this.each(function () {
      var $jthis   = $j(this)
      var data    = $jthis.data('bs.tooltip')
      var options = typeof option == 'object' && option

      if (!data && option == 'destroy') return
      if (!data) $jthis.data('bs.tooltip', (data = new Tooltip(this, options)))
      if (typeof option == 'string') data[option]()
    })
  }

  var old = $j.fn.tooltip

  $j.fn.tooltip             = Plugin
  $j.fn.tooltip.Constructor = Tooltip


  // TOOLTIP NO CONFLICT
  // ===================

  $j.fn.tooltip.noConflict = function () {
    $j.fn.tooltip = old
    return this
  }

}(jQuery);

/* ========================================================================
 * Bootstrap: popover.js v3.3.2
 * http://getbootstrap.com/javascript/#popovers
 * ========================================================================
 * Copyright 2011-2015 Twitter, Inc.
 * Licensed under MIT (https://github.com/twbs/bootstrap/blob/master/LICENSE)
 * ======================================================================== */


+function ($j) {
  'use strict';

  // POPOVER PUBLIC CLASS DEFINITION
  // ===============================

  var Popover = function (element, options) {
    this.init('popover', element, options)
  }

  if (!$j.fn.tooltip) throw new Error('Popover requires tooltip.js')

  Popover.VERSION  = '3.3.2'

  Popover.DEFAULTS = $j.extend({}, $j.fn.tooltip.Constructor.DEFAULTS, {
    placement: 'right',
    trigger: 'click',
    content: '',
    template: '<div class="popover" role="tooltip"><div class="arrow"></div><h3 class="popover-title"></h3><div class="popover-content"></div></div>'
  })


  // NOTE: POPOVER EXTENDS tooltip.js
  // ================================

  Popover.prototype = $j.extend({}, $j.fn.tooltip.Constructor.prototype)

  Popover.prototype.constructor = Popover

  Popover.prototype.getDefaults = function () {
    return Popover.DEFAULTS
  }

  Popover.prototype.setContent = function () {
    var $jtip    = this.tip()
    var title   = this.getTitle()
    var content = this.getContent()

    $jtip.find('.popover-title')[this.options.html ? 'html' : 'text'](title)
    $jtip.find('.popover-content').children().detach().end()[ // we use append for html objects to maintain js events
      this.options.html ? (typeof content == 'string' ? 'html' : 'append') : 'text'
    ](content)

    $jtip.removeClass('fade top bottom left right in')

    // IE8 doesn't accept hiding via the `:empty` pseudo selector, we have to do
    // this manually by checking the contents.
    if (!$jtip.find('.popover-title').html()) $jtip.find('.popover-title').hide()
  }

  Popover.prototype.hasContent = function () {
    return this.getTitle() || this.getContent()
  }

  Popover.prototype.getContent = function () {
    var $je = this.$jelement
    var o  = this.options

    return $je.attr('data-content')
      || (typeof o.content == 'function' ?
            o.content.call($je[0]) :
            o.content)
  }

  Popover.prototype.arrow = function () {
    return (this.$jarrow = this.$jarrow || this.tip().find('.arrow'))
  }

  Popover.prototype.tip = function () {
    if (!this.$jtip) this.$jtip = $j(this.options.template)
    return this.$jtip
  }


  // POPOVER PLUGIN DEFINITION
  // =========================

  function Plugin(option) {
    return this.each(function () {
      var $jthis   = $j(this)
      var data    = $jthis.data('bs.popover')
      var options = typeof option == 'object' && option

      if (!data && option == 'destroy') return
      if (!data) $jthis.data('bs.popover', (data = new Popover(this, options)))
      if (typeof option == 'string') data[option]()
    })
  }

  var old = $j.fn.popover

  $j.fn.popover             = Plugin
  $j.fn.popover.Constructor = Popover


  // POPOVER NO CONFLICT
  // ===================

  $j.fn.popover.noConflict = function () {
    $j.fn.popover = old
    return this
  }

}(jQuery);

/* ========================================================================
 * Bootstrap: scrollspy.js v3.3.2
 * http://getbootstrap.com/javascript/#scrollspy
 * ========================================================================
 * Copyright 2011-2015 Twitter, Inc.
 * Licensed under MIT (https://github.com/twbs/bootstrap/blob/master/LICENSE)
 * ======================================================================== */


+function ($j) {
  'use strict';

  // SCROLLSPY CLASS DEFINITION
  // ==========================

  function ScrollSpy(element, options) {
    var process  = $j.proxy(this.process, this)

    this.$jbody          = $j('body')
    this.$jscrollElement = $j(element).is('body') ? $j(window) : $j(element)
    this.options        = $j.extend({}, ScrollSpy.DEFAULTS, options)
    this.selector       = (this.options.target || '') + ' .nav li > a'
    this.offsets        = []
    this.targets        = []
    this.activeTarget   = null
    this.scrollHeight   = 0

    this.$jscrollElement.on('scroll.bs.scrollspy', process)
    this.refresh()
    this.process()
  }

  ScrollSpy.VERSION  = '3.3.2'

  ScrollSpy.DEFAULTS = {
    offset: 10
  }

  ScrollSpy.prototype.getScrollHeight = function () {
    return this.$jscrollElement[0].scrollHeight || Math.max(this.$jbody[0].scrollHeight, document.documentElement.scrollHeight)
  }

  ScrollSpy.prototype.refresh = function () {
    var offsetMethod = 'offset'
    var offsetBase   = 0

    if (!$j.isWindow(this.$jscrollElement[0])) {
      offsetMethod = 'position'
      offsetBase   = this.$jscrollElement.scrollTop()
    }

    this.offsets = []
    this.targets = []
    this.scrollHeight = this.getScrollHeight()

    var self     = this

    this.$jbody
      .find(this.selector)
      .map(function () {
        var $jel   = $j(this)
        var href  = $jel.data('target') || $jel.attr('href')
        var $jhref = /^#./.test(href) && $j(href)

        return ($jhref
          && $jhref.length
          && $jhref.is(':visible')
          && [[$jhref[offsetMethod]().top + offsetBase, href]]) || null
      })
      .sort(function (a, b) { return a[0] - b[0] })
      .each(function () {
        self.offsets.push(this[0])
        self.targets.push(this[1])
      })
  }

  ScrollSpy.prototype.process = function () {
    var scrollTop    = this.$jscrollElement.scrollTop() + this.options.offset
    var scrollHeight = this.getScrollHeight()
    var maxScroll    = this.options.offset + scrollHeight - this.$jscrollElement.height()
    var offsets      = this.offsets
    var targets      = this.targets
    var activeTarget = this.activeTarget
    var i

    if (this.scrollHeight != scrollHeight) {
      this.refresh()
    }

    if (scrollTop >= maxScroll) {
      return activeTarget != (i = targets[targets.length - 1]) && this.activate(i)
    }

    if (activeTarget && scrollTop < offsets[0]) {
      this.activeTarget = null
      return this.clear()
    }

    for (i = offsets.length; i--;) {
      activeTarget != targets[i]
        && scrollTop >= offsets[i]
        && (!offsets[i + 1] || scrollTop <= offsets[i + 1])
        && this.activate(targets[i])
    }
  }

  ScrollSpy.prototype.activate = function (target) {
    this.activeTarget = target

    this.clear()

    var selector = this.selector +
        '[data-target="' + target + '"],' +
        this.selector + '[href="' + target + '"]'

    var active = $j(selector)
      .parents('li')
      .addClass('active')

    if (active.parent('.dropdown-menu').length) {
      active = active
        .closest('li.dropdown')
        .addClass('active')
    }

    active.trigger('activate.bs.scrollspy')
  }

  ScrollSpy.prototype.clear = function () {
    $j(this.selector)
      .parentsUntil(this.options.target, '.active')
      .removeClass('active')
  }


  // SCROLLSPY PLUGIN DEFINITION
  // ===========================

  function Plugin(option) {
    return this.each(function () {
      var $jthis   = $j(this)
      var data    = $jthis.data('bs.scrollspy')
      var options = typeof option == 'object' && option

      if (!data) $jthis.data('bs.scrollspy', (data = new ScrollSpy(this, options)))
      if (typeof option == 'string') data[option]()
    })
  }

  var old = $j.fn.scrollspy

  $j.fn.scrollspy             = Plugin
  $j.fn.scrollspy.Constructor = ScrollSpy


  // SCROLLSPY NO CONFLICT
  // =====================

  $j.fn.scrollspy.noConflict = function () {
    $j.fn.scrollspy = old
    return this
  }


  // SCROLLSPY DATA-API
  // ==================

  $j(window).on('load.bs.scrollspy.data-api', function () {
    $j('[data-spy="scroll"]').each(function () {
      var $jspy = $j(this)
      Plugin.call($jspy, $jspy.data())
    })
  })

}(jQuery);

/* ========================================================================
 * Bootstrap: tab.js v3.3.2
 * http://getbootstrap.com/javascript/#tabs
 * ========================================================================
 * Copyright 2011-2015 Twitter, Inc.
 * Licensed under MIT (https://github.com/twbs/bootstrap/blob/master/LICENSE)
 * ======================================================================== */


+function ($j) {
  'use strict';

  // TAB CLASS DEFINITION
  // ====================

  var Tab = function (element) {
    this.element = $j(element)
  }

  Tab.VERSION = '3.3.2'

  Tab.TRANSITION_DURATION = 150

  Tab.prototype.show = function () {
    var $jthis    = this.element
    var $jul      = $jthis.closest('ul:not(.dropdown-menu)')
    var selector = $jthis.data('target')

    if (!selector) {
      selector = $jthis.attr('href')
      selector = selector && selector.replace(/.*(?=#[^\s]*$j)/, '') // strip for ie7
    }

    if ($jthis.parent('li').hasClass('active')) return

    var $jprevious = $jul.find('.active:last a')
    var hideEvent = $j.Event('hide.bs.tab', {
      relatedTarget: $jthis[0]
    })
    var showEvent = $j.Event('show.bs.tab', {
      relatedTarget: $jprevious[0]
    })

    $jprevious.trigger(hideEvent)
    $jthis.trigger(showEvent)

    if (showEvent.isDefaultPrevented() || hideEvent.isDefaultPrevented()) return

    var $jtarget = $j(selector)

    this.activate($jthis.closest('li'), $jul)
    this.activate($jtarget, $jtarget.parent(), function () {
      $jprevious.trigger({
        type: 'hidden.bs.tab',
        relatedTarget: $jthis[0]
      })
      $jthis.trigger({
        type: 'shown.bs.tab',
        relatedTarget: $jprevious[0]
      })
    })
  }

  Tab.prototype.activate = function (element, container, callback) {
    var $jactive    = container.find('> .active')
    var transition = callback
      && $j.support.transition
      && (($jactive.length && $jactive.hasClass('fade')) || !!container.find('> .fade').length)

    function next() {
      $jactive
        .removeClass('active')
        .find('> .dropdown-menu > .active')
          .removeClass('active')
        .end()
        .find('[data-toggle="tab"]')
          .attr('aria-expanded', false)

      element
        .addClass('active')
        .find('[data-toggle="tab"]')
          .attr('aria-expanded', true)

      if (transition) {
        element[0].offsetWidth // reflow for transition
        element.addClass('in')
      } else {
        element.removeClass('fade')
      }

      if (element.parent('.dropdown-menu')) {
        element
          .closest('li.dropdown')
            .addClass('active')
          .end()
          .find('[data-toggle="tab"]')
            .attr('aria-expanded', true)
      }

      callback && callback()
    }

    $jactive.length && transition ?
      $jactive
        .one('bsTransitionEnd', next)
        .emulateTransitionEnd(Tab.TRANSITION_DURATION) :
      next()

    $jactive.removeClass('in')
  }


  // TAB PLUGIN DEFINITION
  // =====================

  function Plugin(option) {
    return this.each(function () {
      var $jthis = $j(this)
      var data  = $jthis.data('bs.tab')

      if (!data) $jthis.data('bs.tab', (data = new Tab(this)))
      if (typeof option == 'string') data[option]()
    })
  }

  var old = $j.fn.tab

  $j.fn.tab             = Plugin
  $j.fn.tab.Constructor = Tab


  // TAB NO CONFLICT
  // ===============

  $j.fn.tab.noConflict = function () {
    $j.fn.tab = old
    return this
  }


  // TAB DATA-API
  // ============

  var clickHandler = function (e) {
    e.preventDefault()
    Plugin.call($j(this), 'show')
  }

  $j(document)
    .on('click.bs.tab.data-api', '[data-toggle="tab"]', clickHandler)
    .on('click.bs.tab.data-api', '[data-toggle="pill"]', clickHandler)

}(jQuery);

/* ========================================================================
 * Bootstrap: affix.js v3.3.2
 * http://getbootstrap.com/javascript/#affix
 * ========================================================================
 * Copyright 2011-2015 Twitter, Inc.
 * Licensed under MIT (https://github.com/twbs/bootstrap/blob/master/LICENSE)
 * ======================================================================== */


+function ($j) {
  'use strict';

  // AFFIX CLASS DEFINITION
  // ======================

  var Affix = function (element, options) {
    this.options = $j.extend({}, Affix.DEFAULTS, options)

    this.$jtarget = $j(this.options.target)
      .on('scroll.bs.affix.data-api', $j.proxy(this.checkPosition, this))
      .on('click.bs.affix.data-api',  $j.proxy(this.checkPositionWithEventLoop, this))

    this.$jelement     = $j(element)
    this.affixed      =
    this.unpin        =
    this.pinnedOffset = null

    this.checkPosition()
  }

  Affix.VERSION  = '3.3.2'

  Affix.RESET    = 'affix affix-top affix-bottom'

  Affix.DEFAULTS = {
    offset: 0,
    target: window
  }

  Affix.prototype.getState = function (scrollHeight, height, offsetTop, offsetBottom) {
    var scrollTop    = this.$jtarget.scrollTop()
    var position     = this.$jelement.offset()
    var targetHeight = this.$jtarget.height()

    if (offsetTop != null && this.affixed == 'top') return scrollTop < offsetTop ? 'top' : false

    if (this.affixed == 'bottom') {
      if (offsetTop != null) return (scrollTop + this.unpin <= position.top) ? false : 'bottom'
      return (scrollTop + targetHeight <= scrollHeight - offsetBottom) ? false : 'bottom'
    }

    var initializing   = this.affixed == null
    var colliderTop    = initializing ? scrollTop : position.top
    var colliderHeight = initializing ? targetHeight : height

    if (offsetTop != null && scrollTop <= offsetTop) return 'top'
    if (offsetBottom != null && (colliderTop + colliderHeight >= scrollHeight - offsetBottom)) return 'bottom'

    return false
  }

  Affix.prototype.getPinnedOffset = function () {
    if (this.pinnedOffset) return this.pinnedOffset
    this.$jelement.removeClass(Affix.RESET).addClass('affix')
    var scrollTop = this.$jtarget.scrollTop()
    var position  = this.$jelement.offset()
    return (this.pinnedOffset = position.top - scrollTop)
  }

  Affix.prototype.checkPositionWithEventLoop = function () {
    setTimeout($j.proxy(this.checkPosition, this), 1)
  }

  Affix.prototype.checkPosition = function () {
    if (!this.$jelement.is(':visible')) return

    var height       = this.$jelement.height()
    var offset       = this.options.offset
    var offsetTop    = offset.top
    var offsetBottom = offset.bottom
    var scrollHeight = $j('body').height()

    if (typeof offset != 'object')         offsetBottom = offsetTop = offset
    if (typeof offsetTop == 'function')    offsetTop    = offset.top(this.$jelement)
    if (typeof offsetBottom == 'function') offsetBottom = offset.bottom(this.$jelement)

    var affix = this.getState(scrollHeight, height, offsetTop, offsetBottom)

    if (this.affixed != affix) {
      if (this.unpin != null) this.$jelement.css('top', '')

      var affixType = 'affix' + (affix ? '-' + affix : '')
      var e         = $j.Event(affixType + '.bs.affix')

      this.$jelement.trigger(e)

      if (e.isDefaultPrevented()) return

      this.affixed = affix
      this.unpin = affix == 'bottom' ? this.getPinnedOffset() : null

      this.$jelement
        .removeClass(Affix.RESET)
        .addClass(affixType)
        .trigger(affixType.replace('affix', 'affixed') + '.bs.affix')
    }

    if (affix == 'bottom') {
      this.$jelement.offset({
        top: scrollHeight - height - offsetBottom
      })
    }
  }


  // AFFIX PLUGIN DEFINITION
  // =======================

  function Plugin(option) {
    return this.each(function () {
      var $jthis   = $j(this)
      var data    = $jthis.data('bs.affix')
      var options = typeof option == 'object' && option

      if (!data) $jthis.data('bs.affix', (data = new Affix(this, options)))
      if (typeof option == 'string') data[option]()
    })
  }

  var old = $j.fn.affix

  $j.fn.affix             = Plugin
  $j.fn.affix.Constructor = Affix


  // AFFIX NO CONFLICT
  // =================

  $j.fn.affix.noConflict = function () {
    $j.fn.affix = old
    return this
  }


  // AFFIX DATA-API
  // ==============

  $j(window).on('load', function () {
    $j('[data-spy="affix"]').each(function () {
      var $jspy = $j(this)
      var data = $jspy.data()

      data.offset = data.offset || {}

      if (data.offsetBottom != null) data.offset.bottom = data.offsetBottom
      if (data.offsetTop    != null) data.offset.top    = data.offsetTop

      Plugin.call($jspy, data)
    })
  })

}(jQuery);
