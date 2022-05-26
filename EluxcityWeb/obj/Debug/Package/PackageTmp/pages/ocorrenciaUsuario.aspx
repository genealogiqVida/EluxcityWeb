<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ocorrenciaUsuario.aspx.cs" Inherits="EluxcityWeb.pages.ocorrenciaUsuario" %>

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

    string urlVolta = "";
    //try
   // {
       // urlVolta = Session["urlVolta"].ToString();
    //}
    //catch (Exception ex)
    //{

        cookie = Request.Cookies["urlVolta"];
        if (cookie != null)
        {
            urlVolta = cookie.Value.ToString();
            urlVolta = urlVolta.Replace("%3A", ":");
        }
   // }


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

      // pega os dados do cookie

    string codUsuario = username;

    // pega os dados do cookie

    string nomeUsuario = nome;
   // try { tipoArvore = Session["tipoArvore"].ToString(); }
   // catch (Exception ex) { }
    tipoArvore = tipoArvore.Replace("%20", " ");

    string lblUsuario = "Usuário";
    string lblTitulo = "Cadastro de Ocorrências";
    string lblLista = "Listagem das Ocorrências";
    string lblCancelar = "Cancelar";
    string lblSalvar = "Salvar";
    string lblMenu1 = "Modelo";
    string lblMenu2 = "Ocorrência";
    string lblFiltro = "Filtro Pesquisa Ocorrências";

    string lblOcorrencia = "Busca por palavra-chave";

    string lblLinha = "Linha";
    string lblProduto = "Produto";
    string lblModelo = "Modelo";
    string lblPesquisa = "Pesquisar";
    string lblLimpar = "Limpar";

    string tipoMenu1 = "Categoria";
    string tipoMenu2 = "SubCategoria";
    if (pais.Equals("Brazil"))
    {

        if (tipoArvore.Equals("Arvore Solution Center"))
        {
            tipoMenu1 = "Produto";
            tipoMenu2 = "Modelo";
        }
    }


    if (idioma.Equals("en-US"))
    {
        lblUsuario = "User";
        lblTitulo = "Ocurrencia Registration";
        lblLista = "List of Ocurrencia";
        lblCancelar = "Cancel";
        lblSalvar = "Save";
        lblMenu1 = "Model";
        lblMenu2 = "Ocurrencia";
        lblFiltro = "Filter search Ocurrencia";
       
         lblLinha = "Line";
         lblProduto = "Product";
         lblOcorrencia = "Search by keyword";
         lblModelo = "Model";
         lblPesquisa = "Search";
         lblLimpar = "Clean";
    }
    else if (idioma.Equals("es-ES"))
    {
        lblUsuario = "Usuario";
        lblTitulo = "Registro del Ocurrencia";
        lblLista = "Lista de Ocurrencias";
        lblCancelar = "Cancel";
        lblSalvar = "Guardar";
        lblMenu1 = "Model";
        lblOcorrencia = "Búsqueda por palavra clave";
        lblMenu2 = "Ocurrencia";
        lblFiltro = "Filtro de Búsqueda de Ocurrencia";

        lblLinha = "Línea";
        lblProduto = "Producto";
        lblModelo = "Modelo";

        lblPesquisa = "Búsqueda";
        lblLimpar = "Borrar";
    }

    string codigoPais = pais;
    if (pais.Equals("Brazil"))
        codigoPais = "0";



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
  

    <script src="../includes/arvore/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../includes/arvore/js/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>
    <script src="../includes/arvore/js/jquery.alerts.js" type="text/javascript"></script>
    <script src="../includes/arvore/js/bootstrap.js" type="text/javascript"></script>
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
    <script src="../includes/arvore/js/bootstrap-tagsinput.js" type="text/javascript"></script>
   

    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/jquery-ui-1.10.4.custom.css" />
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/jquery.alerts.css" />
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap-table.css" />
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap-tagsinput.css" />
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/estilo.css" />
    <link href="../includes/arvore/css/bootstrap-multiselect.css" rel="stylesheet" />

