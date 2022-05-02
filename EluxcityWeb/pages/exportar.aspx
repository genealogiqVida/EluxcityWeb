<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="exportar.aspx.cs" Inherits="EluxcityWeb.pages.exportar" %>

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
</head>


<body>
    <div class="container-fluid">
   
    
     <br />
                      <ul>
                                     <li><a class="liMenu" href="index.aspx?idUser=<%=idUser %>&username=<%=username %>"  ><img src="../includes/arvore/imagens/home.png" class="img-responsive" style="cursor: pointer;" /></a></li>
          
                          <li><a class="liMenu" href="minhacoroa.aspx?idUser=<%=idUser %>&username=<%=username %>"  >Minhas Coroas</a></li>
                            <li><a href="consultar.aspx?idUser=<%=idUser %>&username=<%=username %>" class="liMenu">Consultar</a></li>
                            <li><a href="transferir.aspx?idUser=<%=idUser %>&username=<%=username %>" class="liMenu">Transferir</a></li>
                            <li><a href="exportar.aspx?idUser=<%=idUser %>&username=<%=username %>" class="liMenu activeMenu">Exportar</a></li>
                         </ul>    


      <div class="modal-body">


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
