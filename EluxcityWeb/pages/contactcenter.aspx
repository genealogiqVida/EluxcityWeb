<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contactcenter.aspx.cs" Inherits="EluxcityWeb.pages.contactcenter" %>

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


         <script src="../includes/js/index_20.js"></script>
        <script src="../includes/js/index_21.js"></script>
        <script src="../includes/js/index_22.js"></script>
        <script src="../includes/js/index_23.js"></script>
        <script src="../includes/js/index_24.js"></script>
        <script src="../includes/js/index_25.js"></script>
        <script src="../includes/js/index_26.js"></script>
        <script src="../includes/js/index_27.js"></script>
        <script src="../includes/js/index_28.js"></script>

     <style>
         
         .form-select {

            font-weight: 700 !important;
    color: #0a3992 !important;
         }

     </style>
</head>

	<body style="overflow:auto; background-color:#e6e6e6"  id="tela">
        <div class="container">
         <div class="row">
              <div class="col" style="width: 1200px; height:220px; background: url('../includes/images/logo_contactcenter.png');"> 
                 
                 


              </div>
          </div>
       </div>
      <div class="container">
         
          <table><tr><td style="width:20%">&nbsp;</td>
              <td align="center">
                  <div class="card" style="min-width: 1202px !important;">
                      <div class="card-body">


                          


                          <table style="width:36%">
       <tr>
           <td> <button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('index.aspx?idUser=<%=idUser%>&username=<%=username%>&equipe=<%=equipe%>')"><label style="cursor: pointer"><b>Home</b></label></button></td>
           <td><button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('default.aspx?url=https://eluxcitysb-api.sabacloud.com&certificate=<%=certificate%>&userName=<%=username%>&idioma=pt-BR&urlVolta=https://www.eluxcity.com/home.aspx&tipoArvore=Arvore%20Backoffice&idUser=<%=idUser%>')"><label style="cursor: pointer"><b>Back Office N3</b></label></button></td>
           <td> <button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('default.aspx?url=https://eluxcitysb-api.sabacloud.com&certificate=<%=certificate%>&userName=<%=username%>&idioma=pt-BR&urlVolta=https://www.eluxcity.com/home.aspx&tipoArvore=Arvore%20Produtos&idUser=<%=idUser%>')"><label style="cursor: pointer"><b>Check List</b></label></button></td>
           <td> <button type="button" class="btn btn-warning" style="cursor: pointer" onclick="carregaTela('minhacoroa.aspx?url=https://eluxcitysb-api.sabacloud.com&certificate=<%=certificate%>&userName=<%=username%>&idioma=pt-BR&urlVolta=https://www.eluxcity.com/home.aspx&tipoArvore=Arvore%20Backoffice&idUser=<%=idUser%>')"><label style="cursor: pointer"><b>Coroas</b></label></button></td>
       </tr>

   </table>




<br />
                           <div >
                                 <div class="row">
                                     <div class="col">
                                         <span style=" font-weight: 700;color: #0a3992; font-size:24px;">Contact Center</span>
                                     </div>

                                 </div>
                                  <br />

                                <div class="row">
                                         <div class="col">
                                            <div class="form-group">
                                               <label for="email" class="control-label" style="color:#97a8ba;height: 28px;left: -163px;position: relative;">Email address</label>
                                                <input type="email" class="form-control" id="email" placeholder="name@example.com" style="width: 420px !important">
                                            </div>
                                         </div>
                                       </div>

                               <br />
                               <div class="row">
                                         <div class="col">
                                                  <div class="form-group">
                                                            <label for="categoria" class="control-label" style="color:#97a8ba;height: 28px;left: -176px;position: relative;">Categoria</label>
                                                               <select class="form-select"  aria-label="Escolha uma opção" id="categoria" style="width: 420px !important">
                                                              <option value="0">Escolha uma opção</option>
                                                              <option value="1">Categoria 1</option>
                                                              <option value="2">Categoria 2</option>
                                                              <option value="3">Categoria 3</option>
                                                            </select>
                                                  </div>
                                       </div>
                                   </div>
   <br />
                      <div class="row">
                                         <div class="col">
                                            <div class="form-group">
                                               <label for="nome" class="control-label" style="color:#97a8ba;height: 28px;left: -187px;position: relative;">Nome</label>
                                                <input type="text" class="form-control" id="nome" style="width: 420px !important">
                                            </div>
                                         </div>
                                       </div>
                                  <br />
                                <div class="row">
                                         <div class="col">
                                            <div class="form-group">
                                               <label for="assunto" class="control-label" style="color:#97a8ba;height: 28px;left: -182px;position: relative;">Assunto</label>
                                                <input type="text" class="form-control" id="assunto"  style="width: 420px !important">
                                            </div>
                                         </div>
                                       </div>
                                  <br />  
                           <div class="row">
                                         <div class="col">
                                            <div class="form-group">
                                               <label for="ordem" class="control-label" style="color:#97a8ba;height: 28px;left: -148px;position: relative;">Ordem de Serviço</label>
                                                <input type="text" class="form-control" id="ordem" style="width: 420px !important">
                                            </div>
                                         </div>
                                       </div>
                                  <br />
                                 <div class="row">
                                         <div class="col">
                                            <div class="form-group">
                                               <label for="numeroPeca" class="control-label" style="color:#97a8ba;height: 28px;left: -152px;position: relative;">Número da peça</label>
                                                <input type="text" class="form-control" id="numeroPeca" style="width: 420px !important">
                                            </div>
                                         </div>
                                       </div>
                                  <br />   <br />
                                 <div class="row">
                                     <div class="col">
                                        
                                         <button type="button" class="btn" style="background-color:#011844; color:#FFFFFF;    width: 110px;">Enviar</button>
                                     </div>

                                 </div>
                               <br /><br />
                           
                           </div>
                    </div>     
                </div>

              </td>
              <td style="width:20%">&nbsp;</td>

                 </tr></table>
         
               
           

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
