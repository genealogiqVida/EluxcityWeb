function MouseWheelHandler_20(e, element) {
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

    $('#carousel_20-items').animate({ scrollLeft: '-=' + (delta) }, 800);

}

function handleMouse_20(e) {
    MouseWheelHandler_20(e, carousel_20.items);
}

function leftScrollClick_20() {
    MouseWheelHandler_20(380, carousel_20.items);
}

function rightScrollClick_20() {

   
        MouseWheelHandler_20(-380, carousel_20.items);
   

   
}

function scrollEvent_20(e) {
    setLeftScrollOpacity_20();
    setRightScrollOpacity_20();
}

function setLeftScrollOpacity_20() {
    if (isScrolledAllLeft_20()) {
        carousel_20.leftScroll.style.opacity = 0;
    } else {
        carousel_20.leftScroll.style.opacity = 1;
    }
}

function isScrolledAllLeft_20() {
    if (carousel_20.items.scrollLeft === 0) {
        return true;
    } else {
        return false;
    }
}

function isScrolledAllRight_20() {
    if (carousel_20.items.scrollWidth > carousel_20.items.offsetWidth) {
        if (carousel_20.items.scrollLeft + carousel_20.items.offsetWidth === carousel_20.items.scrollWidth) {
            return true;
        }
    } else {
        return true;
    }

    return false;
}

function setRightScrollOpacity_20() {
    if (isScrolledAllRight_20()) {
        carousel_20.rightScroll.style.opacity = 0;
    } else {
        carousel_20.rightScroll.style.opacity = 1;
    }
}