</head>
<script>
    var modelos = [];
    var $j = jQuery.noConflict();
    var $l = jQuery.noConflict();
    var $p = jQuery.noConflict();
    var $m = jQuery.noConflict();

    var codOcorrencia = "0";
    var codLinha = "0";
    var codProduto = "0";
    var codModelo = "0";

    var codPais = "<%=codigoPais %>";

    $j('document').ready(function () {

        telaAtual = "ocorrencia";

        // esse trecho carrega os dados do combo ocorrencia

        $j("#modelo").multiselect({
            includeSelectAllOption: true,
            enableCaseInsensitiveFiltering: true,
            buttonWidth: '250px',
            maxHeight: 200
        });

        $j.ajax({
            type: "POST",
            url: "ocorrencia.aspx/carregaComboOcorrencia",
            data: "{}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (jasonResult) {

                var dados = jasonResult.d;

                //document.getElementById('ocorrencia').innerHTML = dados;


            }
        });

        carregaDadosTabela('0', '0');

    });

    $j('document').ready(function () {

        // esse trecho carrega os dados do combo Linha
        $l.ajax({
            type: "POST",
            url: "modelo.aspx/carregaComboLinhaUsuario",
            data: "{idioma:'<%=idioma %>', tipoArvore:'<%=tipoArvore %>', codPais:'<%=pais %>'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (jasonResult) {

                var dados = jasonResult.d;
                document.getElementById('linha').innerHTML = dados;


            }
        });

        // carregaDadosTabela();

    });


    function preencherComboProdutos(codLinha, codProduto) {

        $j.ajax({
            type: "POST",
            url: "modelo.aspx/carregaComboProdutoUsuario",
            data: "{codigo:'" + codLinha + "', idioma:'<%=idioma %>', tipoArvore:'<%=tipoArvore %>', codPais:'<%=pais %>'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (jasonResult) {

                var dados = jasonResult.d;

              //  alert(dados);
                document.getElementById('produto').innerHTML = dados;


                if (codProduto != '0') {
                    $j("#produto").val(codProduto);
                }


            }
        });

        // carregaDadosTabela();


    }

    function carregaPerguntas(dados) {
        var aDados = dados.split(",");
        var codOcorrencia = aDados[0];
        var codModelo = aDados[1];
        var codLinha = aDados[2];
        var codProduto = aDados[3];
         
        $j.ajax({
            type: "POST",
            url: "ocorrencia.aspx/salvarDadosPesquisa",
            data: "{codOcorrencia:'" + codOcorrencia + "', codModelo:'" + codModelo + "', codLinha:'" + codLinha + "', codProduto:'" + codProduto + "', codUsuario:'<%=codUsuario%>', nomeUsuario:'<%=nomeUsuario%>'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (jasonResult) {

                var codPesquisa = jasonResult.d;

                document.location.href = "perguntaUsuario.aspx?codigoOcorrencia=" + codOcorrencia + "&codPesquisa=" + codPesquisa + "&codModelo=" + codModelo + "&codLinha=" + codLinha + "&codProduto=" + codProduto;


            }
        });





    }

    function preencherComboModelos(codProduto, codModelo) {

        $j.ajax({
            type: "POST",
            url: "ocorrencia.aspx/carregaComboModelo",
            data: "{codigo:'" + codProduto + "' , idioma:'<%=idioma %>' , tipoArvore:'<%=tipoArvore %>',  pais:'" + codPais + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (jasonResult) {

                var dados = jasonResult.d;

                document.getElementById('modelo').innerHTML = dados;


                $j("#modelo").multiselect('rebuild', {
                    includeSelectAllOption: true,
                    enableCaseInsensitiveFiltering: true,
                    buttonWidth: '250px',
                    maxHeight: 200
                });

                $j("#modelo").multiselect('refresh');

                if (codModelo != '0') {
                    var aModelos = codModelo.split(",");

                    for (var i = 0; i < aModelos.length; i++) {
                        $j("#modelo").multiselect('select', aModelos[i], true);

                    }

                }

            }
        });

        // carregaDadosTabela();


    }

    function carregaDadosTabela(codLinha, codProduto) {

        var descOcorrencia = document.getElementById('descOcorrencia').value.trim();

        $j.ajax({
            type: "POST",
            url: "ocorrencia.aspx/carregaOcorrencias",
            data: "{limit: " + limit + ", offset: " + paginaAtual + " , tipo:'usuario' , codModelos:[" + modelos + "], idioma:'<%=idioma %>', pais:'" + codPais + "' , tipoArvore:'<%=tipoArvore %>',  codLinha:'" + codLinha + "' , codProduto:'" + codProduto + "' ,   descOcorrencia:'" + descOcorrencia + "' }",

            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (jasonResult) {
                var dados = jasonResult.d;
                var total = dados.substring(0, dados.indexOf(","));
                dados = dados.replace(total + ",", '');

                $j('#table-ocorrencia').bootstrapTable('destroy');

                var obj = eval(dados);

                 <% if (idioma.Equals("en-US")){ %>

                $j('#table-ocorrencia').bootstrapTable({
                    data: obj,
                    cache: false,
                    height: 570,
                    pagination: true,
                    pageSize: limit,
                    totalRows: total,
                    pageNumber: paginaAtual,
                   // search: true,
                    showColumns: false,
                    showRefresh: false,
                    sidePagination: 'server',
                    minimumCountColumns: 2,
                    clickToSelect: true,
                    columns: [{
                        field: 'cod_ocorrencia',
                        width: 1
                    }, {
                        field: 'nome_linha_ing',
                        title: 'Line',
                        width: 80,
                        align: 'left',
                        valign: 'middle',
                        sortable: true
                    }, {
                        field: 'nome_produto_ing',
                        title: 'Product',
                        width: 80,
                        align: 'left',
                        valign: 'middle',
                        sortable: true
                    }, {
                        field: 'nome_modelo_ing',
                        title: 'Model',
                        width: 80,
                        align: 'left',
                        valign: 'middle',
                        sortable: true
                    }, {
                        field: 'descricao_ocorrencia_ing',
                        title: 'Description Ocurrencia',
                        width: 80,
                        align: 'left',
                        valign: 'middle',
                        sortable: true
                    }, {
                        field: 'perguntas',
                        title: 'Questions',
                        width: 30,
                        align: 'center',
                        valign: 'middle'
                    }
                    ]
                });
                $j('#table-ocorrencia').bootstrapTable('hideColumn', 'cod_ocorrencia');
                $j('#table-ocorrencia').bootstrapTable('refresh');
                <% }else if (idioma.Equals("es-ES")){ %>

                $j('#table-ocorrencia').bootstrapTable({
                    data: obj,
                    cache: false,
                    height: 570,
                    pagination: true,
                    pageSize: limit,
                    totalRows: total,
                    pageNumber: paginaAtual,
                    //search: true,
                    showColumns: false,
                    showRefresh: false,
                    sidePagination: 'server',
                    minimumCountColumns: 2,
                    clickToSelect: true,
                    columns: [{
                        field: 'cod_ocorrencia',
                        width: 1
                    }, {
                        field: 'nome_linha_esp',
                        title: 'Línea',
                        width: 80,
                        align: 'left',
                        valign: 'middle',
                        sortable: true
                    }, {
                        field: 'nome_produto_esp',
                        title: 'Producto',
                        width: 80,
                        align: 'left',
                        valign: 'middle',
                        sortable: true
                    }, {
                        field: 'nome_modelo_esp',
                        title: 'Modelo',
                        width: 80,
                        align: 'left',
                        valign: 'middle',
                        sortable: true
                    },{
                        field: 'descricao_ocorrencia_esp',
                        title: 'Descripción Incidencia',
                        width: 80,
                        align: 'left',
                        valign: 'middle',
                        sortable: true
                    }, {
                        field: 'perguntas',
                        title: 'Preguntas',
                        width: 30,
                        align: 'center',
                        valign: 'middle'
                    }]
                });
                $j('#table-ocorrencia').bootstrapTable('hideColumn', 'cod_ocorrencia');
                $j('#table-ocorrencia').bootstrapTable('refresh');
                <% } else { %>

                <% if (pais.Equals("Brazil")){ %>

                $j('#table-ocorrencia').bootstrapTable({
                    data: obj,
                    cache: false,
                    height: 570,
                    pagination: true,
                    pageSize: limit,
                    totalRows: total,
                    pageNumber: paginaAtual,
                   // search: true,
                    showColumns: false,
                    showRefresh: false,
                    sidePagination: 'server',
                    minimumCountColumns: 2,
                    clickToSelect: true,
                    columns: [{
                        field: 'cod_ocorrencia',
                        width: 1
                    }, {
                        field: 'nome_linha_por',
                        title: 'Linha',
                        width: 80,
                        align: 'left',
                        valign: 'middle',
                        sortable: true
                    }, {
                        field: 'nome_produto_por',
                        title: 'Produto',
                        width: 80,
                        align: 'left',
                        valign: 'middle',
                        sortable: true

                    }, {
                        field: 'nome_modelo_por',
                        title: 'Modelo',
                        width: 80,
                        align: 'left',
                        valign: 'middle',
                        sortable: true
                    }, {
                        field: 'descricao_ocorrencia_por',
                        title: 'Descrição',
                        width: 80,
                        align: 'left',
                        valign: 'middle',
                        sortable: true
                    },  {
                        field: 'perguntas',
                        title: 'Perguntas',
                        width: 30,
                        align: 'center',
                        valign: 'middle'
                    }]
                });
                $j('#table-ocorrencia').bootstrapTable('hideColumn', 'cod_ocorrencia');
                $j('#table-ocorrencia').bootstrapTable('refresh');
                <% } else { %>


                $j('#table-ocorrencia').bootstrapTable({
                    data: obj,
                    cache: false,
                    height: 570,
                    pagination: true,
                    pageSize: limit,
                    totalRows: total,
                    pageNumber: paginaAtual,
                   // search: true,
                    showColumns: false,
                    showRefresh: false,
                    sidePagination: 'server',
                    minimumCountColumns: 2,
                    clickToSelect: true,
                    columns: [{
                        field: 'cod_ocorrencia',
                        width: 1
                    }, {
                        field: 'nome_linha_por',
                        title: 'Linha',
                        width: 80,
                        align: 'left',
                        valign: 'middle',
                        sortable: true
                    }, {
                        field: 'nome_produto_por',
                        title: 'Produto',
                        width: 80,
                        align: 'left',
                        valign: 'middle',
                        sortable: true
                    }, {
                        field: 'nome_modelo_por',
                        title: 'Modelo',
                        width: 80,
                        align: 'left',
                        valign: 'middle',
                        sortable: true
                    },{
                        field: 'descricao_ocorrencia_por',
                        title: 'Descrição Ocorrência',
                        width: 80,
                        align: 'left',
                        valign: 'middle',
                        sortable: true
                    }, {
                        field: 'perguntas',
                        title: 'Perguntas',
                        width: 30,
                        align: 'center',
                        valign: 'middle'
                    }
                     ]
                });
                $j('#table-ocorrencia').bootstrapTable('hideColumn', 'cod_ocorrencia');
                $j('#table-ocorrencia').bootstrapTable('refresh');

                <% } %>





                <% } %>





            }
        });
    }

    function retornaOcorrencia() {
        codOcorrencia = $j("#ocorrencia option:selected").val();
    }

    function retornaLinha() {
        codLinha = $l("#linha option:selected").val();
        paginaAtual = "1";
        preencherComboProdutos(codLinha, "0");
        preencherComboModelos("0", "0");
    }

    function retornaProduto() {
        codProduto = $p("#produto option:selected").val();
        paginaAtual = "1";
        preencherComboModelos(codProduto, "0");
    }

    function retornaModelo() {
        codModelo = $m("#modelo option:selected").val();
        paginaAtual = "1";
    }

    function limpar() {
        location.reload();
    }

    function pesquisaOcorrencia() {

        modelos = [];

        var options = $j("#modelo option:selected");
        options.each(function () {
            modelos.push($j(this).val());
        });

        document.getElementById('table-ocorrencia').innerHTML = "";

        $j('#table-ocorrencia').bootstrapTable('destroy');

        //$j('#table-ocorrencia').bootstrapTable('refresh', { url: "ocorrencia.aspx/carregaOcorrencias" });

        carregaDadosTabela(codLinha, codProduto);


    }

