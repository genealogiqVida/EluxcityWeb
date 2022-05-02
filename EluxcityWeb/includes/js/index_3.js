function MouseWheelHandler_3(e, element) {
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

    $('#carousel_3-items').animate({ scrollLeft: '-=' + (delta) }, 800);

}

function handleMouse_3(e) {
    MouseWheelHandler_3(e, carousel_3.items);
}

function leftScrollClick_3() {
    MouseWheelHandler_3(380, carousel_3.items);
}

function rightScrollClick_3() {

        MouseWheelHandler_3(-380, carousel_3.items);
    


   
}

function scrollEvent_3(e) {
    setLeftScrollOpacity_3();
    setRightScrollOpacity_3();
}

function setLeftScrollOpacity_3() {
    if (isScrolledAllLeft_3()) {
        carousel_3.leftScroll.style.opacity = 0;
    } else {
        carousel_3.leftScroll.style.opacity = 1;
    }
}

function isScrolledAllLeft_3() {
    if (carousel_3.items.scrollLeft === 0) {
        return true;
    } else {
        return false;
    }
}

function isScrolledAllRight_3() {
    if (carousel_3.items.scrollWidth > carousel_3.items.offsetWidth) {
        if (carousel_3.items.scrollLeft + carousel_3.items.offsetWidth === carousel_3.items.scrollWidth) {
            return true;
        }
    } else {
        return true;
    }

    return false;
}

function setRightScrollOpacity_3() {
    if (isScrolledAllRight_3()) {
        carousel_3.rightScroll.style.opacity = 0;
    } else {
        carousel_3.rightScroll.style.opacity = 1;
    }
}

