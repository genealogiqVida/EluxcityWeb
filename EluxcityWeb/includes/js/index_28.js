function MouseWheelHandler_28(e, element) {
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

    $('#carousel_28-items').animate({ scrollLeft: '-=' + (delta) }, 800);

}

function handleMouse_28(e) {
    MouseWheelHandler_28(e, carousel_28.items);
}

function leftScrollClick_28() {
    MouseWheelHandler_28(380, carousel_28.items);
}

function rightScrollClick_28() {

   
        MouseWheelHandler_28(-380, carousel_28.items);
   

   
}

function scrollEvent_28(e) {
    setLeftScrollOpacity_28();
    setRightScrollOpacity_28();
}

function setLeftScrollOpacity_28() {
    if (isScrolledAllLeft_28()) {
        carousel_28.leftScroll.style.opacity = 0;
    } else {
        carousel_28.leftScroll.style.opacity = 1;
    }
}

function isScrolledAllLeft_28() {
    if (carousel_28.items.scrollLeft === 0) {
        return true;
    } else {
        return false;
    }
}

function isScrolledAllRight_28() {
    if (carousel_28.items.scrollWidth > carousel_28.items.offsetWidth) {
        if (carousel_28.items.scrollLeft + carousel_28.items.offsetWidth === carousel_28.items.scrollWidth) {
            return true;
        }
    } else {
        return true;
    }

    return false;
}

function setRightScrollOpacity_28() {
    if (isScrolledAllRight_28()) {
        carousel_28.rightScroll.style.opacity = 0;
    } else {
        carousel_28.rightScroll.style.opacity = 1;
    }
}

