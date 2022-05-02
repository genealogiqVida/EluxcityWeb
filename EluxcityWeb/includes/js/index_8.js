function MouseWheelHandler_8(e, element) {
    var delta = 0;
    if (typeof e === 'number') {
        delta = e;
    } else {
        if (e.deltaX !== 0) {
            delta = e.deltaX;
        } else {
            delta = e.deltaY;
        }
      //  e.preventDefault();
    }

    $('#carousel_8-items').animate({ scrollLeft: '-=' + (delta) }, 800);

}

function handleMouse_8(e) {
    MouseWheelHandler_8(e, carousel_8.items);
}

function leftScrollClick_8() {
    MouseWheelHandler_8(380, carousel_8.items);
}

function rightScrollClick_8() {

        MouseWheelHandler_8(-380, carousel_8.items);
    

    
}

function scrollEvent_8(e) {
    setLeftScrollOpacity_8();
    setRightScrollOpacity_8();
}

function setLeftScrollOpacity_8() {
    if (isScrolledAllLeft_8()) {
        carousel_8.leftScroll.style.opacity = 0;
    } else {
        carousel_8.leftScroll.style.opacity = 1;
    }
}

function isScrolledAllLeft_8() {
    if (carousel_8.items.scrollLeft === 0) {
        return true;
    } else {
        return false;
    }
}

function isScrolledAllRight_8() {
    if (carousel_8.items.scrollWidth > carousel_8.items.offsetWidth) {
        if (carousel_8.items.scrollLeft + carousel_8.items.offsetWidth === carousel_8.items.scrollWidth) {
            return true;
        }
    } else {
        return true;
    }

    return false;
}

function setRightScrollOpacity_8() {
    if (isScrolledAllRight_8()) {
        carousel_8.rightScroll.style.opacity = 0;
    } else {
        carousel_8.rightScroll.style.opacity = 1;
    }
}

