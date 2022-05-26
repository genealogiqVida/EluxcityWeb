<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="transferir.aspx.cs" Inherits="EluxcityWeb.pages.transferir" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1">
 
       <script src="../includes/arvore/js/jquery-1.10.2.js"  type="text/javascript"></script>
    <script src="../includes/arvore/js/jquery-ui-1.10.4.custom.js"  type="text/javascript"></script>
    <script src="../includes/arvore/js/jquery.alerts.js"  type="text/javascript"></script>
    <script src="../includes/arvore/js/bootstrap.js"  type="text/javascript"></script>
    <script src="../includes/arvore/js/bootstrap-table.js" type="text/javascript"></script>
    <script src="../includes/arvore/js/bootstrap-multiselect.js"></script>
    <script src="../includes/arvore/js/bootstrap-tagsinput.js"  type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/jquery-ui-1.10.4.custom.css" /> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/jquery.alerts.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap-table.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap-tagsinput.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/estilo.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/estiloCoroas.css"/> 

    <style>
        hr {
            margin-top: 0px !important;
            margin-bottom: 20px !important;
            border: 0 !important;
            border-top: 2px solid #000000 !important;
            width: 600px !important;
        }

    </style>

    <script>
        function carregaResultado() {
            
            document.getElementById('dadosResultado').style.display = "";
        }

    </script>

</head>


<body>
    <div class="container-fluid">
   
    
     <br />
                      <ul>
                                     <li><a class="liMenu" href="index.aspx?idUser=<%=idUser %>&username=<%=username %>"  ><img src="../includes/arvore/imagens/home.png" class="img-responsive" style="cursor: pointer;" /></a></li>
          
                          <li><a class="liMenu" href="minhacoroa.aspx?idUser=<%=idUser %>&username=<%=username %>"  >Minhas Coroas</a></li>
                            <li><a href="consultar.aspx?idUser=<%=idUser %>&username=<%=username %>" class="liMenu">Consultar</a></li>
                            <li><a href="transferir.aspx?idUser=<%=idUser %>&username=<%=username %>" class="liMenu activeMenu">Transferir</a></li>
                            <li><a href="exportar.aspx?idUser=<%=idUser %>&username=<%=username %>" class="liMenu">Exportar</a></li>
                         </ul>    


      <div class="modal-body">


             <table style="width: 100%">   
            <tr>
                <td style="width:30%;">&nbsp;</td>
                <td>      
                     <div id="cadastro" style="position: absolute; top:0px;" >
                         <br /><br />
                         <label style="font-size: 18px;"><b>Debitar/Creditar Coroas</b></label>
                         <hr /><br />
                        
                                 <table style="width: 100%">   
                                     <tr><td>
                                              <div class="form-group">
                                                <label for="linha" class="control-label"><b>1.</b>&nbsp;Selecione o usuário</label>
                                                <select class="form-control" id="usuario" style="width: 325px !important" onchange="carregaResultado()">
                                                    <option></option>
                                                    <option value="Felipe Miranda">Felipe Miranda</option>
                                                </select>
                                           </div>
                                        </td></tr>
                                </table>

                              <div id="dadosResultado" style="display:none">
                                 <table style="width: 100%">   
                                     <tr><td>
                                              <div>
                                                <label for="linha" class="control-label">Resultado:</label><br /> 
                                                <table style="width:81.5%" border="1">
                                                    <tr>
                                                        <td><b>Username</b></td>
                                                        <td><b>Nome</b></td>
                                                        <td><b>Coroas</b></td>
                                                    </tr>
                                                    <tr>
                                                        <td>felipe.miranda</td>
                                                        <td>Felipe Miranda</td>
                                                        <td>1563</td>
                                                    </tr>
                                                </table> 
                                               
                                           </div>
                                        </td></tr>
                                </table>
                        <br />

                         </div>
                         <table style="width: 100%">   
                                     <tr><td style="width: 255px;">
                                              <div class="form-group">
                                                <label for="linha" class="control-label"><b>2.</b>&nbsp;</label>
                                                <input type="radio" id="radioAdd" name="radioAdd" value="A" />&nbsp;Adicionar
                                               <br /> <div style="position:relative; left:21px;"><input type="radio" id="radioAdd" name="radioAdd" value="S" />&nbsp;Subtrair</div>
                                           </div>
                                        </td>
                                        
                                         <td>
                                              <div class="form-group">
                                                <label for="nomePor" class="control-label">Coroas:</label>
                                                <input type="number" class="form-control" id="qtdeCoroa" style="width: 170px !important" placeholder="Informe a quantidade"/>
                                            </div>

                                         </td>

                                     </tr>
                                </table>


                          <table style="width: 100%">   
                                     <tr><td>
                                              <div class="form-group">
                                                 <label for="linha" class="control-label"><b>3.</b>&nbsp;Justificativa:</label>
                                                <textarea id="justificativa" cols="40" rows="4" ></textarea>
                                                  
                                                  
                                           </div>
                                       </td>
                                        
                                    

                                     </tr>
                                </table>


                         <table style="width: 81.5%">   
                                     <tr><td align="right">
                                              <div class="form-group">
                                                  <button type="button" class="btn" style="background-color: #2AD2FF;
    font-weight: bold;" ><span style="color:#FFFFFF;">Transferir</span></button>
                                                  
                                           </div>
                                       </td>
                                        
                                    

                                     </tr>
                                </table>


                     </div>
                </td>
                <td style="width:30%;">&nbsp;</td>

            </tr>  
        </table>


          </div>

     <footer class="footer">
            <div class="container" style="background: #011E41; justify-content: flex-start; padding-left: 50px; display: flex; flex-wrap: wrap">
                <div class="row" style="margin-top: 30px; width: 100%">
                    <div class="col-md-12">
                        <div class="row" style="flex-wrap: nowrap;">
                            <div class="col-3">
                                <ul class="list-unstyled">
                                    <li style="margin-bottom: 10px; font-size: 20px;"><a href="https://eluxcitysb.sabacloud.com/Saba/Web_spf/NA1TNB0106/app/me/plans" style="color: #FFF; text-decoration: solid">Treinamentos</a></li>
                                    <!--<li style="margin-bottom: 10px; font-size: 20px;"><a href="" style="color: #FFF; text-decoration: solid">Fale com a engenharia</a></li>-->
                                    <!--<li style="margin-bottom: 10px; font-size: 20px;"><a href="https://eluxcitysb.sabacloud.com/Saba/Web_spf/NA1TNB0106/app/dashboard" style="color: #FFF; text-decoration: solid">Check list</a></li>-->
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