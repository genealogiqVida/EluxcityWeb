function MouseWheelHandler_26(e, element) {
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

    $('#carousel_26-items').animate({ scrollLeft: '-=' + (delta) }, 800);

}

function handleMouse_26(e) {
    MouseWheelHandler_26(e, carousel_26.items);
}

function leftScrollClick_26() {
    MouseWheelHandler_26(380, carousel_26.items);
}

function rightScrollClick_26() {

   
        MouseWheelHandler_26(-380, carousel_26.items);
   

   
}

function scrollEvent_26(e) {
    setLeftScrollOpacity_26();
    setRightScrollOpacity_26();
}

function setLeftScrollOpacity_26() {
    if (isScrolledAllLeft_26()) {
        carousel_26.leftScroll.style.opacity = 0;
    } else {
        carousel_26.leftScroll.style.opacity = 1;
    }
}

function isScrolledAllLeft_26() {
    if (carousel_26.items.scrollLeft === 0) {
        return true;
    } else {
        return false;
    }
}

function isScrolledAllRight_26() {
    if (carousel_26.items.scrollWidth > carousel_26.items.offsetWidth) {
        if (carousel_26.items.scrollLeft + carousel_26.items.offsetWidth === carousel_26.items.scrollWidth) {
            return true;
        }
    } else {
        return true;
    }

    return false;
}

function setRightScrollOpacity_26() {
    if (isScrolledAllRight_26()) {
        carousel_26.rightScroll.style.opacity = 0;
    } else {
        carousel_26.rightScroll.style.opacity = 1;
    }
}

