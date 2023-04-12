<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="boletim.aspx.cs" Inherits="EluxcityWeb.pages.boletim" %>


<html style="background-color:#e6e6e6">
	<head>	
       
       <meta name="viewport" content="width=device-width, height=device-height, initial-scale=1" />
       <link rel="stylesheet" type="text/css" href="engine1/style.css" />
	   <script type="text/javascript" src="engine1/jquery.js"></script>
	   <link rel="stylesheet" type="text/css" href="../includes/css/estilo.css"/>	
       <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>		
       <link rel="stylesheet" href="../includes/css/tooltipster.bundle.min.css" type="text/css" />
       <link rel="stylesheet" href="../includes/css/tooltipster-sideTip-punk.min.css" type="text/css" />
       <link rel="stylesheet" href="https://unpkg.com/swiper@8/swiper-bundle.min.css" />
       <script src="https://unpkg.com/swiper@8/swiper-bundle.min.js"></script>
       <script src="../includes/js/tooltipster.bundle.min.js"></script>
       <script src="../includes/js/loading.js"></script>
       <link href="../includes/css/loading.css" type="text/css" rel="stylesheet">

       <script src="../includes/js/popper.min.js"></script>
       <script src="../includes/js/bootstrap5.min.js"></script>
        <script src="../includes/js/bootstrap.bundle.min.js"></script>
         <link href="../includes/css/bootstrap5.min.css" type="text/css" rel="stylesheet">


         <script src="../includes/js/index_0.js"></script>
         <script src="../includes/js/index_1.js"></script>
          <script src="../includes/js/index_2.js"></script>
        <script src="../includes/js/index_3.js"></script>
        <script src="../includes/js/index_4.js"></script>
        <script src="../includes/js/index_5.js"></script>
        <script src="../includes/js/index_6.js"></script>
        <script src="../includes/js/index_7.js"></script>
        <script src="../includes/js/index_8.js"></script>
        <script src="../includes/js/index_9.js"></script>
        <script src="../includes/js/index_10.js"></script>
        <script src="../includes/js/index_11.js"></script>
          <script src="../includes/js/index_18.js"></script>
        <script src="../includes/js/index_20.js"></script>
        <script src="../includes/js/index_21.js"></script>
        <script src="../includes/js/index_22.js"></script>
        <script src="../includes/js/index_23.js"></script>
        <script src="../includes/js/index_24.js"></script>
        <script src="../includes/js/index_25.js"></script>
        <script src="../includes/js/index_26.js"></script>
        <script src="../includes/js/index_27.js"></script>

     <script>
         var pagina0 = 1;
         var pagina1 = 1;
         var pagina2 = 1;
         var pagina3 = 1;
         var pagina4 = 1;
         var pagina5 = 1;
         var pagina6 = 1;
         var pagina7 = 1;
         var pagina8 = 1;
         var pagina9 = 1;
         var pagina10 = 1;
         var pagina11 = 1;
         var pagina18 = 1;
         var carousel_18 = {};
         var carousel_2 = {}; var carousel_0 = {};
         var carousel_11 = {};
         var carousel_4 = {}; var carousel_3 = {};
         var carousel_1 = {}; var carousel_10 = {}; var carousel_9 = {}; var carousel_8 = {}; var carousel_7 = {}; var carousel_6 = {}; var carousel_5 = {};
         var carousel_20 = {}; var carousel_21 = {}; var carousel_22 = {}; var carousel_23 = {}; var carousel_24 = {}; var carousel_25 = {}; var carousel_26 = {}; var carousel_27 = {};
         $(document).ready(function () {

             try {

                 carousel_1.e = document.getElementById('carousel_1');
                 carousel_1.items = document.getElementById('carousel_1-items');
                 carousel_1.leftScroll = document.getElementById('left-scroll-button_1');
                 carousel_1.rightScroll = document.getElementById('right-scroll-button_1');
                 carousel_1.items.addEventListener("mousewheel", handleMouse, false);
                 carousel_1.items.addEventListener("scroll", scrollEvent);
                 carousel_1.leftScroll.addEventListener("click", leftScrollClick);
                 carousel_1.rightScroll.addEventListener("click", rightScrollClick);
                  setLeftScrollOpacity();
                 setRightScrollOpacity();



             } catch (e) { }



             try {

                 carousel_2.e = document.getElementById('carousel_2');
                 carousel_2.items = document.getElementById('carousel_2-items');
                 carousel_2.leftScroll = document.getElementById('left-scroll-button_2');
                 carousel_2.rightScroll = document.getElementById('right-scroll-button_2');

                 carousel_2.items.addEventListener("mousewheel", handleMouse_2, false);
                 carousel_2.items.addEventListener("scroll", scrollEvent_2);
                 carousel_2.leftScroll.addEventListener("click", leftScrollClick_2);
                 carousel_2.rightScroll.addEventListener("click", rightScrollClick_2);

                 setLeftScrollOpacity_2();
                 setRightScrollOpacity_2();



             } catch (e) { }


             try {

                 carousel_3.e = document.getElementById('carousel_3');
                 carousel_3.items = document.getElementById('carousel_3-items');
                 carousel_3.leftScroll = document.getElementById('left-scroll-button_3');
                 carousel_3.rightScroll = document.getElementById('right-scroll-button_3');

                 carousel_3.items.addEventListener("mousewheel", handleMouse_3, false);
                 carousel_3.items.addEventListener("scroll", scrollEvent_3);
                 carousel_3.leftScroll.addEventListener("click", leftScrollClick_3);
                 carousel_3.rightScroll.addEventListener("click", rightScrollClick_3);

                 setLeftScrollOpacity_3();
                 setRightScrollOpacity_3();



             } catch (e) { }



             try {

                 carousel_4.e = document.getElementById('carousel_4');
                 carousel_4.items = document.getElementById('carousel_4-items');
                 carousel_4.leftScroll = document.getElementById('left-scroll-button_4');
                 carousel_4.rightScroll = document.getElementById('right-scroll-button_4');

                 carousel_4.items.addEventListener("mousewheel", handleMouse_4, false);
                 carousel_4.items.addEventListener("scroll", scrollEvent_4);
                 carousel_4.leftScroll.addEventListener("click", leftScrollClick_4);
                 carousel_4.rightScroll.addEventListener("click", rightScrollClick_4);

                 setLeftScrollOpacity_4();
                 setRightScrollOpacity_4();



             } catch (e) { }

             try {

                 carousel_5.e = document.getElementById('carousel_5');
                 carousel_5.items = document.getElementById('carousel_5-items');
                 carousel_5.leftScroll = document.getElementById('left-scroll-button_5');
                 carousel_5.rightScroll = document.getElementById('right-scroll-button_5');

                 carousel_5.items.addEventListener("mousewheel", handleMouse_5, false);
                 carousel_5.items.addEventListener("scroll", scrollEvent_5);
                 carousel_5.leftScroll.addEventListener("click", leftScrollClick_5);
                 carousel_5.rightScroll.addEventListener("click", rightScrollClick_5);

                 setLeftScrollOpacity_5();
                 setRightScrollOpacity_5();



             } catch (e) { }

             try {

                 carousel_6.e = document.getElementById('carousel_6');
                 carousel_6.items = document.getElementById('carousel_6-items');
                 carousel_6.leftScroll = document.getElementById('left-scroll-button_6');
                 carousel_6.rightScroll = document.getElementById('right-scroll-button_6');

                 carousel_6.items.addEventListener("mousewheel", handleMouse_6, false);
                 carousel_6.items.addEventListener("scroll", scrollEvent_6);
                 carousel_6.leftScroll.addEventListener("click", leftScrollClick_6);
                 carousel_6.rightScroll.addEventListener("click", rightScrollClick_6);

                 setLeftScrollOpacity_6();
                 setRightScrollOpacity_6();



             } catch (e) { }

             try {

                 carousel_7.e = document.getElementById('carousel_7');
                 carousel_7.items = document.getElementById('carousel_7-items');
                 carousel_7.leftScroll = document.getElementById('left-scroll-button_7');
                 carousel_7.rightScroll = document.getElementById('right-scroll-button_7');

                 carousel_7.items.addEventListener("mousewheel", handleMouse_7, false);
                 carousel_7.items.addEventListener("scroll", scrollEvent_7);
                 carousel_7.leftScroll.addEventListener("click", leftScrollClick_7);
                 carousel_7.rightScroll.addEventListener("click", rightScrollClick_7);

                 setLeftScrollOpacity_7();
                 setRightScrollOpacity_7();



             } catch (e) { }

             try {

                 carousel_9.e = document.getElementById('carousel_9');
                 carousel_9.items = document.getElementById('carousel_9-items');
                 carousel_9.leftScroll = document.getElementById('left-scroll-button_9');
                 carousel_9.rightScroll = document.getElementById('right-scroll-button_9');

                 carousel_9.items.addEventListener("mousewheel", handleMouse_9, false);
                 carousel_9.items.addEventListener("scroll", scrollEvent_9);
                 carousel_9.leftScroll.addEventListener("click", leftScrollClick_9);
                 carousel_9.rightScroll.addEventListener("click", rightScrollClick_9);

                 setLeftScrollOpacity_9();
                 setRightScrollOpacity_9();



             } catch (e) { }

             try {

                 carousel_8.e = document.getElementById('carousel_8');
                 carousel_8.items = document.getElementById('carousel_8-items');
                 carousel_8.leftScroll = document.getElementById('left-scroll-button_8');
                 carousel_8.rightScroll = document.getElementById('right-scroll-button_8');

                 carousel_8.items.addEventListener("mousewheel", handleMouse_8, false);
                 carousel_8.items.addEventListener("scroll", scrollEvent_8);
                 carousel_8.leftScroll.addEventListener("click", leftScrollClick_8);
                 carousel_8.rightScroll.addEventListener("click", rightScrollClick_8);

                 setLeftScrollOpacity_8();
                 setRightScrollOpacity_8();



             } catch (e) { }

             try {

                 carousel_10.e = document.getElementById('carousel_10');
                 carousel_10.items = document.getElementById('carousel_10-items');
                 carousel_10.leftScroll = document.getElementById('left-scroll-button_10');
                 carousel_10.rightScroll = document.getElementById('right-scroll-button_10');

                 carousel_10.items.addEventListener("mousewheel", handleMouse_10, false);
                 carousel_10.items.addEventListener("scroll", scrollEvent_10);
                 carousel_10.leftScroll.addEventListener("click", leftScrollClick_10);
                 carousel_10.rightScroll.addEventListener("click", rightScrollClick_10);

                 setLeftScrollOpacity_10();
                 setRightScrollOpacity_10();



             } catch (e) { }

             try {

                 carousel_11.e = document.getElementById('carousel_11');
                 carousel_11.items = document.getElementById('carousel_11-items');
                 carousel_11.leftScroll = document.getElementById('left-scroll-button_11');
                 carousel_11.rightScroll = document.getElementById('right-scroll-button_11');

                 carousel_11.items.addEventListener("mousewheel", handleMouse_11, false);
                 carousel_11.items.addEventListener("scroll", scrollEvent_11);
                 carousel_11.leftScroll.addEventListener("click", leftScrollClick_11);
                 carousel_11.rightScroll.addEventListener("click", rightScrollClick_11);

                 setLeftScrollOpacity_11();
                 setRightScrollOpacity_11();



             } catch (e) { }

             try {

                 carousel_18.e = document.getElementById('carousel_18');
                 carousel_18.items = document.getElementById('carousel_18-items');
                 carousel_18.leftScroll = document.getElementById('left-scroll-button_18');
                 carousel_18.rightScroll = document.getElementById('right-scroll-button_18');

                 carousel_18.items.addEventListener("mousewheel", handleMouse_18, false);
                 carousel_18.items.addEventListener("scroll", scrollEvent_18);
                 carousel_18.leftScroll.addEventListener("click", leftScrollClick_18);
                 carousel_18.rightScroll.addEventListener("click", rightScrollClick_18);

                 setLeftScrollOpacity_18();
                 setRightScrollOpacity_18();



             } catch (e) { }

             try {

                 carousel_20.e = document.getElementById('carousel_20');
                 carousel_20.items = document.getElementById('carousel_20-items');
                 carousel_20.leftScroll = document.getElementById('left-scroll-button_20');
                 carousel_20.rightScroll = document.getElementById('right-scroll-button_20');

                 carousel_20.items.addEventListener("mousewheel", handleMouse_20, false);
                 carousel_20.items.addEventListener("scroll", scrollEvent_20);
                 carousel_20.leftScroll.addEventListener("click", leftScrollClick_20);
                 carousel_20.rightScroll.addEventListener("click", rightScrollClick_20);

                 setLeftScrollOpacity_20();
                 setRightScrollOpacity_20();



             } catch (e) { }

             try {

                 carousel_21.e = document.getElementById('carousel_21');
                 carousel_21.items = document.getElementById('carousel_21-items');
                 carousel_21.leftScroll = document.getElementById('left-scroll-button_21');
                 carousel_21.rightScroll = document.getElementById('right-scroll-button_21');

                 carousel_21.items.addEventListener("mousewheel", handleMouse_21, false);
                 carousel_21.items.addEventListener("scroll", scrollEvent_21);
                 carousel_21.leftScroll.addEventListener("click", leftScrollClick_21);
                 carousel_21.rightScroll.addEventListener("click", rightScrollClick_21);

                 setLeftScrollOpacity_21();
                 setRightScrollOpacity_21();



             } catch (e) { }

             try {

                 carousel_22.e = document.getElementById('carousel_22');
                 carousel_22.items = document.getElementById('carousel_22-items');
                 carousel_22.leftScroll = document.getElementById('left-scroll-button_22');
                 carousel_22.rightScroll = document.getElementById('right-scroll-button_22');

                 carousel_22.items.addEventListener("mousewheel", handleMouse_22, false);
                 carousel_22.items.addEventListener("scroll", scrollEvent_22);
                 carousel_22.leftScroll.addEventListener("click", leftScrollClick_22);
                 carousel_22.rightScroll.addEventListener("click", rightScrollClick_22);

                 setLeftScrollOpacity_22();
                 setRightScrollOpacity_22();



             } catch (e) { }

             try {

                 carousel_23.e = document.getElementById('carousel_23');
                 carousel_23.items = document.getElementById('carousel_23-items');
                 carousel_23.leftScroll = document.getElementById('left-scroll-button_23');
                 carousel_23.rightScroll = document.getElementById('right-scroll-button_23');

                 carousel_23.items.addEventListener("mousewheel", handleMouse_23, false);
                 carousel_23.items.addEventListener("scroll", scrollEvent_23);
                 carousel_23.leftScroll.addEventListener("click", leftScrollClick_23);
                 carousel_23.rightScroll.addEventListener("click", rightScrollClick_23);

                 setLeftScrollOpacity_23();
                 setRightScrollOpacity_23();



             } catch (e) { }

             try {

                 carousel_24.e = document.getElementById('carousel_24');
                 carousel_24.items = document.getElementById('carousel_24-items');
                 carousel_24.leftScroll = document.getElementById('left-scroll-button_24');
                 carousel_24.rightScroll = document.getElementById('right-scroll-button_24');

                 carousel_24.items.addEventListener("mousewheel", handleMouse_24, false);
                 carousel_24.items.addEventListener("scroll", scrollEvent_24);
                 carousel_24.leftScroll.addEventListener("click", leftScrollClick_24);
                 carousel_24.rightScroll.addEventListener("click", rightScrollClick_24);

                 setLeftScrollOpacity_24();
                 setRightScrollOpacity_24();



             } catch (e) { }

             try {

                 carousel_25.e = document.getElementById('carousel_25');
                 carousel_25.items = document.getElementById('carousel_25-items');
                 carousel_25.leftScroll = document.getElementById('left-scroll-button_25');
                 carousel_25.rightScroll = document.getElementById('right-scroll-button_25');

                 carousel_25.items.addEventListener("mousewheel", handleMouse_25, false);
                 carousel_25.items.addEventListener("scroll", scrollEvent_25);
                 carousel_25.leftScroll.addEventListener("click", leftScrollClick_25);
                 carousel_25.rightScroll.addEventListener("click", rightScrollClick_25);

                 setLeftScrollOpacity_25();
                 setRightScrollOpacity_25();



             } catch (e) { }

             try {

                 carousel_26.e = document.getElementById('carousel_26');
                 carousel_26.items = document.getElementById('carousel_26-items');
                 carousel_26.leftScroll = document.getElementById('left-scroll-button_26');
                 carousel_26.rightScroll = document.getElementById('right-scroll-button_26');

                 carousel_26.items.addEventListener("mousewheel", handleMouse_26, false);
                 carousel_26.items.addEventListener("scroll", scrollEvent_26);
                 carousel_26.leftScroll.addEventListener("click", leftScrollClick_26);
                 carousel_26.rightScroll.addEventListener("click", rightScrollClick_26);

                 setLeftScrollOpacity_26();
                 setRightScrollOpacity_26();



             } catch (e) { }

             try {

                 carousel_27.e = document.getElementById('carousel_27');
                 carousel_27.items = document.getElementById('carousel_27-items');
                 carousel_27.leftScroll = document.getElementById('left-scroll-button_27');
                 carousel_27.rightScroll = document.getElementById('right-scroll-button_27');

                 carousel_27.items.addEventListener("mousewheel", handleMouse_27, false);
                 carousel_27.items.addEventListener("scroll", scrollEvent_27);
                 carousel_27.leftScroll.addEventListener("click", leftScrollClick_27);
                 carousel_27.rightScroll.addEventListener("click", rightScrollClick_27);

                 setLeftScrollOpacity_27();
                 setRightScrollOpacity_27();



             } catch (e) { }

             try {

                 carousel_8.e = document.getElementById('carousel_8');
                 carousel_8.items = document.getElementById('carousel_8-items');
                 carousel_8.leftScroll = document.getElementById('left-scroll-button_8');
                 carousel_8.rightScroll = document.getElementById('right-scroll-button_8');

                 carousel_8.items.addEventListener("mousewheel", handleMouse_8, false);
                 carousel_8.items.addEventListener("scroll", scrollEvent_8);
                 carousel_8.leftScroll.addEventListener("click", leftScrollClick_8);
                 carousel_8.rightScroll.addEventListener("click", rightScrollClick_8);

                 setLeftScrollOpacity_8();
                 setRightScrollOpacity_8();



             } catch (e) { }

         });

         function esconde(id) {

             document.getElementById(id).style.display = "none";


             var desc = id.replace('ind_', 'ind_desc');
             if (document.getElementById(desc).style != null)
                 document.getElementById(desc).style.display = "none";
         }

         function habilita(id) {

             document.getElementById(id).style.display = "block";
             // $("#" + id).fadeIn("slow");
             //  $("#" + id).fadeIn(3000);

             var desc = id.replace('ind_', 'ind_desc');

             if (document.getElementById(desc).style != null)
                 document.getElementById(desc).style.display = "block";
         }

     </script>
