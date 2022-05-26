<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="proprietario.aspx.cs" Inherits="EluxcityWeb.pages.proprietario" %>

<html style="background-color:#e6e6e6">
	<head>	
       
       <meta name="viewport" content="width=device-width, height=device-height, initial-scale=1" />
       <link rel="stylesheet" type="text/css" href="engine1/style.css" />
	   <script type="text/javascript" src="engine1/jquery.js"></script>
	   <link rel="stylesheet" type="text/css" href="../includes/css/estilo.css"/>	
       <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>		
       <link rel="stylesheet" href="../includes/css/tooltipster.bundle.min.css" type="text/css" />
       <link rel="stylesheet" href="../includes/css/tooltipster-sideTip-punk.min.css" type="text/css" />
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

                <script>
                    function fechaLoad() {
                        document.getElementById('loading').style.display = "none";
                    }
                    function abreLoad() {
                        document.getElementById('loading').style.display = "";
                    }

        </script>

          <style>

             		.spinner {
   position: absolute;
   left: 50%;
   top: 50%;
   height:60px;
   width:60px;
   margin:0px auto;
   -webkit-animation: rotation .6s infinite linear;
   -moz-animation: rotation .6s infinite linear;
   -o-animation: rotation .6s infinite linear;
   animation: rotation .6s infinite linear;
     border-left:6px solid rgba(0,174,239,.15);
   border-right:6px solid rgba(0,174,239,.15);
   border-bottom:6px solid rgba(0,174,239,.15);
   border-top:6px solid rgba(0,174,239,.8);
   border-radius:100%;
}
		
		
		.spinner_white {
   position: absolute;
   left: 50%;
   top: 45%;
    z-index: 999999;
   height:60px;
   width:60px;
   margin:0px auto;
   -webkit-animation: rotation .6s infinite linear;
   -moz-animation: rotation .6s infinite linear;
   -o-animation: rotation .6s infinite linear;
   animation: rotation .6s infinite linear;
      border-left: 6px solid #e7ecef94;
    border-right: 6px solid #e7ecef94;
    border-bottom: 6px solid #e7ecef94;
    border-top: 6px solid rgb(255, 255, 255);
   border-radius:100%;
}

@-webkit-keyframes rotation {
   from {-webkit-transform: rotate(0deg);}
   to {-webkit-transform: rotate(359deg);}
}
@-moz-keyframes rotation {
   from {-moz-transform: rotate(0deg);}
   to {-moz-transform: rotate(359deg);}
}
@-o-keyframes rotation {
   from {-o-transform: rotate(0deg);}
   to {-o-transform: rotate(359deg);}
}
@keyframes rotation {
   from {transform: rotate(0deg);}
   to {transform: rotate(359deg);}
}
		
		
		</style>

