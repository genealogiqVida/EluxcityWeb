<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="produto.aspx.cs" Inherits="EluxcityWeb.pages.produto"%>
<%
    string tipoAcesso = "administrador";
    string nome = "";
    string pais = "";
    string idioma = "";
    string lblPais = "País:&nbsp;&nbsp;";
    string tipoArvore = "";
    string username = "";
    HttpCookie cookie = Request.Cookies["tipoAcesso"];
    if (cookie != null)
        tipoAcesso = cookie.Value.ToString();

    cookie = Request.Cookies["nome"];
    if (cookie != null)
    {
        nome = cookie.Value.ToString();
        nome = nome.Replace("%20", " ");
    }

    tipoAcesso = Request.Params.Get("tipoAcesso");
    if (tipoAcesso.IndexOf(',') != -1)
    {
        tipoAcesso = tipoAcesso.Split(',')[0];
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


    string lblMenu1 = "Modelo";
    string lblMenu2 = "Ocorrência";

    if (pais.Equals("Brazil"))
    {
        lblMenu1 = "SubCategoria";
    }
   
        if (idioma.Equals("en-US"))
        {

            lblPais = "Country:&nbsp;&nbsp;";
            lblMenu1 = "Model";
            lblMenu2 = "Ocurrencia";
        }
        else if (idioma.Equals("es-ES"))
        {

            lblMenu1 = "Model";
            lblMenu2 = "Ocurrencia";
            lblPais = "País:&nbsp;&nbsp;";
        }
    
   // tipoArvore = Session["tipoArvore"].ToString();
    tipoArvore = tipoArvore.Replace("%20", " ");
   // string tipoMenu1 = "Categoria";
   // string tipoMenu2 = "SubCategoria";

    string lblCampo1 = "Informe o nome da Categoria";
    string lblCampo2 = "Enter the category name";
    string lblCampo3 = "Introduzca el nombre del categoria";
    string informacao = "Nome da Categoria | Category name | Nombre del Categoría";
    string lblTitulo = "Cadastro de Categoria";
    string lblLista = "Listagem das Categoria";
    string lblLabel1 = "Linha";
    string lblCancelar = "Cancelar";
    string lblSalvar = "Salvar";
    string lblEditar = "Editar";
    string lblRemover = "Remover";
    
   /* if (pais.Equals("Brazil"))
    {
        if (tipoArvore.Equals("Arvore Solution Center"))
        {
          // string tipoMenu1 = "Produto";
          // string tipoMenu2 = "Modelo";
            lblTitulo = "Cadastro de Produto";
            lblLista = "Listagem dos Produtos";

            lblCampo1 = "Informe o nome do produto";
            lblCampo2 = "Enter the product name";
            lblCampo3 = "Introduzca el nombre del producto";

            informacao = "Nome do Produto | Product name | Nombre del Producto";
        }
    }*/

    lblTitulo = "Cadastro de Categoria";
    lblLista = "Listagem das Categorias";

    lblCampo1 = "Informe o nome do produto";
    lblCampo2 = "Enter the product name";
    lblCampo3 = "Introduzca el nombre del producto";

     if (pais.Equals("Brazil"))
        informacao = "Nome do Produto | Product name | Nombre del Producto";
     else{
           informacao = "Nome do Produto";
     }


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
        lblEditar = "Edit";
        lblRemover = "Remove";

         lblCancelar = "Cancel";
         lblSalvar = "Save";

        lblTitulo = "Category Registration";
        lblLista = "List of Category";

        lblCampo1 = "Informe o nome do produto";
        lblCampo2 = "Enter the product name";
        lblCampo3 = "Introduzca el nombre del producto";

        if (pais.Equals("Brazil"))
        informacao = "Nome do Produto | Product name | Nombre del Producto";
       else{
           informacao = "Product name";
       }
        
    }
    else if (idioma.Equals("es-ES"))
    {
        tipoMenu0 = "Línea";

        lblCancelar = "Cancel";
        lblSalvar = "Guardar";
        tipoMenu3 = "Ocurrencia";
        tipoMenu4 = "Importación de datos";
        tipoMenu5 = "Informes de uso del sistema";

        tipoMenu1 = "Categoría";
        tipoMenu2 = "SubCategoría";

        lblTitulo = "Registro del Categoría";
        lblLista = "Lista de Categoría";

        lblEditar = "Editar";
        lblRemover = "Eliminar";
        
          if (pais.Equals("Brazil"))
        informacao = "Nome do Produto | Product name | Nombre del Producto";
       else{
           informacao = "Nombre del Producto";
       }
    }
    
   // string informacao2 = "Nome do Produto | Product name | Nombre del Producto";
    string lblField1 = "Produto:&nbsp;&nbsp;&nbsp;";
    string lblField2 = "Producto:&nbsp;";
    string lblField3 = "Product:&nbsp;&nbsp;&nbsp;";

    if (tipoArvore.Equals("Arvore Solution Center"))
    {
        tipoMenu1 = "Produto";
        tipoMenu2 = "Modelo";
        lblTitulo = "Cadastro de Produto";
        lblLista = "Listagem dos Produtos";

        if (idioma.Equals("en-US"))
        {
            tipoMenu1 = "Product";
            tipoMenu2 = "Model";

           
            lblTitulo = "Product Registration";
            lblLista = "List of Product";
        }
        else if (idioma.Equals("es-ES"))
        {
            tipoMenu1 = "Producto";
            tipoMenu2 = "Modelo";
            lblTitulo = "Registro del Producto";
            lblLista = "Lista de Producto";
        }

    }else{
         if (pais.Equals("Brazil"))
            informacao = "Nome da Categoria | Category name | Nombre del Categoría";
         else{
             informacao = "Nome da Categoria";
             if (idioma.Equals("en-US")){
           informacao = "Category name";
             }else if (idioma.Equals("es-ES")){
                 informacao = "Nombre del Categoría";
             }
         }

         lblCampo1 = "Informe o nome da categoria";
         lblCampo2 = "Enter the category name";
         lblCampo3 = "Introduzca el nombre del categoría";

         lblField1 = "Categoria:&nbsp";
           lblField2 = "Categoría:&nbsp;";
           lblField3 = "Category:&nbsp;&nbsp;";
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

    <script>
        var codLinha = '0';
        var codPais = "0";
        var $j = jQuery.noConflict();


        $j('document').ready(function () {

            telaAtual = "produto";

            // esse trecho carrega os dados do combo linha
           /* $j.ajax({
                type: "POST",
                url: "produto.aspx/carregaComboLinha",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {

                    var dados = jasonResult.d;

                    document.getElementById('linha').innerHTML = dados;


                }
            });*/


            

            $j.ajax({
                type: "POST",
                url: "modelo.aspx/carregaComboLinha",
                data: "{idioma:'<%=idioma %>', tipoArvore:'<%=tipoArvore %>', codPais:'<%=pais %>'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {

                    var dados = jasonResult.d;
                    document.getElementById('linha').innerHTML = dados;


                }
            });

          

            carregaDadosTabela('0');


        });


        function retornaPais() {
            codPais = $j("#pais option:selected").val();

            if (codPais == '') {
                codPais = "0";
            }

        }

        function carregaDadosTabela(codigo) {

            $j.ajax({
                type: "POST",
                url: "produto.aspx/carregaProdutos",
                data: "{limit: " + limit + ", offset: " + paginaAtual + " ,tipoArvore:'<%=tipoArvore %>', idioma:'<%=idioma %>', codLinha:'" + codigo + "', codPais:'<%=pais %>'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {
                    $j('#table-produto').bootstrapTable('destroy');

                    var dados = jasonResult.d;
                    var total = dados.substring(0, dados.indexOf(","));
                    dados = dados.replace(total + ",", '');

                    var obj = eval(dados);

                    <% if (idioma.Equals("en-US")){ %>
                    $j('#table-produto').bootstrapTable({
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
                            field: 'cod_produto',
                            width: 1
                        }, {
                            field: 'nome_por',
                            title: '<%=lblField1.Replace(":", "")%>',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'nome_esp',
                            title: '<%=lblField2.Replace(":", "")%>',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true

                        }, {
                            field: 'nome_ing',
                            title: '<%=lblField3.Replace(":", "")%>',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'linha_ing',
                            title: '<%=tipoMenu0%>',
                            width: 90,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'alterar',
                            title: '<%=lblEditar%>',
                            width: 30,
                            align: 'center',
                            valign: 'middle'
                        }, {
                            field: 'excluir',
                            title: '<%=lblRemover%>',
                            width: 30,
                            align: 'center',
                            valign: 'middle'
                        }]
                    });
                    $j('#table-produto').bootstrapTable('hideColumn', 'cod_produto');

                    <% }else if (idioma.Equals("es-ES")){ %>
                    $j('#table-produto').bootstrapTable({
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
                            field: 'cod_produto',
                            width: 1
                        }, {
                            field: 'nome_por',
                            title: '<%=lblField1.Replace(":", "")%>',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'nome_esp',
                            title: '<%=lblField2.Replace(":", "")%>',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true

                        }, {
                            field: 'nome_ing',
                            title: '<%=lblField3.Replace(":", "")%>',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'linha_esp',
                            title: '<%=tipoMenu0%>',
                            width: 90,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'alterar',
                            title: '<%=lblEditar%>',
                            width: 30,
                            align: 'center',
                            valign: 'middle'
                        }, {
                            field: 'excluir',
                            title: '<%=lblRemover%>',
                            width: 30,
                            align: 'center',
                            valign: 'middle'
                        }]
                    });
                    $j('#table-produto').bootstrapTable('hideColumn', 'cod_produto');

                    <% }else { %>
                    $j('#table-produto').bootstrapTable({
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
                            field: 'cod_produto',
                            width: 1
                        }, {
                            field: 'nome_por',
                            title: '<%=lblField1.Replace(":", "")%>',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'nome_esp',
                            title: '<%=lblField2.Replace(":", "")%>',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true

                        }, {
                            field: 'nome_ing',
                            title: '<%=lblField3.Replace(":", "")%>',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'linha',
                            title: '<%=tipoMenu0%>',
                            width: 90,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'alterar',
                            title: '<%=lblEditar%>',
                            width: 30,
                            align: 'center',
                            valign: 'middle'
                        }, {
                            field: 'excluir',
                            title: '<%=lblRemover%>',
                            width: 30,
                            align: 'center',
                            valign: 'middle'
                        }]
                    });
                    $j('#table-produto').bootstrapTable('hideColumn', 'cod_produto');

                    <% } %>

                  

                }
            });
        }

        function retornaLinha() {
            codLinha = $j("#linha option:selected").val();
            paginaAtual = "1";

            //recarrega a listagem 
            carregaDadosTabela(codLinha);
           


        }

       
        function cancelar() {
            location.reload();
        }

        function salvarDados() {

            var mensagem = "";
            var title = "";
            var mensagem2 = "Informe a Linha!";
            <% if (idioma.Equals("es-ES")){ %>
            mensagem = "Debe introducir el nombre de los 3 idiomas";
            title = "Decision tree";
            mensagem2 = "Enter the Line";
            <% } else if (idioma.Equals("en-US"))  { %>
            mensagem = "You must enter the name of the 3 languages";
            title = "Árbol de decisión";
            mensagem2 = "Introduzca la Línea";
            <% }else{ %>
            mensagem = "É necessário informar o nome nos 3 idiomas!";
            title = "Arvore de Decisão";
            mensagem2 = "Informe a Linha!";
            <% } %>

            if (codLinha == null) {
                jAlert(mensagem2, title);
            }

            else if (document.getElementById('nomePor').value == '' || document.getElementById('nomeIng').value == ''
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
                    url: "produto.aspx/salvarDados",
                    data: "{nomePor:'" + nomePor + "',nomeEsp:'" + nomeEsp + "',nomeIng:'" + nomeIng + "',codLinha:'" + codLinha + "',codigo:'" + codigo + "', codPais:'<%=pais %>', tipoArvore:'<%=tipoArvore %>'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (jasonResult) {

                        //alert(jasonResult.d);

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
                        url: "produto.aspx/excluirDados",
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
                url: "produto.aspx/getProduto",
                data: "{codigo:'" + codigo + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {
                    var aDados = jasonResult.d.split(";");

                    
                    document.getElementById('nomePor').value = aDados[0];
                    document.getElementById('nomeIng').value = aDados[1];
                    document.getElementById('nomeEsp').value = aDados[2];
                    codLinha = aDados[4];
                    $j("#linha").val(codLinha);

                 


                }
            });


        }


    </script>