</head>

	<body style="overflow:auto; background-color:#e6e6e6"  id="tela">
        <%if (dominio.Equals("BRA - Consumer Care"))
            {%>
        <div class="container" style="padding: 0;">
            <div class="swiper">
                <div class="swiper-wrapper">
                    <%--<div class="swiper-slide">
<a target="_top" href="https://use.sabacloud.com/Saba/Web_spf/NA1PRD0102/app/shared;spf-url=pages%2Fblogpostdetailview%2Fspage000000000010500%2Fnews%2Fcampanha-use:-quanto-mais,-melhor-%257C-fevereiro-2023"><img src="../includes/images/banner/banner-pontos-extras-fevereiro.png" /></a></div>--%>                    <div class="swiper-slide">
                        <a target="_top" href="https://use.sabacloud.com/Saba/Web_spf/NA1PRD0102/app/shared;spf-url=pages%2Fblogpostdetailview%2Fspage000000000010480%2Fnews%2Facesse-os-aplicativos-da-use-onde-e-como-quiser!%25C2%25A0"><img src="../includes/images/banner/banner-use-quando-onde-quiser.png" /></a></div>
                    <div class="swiper-slide">
                        <a target="_top" href="https://use.sabacloud.com/Saba/Web_spf/NA1PRD0102/app/shared;spf-url=common%2Fchanneldetail%2Fteams000000000004863"><img src="../includes/images/banner/bra-consumer-care/banner_consumer_care.png" /></a></div>
                </div>
                <div class="swiper-pagination"></div>

                <div class="swiper-button-prev"></div>
                <div class="swiper-button-next"></div>
            </div>
        </div>
        <%} else if (dominiosLatam.Contains(dominio)) {%>
            <div class="container" style="padding: 0;">
                <div class="swiper">
                    <div class="swiper-wrapper">
                        <div class="swiper-slide">
                        <a target="_top" href="https://use.sabacloud.com/Saba/Web_spf/NA1PRD0102/app/shared;spf-url=common%2Fchanneldetail%2Fteams000000000004863"><img src="../includes/images/banner/latam/banner-latam.png" /></a></div>
                    </div>
                    <div class="swiper-pagination"></div>

                    <div class="swiper-button-prev"></div>
                    <div class="swiper-button-next"></div>
                </div>
            </div>
        <%} else if (dominiosUWM.Contains(dominio)) { %>
            <div class="container" style="padding: 0;">
                <div class="swiper">
                    <div class="swiper-wrapper">
                        <div class="swiper-slide">
                        <a target="_top" href="https://use.sabacloud.com/Saba/Web_spf/NA1PRD0102/app/shared;spf-url=common%2Fchanneldetail%2Fteams000000000004863"><img src="../includes/images/banner/latam-uwm/banner.png" /></a></div>
                    </div>
                    <div class="swiper-pagination"></div>

                    <div class="swiper-button-prev"></div>
                    <div class="swiper-button-next"></div>
                </div>
            </div>
        <%} else { %>
        <div class="container" style="padding: 0;">
            <div class="swiper">
                <div class="swiper-wrapper">
                    <div class="swiper-slide">
                        <a target="_top" href="https://use.sabacloud.com/Saba/Web_spf/NA1PRD0102/app/shared;spf-url=pages%2Fblogpostdetailview%2Fspage000000000010520%2Fnews%2Fcampanha-use:-quanto-mais,-melhor-%257C-mar%25C3%25A7o-2023"><img src="../includes/images/banner/banner_pontos_extras_marco.png" /></a></div>                    
                    <div class="swiper-slide">
                        <a target="_top" href="https://use.sabacloud.com/Saba/Web_spf/NA1PRD0102/app/shared;spf-url=pages%2Fblogpostdetailview%2Fspage000000000010480%2Fnews%2Facesse-os-aplicativos-da-use-onde-e-como-quiser!%25C2%25A0"><img src="../includes/images/banner/banner-use-quando-onde-quiser.png" /></a></div>
                    <div class="swiper-slide">
                        <a target="_top" href="https://use.sabacloud.com/Saba/Web_spf/NA1PRD0102/app/me/learningeventdetail/cours000000000009320?returnurl=common%2Fsearchresults%2Ftreinamento%20online%20exclusivo%20para%20mulheres%2FALL%3Freferrer%3Dtrue&embeddedInTorque=true"><img src="../includes/images/banner/banner-treinamento-tecnico.png" /></a></div>
                </div>
                <div class="swiper-pagination"></div>

                <div class="swiper-button-prev"></div>
                <div class="swiper-button-next"></div>
            </div>
        </div>
        <%} %>
      <div class="container" style="overflow-y: scroll; overflow-x: hidden; max-height: 1100px;">
         
          <div class="row">
              <div class="col"> 
               <div class="card" style="min-width: 1202px !important;">
                      <div class="card-body">
          
          
                          <div class="container">