</head>

	<body style="overflow:auto; background-color:#e6e6e6"  id="tela" onload="fechaLoad()">
         <div id="loading" class="spinner_white"></div>
        <div class="container">
         <div class="row">
              <div class="col"> 
                   <img src="../includes/images/logo_administrativo.png" class="imgTopo" />

              </div>
          </div>
       </div>
      <div class="container">
         
          <div class="row">
              <div class="col"> 
               <div class="card" style="min-width: 1202px !important;">
                      <div class="card-body">
          
          
                             <div class="container">
   <% if(equipe.ToString().Equals("S")) { %>    
                               
                                  <table style="width:70%">
                                       <tr>
                                           <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('https://eluxcitysb-teste.sabacloud.com/Saba/Web_spf/NA1TNB0106/app/team/overview')"><label style="cursor: pointer"><b>Gestão da equipe</b></label></button></td>
                                           <!--<td><button type="button" class="btn btn-warning" style="cursor: pointer"><label style="cursor: pointer"><b>Service Plus</b></label></button></td>-->
                                           <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('manual.aspx?idUser=<%=idUser%>&username=<%=username%>&equipe=<%=equipe%>&certificate=<%=certificate%>')"><label style="cursor: pointer"><b>Manual de serviços</b></label></button></td>
                                           <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('boletim.aspx?idUser=<%=idUser%>&username=<%=username%>&equipe=<%=equipe%>&certificate=<%=certificate%>')"><label style="cursor: pointer"><b>Boletins técnicos</b></label></button></td>
                                           <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('videos.aspx?idUser=<%=idUser%>&username=<%=username%>&equipe=<%=equipe%>&certificate=<%=certificate%>')"><label style="cursor: pointer"><b>Vídeos</b></label></button></td>
                                       </tr>

                                   </table>


                                  

<%}else { %>

<table style="width:52%">
       <tr>
           <!--<td><button type="button" class="btn btn-warning" style="cursor: pointer"><label style="cursor: pointer"><b>Service Plus</b></label></button></td>-->
           <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('manual.aspx?idUser=<%=idUser%>&username=<%=username%>&equipe=<%=equipe%>&certificate=<%=certificate%>')"><label style="cursor: pointer"><b>Manual de serviços</b></label></button></td>
           <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('boletim.aspx?idUser=<%=idUser%>&username=<%=username%>&equipe=<%=equipe%>&certificate=<%=certificate%>')"><label style="cursor: pointer"><b>Boletins técnicos</b></label></button></td>
           <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('videos.aspx?idUser=<%=idUser%>&username=<%=username%>&equipe=<%=equipe%>&certificate=<%=certificate%>')"><label style="cursor: pointer"><b>Vídeos</b></label></button></td>
       </tr>

   </table>




                  <%} %>