</head>
<body style="overflow: hidden;">
    <div class="container-fluid">
     <table border=0 style="width: 100%"><Tr>
          <Td  align="left" style="width: 5%">  <img src="../includes/arvore/imagens/logo.png" class="img-responsive"/></img></Td>
          
              <Td  align="center" style="width: 45%" align="center"><span id="labelCliente">&nbsp;</span></Td>
          
       <td align="right"><span id="labelUsuario"><%=tipoArvore%></span></td>   <td align="right"><span id="labelUsuario">User:</span></td><td><span id="conteudoUsuario">&nbsp;<%=nome %></span></td>  
     
         
    
          
      </Tr></table>
    
    
    
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
                            <li><a href="ocorrencia.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu"><%=lblMenu2 %></a></li>
                           
                        </ul>    

                   <%}%>

              <%}%>

  
         <%} %>

     
     

<div class="modal-body">
  
  <fieldset class="scheduler-border">
    <legend class="scheduler-border"><%=lblTitulo%></legend>

      <div id="cadastro" style="position: absolute; top:0px;" >
        <br /><br /> <br />
         <input type="hidden" name="codigo" id="codigo" value="0" />
         <span class="reqfield" tabindex="0">
                <img src="../includes/arvore/imagens/required.gif" alt="Asterisco"/> <%=informacao%>
         </span><br /><br />
                 <div class="form-group">
            <label for="linha" class="control-label"><%=tipoMenu0%>:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
            <select class="form-control" id="linha" style="width: 250px !important" onchange="retornaLinha()">
                
            </select>
       </div>
        <div class="form-group">   
            <label for="nomePor" class="control-label"><%=lblField1 %></label>
            <input type="text" class="form-control" id="nomePor" style="width: 270px !important" placeholder="<%=lblCampo1%>"/>
        </div>
       
       <div class="form-group">
            <label for="nomeEsp" class="control-label"><%=lblField2 %></label>
            <input type="text" class="form-control" id="nomeEsp" style="width: 270px !important" placeholder="<%=lblCampo3%>"/>
       </div>

          <div class="form-group">
            <label for="nomeIng" class="control-label"><%=lblField3 %></label>
            <input type="text" class="form-control" id="nomeIng" style="width: 270px !important" placeholder="<%=lblCampo2%>"/>
         </div>

       

      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal" onclick="cancelar();"><%=lblCancelar%></button>
        <button type="button" class="btn btn-primary" onclick="salvarDados();"><%=lblSalvar%></button>
      </div>
     
   </div> 
    <div class="table-responsive">
     <div id="listagem" style="margin-left:35%;" >
          <div class="panel panel-primary">
              <div class="panel-heading"><%=lblLista%></div>
              <table class="table" id="table-produto"></table>


           </div>

     </div>   
        </div>
         
  </fieldset>

 </div>    

</div>
</body>
</html>
