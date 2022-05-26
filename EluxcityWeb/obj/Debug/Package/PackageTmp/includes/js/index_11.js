function MouseWheelHandler_11(e, element) {
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

    $('#carousel_11-items').animate({ scrollLeft: '-=' + (delta) }, 800);

}

function handleMouse_11(e) {
    MouseWheelHandler_11(e, carousel_11.items);
}

function leftScrollClick_11() {
    MouseWheelHandler_11(380, carousel_11.items);
}

function rightScrollClick_11() {

  
        MouseWheelHandler_11(-380, carousel_11.items);
    


   
}

function scrollEvent_11(e) {
    setLeftScrollOpacity_11();
    setRightScrollOpacity_11();
}

function setLeftScrollOpacity_11() {
    if (isScrolledAllLeft_11()) {
        carousel_11.leftScroll.style.opacity = 0;
    } else {
        carousel_11.leftScroll.style.opacity = 1;
    }
}

function isScrolledAllLeft_11() {
    if (carousel_11.items.scrollLeft === 0) {
        return true;
    } else {
        return false;
    }
}

function isScrolledAllRight_11() {
    if (carousel_11.items.scrollWidth > carousel_11.items.offsetWidth) {
        if (carousel_11.items.scrollLeft + carousel_11.items.offsetWidth === carousel_11.items.scrollWidth) {
            return true;
        }
    } else {
        return true;
    }

    return false;
}

function setRightScrollOpacity_11() {
    if (isScrolledAllRight_11()) {
        carousel_11.rightScroll.style.opacity = 0;
    } else {
        carousel_11.rightScroll.style.opacity = 1;
    }
}
