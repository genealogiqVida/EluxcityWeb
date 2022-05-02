<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="consultar.aspx.cs" Inherits="EluxcityWeb.pages.consultar" %>

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

        function carregaConsulta() {
            document.getElementById('dadosConsulta').style.display = "";
        }

    </script>
</head>


<body>
    <div class="container-fluid">
   
    
     <br />
                      <ul>
                                     <li><a class="liMenu" href="index.aspx?idUser=<%=idUser %>&username=<%=username %>"  ><img src="../includes/arvore/imagens/home.png" class="img-responsive" style="cursor: pointer;" /></a></li>
          
                          <li><a class="liMenu" href="minhacoroa.aspx?idUser=<%=idUser %>&username=<%=username %>"  >Minhas Coroas</a></li>
                            <li><a href="consultar.aspx?idUser=<%=idUser %>&username=<%=username %>" class="liMenu activeMenu">Consultar</a></li>
                            <li><a href="transferir.aspx?idUser=<%=idUser %>&username=<%=username %>" class="liMenu">Transferir</a></li>
                            <li><a href="exportar.aspx?idUser=<%=idUser %>&username=<%=username %>" class="liMenu">Exportar</a></li>
                         </ul>    


      <div class="modal-body">
  
        <table style="width: 100%">   
            <tr>
                <td style="width:30%;">&nbsp;</td>
                <td>      
                     <div id="cadastro" style="position: absolute; top:0px;" >
                         <br /><br />
                        <fieldset class="scheduler-border">
    <legend class="scheduler-border">Selecione o usuário</legend>
                          <div class="form-group">
            <label for="linha" class="control-label"><b>Usuário</b></label>
            <select class="form-control" id="usuario" style="width: 250px !important" onchange="carregaConsulta();" >
                <option></option>
                <option value="Felipe Miranda">Felipe Miranda</option>
            </select>
       </div>
</fieldset>
     <div id="dadosConsulta" style="display: none;">

                         <br />
                         <table style="width: 100%">   
                             <tr>
                                 <td style="width:25%">&nbsp;</td>
                                 <td align="center">
                                 <table style="width: 100%">   
                                      <tr><td align="center"><label style="font-size: 18px;"><b><u>Felipe Miranda</u></b></label></td></tr>
                                   
                                      <tr><td align="center"><span style="font-size: 28px; font-style: normal; font-weight: 500;">Saldo</span></td></tr>
                                     <tr><td align="center"><span style="font-size: 32px; font-style: normal; font-weight: 500; color:#2AD2FF;"><b>1.600</b></span></td></tr>
                                 </table>
                             </td>
                           
                                 <td style="width:25%">&nbsp;</td>
                         </tr>
                        </table>
                         <br /><br />
                          <label style="color:#051D50; font-size: 18px;"><b>Resumo das Coroas</b></label>
                         <hr />

                         <table style="width:100%">
                             <tr>
                                 <td style="padding: 0px 0px 0px 10px; height: 30px;"><b>Atividade</b></td><td align="center"><b>Quantidade</b></td><td align="center"><b>Coroas</b></td>
                             </tr>

                             <tr style="font-size: 14px; line-height: 25px; background-color: #D4F6FF;">
                                 <td style="padding:0px 0px 0px 10px;">Cursos Atribuídos</td><td align="center">20</td><td align="center">2000</td>
                             </tr>

                             <tr style="font-size: 14px;line-height: 25px;">
                                 <td style="padding:0px 0px 0px 10px;">Cursos Terminados com êxito</td><td align="center">12</td><td align="center">1222</td>
                             </tr>

                             <tr style="font-size: 14px;line-height: 25px;background-color: #D4F6FF;">
                                 <td style="padding:0px 0px 0px 10px;">Seguindo</td><td align="center">2</td><td align="center">3000</td>
                             </tr>

                             <tr style="font-size: 14px;line-height: 25px;">
                                 <td style="padding:0px 0px 0px 10px;">Provas Realizadas</td><td align="center">5</td><td align="center">4000</td>
                             </tr>

                             <tr style="font-size: 14px;line-height: 25px;background-color: #D4F6FF;">
                                 <td style="padding:0px 0px 0px 10px;">Likes Dados</td><td align="center">7</td><td align="center">40</td>
                             </tr>

                         </table>




                         <br /><br />
                           <table><tr><td><label style="color:#051D50; font-size: 18px;"><b>Coroas especiais</b></label></td><td><img src="../includes/arvore/imagens/coroas.png" class="img-responsive" style="width:32px;" /></td></tr></table>
                         <hr />

                         <table style="width:100%">
                             <tr>
                                 <td style="padding: 0px 0px 0px 10px; height: 30px;"><b>Data</b></td><td><b>Administrador</b></td><td><b>Motivo</b></td><td><b>Pontos</b></td>
                             </tr>

                             <tr style="font-size: 14px; line-height: 25px; background-color: #CED2DD">
                                 <td style="padding:0px 0px 0px 10px;">01/01/2022</td><td>José Maria Silva</td><td>Colaboração em projeto</td><td>100</td>
                             </tr>

                             <tr style="font-size: 14px;line-height: 25px;">
                                <td style="padding:0px 0px 0px 10px;">01/01/2022</td><td>José Maria Silva</td><td>Colaboração em projeto</td><td>100</td>
                             </tr>

                             <tr style="font-size: 14px;line-height: 25px;background-color: #CED2DD">
                                <td style="padding:0px 0px 0px 10px;">01/01/2022</td><td>José Maria Silva</td><td>Colaboração em projeto</td><td>100</td>
                             </tr>

                             <tr style="font-size: 14px;line-height: 25px;">
                                <td style="padding:0px 0px 0px 10px;">01/01/2022</td><td>José Maria Silva</td><td>Colaboração em projeto</td><td>100</td>
                             </tr>

                             <tr style="font-size: 14px;line-height: 25px;background-color: #CED2DD;">
                                <td style="padding:0px 0px 0px 10px;">01/01/2022</td><td>José Maria Silva</td><td>Colaboração em projeto</td><td>100</td>
                             </tr>

                         </table>

                   </div>

                     </div>
                </td>
                <td style="width:30%;">&nbsp;</td>

            </tr>  
        </table>


         


     </div>  
        
         
</div>

     <div class="container" style="margin-top: 15%;">
         <div class="row">
              <div class="col"> 
                    <img src="../includes/arvore/imagens/rodape.png"  class="imgTopo" />

              </div>
          </div>
       </div>  
</body>
</html>
