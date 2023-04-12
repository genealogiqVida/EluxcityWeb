<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="principalLatamUWM.aspx.cs" Inherits="EluxcityWeb.pages.principalLatamUWM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
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
       <link rel="stylesheet" href="https://unpkg.com/swiper@8/swiper-bundle.min.css" />
       <script src="https://unpkg.com/swiper@8/swiper-bundle.min.js"></script>
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
<body>
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
        <div class="container" style="overflow-y: scroll !important; overflow-x: hidden !important; max-height: 1100px;">
         
          <div class="row">
              <div class="col"> 
               <div class="card" style="min-width: 1202px !important;">
                      <div class="card-body">

                          <div class="container">

                              <table style="width: 70%">
                                  <tr>
                                      <!--<td><button type="button" class="btn btn-warning" style="cursor: pointer"><label style="cursor: pointer"><b>Service Plus</b></label></button></td>-->
                                      <td>
                                          <button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('manual.aspx?idUser=<%=idUser%>&username=<%=personNO%>&equipe=<%=equipe%>&certificate=<%=certificate%>&dominio=<%=dominio%>&nomeCompleto=<%=nomeCompleto%>')">
                                              <label style="cursor: pointer"><b>Service manual</b></label></button></td>
                                      <td>
                                          <button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('boletim.aspx?idUser=<%=idUser%>&username=<%=personNO%>&equipe=<%=equipe%>&certificate=<%=certificate%>&dominio=<%=dominio%>&nomeCompleto=<%=nomeCompleto%>&idioma=<%=idioma %>')">
                                              <label style="cursor: pointer"><b>Technical Bulletins</b></label></button></td>
                                      <td>
                                          <button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('videos.aspx?idUser=<%=idUser%>&username=<%=personNO%>&equipe=<%=equipe%>&certificate=<%=certificate%>&dominio=<%=dominio%>&nomeCompleto=<%=nomeCompleto%>')">
                                              <label style="cursor: pointer"><b>Videos</b></label></button></td>
                                  </tr>

                              </table>
                          </div>
          
          
                         
                          <% if(!myStringBuilderLancamento.ToString().Equals("")) { %>
                           <div class="row">
                                 <div class="col">
                                        <label class="lblCarrossel"><b>Releases</b></label>
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
                                        <label class="lblCarrossel"><b>Releases</b></label>
                                 </div>
                          </div>
                          <div class="row">
                                 <div class="col" style="text-align: center;">
                                           <label class="lblCarrossel" style="font-size: 16px; color: red; text-align: center;"><b>There are no contents/courses to display here</b></label>
                                </div>
                          </div> 
                            
                           <% } %>
                          
                          <% if(!myStringBuilderTreinamento.ToString().Equals("")) { %>
                          <div class="row">
                                 <div class="col">
                                        <label class="lblCarrossel"><b>Training for you</b></label>
                                 </div>
                          </div>
                          <div class="row">
                                 <div class="col">
                                           <% HttpContext.Current.Response.Write(myStringBuilderTreinamento.ToString());
                                             HttpContext.Current.Response.Flush(); %>
                                </div>
                          </div> 
                          <% }else{ %>

                           <div class="row">
                                 <div class="col">
                                        <label class="lblCarrossel"><b>Training for you</b></label>
                                 </div>
                          </div>
                          <div class="row">
                                 <div class="col" style="text-align: center;">
                                           <label class="lblCarrossel" style="font-size: 16px; color: red; text-align: center;"><b>There are no contents/courses to display here</b></label>
                                </div>
                          </div> 
                            
                           <% } %>
                            
                            <% if (!myStringBuilderSegunda.ToString().Equals(""))
                              { %> 
                          
                                                    <div class="row">
                                 <div class="col">
                                        <label class="lblCarrossel"><b>Latest technical manuals</b></label>
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
                                        <label class="lblCarrossel"><b>Latest technical manuals</b></label>
                                 </div>
                          </div>
                          <div class="row">
                                 <div class="col" style="text-align: center;">
                                           <label class="lblCarrossel" style="font-size: 16px; color: red; text-align: center;"><b>There are no contents/courses to display here</b></label>
                                </div>
                          </div> 
                            
                           <% } %> 

                          <% if (!myStringBuilderPrimeira.ToString().Equals(""))
                              { %> 
                          
                                                    <div class="row">
                                 <div class="col">
                                        <label class="lblCarrossel"><b>Latest technical bulletins</b></label>
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
                                        <label class="lblCarrossel"><b>Latest technical bulletins</b></label>
                                 </div>
                          </div>
                          <div class="row">
                                 <div class="col" style="text-align: center;">
                                           <label class="lblCarrossel" style="font-size: 16px; color: red; text-align: center;"><b>There are no contents/courses to display here</b></label>
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
                        <div class="row flex-container" style="flex-wrap: nowrap;">
                            <div class="col-4">
                                <ul class="list-unstyled">
                                    <li style="margin-bottom: 10px; font-size: 20px;"><a href="https://use.sabacloud.com/Saba/Web_spf/NA1PRD0102/app/me/plans" target="_top" style="color: #FFF; text-decoration: solid">Trainings</a></li>
                                    <li style="margin-bottom: 10px; font-size: 20px; cursor: pointer;"><a onclick="carregaTela('default.aspx?url=https://use-api.sabacloud.com&certificate=<%=certificate %>&userName=<%=username%>&idioma=<%=idioma%>&pais=<%=pais%>&idUser=<%=idUser%>&urlVolta=https://server.impulse.net.br/eluxcity/pages/index.aspx&tipoArvore=Arvore%20Produtos')" style="color: #FFF; text-decoration: solid">Check list</a></li>
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
</body>
</html>
