function MouseWheelHandler_18(e, element) {
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

    $('#carousel_18-items').animate({ scrollLeft: '-=' + (delta) }, 800);

}

function handleMouse_18(e) {
    MouseWheelHandler_18(e, carousel_18.items);
}

function leftScrollClick_18() {
    MouseWheelHandler_18(380, carousel_18.items);
}

function rightScrollClick_18() {

        MouseWheelHandler_18(-380, carousel_18.items);
    


   
}

function scrollEvent_18(e) {
    setLeftScrollOpacity_18();
    setRightScrollOpacity_18();
}

function setLeftScrollOpacity_18() {
    if (isScrolledAllLeft_18()) {
        carousel_18.leftScroll.style.opacity = 0;
    } else {
        carousel_18.leftScroll.style.opacity = 1;
    }
}

function isScrolledAllLeft_18() {
    if (carousel_18.items.scrollLeft === 0) {
        return true;
    } else {
        return false;
    }
}

function isScrolledAllRight_18() {
    if (carousel_18.items.scrollWidth > carousel_18.items.offsetWidth) {
        if (carousel_18.items.scrollLeft + carousel_18.items.offsetWidth === carousel_18.items.scrollWidth) {
            return true;
        }
    } else {
        return true;
    }

    return false;
}

function setRightScrollOpacity_18() {
    if (isScrolledAllRight_18()) {
        carousel_18.rightScroll.style.opacity = 0;
    } else {
        carousel_18.rightScroll.style.opacity = 1;
    }
}
