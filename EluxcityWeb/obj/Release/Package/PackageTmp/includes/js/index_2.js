function MouseWheelHandler_2(e, element) {
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

    $('#carousel_2-items').animate({ scrollLeft: '-=' + (delta) }, 800);

}


function handleMouse_2(e) {
    
    MouseWheelHandler_2(e, carousel_2.items);
}

function leftScrollClick_2() {
    MouseWheelHandler_2(380, carousel_2.items);
   
}

function rightScrollClick_2() {
   

        MouseWheelHandler_2(-380, carousel_2.items);
    

   

   
  
}

function scrollEvent_2(e) {
    setLeftScrollOpacity_2();
    setRightScrollOpacity_2();
}

function setLeftScrollOpacity_2() {
    if (isScrolledAllLeft_2()) {
        carousel_2.leftScroll.style.opacity = 0;
    } else {
        carousel_2.leftScroll.style.opacity = 1;
    }
}

function isScrolledAllLeft_2() {
    if (carousel_2.items.scrollLeft === 0) {
        return true;
    } else {
        return false;
    }
}

function isScrolledAllRight_2() {
    if (carousel_2.items.scrollWidth > carousel_2.items.offsetWidth) {
        if (carousel_2.items.scrollLeft + carousel_2.items.offsetWidth === carousel_2.items.scrollWidth) {
            return true;
        }
    } else {
        return true;
    }

    return false;
}

function setRightScrollOpacity_2() {
    if (isScrolledAllRight_2()) {
        carousel_2.rightScroll.style.opacity = 0;
    } else {
        carousel_2.rightScroll.style.opacity = 1;
    }
}