function MouseWheelHandler_5(e, element) {
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

    $('#carousel_5-items').animate({ scrollLeft: '-=' + (delta) }, 800);

}

function handleMouse_5(e) {
    MouseWheelHandler_5(e, carousel_5.items);
}

function leftScrollClick_5() {
    MouseWheelHandler_5(380, carousel_5.items);
}

function rightScrollClick_5() {

   
        MouseWheelHandler_5(-380, carousel_5.items);
    

   
}

function scrollEvent_5(e) {
    setLeftScrollOpacity_5();
    setRightScrollOpacity_5();
}

function setLeftScrollOpacity_5() {
    if (isScrolledAllLeft_5()) {
        carousel_5.leftScroll.style.opacity = 0;
    } else {
        carousel_5.leftScroll.style.opacity = 1;
    }
}

function isScrolledAllLeft_5() {
    if (carousel_5.items.scrollLeft === 0) {
        return true;
    } else {
        return false;
    }
}

function isScrolledAllRight_5() {
    if (carousel_5.items.scrollWidth > carousel_5.items.offsetWidth) {
        if (carousel_5.items.scrollLeft + carousel_5.items.offsetWidth === carousel_5.items.scrollWidth) {
            return true;
        }
    } else {
        return true;
    }

    return false;
}

function setRightScrollOpacity_5() {
    if (isScrolledAllRight_5()) {
        carousel_5.rightScroll.style.opacity = 0;
    } else {
        carousel_5.rightScroll.style.opacity = 1;
    }
}

