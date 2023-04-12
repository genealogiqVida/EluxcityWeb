<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modelo.aspx.cs"  Inherits="EluxcityWeb.pages.modelo"%>
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

    tipoAcesso = Request.Params.Get("tipoAcesso");
    if (tipoAcesso.IndexOf(',') != -1)
    {
        tipoAcesso = tipoAcesso.Split(',')[0];
    }


    cookie = Request.Cookies["pais"];
    if (cookie != null)
    {
        pais = cookie.Value.ToString();
        pais = pais.Replace("%20", " ");
    }
    else
    {
        pais = Request.Params.Get("pais");
        if (pais != null)
        {
            if (pais.IndexOf(',') != -1)
            {
                pais = pais.Split(',')[0];
            }
        }else
        {
            pais = "Brazil";
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

        if (idioma.IndexOf(',') != -1)
        {
            idioma = idioma.Split(',')[0];
        }
    }else
    {
        idioma = "pt-BR";
    }

    string lblUsuario = "Usuário";
    string lblTitulo = "Cadastro de Modelo";
    string lblLista = "Listagem dos Modelos";
    string lblCancelar = "Cancelar";
    string lblSalvar = "Salvar";
    string lblMenu1 = "Modelo";
    string lblMenu2 = "Ocorrência";
    string lblPais = "País:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
    string tipoMenu1 = "Categoria:";
    string tipoMenu2 = "SubCategoria";

    string lblCampo1 = "Informe o nome da subcategoria";
    string lblCampo2 = "Enter the subcategory name";
    string lblCampo3 = "Introduzca el nombre del subcategoria";
    string informacao = "Nome da SubCategoria | Subcategory name | Nombre del Subcategoría";



    string lblNome = "Nome Modelo:&nbsp;&nbsp;&nbsp;";
    string lblNome2 = "Nombre Modelo:";
    string lblNome3 = "Model name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";

    // if (pais.Equals("Brazil"))
    //{


    if (tipoArvore.Equals("Arvore Solution Center"))
    {
        tipoMenu1 = "Produto:&nbsp;&nbsp;&nbsp;";
        tipoMenu2 = "Modelo";
        lblTitulo = "Cadastro de Modelo";
        lblLista = "Listagem dos Modelos";

        lblCampo1 = "Informe o nome do modelo";
        lblCampo2 = "Enter the model name";
        lblCampo3 = "Introduzca el nombre del modelo";
        if (pais.Equals("Brazil"))
        {
            informacao = "Nome do Modelo | Model name | Nombre del Modelo";
        }
        else
        {
            if (idioma.Equals("en-US"))
            {
                informacao = "Model name";
            }
            else if (idioma.Equals("es-ES"))
            {
                informacao = "Nombre del Modelo";
            }
            else
            {
                informacao = "Nome do Modelo";
            }
        }
    }

    // }

    if (idioma.Equals("en-US"))
    {
        lblUsuario = "User";
        lblTitulo = "Model Registration";
        lblLista = "List of Models";
        lblCancelar = "Cancel";
        lblSalvar = "Save";
        lblMenu1 = "Model";
        lblPais = "Country:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        lblMenu2 = "Ocurrencia";
    }
    else if (idioma.Equals("es-ES"))
    {
        lblUsuario = "Usuario";
        lblTitulo = "Registro del modelo";
        lblLista = "Lista de modelos";
        lblCancelar = "Cancel";
        lblSalvar = "Guardar";
        lblPais = "País:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        lblMenu1 = "Modelo";
        lblMenu2 = "Ocurrencia";
    }




    string tipoMenu3 = "Ocorrência";
    string tipoMenu4 = "Importação de Dados";
    string tipoMenu5 = "Relatórios de uso do Sistema";

    string  lblLista1 = "Nome Modelo";
    string lblLista2 = "Nombre Modelo";
    string lblLista3 = "Model name";


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
        tipoMenu1 = "Produto:&nbsp;&nbsp;&nbsp;";
        tipoMenu2 = "Modelo";

        lblNome = "Modelo:&nbsp;&nbsp;&nbsp;";
        lblNome2 = "Modelo:&nbsp;&nbsp;&nbsp;";
        lblNome3 = "Model:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";

        lblTitulo = "Cadastro de Modelo";
        lblLista = "Listagem dos Modelos";
        lblMenu1 = "Modelo";

        lblLista1  = "Modelo";
        lblLista2 = "Modelo";
        lblLista3 = "Model";

        if (idioma.Equals("en-US"))
        {
            tipoMenu1 = "Product:&nbsp;&nbsp;&nbsp;";
            tipoMenu2 = "Model";

            lblTitulo = "Model Registration";
            lblLista = "List of Models";
            lblMenu1 = "Model";
        }
        else if (idioma.Equals("es-ES"))
        {
            tipoMenu1 = "Producto:&nbsp;&nbsp;&nbsp;";
            tipoMenu2 = "Modelo";

            lblTitulo = "Registro del modelo";
            lblLista = "Lista de modelos";
            lblMenu1 = "Modelo";

        }

    }
    else
    {

        lblLista1 = "SubCategoria";
        lblLista2 = "SubCategoría";
        lblLista3 = "Subcategory";

        lblTitulo = "Cadastro de SubCategoria";
        lblLista = "Listagem das SubCategorias";
        lblMenu1 = "SubCategoria";

        lblNome = "SubCategoria:";
        lblNome2 = "SubCategoría:";
        lblNome3 = "Subcategory:&nbsp;";


        if (idioma.Equals("en-US"))
        {


            lblTitulo = "Subcategory Registration";
            lblLista = "List of Subcategory";
            lblMenu1 = "Subcategory";
        }
        else if (idioma.Equals("es-ES"))
        {

            lblMenu1 = "SubCategoría";
            lblTitulo = "Registro del SubCategoría";
            lblLista = "Lista de SubCategoría";

        }

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
     <% }else if (idioma.Equals("es-ES")){ %>
                 <script src="../includes/arvore/js/bootstrap-table-esp.js" type="text/javascript"></script>
     <% }else{ %>
                <script src="../includes/arvore/js/bootstrap-table.js" type="text/javascript"></script>
      <% } %>


   
    <script src="../includes/arvore/js/bootstrap-tagsinput.js" type="text/javascript"></script>


    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/jquery-ui-1.10.4.custom.css" />
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/jquery.alerts.css" />
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap-table.css" />
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap-tagsinput.css" />
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/estilo.css" />

    <script>
        var codProduto= "0";
        var codLinha = "0";
        var codPais = "<%=codigoPais %>";
        var idioma = "<%=idioma %>";
        var $j = jQuery.noConflict();
        var $l = jQuery.noConflict();


        $j('document').ready(function () {

            telaAtual = "modelo";

            var idioma = "<%=idioma.ToString()%>";
            var tipoArvore = "<%=tipoArvore.ToString()%>";
            var dataStr = (idioma.indexOf("'") != -1 && tipoArvore.indexOf("'") != -1) ? "{idioma:" + idioma + ", tipoArvore:" + tipoArvore + ", codPais:'<%=pais %>'}" : "{idioma:'" + idioma + "', tipoArvore:'" + tipoArvore + "', codPais:'<%=pais %>'}";

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

            carregaDadosTabela('', '', '0');

        });


        function carregaDadosTabela(codLinha, codProduto, codPais) {

            var idioma = "<%=idioma.ToString()%>";
            var tipoArvore = "<%=tipoArvore.ToString()%>";
            var dataStr = (idioma.indexOf("'") != -1 && tipoArvore.indexOf("'") != -1) ? "{limit: " + limit + ", offset: " + paginaAtual + " ,idioma:" + idioma + ", pais:'" + codPais + "' , codLinha:'" + codLinha + "' , codProduto:'" + codProduto + "' , tipoArvore:" + tipoArvore + "}" : "{limit: " + limit + ", offset: " + paginaAtual + " ,idioma:'" + idioma + "', pais:'" + codPais + "' , codLinha:'" + codLinha + "' , codProduto:'" + codProduto + "' , tipoArvore:'" + tipoArvore + "'}";

            $j.ajax({
                type: "POST",
                url: "modelo.aspx/carregaModelos",
                data: dataStr,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {

                    $j('#table-modelo').bootstrapTable('destroy');

                    var dados = jasonResult.d;
                    var total = dados.substring(0, dados.indexOf(","));
                    dados = dados.replace(total + ",", '');

                    var obj = eval(dados);

                    <% if (idioma.Equals("en-US")){ %>

                    <% if (pais.Equals("Brazil")){ %>

                    $j('#table-modelo').bootstrapTable({
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
                            field: 'cod_modelo',
                            width: 1
                        }, {  
                            field: 'nome_por',
                            title: '<%=lblLista1%>',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'nome_esp',
                            title: '<%=lblLista2%>',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true

                        }, {
                            field: 'nome_ing',
                            title: '<%=lblLista3%>',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'linha_ing',
                            title: 'Line',
                            width: 90,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'produto_ing',
                            title: 'Product',
                            width: 90,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'pais',
                            title: 'Country',
                            width: 50,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
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
                    $j('#table-modelo').bootstrapTable('hideColumn', 'cod_modelo');

                    <% }else{ %>

                    $j('#table-modelo').bootstrapTable({
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
                            field: 'cod_modelo',
                            width: 1
                        },  {
                            field: 'nome_ing',
                            title: 'Model',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'linha_ing',
                            title: 'Line',
                            width: 90,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'produto_ing',
                            title: 'Product',
                            width: 90,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'pais',
                            title: 'Country',
                            width: 50,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
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
                    $j('#table-modelo').bootstrapTable('hideColumn', 'cod_modelo');

                     <% }%>

                    


                    <% }else if (idioma.Equals("es-ES")){ %>

                    <% if (pais.Equals("Brazil")){ %>

                    $j('#table-modelo').bootstrapTable({
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
                            field: 'cod_modelo',
                            width: 1
                        }, {
                            field: 'nome_por',
                            title: '<%=lblLista1%>',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'nome_esp',
                            title: '<%=lblLista2%>',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true

                        }, {
                            field: 'nome_ing',
                            title: '<%=lblLista3%>',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'linha_esp',
                            title: 'Linha',
                            width: 90,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'produto_esp',
                            title: 'Producto',
                            width: 90,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'pais',
                            title: 'País',
                            width: 50,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
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
                    $j('#table-modelo').bootstrapTable('hideColumn', 'cod_modelo');

                    <% }else{ %>


                    $j('#table-modelo').bootstrapTable({
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
                            field: 'cod_modelo',
                            width: 1
                        }, {
                            field: 'nome_esp',
                            title: 'Modelo',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true

                        },  {
                            field: 'linha_esp',
                            title: 'Linha',
                            width: 90,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'produto_esp',
                            title: 'Producto',
                            width: 90,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'pais',
                            title: 'País',
                            width: 50,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
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
                    $j('#table-modelo').bootstrapTable('hideColumn', 'cod_modelo');

                     <% }%>

                   

                    <% } else { %>

                    <% if (pais.Equals("Brazil")){ %>

                    $j('#table-modelo').bootstrapTable({
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
                            field: 'cod_modelo',
                            width: 1
                        }, {
                            field: 'nome_por',
                            title: '<%=lblLista1%>',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'nome_esp',
                            title: '<%=lblLista2%>',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true

                        }, {
                            field: 'nome_ing',
                            title: '<%=lblLista3%>',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'linha',
                            title: '<%=tipoMenu0.Replace(":", "")%>',
                            width: 90,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'produto',
                            title: '<%=tipoMenu1.Replace(":", "")%>',
                            width: 90,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'pais',
                            title: 'País',
                            width: 50,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
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
                    $j('#table-modelo').bootstrapTable('hideColumn', 'cod_modelo');

                    <% }else{ %>


                    $j('#table-modelo').bootstrapTable({
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
                            field: 'cod_modelo',
                            width: 1
                        }, {
                            field: 'nome_por',
                            title: 'Modelo',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        },  {
                            field: 'linha',
                            title: '<%=tipoMenu0.Replace(":", "")%>',
                            width: 90,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'produto',
                            title: '<%=tipoMenu1.Replace(":", "")%>',
                            width: 90,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'pais',
                            title: 'País',
                            width: 50,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
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
                    $j('#table-modelo').bootstrapTable('hideColumn', 'cod_modelo');

                     <% }%>

                

                    

                    <% } %>


                    


                }
            });
        }

        function retornaPais() {
            codPais = $j("#pais option:selected").val();
            paginaAtual = "1";
            carregaDadosTabela(codLinha, codProduto, codPais)
        }

        function preencherComboProdutos(codLinha, codProduto) {

            var idioma = "<%=idioma.ToString()%>";
            var tipoArvore = "<%=tipoArvore.ToString()%>";
            var dataStr = (idioma.indexOf("'") != -1 && tipoArvore.indexOf("'") != -1) ? "{codigo:'" + codLinha + "', idioma:" + idioma + ", tipoArvore:" + tipoArvore + ", codPais:'<%=pais %>'}" : "{codigo:'" + codLinha + "', idioma:'" + idioma + "', tipoArvore:'" + tipoArvore + "', codPais:'<%=pais %>'}";

            $j.ajax({
                type: "POST",
                url: "modelo.aspx/carregaComboProduto",
                data: dataStr,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {

                    var dados = jasonResult.d;

                    document.getElementById('produto').innerHTML = dados;

                
                    if(codProduto!='0'){
                        $j("#produto").val(codProduto);
                    }


                }
            });

            carregaDadosTabela(codLinha, codProduto, codPais);


        }


        function retornaProduto() {
            codProduto = $j("#produto option:selected").val();
            paginaAtual = "1";
            carregaDadosTabela(codLinha, codProduto, codPais);
        }

        function retornaLinha() {
            codLinha = $l("#linha option:selected").val();
            paginaAtual = "1";
            codProduto = "0";
            preencherComboProdutos(codLinha, "0");
            //carregaDadosTabela(codLinha, codProduto)


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

            if (codProduto == "0") {
                <% if (idioma.Equals("en-US")){ %>
                   jAlert('Tell Product!', 'Decision tree');
                <% }else if (idioma.Equals("es-ES")){ %>
                   jAlert('Dile Producto!', 'Árbol de decisión');
                <% }else{ %>
                    jAlert('Informe o Produto!', 'Arvore de Decisão');
                <% } %>


               

            }
            else if (document.getElementById('nomePor').value == '' || document.getElementById('nomeIng').value == ''
                     || document.getElementById('nomeEsp').value == '') {

                <% if (pais.Equals("Brazil")){ %>
                      jAlert(mensagem, title);
                <% } else { %>

                            var nomePor = document.getElementById('nomePor').value.trim();
                            var nomeEsp = document.getElementById('nomeEsp').value.trim();
                            var nomeIng = document.getElementById('nomeIng').value.trim();
                            var codigo = document.getElementById('codigo').value;

                            var msg = "";
                            var titulo = "";
                            if (idioma == 'en-US') {
                                if (nomeIng == '') {
                                    msg = "Enter the model name";
                                    titulo = "Árbol de decisión";
                                }
                            } else if (idioma == 'es-ES') {
                                if (nomeEsp == '') {
                                    msg = "Introduzca el nombre del modelo";
                                    titulo = "Decision tree";
                                }
                            } else {
                                if (nomePor == '') {
                                    msg = "Informe o nome do modelo!";
                                    titulo = "Arvore de Decisão";
                                }
                            }

                            if (msg == '') {

                                    $j.ajax({
                                        type: "POST",
                                        url: "modelo.aspx/salvarDados",
                                        data: "{nomePor:'" + nomePor + "',nomeEsp:'" + nomeEsp + "',nomeIng:'" + nomeIng + "',codProduto:'" + codProduto + "',codigo:'" + codigo + "', codPais:'" + codPais + "', username:'<%=username %>', tipoArvore:'<%=tipoArvore %>', idioma:'<%=idioma %>'}",
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

                           

                 <% } %>
              
               

            }

            else {

                var nomePor = document.getElementById('nomePor').value.trim();
                var nomeEsp = document.getElementById('nomeEsp').value.trim();
                var nomeIng = document.getElementById('nomeIng').value.trim();
                var codigo = document.getElementById('codigo').value;

                $j.ajax({
                    type: "POST",
                    url: "modelo.aspx/salvarDados",
                    data: "{nomePor:'" + nomePor + "',nomeEsp:'" + nomeEsp + "',nomeIng:'" + nomeIng + "',codProduto:'" + codProduto + "',codigo:'" + codigo + "', codPais:'" + codPais + "', username:'<%=username %>', tipoArvore:'<%=tipoArvore %>', idioma:'<%=idioma %>'}",
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
                        url: "modelo.aspx/excluirDados",
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
                                jAlert("Could not delete the record<br>There is Ocurrencia for this model.", 'Decision tree');
                                <% }else if (idioma.Equals("es-ES")){ %>
                                jAlert("No se pudo eliminar el registro<Br>No es ocurrencia para esta modelo.", 'Árbol de decisión');
                                <% }else{ %>
                                jAlert('Não foi possível excluir o registro!<br>Existe(m) ocorrência(s) para esse modelo.', 'Arvore de Decisão');
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
                url: "modelo.aspx/getModelo",
                data: "{codigo:'" + codigo + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {
                    var aDados = jasonResult.d.split(";");
                    document.getElementById('nomePor').value = aDados[0];
                    document.getElementById('nomeIng').value = aDados[1];
                    document.getElementById('nomeEsp').value = aDados[2];
                    codLinha = aDados[4];
                    codProduto = aDados[6];
                    $j("#linha").val(codLinha);

                    codPais = aDados[7];

                    


                    if (codPais != '0') {
                        $j("#pais").val(codPais);

                    }
                    
                     preencherComboProdutos(codLinha,codProduto);
                

                }
            });


        }


    </script>
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
            <li><a class="liMenu" href="<%=urlVolta%>"  ><img src="../includes/arvore/imagens/home.png" class="img-responsive" style="cursor: pointer;" /></a></li>
            <li><a href="ocorrenciaUsuario.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu">Ocorr&ecirc;ncias</a></li>
        </ul>    

         <%}else{ %>
              <% if(pais.Equals("Brazil")){  %>
                         <ul>
                              <li><a class="liMenu" href="<%=urlVolta%>"  ><img src="../includes/arvore/imagens/home.png" class="img-responsive" style="cursor: pointer;" /></a></li>
                          <li><a class="liMenu" href="linha.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>&idioma=<%=idioma%>&pais=<%=pais%>"  ><%=tipoMenu0 %></a></li>
                            <li><a href="produto.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>&idioma=<%=idioma%>&pais=<%=pais%>" class="liMenu"><%=tipoMenu1.Replace(":", "") %></a></li>
                            <li><a href="modelo.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>&idioma=<%=idioma%>&pais=<%=pais%>" class="liMenu"><%=tipoMenu2 %></a></li>
                            <li><a href="ocorrencia.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>&idioma=<%=idioma%>&pais=<%=pais%>" class="liMenu"><%=tipoMenu3 %></a></li>
                            <li><a href="importacao.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>&idioma=<%=idioma%>&pais=<%=pais%>" class="liMenu"><%=tipoMenu4 %></a></li>
                            <li><a href="relatorios.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>&idioma=<%=idioma%>&pais=<%=pais%>" class="liMenu"><%=tipoMenu5 %></a></li>
                        </ul>    

              
              <%}else{ %>
                   <% if(tipoArvore.Equals("Arvore Solution Center")){ %>

                          <ul>
                               <li><a class="liMenu" href="<%=urlVolta%>"  ><img src="../includes/arvore/imagens/home.png" class="img-responsive" style="cursor: pointer;" /></a></li>
                            <li><a href="modelo.aspx" class="liMenu"><%=lblMenu1 %></a></li>
                            <li><a href="ocorrencia.aspx" class="liMenu"><%=lblMenu2 %></a></li>
                           
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

            <div id="cadastro" style="position: absolute; top:0px;">
                <br />
                <br />
                <br />
                <input type="hidden" name="codigo" id="codigo" value="0" />
                
                <% if (idioma.Equals("en-US")){ %>

                <span class="reqfield" tabindex="0">
                    <img src="../includes/arvore/imagens/required.gif" alt="Asterisco" />
                    Model's name
                </span><br/><br/>
                                <div class="form-group">
                    <label for="linha" class="control-label">Line:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                    <select class="form-control" id="linha" style="width: 250px !important" onchange="retornaLinha()">
                    </select>
                </div>

                <div class="form-group">
                    <label for="produto" class="control-label">Product:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
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

                       <% if (pais.Equals("Brazil")){ %>
                <div class="form-group">
                    <label for="nomePor" class="control-label"><%=lblNome %></label>
                    <input type="text" class="form-control" id="nomePor" style="width: 300px !important" placeholder="<%=lblCampo1 %>" />
                </div>
              
                <div class="form-group">
                    <label for="nomeEsp" class="control-label"><%=lblNome2 %></label>
                    <input type="text" class="form-control" id="nomeEsp" style="width: 300px !important" placeholder="<%=lblCampo3 %>" />
                </div>
                  <div class="form-group">
                    <label for="nomeIng" class="control-label"><%=lblNome3 %></label>
                    <input type="text" class="form-control" id="nomeIng" style="width: 300px !important" placeholder="<%=lblCampo2 %>" />
                </div>
                 <% }else{ %> 
                
                  <div class="form-group">
                    <label for="nomeIng" class="control-label"><%=lblNome3 %></label>
                    <input type="text" class="form-control" id="nomeIng" style="width: 300px !important" placeholder="<%=lblCampo2 %>" />
                </div>
              
                     <input type="hidden" class="form-control" id="nomePor" />
              
                      <input type="hidden" class="form-control" id="nomeEsp" />
              

                 <% } %>   
         

                <% } else if (idioma.Equals("es-ES")){ %>
                  <span class="reqfield" tabindex="0">
                    <img src="../includes/arvore/imagens/required.gif" alt="Asterisco" />
                    Nombre del modelo
                </span><br/><br/>
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
                    <label for="pais" class="control-label"><%=lblPais %>&nbsp;&nbsp;&nbsp;</label>
                    <select class="form-control" id="pais" style="width: 190px !important" onchange="retornaPais()">
                
                    </select>
                 </div>
             <% } %>

                 <% if (pais.Equals("Brazil")){ %>
                <div class="form-group">
                    <label for="nomePor" class="control-label"><%=lblNome %></label>
                    <input type="text" class="form-control" id="nomePor" style="width: 300px !important" placeholder="<%=lblCampo1 %>" />
                </div>
              
                <div class="form-group">
                    <label for="nomeEsp" class="control-label"><%=lblNome2 %></label>
                    <input type="text" class="form-control" id="nomeEsp" style="width: 300px !important" placeholder="<%=lblCampo3 %>" />
                </div>
                  <div class="form-group">
                    <label for="nomeIng" class="control-label"><%=lblNome3 %></label>
                    <input type="text" class="form-control" id="nomeIng" style="width: 300px !important" placeholder="<%=lblCampo2 %>" />
                </div>
                 <% }else{ %> 
                
                <div class="form-group">
                    <label for="nomeEsp" class="control-label"><%=lblNome2 %></label>
                    <input type="text" class="form-control" id="nomeEsp" style="width: 300px !important" placeholder="<%=lblCampo3 %>" />
                </div>
              
                     <input type="hidden" class="form-control" id="nomePor" />
              
                      <input type="hidden" class="form-control" id="nomeIng" />
              

                 <% } %>   

                <% }else { %>

                
                 <span class="reqfield" tabindex="0">
                    <img src="../includes/arvore/imagens/required.gif" alt="Asterisco" />
                    <%=informacao %>
                </span><br/><br/>
                                <div class="form-group">
                    <label for="linha" class="control-label">Linha:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                    <select class="form-control" id="linha" style="width: 250px !important" onchange="retornaLinha()">
                    </select>
                </div>

                <div class="form-group">
                    <label for="produto" class="control-label"><%=tipoMenu1%></label>
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


                  <% if (pais.Equals("Brazil")){ %>
                <div class="form-group">
                    <label for="nomePor" class="control-label"><%=lblNome %></label>
                    <input type="text" class="form-control" id="nomePor" style="width: 300px !important" placeholder="<%=lblCampo1 %>" />
                </div>
              
                <div class="form-group">
                    <label for="nomeEsp" class="control-label"><%=lblNome2 %></label>
                    <input type="text" class="form-control" id="nomeEsp" style="width: 300px !important" placeholder="<%=lblCampo3 %>" />
                </div>
                  <div class="form-group">
                    <label for="nomeIng" class="control-label"><%=lblNome3 %></label>
                    <input type="text" class="form-control" id="nomeIng" style="width: 300px !important" placeholder="<%=lblCampo2 %>" />
                </div>
                 <% }else{ %> 
                
                  <div class="form-group">
                    <label for="nomePor" class="control-label"><%=lblNome %></label>
                    <input type="text" class="form-control" id="nomePor" style="width: 300px !important" placeholder="<%=lblCampo1 %>" />
                </div>
              
                     <input type="hidden" class="form-control" id="nomeEsp" />
              
                      <input type="hidden" class="form-control" id="nomeIng" />
              

                 <% } %>   
                 

                <% } %>

            

                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal" onclick="cancelar();"><%=lblCancelar %></button>
                    <button type="button" class="btn btn-primary" onclick="salvarDados();"><%=lblSalvar %></button>
                </div>

            </div>
            <div class="table-responsive">
            <div id="listagem" style="margin-left:35%;">
                <div class="panel panel-primary">
                    <div class="panel-heading"><%=lblLista %></div>
                    <table class="table" id="table-modelo"></table>


                </div>

            </div>
                </div>

        </fieldset>

    </div>

</div>
</body>
</html>
