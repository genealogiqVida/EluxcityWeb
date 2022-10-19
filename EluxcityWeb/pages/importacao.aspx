<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="importacao.aspx.cs"  Inherits="EluxcityWeb.pages.importacao" %>



<%
    string tipoAcesso = "administrador";
    string nome = "";
    string pais = "";
    string idioma = "";
    string tipoArvore = "";
    string username = "";
    HttpCookie cookie = Request.Cookies["tipoAcesso"];
    if (cookie != null)
        tipoAcesso = cookie.Value.ToString();

    tipoAcesso = Request.Params.Get("tipoAcesso");
    if (tipoAcesso.IndexOf(',') != -1)
    {
        tipoAcesso = tipoAcesso.Split(',')[0];
    }

    cookie = Request.Cookies["nome"];
    if (cookie != null)
    {
        nome = cookie.Value.ToString();
        nome = nome.Replace("%20", " ");
    }


    cookie = Request.Cookies["pais"];
    if (cookie != null)
    {
        pais = cookie.Value.ToString();
        pais = pais.Replace("%20", " ");
    }

    cookie = Request.Cookies["idioma"];
    if (cookie != null)
    {
        idioma = cookie.Value.ToString();
        idioma = idioma.Replace("%20", " ");
    }


    cookie = Request.Cookies["usuario"];
    if (cookie != null)
    {
        username = cookie.Value.ToString();
        username = username.Replace("%20", " ");
    }

    cookie = Request.Cookies["tipoArvore"];
    if (cookie != null)
    {
        tipoArvore = cookie.Value.ToString();
        tipoArvore = tipoArvore.Replace("%20", " ");
    }

    //tipoArvore = Session["tipoArvore"].ToString();
    tipoArvore = tipoArvore.Replace("%20", " ");


    string lblMenu1 = "Modelo";
    string lblMenu2 = "Ocorrência";

    if (pais.Equals("Brazil"))
    {
        lblMenu1 = "SubCategoria";
    }
    else
    {
        if (idioma.Equals("en-US"))
        {
         
            lblMenu1 = "Model";
            lblMenu2 = "Ocurrencia";
        }
        else if (idioma.Equals("es-ES"))
        {
            
            lblMenu1 = "Model";
            lblMenu2 = "Ocurrencia";
        }
    }

    string tipoMenu1 = "Categoria";
    string tipoMenu2 = "SubCategoria";
    if (tipoArvore.Equals("Arvore Solution Center"))
    {
        tipoMenu1 = "Produto";
        tipoMenu2 = "Modelo";
    }


    string tipoMenu3 = "Ocorrência";
    string tipoMenu4 = "Importação de Dados";
    string tipoMenu5 = "Relatórios de uso do Sistema";

    string urlVolta = "";
    //try
    // {
    //  urlVolta = Session["urlVolta"].ToString();
    //}
    //  catch (Exception ex)
    // {

    cookie = Request.Cookies["urlVolta"];
    if (cookie != null)
    {
        urlVolta = cookie.Value.ToString();
        urlVolta = urlVolta.Replace("%3A", ":");
    }

    //  }

    string tipoMenu0 = "Linha";
     tipoMenu1 = "Categoria";
     tipoMenu2 = "SubCategoria";
     string lblTitulo = "Importação de Dados";

    if (idioma.Equals("en-US"))
    {
        tipoMenu0 = "Line";
        lblTitulo = "Data Import";
        tipoMenu3 = "Ocurrencia";
        tipoMenu4 = "Data Import";
        tipoMenu5 = "System usage reports";

        tipoMenu1 = "Category";
        tipoMenu2 = "Subcategory";
    }
    else if (idioma.Equals("es-ES"))
    {
        tipoMenu0 = "Línea";
        lblTitulo = "Importación de datos";

        tipoMenu3 = "Ocurrencia";
        tipoMenu4 = "Importación de datos";
        tipoMenu5 = "Informes de uso del sistema";

        tipoMenu1 = "Categoría";
        tipoMenu2 = "SubCategoría";
    }

    if (tipoArvore.Equals("Arvore Solution Center"))
    {
        tipoMenu1 = "Produto";
        tipoMenu2 = "Modelo";

        if (idioma.Equals("en-US"))
        {
            tipoMenu1 = "Product";
            tipoMenu2 = "Model";
        }
        else if (idioma.Equals("es-ES"))
        {
            tipoMenu1 = "Producto";
            tipoMenu2 = "Modelo";
        }

    }

   string idUser = Request.Params.Get("idUser");
   string user = Request.Params.Get("usuario");
    if (idUser.IndexOf(',') != -1)
    {
        idUser = idUser.Split(',')[0];
    }
    if (user.IndexOf(',') != -1)
    {
        user = user.Split(',')[0];
    }
    
    
    urlVolta = "index.aspx?idUser=" + idUser + "&username=" + user;

