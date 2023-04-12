<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="principal.aspx.cs" Inherits="EluxcityWeb.pages.principal" %>
<%
    string tipoAcesso = "administrador";
    string nome = "";
    string pais = "";
    string idioma = "";
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

    nome = Request.Params.Get("nome");
    if(nome == null)
    {
        nome = "";
    }else
    {
        if(nome.IndexOf(',') != -1)
        {
            nome = nome.Split(',')[0];
        }
    }

    cookie = Request.Cookies["pais"];
    if (cookie != null)
    {
        pais = cookie.Value.ToString();
        pais = pais.Replace("%20", " ");
    }

    
    pais = Request.Params.Get("pais");
    if(pais == null)
    {
        pais = "Brazil";
    }

    string tipoArvore = Request.Params.Get("tipoArvore");
    if(tipoArvore != null)
    {
        tipoArvore = tipoArvore.Replace("%20", " ");
    }

    HttpCookie aCookie = new HttpCookie("tipoArvore");
    aCookie.Value = tipoArvore;
    //aCookie.Expires = DateTime.Now.AddDays(-1D);
    Response.Cookies.Add(aCookie);

    tipoArvore = Request.Params.Get("tipoArvore");
    if(tipoArvore != null)
    {
        if (tipoArvore.IndexOf(',') != -1)
        {
            tipoArvore = tipoArvore.Split(',')[0];
        }

        Session["tipoArvore"] = tipoArvore;
    }else
    {
        tipoArvore = "Arvore Produtos";
    }


    cookie = Request.Cookies["idioma"];
    if (cookie != null)
    {
        idioma = cookie.Value.ToString();
        idioma = idioma.Replace("%20", " ");
    }else
    {
        idioma = "pt-BR";
    }

    idioma = Request.Params.Get("idioma");
    if (idioma == null)
    {
        idioma = "pt-BR";
    }else {
        if (idioma.IndexOf(',') != -1)
        {
            idioma = idioma.Split(',')[0];
        }
    }

    string tipoMenu3 = "Ocorrência";
    string tipoMenu4 = "Importação de Dados";
    string tipoMenu5 = "Relatórios de uso do Sistema";

    string lblUsuario = "Usuário";
    string lblMenu1 = "Modelo";
    string lblMenu2 = "Ocorrência";

    string tipoMenu0 = "Linha";
    string tipoMenu1 = "Categoria";
    string tipoMenu2 = "SubCategoria";

    if (idioma.Equals("en-US"))
    {
        lblUsuario = "User";
        tipoMenu0 = "Line";
        lblMenu1 = "Model";
        lblMenu2 = "Ocurrencia";

        tipoMenu3 = "Ocurrencia";
        tipoMenu4 = "Data Import";
        tipoMenu5 = "System usage reports";

        tipoMenu1 = "Category";
        tipoMenu2 = "Subcategory";
    }
    else if (idioma.Equals("es-ES"))
    {
        lblUsuario = "Usuario";
        tipoMenu0 = "Línea";
        lblMenu1 = "Modelo";
        lblMenu2 = "Ocurrencia";

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

    string idUser = "";
    cookie = Request.Cookies["idUser"];
    if (cookie != null)
    {
        idUser = cookie.Value.ToString();
        idUser = idUser.Replace("%3A", ":");
    }
    string user = "";
    cookie = Request.Cookies["usuario"];
    if (cookie != null)
    {
        user = cookie.Value.ToString();
        user = user.Replace("%3A", ":");
    }

    idUser = Request.Params.Get("idUser");
    user = Request.Params.Get("usuario");
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
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
  
     <script src="../includes/arvore/js/jquery-1.10.2.js"  type="text/javascript"></script>
    <script src="../includes/arvore/js/jquery-ui-1.10.4.custom.js"  type="text/javascript"></script>
    <script src="../includes/arvore/js/jquery.alerts.js"  type="text/javascript"></script>
    <script src="../includes/arvore/js/bootstrap.js"  type="text/javascript"></script>
    <script src="../includes/arvore/js/bootstrap-table.js"  type="text/javascript"></script>
    <script src="../includes/arvore/js/bootstrap-tagsinput.js"  type="text/javascript"></script>
  

    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/jquery-ui-1.10.4.custom.css" /> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/jquery.alerts.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap-table.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap-tagsinput.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/estilo.css"/> 

   

   
</head>
     <script>
         var tipoAcesso = "<%=tipoAcesso%>";
         function carregaPrincipal() {

             if (tipoAcesso == 'usuario') {
                 document.location = "ocorrenciaUsuario.aspx?idUser=<%=idUser%>&usuario=<%=user%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&idioma=<%=idioma%>&pais=<%=pais%>&idUser=<%=idUser%>";
             }

         }


     </script>
<body onload="carregaPrincipal()">
    <div class="container-fluid">
     <%--<table border=0 style="width: 100%"><Tr>
          <Td  align="left" style="width: 5%">  <img src="../includes/arvore/imagens/logo.png" class="img-responsive"/></img></Td>
          
            <Td  align="center" style="width: 45%" align="center"><span id="labelCliente">&nbsp;</span></Td>
          
       <td align="right"><span id="labelUsuario"><%=tipoArvore%></span></td>   <td align="right"><span id="labelUsuario">User:</span></td><td><span id="conteudoUsuario">&nbsp;<%=nome %></span></td>  
      
         
         
  
          
          
          
      </Tr></table>--%>
    
    
    
     <br />
         <% if(tipoAcesso.Equals("usuario")){  %>
     <ul>
                 <li><a class="liMenu" href="<%=urlVolta%>"  ><img src="../includes/arvore/imagens/home.png" class="img-responsive" style="cursor: pointer;" /></a></li>
                        
            <li><a href="ocorrenciaUsuario.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu"><%=lblMenu2%></a></li>
        </ul>    

         <%}else{ %>
              <% if(pais.Contains("Brazil")){  %>
                         <ul>
                              <li><a class="liMenu" href="<%=urlVolta%>"  ><img src="../includes/arvore/imagens/home.png" class="img-responsive" style="cursor: pointer;" /></a></li>
                            <li><a class="liMenu" href="linha.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>&tipoArvore=<%=tipoArvore%>&idioma=<%=idioma%>"  ><%=tipoMenu0 %></a></li>
                            <li><a href="produto.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>&tipoArvore=<%=tipoArvore%>&idioma=<%=idioma%>" class="liMenu"><%=tipoMenu1 %></a></li>
                            <li><a href="modelo.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>&tipoArvore=<%=tipoArvore%>&idioma=<%=idioma%>&pais=<%=pais%>" class="liMenu"><%=tipoMenu2 %></a></li>
                            <li><a href="ocorrencia.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>&tipoArvore=<%=tipoArvore%>&idioma=<%=idioma%>&nome=<%=nome%>&pais=<%=pais%>" class="liMenu"><%=tipoMenu3 %></a></li>
                            <li><a href="importacao.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>&tipoArvore=<%=tipoArvore%>&idioma=<%=idioma%>" class="liMenu"><%=tipoMenu4 %></a></li>
                            <li><a href="relatorios.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>&tipoArvore=<%=tipoArvore%>&idioma=<%=idioma%>" class="liMenu"><%=tipoMenu5 %></a></li>
                        </ul>    

              
              <%}else{ %>
                   <% if(tipoArvore.Equals("Arvore Solution Center")){ %>

                          <ul>
                                    <li><a class="liMenu" href="<%=urlVolta%>"  ><img src="../includes/arvore/imagens/home.png" class="img-responsive" style="cursor: pointer;" /></a></li>
                        
                            <li><a href="modelo.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>&tipoArvore=<%=tipoArvore%>&idioma=<%=idioma%>&pais=<%=pais%>" class="liMenu"><%=lblMenu1%></a></li>
                            <li><a href="ocorrencia.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>&tipoArvore=<%=tipoArvore%>&idioma=<%=idioma%>&pais=<%=pais%>" class="liMenu"><%=lblMenu2%></a></li>
                           
                        </ul>    

                   <%}else{ %>

                         <ul>
                                   <li><a class="liMenu" href="<%=urlVolta%>"  ><img src="../includes/arvore/imagens/home.png" class="img-responsive" style="cursor: pointer;" /></a></li>
                        
                            <li><a href="ocorrencia.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>&tipoArvore=<%=tipoArvore%>&idioma=<%=idioma%>" class="liMenu"><%=lblMenu2%></a></li>
                           
                        </ul>    

                   <%}%>

              <%}%>

  
         <%} %>
    
</div>
</body>
</html>
