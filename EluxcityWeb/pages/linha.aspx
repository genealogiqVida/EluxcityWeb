<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="linha.aspx.cs" Inherits="EluxcityWeb.pages.linha" %>

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

   // tipoArvore = Session["tipoArvore"].ToString();
    tipoArvore = tipoArvore.Replace("%20", " ");

    username = Request.Params.Get("username");
    if (username.IndexOf(',') != -1)
    {
        username = username.Split(',')[0];
    }

    tipoArvore = Request.Params.Get("tipoArvore");
    if(tipoArvore != null)
    {
        if (tipoArvore.IndexOf(',') != -1)
        {
            tipoArvore = tipoArvore.Split(',')[0];
        }

        tipoArvore = tipoArvore.Replace("%20", " ");

        Session["tipoArvore"] = tipoArvore;
    }else
    {
        tipoArvore = "Arvore Produtos";
    }

    idioma = Request.Params.Get("idioma");
    if(idioma != null)
    {
        idioma = idioma.Replace("%20", " ");
    }else
    {
        idioma = "pt-BR";
    }

    string lblTitulo = "Listagem das Linhas";
    string lblCadastro = "Cadastro de Linha";
    string lblCancelar = "Cancelar";
    string lblSalvar = "Salvar";
    string lblMenu1 = "Modelo";
    string lblMenu2 = "Ocorrência";
    string lblEditar = "Editar";
    string lblPais = "País:&nbsp;&nbsp;";
    string lblRemover = "Remover";
    

    if (pais.Equals("Brazil"))
    {
        lblMenu1 = "SubCategoria";
    }
   
        if (idioma.Equals("en-US"))
        {
         
            lblMenu1 = "Model";
            lblTitulo = "List of Line";
            lblCancelar = "Cancel";
            lblCadastro = "Line Registration";
            lblSalvar = "Save";
            lblMenu2 = "Ocurrencia";
            lblPais = "Country:&nbsp;&nbsp;";
             lblEditar = "Edit";
             lblRemover = "Remove";
        }
        else if (idioma.Equals("es-ES"))
        {

            lblCancelar = "Cancel";
            lblSalvar = "Guardar";
            lblCadastro = "Registro del Linea";
            lblTitulo = "Lista de Línea";
            lblMenu1 = "Model";
            lblEditar = "Editar";
            lblRemover = "Eliminar";
            lblPais = "País:&nbsp;&nbsp;";
            lblMenu2 = "Ocurrencia";
        }
    

    /*string tipoMenu1 = "Categoria";
    string tipoMenu2 = "SubCategoria";
    if (tipoArvore.Equals("Arvore Solution Center"))
    {
        tipoMenu1 = "Produto";
        tipoMenu2 = "Modelo";
    }*/



    string tipoMenu3 = "Ocorrência";
    string tipoMenu4 = "Importação de Dados";
    string tipoMenu5 = "Relatórios de uso do Sistema";

  

    string tipoMenu0 = "Linha";
    string tipoMenu1 = "Categoria";
    string tipoMenu2 = "SubCategoria";

    if (idioma.Equals("en-US"))
    {
       tipoMenu0 = "Line";
        
        tipoMenu3 = "Ocurrencia";
        tipoMenu4 = "Data Import";
        tipoMenu5 = "System usage reports";

        tipoMenu1 = "Category";
        tipoMenu2 = "Subcategory";
    }
    else if (idioma.Equals("es-ES"))
    {
        tipoMenu0 = "Línea";
      

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
    <script src="../includes/arvore/js/bootstrap.js"  type="text/javascript"></script>
    <% if (idioma.Equals("en-US")){ %>
              <script src="../includes/arvore/js/bootstrap-table-ing.js" type="text/javascript"></script>
    <script src="../includes/arvore/js/bootstrap-multiselect-ing.js"></script>
     <% }else if (idioma.Equals("es-ES")){ %>
                 <script src="../includes/arvore/js/bootstrap-table-esp.js" type="text/javascript"></script>
    <script src="../includes/arvore/js/bootstrap-multiselect-esp.js"></script>
     <% }else{ %>
                <script src="../includes/arvore/js/bootstrap-table.js" type="text/javascript"></script>
    <script src="../includes/arvore/js/bootstrap-multiselect.js"></script>
      <% } %>
    <script src="../includes/arvore/js/bootstrap-tagsinput.js"  type="text/javascript"></script>

        <link rel="stylesheet" type="text/css" href="../includes/arvore/css/jquery-ui-1.10.4.custom.css" /> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/jquery.alerts.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap-table.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap-tagsinput.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/estilo.css"/> 

</head>



    <script>
        var codLinha = "0";
        var codPais = "0";
        var $j = jQuery.noConflict();
        $j('document').ready(function () {



           
            carregaDadosTabela();


            

        });


        function retornaPais() {
            codPais = $j("#pais option:selected").val();
            if (codPais == '') codPais = "0";
           
        }

        function carregaDadosTabela() {

            telaAtual = "linha";

            var idioma = "<%=idioma.ToString()%>";
            var tipoArvore = "<%=tipoArvore.ToString()%>";
            var dataStr = (idioma.indexOf("'") != -1 && tipoArvore.indexOf("'") != -1) ? "{limit: " + limit + ", offset: " + paginaAtual + " ,tipoArvore:" + tipoArvore + ", idioma:" + idioma + ", codPais:'<%=pais %>'}" : "{limit: " + limit + ", offset: " + paginaAtual + " ,tipoArvore:'" + tipoArvore + "', idioma:'" + idioma + "', codPais:'<%=pais %>'}"

            $j.ajax({
                type: "POST",
                url: "linha.aspx/carregaLinhas",
                data: dataStr,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {
                    $j('#table-linha').bootstrapTable('destroy');

                    var dados = jasonResult.d;
                    var total = dados.substring(0, dados.indexOf(","));
                    dados = dados.replace(total + ",", '');

                    var obj = eval(dados);

                    $j('#table-linha').bootstrapTable({
                        data: obj,
                        cache: false,
                        height: 400,
                        pagination: true,
                        pageSize: limit,
                        totalRows: total,
                        pageNumber: paginaAtual,
                        search: true,
                        showColumns: false,
                        showRefresh: false,
                        sidePagination: 'server',
                        minimumCountColumns: 2,
                        clickToSelect: true,
                        columns: [{
                            field: 'cod_linha',
                            width: 1
                        }, {
                            field: 'nome_por',
                            title: 'Linha',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'nome_esp',
                            title: 'Línea',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true

                        }, {
                           
                            field: 'nome_ing',
                            title: 'Line',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true

                        },  {
                            field: 'alterar',
                            title: '<%=lblEditar %>',
                            width: 30,
                            align: 'center',
                            valign: 'middle'
                        }, {
                            field: 'excluir',
                            title: '<%=lblRemover %>',
                            width: 30,
                            align: 'center',
                            valign: 'middle'
                        }]
                    });
                    $j('#table-linha').bootstrapTable('hideColumn', 'cod_linha');

                }
            });
        }

        function retornaLinha() {
            codLinha = $j("#linha option:selected").val();
        }

        

        function cancelar() {
            location.reload();
        }

        function salvarDados() {

            var mensagem = "";
            var title = "";
           <% if (idioma.Equals("es-ES")){ %>
            mensagem = "Debe introducir el nombre de los 3 idiomas";
            title = "Decision tree";
            <% }else if (idioma.Equals("en-US")){ %>
            mensagem = "You must enter the name of the 3 languages";
            title = "Árbol de decisión";
            <% }else{ %>
            mensagem = "É necessário informar o nome nos 3 idiomas!";
            title = "Arvore de Decisão";
            <% } %>

            if (document.getElementById('nomePor').value == '' || document.getElementById('nomeIng').value == ''
                 || document.getElementById('nomeEsp').value == '') {
                jAlert(mensagem, title);
            }
            
            else {

                var nomePor = document.getElementById('nomePor').value.trim();
                var nomeEsp = document.getElementById('nomeEsp').value.trim();
                var nomeIng = document.getElementById('nomeIng').value.trim();
                var codigo = document.getElementById('codigo').value;




                $j.ajax({
                    type: "POST",
                    url: "linha.aspx/salvarDados",
                    data: "{nomePor:'" + nomePor + "',nomeEsp:'" + nomeEsp + "',nomeIng:'" + nomeIng + "',codigo:'" + codigo + "', codPais:'" + codPais + "', tipoArvore:'<%=tipoArvore %>'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (jasonResult) {

                        if (jasonResult.d == '0') {
                               <% if (idioma.Equals("en-US")){ %>
                            jAlert('Successfully recorded record', 'Decision tree', function () {
                                location.reload();
                            });
                            <% }else if (idioma.Equals("es-ES")){ %>
                            jAlert('Registro grabada con éxito.', 'Árbol de decisión', function () {
                                location.reload();
                            });
                            <% }else{ %>
                            jAlert('Registro gravado com sucesso.', 'Arvore de Decisão', function () {
                                location.reload();
                            });
                            <% } %>



                        } else if (jasonResult.d == '1') {
                                                                                   
                              <% if (idioma.Equals("en-US")){ %>
                            jAlert('Already inserted record!', 'Decision tree');
                            <% }else if (idioma.Equals("es-ES")){ %>
                            jAlert('Registro ya insertada!', 'Árbol de decisión');
                            <% }else{ %>
                            jAlert('Registro já inserido!', 'Arvore de Decisão');
                                <% } %>
                        } else {
                           <% if (idioma.Equals("en-US")){ %>
                            jAlert(jasonResult.d, 'Decision tree');
                            <% }else if (idioma.Equals("es-ES")){ %>
                            jAlert(jasonResult.d, 'Árbol de decisión');
                            <% }else{ %>
                            jAlert(jasonResult.d, 'Arvore de Decisão');
                            <% } %>
                        }


                    }
                });
            }


        }

        function excluirRegistro(codigo) {

            var mensagem = "";
            var title = "";
            <% if (idioma.Equals("en-US")){ %>
            mensagem = "You really want to delete the record ?";
            title = "Decision tree";
            <% }else if (idioma.Equals("es-ES")){ %>
            mensagem = "Usted realmente desea eliminar el registro ?";
            title = "Árbol de decisión";
            <% }else{ %>
            mensagem = "Deseja realmente excluir o registro ?";
            title = "Arvore de Decisão";
            <% } %>

            jConfirm(mensagem, title, function (r) {

                if (r == true) {

                    $j.ajax({
                        type: "POST",
                        url: "linha.aspx/excluirDados",
                        data: "{codigo:'" + codigo + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (jasonResult) {

                            if (jasonResult.d == '0') {
                                <% if (idioma.Equals("en-US")){ %>
                                jAlert('Successfully deleted record.', 'Decision tree', function () {

                                    location.reload();
                                });
                                <% }else if (idioma.Equals("es-ES")){ %>
                                jAlert('Se ha eliminado el registro.', 'Árbol de decisión', function () {

                                    location.reload();
                                });
                                <% }else{ %>
                                jAlert('Registro excluído com sucesso.', 'Arvore de Decisão', function () {

                                    location.reload();
                                });
                                <% } %>



                            } else {
                                <% if (idioma.Equals("en-US")){ %>
                                jAlert("Could not delete the record<br>There is question for this Ocurrencia.", 'Decision tree');
                                <% }else if (idioma.Equals("es-ES")){ %>
                                jAlert("No se pudo eliminar el registro<Br>No es cuestión para esta ocurrencia.", 'Árbol de decisión');
                                <% }else{ %>
                                jAlert('Não foi possível excluir o registro!<br>Existe(m) pergunta(s) para essa ocorrência.', 'Arvore de Decisão');
                                <% } %>
                            }


                        }
                    });
                }
            });
        }

        function alterarRegistro(codigo) {

            document.getElementById('codigo').value = codigo;

            $j.ajax({
                type: "POST",
                url: "linha.aspx/getLinha",
                data: "{codigo:'" + codigo + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {
                    var aDados = jasonResult.d.split(";");
                    document.getElementById('nomePor').value = aDados[0];
                    document.getElementById('nomeIng').value = aDados[1];
                    document.getElementById('nomeEsp').value = aDados[2];

                    codPais = aDados[3];




                    if (codPais != '0') {
                        $j("#pais").val(codPais);

                    }
                   

                }
            });


        }


    </script>
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
            <li><a class="liMenu" href="<%=urlVolta%>"  ><img src="../includes/arvore/imagens/home.png" class="img-responsive" style="cursor: pointer;" /></a></li>
            <li><a href="ocorrenciaUsuario.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu">Ocorr&ecirc;ncias</a></li>
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
                            <li><a class="liMenu" href="linha.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>&tipoArvore=<%=tipoArvore%>&idioma=<%=idioma%>"  ><%=tipoMenu0 %></a></li>
                            <li><a href="produto.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>&tipoArvore=<%=tipoArvore%>&idioma=<%=idioma%>" class="liMenu"><%=tipoMenu1 %></a></li>
                            <li><a href="modelo.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>&tipoArvore=<%=tipoArvore%>&idioma=<%=idioma%>" class="liMenu"><%=tipoMenu2 %></a></li>
                            <li><a href="ocorrencia.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>&tipoArvore=<%=tipoArvore%>&idioma=<%=idioma%>" class="liMenu"><%=tipoMenu3 %></a></li>
                            <li><a href="importacao.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>&tipoArvore=<%=tipoArvore%>&idioma=<%=idioma%>" class="liMenu"><%=tipoMenu4 %></a></li>
                            <li><a href="relatorios.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>&tipoArvore=<%=tipoArvore%>&idioma=<%=idioma%>" class="liMenu"><%=tipoMenu5 %></a></li>
                           
                        </ul>    

                   <%}%>

              <%}%>

  
         <%} %>
  
      


    <div class="modal-body">
  
  <fieldset class="scheduler-border">
    <legend class="scheduler-border"><%=lblCadastro %></legend>

      <div id="cadastro" style="position: absolute; top:0px;" >
        <br /><br /> <br />
         <input type="hidden" name="codigo" id="codigo" value="0" />
        
          <%if (pais.Equals("Brazil")){ %>
          
           <span class="reqfield" tabindex="0">
                <img src="../includes/arvore/imagens/required.gif" alt="Asterisco"/> Nome da linha | Line's name | Línea nombre
         </span><br /><br />
        <div class="form-group">
            <label for="nomePor" class="control-label">Linha:</label>
            <input type="text" class="form-control" id="nomePor" style="width: 300px !important" placeholder="Informe o nome da linha"/>
        </div>
         <div class="form-group">
            <label for="nomeEsp" class="control-label">Línea:</label>
            <input type="text" class="form-control" id="nomeEsp" style="width: 300px !important" placeholder="Introduzca el nombre de la línea"/>
       </div>
           <div class="form-group">
            <label for="nomeIng" class="control-label">Line:&nbsp;&nbsp;</label>
            <input type="text" class="form-control" id="nomeIng" style="width: 300px !important" placeholder="Enter the line name"/>
         </div>


          
     

        <%}else{ 

           if (idioma.Equals("en-US")){%>

           <span class="reqfield" tabindex="0">
                <img src="../includes/arvore/imagens/required.gif" alt="Asterisco"/> Line's name
         </span><br /><br />
        <input type="hidden" class="form-control" id="nomePor"/>
        <div class="form-group">
            <label for="nomeIng" class="control-label">Line:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
            <input type="text" class="form-control" id="nomeIng" style="width: 300px !important" placeholder="Enter the line name"/>
         </div>
        <input type="hidden" class="form-control" id="nomeEsp" />
               
         <% }
           else { %>

           <span class="reqfield" tabindex="0">
                <img src="../includes/arvore/imagens/required.gif" alt="Asterisco"/> Línea nombre
         </span><br /><br />
        <input type="hidden" class="form-control" id="nomePor"/>
         <input type="hidden" class="form-control" id="nomeIng"/>
       <div class="form-group">
            <label for="nomeEsp" class="control-label">Línea:&nbsp;&nbsp;</label>
            <input type="text" class="form-control" id="nomeEsp" style="width: 300px !important" placeholder="Introduzca el nombre de la línea"/>
       </div>

          <%}
        } %>


         
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal" onclick="cancelar();"><%=lblCancelar %></button>
        <button type="button" class="btn btn-primary" onclick="salvarDados();"><%=lblSalvar %></button>
      </div>
     
   </div> 
    <div class="table-responsive">
     <div id="listagem" style="margin-left:35%;">
          <div class="panel panel-primary">
              <div class="panel-heading"><%=lblTitulo %></div>
              <table class="table" id="table-linha"></table>


           </div>
         </div>

     </div>   
         
  </fieldset>

 </div>    
</div>
</body>
</html>
