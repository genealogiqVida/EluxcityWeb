function MouseWheelHandler_27(e, element) {
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

    $('#carousel_27-items').animate({ scrollLeft: '-=' + (delta) }, 800);

}

function handleMouse_27(e) {
    MouseWheelHandler_27(e, carousel_27.items);
}

function leftScrollClick_27() {
    MouseWheelHandler_27(380, carousel_27.items);
}

function rightScrollClick_27() {

   
        MouseWheelHandler_27(-380, carousel_27.items);
   

   
}

function scrollEvent_27(e) {
    setLeftScrollOpacity_27();
    setRightScrollOpacity_27();
}

function setLeftScrollOpacity_27() {
    if (isScrolledAllLeft_27()) {
        carousel_27.leftScroll.style.opacity = 0;
    } else {
        carousel_27.leftScroll.style.opacity = 1;
    }
}

function isScrolledAllLeft_27() {
    if (carousel_27.items.scrollLeft === 0) {
        return true;
    } else {
        return false;
    }
}

function isScrolledAllRight_27() {
    if (carousel_27.items.scrollWidth > carousel_27.items.offsetWidth) {
        if (carousel_27.items.scrollLeft + carousel_27.items.offsetWidth === carousel_27.items.scrollWidth) {
            return true;
        }
    } else {
        return true;
    }

    return false;
}

function setRightScrollOpacity_27() {
    if (isScrolledAllRight_27()) {
        carousel_27.rightScroll.style.opacity = 0;
    } else {
        carousel_27.rightScroll.style.opacity = 1;
    }
}

