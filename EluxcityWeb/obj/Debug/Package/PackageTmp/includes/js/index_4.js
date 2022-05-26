function MouseWheelHandler_4(e, element) {
    var delta = 0;
    if (typeof e === 'number') {
        delta = e;
    } else {
        if (e.deltaX !== 0) {
            delta = e.deltaX;
        } else {
            delta = e.deltaY;
        }
     //   e.preventDefault();
    }

    $('#carousel_4-items').animate({ scrollLeft: '-=' + (delta) }, 800);

}

function handleMouse_4(e) {
    MouseWheelHandler_4(e, carousel_4.items);
}

function leftScrollClick_4() {
    MouseWheelHandler_4(380, carousel_4.items);
}

function rightScrollClick_4() {

   
        MouseWheelHandler_4(-380, carousel_4.items);
    

    
}

function scrollEvent_4(e) {
    setLeftScrollOpacity_4();
    setRightScrollOpacity_4();
}

function setLeftScrollOpacity_4() {
    if (isScrolledAllLeft_4()) {
        carousel_4.leftScroll.style.opacity = 0;
    } else {
        carousel_4.leftScroll.style.opacity = 1;
    }
}

function isScrolledAllLeft_4() {
    if (carousel_4.items.scrollLeft === 0) {
        return true;
    } else {
        return false;
    }
}

function isScrolledAllRight_4() {
    if (carousel_4.items.scrollWidth > carousel_4.items.offsetWidth) {
        if (carousel_4.items.scrollLeft + carousel_4.items.offsetWidth === carousel_4.items.scrollWidth) {
            return true;
        }
    } else {
        return true;
    }

    return false;
}

function setRightScrollOpacity_4() {
    if (isScrolledAllRight_4()) {
        carousel_4.rightScroll.style.opacity = 0;
    } else {
        carousel_4.rightScroll.style.opacity = 1;
    }
}
