<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ocorrencia.aspx.cs" Inherits="EluxcityWeb.pages.ocorrencia"%>
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
    // try { tipoArvore = Session["tipoArvore"].ToString(); }
    // catch (Exception ex) { }
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
        if(idioma.IndexOf(',') != -1)
        {
            idioma = idioma.Split(',')[0];
        }
        idioma = idioma.Replace("%20", " ");
    }else
    {
        idioma = "pt-BR";
    }

    pais = Request.Params.Get("pais");
    if(pais != null)
    {
        if (pais.IndexOf(',') != -1)
        {
            pais = pais.Split(',')[0];
        }

        pais = pais.Replace("%20", " ");
    }else
    {
        pais = "Brazil";
    }

    string lblUsuario = "Usuário";
    string lblTitulo = "Cadastro de Ocorrências";
    string lblLista = "Listagem das Ocorrências";
    string lblCancelar = "Cancelar";
    string lblSalvar = "Salvar";
    string lblMenu1 = "Modelo";
    string lblMenu2 = "Ocorrência";
    string lblMenu3 = "Categoria:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
    string lblMenu8 = "Linha:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
    string lblMenu4 = "SubCategoria:";
    string lblPais = "País:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
    string tipoMenu1 = "Categoria";
    string tipoMenu2 = "SubCategoria";
    if (pais.Equals("Brazil"))
    {

        if (tipoArvore.Equals("Arvore Solution Center"))
        {
            tipoMenu1 = "Produto";
            tipoMenu2 = "Modelo";

            lblMenu3 = "Produto:&nbsp;&nbsp;&nbsp;&nbsp;";
            lblMenu4 = "Modelo:";
        }
    }


    if (idioma.Equals("en-US"))
    {
        lblUsuario = "User";
        lblTitulo = "Ocurrencia Registration";
        lblLista = "List of Ocurrencia";
        lblCancelar = "Cancel";
        lblSalvar = "Save";
        lblPais = "Country:&nbsp;&nbsp;";
        lblMenu1 = "Model";
        lblMenu2 = "Ocurrencia";
    }
    else if (idioma.Equals("es-ES"))
    {
        lblUsuario = "Usuario";
        lblTitulo = "Registro del Ocurrencia";
        lblLista = "Lista de Ocurrencias";
        lblCancelar = "Cancel";
        lblSalvar = "Guardar";
        lblPais = "País:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        lblMenu1 = "Modelo";
        lblMenu2 = "Ocurrencia";
    }

    if (lblMenu4.Equals("SubCategoria:"))
    {
        lblPais = "País:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";

        lblMenu8 = "Linha:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";

        lblMenu4 = lblMenu4 + "";
    }
    else
    {
        lblMenu4 = lblMenu4 + "&nbsp; &nbsp; &nbsp; &nbsp;";
    }

    string tipoMenu3 = "Ocorrência";
    string tipoMenu4 = "Importação de Dados";
    string tipoMenu5 = "Relatórios de uso do Sistema";

    string tipoMenu0 = "Linha";
    tipoMenu1 = "Categoria";
    tipoMenu2 = "SubCategoria";

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
    string codigoPais = pais;
    if (pais.Equals("Brazil"))
        codigoPais = "0";


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
    <link href="../includes/arvore/css/bootstrap-multiselect.css" rel="stylesheet" />

  </head>
    <script>

        var $j = jQuery.noConflict();
        var $l = jQuery.noConflict();
        var $p = jQuery.noConflict();
        var $m = jQuery.noConflict();
        var modelo = [];
        var codOcorrencia = 1;
        var codLinha = '0';
        var codProduto = '0';
        var codModelo = '0';
        var codPais = "<%=codigoPais %>";
        var idioma = "<%=idioma %>";

        codPais = "0";

        $j('document').ready(function () {

            telaAtual = "ocorrenciaadmin";

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

                    try { document.getElementById('ocorrencia').innerHTML = dados; } catch (e) { }


                }
            });

              <% if (pais.Equals("Brazil")){ %>
            // esse trecho carrega os dados do pais
            $j.ajax({
                type: "POST",
                url: "linha.aspx/carregaComboPais",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {

                    var dados = jasonResult.d;

                    document.getElementById('pais').innerHTML = dados;


                }
            });
             <% } %>

           

        });

        $j('document').ready(function () {

            var idioma = "<%=idioma.ToString()%>";
            var tipoArvore = "<%=tipoArvore.ToString()%>";
            var dataStr = (idioma.indexOf("'") != -1 && tipoArvore.indexOf("'") != 1) ? "{idioma:" + idioma + ", tipoArvore:" + tipoArvore + ", codPais:'<%=pais %>'}" : "{idioma:'" + idioma + "', tipoArvore:'" + tipoArvore + "', codPais:'<%=pais %>'}";
            // esse trecho carrega os dados do combo Linha
            $l.ajax({
                type: "POST",
                url: "modelo.aspx/carregaComboLinha",
                data: dataStr,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {

                    var dados = jasonResult.d;
                    document.getElementById('linha').innerHTML = dados;


                }
            });

            carregaDadosTabela('', '', '0', '0');

        });


        function preencherComboProdutos(codLinha, codProduto) {

            var idioma = "<%=idioma.ToString()%>";
            var tipoArvore = "<%=tipoArvore.ToString()%>";
            var dataStr = (idioma.indexOf("'") != -1 && tipoArvore.indexOf("'") != 1) ? "{codigo:'" + codLinha + "', idioma:" + idioma + ", tipoArvore:" + tipoArvore + ", codPais:'<%=pais %>'}" : "{codigo:'" + codLinha + "', idioma:'" + idioma + "', tipoArvore:'" + tipoArvore + "', codPais:'<%=pais %>'}";

            $j.ajax({
                type: "POST",
                url: "modelo.aspx/carregaComboProduto",
                data: dataStr,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {

                    var dados = jasonResult.d;

                    document.getElementById('produto').innerHTML = dados;


                    if (codProduto != '0') {
                        $j("#produto").val(codProduto);
                    }


                }
            });

           


        }

        function carregaPerguntas(dados) {

            var aDados = dados.split(",");
            var codOcorrencia = aDados[0];
            var codModelo = aDados[1];
            var codLinha = aDados[2];
            var codProduto = aDados[3];

            document.location.href = "pergunta.aspx?codigoOcorrencia=" + codOcorrencia + "&codModelo="+codModelo + "&tipoAcesso=administrador" + "&idUser=&usuario=<%=username%>&nome=<%=nome%>&tipoArvore=<%=tipoArvore%>&idioma=<%=idioma%>&pais=<%=pais%>";

        }

        function preencherComboModelos(codProduto, codModelo) {
            var idioma = "<%=idioma.ToString()%>";
            var tipoArvore = "<%=tipoArvore.ToString()%>";
            var dataStr = (idioma.indexOf("'") != -1 && tipoArvore.indexOf("'") != 1) ? "{codigo:'" + codProduto + "' , idioma:" + idioma + " , tipoArvore:" + tipoArvore + ",  pais:'" + codPais + "'}" : "{codigo:'" + codProduto + "' , idioma:'" + idioma + "' , tipoArvore:'" + tipoArvore + "',  pais:'" + codPais + "'}"

            $j.ajax({
                type: "POST",
                url: "ocorrencia.aspx/carregaComboModelo",
                data: dataStr,
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

          //  carregaDadosTabela(codLinha, codProduto);


        }

        function carregaDadosTabela(codLinha, codProduto, codigoModelo, codPais) {

            //  var descOcorrencia = document.getElementById('descOcorrencia').value.trim();
            var descOcorrencia = "";
            idioma = "<%=idioma.ToString()%>";
            var tipoArvore = "<%=tipoArvore.ToString()%>";
            console.log('tipoArvore', tipoArvore);
            var dataStr = "";
            if (idioma.indexOf("'") != -1 && tipoArvore.indexOf("'") != -1) {
                dataStr = dataStr = "{ limit: " + limit + ", offset: " + paginaAtual + " , tipo:'administrador' , codModelos:[" + codigoModelo + "], idioma:" + idioma + ", pais:'" + codPais + "' , tipoArvore:" + tipoArvore + ",  codLinha:'" + codLinha + "' ,  codProduto:'" + codProduto + "' ,   descOcorrencia:'" + descOcorrencia + "'  }"
            } else {
                dataStr = "{ limit: " + limit + ", offset: " + paginaAtual + " , tipo:'administrador' , codModelos:[" + codigoModelo + "], idioma:'" + idioma + "', pais:'" + codPais + "' , tipoArvore:'" + tipoArvore + "',  codLinha:'" + codLinha + "' ,  codProduto:'" + codProduto + "' ,   descOcorrencia:'" + descOcorrencia + "'  }"
            }

            console.log('dataStr: ', dataStr);
            $j.ajax({
                type: "POST",
                url: "ocorrencia.aspx/carregaOcorrencias",
                data: dataStr,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {
                    $j('#table-ocorrencia').bootstrapTable('destroy');

                    var dados = jasonResult.d;
                    var total = dados.substring(0, dados.indexOf(","));
                    dados = dados.replace(total + ",", '');

                    var obj = eval(dados);


                    <% if (idioma.Equals("en-US")){ %>

                    $j('#table-ocorrencia').bootstrapTable({
                        data: obj,
                        cache: false,
                        height: 400,
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
                            sortable: truoe
                        }, {
                            field: 'descricao_ocorrencia_ing',
                            title: 'Ocurrencia',
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
                                field: 'pais',
                                title: 'Country',
                                width: 80,
                                align: 'left',
                                valign: 'middle',
                                sortable: true
                            }
                            ,{
                            field: 'perguntas',
                            title: 'Questions',
                            width: 30,
                            align: 'center',
                            valign: 'middle'
                        }, {
                            field: 'alterar',
                            title: 'Edit',
                            width: 30,
                            align: 'center',
                            valign: 'middle'
                        }, {
                            field: 'excluir',
                            title: 'Remove',
                            width: 30,
                            align: 'center',
                            valign: 'middle'
                        }]
                    });
                    $j('#table-ocorrencia').bootstrapTable('hideColumn', 'cod_ocorrencia');

                    <% }else if (idioma.Equals("es-ES")){ %>

                    $j('#table-ocorrencia').bootstrapTable({
                        data: obj,
                        cache: false,
                        height: 400,
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
                        },  {
                            field: 'descricao_ocorrencia_esp',
                            title: 'Ocurrencia',
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
                            }, {
                                field: 'pais',
                                title: 'Pais',
                                width: 80,
                                align: 'left',
                                valign: 'middle',
                                sortable: true
                            },{
                            field: 'perguntas',
                            title: 'Preguntas',
                            width: 30,
                            align: 'center',
                            valign: 'middle'
                        }, {
                            field: 'alterar',
                            title: 'Editar',
                            width: 30,
                            align: 'center',
                            valign: 'middle'
                        }, {
                            field: 'excluir',
                            title: 'Eliminar',
                            width: 30,
                            align: 'center',
                            valign: 'middle'
                        }]
                    });
                    $j('#table-ocorrencia').bootstrapTable('hideColumn', 'cod_ocorrencia');

                    <% } else { %>

                    $j('#table-ocorrencia').bootstrapTable({
                        data: obj,
                        cache: false,
                        height: 400,
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
                            field: 'descricao_ocorrencia_por',
                            title: 'Ocorrência',
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
                            field: 'pais',
                            title: 'País',
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
                        }, {
                            field: 'alterar',
                            title: 'Editar',
                            width: 30,
                            align: 'center',
                            valign: 'middle'
                        }, {
                            field: 'excluir',
                            title: 'Remover',
                            width: 30,
                            align: 'center',
                            valign: 'middle'
                        }]
                    });
                    $j('#table-ocorrencia').bootstrapTable('hideColumn', 'cod_ocorrencia');

                   





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
            codProduto = "0";
            codModelo = "0";
            
            preencherComboProdutos(codLinha, "0");
            preencherComboModelos("0", '0');
            carregaDadosTabela(codLinha, codProduto, codModelo, codPais);
        }

        function retornaProduto() {
            codProduto = $p("#produto option:selected").val();
            paginaAtual = "1";
            codModelo = "0";
            preencherComboModelos(codProduto, "0");
            carregaDadosTabela(codLinha, codProduto, codModelo, codPais);
        }

        function retornaModelo() {
            codModelo = $m("#modelo option:selected").val();
            paginaAtual = "1";
            carregaDadosTabela(codLinha, codProduto, codModelo, codPais);
        }


        function cancelar() {
            location.reload();
        }
        function salvarDados() {

            var modelos = [];
            var bModel = false;
            var options = $j("#modelo option:selected");
            options.each(function () {
                modelos.push($j(this).val());
                bModel = true;
            });

            if (bModel) {

                if (document.getElementById('descricaoPor').value == '' || document.getElementById('descricaoIng').value == ''
            || document.getElementById('descricaoEsp').value == '') {

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

                     <% if (pais.Equals("Brazil")){ %>
                           jAlert(mensagem, title);
                    <% } else { %>

                    var descricaoPor = document.getElementById('descricaoPor').value.trim();
                    var descricaoIng = document.getElementById('descricaoIng').value.trim();
                    var descricaoEsp = document.getElementById('descricaoEsp').value.trim();
                    var codigo = document.getElementById('codigo').value;

                    var msg = "";
                    var titulo = "";
                    if (idioma == 'en-US') {
                        if (descricaoIng == '') {
                            msg = "Enter the description";
                            titulo = "Árbol de decisión";
                        }
                    } else if (idioma == 'es-ES') {
                        if (descricaoEsp == '') {
                            msg = "Introduzca el descripción";
                            titulo = "Decision tree";
                        }
                    } else {
                        if (descricaoPor == '') {
                            msg = "Informe a descrição!";
                            titulo = "Arvore de Decisão";
                        }
                    }

                    if (msg == '') {
                        $j.ajax({
                            type: "POST",
                            url: "ocorrencia.aspx/salvarDados",
                            data: "{descricaoPor:'" + descricaoPor + "',descricaoIng:'" + descricaoIng + "',descricaoEsp:'" + descricaoEsp + "',codigo:'" + codigo + "',codModelos:[" + modelos + "], codPais:'" + codPais + "', tipoArvore:'<%=tipoArvore %>', idioma:'<%=idioma %>', codLinha:'" + codLinha + "', codProduto:'" + codProduto + "'}",
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
                    } else {
                        jAlert(msg, titulo);

                    }


                     <% }  %>



                }

                else {

                    var descricaoPor = document.getElementById('descricaoPor').value.trim();
                    var descricaoIng = document.getElementById('descricaoIng').value.trim();
                    var descricaoEsp = document.getElementById('descricaoEsp').value.trim();
                    var codigo = document.getElementById('codigo').value;



                    $j.ajax({
                        type: "POST",
                        url: "ocorrencia.aspx/salvarDados",
                        data: "{descricaoPor:'" + descricaoPor + "',descricaoIng:'" + descricaoIng + "',descricaoEsp:'" + descricaoEsp + "',codigo:'" + codigo + "',codModelos:[" + modelos + "], codPais:'" + codPais + "', tipoArvore:'<%=tipoArvore %>', idioma:'<%=idioma %>' , codLinha:'" + codLinha + "', codProduto:'" + codProduto + "'}",
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

            } else {

                <% if (idioma.Equals("en-US")){ %>
                jAlert('Tell Model!', 'Decision tree');
                <% }else if (idioma.Equals("es-ES")){ %>
                jAlert('Dile Modelo!', 'Árbol de decisión');
                <% }else{ %>
                jAlert('Informe o Modelo!', 'Arvore de Decisão');
                <% } %>

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
                        url: "ocorrencia.aspx/excluirDados",
                        data: "{codigo:'" + codigo + "', tipoArvore:'<%=tipoArvore %>'}",
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
                url: "ocorrencia.aspx/getOcorrencia",
                data: "{codigo:'" + codigo + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {

                    var aDados = jasonResult.d.split(";");



                    document.getElementById('descricaoPor').value = aDados[0];
                    document.getElementById('descricaoIng').value = aDados[1];
                    document.getElementById('descricaoEsp').value = aDados[2];
                    codLinha = aDados[4];
                    $j("#linha").val(codLinha);
                    codProduto = aDados[5];
                    preencherComboProdutos(codLinha, codProduto);
                    preencherComboModelos(codProduto, aDados[6]);



                    codPais = aDados[7];




                    if (codPais != '0') {
                        $j("#pais").val(codPais);

                    }


                }
            });

        }

        function retornaPais() {
            codPais = $j("#pais option:selected").val();
            paginaAtual = "1";

            if (codPais == '') {
                codPais = "0";
            }

            preencherComboModelos(codProduto, '0');

            carregaDadosTabela(codLinha, codProduto, codModelo, codPais);
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
            <li><a href="ocorrenciaUsuario.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu"><%=tipoMenu3 %></a></li>
        </ul>    

         <%}else{ %>
              <% if(pais.Equals("Brazil")){  %>
                         <ul>
                              <li><a class="liMenu" href="<%=urlVolta%>"  ><img src="../includes/arvore/imagens/home.png" class="img-responsive" style="cursor: pointer;" /></a></li>
                          <li><a class="liMenu" href="linha.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>&tipoArvore=<%=tipoArvore%>&idioma=<%=idioma%>"  ><%=tipoMenu0 %></a></li>
                            <li><a href="produto.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>&tipoArvore=<%=tipoArvore%>&idioma=<%=idioma%>" class="liMenu"><%=tipoMenu1 %></a></li>
                            <li><a href="modelo.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>&tipoArvore=<%=tipoArvore%>&idioma=<%=idioma%>" class="liMenu"><%=tipoMenu2 %></a></li>
                            <li><a href="ocorrencia.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>&tipoArvore=<%=tipoArvore%>&idioma=<%=idioma%>" class="liMenu"><%=tipoMenu3 %></a></li>
                            <li><a href="importacao.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>&tipoArvore=<%=tipoArvore%>&idioma=<%=idioma%>" class="liMenu"><%=tipoMenu4 %></a></li>
                            <li><a href="relatorios.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>&tipoArvore=<%=tipoArvore%>&idioma=<%=idioma%>" class="liMenu"><%=tipoMenu5 %></a></li>
                        </ul>    

              
              <%}else{ %>
                   <% if(tipoArvore.Equals("Arvore Solution Center")){ %>

                          <ul>
                               <li><a class="liMenu" href="<%=urlVolta%>"  ><img src="../includes/arvore/imagens/home.png" class="img-responsive" style="cursor: pointer;" /></a></li>
                            <li><a href="modelo.aspx?idUser=<%=idUser%>&username=<%=user%>&usuario=<%=user%>" class="liMenu"><%=lblMenu1 %></a></li>
                            <li><a href="ocorrencia.aspx?idUser=<%=idUser%>&username=<%=user%>&usuario=<%=user%>" class="liMenu"><%=lblMenu2 %></a></li>
                           
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
    <legend class="scheduler-border"><%=lblTitulo %></legend>

      <div id="cadastro" style="position: absolute; top:0px;" >
        <br /><br /> <br />
         <input type="hidden" name="codigo" id="codigo" value="0" />


           <% if (idioma.Equals("en-US")){ %>

           <% if (pais.Equals("Brazil")){ %>
                   <span class="reqfield" tabindex="0">
                <img src="../includes/arvore/imagens/required.gif" alt="Asterisco"/>Descri&ccedil;&atilde;o da Ocorr&ecirc;ncia | Ocurrencia description | Descripci&oacute;n ocurrencia
         </span><br /><br />
             <% }else{ %>

             <span class="reqfield" tabindex="0">
                <img src="../includes/arvore/imagens/required.gif" alt="Asterisco"/>Ocurrencia description
         </span><br /><br />

           <% } %>

        
               
          
        <div class="form-group">
            <label for="linha" class="control-label">Line:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
            <select class="form-control" id="linha" style="width: 250px !important" onchange="retornaLinha()">           
            </select>
       </div>
       <div class="form-group">
            <label for="produto" class="control-label">Product:&nbsp;&nbsp;</label>
            <select class="form-control" id="produto" style="width: 250px !important" onchange="retornaProduto()">                
            </select>
       </div>

           <% if (pais.Equals("Brazil")){ %>
                <div class="form-group">
                    <label for="pais" class="control-label"><%=lblPais %></label>
                    <select class="form-control" id="pais" style="width: 190px !important" onchange="retornaPais()">
                
                    </select>
                 </div>
             <% } %>

            <div class="form-group">
            <label for="modelo" class="control-label">Model:&nbsp;&nbsp;&nbsp;&nbsp;</label>
            <select id="modelo" multiple="multiple" onchange="retornaModelo()" >
            </select>           
                                </div>  
           
          
          
           


            <% if (pais.Equals("Brazil")){ %>
                
            <div class="form-group">
            <label for="descricaoPor" class="control-label">Ocorrência:&nbsp;</label>
            <input type="text" class="form-control" id="descricaoPor" style="width: 300px !important" placeholder="Informe o a descrição da ocorrência"/>
        </div>
           <div class="form-group">
            <label for="descricaoEsp" class="control-label">Ocurrencia:&nbsp;&nbsp;</label>
            <input type="text" class="form-control" id="descricaoEsp" style="width: 300px !important" placeholder="Introduzca la descripción de la ocurrencia"/>
       </div>
        <div class="form-group">
            <label for="descricaoIng" class="control-label">Ocurrencia:&nbsp;</label>
            <input type="text" class="form-control" id="descricaoIng" style="width: 300px !important" placeholder="Enter the description of the Ocurrencia"/>
         </div>
      

             <% }else{ %>

            <input type="hidden" class="form-control" id="descricaoPor"/>
     
        <div class="form-group">
            <label for="descricaoIng" class="control-label">Ocurrencia:&nbsp;&nbsp;&nbsp;&nbsp;</label>
            <input type="text" class="form-control" id="descricaoIng" style="width: 300px !important" placeholder="Enter the description of the Ocurrencia"/>
         </div>
              <input type="hidden" class="form-control" id="descricaoEsp" />
      

           <% } %>
     


            <% } else if (idioma.Equals("es-ES")){ %>

           <% if (pais.Equals("Brazil")){ %>
                   <span class="reqfield" tabindex="0">
                <img src="../includes/arvore/imagens/required.gif" alt="Asterisco"/> Descri&ccedil;&atilde;o da Ocorr&ecirc;ncia | Ocurrencia description | Descripci&oacute;n ocurrencia
         </span><br /><br />
             <% }else{ %>

             <span class="reqfield" tabindex="0">
                <img src="../includes/arvore/imagens/required.gif" alt="Asterisco"/>Descripci&oacute;n ocurrencia
         </span><br /><br />

           <% } %>
                  <div class="form-group">
            <label for="linha" class="control-label">Línea:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
            <select class="form-control" id="linha" style="width: 250px !important" onchange="retornaLinha()">           
            </select>
       </div>
       <div class="form-group">
            <label for="produto" class="control-label">Producto:&nbsp;&nbsp;&nbsp;&nbsp;</label>
            <select class="form-control" id="produto" style="width: 250px !important" onchange="retornaProduto()">                
            </select>
       </div>

           <% if (pais.Equals("Brazil")){ %>
                <div class="form-group">
                    <label for="pais" class="control-label"><%=lblPais %></label>
                    <select class="form-control" id="pais" style="width: 190px !important" onchange="retornaPais()">
                
                    </select>
                 </div>
             <% } %>
            <div class="form-group">
            <label for="modelo" class="control-label">Modelo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
            <select id="modelo" multiple="multiple" onchange="retornaModelo()" >
            </select>           
                                </div>  
           


            <% if (pais.Equals("Brazil")){ %>
                
            <div class="form-group">
            <label for="descricaoPor" class="control-label">Ocorrência:&nbsp;</label>
            <input type="text" class="form-control" id="descricaoPor" style="width: 300px !important" placeholder="Informe o a descrição da ocorrência"/>
        </div>
           <div class="form-group">
            <label for="descricaoEsp" class="control-label">Ocurrencia:&nbsp;&nbsp;</label>
            <input type="text" class="form-control" id="descricaoEsp" style="width: 300px !important" placeholder="Introduzca la descripción de la ocurrencia"/>
       </div>
        <div class="form-group">
            <label for="descricaoIng" class="control-label">Ocurrencia:&nbsp;</label>
            <input type="text" class="form-control" id="descricaoIng" style="width: 300px !important" placeholder="Enter the description of the Ocurrencia"/>
         </div>
      

             <% }else{ %>

             <input type="hidden" class="form-control" id="descricaoPor" />
       
           <input type="hidden" class="form-control" id="descricaoIng" />
       
       <div class="form-group">
            <label for="descricaoEsp" class="control-label">Descripción:&nbsp;&nbsp;</label>
            <input type="text" class="form-control" id="descricaoEsp" style="width: 300px !important" placeholder="Introduzca la descripción de la incidencia"/>
       </div>
      

           <% } %>





            <% }else { %>

           
         <% if (pais.Equals("Brazil")){ %>
                   <span class="reqfield" tabindex="0">
                <img src="../includes/arvore/imagens/required.gif" alt="Asterisco"/> Descri&ccedil;&atilde;o da Ocorr&ecirc;ncia | Ocurrencia description | Descripci&oacute;n ocurrencia
         </span><br /><br />
             <% }else{ %>

             <span class="reqfield" tabindex="0">
                <img src="../includes/arvore/imagens/required.gif" alt="Asterisco"/>Descri&ccedil;&atilde;o da Ocorr&ecirc;ncia
         </span><br /><br />

           <% } %>
                  <div class="form-group">
            <label for="linha" class="control-label"><%=lblMenu8 %></label>
            <select class="form-control" id="linha" style="width: 250px !important" onchange="retornaLinha()">           
            </select>
       </div>
       <div class="form-group">
            <label for="produto" class="control-label"><%=lblMenu3 %></label>
            <select class="form-control" id="produto" style="width: 250px !important" onchange="retornaProduto()">                
            </select>
       </div>

           <% if (pais.Equals("Brazil")){ %>
                <div class="form-group">
                    <label for="pais" class="control-label"><%=lblPais %></label>
                    <select class="form-control" id="pais" style="width: 190px !important" onchange="retornaPais()">
                
                    </select>
                 </div>
             <% } %>


            <div class="form-group">
            <label for="modelo" class="control-label"><%=lblMenu4 %></label>
            <select id="modelo" multiple="multiple" onchange="retornaModelo()" >
            </select>           
                                </div>  
      
           <% if (pais.Equals("Brazil")){ %>
                
            <div class="form-group">
            <label for="descricaoPor" class="control-label">Ocorrência:&nbsp;</label>
            <input type="text" class="form-control" id="descricaoPor" style="width: 300px !important" placeholder="Informe o a descrição da ocorrência"/>
        </div>
           <div class="form-group">
            <label for="descricaoEsp" class="control-label">Ocurrencia:&nbsp;&nbsp;</label>
            <input type="text" class="form-control" id="descricaoEsp" style="width: 300px !important" placeholder="Introduzca la descripción de la ocurrencia"/>
       </div>
        <div class="form-group">
            <label for="descricaoIng" class="control-label">Ocurrencia:&nbsp;</label>
            <input type="text" class="form-control" id="descricaoIng" style="width: 300px !important" placeholder="Enter the description of the Ocurrencia"/>
         </div>
      

             <% }else{ %>

             <div class="form-group">
            <label for="descricaoPor" class="control-label">Ocorrência:&nbsp;</label>
            <input type="text" class="form-control" id="descricaoPor" style="width: 300px !important" placeholder="Informe o a descrição da ocorrência"/>
        </div>
                 <input type="hidden" class="form-control" id="descricaoEsp" />
     
          <input type="hidden" class="form-control" id="descricaoIng" />
         
      

           <% } %>
          
          
          
        


                <% } %>

                
            



        
      
               

      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal" onclick="cancelar();"><%=lblCancelar %></button>
        <button type="button" class="btn btn-primary" onclick="salvarDados();"><%=lblSalvar %></button>
      </div>
     
   </div> 
       
    <div class="table-responsive">
     <div id="listagem" style="margin-left:35%;" >
          <div class="panel panel-primary">
              <div class="panel-heading"><%=lblLista %></div>
              <table class="table" id="table-ocorrencia"></table>


           </div>

     </div>   
  </div>
         
  </fieldset>

 </div>    
        </div>

</body>
</html>