<% if (equipe.ToString().Equals("S"))
    {
        if (dominio.Equals("BRA - Service Center"))
        { %>    
                               
                              <table style="width:95%">
       <tr>
           <td><a target="_top" href="https://use.sabacloud.com/Saba/Web_spf/NA1PRD0102/app/shared;spf-url=common%2Fchanneldetail%2Fteams000000000004863"><button type="button" class="btn btn-warning" style="cursor: pointer"><label style="cursor: pointer"><b>Conheça a USE</b></label></button></a></td>
           <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('index.aspx?idUser=<%=idUser%>&username=<%=username%>&equipe=<%=equipe%>&dominio=<%=dominio%>&nomeCompleto=<%=nomeCompleto%>')"><label style="cursor: pointer"><b>Home</b></label></button></td>
           <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('https://use.sabacloud.com/Saba/Web_spf/NA1PRD0102/app/team/overview')"><label style="cursor: pointer"><b>Gestão da equipe</b></label></button></td>
           <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('minhacoroa.aspx?url=https://use-api.sabacloud.com&certificate=<%=certificate %>&userName=<%=username%>&nomeCompleto=<%=nomeCompleto %>&equipe=<%=equipe %>&idUser=<%=idUser %>&dominio<%=dominio %>')"><label style="cursor: pointer"><b>Extrato de Coroas</b></label></button></td>
           <!--<td><button type="button" class="btn btn-warning" style="cursor: pointer"><label style="cursor: pointer"><b>Service Plus</b></label></button></td>-->
        <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('manual.aspx?idUser=<%=idUser%>&username=<%=username%>&equipe=<%=equipe%>&dominio=<%=dominio%>&nomeCompleto=<%=nomeCompleto%>')"><label style="cursor: pointer"><b>Manual de serviços</b></label></button></td>
               <td><button type="button" class="btn btn-warning" style=" background-color:#f7f0e9" ><label><b>Boletins técnicos</b></label></button></td>
           <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('videos.aspx?idUser=<%=idUser%>&username=<%=username%>&equipe=<%=equipe%>&certificate=<%=certificate%>&dominio=<%=dominio%>&nomeCompleto=<%=nomeCompleto%>')"><label style="cursor: pointer"><b>Vídeos</b></label></button></td>
           <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('circulares.aspx?idUser=<%=idUser%>&username=<%=username%>&equipe=<%=equipe%>&certificate=<%=certificate%>&dominio=<%=dominio%>&nomeCompleto=<%=nomeCompleto%>')"><label style="cursor: pointer"><b>Circulares</b></label></button></td>
       </tr>

   </table>
         <%}
             else
             { %>
    <table style="width:85%">
       <tr>
           <td><a target="_top" href="https://use.sabacloud.com/Saba/Web_spf/NA1PRD0102/app/shared;spf-url=common%2Fchanneldetail%2Fteams000000000004863"><button type="button" class="btn btn-warning" style="cursor: pointer"><label style="cursor: pointer"><b>Conheça a USE</b></label></button></a></td>
           <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('index.aspx?idUser=<%=idUser%>&username=<%=username%>&equipe=<%=equipe%>&dominio=<%=dominio%>&nomeCompleto=<%=nomeCompleto%>')"><label style="cursor: pointer"><b>Home</b></label></button></td>
           <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('https://use.sabacloud.com/Saba/Web_spf/NA1PRD0102/app/team/overview')"><label style="cursor: pointer"><b>Gestão da equipe</b></label></button></td>
           <!--<td><button type="button" class="btn btn-warning" style="cursor: pointer"><label style="cursor: pointer"><b>Service Plus</b></label></button></td>-->
        <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('manual.aspx?idUser=<%=idUser%>&username=<%=username%>&equipe=<%=equipe%>&dominio=<%=dominio%>&nomeCompleto=<%=nomeCompleto%>')"><label style="cursor: pointer"><b>Manual de serviços</b></label></button></td>
               <td><button type="button" class="btn btn-warning" style=" background-color:#f7f0e9" ><label><b>Boletins técnicos</b></label></button></td>
           <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('videos.aspx?idUser=<%=idUser%>&username=<%=username%>&equipe=<%=equipe%>&certificate=<%=certificate%>&dominio=<%=dominio%>&nomeCompleto=<%=nomeCompleto%>')"><label style="cursor: pointer"><b>Vídeos</b></label></button></td>
           <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('circulares.aspx?idUser=<%=idUser%>&username=<%=username%>&equipe=<%=equipe%>&certificate=<%=certificate%>&dominio=<%=dominio%>&nomeCompleto=<%=nomeCompleto%>')"><label style="cursor: pointer"><b>Circulares</b></label></button></td>
       </tr>

   </table>
        <%} %>

<%}
    else if (dominiosLatam.Contains(dominio) || dominiosUWM.Contains(dominio))
    { %>

   <table style="width:70%">
       <tr>
           <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('index.aspx?idUser=<%=idUser%>&username=<%=username%>&equipe=<%=equipe%>&dominio=<%=dominio%>&nomeCompleto=<%=nomeCompleto%>')"><label style="cursor: pointer"><b>Home</b></label></button></td>
           <!--<td><button type="button" class="btn btn-warning" style="cursor: pointer"><label style="cursor: pointer"><b>Service Plus</b></label></button></td>-->
           <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('manual.aspx?idUser=<%=idUser%>&username=<%=username%>&equipe=<%=equipe%>&dominio=<%=dominio%>&nomeCompleto=<%=nomeCompleto%>')"><label style="cursor: pointer"><b><%=btnManualServicos %></b></label></button></td>
            <td><button type="button" class="btn btn-warning"  style=" background-color:#f7f0e9" ><label><b><%=btnBoletinsTecnicos %></b></label></button></td>
           <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('videos.aspx?idUser=<%=idUser%>&username=<%=username%>&equipe=<%=equipe%>&certificate=<%=certificate%>&dominio=<%=dominio%>&nomeCompleto=<%=nomeCompleto%>')"><label style="cursor: pointer"><b><%=btnVideos %></b></label></button></td>
       </tr>

   </table>

  <%}
      else if (dominio.Equals("BRA - Service Center"))
      {%>
    <table style="width:80%">
       <tr>
           <td><a target="_top" href="https://use.sabacloud.com/Saba/Web_spf/NA1PRD0102/app/shared;spf-url=common%2Fchanneldetail%2Fteams000000000004863"><button type="button" class="btn btn-warning" style="cursor: pointer"><label style="cursor: pointer"><b>Conheça a USE</b></label></button></a></td>
           <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('minhacoroa.aspx?url=https://use-api.sabacloud.com&certificate=<%=certificate %>&userName=<%=username%>&nomeCompleto=<%=nomeCompleto %>&equipe=<%=equipe %>&idUser=<%=idUser %>&dominio<%=dominio %>')"><label style="cursor: pointer"><b>Extrato de Coroas</b></label></button></td>
           <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('index.aspx?idUser=<%=idUser%>&username=<%=username%>&equipe=<%=equipe%>&dominio=<%=dominio%>&nomeCompleto=<%=nomeCompleto%>')"><label style="cursor: pointer"><b>Home</b></label></button></td>
           <!--<td><button type="button" class="btn btn-warning" style="cursor: pointer"><label style="cursor: pointer"><b>Service Plus</b></label></button></td>-->
           <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('manual.aspx?idUser=<%=idUser%>&username=<%=username%>&equipe=<%=equipe%>&dominio=<%=dominio%>&nomeCompleto=<%=nomeCompleto%>')"><label style="cursor: pointer"><b>Manual de serviços</b></label></button></td>
            <td><button type="button" class="btn btn-warning"  style=" background-color:#f7f0e9" ><label><b>Boletins técnicos</b></label></button></td>
           <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('videos.aspx?idUser=<%=idUser%>&username=<%=username%>&equipe=<%=equipe%>&certificate=<%=certificate%>&dominio=<%=dominio%>&nomeCompleto=<%=nomeCompleto%>')"><label style="cursor: pointer"><b>Vídeos</b></label></button></td>
           <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('circulares.aspx?idUser=<%=idUser%>&username=<%=username%>&equipe=<%=equipe%>&certificate=<%=certificate%>&dominio=<%=dominio%>&nomeCompleto=<%=nomeCompleto%>')"><label style="cursor: pointer"><b>Circulares</b></label></button></td>
       </tr>

   </table>


    <%}
        else
        {%>
        <table style="width:70%">
       <tr>
           <td><a target="_top" href="https://use.sabacloud.com/Saba/Web_spf/NA1PRD0102/app/shared;spf-url=common%2Fchanneldetail%2Fteams000000000004863"><button type="button" class="btn btn-warning" style="cursor: pointer"><label style="cursor: pointer"><b>Conheça a USE</b></label></button></a></td>
           <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('index.aspx?idUser=<%=idUser%>&username=<%=username%>&equipe=<%=equipe%>&dominio=<%=dominio%>&nomeCompleto=<%=nomeCompleto%>')"><label style="cursor: pointer"><b>Home</b></label></button></td>
           <!--<td><button type="button" class="btn btn-warning" style="cursor: pointer"><label style="cursor: pointer"><b>Service Plus</b></label></button></td>-->
           <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('manual.aspx?idUser=<%=idUser%>&username=<%=username%>&equipe=<%=equipe%>&dominio=<%=dominio%>&nomeCompleto=<%=nomeCompleto%>')"><label style="cursor: pointer"><b>Manual de serviços</b></label></button></td>
            <td><button type="button" class="btn btn-warning"  style=" background-color:#f7f0e9" ><label><b>Boletins técnicos</b></label></button></td>
           <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('videos.aspx?idUser=<%=idUser%>&username=<%=username%>&equipe=<%=equipe%>&certificate=<%=certificate%>&dominio=<%=dominio%>&nomeCompleto=<%=nomeCompleto%>')"><label style="cursor: pointer"><b>Vídeos</b></label></button></td>
           <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('circulares.aspx?idUser=<%=idUser%>&username=<%=username%>&equipe=<%=equipe%>&certificate=<%=certificate%>&dominio=<%=dominio%>&nomeCompleto=<%=nomeCompleto%>')"><label style="cursor: pointer"><b>Circulares</b></label></button></td>
       </tr>

   </table>
        <%} %>
