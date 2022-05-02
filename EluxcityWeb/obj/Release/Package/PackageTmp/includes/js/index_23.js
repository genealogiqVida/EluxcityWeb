function MouseWheelHandler_23(e, element) {
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

    $('#carousel_23-items').animate({ scrollLeft: '-=' + (delta) }, 800);

}

function handleMouse_23(e) {
    MouseWheelHandler_23(e, carousel_23.items);
}

function leftScrollClick_23() {
    MouseWheelHandler_23(380, carousel_23.items);
}

function rightScrollClick_23() {

   
        MouseWheelHandler_23(-380, carousel_23.items);
   

   
}

function scrollEvent_23(e) {
    setLeftScrollOpacity_23();
    setRightScrollOpacity_23();
}

function setLeftScrollOpacity_23() {
    if (isScrolledAllLeft_23()) {
        carousel_23.leftScroll.style.opacity = 0;
    } else {
        carousel_23.leftScroll.style.opacity = 1;
    }
}

function isScrolledAllLeft_23() {
    if (carousel_23.items.scrollLeft === 0) {
        return true;
    } else {
        return false;
    }
}

function isScrolledAllRight_23() {
    if (carousel_23.items.scrollWidth > carousel_23.items.offsetWidth) {
        if (carousel_23.items.scrollLeft + carousel_23.items.offsetWidth === carousel_23.items.scrollWidth) {
            return true;
        }
    } else {
        return true;
    }

    return false;
}

function setRightScrollOpacity_23() {
    if (isScrolledAllRight_23()) {
        carousel_23.rightScroll.style.opacity = 0;
    } else {
        carousel_23.rightScroll.style.opacity = 1;
    }
}