</div>
                          <% if(!myStringBuilderLancamento.ToString().Equals("")) { %> 
                           <div class="row">
                                 <div class="col">
                                        <label class="lblCarrossel"><b>Lançamentos</b></label>
                                 </div>
                          </div>
                          <div class="row">
                                 <div class="col">
                                           <% HttpContext.Current.Response.Write(myStringBuilderLancamento.ToString());
                                             HttpContext.Current.Response.Flush(); %>
                                </div>
                          </div>
                    
                          <% }else{ %>

                           <div class="row">
                                 <div class="col">
                                        <label class="lblCarrossel"><b>Lançamentos</b></label>
                                 </div>
                          </div>
                          <div class="row">
                                 <div class="col" style="text-align: center;">
                                           <label class="lblCarrossel" style="font-size: 16px; color: red; text-align: center;"><b>Não existem conteúdos/cursos a serem exibidos aqui</b></label>
                                </div>
                          </div> 
                            
                           <% } %>
                            <% if(!myStringBuilderSugestao.ToString().Equals("")) { %> 
                          
                          <div class="row">
                                 <div class="col">
                                        <label class="lblCarrossel"><b>Sugestões para você</b></label>
                                 </div>
                          </div>
                          <div class="row">
                                 <div class="col">
                                           <% HttpContext.Current.Response.Write(myStringBuilderSugestao.ToString());
                                             HttpContext.Current.Response.Flush(); %>
                                </div>
                          </div>   
                          <% }else{ %>

                           <div class="row">
                                 <div class="col">
                                        <label class="lblCarrossel"><b>Sugestões para você</b></label>
                                 </div>
                          </div>
                          <div class="row">
                                 <div class="col" style="text-align: center;">
                                           <label class="lblCarrossel" style="font-size: 16px; color: red; text-align: center;"><b>Não existem conteúdos/cursos a serem exibidos aqui</b></label>
                                </div>
                          </div> 
                            
                           <% } %>

                           <% if (!myStringBuilderRecente.ToString().Equals(""))
                              { %> 
                          
                                                    <div class="row">
                                 <div class="col">
                                        <label class="lblCarrossel"><b>Vídeos mais recentes</b></label>
                                 </div>
                          </div>
                          <div class="row">
                                 <div class="col">
                                           <% HttpContext.Current.Response.Write(myStringBuilderRecente.ToString());
                                             HttpContext.Current.Response.Flush(); %>
                                </div>
                          </div>  

                           <% }else{ %>

                           <div class="row">
                                 <div class="col">
                                        <label class="lblCarrossel"><b>Vídeos mais recentes</b></label>
                                 </div>
                          </div>
                          <div class="row">
                                 <div class="col" style="text-align: center;">
                                           <label class="lblCarrossel" style="font-size: 16px; color: red; text-align: center;"><b>Não existem conteúdos/cursos a serem exibidos aqui</b></label>
                                </div>
                          </div> 
                            
                           <% } %>
                            <% if (!myStringBuilderPopular.ToString().Equals(""))
                              { %> 

                          
                                                    <div class="row">
                                 <div class="col">
                                        <label class="lblCarrossel"><b>Circulares mais recentes</b></label>
                                 </div>
                          </div>
                          <div class="row">
                                 <div class="col">
                                           <% HttpContext.Current.Response.Write(myStringBuilderPopular.ToString());
                                             HttpContext.Current.Response.Flush(); %>
                                </div>
                          </div>  

                           <% }else{ %>

                           <div class="row">
                                 <div class="col">
                                        <label class="lblCarrossel"><b>Circulares mais recentes</b></label>
                                 </div>
                          </div>
                          <div class="row">
                                 <div class="col" style="text-align: center;">
                                           <label class="lblCarrossel" style="font-size: 16px; color: red; text-align: center;"><b>Não existem conteúdos/cursos a serem exibidos aqui</b></label>
                                </div>
                          </div> 
                            
                           <% } %>

                            <% if (!myStringBuilderPrimeira.ToString().Equals(""))
                              { %> 
                          
                                                    <div class="row">
                                 <div class="col">
                                        <label class="lblCarrossel"><b>Boletins técnicos mais recentes</b></label>
                                 </div>
                          </div>
                          <div class="row">
                                 <div class="col">
                                           <% HttpContext.Current.Response.Write(myStringBuilderPrimeira.ToString());
                                             HttpContext.Current.Response.Flush(); %>
                                </div>
                          </div>  

                          
                           <% }else{ %>

                           <div class="row">
                                 <div class="col">
                                        <label class="lblCarrossel"><b>Boletins técnicos mais recentes</b></label>
                                 </div>
                          </div>
                          <div class="row">
                                 <div class="col" style="text-align: center;">
                                           <label class="lblCarrossel" style="font-size: 16px; color: red; text-align: center;"><b>Não existem conteúdos/cursos a serem exibidos aqui</b></label>
                                </div>
                          </div> 
                            
                           <% } %>

                            <% if (!myStringBuilderSegunda.ToString().Equals(""))
                              { %> 
                          
                                                    <div class="row">
                                 <div class="col">
                                        <label class="lblCarrossel"><b>Manuais técnicos mais recentes</b></label>
                                 </div>
                          </div>
                          <div class="row">
                                 <div class="col">
                                           <% HttpContext.Current.Response.Write(myStringBuilderSegunda.ToString());
                                             HttpContext.Current.Response.Flush(); %>
                                </div>
                          </div>  

                           <% }else{ %>

                           <div class="row">
                                 <div class="col">
                                        <label class="lblCarrossel"><b>Manuais técnicos mais recentes</b></label>
                                 </div>
                          </div>
                          <div class="row">
                                 <div class="col" style="text-align: center;">
                                           <label class="lblCarrossel" style="font-size: 16px; color: red; text-align: center;"><b>Não existem conteúdos/cursos a serem exibidos aqui</b></label>
                                </div>
                          </div> 
                            
                           <% } %>
                           <% if (!myStringBuilderTerceira.ToString().Equals(""))
                              { %> 
                          
                                                    <div class="row">
                                 <div class="col">
                                        <label class="lblCarrossel"><b>Treinamentos mais populares – Equipe técnica</b></label>
                                 </div>
                          </div>
                          <div class="row">
                                 <div class="col">
                                           <% HttpContext.Current.Response.Write(myStringBuilderTerceira.ToString());
                                             HttpContext.Current.Response.Flush(); %>
                                </div>
                          </div>  
                          
                          <% }else{ %>

                           <div class="row">
                                 <div class="col">
                                        <label class="lblCarrossel"><b>Treinamentos mais populares – Equipe técnica</b></label>
                                 </div>
                          </div>
                          <div class="row">
                                 <div class="col" style="text-align: center;">
                                           <label class="lblCarrossel" style="font-size: 16px; color: red; text-align: center;"><b>Não existem conteúdos/cursos a serem exibidos aqui</b></label>
                                </div>
                          </div> 
                            
                           <% } %>

                            <% if (!myStringBuilderProva.ToString().Equals(""))
                              { %> 
                          
                          <div class="row">
                                 <div class="col">
                                        <label class="lblCarrossel"><b>Treinamentos mais populares – Equipe administrativa</b></label>
                                 </div>
                          </div>
                          <div class="row">
                                 <div class="col">
                                           <% HttpContext.Current.Response.Write(myStringBuilderProva.ToString());
                                             HttpContext.Current.Response.Flush(); %>
                                </div>
                          </div>   
                                            
                          <% }else{ %>

                           <div class="row">
                                 <div class="col">
                                        <label class="lblCarrossel"><b>Treinamentos mais populares – Equipe administrativa</b></label>
                                 </div>
                          </div>
                          <div class="row">
                                 <div class="col" style="text-align: center;">
                                           <label class="lblCarrossel" style="font-size: 16px; color: red; text-align: center;"><b>Não existem conteúdos/cursos a serem exibidos aqui</b></label>
                                </div>
                          </div> 
                            
                           <% } %>
                    </div>
       
                </div>
            </div>
           </div>

          </div>

          <footer class="footer">
            <div class="container" style="background: #011E41; justify-content: flex-start; padding-left: 50px; display: flex; flex-wrap: wrap">
                <div class="row" style="margin-top: 30px; width: 100%">
                    <div class="col-md-12">
                        <div class="row" style="flex-wrap: nowrap;">
                            <div class="col-3">
                                <ul class="list-unstyled">
                                    <li style="margin-bottom: 10px; font-size: 20px;"><a href="https://eluxcitysb.sabacloud.com/Saba/Web_spf/NA1TNB0106/app/me/plans" target="_top" style="color: #FFF; text-decoration: solid">Treinamentos</a></li>
                                    <!--<li style="margin-bottom: 10px; font-size: 20px;"><a href="" style="color: #FFF; text-decoration: solid">Fale com a engenharia</a></li>-->
                                    <!--<li style="margin-bottom: 10px; font-size: 20px;"><a href="https://eluxcitysb.sabacloud.com/Saba/Web_spf/NA1TNB0106/app/dashboard" target="_top" style="color: #FFF; text-decoration: solid">Check list</a></li>-->
                                    <li style="font-size: 20px;"><a href="" style="color: #FFF; text-decoration: solid">Peças e acessórios</a></li>
                                </ul>
                            </div>
                            <div class="col-9">
                                <ul class="list-unstyled">
                                    <li style="margin-bottom: 10px; font-size: 20px;"><a href="" style="color: #FFF; text-decoration: solid">Política de privacidade</a></li>
                                    <li style="margin-bottom: 10px; font-size: 20px;"><a href="" style="color: #FFF; text-decoration: solid">Termos de uso</a></li>
                                    <!--<li style="margin-bottom: 10px; font-size: 20px;"><a href="" style="color: #FFF; text-decoration: solid">Ajuda</a></li>-->
                                </ul>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12" style="display: flex; justify-content: right">
                                <img src="../includes/images/logo_rodape_resize.png" style="height: 60px"/>
                            </div>
                            
                        </div>
                        <br>
                    </div>
                </div>
            </div>
        </footer>
   
	</body>

</html>