</div>
                       <%   if (listStringBuilderProduto.Count <= 0)
                  { %>
                      
                           <div class="row">
                                 <div class="col">
                                        <label class="lblCarrossel"><b></b></label>
                                 </div>
                          </div>
                          <div class="row" style="height: 400px;">
                                 <div class="col" style="text-align: center;">
                                           <label class="lblCarrossel" style="font-size: 16px; color: red; text-align: center;"><b><%=msgCarrosselVazio %></b></label>
                                </div>
                          </div>

             <%  } else { %>  
                          <% string produtoCorrente = ""; 
                          for(var i = 0; i < listStringBuilderProduto.Count; i++) {
                            if (produtoCorrente.Equals(""))
                            {
                                produtoCorrente = listStringBuilderProduto[i].getTipoProduto(); %>
                                <div class="row">
                                 <div class="col">
                                        <label class="lblCarrossel"><b><%=tituloCarrossel %><%= produtoCorrente %></b></label>
                                 </div>
                                </div>
                          <%}
                            if (!produtoCorrente.Equals(listStringBuilderProduto[i].getTipoProduto()))
                            {
                                produtoCorrente = listStringBuilderProduto[i].getTipoProduto(); %>
                                <div class="row">
                                 <div class="col">
                                        <label class="lblCarrossel"><b><%=tituloCarrossel %><%= produtoCorrente %></b></label>
                                 </div>
                                </div>
                          <%}%>

                           
                          <div class="row">
                                 <div class="col">
                                           <% HttpContext.Current.Response.Write(listStringBuilderProduto[i].GetStringBuilder().ToString());
                                             HttpContext.Current.Response.Flush(); %>
                                </div>
                          </div>
                          <%if(i == listStringBuilderProduto.Count - 1) { %>
                          <div class="row" style="height: 350px;">
                                 <div class="col">
                                        <label class="lblCarrossel"><b></b></label>
                                 </div>
                          </div>
                          <%  }
                              }  %>
                       <%  }  %>                      
                          
                    </div>
       
                </div>
            </div>
           </div>

          </div>
          <%if (dominiosLatam.Contains(dominio))
              { %>
              <footer class="footer">
                <div class="container" style="background: #011E41; justify-content: flex-start; padding-left: 50px; display: flex; flex-wrap: wrap">
                    <div class="row" style="margin-top: 30px; width: 100%">
                        <div class="col-md-12">
                            <div class="row flex-container" style="flex-wrap: nowrap;">
                                <div class="col-4">
                                    <ul class="list-unstyled">
                                        <li style="margin-bottom: 10px; font-size: 20px;"><a href="https://use.sabacloud.com/Saba/Web_spf/NA1PRD0102/app/me/plans" target="_top" style="color: #FFF; text-decoration: solid">Entrenamientos</a></li>
                                        <li style="margin-bottom: 10px; font-size: 20px; cursor: pointer;"><a onclick="carregaTela('default.aspx?url=https://use-api.sabacloud.com&certificate=<%=certificate %>&userName=<%=username%>&idUser=<%=idUser %>&idioma=<%=idioma%>&pais=<%=pais%>&idUser=<%=idUser%>&urlVolta=https://server.impulse.net.br/eluxcity/pages/index.aspx&tipoArvore=Arvore%20Produtos')" style="color: #FFF; text-decoration: solid">Check list</a></li>
                                    </ul>
                                </div>  
                            </div>
                            <div class="row">
                                <div class="col-12" style="display: flex; justify-content: right">
                                    <img src="../includes/images/logo_rodape_resize.png" style="height: 35px"/>
                                </div>
                            
                            </div>
                            <br>
                        </div>
                    </div>
                </div>
            </footer>
          
          <%}
              else if (dominiosUWM.Contains(dominio))
              { %>
            <footer class="footer">
                <div class="container" style="background: #011E41; justify-content: flex-start; padding-left: 50px; display: flex; flex-wrap: wrap">
                    <div class="row" style="margin-top: 30px; width: 100%">
                        <div class="col-md-12">
                            <div class="row flex-container" style="flex-wrap: nowrap;">
                                <div class="col-4">
                                    <ul class="list-unstyled">
                                        <li style="margin-bottom: 10px; font-size: 20px;"><a href="https://use.sabacloud.com/Saba/Web_spf/NA1PRD0102/app/me/plans" target="_top" style="color: #FFF; text-decoration: solid">Trainings</a></li>
                                        <li style="margin-bottom: 10px; font-size: 20px; cursor: pointer;"><a onclick="carregaTela('default.aspx?url=https://use-api.sabacloud.com&certificate=<%=certificate %>&userName=<%=username%>&idUser=<%=idUser %>&idioma=<%=idioma%>&pais=<%=pais%>&idUser=<%=idUser%>&urlVolta=https://server.impulse.net.br/eluxcity/pages/index.aspx&tipoArvore=Arvore%20Produtos')" style="color: #FFF; text-decoration: solid">Check list</a></li>
                                    </ul>
                                </div>  
                            </div>
                            <div class="row">
                                <div class="col-12" style="display: flex; justify-content: right">
                                    <img src="../includes/images/logo_rodape_resize.png" style="height: 35px"/>
                                </div>
                            
                            </div>
                            <br>
                        </div>
                    </div>
                </div>
            </footer>
          <%} else { %>
          <footer class="footer">
            <div class="container" style="background: #011E41; justify-content: flex-start; padding-left: 50px; display: flex; flex-wrap: wrap">
                <div class="row" style="margin-top: 30px; width: 100%">
                    <div class="col-md-12">
                        <div class="row flex-container" style="flex-wrap: nowrap;">
                            <div class="col-4">
                                <ul class="list-unstyled">
                                    <li style="margin-bottom: 10px; font-size: 20px;"><a href="https://use.sabacloud.com/Saba/Web_spf/NA1PRD0102/app/me/plans" target="_top" style="color: #FFF; text-decoration: solid">Treinamentos</a></li>
                                    <li style="margin-bottom: 10px; font-size: 20px;"><a href="" onclick="alert('Em breve - Página em construção');" style="color: #FFF; text-decoration: solid">Fale com a engenharia</a></li>
                                    <li style="margin-bottom: 10px; font-size: 20px; cursor: pointer;"><a onclick="carregaTela('default.aspx?url=https://use-api.sabacloud.com&certificate=<%=certificate %>&idUser=<%=idUser %>&userName=<%=username%>&idioma=pt-BR&urlVolta=https://server.impulse.net.br/eluxcity/pages/index.aspx&tipoArvore=Arvore%20Produtos')" style="color: #FFF; text-decoration: solid">Check list</a></li>
                                    <li style="font-size: 20px;"><a target="_blank" href="http://vistaexplodida.eluxinfo.com.br/" style="color: #FFF; text-decoration: solid">Peças e acessórios</a></li>
                                </ul>
                            </div>
                            <div class="col-8">
                                <ul class="list-unstyled">
                                    <%if (dominio != "BRA - Consumer Care" && dominio != "BRA - Service Center")
                                        { %>
                                    <li style="margin-bottom: 10px; font-size: 20px;"><a onclick="carregaTela('minhacoroa.aspx?url=https://use-api.sabacloud.com&certificate=<%=certificate %>&userName=<%=username%>&nomeCompleto=<%=nomeCompleto %>&equipe=<%=equipe %>&idUser=<%=idUser %>&dominio<%=dominio %>')" style="color: #FFF; text-decoration: solid; cursor: pointer">Extrato de Coroas</a></li>
                                    <%} %>
                                    <li style="margin-bottom: 10px; font-size: 20px;"><a target="_blank" href="https://institucional.electrolux.com.br/politicas" style="color: #FFF; text-decoration: solid">Política de privacidade</a></li>
                                    <li style="margin-bottom: 10px; font-size: 20px;"><a href="" onclick="alert('Em breve - Página em construção');" style="color: #FFF; text-decoration: solid">Termos de uso</a></li>
                                    <li style="margin-bottom: 10px; font-size: 20px; cursor: pointer;"><a onclick="carregaTela('contactcenter.aspx?idUser=<%=idUser%>&username=<%=username%>&equipe=<%=equipe%>&certificate=<%=certificate%>&dominio=<%=dominio%>')" style="color: #FFF; text-decoration: solid">Ajuda</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12" style="display: flex; justify-content: right">
                                <img src="../includes/images/logo_rodape_resize.png" style="height: 35px"/>
                            </div>
                            
                        </div>
                        <br>
                    </div>
                </div>
            </div>
        </footer> 
        <%} %>
        <script>
            const swiper = new Swiper('.swiper', {
                loop: true,

                autoplay: {
                    delay: 15000,
                },

                pagination: {
                    el: '.swiper-pagination',
                },

                navigation: {
                    nextEl: '.swiper-button-next',
                    prevEl: '.swiper-button-prev',
                },
            });
        </script>
	</body>

</html>

