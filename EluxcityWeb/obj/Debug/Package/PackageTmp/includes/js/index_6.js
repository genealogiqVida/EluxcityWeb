function MouseWheelHandler_6(e, element) {
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

    $('#carousel_6-items').animate({ scrollLeft: '-=' + (delta) }, 800);

}

function handleMouse_6(e) {
    MouseWheelHandler_6(e, carousel_6.items);
}

function leftScrollClick_6() {
    MouseWheelHandler_6(380, carousel_6.items);
}

function rightScrollClick_6() {

    
        MouseWheelHandler_6(-380, carousel_6.items);
    

    
}

function scrollEvent_6(e) {
    setLeftScrollOpacity_6();
    setRightScrollOpacity_6();
}

function setLeftScrollOpacity_6() {
    if (isScrolledAllLeft_6()) {
        carousel_6.leftScroll.style.opacity = 0;
    } else {
        carousel_6.leftScroll.style.opacity = 1;
    }
}

function isScrolledAllLeft_6() {
    if (carousel_6.items.scrollLeft === 0) {
        return true;
    } else {
        return false;
    }
}

function isScrolledAllRight_6() {
    if (carousel_6.items.scrollWidth > carousel_6.items.offsetWidth) {
        if (carousel_6.items.scrollLeft + carousel_6.items.offsetWidth === carousel_6.items.scrollWidth) {
            return true;
        }
    } else {
        return true;
    }

    return false;
}

function setRightScrollOpacity_6() {
    if (isScrolledAllRight_6()) {
        carousel_6.rightScroll.style.opacity = 0;
    } else {
        carousel_6.rightScroll.style.opacity = 1;
    }
}
