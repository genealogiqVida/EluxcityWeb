<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="minhacoroa.aspx.cs" Inherits="EluxcityWeb.pages.minhacoroa" %>



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
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap-tagsinput.css" />
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/estilo.css" />
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/estiloCoroas.css" />
    <script src="../includes/js/bootstrap5.min.js"></script>
    <link href="../includes/css/bootstrap5.min.css" type="text/css" rel="stylesheet">

    <script src="../includes/js/index_0.js"></script>

    <style>
        hr {
            margin-top: 0px !important;
            margin-bottom: 20px !important;
            border: 0 !important;
            border-top: 2px solid #000000 !important;
            width: 600px !important;
        }

    </style>
</head>


<body>
    <div class="container-fluid">
   
    
     <br />
                      <ul>
                          <li><a class="liMenu" onclick="carregaTela('index.aspx?idUser=<%=idUser%>&username=<%=username%>&equipe=<%=equipe%>&dominio=<%=dominio%>')" style="margin-right: 5px; height: 100%; padding: 17px 16px;"  ><img src="../includes/arvore/imagens/home.png" class="img-responsive" style="cursor: pointer;" /></a></li>
          
                          <li><a class="liMenu activeMenu" onclick="carregaTela('minhacoroa.aspx?url=https://use-api.sabacloud.com&certificate=<%=certificate %>&userName=<%=username%>&nomeCompleto=<%=nomeCompleto %>&equipe=<%=equipe %>&idUser=<%=idUser %>')"  >Minhas Coroas</a></li>
                            <%if (isAdmin == true)
                              { %>
                                <%--<li><a href="consultar.aspx?idUser=<%=idUser %>&username=<%=username %>" class="liMenu">Consultar</a></li>
                                <li><a href="transferir.aspx?idUser=<%=idUser %>&username=<%=username %>" class="liMenu">Transferir</a></li>
                                <li><a href="exportar.aspx?idUser=<%=idUser %>&username=<%=username %>" class="liMenu">Exportar</a></li>--%>
                                <li><a class="liMenu">Consultar</a></li>
                                <li><a class="liMenu">Transferir</a></li>
                                <li><a class="liMenu">Exportar</a></li>
                            <%} %>
                         </ul>    


      <div class="modal-body" style="overflow-y: auto;">
  
        <table style="width: 100%">   
            <tr>
                <td style="width:30%;">&nbsp;</td>
                <td>      
                     <div id="cadastro" style="position: absolute; top:0px;" >
                         <br /><br />
                         <div style="display: flex; justify-content: space-between">
                             <label style="font-size: 18px;"><b><%=nomeCompleto%></b></label>
                             <label style="font-size: 18px;"><b><%=dataAtualizacao%></b></label>
                         </div>
                         <hr />
                         <table style="width: 100%">   
                             <tr>
                                 <td style="width:25%">&nbsp;</td>
                                 <td align="center">
                                 <table style="width: 100%">   
                                     <tr><td align="center"><span style="font-size: 28px; font-style: normal; font-weight: 500;">Saldo</span></td></tr>
                                     <tr><td align="center"><span style="font-size: 32px; font-style: normal; font-weight: 500; color:#2AD2FF;"><b><%=saldo %></b></span></td></tr>
                                 </table>
                             </td>
                                 <td align="center">
                                     <table style="width: 100%">
                                         <tbody>
                                             <tr>
                                                 <td align="center">
                                                     <button type="button" class="btn" style="background-color: #2AD2FF; font-weight: bold;">
                                                     <span style="color: #FFFFFF;">Transferir Coroas</span></button></td>
                                             </tr>
                                             <tr>
                                                 <td align="center"><span>Shopclub</span></td>
                                             </tr>
                                         </tbody>
                                     </table>

                                 </td>
                                 <td style="width:25%">&nbsp;</td>
                         </tr>
                        </table>
                         <br /><br />
                          <label style="color:#051D50; font-size: 18px;"><b>Resumo das Coroas</b></label>
                         <hr />

                           <% HttpContext.Current.Response.Write(myStringBuilderCoroas.ToString());
                                             HttpContext.Current.Response.Flush(); %>




                         <br /><br />
                           <table><tr><td><label style="color:#051D50; font-size: 18px;"><b>Coroas especiais</b></label></td><td><img src="../includes/arvore/imagens/coroas.png" class="img-responsive" style="width:32px;" /></td></tr></table>
                         <hr />

                         <% HttpContext.Current.Response.Write(myStringBuilderCoroasEspeciais.ToString());
                                             HttpContext.Current.Response.Flush(); %>

                         <%--<table style="width:100%">
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

                         </table>--%>



                     </div>
                </td>
                <td style="width:30%;">&nbsp;</td>

            </tr>  
        </table>


         


     </div>  
        
         
</div>

     <footer class="footer">
            <div class="container" style="background: #011E41; justify-content: flex-start; padding-left: 50px; display: flex; flex-wrap: wrap">
                <div class="row" style="margin-top: 30px; width: 100%">
                    <div class="col-md-12">
                        <div class="row flex-container" style="flex-wrap: nowrap;">
                            <div class="col-4">
                                <ul class="list-unstyled" style="display: flex; flex-direction: column; background-color: #011E41 !important;">
                                    <li style="margin-bottom: 10px; font-size: 20px;"><a href="https://use.sabacloud.com/Saba/Web_spf/NA1PRD0102/app/me/plans" target="_top" style="color: #FFF; text-decoration: solid">Treinamentos</a></li>
                                    <li style="margin-bottom: 10px; font-size: 20px;"><a href="" style="color: #FFF; text-decoration: solid">Fale com a engenharia</a></li>
                                    <li style="margin-bottom: 10px; font-size: 20px; cursor: pointer;"><a onclick="carregaTela('default.aspx?url=https://use-api.sabacloud.com&certificate=<%=certificate%>&userName=<%=username%>&idioma=pt-BR&urlVolta=https://www.eluxcity.com/home.aspx&tipoArvore=Arvore%20Produtos&idUser=<%=idUser%>')" target="_top" style="color: #FFF; text-decoration: solid">Check list</a></li>
                                    <li style="font-size: 20px;"><a target="_blank"s href="http://vistaexplodida.eluxinfo.com.br/" style="color: #FFF; text-decoration: solid">Peças e acessórios</a></li>
                                </ul>
                            </div>
                            <div class="col-8">
                                <ul class="list-unstyled" style="display: flex; flex-direction: column; background-color: #011E41 !important;">
                                    <li style="margin-bottom: 10px; font-size: 20px;"><a href="" style="color: #FFF; text-decoration: solid; cursor: pointer">Extrato de Coroas</a></li>
                                    <li style="margin-bottom: 10px; font-size: 20px;"><a target="_blank" href="https://institucional.electrolux.com.br/politicas" style="color: #FFF; text-decoration: solid">Política de privacidade</a></li>
                                    <li style="margin-bottom: 10px; font-size: 20px;"><a href="" style="color: #FFF; text-decoration: solid">Termos de uso</a></li>
                                    <li style="margin-bottom: 10px; font-size: 20px; cursor: pointer;"><a onclick="carregaTela('contactcenter.aspx?idUser=<%=idUser%>&username=<%=username%>&equipe=<%=equipe%>&certificate=<%=certificate%>')" style="color: #FFF; text-decoration: solid">Ajuda</a></li>
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
