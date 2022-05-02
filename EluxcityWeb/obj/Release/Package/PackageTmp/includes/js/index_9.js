function MouseWheelHandler_9(e, element) {
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

    $('#carousel_9-items').animate({ scrollLeft: '-=' + (delta) }, 800);

}

function handleMouse_9(e) {
    MouseWheelHandler_9(e, carousel_9.items);
}

function leftScrollClick_9() {
    MouseWheelHandler_9(380, carousel_9.items);
}

function rightScrollClick_9() {

   
        MouseWheelHandler_9(-380, carousel_9.items);
   

   
}

function scrollEvent_9(e) {
    setLeftScrollOpacity_9();
    setRightScrollOpacity_9();
}

function setLeftScrollOpacity_9() {
    if (isScrolledAllLeft_9()) {
        carousel_9.leftScroll.style.opacity = 0;
    } else {
        carousel_9.leftScroll.style.opacity = 1;
    }
}

function isScrolledAllLeft_9() {
    if (carousel_9.items.scrollLeft === 0) {
        return true;
    } else {
        return false;
    }
}

function isScrolledAllRight_9() {
    if (carousel_9.items.scrollWidth > carousel_9.items.offsetWidth) {
        if (carousel_9.items.scrollLeft + carousel_9.items.offsetWidth === carousel_9.items.scrollWidth) {
            return true;
        }
    } else {
        return true;
    }

    return false;
}

function setRightScrollOpacity_9() {
    if (isScrolledAllRight_9()) {
        carousel_9.rightScroll.style.opacity = 0;
    } else {
        carousel_9.rightScroll.style.opacity = 1;
    }
}