%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1">
   
    <script src="../includes/arvore/js/jquery-1.10.2.js"  type="text/javascript"></script>
    <script src="../includes/arvore/js/jquery-ui-1.10.4.custom.js"  type="text/javascript"></script>
    <script src="../includes/arvore/js/jquery.alerts.js"  type="text/javascript"></script>
    <script src="../includes/arvore/js/importacao.js" type="text/javascript"></script>
    <script src="../includes/arvore/js/bootstrap-table.js"  type="text/javascript"></script>
    <script src="../includes/arvore/js/bootstrap-tagsinput.js"  type="text/javascript"></script>
   

     <% if (idioma.Equals("en-US")){ %>
     <script src="../includes/arvore/js/fileinput_ing.js"  type="text/javascript"></script>
            <script src="../includes/arvore/js/fileinput_locale_en-US.js"  type="text/javascript"></script>
     <% }else if (idioma.Equals("es-ES")){ %>
     <script src="../includes/arvore/js/fileinput_esp.js"  type="text/javascript"></script>
           <script src="../includes/arvore/js/fileinput_locale_es-ES.js"  type="text/javascript"></script>
     <% }else{ %>
     <script src="../includes/arvore/js/fileinput.js"  type="text/javascript"></script>
              <script src="../includes/arvore/js/fileinput_locale_pt-BR.js"  type="text/javascript"></script>
      <% } %>

    
    <script src="../includes/arvore/js/canvas-to-blob.min.js" type="text/javascript"></script>
     <script src="../includes/arvore/js/ajaxupload.js" type="text/javascript"></script>

    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/jquery-ui-1.10.4.custom.css" /> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/jquery.alerts.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/importacao.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap-table.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap-tagsinput.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/estilo.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap-fileinput.css"/> 

   
   
</head>


<body style="overflow: hidden;">
    <div class="container-fluid">
     <%--<table border=0 style="width: 100%"><Tr>
          <Td  align="left" style="width: 5%">  <img src="../includes/arvore/imagens/logo.png" class="img-responsive"/></img></Td>
          
              <Td  align="center" style="width: 45%" align="center"><span id="labelCliente">&nbsp;</span></Td>
          
       <td align="right"><span id="labelUsuario"><%=tipoArvore%></span></td>   <td align="right"><span id="labelUsuario">User:</span></td><td><span id="conteudoUsuario">&nbsp;<%=nome %></span></td>  
   
         
         
   
          
          
          
      </Tr></table>--%>
    
    
    
     <br />
       <% if(tipoAcesso.Equals("usuario")){  %>
     <ul>
           
            <li><a href="ocorrenciaUsuario.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu"><%=tipoMenu3 %></a></li>
        </ul>    

         <%}else{ %>
              <% if(pais.Equals("Brazil")){  %>
                         <ul>
                                    <li><a class="liMenu" href="<%=urlVolta%>"  ><img src="../includes/arvore/imagens/home.png" class="img-responsive" style="cursor: pointer;" /></a></li>
          
                          <li><a class="liMenu" href="linha.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>"  ><%=tipoMenu0 %></a></li>
                            <li><a href="produto.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu"><%=tipoMenu1 %></a></li>
                            <li><a href="modelo.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu"><%=tipoMenu2 %></a></li>
                            <li><a href="ocorrencia.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu"><%=tipoMenu3 %></a></li>
                            <li><a href="importacao.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu"><%=tipoMenu4 %></a></li>
                            <li><a href="relatorios.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu"><%=tipoMenu5 %></a></li>
                        </ul>    

              
              <%}else{ %>
                   <% if(tipoArvore.Equals("Arvore Solution Center")){ %>

                          <ul>
                                     <li><a class="liMenu" href="<%=urlVolta%>"  ><img src="../includes/arvore/imagens/home.png" class="img-responsive" style="cursor: pointer;" /></a></li>
          
                            <li><a href="modelo.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu"><%=lblMenu1 %></a></li>
                            <li><a href="ocorrencia.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu"><%=lblMenu2 %></a></li>
                           
                        </ul>    

                   <%}else{ %>

                         <ul>
                                    <li><a class="liMenu" href="<%=urlVolta%>"  ><img src="../includes/arvore/imagens/home.png" class="img-responsive" style="cursor: pointer;" /></a></li>
                                    <li><a class="liMenu" href="linha.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>"  >Linha</a></li>
                            <li><a href="produto.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu"><%=tipoMenu1 %></a></li>
                            <li><a href="modelo.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu"><%=tipoMenu2 %></a></li>
                            <li><a href="ocorrencia.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu">Ocorr&ecirc;ncias</a></li>
                            <li><a href="importacao.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu">Importa&ccedil;&atilde;o de Dados</a></li>
                            <li><a href="relatorios.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu">Relat&oacute;rios de uso do Sistema</a></li>
                           
                        </ul>    

                   <%}%>

              <%}%>

  
         <%} %>
  


    <div class="modal-body">
  
  <fieldset class="scheduler-border">
    <legend class="scheduler-border"><%=lblTitulo %></legend>

    <table style="width: 100%"><tr><Td style="width:20%">&nbsp;</Td><td style="align-content:center">
      <div id="cadastro" style="width:650px; position: absolute; top:0px;" >
        <br /><br /> <br />
         <form id="form1" runat="server">
     
                <div class="form-group">
                    <input id="uploadFile" type="file" class="file" data-upload-url="#">
                </div>

          </form>
                

      
      </div> 
    </td></tr></table>
    
     
  </fieldset>

 </div>    
        </div>
</body>

    <script>

        $("#uploadFile").fileinput({
            uploadExtraData: { kvId: '10' }//,
            //uploadUrl: 'AjaxFileHandler.ashx'
        });

        function uploadArquivo() {

            var fileUpload = $("#uploadFile").get(0);
            var files = fileUpload.files;
            var test = new FormData();
            for (var i = 0; i < files.length; i++) {
                test.append(files[i].name, files[i]);
               
            }
           
            $.ajax({
                url: "UploadHandler.ashx",
                type: "POST",
                contentType: false,
                processData: false,
                data: test,
                // dataType: "json",
                success: function (result) {
                    if (result != '') {
                        alert(result);
                    }
                    
                },
                error: function (err) {
                    if (err.statusText != '') {
                        alert(err.statusText);
                    }
                }
            });


            
        }

    </script>

</html>

