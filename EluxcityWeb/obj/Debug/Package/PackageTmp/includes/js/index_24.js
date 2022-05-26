function MouseWheelHandler_24(e, element) {
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

    $('#carousel_24-items').animate({ scrollLeft: '-=' + (delta) }, 800);

}

function handleMouse_24(e) {
    MouseWheelHandler_24(e, carousel_24.items);
}

function leftScrollClick_24() {
    MouseWheelHandler_24(380, carousel_24.items);
}

function rightScrollClick_24() {

   
        MouseWheelHandler_24(-380, carousel_24.items);
   

   
}

function scrollEvent_24(e) {
    setLeftScrollOpacity_24();
    setRightScrollOpacity_24();
}

function setLeftScrollOpacity_24() {
    if (isScrolledAllLeft_24()) {
        carousel_24.leftScroll.style.opacity = 0;
    } else {
        carousel_24.leftScroll.style.opacity = 1;
    }
}

function isScrolledAllLeft_24() {
    if (carousel_24.items.scrollLeft === 0) {
        return true;
    } else {
        return false;
    }
}

function isScrolledAllRight_24() {
    if (carousel_24.items.scrollWidth > carousel_24.items.offsetWidth) {
        if (carousel_24.items.scrollLeft + carousel_24.items.offsetWidth === carousel_24.items.scrollWidth) {
            return true;
        }
    } else {
        return true;
    }

    return false;
}

function setRightScrollOpacity_24() {
    if (isScrolledAllRight_24()) {
        carousel_24.rightScroll.style.opacity = 0;
    } else {
        carousel_24.rightScroll.style.opacity = 1;
    }
}

