function MouseWheelHandler_22(e, element) {
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

    $('#carousel_22-items').animate({ scrollLeft: '-=' + (delta) }, 800);

}

function handleMouse_22(e) {
    MouseWheelHandler_22(e, carousel_22.items);
}

function leftScrollClick_22() {
    MouseWheelHandler_22(380, carousel_22.items);
}

function rightScrollClick_22() {

   
        MouseWheelHandler_22(-380, carousel_22.items);
   

   
}

function scrollEvent_22(e) {
    setLeftScrollOpacity_22();
    setRightScrollOpacity_22();
}

function setLeftScrollOpacity_22() {
    if (isScrolledAllLeft_22()) {
        carousel_22.leftScroll.style.opacity = 0;
    } else {
        carousel_22.leftScroll.style.opacity = 1;
    }
}

function isScrolledAllLeft_22() {
    if (carousel_22.items.scrollLeft === 0) {
        return true;
    } else {
        return false;
    }
}

function isScrolledAllRight_22() {
    if (carousel_22.items.scrollWidth > carousel_22.items.offsetWidth) {
        if (carousel_22.items.scrollLeft + carousel_22.items.offsetWidth === carousel_22.items.scrollWidth) {
            return true;
        }
    } else {
        return true;
    }

    return false;
}

function setRightScrollOpacity_22() {
    if (isScrolledAllRight_22()) {
        carousel_22.rightScroll.style.opacity = 0;
    } else {
        carousel_22.rightScroll.style.opacity = 1;
    }
}

