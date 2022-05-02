function MouseWheelHandler_21(e, element) {
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

    $('#carousel_21-items').animate({ scrollLeft: '-=' + (delta) }, 800);

}

function handleMouse_21(e) {
    MouseWheelHandler_21(e, carousel_21.items);
}

function leftScrollClick_21() {
    MouseWheelHandler_21(380, carousel_21.items);
}

function rightScrollClick_21() {

   
        MouseWheelHandler_21(-380, carousel_21.items);
   

   
}

function scrollEvent_21(e) {
    setLeftScrollOpacity_21();
    setRightScrollOpacity_21();
}

function setLeftScrollOpacity_21() {
    if (isScrolledAllLeft_21()) {
        carousel_21.leftScroll.style.opacity = 0;
    } else {
        carousel_21.leftScroll.style.opacity = 1;
    }
}

function isScrolledAllLeft_21() {
    if (carousel_21.items.scrollLeft === 0) {
        return true;
    } else {
        return false;
    }
}

function isScrolledAllRight_21() {
    if (carousel_21.items.scrollWidth > carousel_21.items.offsetWidth) {
        if (carousel_21.items.scrollLeft + carousel_21.items.offsetWidth === carousel_21.items.scrollWidth) {
            return true;
        }
    } else {
        return true;
    }

    return false;
}

function setRightScrollOpacity_21() {
    if (isScrolledAllRight_21()) {
        carousel_21.rightScroll.style.opacity = 0;
    } else {
        carousel_21.rightScroll.style.opacity = 1;
    }
}

