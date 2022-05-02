function MouseWheelHandler_10(e, element) {
    var delta = 0;
    if (typeof e === 'number') {
        delta = e;
    } else {
        if (e.deltaX !== 0) {
            delta = e.deltaX;
        } else {
            delta = e.deltaY;
        }
        //e.preventDefault();
    }

    $('#carousel_10-items').animate({ scrollLeft: '-=' + (delta) }, 800);

}

function handleMouse_10(e) {
    MouseWheelHandler_10(e, carousel_10.items);
}

function leftScrollClick_10() {
    MouseWheelHandler_10(380, carousel_10.items);
}

function rightScrollClick_10() {

   
        MouseWheelHandler_10(-380, carousel_10.items);
    

   
}

function scrollEvent_10(e) {
    setLeftScrollOpacity_10();
    setRightScrollOpacity_10();
}

function setLeftScrollOpacity_10() {
    if (isScrolledAllLeft_10()) {
        carousel_10.leftScroll.style.opacity = 0;
    } else {
        carousel_10.leftScroll.style.opacity = 1;
    }
}

function isScrolledAllLeft_10() {
    if (carousel_10.items.scrollLeft === 0) {
        return true;
    } else {
        return false;
    }
}

function isScrolledAllRight_10() {
    if (carousel_10.items.scrollWidth > carousel_10.items.offsetWidth) {
        if (carousel_10.items.scrollLeft + carousel_10.items.offsetWidth === carousel_10.items.scrollWidth) {
            return true;
        }
    } else {
        return true;
    }

    return false;
}

function setRightScrollOpacity_10() {
    if (isScrolledAllRight_10()) {
        carousel_10.rightScroll.style.opacity = 0;
    } else {
        carousel_10.rightScroll.style.opacity = 1;
    }
}

