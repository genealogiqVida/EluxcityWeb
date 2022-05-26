function carregaTela(tela) {

    if (tela.indexOf('manual.aspx?') != -1) {
        location.href = tela;
    } else if (tela.indexOf('boletim.aspx?') != -1) {
        location.href = tela;
    } else if (tela.indexOf('videos.aspx?') != -1) {
        location.href = tela;
    } else if (tela.indexOf('index.aspx?') != -1) {
        location.href = tela;

    }else if (tela.indexOf('default.aspx?') != -1) {
        location.href = tela;

        
    }else if (tela.indexOf('minhacoroa.aspx?') != -1) {
        location.href = tela;

    

    } else if (tela.indexOf('contactcenter.aspx?') != -1) {
        location.href = tela;

    }else if(tela.indexOf('/arvoredecisao/') != -1) {
        location.href = tela;
    
    
    } else {
        window.top.location.href = tela;
    }

   
}

function carregaConteudo(idConteudo) {
    if(idConteudo.indexOf('spage') != -1) {
        window.top.location.href = "https://eluxcitysb.sabacloud.com/Saba/Web_spf/NA1TNB0106/app/shared;spf-url=pages%2Fvideodetailview%2F" + idConteudo;

    }else{
        window.top.location.href = "https://eluxcitysb.sabacloud.com/Saba/Web_spf/NA1TNB0106/common/resources/resourcedetail/" + idConteudo;

    }
 

    
    
}


function carregaCurso(idCurso) {
    if (idCurso.indexOf("curra") != -1) {
        window.top.location.href = "https://eluxcitysb.sabacloud.com/Saba/Web_spf/NA1TNB0106/app/shared;spf-url=common%2Flearningeventdetail%2F" + idCurso;
        
    }else{
        window.top.location.href = "https://eluxcitysb.sabacloud.com/Saba/Web_spf/NA1TNB0106/common/ledetail/" + idCurso;
    }

   
}




function MouseWheelHandler_0(e, element) {
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

    $('#carousel_0-items').animate({ scrollLeft: '-=' + (delta) }, 750);

}

function handleMouse_0(e) {
    MouseWheelHandler_0(e, carousel_0.items);
}

function leftScrollClick_0() {
    MouseWheelHandler_0(380, carousel_0.items);
}


function rightScrollClick_0() {
   
        MouseWheelHandler_0(-380, carousel_0.items);
    
}

function scrollEvent_0(e) {
    setLeftScrollOpacity_0();
    setRightScrollOpacity_0();
}

function setLeftScrollOpacity_0() {
    if (isScrolledAllLeft_0()) {
        carousel_0.leftScroll.style.opacity = 0;
    } else {
        carousel_0.leftScroll.style.opacity = 1;
    }
}

function isScrolledAllLeft_0() {
    if (carousel_0.items.scrollLeft === 0) {
        return true;
    } else {
        return false;
    }
}

function isScrolledAllRight_0() {
    if (carousel_0.items.scrollWidth > carousel_0.items.offsetWidth) {
        if (carousel_0.items.scrollLeft + carousel_0.items.offsetWidth === carousel_0.items.scrollWidth) {
            return true;
        }
    } else {
        return true;
    }

    return false;
}

function setRightScrollOpacity_0() {
    if (isScrolledAllRight_0()) {
        carousel_0.rightScroll.style.opacity = 0;
    } else {
        carousel_0.rightScroll.style.opacity = 1;
    }
}

