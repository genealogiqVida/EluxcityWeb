function MouseWheelHandler(e, element) {
    var delta = 0;
    if (typeof e === 'number') {
        delta = e;
    } else {
        if (e.deltaX !== 0) {
            delta = e.deltaX;
        } else {
            delta = e.deltaY;
        }
        e.preventDefault();
    }
   // element.scrollLeft -= (delta);

    $('#carousel_1-items').animate({ scrollLeft: '-=' + (delta) }, 800);
}

function handleMouse(e) {
    MouseWheelHandler(e, carousel_1.items);
}
function leftScrollClick() {
    MouseWheelHandler(380, carousel_1.items);
}
function rightScrollClick() {
    MouseWheelHandler(-380, carousel_1.items);
}

function scrollEvent(e) {
    setLeftScrollOpacity();
    setRightScrollOpacity();
}

function setLeftScrollOpacity() {
    if (isScrolledAllLeft()) {
        carousel_1.leftScroll.style.opacity = 0;
    } else {
        carousel_1.leftScroll.style.opacity = 1;
    }
}

function isScrolledAllLeft() {
    if (carousel_1.items.scrollLeft === 0) {
        return true;
    } else {
        return false;
    }
}

function isScrolledAllRight() {
    if (carousel_1.items.scrollWidth > carousel_1.items.offsetWidth) {
        if (carousel_1.items.scrollLeft + carousel_1.items.offsetWidth === carousel_1.items.scrollWidth) {
            return true;
        }
    } else {
        return true;
    }

    return false;
}

function setRightScrollOpacity() {
    if (isScrolledAllRight()) {
        carousel_1.rightScroll.style.opacity = 0;
    } else {
        carousel_1.rightScroll.style.opacity = 1;
    }
}



