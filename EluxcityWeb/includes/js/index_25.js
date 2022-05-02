function MouseWheelHandler_25(e, element) {
    var delta = 0;
    if (typeof e === 'number') {
        delta = e;
    } else {
        if (e.deltaX !== 0) {
            delta = e.deltaX;
        } else {
            delta = e.deltaY;
        }
       // e.preventDefault();
    }

    $('#carousel_25-items').animate({ scrollLeft: '-=' + (delta) }, 800);

}

function handleMouse_25(e) {
    MouseWheelHandler_25(e, carousel_25.items);
}

function leftScrollClick_25() {
    MouseWheelHandler_25(380, carousel_25.items);
}

function rightScrollClick_25() {

   
        MouseWheelHandler_25(-380, carousel_25.items);
   

   
}

function scrollEvent_25(e) {
    setLeftScrollOpacity_25();
    setRightScrollOpacity_25();
}

function setLeftScrollOpacity_25() {
    if (isScrolledAllLeft_25()) {
        carousel_25.leftScroll.style.opacity = 0;
    } else {
        carousel_25.leftScroll.style.opacity = 1;
    }
}

function isScrolledAllLeft_25() {
    if (carousel_25.items.scrollLeft === 0) {
        return true;
    } else {
        return false;
    }
}

function isScrolledAllRight_25() {
    if (carousel_25.items.scrollWidth > carousel_25.items.offsetWidth) {
        if (carousel_25.items.scrollLeft + carousel_25.items.offsetWidth === carousel_25.items.scrollWidth) {
            return true;
        }
    } else {
        return true;
    }

    return false;
}

function setRightScrollOpacity_25() {
    if (isScrolledAllRight_25()) {
        carousel_25.rightScroll.style.opacity = 0;
    } else {
        carousel_25.rightScroll.style.opacity = 1;
    }
}