</script>
<body>
   <div class="container-fluid">
   




         <br />
 <% if(tipoAcesso.Equals("usuario")){  %>
     <ul>
            <li><a class="liMenu" href="<%=urlVolta%>"  ><img src="../includes/arvore/imagens/home.png" class="img-responsive" style="cursor: pointer;" /></a></li>
            <li><a href="ocorrenciaUsuario.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu"><%=lblMenu2 %></a></li>
        </ul>    

         <%}else{ %>
              <% if(pais.Equals("Brazil")){  %>
                         <ul>
                              <li><a class="liMenu" href="<%=urlVolta%>"  ><img src="../includes/arvore/imagens/home.png" class="img-responsive" style="cursor: pointer;" /></a></li>
                            <li><a class="liMenu" href="linha.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>"  >Linha</a></li>
                           <li><a href="produto.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu"><%=tipoMenu1 %></a></li>
                            <li><a href="modelo.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu"><%=tipoMenu2 %></a></li>
                            <li><a href="ocorrencia.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu">Ocorr&ecirc;ncias</a></li>
                            <li><a href="importacao.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu">Importa&ccedil;&atilde;o de Dados</a></li>
                            <li><a href="relatorios.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu">Relat&oacute;rios de uso do Sistema</a></li>
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
                <legend class="scheduler-border"><%=lblFiltro %></legend>
                <div style="text-align: center;">
                    <div class="form-group">
                        <label for="linha" class="control-label"><%=lblLinha %>:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                        <select class="form-control" id="linha" style="width: 250px !important" onchange="retornaLinha()">
                        </select>
                    </div>
                    <div class="form-group">
                        <label for="produto" class="control-label"><%=lblProduto %>:&nbsp;&nbsp;&nbsp;</label>
                        <select class="form-control" id="produto" style="width: 250px !important" onchange="retornaProduto()">
                        </select>
                    </div>
                    <div class="form-group">
                        <label for="modelo" class="control-label"><%=lblModelo %>:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                        <select id="modelo" multiple="multiple" onchange="retornaModelo()">
                        </select>
                    </div>

                     <div class="form-group">
                        <label for="modelo" class="control-label"><%=lblOcorrencia %>:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                                 <input type="text" class="form-control" id="descOcorrencia" style="width: 390px !important"  />
          
                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" onclick="pesquisaOcorrencia();"><%=lblPesquisa %></button>
                        <button type="button" class="btn btn-primary" onclick="limpar();"><%=lblLimpar %></button>
                    </div>
                </div>
            </fieldset>


            <div class="table-responsive" width="100%">
                <table class="table">
                    <tr>
                        <td>
                            <div id="listagem">
                                <div class="panel panel-primary">
                                    <div class="panel-heading"><%=lblLista %></div>
                                    <table id="table-ocorrencia"></table>
                                </div>

                            </div>
                        </td>

                    </tr>
                </table>
            </div>

        </div>
    </div>
</body>
</html>
