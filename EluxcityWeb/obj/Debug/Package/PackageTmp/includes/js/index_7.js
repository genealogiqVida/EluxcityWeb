function MouseWheelHandler_7(e, element) {
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

    $('#carousel_7-items').animate({ scrollLeft: '-=' + (delta) }, 800);

}

function handleMouse_7(e) {
    MouseWheelHandler_7(e, carousel_7.items);
}

function leftScrollClick_7() {
    MouseWheelHandler_7(380, carousel_7.items);
}

function rightScrollClick_7() {

   
        MouseWheelHandler_7(-380, carousel_7.items);
    

   
}

function scrollEvent_7(e) {
    setLeftScrollOpacity_7();
    setRightScrollOpacity_7();
}

function setLeftScrollOpacity_7() {
    if (isScrolledAllLeft_7()) {
        carousel_7.leftScroll.style.opacity = 0;
    } else {
        carousel_7.leftScroll.style.opacity = 1;
    }
}

function isScrolledAllLeft_7() {
    if (carousel_7.items.scrollLeft === 0) {
        return true;
    } else {
        return false;
    }
}

function isScrolledAllRight_7() {
    if (carousel_7.items.scrollWidth > carousel_7.items.offsetWidth) {
        if (carousel_7.items.scrollLeft + carousel_7.items.offsetWidth === carousel_7.items.scrollWidth) {
            return true;
        }
    } else {
        return true;
    }

    return false;
}

function setRightScrollOpacity_7() {
    if (isScrolledAllRight_7()) {
        carousel_7.rightScroll.style.opacity = 0;
    } else {
        carousel_7.rightScroll.style.opacity = 1;
    }
}
